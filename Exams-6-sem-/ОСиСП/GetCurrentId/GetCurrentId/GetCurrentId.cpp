#include <Windows.h>
#include <iostream>

int main()
{
    std::cout << "PID = " << GetCurrentProcessId() << ", TID = " << GetCurrentThreadId() << "\n";

    return 0;
}

