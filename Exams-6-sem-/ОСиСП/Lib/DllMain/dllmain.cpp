// dllmain.cpp : Определяет точку входа для приложения DLL.
#include "pch.h"
#include <iostream>

using namespace std;

BOOL APIENTRY DllMain(HMODULE hModule,
    DWORD  ul_reason_for_call,
    LPVOID lpReserved
)
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH: cout << "-- DLL загружена в адресное пространство процесса\n"; break;
    case DLL_THREAD_ATTACH: cout << "-- в процессе создан новый поток и функция DllMain вызывается в контексте этого потока\n"; break;
    case DLL_THREAD_DETACH: cout << "-- в процессе завершается поток и функция DllMain вызывается в контексте этого потока\n"; break;
    case DLL_PROCESS_DETACH: cout << "-- DLL выгружается из адресного пространства процесса\n"; break;
        break;
    }
    return TRUE;
}

/*Для того чтобы сделать функцию или переменную экспортируемой, нужно определить их
с модификатором extern "C" и квалификатором __declspec(dllexport).*/
/*Модификатор extern "C" указывает компилятору на то, что функция или переменная должна
иметь имя в стиле языка программирования С. То есть имя функции или переменной не будет
искажаться путем добавления к нему обозначений типов данных из сигнатуры
функции или определения переменной. Модификатор __declspec(dllexport) указывает компилятору на то,
что данная функция или переменная будет экспортироваться из DLL.
*/
__declspec(dllexport) int Sum(int a, int b)
{
    return a + b;
}

__declspec(dllexport) int Sub(int a, int b)
{
    return a - b;
}