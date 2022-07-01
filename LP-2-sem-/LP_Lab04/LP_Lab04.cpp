#include "pch.h"
#include <iostream>

int fun()
{
	return 7;
}

int main()
{
	bool a = true, b = false;
	char c = 'A';
	wchar_t wc = L'Й';
	short X1 = 16, X2 = -16;
	// X1 = 10, X2 = ‭FFFFFFFFFFFFFFF0‬;
	short max = 0x7FFF, min = 0xFFFFFFFFFFFF8001;
	unsigned short max1 = 0xFFFF, min1=0x0000;
	int Y1 = 17, Y2 = -17;
	// Y1 = 11, Y2 = FFFFFFFFFFFFFFEF;
	int Max = 0x7FFFFFFF, Min = 0xFFFFFFFF80000001;
	unsigned Max1 = 0xFFFFFFFF, Min1 = 0x0000;
	long Z1 = 18, Z2 = -18;
	// Z1 = 0x12, Z2 = 0xFFFFFFFFFFFFFFEE;
	long MAx = 0x7FFFFFFF, MIn = 0xFFFFFFFF80000001;
	unsigned long MAx1 = 0xFFFFFFFF, MIn1 = 0x0000;
	float S1 = 8.000, S2 = -8.000, q1=-1.15, q2=-0.14,q3=-9.75115;
	// S1 = 8, S2 = FFFFFFFFFFFFFFF8;

	double z = 0;
	printf("%.2f", 1 / z);
	std::cout << std::endl << std::endl;
	printf("%.2f", -1 / z);
	std::cout << std::endl << std::endl;
	printf("%.2f", -z / z);

	char *pc = &c;
	pc = pc + 3;
	wchar_t *pwc = &wc;
	short *pX1 = &X1;
	int *pY1 = &Y1;
	float *pS1 = &S1;
	double *pz = &z;
	int (*pfun)() = fun;

	char &sc = c;
	wchar_t &swc = wc;
	short &sX1 = X1;
	int &sY1 = Y1;
	float &sS1 = S1;
	double &sz = z;

	std::cout << sizeof(&sX1);

	system("pause");
	return 0;
}