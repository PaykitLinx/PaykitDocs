#include "StdAfx.h"
#include "DialogoTransacao.h"
#include "Define.h"

using namespace ExemploInterfaceIntegracao;
using namespace System;
using namespace msclr::interop;

#pragma region Constructor Overloads

DialogoTransacao::DialogoTransacao(void)
{
  InitializeComponent();
}

DialogoTransacao::DialogoTransacao(String^ sMensagem, Form^ frmCaller)
{
  InitializeComponent();
  this->caller = frmCaller;
  lblMensagem->Text = sMensagem;
  oLog = ((InterfaceExemplo^)caller)->getLog();
}

#pragma endregion

void DialogoTransacao::setModo(int iModo, String^ sLabel)
{
  ((InterfaceExemplo^)caller)->setOperacaoCancelada(false);
  bAguardandokeyPress = false;
  this->iModo = iModo;
  lblMensagem->Text = sLabel;
  boxValor->Enabled = true;
  boxValor->Text = L"";
  sTransicao = "";
  boxValor->Enabled = true;
  boxValor->Visible = true;
  cboxSelecionaOpcao->Visible = false;
  boxValor->Enabled = true;
  btCancelar->Enabled = true;
  bOperacaoCancelada = false;
  imgInfo->Visible = false;
  iCasasDecimais = 2;
  boxValor->MaxLength = 20;
  boxValor->TextAlign = HorizontalAlignment::Right;
  boxValor->Font = gcnew System::Drawing::Font(boxValor->Font->Name, 20);
  boxValor->Focus();
  

  //força ficar no topo 
  this->Owner = caller;
  caller->TopMost = true;
  this->TopLevel = true;
  this->TopMost = true;

  oLog->GravarLog("DialogoTransacao->setModo(" + iModo + "," + sLabel + ")");

  switch (iModo)
  {
  case MODO_ENTRA_VALOR:
    boxValor->MaxLength = 15;
    ConverteBoxParaValor();
    break;
  case MODO_ENTRA_VALOR_ESPECIAL:
    boxValor->MaxLength = 15;
    ConverteBoxParaValor();
    break;
  case MODO_ENTRA_CARTAO:
    boxValor->Font = gcnew System::Drawing::Font(boxValor->Font->Name, 15);
    boxValor->Text = L"";
    break; 
  case MODO_INTERMEDIARIO_AGUARDA_ACAO:
  case MODO_CONFIRMACAO:
    boxValor->Enabled = false;
    btCancelar->Enabled = true;
    break;
  case MODO_ENTRA_DATA_VALIDADE:
    boxValor->TextAlign = HorizontalAlignment::Left;
    boxValor->MaxLength = 5;
    break;
  case MODO_ENTRA_DATA:
    boxValor->TextAlign = HorizontalAlignment::Left;
    boxValor->MaxLength = 8;
    break;
  case MODO_ENTRA_CODIGO_BARRAS:
    boxValor->TextAlign = HorizontalAlignment::Right;
    boxValor->MaxLength = 50;
    break;
  }
}

void DialogoTransacao::setModo(int iModo, String^ sLabel, String^ sParametros)
{
  setModo(iModo, sLabel);
  if (iModo == MODO_ENTRA_VALOR)
  {        
    String^ sConcat;
    FuncoesComuns::ExtraiNumeros(sParametros, sConcat);
    FuncoesComuns::ConverteBoxParaValor(boxValor, 2, sConcat);
  }
}

void DialogoTransacao::setModoSelecionaOpcoes(String^ sLabel, String^ sOpcoes, int iOpcaoSelecionada)
{
  oLog->GravarLog("DialogoTransacao->setModoSelecionaOpcoes(" + iModo + "," + sOpcoes + ", [vlr default =]" + iOpcaoSelecionada + ")");
  iModo = MODO_SELECIONA_OPCOES;
  lblMensagem->Text = sLabel;
  boxValor->Visible = false;
  bOperacaoCancelada = false;
  cboxSelecionaOpcao->Location = boxValor->Location;
  AjustaBoxOpcoes(sOpcoes);
  cboxSelecionaOpcao->SelectedIndex = 0;

  if (iOpcaoSelecionada > 0 && iOpcaoSelecionada <= cboxSelecionaOpcao->Items->Count)
      cboxSelecionaOpcao->SelectedIndex = iOpcaoSelecionada - 1;  
    
  cboxSelecionaOpcao->Visible = true;
  cboxSelecionaOpcao->Enabled = true;
  imgInfo->Visible = false;
  cboxSelecionaOpcao->Focus();
}

void DialogoTransacao::AjustaBoxOpcoes(String^ sOpcoes)
{
  oLog->GravarLog("DialogoTransacao->AjustaBoxOpcoes(" + sOpcoes + ")");
  cboxSelecionaOpcao->Items->Clear();
  array<String^>^VetorOpcoes = sOpcoes->Split('"');
  for (int i = 1; i < VetorOpcoes->Length; i += 2)
    cboxSelecionaOpcao->Items->Add(VetorOpcoes[i]);
}

