#include <windows.h>
#include <iostream>

int count;

void main()
{
	 for (; ; )
	 {
		 count++;
		 Sleep(1000);
		 std::cout << "count = " << count << std::endl;
	 }
}