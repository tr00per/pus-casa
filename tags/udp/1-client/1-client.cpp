// 1-client.cpp : Client on IPv4
//
//Windows Sockets error codes: http://msdn.microsoft.com/en-us/library/ms740668(VS.85).aspx

#include "stdafx.h"
#include <winsock2.h>
#include <ws2tcpip.h> //newer functions and structs used to retrieve IP addresses
#include <iostream>
#include <string>
#include <AtlBase.h> //parameter conversion
#include <AtlConv.h>

#define MYPORT "4000" //Diablo II port
#define BUFFLEN 512 //cannot exceed packet capacity
#define IPADDRLEN 16 //abc.def.ghi.jkl

void showUsageHelp() {
	std::cout
		<<"Program usage:\n"
		<<"{client.exe} <host address> <query>\n\n"
		<<"<host address>\tIPv4 address in a.b.c.d format\n"
		<<"<query>\t\tfile to view or directory to list\n\t\tmaximum lenght is "<<BUFFLEN<<"; overlapping chars will be ignored\n\n"
		<<std::flush;
}

int _tmain(int argc, _TCHAR* argv[])
{
	if (argc < 3) {
		showUsageHelp();
		return 100;
	}

	char serverAddress[IPADDRLEN];
	char query[BUFFLEN];

	//WISH check if input is correct (i.e. doesn't contain "..")
	USES_CONVERSION;
	CT2CA arg_ip(argv[1]);
	strncpy_s(serverAddress, arg_ip, IPADDRLEN);
	CT2CA arg_query(argv[2]);
	strncpy_s(query, arg_query, BUFFLEN);

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
	request.ai_socktype = SOCK_DGRAM; //socket type for UDP over IP (2) [SOCK_STREAM (1)]
	request.ai_protocol = IPPROTO_UDP; //guess; it also requires the above pair (17) [IPPROTO_TCP (6)]


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
	if (bytesTransmitted == SOCKET_ERROR) {
		std::cout<<"send() failed:"<<WSAGetLastError()<<std::endl;
		closesocket(connectionSocket);
		WSACleanup();
		return 9;
	} else {
		std::cout<<"Bytes sent: "<<bytesTransmitted<<std::endl;
	}
	
	if ((error = shutdown(connectionSocket, SD_SEND)) == SOCKET_ERROR) {
		std::cerr<<"\nCannot shutdown connection!"<<std::endl;
		closesocket(connectionSocket);
		WSACleanup();
		return 10;
	}

	std::cout<<"Awaiting response..."<<std::endl;
	int totalBT = 0;
	do {
		bytesTransmitted = recv(connectionSocket, response, BUFFLEN, 0);
		if (bytesTransmitted > 0) {
			std::cout.write(response, bytesTransmitted);
			totalBT += bytesTransmitted;
		} else if (bytesTransmitted == 0) {
			std::cout<<"\n\nConnection closed. ";
		} else {
			std::cerr<<"\n\nrecv() failed: "<<WSAGetLastError()<<std::endl;
		}
	} while (bytesTransmitted > 0);
	std::cout<<"Total bytes received: "<<totalBT<<std::endl;

	//*** disconnect from server
	std::cout<<"Closing connection..."<<std::flush;
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
