#include "StdAfx.h"
#include "DialogoSelecionaPlanos.h"
#include "FuncoesComuns.h"

using namespace System;
using namespace System::Windows::Forms;
using namespace ExemploInterfaceIntegracao;

tsSelecionaPlanos* DialogoSelecionaPlanos::getParametros()
{
  String^ sData;
  String^ sNumeroParcelas;
  String^ sValorEntrada;
  String^ sValorParcela;
  String^ sValorTransacao;

  tsSelecionaPlanos* stSelecionaPlanos = new tsSelecionaPlanos;

  FuncoesComuns::ExtraiNumeros(boxData->Text, sData, false);
  FuncoesComuns::ExtraiNumeros(boxNumeroParcelas->Text, sNumeroParcelas, false);
  FuncoesComuns::ExtraiNumeros(boxValorEntrada->Text, sValorEntrada, false);
  FuncoesComuns::ExtraiNumeros(boxValorParcela->Text, sValorParcela, false);
  FuncoesComuns::ExtraiNumeros(boxValorTransacao->Text, sValorTransacao, false);

  stSelecionaPlanos->sData = FuncoesComuns::SystemStrToCharPtr(sData);
  stSelecionaPlanos->sNumeroParcelas = FuncoesComuns::SystemStrToCharPtr(sNumeroParcelas->PadLeft(2, '0'));
  stSelecionaPlanos->sValorEntrada = FuncoesComuns::SystemStrToCharPtr(sValorEntrada->PadLeft(12, '0'));
  stSelecionaPlanos->sValorParcela = FuncoesComuns::SystemStrToCharPtr(sValorParcela->PadLeft(12, '0'));;
  stSelecionaPlanos->sValorTransacao = FuncoesComuns::SystemStrToCharPtr(sValorTransacao->PadLeft(12, '0'));;

  return stSelecionaPlanos;
}