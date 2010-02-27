// 1.cpp : Server on IPv4
//
//Windows Sockets error codes: http://msdn.microsoft.com/en-us/library/ms740668(VS.85).aspx

#include "stdafx.h"
#include <winsock2.h>
#include <ws2tcpip.h> //newer functions and structs used to retrieve IP addresses
#include <iostream> //cout, cerr,...
#include <fstream> //ifstream
#include <string> //sring
#include <sstream> //ostringstream
#include <csignal> //stignal()

#define MYPORT "4000" //Diablo II port
#define BUFFLEN 512

bool awaitClients = true;

void breakLoop(int a) {
	awaitClients = false;
}

int _tmain(int argc, _TCHAR* argv[])
{
	signal(SIGINT, breakLoop);

	//TODO read root dir and port number from command line
	char * serverRoot = "c:\\test\\";

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
	request.ai_socktype = SOCK_STREAM; //socket type for TCP over IP (1)
	request.ai_protocol = IPPROTO_TCP; //guess; it also requires the above pair (6)
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
	//FIXME asynchronous loop breaking
	while (awaitClients) {
		std::cout<<"Awaiting connection on port "<<MYPORT<<"..."<<std::endl;
		//SOMAXCONN - maximum, reasonable number of pending connections (0x7fffffff - madness?)
		if (listen(listenSocket, SOMAXCONN) == SOCKET_ERROR) {
			std::cerr<<"Socket error @ listen(): "<<WSAGetLastError()<<std::endl;
			continue;
		}

		//*** accept a connection from a client
		SOCKET tmpSocket = INVALID_SOCKET;

		//accept() is simpler than WSAAccept() - attempts to accept all connections,
		//whereas WSAA...() requires a condition
		if ((tmpSocket = accept(listenSocket, NULL, NULL)) == INVALID_SOCKET) {
			std::cerr<<"Uncool host attempted to connect; accept() failed: "<<WSAGetLastError()<<std::endl;
			continue;
		}
		//WISH info about accepted connection

		//*** send and receive data
		int bytesR, bytesS;
		bytesR = recv(tmpSocket, clientQuery, BUFFLEN, 0);

		//maximum size of path to file/dir is 511, since we read the input only once
		if (bytesR > 0) {
			std::cout<<"Recived query: "<<clientQuery<<std::endl;

			//TODO check if the path exists
			//WISH dir listing
			
			response.str("");
			response<<serverRoot<<clientQuery;
			std::cout<<"Opening and reading "<<response.str()<<"..."<<std::endl;
			std::ifstream fin(response.str().c_str());
			char buf[BUFFLEN];
			response.str("");
			while (!fin.eof()) {
				fin.getline(buf, BUFFLEN);
				response<<buf;
			}
			fin.close();
			std::cout<<"Sending file content..."<<std::flush;
			bytesS = send(tmpSocket, response.str().c_str(), response.str().size(), 0);
			if (bytesS == SOCKET_ERROR) {
				std::cout<<"\nsend() failed:"<<WSAGetLastError()<<std::endl;
				closesocket(tmpSocket);
				continue;
			}
			std::cout<<"Done."<<std::endl;
			
		} else if (bytesR == SOCKET_ERROR) {
			std::cerr<<"\n\nrecv() failed: "<<WSAGetLastError()<<std::endl;
			closesocket(tmpSocket);
			continue;
		}

		std::cout<<"\n\nTotal bytes received: "<<bytesR<<"; sent: "<<bytesS<<std::endl;

		//*** disconnect client
		std::cout<<"Closing client connection..."<<std::flush;
		if ((error = shutdown(tmpSocket, SD_SEND)) == SOCKET_ERROR) {
			std::cerr<<"\nCannot shutdown connection! Forcing close."<<std::endl;
			closesocket(tmpSocket);
			continue;
		}
		closesocket(tmpSocket);
		std::cout<<"Done."<<std::endl;
	}

	//*** finalize
	closesocket(listenSocket);
	WSACleanup();

	std::cout<<"Finished."<<std::endl;
	return 0;
}
