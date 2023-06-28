#include "StdAfx.h"
#include "Define.h"
#include "InterfaceExemplo.h"
#include "DialogoSelecionaPlanos.h"
#include "ConsultaAVS.h"
#include <msclr\marshal.h>
#include <iostream>
#include <vector>
#include <sstream>
#include <process.h>
#include "frmComprovante.h"

using namespace ExemploInterfaceIntegracao;
using namespace System;
using namespace msclr::interop;


InterfaceExemplo::InterfaceExemplo(void)
{
	classe = new ClasseIntegracao();	
	classe->carregaDll();
	registrarFuncoesCallBack();
  
	classe->setTransacaoSemTelas();
	oLog = gcnew Logger();
	InitializeComponent();
}

void InterfaceExemplo::registrarFuncoesCallBack()
{
	_CallBackDisplayTerminal^ cbDisplayTerminal = gcnew _CallBackDisplayTerminal(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackDisplayTerminal);
	IntPtr stubPtrDisplayTerminal = Marshal::GetFunctionPointerForDelegate(cbDisplayTerminal);
	pCallBackDisplayTerminal pointerCBDisplayTerminal = static_cast<pCallBackDisplayTerminal>(stubPtrDisplayTerminal.ToPointer());		
	_GCDislpayTerminal.Alloc(cbDisplayTerminal);
	classe->setCallBackDisplayTerminal(pointerCBDisplayTerminal);
	
	_CallBackDisplayErro^ cbDisplayErro = gcnew _CallBackDisplayErro(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackDisplayErro);
	IntPtr stubPtrDisplayErro = Marshal::GetFunctionPointerForDelegate(cbDisplayErro);
	pCallBackDisplayErro pointerCBDisplayErro = static_cast<pCallBackDisplayErro>(stubPtrDisplayErro.ToPointer());		
	_GCDisplayErro.Alloc(cbDisplayErro);
	classe->setCallBackDisplayErro(pointerCBDisplayErro);
	

	_CallBackMensagem^ cbMensagem = gcnew _CallBackMensagem(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackDisplayMensagem);
	IntPtr stubPtrMensagem = Marshal::GetFunctionPointerForDelegate(cbMensagem);
	pCallBackDisplayErro pointerCBMensagem = static_cast<pCallBackMensagem>(stubPtrMensagem.ToPointer());		
	_GCMensagem.Alloc(cbMensagem);
	classe->setCallBackDisplayMensagem(pointerCBMensagem);
	

	_CallBackBeep^ cbBeep = gcnew _CallBackBeep(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackBeep);
	IntPtr stubPtrBeep = Marshal::GetFunctionPointerForDelegate(cbBeep);
	pCallBackBeep pointerCBBeep = static_cast<pCallBackBeep>(stubPtrBeep.ToPointer());		
	_GCBEep.Alloc(cbBeep);
	classe->setCallBackBeep(pointerCBBeep);
	
	_CallBackSolicitaConfirmacao^ cbSolicitaConfirmacao = gcnew _CallBackSolicitaConfirmacao(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackSolicitaConfirmacao);
	IntPtr stubPtrSolicitaConfirmacao = Marshal::GetFunctionPointerForDelegate(cbSolicitaConfirmacao);
	pCallBackSolicitaConfirmacao pointerCBSolicitaConfirmacao = static_cast<pCallBackSolicitaConfirmacao>(stubPtrSolicitaConfirmacao.ToPointer());		
	_GCSolicitaConfirmacao.Alloc(cbSolicitaConfirmacao);
	classe->setCallBackSolicitaConfirmacao(pointerCBSolicitaConfirmacao);


	_CallBackEntraCartao^ cbEntraCartao = gcnew _CallBackEntraCartao(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraCartao);
	IntPtr stubPtrEntraCartao = Marshal::GetFunctionPointerForDelegate(cbEntraCartao);
	pCallBackEntraCartao pointerCBEntraCartao = static_cast<pCallBackEntraCartao>(stubPtrEntraCartao.ToPointer());		
	_GCEntraCartao.Alloc(cbEntraCartao);
	classe->setCallBackEntraCartao(pointerCBEntraCartao);


	_CallBackEntraDataValidade^ cbEntraDataValidade = gcnew _CallBackEntraDataValidade(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraDataValidade);
	IntPtr stubPtrEntraDataValidade = Marshal::GetFunctionPointerForDelegate(cbEntraDataValidade);
	pCallBackEntraDataValidade pointerCBEntraDataValidade = static_cast<pCallBackEntraDataValidade>(stubPtrEntraDataValidade.ToPointer());		
	_GCEntraDataValidade.Alloc(cbEntraDataValidade);
	classe->setCallBackEntraDataValidade(pointerCBEntraDataValidade);
	

	_CallBackEntraData^ cbEntraData = gcnew _CallBackEntraData(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraData);
	IntPtr stubPtrEntraData = Marshal::GetFunctionPointerForDelegate(cbEntraData);
	pCallBackEntraData pointerCBEntraData = static_cast<pCallBackEntraData>(stubPtrEntraData.ToPointer());		
	_GCEntraData.Alloc(cbEntraData);
	classe->setCallBackEntraData(pointerCBEntraData);
	

	_CallBackEntraCodigoSeguranca^ cbEntraCodigoSeguranca = gcnew _CallBackEntraCodigoSeguranca(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraCodigoSeguranca);
	IntPtr stubPtrEntraCodigoSeguranca = Marshal::GetFunctionPointerForDelegate(cbEntraCodigoSeguranca);
	pCallBackEntraCodigoSeguranca pointerCBEntraCodigoSeguranca = static_cast<pCallBackEntraCodigoSeguranca>(stubPtrEntraCodigoSeguranca.ToPointer());		
	_GCEntraCodigoSeguranca.Alloc(cbEntraCodigoSeguranca);
	classe->setCallBackEntraCodigoSeguranca(pointerCBEntraCodigoSeguranca);
	

	_CallBackSelecionaOpcao^ cbSelecionaOpcao = gcnew _CallBackSelecionaOpcao(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackSelecionaOpcao);
	IntPtr stubPtrSelecionaOpcao = Marshal::GetFunctionPointerForDelegate(cbSelecionaOpcao);
	pCallBackSelecionaOpcao pointerCBSelecionaOpcao = static_cast<pCallBackSelecionaOpcao>(stubPtrSelecionaOpcao.ToPointer());		
	_GCSelecionaOpcao.Alloc(cbSelecionaOpcao);
	classe->setCallBackSelecionaOpcao(pointerCBSelecionaOpcao);
	

	_CallBackEntraValor^ cbEntraValor = gcnew _CallBackEntraValor(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraValor);
	IntPtr stubPtrEntraValor = Marshal::GetFunctionPointerForDelegate(cbEntraValor);
	pCallBackEntraValor pointerCBEntraValor = static_cast<pCallBackEntraValor>(stubPtrEntraValor.ToPointer());		
	_GCEntraValor.Alloc(cbEntraValor);
	classe->setCallBackEntraValor(pointerCBEntraValor);
	
  
  _CallBackEntraValorEspecial^ cbEntraValorEspecial = gcnew _CallBackEntraValorEspecial(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraValorEspecial);
  IntPtr stubPtrEntraValorEspecial = Marshal::GetFunctionPointerForDelegate(cbEntraValorEspecial);
  pCallBackEntraValorEspecial pointerCBEntraValorEspecial = static_cast<pCallBackEntraValorEspecial>(stubPtrEntraValorEspecial.ToPointer());
  _GCEntraValorEspecial.Alloc(cbEntraValorEspecial);
  classe->setCallBackEntraValorEspecial(pointerCBEntraValorEspecial);
  
	_CallBackEntraNumero^ cbEntraNumero = gcnew _CallBackEntraNumero(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraNumero);
	IntPtr stubPtrEntraNumero = Marshal::GetFunctionPointerForDelegate(cbEntraNumero);
	pCallBackEntraNumero pointerCBEntraNumero = static_cast<pCallBackEntraNumero>(stubPtrEntraNumero.ToPointer());		
	_GCEntraNumero.Alloc(cbEntraNumero);
	classe->setCallBackEntraNumero(pointerCBEntraNumero);
	

	_CallBackOperacaoCancelada^ cbOperacaoCancelada = gcnew _CallBackOperacaoCancelada(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackOperacaoCancelada);
	IntPtr stubPtrOperacaoCancelada = Marshal::GetFunctionPointerForDelegate(cbOperacaoCancelada);
	pCallBackOperacaoCancelada pointerCBOperacaoCancelada = static_cast<pCallBackOperacaoCancelada>(stubPtrOperacaoCancelada.ToPointer());		
	_GCOperacaoCancelada.Alloc(cbOperacaoCancelada);
	classe->setCallBackOperacaoCancelada(pointerCBOperacaoCancelada);
	

	_CallBackSetaOperacaoCancelada^ cbSetaOperacaoCancelada = gcnew _CallBackSetaOperacaoCancelada(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackSetaOperacaoCancelada);
	IntPtr stubPtrSetaOperacaoCancelada = Marshal::GetFunctionPointerForDelegate(cbSetaOperacaoCancelada);
	pCallBackSetaOperacaoCancelada pointerCBSetaOperacaoCancelada = static_cast<pCallBackSetaOperacaoCancelada>(stubPtrSetaOperacaoCancelada.ToPointer());		
	_GCSetaOperacaoCancelada.Alloc(cbSetaOperacaoCancelada);
	classe->setCallBackSetaOperacaoCancelada(pointerCBSetaOperacaoCancelada);


	_CallBackProcessaMensagens^ cbProcessaMensagens = gcnew _CallBackProcessaMensagens(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackProcessaMensagens);
	IntPtr stubPtrProcessaMensagens = Marshal::GetFunctionPointerForDelegate(cbProcessaMensagens);
	pCallBackProcessaMensagens pointerCBProcessaMensagens = static_cast<pCallBackProcessaMensagens>(stubPtrProcessaMensagens.ToPointer());		
	_GCProcessaMensagens.Alloc(cbProcessaMensagens);
	classe->setCallBackProcessaMensagens(pointerCBProcessaMensagens);
	

	_CallBackEntraString^ cbEntraString = gcnew _CallBackEntraString(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraString);
	IntPtr stubPtrEntraString = Marshal::GetFunctionPointerForDelegate(cbEntraString);
	pCallBackEntraString pointerCBEntraString = static_cast<pCallBackEntraString>(stubPtrEntraString.ToPointer());		
	_GCEntraString.Alloc(cbEntraString);
	classe->setCallBackEntraString(pointerCBEntraString);
	

    _CallBackConsultaAVS^ cbConsultaAVS = gcnew _CallBackConsultaAVS(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackConsultaAVS);
	IntPtr stubPtrConsultaAVS = Marshal::GetFunctionPointerForDelegate(cbConsultaAVS);
	pCallBackConsultaAVS pointerCBConsultaAVS = static_cast<pCallBackConsultaAVS>(stubPtrConsultaAVS.ToPointer());		
	_GCConsultaAVS.Alloc(cbConsultaAVS);
	classe->setCallBackConsultaAVS(pointerCBConsultaAVS);
	

	_CallBackMensagemAdicional^ cbMensagemAdicional = gcnew _CallBackMensagemAdicional(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackMensagemAdicional);
	IntPtr stubPtrMensagemAdicional = Marshal::GetFunctionPointerForDelegate(cbMensagemAdicional);
	pCallBackMensagemAdicional pointerCBMensagemAdicional = static_cast<pCallBackMensagemAdicional>(stubPtrMensagemAdicional.ToPointer());		
	_GCMensagemAdicional.Alloc(cbMensagemAdicional);
	classe->setCallBackMensagemAdicional(pointerCBMensagemAdicional);
	

	_CallBackEntraCodigoBarras^ cbEntraCodigoBarras = gcnew _CallBackEntraCodigoBarras(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraCodigoBarras);
	IntPtr stubPtrEntraCodigoBarras = Marshal::GetFunctionPointerForDelegate(cbEntraCodigoBarras);
	pCallBackEntraCodigoBarras pointerCBEntraCodigoBarras = static_cast<pCallBackEntraCodigoBarras>(stubPtrEntraCodigoBarras.ToPointer());		
	_GCEntraCodigoBarras.Alloc(cbEntraCodigoBarras);
	classe->setCallBackEntraCodigoBarras(pointerCBEntraCodigoBarras);
	

	_CallBackEntraCodigoBarrasLido^ cbEntraCodigoBarrasLido = gcnew _CallBackEntraCodigoBarrasLido(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackEntraCodigoBarrasLido);
	IntPtr stubPtrEntraCodigoBarrasLido = Marshal::GetFunctionPointerForDelegate(cbEntraCodigoBarrasLido);
	pCallBackEntraCodigoBarrasLido pointerCBEntraCodigoBarrasLido = static_cast<pCallBackEntraCodigoBarrasLido>(stubPtrEntraCodigoBarrasLido.ToPointer());		
	_GCEntraCodigoBarrasLido.Alloc(cbEntraCodigoBarrasLido);
	classe->setCallBackEntraCodigoBarrasLido(pointerCBEntraCodigoBarrasLido);
	

	_CallBackMensagemAlerta^ cbMensagemAlerta = gcnew _CallBackMensagemAlerta(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackMensagemAlerta);
	IntPtr stubPtrMensagemAlerta = Marshal::GetFunctionPointerForDelegate(cbMensagemAlerta);
	pCallBackMensagemAlerta pointerCBMensagemAlerta = static_cast<pCallBackMensagemAlerta>(stubPtrMensagemAlerta.ToPointer());		
	_GCMensagemAlerta.Alloc(cbMensagemAlerta);
	classe->setCallBackMensagemAlerta(pointerCBMensagemAlerta);
	

	_CallBackPreviewComprovante^ cbPreviewComprovante = gcnew _CallBackPreviewComprovante(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackPreviewComprovante);
	IntPtr stubPtrPreviewComprovante = Marshal::GetFunctionPointerForDelegate(cbPreviewComprovante);
	pCallBackPreviewComprovante pointerCBPreviewComprovante = static_cast<pCallBackPreviewComprovante>(stubPtrPreviewComprovante.ToPointer());		
	_GCPreviewComprovante.Alloc(cbPreviewComprovante);
	classe->setCallBackPreviewComprovante(pointerCBPreviewComprovante);
	

    _CallBackSelecionaPlanos^ cbSelecionaPlanos = gcnew _CallBackSelecionaPlanos(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackSelecionaPlanos);
	IntPtr stubPtrSelecionaPlanos = Marshal::GetFunctionPointerForDelegate(cbSelecionaPlanos);
	pCallBackSelecionaPlanos pointerCBSelecionaPlanos = static_cast<pCallBackSelecionaPlanos>(stubPtrSelecionaPlanos.ToPointer());		
	_GCSelecionaPlanos.Alloc(cbSelecionaPlanos);
	classe->setCallBackSelecionaPlanos(pointerCBSelecionaPlanos);

	_CallBackSelecionaPlanosEx^ cbSelecionaPlanosEx = gcnew _CallBackSelecionaPlanosEx(this, &ExemploInterfaceIntegracao::InterfaceExemplo::callBackSelecionaPlanosEx);
	IntPtr stubPtrSelecionaPlanosEx = Marshal::GetFunctionPointerForDelegate(cbSelecionaPlanosEx);
	pCallBackSelecionaPlanosEx pointerCBSelecionaPlanosEx = static_cast<pCallBackSelecionaPlanosEx>(stubPtrSelecionaPlanosEx.ToPointer());		
	_GCSelecionaPlanosEx.Alloc(cbSelecionaPlanosEx);
	classe->setCallBackSelecionaPlanosEx(pointerCBSelecionaPlanosEx);
}

