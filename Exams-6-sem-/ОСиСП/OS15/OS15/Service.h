#pragma once
#include <Windows.h>
#include <iostream>
#include <fstream>

#define SERVICENAME L"OS15"
#define TRACEPATH "D:\\ServciceLog.txt"

VOID WINAPI ServiceMain(DWORD dwArgc, LPTSTR* lpszArgv);
VOID WINAPI ServiceHandler(DWORD fdwControl);

void trace(const char* msg, int r = std::ofstream::app);

void trace(const wchar_t* msg, int r = std::wofstream::app);