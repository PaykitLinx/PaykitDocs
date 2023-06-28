#pragma once
#include "stdafx.h"

class FuncoesComuns
{
public:
  FuncoesComuns();

  static void ConverteBoxParaValor(System::Windows::Forms::TextBox^ tb, int iCasasDecimais, System::String^ concat);
  static void ExtraiNumeros(System::String^ sTexto, System::String^ &sRet, bool bRemoverZerosEsquera);
  static void ExtraiNumeros(System::String^ sTexto, System::String^ &sRet);
  static void InputHandlerValor(System::Windows::Forms::KeyPressEventArgs^  e, System::Windows::Forms::TextBox^ tb, int iCasasDecimais);
  static void InputHandlerValor(System::Windows::Forms::KeyPressEventArgs^  e, System::Windows::Forms::TextBox^ tb);
  static void InputHandlerData(System::Windows::Forms::KeyPressEventArgs^  e, System::Windows::Forms::TextBox^ tb);
  static char* SystemStrToCharPtr(System::String^ strEntrada);

};