vector<string> split(string str, char delimiter) {
  vector<string> internal;
  stringstream ss(str); 
  string tok;
  
  while(getline(ss, tok, delimiter)) {
    internal.push_back(tok);
  }
  
  return internal;
}

//Implementação do comportamento dos callbacks
#pragma region Implementação dos callbacks

void InterfaceExemplo::callBackDisplayTerminal(char *pMensagem)
{
	VerificaInstanciaDialogoTransacao();
	
	oLog->GravarLog("callBackDisplayTerminal()", pMensagem, "void");

	((DialogoTransacao^)dTransacao)->setMensagem(marshal_as<String^>(pMensagem), DISPLAY_TERMINAL);
}

void InterfaceExemplo::callBackDisplayErro(char *pMensagem)
{			
	VerificaInstanciaDialogoTransacao();

	oLog->GravarLog("callBackDisplayErro()", pMensagem, "void");

	((DialogoTransacao^)dTransacao)->setMensagem(marshal_as<String^>(pMensagem), DISPLAY_ERRO);
}

void InterfaceExemplo::callBackDisplayMensagem(char *pMensagem)
{
	VerificaInstanciaDialogoTransacao();

	oLog->GravarLog("callBackDisplayMensagem()", pMensagem, "void");

	((DialogoTransacao^)dTransacao)->setMensagem(marshal_as<String^>(pMensagem), DISPLAY_MENSAGEM);	
}

