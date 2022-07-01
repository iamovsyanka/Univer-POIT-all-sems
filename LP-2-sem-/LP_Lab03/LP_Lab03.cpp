// KostukovaAnn2001  
// КостюковаАня2001
// Костюкова2001Ann

//Windows-1251 
//4B 6F 73 74 75 6B 6F 76 61 41 6E 6E 32 30 30 31
//CA EE F1 F2 FE EA EE E2 E0 C0 ED FF 32 30 30 31
//CA EE F1 F2 FE EA EE E2 E0 32 30 30 31 41 6E 6E

//UTF-8
//4B 6F 73 74 75 6B 6F 76 61 41 6E 6E 32 30 30 31
//D0 9A D0 BE D1 81 D1 82 D1 8E D0 BA D0 BE D0 B2 D0 B0 D0 90 D0 BD D1 8F 32 30 30 31
//D0 9A D0 BE D1 81 D1 82 D1 8E D0 BA D0 BE D0 B2 D0 B0 32 30 30 31 41 6E 6E 0D 0A

//UTF-16
//4B 00 6F 00 73 00 74 00 75 00 6B 00 6F 00 76 00 61 00 41 00 6E 00 6E 00 32 00 30 00 30 00 31
//1A 04 3E 04 41 04 42 04 4E 04 3A 04 3E 04 32 04 30 04 10 04 3D 04 4F 04 32 00 30 00 30 00 31
//1A 04 3E 04 41 04 42 04 4E 04 3A 04 3E 04 32 04 30 04 32 00 30 00 30 00 31 00 41 00 6E 00 6E



#include "pch.h"
#include <cstdlib>
#include <iostream>

char lf[] = "KostukovaAnn2001";
char rf[] = "КостюковаАня2001";
char lr[] = "Костюкова2001Ann";

wchar_t Llp[] = L"KostukovaAnn2001";
wchar_t Lrp[] = L"КостюковаАня2001";
wchar_t Llr[] = L"Костюкова2001Ann";

char* UpperW1251(char* destination, char* sourse);

int main()
{
	setlocale(LC_ALL, "rus");
	char sourse[] = "12345sdfghjlйцгшщз";
	char destination[] = "124567890123456789";
	UpperW1251(destination, sourse);
	std::cout << destination << std::endl;
	system("pause");
	return 0;
}

char* UpperW1251(char* destination, char* source)
{
	int tmp;
	for (int i = 0; i < strlen(source); i++)
	{
		tmp = source[i];
		if (((tmp > 96) && (tmp < 123)) || ((tmp > -33) && (tmp < 0))) 
			tmp -= 32;
		destination[i] = (char)tmp;
	}
	return destination;
}
