// 1.cpp : Server on IPv4
//
//Windows Sockets error codes: http://msdn.microsoft.com/en-us/library/ms740668(VS.85).aspx

#include "stdafx.h"
#include <winsock2.h>
#include <ws2tcpip.h> //newer functions and structs used to retrieve IP addresses
#include <iostream>
#include <fstream>
#include <string>
#include <sstream>
#include <AtlBase.h> //parameter conversion
#include <AtlConv.h>
#include <WinBase.h>

#define MYPORT "4000" //Diablo II port
#define BUFFLEN 512 //cannot exceed packet capacity
#define ROOTDIRLEN 127 //nostalgy

void showUsageHelp() {
	std::cout
		<<"Program usage:\n"
		<<"{server.exe} <root dir>\n\n"
		<<"<root dir>\tpath which will be used for translation of queries\n\t\tmaximum length is "<<ROOTDIRLEN<<"\n\n"
		<<"Send \"~~kill\" to stop the server.\n\n"
		<<std::flush;
}

int _tmain(int argc, _TCHAR* argv[])
{
	if (argc < 2) {
		showUsageHelp();
		return 100;
	}

	char serverRoot[ROOTDIRLEN];

	//WISH check for trailing / in the name
	//WISH check if the directory exists ^^
	USES_CONVERSION;
	CT2CA arg_rootdir(argv[1]);
	strncpy_s(serverRoot, arg_rootdir, ROOTDIRLEN);
	
	std::cout<<"Server root: "<<serverRoot<<std::endl;

	char clientQuery[BUFFLEN];
	std::ostringstream response;

	int error;

	//*** initialize Winsock
	WSADATA wsaData;
	//2.2 is a version number. it's the latest - from 08.1997 :D
	if ((error = WSAStartup(MAKEWORD(2,2), &wsaData)) != 0) {
		std::cerr<<"WSAStartup returned an error: "<<error<<std::endl;
		return 1;
	}

	//*** create a socket
	PADDRINFOA addrInfo = NULL;
	ADDRINFOA request;

	ZeroMemory(&request, sizeof(request));
	request.ai_family = AF_INET; //IPv4 (2)
	request.ai_socktype = SOCK_DGRAM; //socket type for UDP over IP (2) [SOCK_STREAM (1)]
	request.ai_protocol = IPPROTO_UDP; //guess; it also requires the above pair (17) [IPPROTO_TCP (6)]
	request.ai_flags = AI_PASSIVE; //socket will be used with bind() (1)

	if ((error = getaddrinfo(NULL, MYPORT, &request, &addrInfo)) != 0) {
		std::cerr<<"gettaddrinfo returned an error: "<<error<<std::endl;
		WSACleanup();
		return 2;
	}

	SOCKET listenSocket = INVALID_SOCKET;

	//teh creation
	listenSocket = socket(addrInfo->ai_family, addrInfo->ai_socktype, addrInfo->ai_protocol);

	if (listenSocket == INVALID_SOCKET) {
		std::cerr<<"Creating a socket failed miserably (error: "<<WSAGetLastError()<<')'<<std::endl;
		freeaddrinfo(addrInfo);
		WSACleanup();
		return 3;
	}

	//*** bind the socket
	if ((error = bind(listenSocket, addrInfo->ai_addr, (int)addrInfo->ai_addrlen)) != 0) {
		std::cerr<<"bind() failed: "<<WSAGetLastError()<<" :("<<std::endl;
		freeaddrinfo(addrInfo);
		closesocket(listenSocket);
		WSACleanup();
		return 4;
	}

	freeaddrinfo(addrInfo);

	//*** listen on the socket for a client
	bool awaitConnections = true;
	sockaddr peer;

	while (awaitConnections) {
		std::cout<<"Awaiting connection on port "<<MYPORT<<"..."<<std::endl;
		//TODO info about accepted connection

		//*** send and receive data
		int bytesR = 0, bytesS = 0;
		int sizeOfPeer = sizeof(peer);
		bytesR = recvfrom(listenSocket, clientQuery, BUFFLEN, 0, &peer, &sizeOfPeer);

		//maximum size of path to file/dir is 511, since we read the input only once
		if (bytesR > 0) {
			std::cout<<"Recived query: "<<clientQuery<<std::endl;

			if (strncmp(clientQuery, "~~kill", 6) == 0) {
				//client sent control code
				awaitConnections = false;
			} else {
				response.str("");
				response<<serverRoot<<clientQuery;
				std::string path = response.str();
				std::cout<<"Opening and reading "<<path<<std::flush;
				
				DWORD fileAttr = GetFileAttributesA(path.c_str());

				//WISH check for trailing / when directory is recognized
				//TODO add trailing / to directories in listings, co they appear as "dirname/"
				response.str("");
				if (fileAttr == INVALID_FILE_ATTRIBUTES) {
					std::cout<<"\nPath is invalid! Sending root directory listing..."<<std::flush;
					response<<"Invalid path! Root directory:\n";
					WIN32_FIND_DATAA search;
					path = serverRoot;
					HANDLE h = FindFirstFileA((path+'*').c_str(), &search);
					if (h == INVALID_HANDLE_VALUE) {
						response<<"EMPTY!";
					} else {
						do {
							response<<search.cFileName<<'\n';
						} while (FindNextFileA(h, &search));
						FindClose(h);
					}
				} else if (fileAttr & FILE_ATTRIBUTE_DIRECTORY) {
					std::cout<<"\nIt's a directory. Sending listing..."<<std::flush;
					response<<"Listing directory:\n";
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
				
				std::string output;
				int head = 0, tail = response.str().size();
				do {
					output = response.str().substr(head, BUFFLEN);
					bytesS += sendto(listenSocket, output.c_str(), output.size(), 0, &peer, sizeOfPeer);
					if (bytesS == SOCKET_ERROR) { //valid only for the first iteration :]
						std::cout<<"\nsend() failed:"<<WSAGetLastError()<<std::endl;
						continue;
					}
					head+=BUFFLEN;
				} while (head < tail);
			}
			//*** transmision verification
			std::string verify = "~~~";
			char tmpBuf[BUFFLEN];
			_itoa_s(bytesS, tmpBuf, BUFFLEN, 10);
			verify += tmpBuf; //hack -_-
			sendto(listenSocket, verify.c_str(), verify.size(), 0, &peer, sizeOfPeer); //finalize connection

			sendto(listenSocket, 0, 0, 0, &peer, sizeOfPeer); //finalize connection
			std::cout<<"Done."<<std::endl;

		} else if (bytesR == SOCKET_ERROR) {
			std::cerr<<"\n\nrecv() failed: "<<WSAGetLastError()<<std::endl;
			closesocket(listenSocket);
			awaitConnections = false;
		}

		std::cout<<"\n\nTotal bytes received: "<<bytesR<<"; sent: "<<bytesS<<std::endl;
	}

	//*** finalize
	closesocket(listenSocket);
	WSACleanup();

	std::cout<<"Finished."<<std::endl;
	return 0;
}