void InterfaceExemplo::callBackBeep(){
	oLog->GravarLog("callBackBeep()", "void", "void");
	Beep( 750, 500 );
}

int InterfaceExemplo::callBackSolicitaConfirmacao(char *pMensagem){
	oLog->GravarLog("callBackSolicitaConfirmacao(pMensagem)[entrada]", pMensagem);
  int ret = 0;
	String^ sMensagem = marshal_as<String^>(pMensagem);
	DialogoTransacao^ transacao;

	VerificaInstanciaDialogoTransacao();

	transacao = (DialogoTransacao ^)dTransacao;

  if (sMensagem == "")
	{
    transacao->setModo(MODO_CONFIRMACAO, sMensagem);
		aguardar();
    ret = ((DialogoTransacao ^)dTransacao)->RetornaTipoConfirmacao();
	}
  else if (MessageBox::Show(sMensagem, "Confirmação", MessageBoxButtons::YesNo, MessageBoxIcon::Question) == ::DialogResult::No)
	{
		oLog->GravarLog("callBackSolicitaConfirmacao[saida]", "", "-1");
		return -1;
	}

	oLog->GravarLog("callBackSolicitaConfirmacao(pMensagem)[saida]", pMensagem, "0");
	return ret;
}

int InterfaceExemplo::callBackEntraCartao(char *pLabel, char *pCartao){
	oLog->GravarLog("callBackEntraCartao(pLabel)[entrada]", pLabel, "");
	DialogoTransacao^ transacao;
	String^ label = marshal_as<String^>(pLabel);

	VerificaInstanciaDialogoTransacao();

	transacao = (DialogoTransacao ^)dTransacao;

	transacao->setModo(MODO_ENTRA_CARTAO, label);

  aguardar();

	if (transacao->getOperacaoCancelada())
        return -1;

	sprintf(pCartao, "%s", transacao->sTransicao);

	oLog->GravarLog("callBackEntraCartao[saida]", "**************", "0");
	return 0;
}

