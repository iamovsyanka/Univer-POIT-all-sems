#include "pch.h"
#include "Dictionary.h"
#include <iostream>
#include <Windows.h>
using namespace Dictionary;
int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleCP(1251);
	std::cout << "\t\t\t---------Словари---------\n\n";

	#ifdef TEST_CREATE_01
		{
			try
			{
				Instance d = Create("1234567891012131415161718", 5);
			}
			catch (const char* e)
			{
				std::cout << e << '\n';
			}
		}
	#endif 

	#ifdef TEST_CREATE_02
		{
			try
			{
				Instance d = Create("123456789", 150);
			}
			catch (const char* e)
			{
				std::cout << e << '\n';
			}
		}
	#endif 

	#ifdef TEST_ADDENTRY_03
		{
			try
			{
				Instance d = Create("Экзамены", 1);
				AddEntry(d, new Entry("ОАиП", 1));
				AddEntry(d, new Entry("ЯП", 2));
			}
			catch (const char* e)
			{
				std::cout << e << '\n';
			}
		}
	#endif

	#ifdef TEST_ADDENTRY_04
		{
			try
			{
				Instance d = Create("Экзамены", 3);
				AddEntry(d, new Entry("ОАиП", 1));
				AddEntry(d, new Entry("ЯП", 1));
			}
			catch (const char* e)
			{
				std::cout << e << '\n';
			}
		}
	#endif

	#ifdef	TEST_GETENTRY_05
		{
			try
			{
				Instance d = Create("Экзамены", 3);
				AddEntry(d, new Entry("ОАиП", 1));
				AddEntry(d, new Entry("ЯП", 2));
				Entry entry = GetEntry(d, 3);
			}
			catch (const char* e)
			{
				std::cout << e << '\n';
			}
		}
	#endif

	#ifdef	TEST_DELENTRY_06
		{
			try
			{
				Instance d = Create("Экзамены", 3);
				AddEntry(d, new Entry("ОАиП", 1));
				AddEntry(d, new Entry("ЯП", 2));
				DelEntry(d, 3);
			}
			catch (const char* e)
			{
				std::cout << e << '\n';
			}
		}
	#endif

	#ifdef	TEST_UPDENTRY_07
		{
			try
			{
				Instance d = Create("Экзамены", 4);
				AddEntry(d, new Entry("ОАиП", 1));
				AddEntry(d, new Entry("ЯП", 2));
				UpdEntry(d, 3, Entry("КЯР", 0));
			}
			catch (const char* e)
			{
				std::cout << e << '\n';
			}
		}
	#endif

	#ifdef	TEST_UPDENTRY_08
		{
			try
			{
				Instance d = Create("Экзамены", 4);
				AddEntry(d, new Entry("ОАиП", 1));
				AddEntry(d, new Entry("ЯП", 2));
				UpdEntry(d, 1, Entry("КЯР", 1));
			}
			catch (const char* e)
			{
				std::cout << e << '\n';
			}
		}
	#endif

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



