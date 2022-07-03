#pragma once
#include <Windows.h>

namespace HT
{
	extern "C"  struct HTHANDLE    // ���� ���������� HT
	{
		HTHANDLE();
		HTHANDLE(int Capacity, int SecSnapshotInterval, int MaxKeyLength, int MaxPayloadLength, const wchar_t FileName[512], LPCWSTR HTUsersGroup);
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

	extern "C" struct Element   // ������� 
	{
	public:
		Element();
		Element(void* key, int keylength);                                             // for Get
		Element(void* key, int keylength, void* payload, int  payloadlength);    // for Insert
		//MATHLIBRARY_API Element(Element* oldelement, const void* newpayload, int  newpayloadlength);         // for update
		void* key;                 // �������� ����� 
		int             keylength;           // ������ �����
		void* payload;             // ������ 
		int             payloadlength;       // ������ ������
	};
};
