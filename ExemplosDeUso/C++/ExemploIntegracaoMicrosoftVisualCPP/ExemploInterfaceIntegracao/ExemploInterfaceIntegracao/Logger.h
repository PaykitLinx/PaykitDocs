#pragma once

using namespace System;
using namespace System::IO;

ref class Logger
{
public:
	StreamWriter^ oArquivo;
	DateTime^ dt;
	String^ sNomeArquivo;

	Logger(void);
	Logger::~Logger(void);

	void GravarLog(String^ sMensagem);
  void GravarLog(char* sMetodo, int iParametros);
	void GravarLog(char* sMetodo, char* sParametros);
	void GravarLog(char* sMetodo, char* sParametros, char * sRetorno);
	void GravarLog(char* sMetodo, char* sParametros, char* sParametro2, char* sRetorno);
	void Logger::GravarLog(char* sMetodo, char* sParametro1, char* sParametro2, char* sParametro3, char* sRetorno);

};

