// 1.cpp : Server on IPv4
//
//Windows Sockets error codes: http://msdn.microsoft.com/en-us/library/ms740668(VS.85).aspx

#include "stdafx.h"
#include <winsock2.h>
#include <ws2tcpip.h> //newer functions and structs used to retrieve IP addresses
#include <iostream>

#define MYPORT "4000" //Diablo II port
#define BUFFLEN 512

int _tmain(int argc, _TCHAR* argv[])
{
	int error;

	//*** initialize Winsock
	WSADATA wsaData;
	//2.2 is a version number. it's the latest - from 08.1997 :D
	if ((error = WSAStartup(MAKEWORD(2,2), &wsaData)) != 0) {
		std::cout<<"WSAStartup returned an error: "<<error<<std::endl;
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
		std::cout<<"gettaddrinfo returned an error: "<<error<<std::endl;
		WSACleanup();
		return 2;
	}

	SOCKET listenSocket = INVALID_SOCKET;

	//teh creation
	listenSocket = socket(addrInfo->ai_family, addrInfo->ai_socktype, addrInfo->ai_protocol);

	if (listenSocket = INVALID_SOCKET) {
		std::cout<<"Creating a socket failed miserabely (error: "<<WSAGetLastError()<<')'<<std::endl;
		freeaddrinfo(addrInfo);
		WSACleanup();
		return 3;
	}

	//*** bind the socket
	if ((error = bind(listenSocket, addrInfo->ai_addr, (int)addrInfo->ai_addrlen)) != 0) {
		std::cout<<"bin() failed: "<<WSAGetLastError()<<" :("<<std::endl;
		freeaddrinfo(addrInfo);
		closesocket(listenSocket);
		WSACleanup();
		return 4;
	}

	freeaddrinfo(addrInfo);

	//*** listen on the socket for a client
	std::cout<<"Awaiting connection on port "<<MYPORT<<"..."<<std::endl;
	//SOMAXCONN - maximum, reasonable number of pending connections (0x7fffffff - madness?)
	if (listen(listenSocket, SOMAXCONN) == SOCKET_ERROR) {
		std::cout<<"Socket error @ listen(): "<<WSAGetLastError()<<std::endl;
		closesocket(listenSocket);
		WSACleanup();
		return 5;
	}

	//*** accept a connection from a client
	SOCKET tmpSocket = INVALID_SOCKET;

	//accept() simpler than WSAAccept() - attempts to accept all connections,
	//whereas WSAA...() requires a condition
	if ((tmpSocket = accept(listenSocket, NULL, NULL)) == INVALID_SOCKET) {
		std::cout<<"Uncool host attempted to connect; accept() failed: "<<WSAGetLastError()<<std::endl;
		closesocket(listenSocket);
		WSACleanup();
		return 6;
	}

	//*** send and receive data
	//TODO magic goes here :]

	//*** disconnect client
	if ((error = shutdown(tmpSocket, SD_SEND)) == SOCKET_ERROR) {
		std::cout<<"Cannot shutdown connection!"<<std::endl;
		closesocket(tmpSocket);
		closesocket(listenSocket);
		WSACleanup();
		return 7;
	}
	closesocket(tmpSocket);

	//*** finalize
	closesocket(listenSocket);
	WSACleanup();

	return 0;
}
