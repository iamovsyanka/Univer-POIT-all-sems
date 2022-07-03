#pragma once
#include <Windows.h>
#include "HT.h"

namespace HTAPI    // HT API
{
	bool OpenApi();
	bool CloseApi();

	HT::HTHANDLE* Create   //  ������� HT             
	(
		int	  Capacity,					   // ������� ���������
		int   SecSnapshotInterval,		   // ������������� ���������� � ���.
		int   MaxKeyLength,                // ������������ ������ �����
		int   MaxPayloadLength,            // ������������ ������ ������
		char  FileName[512],          // ��� ����� 
		LPCWSTR HTUsersGroup
	);

	HT::HTHANDLE* Open     //  ������� HT             
	(
		char    FileName[512]         // ��� ����� 
	); 	// != NULL �������� ����������  

	HT::HTHANDLE* Open     //  ������� HT             
	(
		char    FileName[512],
		LPCWSTR userName,
		LPCWSTR password
	);


	BOOL Snap         // ��������� Snapshot
	(
		HT::HTHANDLE* hthandle           // ���������� HT (File, FileMapping)
	);

	BOOL Close        // Snap � ������� HT  �  �������� HT::HTHANDLE
	(
		HT::HTHANDLE* hthandle           // ���������� HT (File, FileMapping)
	);	//  == TRUE �������� ����������   

	BOOL Insert      // �������� ������� � ���������
	(
		HT::HTHANDLE* hthandle,            // ���������� HT
		HT::Element* element              // �������
	);	//  == TRUE �������� ���������� 

	BOOL Delete      // ������� ������� � ���������
	(
		HT::HTHANDLE* hthandle,            // ���������� HT (����)
		HT::Element* element              // ������� 
	);	//  == TRUE �������� ���������� 

	HT::Element* Get     //  ������ ������� � ���������
	(
		HT::HTHANDLE* hthandle,            // ���������� HT
		HT::Element* element              // ������� 
	); 	//  != NULL �������� ���������� 

	BOOL Update     //  ������� ������� � ���������
	(
		HT::HTHANDLE* hthandle,            // ���������� HT
		HT::Element* oldelement,          // ������ ������� (����, ������ �����)
		void* newpayload,          // ����� ������  
		int             newpayloadlength     // ������ ����� ������
	); 	//  != NULL �������� ���������� 

	char* GetLastHtError  // �������� ��������� � ��������� ������
	(
		HT::HTHANDLE* ht                         // ���������� HT
	);
};
