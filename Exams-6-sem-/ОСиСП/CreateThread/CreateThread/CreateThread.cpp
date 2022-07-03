#include <Windows.h>
#include <iostream>

DWORD WINAPI T1() {
    DWORD pid = GetCurrentProcessId();
    DWORD tid = GetCurrentThreadId();

    for (int i = 0; i < 500; ++i) {
        Sleep(300);
        std::cout << i << ". T1 PID = " << pid << ", TID = " << tid << std::endl;
    }

    return 0;
}

int main() {
    DWORD pid = GetCurrentProcessId();
    DWORD tid = GetCurrentThreadId();

    DWORD childId_T1;

    HANDLE hChild1 = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)T1, NULL, 0, &childId_T1);

    for (int i = 0; i < 10000; ++i) {
        Sleep(300);
        std::cout << i << ". Parent Thread PID = " << pid << ", TID = " << tid << ", Child thread id =  " << childId_T1 << std::endl;
    }

    WaitForSingleObject(hChild1, INFINITE);

    CloseHandle(hChild1);

    return 0;
}

