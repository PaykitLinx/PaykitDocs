#include "stdafx.h"
#include "FuncoesComuns.h"
#include <msclr\marshal.h>

using namespace System;
using namespace msclr::interop;

FuncoesComuns::FuncoesComuns()
{
}

void FuncoesComuns::ConverteBoxParaValor(System::Windows::Forms::TextBox^ tb, int iCasasDecimais, String^ sConcat)
{

  String^ str = "";

  if (sConcat->Length == 0)
  {
    str = L"0,";
    for (int i = 0; i < iCasasDecimais; i++)
    {
      str += L"0";
    }

  }
  else if (sConcat->Length > 0 && sConcat->Length < 3)
  {
    str = L"0,";
    for (int i = 0; i < iCasasDecimais - sConcat->Length; i++)
    {
      str += L"0";
    }
    str += sConcat;
  }
  else if (sConcat->Length > 2)
  {
    if (sConcat->Length <= iCasasDecimais)
      str += L"0";

    for (int i = 0; i < sConcat->Length; i++)
    {
      if (i == sConcat->Length - iCasasDecimais)
        str += L",";
      str += sConcat[i];
      if (i == sConcat->Length - (4 + iCasasDecimais) || i == sConcat->Length - (7 + iCasasDecimais))
        str += L".";
    }
  }
  tb->Text = str;

}

void FuncoesComuns::ExtraiNumeros(String^ sTexto, String^ &sRet, bool bRemoverZerosEsquerda)
{

  if (bRemoverZerosEsquerda)
    sTexto = sTexto->TrimStart('0');

  if (sTexto->Length > 0)
  {
    for (int i = 0; i < sTexto->Length; i++)
    {
      if (Char::IsDigit(sTexto[i]))
        sRet += sTexto[i];
    }
  }
  else
    sRet = "";
}

void FuncoesComuns::ExtraiNumeros(String^ sTexto, String^ &sRet)
{
  ExtraiNumeros(sTexto, sRet, true);
}

void FuncoesComuns::InputHandlerValor(System::Windows::Forms::KeyPressEventArgs^  e, System::Windows::Forms::TextBox^ tb, int iCasasDecimais)
{
  e->Handled = true;

  String^ concat;
  ExtraiNumeros(tb->Text, concat);

  if (e->KeyChar == (char)System::Windows::Forms::Keys::Back)
    concat = concat->Substring(0, concat->Length - 1);
  else if (Char::IsDigit(e->KeyChar))
    concat += e->KeyChar + L"";
  else
    return;
  ConverteBoxParaValor(tb, iCasasDecimais, concat);
}

void FuncoesComuns::InputHandlerValor(System::Windows::Forms::KeyPressEventArgs^  e, System::Windows::Forms::TextBox^ tb)
{
  InputHandlerValor(e, tb, 2);
}

void FuncoesComuns::InputHandlerData(System::Windows::Forms::KeyPressEventArgs^  e, System::Windows::Forms::TextBox^ tb)
{
  e->Handled = true;
  String^ concat;

  //se o botão não é backspace... 
  //se o char não é digito ou tamanho maximo foi atigindo retorna.
  if (e->KeyChar != 0x08)
  {
    if (!Char::IsDigit(e->KeyChar) || (tb->MaxLength < tb->Text->Length + 1))
      return;
  }

  ExtraiNumeros(tb->Text, concat, false);

  if (e->KeyChar == (char)System::Windows::Forms::Keys::Back)
  {
    if (tb->Text->Length > 0)
      concat = concat->Substring(0, concat->Length - 1);
    else
      return;
  }
  else
    concat += e->KeyChar + L"";

  if (concat->Length < 2)
    tb->Text = concat;
  else
  {
    String^ str = L"";
    for (int i = 0; i < concat->Length; i++)
    {
      if (i == 2 || i == 4)
        str += "/";
      str += concat[i];
    }
    tb->Text = str;
  }
}

char* FuncoesComuns::SystemStrToCharPtr(String^ strEntrada)
{
  IntPtr ptrToNativeString = System::Runtime::InteropServices::Marshal::StringToHGlobalAnsi(strEntrada);
  return static_cast<char*>(ptrToNativeString.ToPointer());
}