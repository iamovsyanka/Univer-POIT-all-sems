#include <Windows.h>
#include <iostream>

using namespace std;

int main()
{
    LPCWSTR an = L"C:\\Windows\\explorer.exe"; // путь к exe проводника
    STARTUPINFO si;
    PROCESS_INFORMATION pi;

    // заполняем значения структуры STARTUPINFO по умолчанию
    ZeroMemory(&si, sizeof(STARTUPINFO));
    si.cb = sizeof(STARTUPINFO);

    // запускаем процесс Notepad
    if (!CreateProcess(
        an, // имя исполняемого модуля 
        NULL, // командная строка
        NULL, // защита процесса
        NULL, // защита потока
        FALSE, // признак наследования дескриптора
        CREATE_NEW_CONSOLE, // флаги создания процесса 
        NULL,  // блок новой среды окружения
        NULL, // текущий каталог
        &si, // вид главного окна
        &pi // информация о процессе
    )
        )
    {
        cout << "CreateProcess failed " << GetLastError() << endl;
        return 0;
    }
    /*Вызов WaitForSingleObject используется для ожидания события. 
    Ожидание может касаться множества возможных событий. Если в параметре указан процесс, 
    то вызывающая программа дожидается окончания конкретного процесса.*/
    WaitForSingleObject(pi.hProcess, INFINITE);

    // закроем дескрипторы запущенного процесса в текущем процессе
    CloseHandle(pi.hThread);
    CloseHandle(pi.hProcess);

    return 0;
}
