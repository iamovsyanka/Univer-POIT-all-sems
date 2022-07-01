#include "pch.h"
#include "..//LP_Lab08L/Dictionary.h"
#include <iostream>
#include <Windows.h>

using namespace Dictionary;

int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	std::cout << "\t\t---------Словари---------\n";

	#ifdef TEST_DICTIONARY
		{
			try
			{
				Instance d1 = Create("Преподаватели", 5);
				AddEntry(d1, new Entry("Наркевич", 1));
				AddEntry(d1, new Entry("Жиляк", 2));
				AddEntry(d1, new Entry("Ловенецкая", 3));
				AddEntry(d1, new Entry("БЕЛОДЕД", 4));
				Instance d2 = Create("Студенты", 5);
				AddEntry(d2, new Entry("Козловский", 1));
				AddEntry(d2, new Entry("Капустин", 2));
				AddEntry(d2, new Entry("Петров", 3));
				AddEntry(d2, new Entry("Лев", 4));
				DelEntry(d1, 3);
				DelEntry(d2, 4);
				Entry e1 = GetEntry(d1, 4);
				Entry e2 = GetEntry(d2, 1);
				UpdEntry(d1, 1, Entry("Воронов", 0));
				UpdEntry(d2, 3, Entry("Петушок", 0));
				Print(d1);
				Print(d2);
				Delete(d1);
				Delete(d2);
			}
			catch (const char* e)
			{
				std::cout << e << '\n';
			}
		}
	#endif

	system("pause");
	return 0;
}