int InterfaceExemplo::callBackEntraDataValidade(char *pLabel, char *pDataValidade){
	oLog->GravarLog("callBackEntraDataValidade(pLabel)[entrada]", pLabel, "");
	DialogoTransacao^ transacao;
	String^ label = marshal_as<String^>(pLabel);

	VerificaInstanciaDialogoTransacao();

	transacao = (DialogoTransacao ^)dTransacao;

	transacao->setModo(MODO_ENTRA_DATA_VALIDADE, label);

	aguardar();

	if (transacao->getOperacaoCancelada())
        return -1;

	sprintf(pDataValidade, "%s", transacao->sTransicao);
	oLog->GravarLog("callBackEntraDataValidade(pDataValidade)[saida]", pDataValidade, "0");
	return 0;
}

int InterfaceExemplo::callBackEntraData(char *pLabel, char *pData){
	oLog->GravarLog("callBackEntraData(pLabel)[entrada]", pLabel);

	DialogoTransacao^ transacao;
	String^ label = marshal_as<String^>(pLabel);

	VerificaInstanciaDialogoTransacao();

	transacao = (DialogoTransacao ^)dTransacao;

	transacao->setModo(MODO_ENTRA_DATA, label);

	aguardar();

	if (transacao->getOperacaoCancelada())
        return -1;

  sprintf(pData, "%s", transacao->sTransicao);
	oLog->GravarLog("callBackEntraData(pData)[saida]", pData, "0");
	return 0;
}

