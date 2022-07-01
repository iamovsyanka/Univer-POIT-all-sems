#pragma once
#include <iostream>
#include <locale>
#include <cstdarg>

namespace Call
{
	int __cdecl cdevl(int &a1, int &a2, int &a3);

	int __stdcall cstd(int b1, int &b2, int &b3);
	
	int __fastcall cfst(int c1, int c2, int c3);
};
