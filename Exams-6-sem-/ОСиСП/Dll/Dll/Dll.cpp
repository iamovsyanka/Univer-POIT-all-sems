#include <Windows.h>
#include <iostream>

int main()
{
	try 
	{
		setlocale(LC_ALL, "Russian");

		HMODULE hmdll = LoadLibrary(L"D:\\Exams-6-sem-\\ОСиСП\\Dll\\Debug\\DllMain.dll");
		if (!hmdll) throw "LoadLibrary failed";
		std::cout << "LoadLibrary succesfull\n";

		int(*Sum)(int, int) = (int(*)(int, int)) GetProcAddress(hmdll, "Sum");
		int(*Sub)(int, int) = (int(*)(int, int)) GetProcAddress(hmdll, "Sub");

		if(!Sum || !Sub) throw "GetProcAddress failed";
		std::cout << "GetProcAddress succesfull\n";

		std::cout << "Sum(2, 4) = " << Sum(2, 4) << std::endl;
		std::cout << "Sub(6, 4) = " << Sub(6, 4) << std::endl;

		if (!FreeLibrary(hmdll)) throw "FreeLibrary failed";
		std::cout << "FreeLibrary succesfull\n";
	}
	catch (const char* em) 
	{
		std::cout << "--Error: " << em << "\n";
	}
}
