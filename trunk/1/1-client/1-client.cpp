// 1-client.cpp : Client on IPv4
//

#include "stdafx.h"
#include <winsock2.h>
#include <ws2tcpip.h> //newer functions and structs used to retrieve IP addresses
#include <iostream>

int _tmain(int argc, _TCHAR* argv[])
{
	int error;

	//initialize Winsock
	WSADATA wsaData;
	//2.2 is a version number.
	if ((error = WSAStartup(MAKEWORD(2,2), &wsaData)) != 0) {
		std::cout<<"WSAStartup returned and error: "<<error<<std::endl;
		return 1;
	}
	//create a socket
	//connect to the server
	//send and receive data
	//disconnect
	WSACleanup();

	return 0;
}

