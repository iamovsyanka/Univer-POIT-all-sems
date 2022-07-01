//Задание 1

#include "pch.h"
#include <iostream>
#include <tuple>

struct Date {
	unsigned char day;
	unsigned char month;
	unsigned char year;
};

bool operator < (const Date &a, const Date &b) {
	return std::tie(a.year, a.month, a.day) < std::tie(b.year, b.month, b.day);
}

bool operator > (const Date &a, const Date &b) {
	return std::tie(a.year, a.month, a.day) > std::tie(b.year, b.month, b.day);
}

bool operator == (const Date &a, const Date &b) {
	return std::tie(a.year, a.month, a.day) == std::tie(b.year, b.month, b.day);
}

int main()
{
	setlocale(LC_ALL, "Rus");
	using namespace std;

	Date date1 = {7,1,1980};
	Date date2 = {7,2,1993};
	Date date3 = {7,1,1980};

	if (date1 < date2)
		cout << "истина" << endl;
	else
		cout << "ложь" << endl;

	if (date1 > date2)
		cout << "истина" << endl;
	else
		cout << "ложь" << endl;

	if (date1 == date2)
		cout << "истина" << endl;
	else
		cout << "ложь" << endl;

	if (date1 == date3)
		cout << "истина" << endl;
	else
		cout << "ложь" << endl;

	return 0;
}
