#include "pch.h"
#include "Call.h"

int __cdecl Call::cdevl(int &a1, int &a2, int &a3)
/*Вызывающая функция			Параметры помещаются в стек в обратном порядке (справа налево)*/
{
	return a1*a2*a3;
};

int __stdcall Call::cstd(int b1, int &b2, int &b3)
/*Вызываемая функция			Параметры помещаются в стек в обратном порядке (справа налево)*/
{
	return b1*b2*b3;
};

int __fastcall Call::cfst(int c1, int c2, int c3)
/*Вызываемая функция			Хранятся в регистрах, затем помещаются в стек*/
{
	return c1*c2*c3;
};
