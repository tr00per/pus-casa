// 1-client.cpp : Client on IPv4
//
//Windows Sockets error codes: http://msdn.microsoft.com/en-us/library/ms740668(VS.85).aspx

#include "stdafx.h"
#include <winsock2.h>
#include <ws2tcpip.h> //newer functions and structs used to retrieve IP addresses
#include <iostream>
#include <string>

#define MYPORT "4000" //Diablo II port
#define BUFFLEN 512

int _tmain(int argc, _TCHAR* argv[])
{
	char * serverAddress = "192.168.0.1";
	char query[BUFFLEN] = "test.txt";
	char response[BUFFLEN] = {0};

	int error;

	//*** initialize Winsock
	WSADATA wsaData;
	//2.2 is a version number
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


	if ((error = getaddrinfo(serverAddress, MYPORT, &request, &addrInfo)) != 0) {
		std::cerr<<"gettaddrinfo returned an error: "<<error<<std::endl;
		WSACleanup();
		return 2;
	}

	SOCKET connectionSocket = INVALID_SOCKET;

	//teh creation
	connectionSocket = socket(addrInfo->ai_family, addrInfo->ai_socktype, addrInfo->ai_protocol);

	if (connectionSocket == INVALID_SOCKET) {
		std::cerr<<"Creating a socket failed miserably (error: "<<WSAGetLastError()<<')'<<std::endl;
		freeaddrinfo(addrInfo);
		WSACleanup();
		return 3;
	}

	//*** connect to server
	std::cout<<"Connecting to "<<argv[1]<<"..."<<std::endl;

	if ((error = connect(connectionSocket, addrInfo->ai_addr, (int)addrInfo->ai_addrlen)) == SOCKET_ERROR) {
		PADDRINFOA tmpAI = addrInfo;
		//cycle through additional addresses
		while (tmpAI->ai_next != NULL) {
			std::cerr<<"Retrying on another interface..."<<std::endl;
			tmpAI = tmpAI->ai_next;
			error = connect(connectionSocket, tmpAI->ai_addr, (int)tmpAI->ai_addrlen);
			if (error != SOCKET_ERROR) break;
		}
		if (error == SOCKET_ERROR) { //maybe there's no server on the other side?
			std::cerr<<"Unable to connect!"<<std::endl;
			closesocket(connectionSocket);
			freeaddrinfo(addrInfo);
			WSACleanup();
			return 8;
		}
	}

	freeaddrinfo(addrInfo);
	
	//*** send and receive data
	std::cout<<"Sending query: "<<query<<" (please wait...)"<<std::endl;
	int bytesTransmitted;
	bytesTransmitted = send(connectionSocket, query, BUFFLEN, 0);
	std::cout<<"Bytes send: "<<bytesTransmitted<<std::endl;
	//TODO error check (SOCKET_ERROR)

	shutdown(connectionSocket, SD_SEND);
	//TODO error check (SOCKET_ERROR)

	std::cout<<"Awaiting response..."<<std::endl;
	int totalBT = 0;
	do {
		bytesTransmitted = recv(connectionSocket, response, BUFFLEN, 0);
		if (bytesTransmitted > 0) {
			std::cout<<response<<std::flush;
			totalBT += bytesTransmitted;
		} else if (bytesTransmitted == 0) {
			std::cout<<"\n\nConnection closed. ";
		} else {
			std::cerr<<"\n\nrecv() failed: "<<WSAGetLastError()<<std::endl;
		}
	} while (bytesTransmitted > 0);
	std::cout<<"Total bytes received: "<<totalBT<<std::endl;

	//*** disconnect from server
	if ((error = shutdown(connectionSocket, SD_SEND)) == SOCKET_ERROR) {
		std::cerr<<"Cannot shutdown connection!"<<std::endl;
		closesocket(connectionSocket);
		WSACleanup();
		return 7;
	}

	//*** finalize
	closesocket(connectionSocket);
	WSACleanup();

	std::cout<<"Done."<<std::endl;
	return 0;
}