int InterfaceExemplo::callBackEntraCodigoSeguranca(char *pLabel, char *pCodigoSeguranca, int TamanhoMax){

	DialogoTransacao^ transacao;
	String^ label = marshal_as<String^>(pLabel);
  String^ sTamanhoMax = L"" + TamanhoMax;

  oLog->GravarLog("callBackEntraCodigoSeguranca(pLabel, tamanhoMax) [entrada]", pLabel, FuncoesComuns::SystemStrToCharPtr(sTamanhoMax), "");

	VerificaInstanciaDialogoTransacao();

	transacao = (DialogoTransacao ^)dTransacao;

	transacao->setModo(MODO_ENTRA_CODIGO_SEGURANCA, label);

	aguardar();

	if (transacao->getOperacaoCancelada())
        return -1;

	sprintf(pCodigoSeguranca, "%s", transacao->sTransicao);

	oLog->GravarLog("callBackEntraCodigoSeguranca(pCodigoSeguranca) [saida]", pCodigoSeguranca, "0");
	return 0;
}

int InterfaceExemplo::callBackSelecionaOpcao(char *pLabel, char *pOpcoes, int *iOpcaoSelecionada){
	oLog->GravarLog("callBackSelecionaOpcao(pLabel, pOpcoes) [entrada]", pLabel, pOpcoes, "");

	DialogoTransacao^ transacao;
	String^ label = marshal_as<String^>(pLabel);
	String^ opcoes = marshal_as<String^>(pOpcoes);
  int indice = *iOpcaoSelecionada;
	VerificaInstanciaDialogoTransacao();

	transacao = (DialogoTransacao ^)dTransacao;

	transacao->setModoSelecionaOpcoes(label, opcoes, indice);

	aguardar();

	if (transacao->getOperacaoCancelada())
        return -1;

	int retornado = transacao->getIndiceSelecionado() +1;
	*iOpcaoSelecionada = retornado;

	oLog->GravarLog("callBackSelecionaOpcao(iOpcaoSelecionada) [saida]", retornado);
	return 0;
}

