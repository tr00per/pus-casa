// UDP.cpp : UDP client and server
//

#include "stdafx.h"
#include <winsock2.h>
#include <ws2tcpip.h> //newer functions and structs used to retrieve IP addresses
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <AtlBase.h> //parameter conversion
#include <AtlConv.h>
#include <WinBase.h> //directory listing
#include <list> //for queueing clients' queries

#define QUERYPORT 4000 //Diablo II port
#define DATAPORT 23073 //Soldat dedicated server port
#define BUFFLEN 512 //cannot exceed packet capacity
#define ROOTDIRLEN 128 //nostalgy
#define IPADDRLEN 16 //abc.def.ghi.jkl

SOCKET querySocket = INVALID_SOCKET;
SOCKET dataSocket = INVALID_SOCKET;

void finalize() {
	closesocket(querySocket);
	closesocket(dataSocket);
	WSACleanup();
}

void showUsageHelp() {
	std::cout
		<<"Program usage:\n"
		<<"{server.exe} <root dir>\n\n"
		<<"<root dir>\tpath which will be used for translation of queries\n\t\tmaximum length is "<<ROOTDIRLEN<<"\n\n"
		<<"Send \"~~kill\" to stop the server.\n\n"
		<<"\n{client.exe} <host address> <query>\n\n"
		<<"<host address>\tIPv4 address in a.b.c.d format\n"
		<<"<query>\t\tfile to view or directory to list\n\t\tmaximum lenght is "<<BUFFLEN<<"; overlapping chars will be ignored\n\n"
		<<std::flush;
}

char serverAddress[IPADDRLEN];
char clientQuery[BUFFLEN];
char serverRoot[ROOTDIRLEN];
char transBuffer[BUFFLEN];

void listDirectory(std::string& path, std::ostringstream& response) {
	//TODO add trailing / to directories in listings, co they appear as "dirname/"
	WIN32_FIND_DATAA search;
	HANDLE h = FindFirstFileA((path+'*').c_str(), &search);
	if (h == INVALID_HANDLE_VALUE) {
		response<<"EMPTY!";
	} else {
		do {
			response<<search.cFileName<<'\n';
		} while (FindNextFileA(h, &search));
		FindClose(h);
	}
}

