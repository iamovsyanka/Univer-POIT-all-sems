#include "pch.h"
#include "Varparm.h"
#include "Call.h"

/*EAX/AX/AH/AL (аккумул€тор) Ц примен€етс€ дл€ хранени€ промежуточных данных, 
автоматически примен€етс€ при операци€х умножени€, делени€ дл€ хранени€ первого операнда;
EBX/BX/BH/BL (база) Ц регистр базы, примен€етс€ дл€ хранени€ базового адреса некоторого объекта в пам€ти 
(например, массива);
ECX/CX/CH/CL (регистр-счетчик) Ц автоматически примен€етс€ в качестве счетчика цикла, 
его использование зачастую не€вно и скрыто в алгоритме работы соответствующей команды;
EDX/DX/DH/DL Ц регистр данных, примен€етс€ в операци€х умножени€ и делени€, 
используетс€ как расширение регистра-аккумул€тора при работе с 32- разр€дными числами;
ESI/SI Ц индекс источника;
EDI/DI Ц индекс приЄмника (получател€);
ESP/SP Ц регистр указател€ стека;
EBP/BP Ц регистр указател€ базы.*/

int main()
{
	setlocale(LC_ALL, "rus");

	std::cout << "------ƒемонстраци€ работы функций с общим числом параментров: 1------" << std::endl;
	std::cout << "ivarparm " << Varparm::ivarparm(1, 2) << std::endl;
	std::cout << "svarparm " << Varparm::svarparm(1, 3) << std::endl;
	std::cout << "fvarparm " << Varparm::fvarparm(2.5, (double)FLT_MAX) << std::endl;
	std::cout << "fvarparm " << Varparm::dvarparm(2.5, DBL_MAX) << std::endl;
	std::cout << std::endl << std::endl;

	std::cout << "------ƒемонстраци€ работы функций с общим числом параментров: 2------" << std::endl;
	std::cout << "ivarparm " << Varparm::ivarparm(2, 2, 3) << std::endl;
	std::cout << "svarparm " << Varparm::svarparm(2, 2, 2) << std::endl;
	std::cout << "fvarparm " << Varparm::fvarparm(2.5, 3., (double)FLT_MAX) << std::endl;
	std::cout << "fvarparm " << Varparm::dvarparm(2.5, 4., DBL_MAX) << std::endl;
	std::cout << std::endl << std::endl;

	std::cout << "------ƒемонстраци€ работы функций с общим числом параментров: 3------" << std::endl;
	std::cout << "ivarparm " << Varparm::ivarparm(3, 2, 3, 4) << std::endl;
	std::cout << "svarparm " << Varparm::svarparm(3, 2, 2, 3) << std::endl;
	std::cout << "fvarparm " << Varparm::fvarparm(2.5, 3., 4., (double)FLT_MAX) << std::endl;
	std::cout << "fvarparm " << Varparm::dvarparm(2.5, 4., 5., DBL_MAX) << std::endl;
	std::cout << std::endl << std::endl;

	std::cout << "------ƒемонстраци€ работы функций с общим числом параментров: 7------" << std::endl;
	std::cout << "ivarparm " << Varparm::ivarparm(7, 2, 3, 4, 5, 6, 7, 8) << std::endl;
	std::cout << "svarparm " << Varparm::svarparm(7, 2, 2, 3, 3, 3, 4, 3) << std::endl;
	std::cout << "fvarparm " << Varparm::fvarparm(2.5, 3., 4., 5., 6., 7., (double)FLT_MAX) << std::endl;
	std::cout << "fvarparm " << Varparm::dvarparm(2.5, 4., 5., 6., 7., 8., DBL_MAX) << std::endl;
	std::cout << std::endl << std::endl;
	std::cout << std::endl << std::endl;

	std::cout << "------ƒемонстраци€ работы функций из второй таблицы------" << std::endl;
	int ac1 = 1, ac2 = 2, ac3 = 3;
	std::cout << Call::cdevl(ac1, ac2, ac3) << std::endl;
	int bc2 = 2, bc3 = 3;
	std::cout << Call::cstd(1, bc2, bc3) << std::endl;
	std::cout << Call::cfst(1, 2, 3) << std::endl;

	return 0;
}