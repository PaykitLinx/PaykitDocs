#include "StdAfx.h"
#include "ConsultaAVS.h"
#include <iostream>
#include <windows.h>
#include "FuncoesComuns.h"

using namespace ExemploInterfaceIntegracao;
using namespace System;
using namespace std;

tsConsultaAVS* ConsultaAVS::getParametros()
{
  tsConsultaAVS* stConsultaAVS = new tsConsultaAVS;

  stConsultaAVS->endereco = FuncoesComuns::SystemStrToCharPtr(boxEndereco->Text);
  stConsultaAVS->numero = FuncoesComuns::SystemStrToCharPtr(boxNumero->Text);
  stConsultaAVS->apartamento = FuncoesComuns::SystemStrToCharPtr(boxApartamento->Text);
  stConsultaAVS->bloco = FuncoesComuns::SystemStrToCharPtr(boxBloco->Text);
  stConsultaAVS->bairro = FuncoesComuns::SystemStrToCharPtr(boxBairro->Text);
  stConsultaAVS->CEP = FuncoesComuns::SystemStrToCharPtr(boxCEP->Text);
  stConsultaAVS->CPF = FuncoesComuns::SystemStrToCharPtr(boxCPF->Text);
  
  return stConsultaAVS;
}