#include "pch.h"
#include "Varparm.h"
#include "Call.h"

/*EAX/AX/AH/AL (�����������) � ����������� ��� �������� ������������� ������, 
������������� ����������� ��� ��������� ���������, ������� ��� �������� ������� ��������;
EBX/BX/BH/BL (����) � ������� ����, ����������� ��� �������� �������� ������ ���������� ������� � ������ 
(��������, �������);
ECX/CX/CH/CL (�������-�������) � ������������� ����������� � �������� �������� �����, 
��� ������������� �������� ������ � ������ � ��������� ������ ��������������� �������;
EDX/DX/DH/DL � ������� ������, ����������� � ��������� ��������� � �������, 
������������ ��� ���������� ��������-������������ ��� ������ � 32- ���������� �������;
ESI/SI � ������ ���������;
EDI/DI � ������ �������� (����������);
ESP/SP � ������� ��������� �����;
EBP/BP � ������� ��������� ����.*/

int main()
{
	setlocale(LC_ALL, "rus");

	std::cout << "------������������ ������ ������� � ����� ������ �����������: 1------" << std::endl;
	std::cout << "ivarparm " << Varparm::ivarparm(1, 2) << std::endl;
	std::cout << "svarparm " << Varparm::svarparm(1, 3) << std::endl;
	std::cout << "fvarparm " << Varparm::fvarparm(2.5, (double)FLT_MAX) << std::endl;
	std::cout << "fvarparm " << Varparm::dvarparm(2.5, DBL_MAX) << std::endl;
	std::cout << std::endl << std::endl;

	std::cout << "------������������ ������ ������� � ����� ������ �����������: 2------" << std::endl;
	std::cout << "ivarparm " << Varparm::ivarparm(2, 2, 3) << std::endl;
	std::cout << "svarparm " << Varparm::svarparm(2, 2, 2) << std::endl;
	std::cout << "fvarparm " << Varparm::fvarparm(2.5, 3., (double)FLT_MAX) << std::endl;
	std::cout << "fvarparm " << Varparm::dvarparm(2.5, 4., DBL_MAX) << std::endl;
	std::cout << std::endl << std::endl;

	std::cout << "------������������ ������ ������� � ����� ������ �����������: 3------" << std::endl;
	std::cout << "ivarparm " << Varparm::ivarparm(3, 2, 3, 4) << std::endl;
	std::cout << "svarparm " << Varparm::svarparm(3, 2, 2, 3) << std::endl;
	std::cout << "fvarparm " << Varparm::fvarparm(2.5, 3., 4., (double)FLT_MAX) << std::endl;
	std::cout << "fvarparm " << Varparm::dvarparm(2.5, 4., 5., DBL_MAX) << std::endl;
	std::cout << std::endl << std::endl;

	std::cout << "------������������ ������ ������� � ����� ������ �����������: 7------" << std::endl;
	std::cout << "ivarparm " << Varparm::ivarparm(7, 2, 3, 4, 5, 6, 7, 8) << std::endl;
	std::cout << "svarparm " << Varparm::svarparm(7, 2, 2, 3, 3, 3, 4, 3) << std::endl;
	std::cout << "fvarparm " << Varparm::fvarparm(2.5, 3., 4., 5., 6., 7., (double)FLT_MAX) << std::endl;
	std::cout << "fvarparm " << Varparm::dvarparm(2.5, 4., 5., 6., 7., 8., DBL_MAX) << std::endl;
	std::cout << std::endl << std::endl;
	std::cout << std::endl << std::endl;

	std::cout << "------������������ ������ ������� �� ������ �������------" << std::endl;
	int ac1 = 1, ac2 = 2, ac3 = 3;
	std::cout << Call::cdevl(ac1, ac2, ac3) << std::endl;
	int bc2 = 2, bc3 = 3;
	std::cout << Call::cstd(1, bc2, bc3) << std::endl;
	std::cout << Call::cfst(1, 2, 3) << std::endl;

	return 0;
}