int InterfaceExemplo::callBackEntraValor(char *pLabel, char *pValor, char *pValorMinimo, char *pValorMaximo){
	oLog->GravarLog("callBackEntraValor(pLabel, pValorMinimo, pValorMaximo) [entrada]", pLabel, pValorMinimo, pValorMaximo, "");
	DialogoTransacao^ transacao;
	String^ info = marshal_as<String^>(pValorMinimo);
	info += L"|";
	info += marshal_as<String^>(pValorMaximo);

	VerificaInstanciaDialogoTransacao();

	transacao = (DialogoTransacao ^)dTransacao;

	String^ label = marshal_as<String^>(pLabel);
  String^ sValor = marshal_as<String^>(pValor);

	transacao->setModo(MODO_ENTRA_VALOR, label, sValor);
	transacao->setInfo(MODO_ENTRA_VALOR, info);

	aguardar();
	
	if (transacao->getOperacaoCancelada())
        return -1;

	sprintf(pValor, "%s", transacao->sTransicao);
	oLog->GravarLog("callBackEntraValor(pValor) [saida]", pValor);
	return 0;
}

int InterfaceExemplo::callBackEntraValorEspecial(char *pLabel, char *pValor, char *pParametros){
	oLog->GravarLog("callBackEntraValorEspecial(pLabel) [entrada]", pLabel);
	DialogoTransacao^ transacao;
	String^ sParametros = marshal_as<String^>(pParametros);
	String^ info = sParametros->Substring(0,11);
	info += L"|";
	info += sParametros->Substring(12,23);
	info += L"|";
	info += sParametros->Substring(24);

	VerificaInstanciaDialogoTransacao();

	transacao = (DialogoTransacao ^)dTransacao;

	String^ label = marshal_as<String^>(pLabel);

	transacao->iCasasDecimais = transacao->ToIntDef(sParametros->Substring(24),2);
	transacao->setModo(MODO_ENTRA_VALOR_ESPECIAL, label);
	transacao->setInfo(MODO_ENTRA_VALOR_ESPECIAL, info);

	aguardar();
	
	if (transacao->getOperacaoCancelada())
        return -1;

	sprintf(pValor, "%s", transacao->sTransicao);

	oLog->GravarLog("callBackEntraValorEspecial(pLabel) [saida]", pValor, "0");

	return 0;
}

int InterfaceExemplo::callBackEntraNumero(char *pLabel, char *pNumero, char *pNumeroMinimo, char *pNumeroMaximo,int iMinimoDigitos,int iMaximoDigitos,int iDigitosExatos){
	oLog->GravarLog("callBackEntraNumero(pLabel, numeroMinimo, NumeroMax) [entrada]", pLabel, pNumeroMinimo, pNumeroMaximo , "");
	DialogoTransacao^ frmTransacao;
	String^ info = marshal_as<String^>(pNumeroMinimo);
	info += L"|";
	info += marshal_as<String^>(pNumeroMaximo);
  int iNumero = frmTransacao->ToIntDef(marshal_as<String^>(pNumero), 0);

	VerificaInstanciaDialogoTransacao();

  frmTransacao = (DialogoTransacao ^)dTransacao;

	String^ label = marshal_as<String^>(pLabel);

  frmTransacao->setModo(MODO_ENTRA_NUMERO, label);
  frmTransacao->AjustaModoEntraNumero(iMinimoDigitos, iMaximoDigitos, iDigitosExatos, iNumero);
  frmTransacao->setInfo(MODO_ENTRA_NUMERO, info);

	aguardar();
	
  if (frmTransacao->getOperacaoCancelada())
        return -1;

  sprintf(pNumero, "%s", frmTransacao->sTransicao);

	oLog->GravarLog("callBackEntraNumero(pLabel)[saida]", pNumero, "0");

	return 0;
}

