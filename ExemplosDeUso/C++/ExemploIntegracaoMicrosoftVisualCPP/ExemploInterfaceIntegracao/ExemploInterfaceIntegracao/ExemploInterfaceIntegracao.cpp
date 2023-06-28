// ExemploInterfaceIntegracao.cpp : main project file.

#include "stdafx.h"
#include "ClasseIntegracao.h"
#include "InterfaceExemplo.h"
#include "DialogoSelecionaPlanos.h"
#include "Logger.h"


using namespace ExemploInterfaceIntegracao;

[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
  // Enabling Windows XP visual effects before any controls are created
  Application::EnableVisualStyles();
  Application::SetCompatibleTextRenderingDefault(true);

  InterfaceExemplo ^frmTemp = nullptr;
  delete frmTemp;

  frmTemp=  gcnew InterfaceExemplo();
  Logger^ log = frmTemp->getLog();

  
  
	// Create the main window and run it
	Application::Run(frmTemp);
	return 0;
}

