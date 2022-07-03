#include <Windows.h>
#include <iostream>
#include <tlhelp32.h>

using namespace std;

DWORD GetProcessByExeName(const wchar_t* ExeName)
{
    DWORD Pid;

    PROCESSENTRY32 pe32;
    pe32.dwSize = sizeof(PROCESSENTRY32);

    HANDLE hProcessSnap = CreateToolhelp32Snapshot(TH32CS_SNAPALL, NULL);
    if (hProcessSnap == INVALID_HANDLE_VALUE)
    {
        cout << "Error = " << GetLastError() << endl;
        return false;
    }

    if (Process32First(hProcessSnap, &pe32))
    {
        do
        {
            if (wcscmp(pe32.szExeFile, ExeName) == 0)
            {
                CloseHandle(hProcessSnap);
                return pe32.th32ProcessID;
            }
        } while (Process32Next(hProcessSnap, &pe32));
    }

    CloseHandle(hProcessSnap);
    return 0;
}

void killProcessByName(const wchar_t* filename)
{
    DWORD PID = GetProcessByExeName(filename);
    if (!PID)  cout << "Процесс не найден" << endl;
    else
    {
        HANDLE hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, PID);
        if (TerminateProcess(hProcess, 0))  cout << "Процесс убит" << endl;
        else cout << "Не могу убить процесс" << endl;
    }
}

int main(int argc, char* argv[])
{
     setlocale(LC_ALL, "Russian");
     killProcessByName(L"OS13_Start.exe");
     killProcessByName(L"OS13_Insert.exe");
     killProcessByName(L"OS13_Update.exe");
     killProcessByName(L"OS13_Delete.exe");

     system("pause");
     return 0;
}