int InterfaceExemplo::callBackOperacaoCancelada(void){
	int ret = 0;

  if (operacaoCancelada)
  {
    oLog->GravarLog("Operacao cancelada = true");
    ret = 1;
  }
	return ret;
}

int InterfaceExemplo::callBackSetaOperacaoCancelada(bool bCancelada){
	operacaoCancelada = bCancelada;
  oLog->GravarLog("SetaOperacaoCancelada = " + bCancelada);
	return 0;
}

void InterfaceExemplo::callBackProcessaMensagens(){
MSG Msg; 
    if(::PeekMessage(&Msg, NULL, 0, 0, PM_REMOVE)) 
    { 
        ::TranslateMessage(&Msg); 
        ::DispatchMessage(&Msg); 
    } 
}

int InterfaceExemplo::callBackEntraString(char *pLabel, char *pString, char *pTamanhoMaximo){
	oLog->GravarLog("callBackEntraString(pLabel, pTamanhoMaximo)[entrada]", pLabel, pTamanhoMaximo, "");

  DialogoTransacao^ frmTransacao;

	VerificaInstanciaDialogoTransacao();

  frmTransacao = (DialogoTransacao ^)dTransacao;

	String^ sLabel = marshal_as<String^>(pLabel);
  String^ sSTR = marshal_as<String^>(pString);

  frmTransacao->AjustaModoEntraString(sLabel, sSTR, *pTamanhoMaximo);

	aguardar();
	
  if (frmTransacao->getOperacaoCancelada())
        return -1;

  sprintf(pString, "%s", frmTransacao->sTransicao);

	oLog->GravarLog("callBackEntraString(pNumero)[saida]", pString, "0");

	return 0;
}

int InterfaceExemplo::callBackConsultaAVS(char *cEndereco,char *cNumero,char *cApto,char *cBloco,char *cCEP,char *cBairro,char *cCPF){
	oLog->GravarLog("callBackConsultaAVS(apenas retorno de parametros)[entrada]", "");
  tsConsultaAVS* stConsultaAVS;
	ConsultaAVS^ frmConsultaAVS = gcnew ConsultaAVS();

  if (frmConsultaAVS->ShowDialog() != System::Windows::Forms::DialogResult::OK)
    return -1;

  stConsultaAVS = frmConsultaAVS->getParametros();

  cEndereco = stConsultaAVS->endereco;
  cNumero = stConsultaAVS->numero;
  cApto = stConsultaAVS->apartamento;
  cBloco = stConsultaAVS->bloco;
  cCEP = stConsultaAVS->CEP;
  cBairro = stConsultaAVS->bairro;
  cCPF = stConsultaAVS->CPF;

	oLog->GravarLog("callBackConsultaAVS[parametros][saida]", "","0");

	return 0;
}

int InterfaceExemplo::callBackMensagemAdicional(char *pMensagemAdicional){
	
	VerificaInstanciaDialogoTransacao();

	((DialogoTransacao^)dTransacao)->setMensagemAdicional(marshal_as<String^>(pMensagemAdicional));

	oLog->GravarLog("callBackMensagemAdicional(pMensagemAdicional)", pMensagemAdicional, "");

	return 0;
}

int InterfaceExemplo::callBackImagemAdicional(int iIndiceImagem){
	return 0;
} 

int InterfaceExemplo::callBackEntraCodigoBarras(char *pLabel,char *pCampo){
	oLog->GravarLog("callBackEntraCodigoBarras(pLabel)[entrada]", pLabel);

	DialogoTransacao^ frmTransacao;

	VerificaInstanciaDialogoTransacao();

  frmTransacao = (DialogoTransacao ^)dTransacao;

	String^ sLabel = marshal_as<String^>(pLabel);

  frmTransacao->setModo(MODO_ENTRA_CODIGO_BARRAS, sLabel);

	aguardar();
	
  if (frmTransacao->getOperacaoCancelada())
        return -1;

  sprintf(pCampo, "%s", frmTransacao->sTransicao);

	oLog->GravarLog("callBackEntraCodigoBarras(pLabel)[saida]", pCampo);

	return 0;
}