void gatherOuputData(std::ostringstream& response) {
	response.str("");
	response<<serverRoot<<clientQuery;
	std::string path = response.str();
	std::cout<<"Opening and reading "<<path<<std::flush;
	
	DWORD fileAttr = GetFileAttributesA(path.c_str());

	//WISH check for trailing / when directory is recognized
	response.str("");
	if (fileAttr == INVALID_FILE_ATTRIBUTES) {
		std::cout<<"\nPath is invalid! Sending root directory listing..."<<std::flush;
		response<<"Invalid path! Root directory:\n";
		path = serverRoot;

		listDirectory(path, response);
	} else if (fileAttr & FILE_ATTRIBUTE_DIRECTORY) {
		std::cout<<"\nIt's a directory. Sending listing..."<<std::flush;
		response<<"Listing directory:\n";

		listDirectory(path, response);
	} else {
		std::ifstream fin(path.c_str());
		char buf[BUFFLEN];
		while (!fin.eof()) {
			fin.read(buf, BUFFLEN);
			response.write(buf, fin.gcount());
			std::cout<<'.'<<std::flush;
		}
		fin.close();
		std::cout<<"\nSending file content..."<<std::flush;
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	enum {CLIENT, SERVER} state = CLIENT;

	USES_CONVERSION;

	if (argc == 2) {
		//WISH check for trailing / in the name
		//WISH check if the directory exists ^^
		CT2CA arg_rootdir(argv[1]);
		strncpy_s(serverRoot, arg_rootdir, ROOTDIRLEN-1);
		serverRoot[ROOTDIRLEN-1] = '\0';
	
		state = SERVER;
		std::cout<<"Server root: "<<serverRoot<<std::endl;
	} else if (argc == 3) {
		//WISH check if input is correct (i.e. doesn't contain "..")
		CT2CA arg_ip(argv[1]);
		strncpy_s(serverAddress, arg_ip, IPADDRLEN-1);
		serverAddress[IPADDRLEN-1] = '\0';

		CT2CA arg_query(argv[2]);
		strncpy_s(clientQuery, arg_query, BUFFLEN-1);
		clientQuery[BUFFLEN-1] = '\0';

		//state already set to CLIENT
		std::cout<<"Server address: "<<serverAddress<<"\nClient query: "<<clientQuery<<std::endl;
	} else {
		showUsageHelp();
		return 1;
	}

	int error;

	//**** inicjalizuj Winsock
	WSADATA wsaData;
	//wersja 2.2; prosto z sierpnia 1997 roku ;P
	if ((error = WSAStartup(MAKEWORD(2,2), &wsaData)) != 0) {
		std::cerr<<"WSAStartup returned an error: "<<error<<std::endl;
		return 2;
	}

	//**** otwórz oba sockety
	querySocket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (querySocket == INVALID_SOCKET) {
		std::cerr<<"Error while creating query socket: "<<WSAGetLastError()<<std::endl;
		WSACleanup();
		return 3;
	}

	dataSocket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	if (dataSocket == INVALID_SOCKET) {
		std::cerr<<"Error while creating query socket: "<<WSAGetLastError()<<std::endl;
		closesocket(querySocket);
		WSACleanup();
		return 3;
	}

	//**** wymuszenie obliczania sum kontrolnych
	//dostêpne do WinXP
	//bool optVal = true;
	//int optLen = sizeof(bool);
	//setsockopt(querySocket, IPPROTO_UDP, UDP_CHECKSUM_COVERAGE, (char*)&optVal, optLen);
	//setsockopt(dataSocket, IPPROTO_UDP, UDP_CHECKSUM_COVERAGE, (char*)&optVal, optLen);

	if (state == SERVER) {////////////////////////////////////////////////////////////// SERVER ////
		//**** przygotuj kolejkê dla klientów
		struct ClientRequest {
			sockaddr * address;
			int addressSize;
			char query[BUFFLEN];

			ClientRequest(sockaddr_in& addr, int size, const char * q, int qLen): addressSize(size) {
				address = new sockaddr();
				memcpy((void *)address, (const void *)&addr, size);//HACK find a better way
				strncpy_s(query, q, qLen);
			}

			~ClientRequest() {
				delete address;
			}
		};
		std::list<ClientRequest *> queue;
		typedef std::list<ClientRequest *>::iterator queueIter;

		sockaddr_in peer;
		int peerSize = sizeof(peer);
		//## recv query @ queueSocket
		int trans = recvfrom(querySocket, clientQuery, BUFFLEN, 0, (sockaddr *)&peer, &peerSize);

		//## add to client queue
		peer.sin_port = htons(DATAPORT); //zmieñ na port odbioru danych
		ClientRequest * cr = new ClientRequest(peer, peerSize, clientQuery, trans);

		//## handle first of queued clients
		//## send data @ dataSocket
		//## recv ack @ dataSocket

		//finalize
		if (queue.size() > 0) {
			for (queueIter iter = queue.begin(); iter != queue.end(); ++iter) {
				strncpy_s(clientQuery, "SHD", 4); //SDH - SHutDown
				sendto(dataSocket, clientQuery, 4, 0, (*iter)->address, (*iter)->addressSize);
				delete *iter;
			}
		}
	} else if (state == CLIENT) {////////////////////////////////////////////////////////////// CLIENT ////
		sockaddr_in srv;
		int srvSize = sizeof(srv);
		srv.sin_family = AF_INET;
		srv.sin_addr.s_addr = inet_addr(serverAddress);
		srv.sin_port = htons(QUERYPORT);

		//## send query @ queueSocket
		int trans = sendto(querySocket, clientQuery, BUFFLEN, 0, (sockaddr *)&srv, srvSize);
		if (trans == SOCKET_ERROR) {
			std::cerr<<"sendto(QUERY) failed:"<<WSAGetLastError()<<std::endl;
			finalize();
			return 5;
		} else {
			std::cout<<"Bytes sent: "<<trans<<std::endl;
		}
		
		//zmieñ port zapytania na port danych
		srv.sin_port = htons(DATAPORT);

		std::cout<<"\n\n";
		int totalTrans = 0;
		do {
			//## recv data @ dataSocket
			trans = recvfrom(dataSocket, transBuffer, BUFFLEN, 0, (sockaddr *)&srv, &srvSize);
			if (trans == SOCKET_ERROR) {
				std::cerr<<"recvfrom() failed! Error code: "<<WSAGetLastError()<<std::endl;
				finalize();
				return 5;
			}
			
			std::cout.write(transBuffer, trans);

			if (trans != 4 || strncmp("SHD", transBuffer, 3) != 0) {
				totalTrans += trans;

				//## send ack @ dataSocket
				strncpy_s(clientQuery, "ACK", 4); //¿eby ³adnie zakoñczy³ stringa '\0'
				trans = sendto(dataSocket, clientQuery, 4, 0, (sockaddr *)&srv, srvSize);
				if (trans == SOCKET_ERROR) {
					std::cerr<<"sendto(ACK) failed! Error code: "<<WSAGetLastError()<<std::endl;
					finalize();
					return 5;
				}
			}

			if (trans < BUFFLEN) {
				std::cout<<"\n\nTranssmision ended."<<std::endl;
			}	
		} while (trans == 512);
		std::cout<<"Total bytes received: "<<totalTrans<<std::endl;
	}

	//**** zakoñcz pracê z Winsock
	finalize();

	std::cout<<"Koniec."<<std::endl;
	return 0;
}
