#include "stdafx.h"
#include <iostream>
#include <iomanip> 
#include "Salesman.h"
#define N 5

int main()
{
	setlocale(LC_ALL, "rus");
	int d[N][N] = {       
					{ INF,  16, 29,  INF,   8 },    
					{ 8,   INF,  23,  60,  76 },   
					{ 10,  24,   INF,  86,   57 },    
					{ 25,  50,  32,   INF,   24 },    
					{ 85,  74,  52,  21,    INF } };     
	int r[N];                 
	int s = salesman(N, (int*)d, r);
	std::cout << std::endl << "~~~~~~~~~~ Задача коммивояжера ~~~~~~~~~~~";
	std::cout << std::endl << "-- количество  городов: " << N;
	std::cout << std::endl << "-- условие задачи коммивояжера : ";
	for (int i = 0; i < N; i++)
	{
		std::cout << std::endl;
		for (int j = 0; j < N; j++)

			if (d[i][j] != INF) std::cout << std::setw(3) << d[i][j] << " ";

			else std::cout << std::setw(3) << "INF" << " ";
	}
	std::cout << std::endl << "-- оптимальный маршрут: ";
	for (int i = 0; i < N; i++) std::cout << r[i]+1 << "-->"; std::cout << 1;
	std::cout << std::endl << "-- длина маршрута     : " << s;
	std::cout << std::endl;

	system("pause");
	return 0;
}

