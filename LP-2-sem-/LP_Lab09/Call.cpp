#include "pch.h"
#include "Call.h"

int __cdecl Call::cdevl(int &a1, int &a2, int &a3)
/*���������� �������			��������� ���������� � ���� � �������� ������� (������ ������)*/
{
	return a1*a2*a3;
};

int __stdcall Call::cstd(int b1, int &b2, int &b3)
/*���������� �������			��������� ���������� � ���� � �������� ������� (������ ������)*/
{
	return b1*b2*b3;
};

int __fastcall Call::cfst(int c1, int c2, int c3)
/*���������� �������			�������� � ���������, ����� ���������� � ����*/
{
	return c1*c2*c3;
};
