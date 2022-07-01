#include "pch.h"

int sum(int x, int y);
int sub(int x, int y);
int mul(int x, int y);

int main()
{
    std::cout << "sum(2, 3) = " << sum(2, 3) << std::endl;
	std::cout << "sub(2, 3) = " << sub(2, 3) << std::endl;
	std::cout << "mul(2, 3) = " << mul(2, 3) << std::endl;
	system("pause");
	return 0;
}

