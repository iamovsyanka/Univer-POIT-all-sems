#include <Windows.h>
#include <iostream>

volatile UINT count;

void thread()
{
	for (;;)
	{
		count++;
		Sleep(100);
	}
}

int main()
{
	char c;
	HANDLE hThread;
	DWORD IDThread;
	hThread = CreateThread(NULL, 0, (LPTHREAD_START_ROUTINE)thread, NULL, 0, &IDThread);
	if (hThread == NULL) 
	{
		return GetLastError();
	}

	for (;;)
	{
		std::cout << "Input 'y' to display the count or any char to exit: ";
		std::cin >> c;
		if (c == 'y')
		{
			std::cout << "count = " << count << std::endl;
		}
		else 
		{
			ExitProcess(1);
		}
	}
}