#include "pch.h"
#include "Log.h"
#include "Error.h"
#include "Parm.h"
#include <ctime>

namespace Log
{
	LOG getlog(wchar_t logfile[])
	{
		LOG a;
		wcscpy_s(a.logfile, logfile);
		a.stream = new std::ofstream(logfile, std::ofstream::out);

		if (a.stream->fail()) 
		{
			throw ERROR_THROW(112); 
		}
		return a;
	}

	void WriteLine(LOG log, const char* c, ...)
	{
		const char **p = &c;

		while (*p != "")
		{
			(*log.stream) << *p;
			p += sizeof(**p);
		}
	}

	void WriteLine(LOG log, const wchar_t* c, ...)
	{
		const wchar_t **p = &c;
		char buffer[50];

		while (*p != L"")
		{
			wcstombs(buffer, *p, sizeof(buffer));
			(*log.stream) << buffer;
			p += sizeof(**p) / 2;
		}
	}

	void WriteLog(LOG log)
	{
		char buffer[PARM_MAX_SIZE];

		time_t rawtime;
		struct tm* timeinfo;

		time(&rawtime);
		timeinfo = localtime(&rawtime);

		strftime(buffer, PARM_MAX_SIZE, "����: %d.%m.%y %H:%M:%S", timeinfo);
		(*log.stream) << "\n---- �������� ---- " << buffer << " ---- \n";
	}

	void WriteParm(LOG log, Parm::PARM parm)
	{
		char inInfo[PARM_MAX_SIZE];
		char outInfo[PARM_MAX_SIZE];
		char logInfo[PARM_MAX_SIZE];

		wcstombs(inInfo, parm.in, sizeof(inInfo));
		wcstombs(outInfo, parm.out, sizeof(outInfo));
		wcstombs(logInfo, parm.log, sizeof(logInfo));

		(*log.stream) << "---- ��������� ---- \n"
			<< " -in: " << inInfo << "\n"
			<< " -out: " << outInfo << "\n"
			<< " -log: " << logInfo << "\n";
	}

	void WriteIn(LOG log, In::IN in)
	{
		(*log.stream) << "---- �������� ������ ---- \n"
			<< "����� ��������: " << in.size << "\n"
			<< "����� �����: " << in.lines << "\n"
			<< "���������: " << in.ignor << "\n";
	}

	void WriteError(LOG log, Error::ERROR error)
	{
		if (error.id == 100)
		{
			std::cout << "������ " << error.id << ": " << error.message << "\n";
		}
		else
		{
			(*log.stream) << "������ " << error.id << ": " << error.message << "\n"
				<< "������ " << error.inext.line << ", �������: " << error.inext.col;
		}
	}

	void Close(LOG log)
	{
		(*log.stream).close();
	}
}