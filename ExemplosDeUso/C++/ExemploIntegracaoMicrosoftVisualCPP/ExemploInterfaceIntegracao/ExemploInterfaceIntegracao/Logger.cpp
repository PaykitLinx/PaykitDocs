#pragma once

#include "StdAfx.h"
#include <msclr\marshal.h>
#include "Logger.h"


using namespace System;
using namespace System::Runtime::InteropServices;
using namespace msclr::interop;

Logger::Logger(void)
{
	dt = gcnew DateTime();
	dt = DateTime::Now;
	sNomeArquivo = "IntegracaoDebug_" + dt->ToString("yyyyMMdd") + ".txt";
}

Logger::~Logger(void)
{
}

void Logger::GravarLog(String^ sMensagem)
{
  String^ sID = "" + GetCurrentProcessId();
  oArquivo = File::AppendText(sNomeArquivo);
  oArquivo->WriteLine(DateTime::Now + "   ProcID: " + sID->PadLeft(6) + "   " + sMensagem);
	oArquivo->Flush();
  oArquivo->Close();
}

void Logger::GravarLog(char* sMetodo, int iParametros)
{
  String^ sMensagem = marshal_as<String^>(sMetodo)->PadRight(70, ' ') + ": " + iParametros;

  GravarLog(sMensagem);
}

void Logger::GravarLog(char* sMetodo, char* sParametros)
{
	String^ sMensagem =marshal_as<String^>(sMetodo)->PadRight(70, ' ') + ": ";
	sMensagem += marshal_as<String^>(sParametros);

	GravarLog(sMensagem);
}

void Logger::GravarLog(char* sMetodo, char* sParametros, char* sRetorno)
{
	String^ sMensagem = marshal_as<String^>(sMetodo)->PadRight(70, ' ') + ": ";
	sMensagem += marshal_as<String^>(sParametros) + " |";
	sMensagem += "Ret =" + marshal_as<String^>(sRetorno);

	GravarLog(sMensagem);
}

void Logger::GravarLog(char* sMetodo, char* sParametro1, char* sParametro2, char* sRetorno)
{
	String^ sMensagem = marshal_as<String^>(sMetodo)->PadRight(70, ' ') + ": ";
	sMensagem += marshal_as<String^>(sParametro1) + ", ";
	sMensagem += marshal_as<String^>(sParametro2) + " |";
	sMensagem += "Ret =" + marshal_as<String^>(sRetorno);

	GravarLog(sMensagem);
}

void Logger::GravarLog(char* sMetodo, char* sParametro1, char* sParametro2, char* sParametro3, char* sRetorno)
{
	String^ sMensagem = marshal_as<String^>(sMetodo)->PadRight(70, ' ') + ": ";
	sMensagem += marshal_as<String^>(sParametro1) + ", ";
	sMensagem += marshal_as<String^>(sParametro2) + ", ";
	sMensagem += marshal_as<String^>(sParametro3) + " |";
	sMensagem += "Ret =" + marshal_as<String^>(sRetorno);

	GravarLog(sMensagem);
}
