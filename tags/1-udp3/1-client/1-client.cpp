// 1-client.cpp : Client on IPv4
//
//Windows Sockets error codes: http://msdn.microsoft.com/en-us/library/ms740668(VS.85).aspx

#include "stdafx.h"
#include <winsock2.h>
#include <ws2tcpip.h> //newer functions and structs used to retrieve IP addresses
#include <iostream>
#include <string>
#include <cstring>
#include <AtlBase.h> //parameter conversion
#include <AtlConv.h>

#define MYPORT 4000 //Diablo II port
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
	sockaddr_in Server;

	Server.sin_family = AF_INET;
	Server.sin_port = htons(MYPORT);
	Server.sin_addr.s_addr = inet_addr(serverAddress);

	SOCKET connectionSocket = INVALID_SOCKET;

	//teh creation
	connectionSocket = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);

	if (connectionSocket == INVALID_SOCKET) {
		std::cerr<<"Creating a socket failed miserably (error: "<<WSAGetLastError()<<')'<<std::endl;
		WSACleanup();
		return 3;
	}

	//*** connect to server
	std::cout<<"Connecting to "<<argv[1]<<"..."<<std::endl;

	bool transmissionOK;

	do {
		transmissionOK = true;

		//*** send and receive data
		std::cout<<"Sending query: "<<query<<" (please wait...)"<<std::endl;
		int bytesTransmitted;
		int sizeOfServer = sizeof(Server);
		bytesTransmitted = sendto(connectionSocket, query, BUFFLEN, 0, (SOCKADDR *)&Server, sizeOfServer);
		if (bytesTransmitted == SOCKET_ERROR) {
			std::cout<<"send() failed:"<<WSAGetLastError()<<std::endl;
			closesocket(connectionSocket);
			WSACleanup();
			return 9;
		} else {
			std::cout<<"Bytes sent: "<<bytesTransmitted<<std::endl;
		}

		sendto(connectionSocket, 0, 0, 0, (SOCKADDR *)&Server, sizeOfServer); //signal end of sending

		std::cout<<"Awaiting response..."<<std::endl;
		std::string controlBuf;
		int totalBT = 0, expectedSize = 0;
		do {
			bytesTransmitted = recvfrom(connectionSocket, response, BUFFLEN, 0, (SOCKADDR *)&Server, &sizeOfServer);
			if (bytesTransmitted > 0) {
				//FIXME check for transmission size and verify :]
				if (strncmp(response, "~~~", 3) == 0) {
					char tmpBuf[BUFFLEN];
					strncpy(tmpBuf, response+3, strlen(response)-3); 
					expectedSize = atoi(tmpBuf);
					std::cout<<"\n\nExpected size: "<<expectedSize<<'\t';
				} else {
					std::cout.write(response, bytesTransmitted);
					totalBT += bytesTransmitted;
				}
			} else if (bytesTransmitted == 0) {
				std::cout<<"\nConnection closed.";
			} else {
				std::cerr<<"\nrecv() failed: "<<WSAGetLastError();
			}
		} while (bytesTransmitted > 0);
		std::cout<<" Total bytes received: "<<totalBT<<std::endl;
		
		if (expectedSize != totalBT) {
			std::cout<<"Response packages broken or lost - requesting retransmission..."<<std::endl;
			transmissionOK = false;
		}

	} while (!transmissionOK);

	//*** disconnect from server
	std::cout<<"Closing connection..."<<std::flush;

	//*** finalize
	closesocket(connectionSocket);
	WSACleanup();

	std::cout<<"Done."<<std::endl;
	return 0;
}
