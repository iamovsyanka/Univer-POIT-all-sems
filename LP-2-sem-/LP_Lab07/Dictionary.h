#pragma once
#include "pch.h"
#include <iostream>
#define DICTNAMEMAXSIZE 20
#define DICTMAXSIZE 100
#define ENTRYNAMEMAXSIZE 30
#define THROW01 "Create: �������� ������ ����� �������"
#define THROW02 "Create: �������� ������ ������������ ������� �������"
#define THROW03 "AddEntry: ������������ �������"
#define THROW04 "AddEntry: ������������ ��������������"
#define THROW05 "GetEntry: �� ������ �������"
#define THROW06 "DelEntry: �� ������ �������"
#define THROW07 "UpdEntry: �� ������ �������"
#define THROW08 "UpdEntry: ������������ ��������������"
namespace Dictionary
{
	struct Entry //������� �������
	{
		int id;
		char name[ENTRYNAMEMAXSIZE];
		Entry(const char*n, int i)
		{
			strcpy_s(name, n);
			id = i;
		}
		Entry()
		{
			strcpy_s(name, "");
			id = 0;
		}
	};
	struct Instance
	{
		char name[DICTNAMEMAXSIZE];
		int maxsize;// < DICTMAXSIZE
		int size; //������� ������
		Entry* dictionary;
	};
	//-----------------------------------------------------

	Instance Create(const char *n, int size);
	void AddEntry(Instance& dict, Entry* element);
	Entry GetEntry(Instance dict, int id);
	void DelEntry(Instance& dict, int id);
	void Delete(Instance& dict);
	void UpdEntry(Instance& dict, int id, Entry new_entry);
	int GetIndexEntryR(Instance dict, int id);
	void Print(Instance &dict);
}