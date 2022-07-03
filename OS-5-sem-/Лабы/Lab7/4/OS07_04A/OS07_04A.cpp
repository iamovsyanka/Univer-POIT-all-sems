﻿#include <Windows.h>
#include <iostream>
#include <ctime>

using namespace std;

int main() {
    int start = clock();

    DWORD pid = GetCurrentProcessId();
    HANDLE hs = OpenSemaphore(SEMAPHORE_ALL_ACCESS, FALSE, L"Semaphore");

    hs == NULL ? cout << "OS07_04A: Open Error Semaphore\n" : cout << "OS07_04A: Open Semaphore\n";

    for (int i = 0; i < 90; i++) {
        if (i == 29) {
            WaitForSingleObject(hs, INFINITE);
        }
        if (i == 59) {
            ReleaseMutex(hs);
        }

        cout << i << " OS07_04A pid = " << pid << ", time: " << clock() - start << endl;
        Sleep(100);
    }

    CloseHandle(hs);

    system("pause");
    return 0;
}