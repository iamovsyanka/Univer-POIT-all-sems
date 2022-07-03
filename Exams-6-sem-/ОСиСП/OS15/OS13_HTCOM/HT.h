#pragma once
#define _CRT_SECURE_NO_WARNINGS
#include <Windows.h>

#define MATHLIBRARY_API __declspec(dllexport)

namespace HT
{
	// API HT - ����������� ��������� ��� ������� � ��-��������� 
	//          ��-��������� ������������� ��� �������� ������ � �� � ������� ����/��������
	//          ���������������� (�����������) ������ �������������� � ������� snapshot-���������� 
	//          Create - �������  � ������� HT-��������� ��� �������������   
	//          Open   - ������� HT-��������� ��� �������������
	//          Insert - ������� ������� ������
	//          Delete - ������� ������� ������    
	//          Get    - ������  ������� ������
	//          Update - �������� ������� ������
	//          Snap   - �������� snapshot
	//          Close  - ��������� Snap � ������� HT-��������� ��� �������������
	//          GetLastError - �������� ��������� � ��������� ������

	MATHLIBRARY_API struct HTHANDLE    // ���� ���������� HT
	{
		HTHANDLE();
		MATHLIBRARY_API HTHANDLE(int Capacity, int SecSnapshotInterval, int MaxKeyLength, int MaxPayloadLength, wchar_t FileName[512], LPCWSTR HTUsersGroup);
		int     Capacity = 20;               // ������� ��������� � ���������� ��������� 
		int     SecSnapshotInterval = 120;    // ������������� ���������� � ���. 
		int     MaxKeyLength = 64;           // ������������ ����� �����
		int     MaxPayloadLength = 64;       // ������������ ����� ������
		wchar_t    FileName[512] = L"map.txt";          // ��� ����� 
		HANDLE  File = 0;                   // File HANDLE != 0, ���� ���� ������
		HANDLE  FileMapping = 0;            // Mapping File HANDLE != 0, ���� mapping ������  
		LPVOID  Addr = 0;                   // Addr != NULL, ���� mapview ��������. ����� � ����� ���������� ��������  
		char    LastErrorMessage[512] = "\0";  // ��������� �� ��������� ������ ��� 0x00  
		time_t  lastsnaptime = 0;           // ���� ���������� snap'a (time())  

		wchar_t mutexName[512];
		wchar_t fileMapName[512];
		wchar_t timerName[512];
		wchar_t HTUsersGroup[512];
		DWORD creatorPid;
		HANDLE hTimer;
		HANDLE hTimerThread;
	};

	extern "C" MATHLIBRARY_API struct Element   // ������� 
	{
		public:
			Element(void* key, int keylength);                                             // for Get
			Element(void* key, int keylength, void* payload, int  payloadlength);    // for Insert
			//MATHLIBRARY_API Element(Element* oldelement, void* newpayload, int  newpayloadlength);         // for update
			void* key;                 // �������� ����� 
			int             keylength;           // ������ �����
			void* payload;             // ������ 
			int             payloadlength;       // ������ ������
	};

	Element* CreateElement(void* key, int keylength);
	Element* CreateElement(void* key, int keylength, void* payload, int  payloadlength);
	HTHANDLE* Create   //  ������� HT             
	(
		int	  Capacity,					   // ������� ���������
		int   SecSnapshotInterval,		   // ������������� ���������� � ���.
		int   MaxKeyLength,                // ������������ ������ �����
		int   MaxPayloadLength,            // ������������ ������ ������
		char  FileName[512],          // ��� ����� 
		LPCWSTR HTUsersGroup
	); 	// != NULL �������� ����������  

	MATHLIBRARY_API  HTHANDLE* Open     //  ������� HT             
	(
		char    FileName[512]         // ��� ����� 
	); 	// != NULL �������� ����������  

	MATHLIBRARY_API  HTHANDLE* Open     //  ������� HT             
	(
		char    FileName[512],
		LPCWSTR userName,
		LPCWSTR password
	);

	extern "C" MATHLIBRARY_API  BOOL Snap         // ��������� Snapshot
	(
		HTHANDLE * hthandle           // ���������� HT (File, FileMapping)
	);

	extern "C" MATHLIBRARY_API BOOL Close        // Snap � ������� HT  �  �������� HTHANDLE
	(
		HTHANDLE * hthandle           // ���������� HT (File, FileMapping)
	);	//  == TRUE �������� ����������   

	extern "C" MATHLIBRARY_API BOOL Insert      // �������� ������� � ���������
	(
		HTHANDLE * hthandle,            // ���������� HT
		Element * element              // �������
	);	//  == TRUE �������� ���������� 

	extern "C" MATHLIBRARY_API BOOL Delete      // ������� ������� � ���������
	(
		HTHANDLE * hthandle,            // ���������� HT (����)
		Element * element              // ������� 
	);	//  == TRUE �������� ���������� 

	extern "C" MATHLIBRARY_API Element * Get     //  ������ ������� � ���������
	(
		HTHANDLE * hthandle,            // ���������� HT
		Element * element              // ������� 
	); 	//  != NULL �������� ���������� 

	extern "C" MATHLIBRARY_API int PrintAll     // print all elements aand return their count
	(
		HTHANDLE * ht           // ���������� HT
	); 	//  != NULL �������� ���������� 

	extern "C" MATHLIBRARY_API BOOL Update     //  ������� ������� � ���������
	(
		HTHANDLE * hthandle,            // ���������� HT
		Element * oldelement,          // ������ ������� (����, ������ �����)
		void* newpayload,          // ����� ������  
		int             newpayloadlength     // ������ ����� ������
	); 	//  != NULL �������� ���������� 

	extern "C" MATHLIBRARY_API char* GetLastHtError  // �������� ��������� � ��������� ������
	(
		HTHANDLE * ht                         // ���������� HT
	);

	extern "C" MATHLIBRARY_API void print                               // ����������� ������� 
	(
		Element * element              // ������� 
	);
};