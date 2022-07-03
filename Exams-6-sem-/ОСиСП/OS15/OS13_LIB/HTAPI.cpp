#pragma once
#include <Windows.h>
#include <objbase.h>
#include "HTAPI.h"
#include "IHT.h"
#include <iostream>

namespace HTAPI 
{
	IHashTable* pIHashTable = nullptr;
	IUnknown* pIUnknown = NULL;

	bool  HTAPI::OpenApi() {
		CoInitialize(NULL);                        // ������������� ���������� OLE32
		HRESULT hr0 = CoCreateInstance(CLSID_CA, NULL, CLSCTX_INPROC_SERVER, IID_IUnknown, (void**)&pIUnknown);
		if (SUCCEEDED(hr0))
		{
			std::cout << "CoCreateInstance succeeded" << std::endl;
			if (SUCCEEDED(pIUnknown->QueryInterface(IID_IHashTable, (void**)&pIHashTable)))
			{
				return true;
			}
		}
		return false;
	}

	bool  HTAPI::CloseApi() {
		bool res = true;
		if (!SUCCEEDED(pIHashTable->Release()))
			res = false;
		if (!SUCCEEDED(pIUnknown->Release()))
			res = false;
		CoFreeUnusedLibraries();
		return true;
	}

	HT::HTHANDLE* HTAPI::Create   //  ������� HT             
	(
		int	  Capacity,					   // ������� ���������
		int   SecSnapshotInterval,		   // ������������� ���������� � ���.
		int   MaxKeyLength,                // ������������ ������ �����
		int   MaxPayloadLength,            // ������������ ������ ������
		char  FileName[512],          // ��� �����
		LPCWSTR HTUsersGroup
	) {
		HT::HTHANDLE* pht;
		if (SUCCEEDED(pIHashTable->Create(
			&pht, Capacity, SecSnapshotInterval, MaxKeyLength, MaxPayloadLength, FileName, HTUsersGroup))) {
			return pht;
		}
		else {
			return NULL;
		}
	}

	HT::HTHANDLE* HTAPI::Open     //  ������� HT             
	(
		char    FileName[512]         // ��� ����� 
	) {
		HT::HTHANDLE* pht;
		if (SUCCEEDED(pIHashTable->Open(FileName, &pht))) {
			return pht;
		}
		else {
			return NULL;
		}
	}

	HT::HTHANDLE* HTAPI::Open     //  ������� HT             
	(
		char    FileName[512],
		LPCWSTR userName,
		LPCWSTR password
	) {
		HT::HTHANDLE* pht;
		if (SUCCEEDED(pIHashTable->Open(FileName, userName, password, &pht))) {
			return pht;
		}
		else {
			return NULL;
		}
	}

	BOOL Snap         // ��������� Snapshot
	(
		HT::HTHANDLE* hthandle           // ���������� HT (File, FileMapping)
	) {
		if (SUCCEEDED(pIHashTable->Snap(&hthandle))) {
			return true;
		}
		else {
			return false;
		}
	}

	BOOL Close        // Snap � ������� HT  �  �������� HT::HTHANDLE
	(
		HT::HTHANDLE* hthandle           // ���������� HT (File, FileMapping)
	) {

		if (SUCCEEDED(pIHashTable->Close(&hthandle))) {
			return true;
		}
		else {
			return false;
		}
	}

	BOOL Insert      // �������� ������� � ���������
	(
		HT::HTHANDLE* hthandle,            // ���������� HT
		HT::Element* element              // �������
	) {
		if (SUCCEEDED(pIHashTable->Insert(&hthandle, element))) {
			return true;
		}
		else {
			return false;
		}
	}

	BOOL Delete      // ������� ������� � ���������
	(
		HT::HTHANDLE* hthandle,            // ���������� HT (����)
		HT::Element* element              // ������� 
	) {
		if (SUCCEEDED(pIHashTable->Delete(&hthandle, element))) {
			return true;
		}
		else {
			return false;
		}
	}

	HT::Element* Get     //  ������ ������� � ���������
	(
		HT::HTHANDLE* hthandle,            // ���������� HT
		HT::Element* element              // ������� 
	) {
		HT::Element result;
		if (SUCCEEDED(pIHashTable->Get(result, &hthandle, element))) {
			return &result;
		}
		else {
			return NULL;
		}
	}

	BOOL Update     //  ������� ������� � ���������
	(
		HT::HTHANDLE* hthandle,            // ���������� HT
		HT::Element* oldelement,          // ������ ������� (����, ������ �����)
		void* newpayload,          // ����� ������  
		int             newpayloadlength     // ������ ����� ������
	) {
		if (SUCCEEDED(pIHashTable->Update(&hthandle, oldelement, newpayload, newpayloadlength))) {
			return true;
		}
		else {
			return false;
		}
	}

	char* GetLastHtError  // �������� ��������� � ��������� ������
	(
		HT::HTHANDLE* ht                         // ���������� HT
	) {
		std::string err;
		if (SUCCEEDED(pIHashTable->GetLastHtError(err, &ht))) {
			return (char*)(err.c_str());
		}
		else {
			return NULL;
		}
	}
};
