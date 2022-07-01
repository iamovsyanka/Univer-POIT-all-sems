#include "pch.h"
#include "Varparm.h"

int  Varparm::ivarparm(int kol, int i1, ...)
{
	int *p = &i1, k = 0, proiz1 = 1;
	while (k != kol)
	{
		proiz1 *= p[k];
		k++;
	}
	return proiz1;
}

short  Varparm::svarparm(short kol, short s1, ...)
{
	short *p = &s1, k = 0, proiz2 = 1;
	while (k != 2*kol)
	{
		proiz2 *= p[k];
		k+=2;
	}
	return proiz2;
}

double  Varparm::fvarparm(float f, ...)
{
	double *p = (double*)(&f+1);
	double sum1 = f;
	int k = 0;
	while (p[k] != (double)FLT_MAX)
	{
		sum1 += p[k];
		k++;
	}
	return sum1;
}

double  Varparm::dvarparm(double d, ...)
{
	double *p = &d, sum2 = 0;
	int k = 0;
	while (p[k] != DBL_MAX)
	{
		sum2 += p[k];
		k++;
	}
	return sum2;
}