void DialogoTransacao::setMensagem(String^ sMensagem, int iTipo)
{
  switch (iTipo)
  {
  case DISPLAY_TERMINAL:
    this->panelFeedBack->BackColor = System::Drawing::Color::WhiteSmoke;
    lblDisplayTerminal->Text = sMensagem;
    break;
  case DISPLAY_ERRO:
    this->panelFeedBack->BackColor = System::Drawing::Color::Red;
    lblDisplayTerminal->Text = sMensagem;
    break;
  case DISPLAY_MENSAGEM:
    lblMensagemTerminal->Text = sMensagem;
    lblMensagemTerminal->Visible = true;
    break;
  }
  this->Refresh();
  ((InterfaceExemplo ^)caller)->doEvents();
}

void DialogoTransacao::setMensagemAdicional(String^ sMensagem)
{
  lblMensagemAdicional->Visible = true;
  lblMensagemAdicional->Text = sMensagem;
}

void DialogoTransacao::EnviaTeclaPressionada()
{
  ((InterfaceExemplo^)caller)->teclaPressionada = true;
}

void DialogoTransacao::ConverteBoxParaValor()
{
  String ^ sConversor;

  String^ str = "";

  if (sTransicao->Length == 0)
  {
    str = L"0,";
    for (int i = 0; i < iCasasDecimais; i++)
    {
      str += L"0";
    }

  }
  else if (sTransicao->Length > 0 && sTransicao->Length < 3)
  {
    str = L"0,";
    for (int i = 0; i < iCasasDecimais - sTransicao->Length; i++)
    {
      str += L"0";
    }
    str += sTransicao;
  }
  else if (sTransicao->Length > 2)
  {
    if (sTransicao->Length <= iCasasDecimais)
      str += L"0";

    for (int i = 0; i < sTransicao->Length; i++)
    {
      if (i == sTransicao->Length - iCasasDecimais)
        str += L",";
      str += sTransicao[i];
      if (i == sTransicao->Length - (4 + iCasasDecimais) || i == sTransicao->Length - (7 + iCasasDecimais))
        str += L".";
    }
  }
  boxValor->Text = str;
}

void DialogoTransacao::AguardarConfirmacao()
{
  boxValor->Enabled = false;
  iModo = MODO_CONFIRMACAO;
}

void DialogoTransacao::EnviaOperacaoCancelada(bool bCancelada)
{
  oLog->GravarLog("DialogoTransacao->EnviaOperacaoCancelada()");
  ((InterfaceExemplo ^)caller)->setOperacaoCancelada(bCancelada);
}

void DialogoTransacao::setInfo(int iModo, String^ sMensagem)
{
  oLog->GravarLog("DialogoTransacao->setInfo(" + iModo + "," + sMensagem + ")");

  imgInfo->Visible = true;

  array<String^>^VetorMensagem = sMensagem->Split('|');
  if (VetorMensagem->Length > 1)
  {
    switch (iModo)
    {
    case MODO_ENTRA_VALOR:
      ttInfo->SetToolTip(imgInfo, "Valor Entre " + ToIntDef(VetorMensagem[0], 0) + " e " + VetorMensagem[1]);
      break;
    case MODO_ENTRA_NUMERO:
      ttInfo->SetToolTip(imgInfo, "Número Entre " + ToIntDef(VetorMensagem[0], 0) + " e " + VetorMensagem[1]);
      break;
    case MODO_ENTRA_VALOR_ESPECIAL:
      ttInfo->SetToolTip(imgInfo, "Valor Entre " + ToIntDef(VetorMensagem[0], 0) + " e " + VetorMensagem[1] +
        " Casas Decimais " + ToIntDef(VetorMensagem[2], 0));
      break;
    }
  }
}

void DialogoTransacao::AjustaModoEntraNumero(int iMinimoDigitos, int iMaximoDigitos, int iDigitosExatos, int iNumero)
{
  if (iNumero > 0)
    boxValor->Text = "" + iNumero;

  this->iMinimoDigitos = iMinimoDigitos;
  this->iMaximoDigitos = iMaximoDigitos;
  this->iDigitosExatos = iDigitosExatos;

  if (boxValor->Text->Length < iMinimoDigitos)
    btOk->Enabled = false;
}

void DialogoTransacao::AjustaModoEntraString(String^ sLabel, String^ sSTR, int iTamanhoMax)
{
  setModo(MODO_ENTRA_STRING, sLabel);
  boxValor->Text = sSTR;
  boxValor->MaxLength = iTamanhoMax;
}

int DialogoTransacao::ToIntDef(String^ str, int i)
{
  int iRet;

  try
  {
    iRet = int::Parse(str);
  }
  catch (Exception^ e)
  {
    return i;
  }

  return iRet;
}
