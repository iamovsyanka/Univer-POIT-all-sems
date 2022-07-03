#include <Windows.h>
#include <iostream>

#pragma comment(lib, "D:\\Exams-6-sem-\\ОСиСП\\Lib\\Debug\\DllMain.lib")

int Sum(int, int);
int Sub(int, int);

int main()
{
	setlocale(LC_ALL, "Russian");

	try
	{
		std::cout << "Sum(2, 4) = " << Sum(2, 4) << std::endl;
		std::cout << "Sub(6, 4) = " << Sub(6, 4) << std::endl;

		return 0;
	}
	catch (const char* em)
	{
		std::cout << "--Error: " << em << "\n";
	}
}