int InterfaceExemplo::callBackEntraCodigoBarrasLido(char *pLabel,char *pCampo){
	oLog->GravarLog("callBackEntraCodigoBarrasLido(pLabel)[entrada]", pLabel);

  DialogoTransacao^ frmTransacao;

	VerificaInstanciaDialogoTransacao();

  frmTransacao = (DialogoTransacao ^)dTransacao;

  String^ sLabel = marshal_as<String^>(pLabel);

  frmTransacao->setModo(MODO_ENTRA_CODIGO_BARRAS, sLabel);

	aguardar();
	
  if (frmTransacao->getOperacaoCancelada())
        return -1;

  sprintf(pCampo, "%s", frmTransacao->sTransicao);
	oLog->GravarLog("callBackEntraCodigoBarrasLido(pLabel)[saida]", pCampo, "0");
	return 0;
}

void InterfaceExemplo::callBackMensagemAlerta(char *pMensagemAlerta){
	String^ sMensagem = marshal_as<String^>(pMensagemAlerta);
  MessageBox::Show(sMensagem, "Mensagem Alerta");
}

void InterfaceExemplo::callBackPreviewComprovante(char * cComprovante){
  String^ sComprovante = marshal_as<String^>(cComprovante);
  Form^ Comprovante = gcnew frmComprovante(sComprovante);
  Comprovante->Show();
}
int InterfaceExemplo::callBackSelecionaPlanos(int iCodigoRede, int iCodigoTransacao, int iTipoFinanciamento, int iMaximoParcelas,char *pValorMinimoParcela,
  int iMaxDiasPreDatado, char *pNumeroParcelas, char *pValorTransacao, char *pValorParcela, char *pValorEntrada, char *pData)
{
	oLog->GravarLog("callBackSelecionaPlanos()[entrada]", "");

  //*Ainda não está implementada, por default retornar -1 ou não registrar o callback

	/*String^ valorMinParcela = marshal_as<String^>(pValorMinimoParcela);
	String^ numeroMaxParcela = Convert::ToString(iMaximoParcelas);
	String^ maxDias = Convert::ToString(iMaxDiasPreDatado);

  tsSelecionaPlanos* stSelecionaPlanos = new tsSelecionaPlanos;

	DialogoSelecionaPlanos^ selecionaPlanos = gcnew DialogoSelecionaPlanos(maxDias, numeroMaxParcela, valorMinParcela);

  if (selecionaPlanos->ShowDialog() != System::Windows::Forms::DialogResult::OK)
    return -1;

  stSelecionaPlanos = selecionaPlanos->getParametros();

  pData = stSelecionaPlanos->sData;
  pNumeroParcelas = stSelecionaPlanos->sNumeroParcelas;
  pValorEntrada = stSelecionaPlanos->sValorEntrada;
  pValorParcela = stSelecionaPlanos->sValorParcela;
  pValorTransacao = stSelecionaPlanos->sValorTransacao;*/

	oLog->GravarLog("callBackSelecionaPlanos[parametros][saida]", "-1");

	return -1;
}
int InterfaceExemplo::callBackSelecionaPlanosEx(char *pSolicitacao, char *pRetorno){
  /*
    Método reservado para uso futuro
  */

  // se o D-POS tiver planos, tem que processar os planos por aqui
  strcpy(pRetorno, "");
  return -1;
}
#pragma endregion

void InterfaceExemplo::aguardar(){

	teclaPressionada = false;

  while (true)
  {
      if (teclaPressionada)
		return;
      doEvents();
  }
}

void InterfaceExemplo::aguardarConfirmacao(){
	oLog->GravarLog("aguardarConfirmacao()", "void");
	((DialogoTransacao^)dTransacao)->setModo(MODO_CONFIRMACAO, "");

	aguardar();
}

void InterfaceExemplo::doEvents()
{
	MSG Msg; 
    if(::PeekMessage(&Msg, NULL, 0, 0, PM_REMOVE)) 
    { 
        ::TranslateMessage(&Msg); 
        ::DispatchMessage(&Msg); 
    } 
}

void InterfaceExemplo::FechaDialogo(){
   if(dTransacao != nullptr) {
      dTransacao->Close();
      delete(dTransacao);
      dTransacao = nullptr;
   }
   this->Enabled = true;
}

void InterfaceExemplo::VerificaInstanciaDialogoTransacao(){
	if(dTransacao == nullptr)
	{		
		dTransacao = gcnew DialogoTransacao(L"", this);
	}

	if(!dTransacao->Visible)
		dTransacao->Show();

	this->Enabled = false;
}

