#include "StdAfx.h"
#include "ClasseIntegracao.h"
#include <string>
#include <iostream>
#include <windows.h>
#include "DialogoTransacao.h"

using namespace std;

HMODULE handle;
ClasseIntegracao classeTEF;

static bool isCancelada;


ClasseIntegracao::ClasseIntegracao()
{
	semTelas = false;
}

void ClasseIntegracao::carregaDll(void)
{
	if(handle == NULL)
	{
	  handle = LoadLibrary(TEXT("DPOSDRV.DLL"));
	}

	if(semTelas)
	  RegistrarFuncoesCallBack();	
}

void ClasseIntegracao::setTransacaoSemTelas()
{
	semTelas = true;
}

//funções callback

void ClasseIntegracao::setCallBackDisplayTerminal(ptrCallBackDisplayTerminal cbDisplayTerminal)
{
	RegPDVDisplayTerminal RegPDVDisplayTerminalPtr = RegPDVDisplayTerminal(GetProcAddress(handle, "RegPDVDisplayTerminal"));
	if(RegPDVDisplayTerminalPtr != NULL)
		RegPDVDisplayTerminalPtr((pCallBackDisplayTerminal)cbDisplayTerminal);
}

void ClasseIntegracao::setCallBackDisplayErro(ptrCallBackDisplayErro cbCallBackDisplayErro)
{
	RegPDVDisplayErro RegPDVDisplayErroPtr = RegPDVDisplayErro(GetProcAddress(handle, "RegPDVDisplayErro"));
	if(RegPDVDisplayErroPtr != NULL)
		RegPDVDisplayErroPtr((pCallBackDisplayErro)cbCallBackDisplayErro);
}

void ClasseIntegracao::setCallBackDisplayMensagem(ptrCallBackMensagem cbDisplayMensagem)
{
	RegPDVMensagem RegPDVMensagemPtr = RegPDVMensagem(GetProcAddress(handle, "RegPDVMensagem"));
	if(RegPDVMensagemPtr != NULL)
		RegPDVMensagemPtr((pCallBackMensagem)cbDisplayMensagem);
}

void ClasseIntegracao::setCallBackBeep(ptrCallBackBeep cbBeep)
{
	RegPDVBeep RegPDVBeepPtr = RegPDVBeep(GetProcAddress(handle,"RegPDVBeep"));
	if(RegPDVBeepPtr != NULL)
		RegPDVBeepPtr((pCallBackBeep)cbBeep);
}

void ClasseIntegracao::setCallBackSolicitaConfirmacao(ptrCallBackSolicitaConfirmacao cbSolicitaConfirmacao)
{
	RegPDVSolicitaConfirmacao RegPDVSolicitaConfirmacaoPtr = RegPDVSolicitaConfirmacao(GetProcAddress(handle,"RegPDVSolicitaConfirmacao"));
	if(RegPDVSolicitaConfirmacaoPtr != NULL)
		RegPDVSolicitaConfirmacaoPtr((pCallBackSolicitaConfirmacao)cbSolicitaConfirmacao);
}

void ClasseIntegracao::setCallBackEntraCartao(ptrCallBackEntraCartao cbEntraCartao)
{
	RegPDVEntraCartao RegPDVEntraCartaoPtr = RegPDVEntraCartao(GetProcAddress(handle,"RegPDVEntraCartao"));
	if(RegPDVEntraCartaoPtr != NULL)
		RegPDVEntraCartaoPtr((pCallBackEntraCartao)cbEntraCartao);
}

void ClasseIntegracao::setCallBackEntraDataValidade(ptrCallBackEntraDataValidade cbEntraDataValidade)
{
	RegPDVEntraDataValidade RegPDVEntraDataValidadePtr = RegPDVEntraDataValidade(GetProcAddress(handle,"RegPDVEntraDataValidade"));
	if(RegPDVEntraDataValidadePtr != NULL)
		RegPDVEntraDataValidadePtr((pCallBackEntraDataValidade)cbEntraDataValidade);
}

void ClasseIntegracao::setCallBackEntraData(ptrCallBackEntraData cbEntraData)
{
	RegPDVEntraData RegPDVEntraDataPtr = RegPDVEntraData(GetProcAddress(handle,"RegPDVEntraData"));
		if(RegPDVEntraDataPtr != NULL)
			RegPDVEntraDataPtr((pCallBackEntraData)cbEntraData);
}

void ClasseIntegracao::setCallBackEntraCodigoSeguranca(ptrCallBackEntraCodigoSeguranca cbEntraCodigoSeguranca)
{
	RegPDVEntraCodigoSeguranca RegPDVEntraCodigoSegurancaPtr = RegPDVEntraCodigoSeguranca(GetProcAddress(handle,"RegPDVEntraCodigoSeguranca"));
	if(RegPDVEntraCodigoSegurancaPtr != NULL)
		RegPDVEntraCodigoSegurancaPtr((pCallBackEntraCodigoSeguranca)cbEntraCodigoSeguranca);
}

void ClasseIntegracao::setCallBackSelecionaOpcao(ptrCallBackSelecionaOpcao cbSelecionaOpcao)
{
	RegPDVSelecionaOpcao RegPDVSelecionaOpcaoPtr = RegPDVSelecionaOpcao(GetProcAddress(handle,"RegPDVSelecionaOpcao"));
	if(RegPDVSelecionaOpcaoPtr != NULL)
		RegPDVSelecionaOpcaoPtr((pCallBackSelecionaOpcao)cbSelecionaOpcao);
}

void ClasseIntegracao::setCallBackEntraValor(ptrCallBackEntraValor cbEntraValor)
{
	RegPDVEntraValor RegPDVEntraValorPtr = RegPDVEntraValor(GetProcAddress(handle,"RegPDVEntraValor"));
	if(RegPDVEntraValorPtr != NULL)
		RegPDVEntraValorPtr((pCallBackEntraValor)cbEntraValor);
}

void ClasseIntegracao::setCallBackEntraValorEspecial(ptrCallBackEntraValorEspecial cbEntraValorEspecial)
{
  RegPDVEntraValorEspecial RegPDVEntraValorEspecialPtr = RegPDVEntraValorEspecial(GetProcAddress(handle, "RegPDVEntraValorEspecial"));
  if (RegPDVEntraValorEspecialPtr != NULL)
    RegPDVEntraValorEspecialPtr((pCallBackEntraValorEspecial)cbEntraValorEspecial);
}

void ClasseIntegracao::setCallBackEntraNumero(ptrCallBackEntraNumero cbEntraNumero)
{
	 RegPDVEntraNumero RegPDVEntraNumeroPtr = RegPDVEntraNumero(GetProcAddress(handle,"RegPDVEntraNumero"));
	 if(RegPDVEntraNumeroPtr != NULL)
		 RegPDVEntraNumeroPtr((pCallBackEntraNumero)cbEntraNumero);
}

void ClasseIntegracao::setCallBackOperacaoCancelada(ptrCallBackOperacaoCancelada cbOperacaoCancelada)
{
  RegPDVOperacaoCancelada RegPDVOperacaoCanceladaPtr = RegPDVOperacaoCancelada(GetProcAddress(handle,"RegPDVOperacaoCancelada"));
	if(RegPDVOperacaoCanceladaPtr != NULL)
		RegPDVOperacaoCanceladaPtr((pCallBackOperacaoCancelada)cbOperacaoCancelada);
	
}

void ClasseIntegracao::setCallBackSetaOperacaoCancelada(ptrCallBackSetaOperacaoCancelada cbSetaOperacaoCancelada)
{
  RegPDVSetaOperacaoCancelada RegPDVSetaOperacaoCanceladaPtr = RegPDVSetaOperacaoCancelada(GetProcAddress(handle,"RegPDVSetaOperacaoCancelada"));
	if(RegPDVSetaOperacaoCanceladaPtr != NULL)
		RegPDVSetaOperacaoCanceladaPtr((pCallBackSetaOperacaoCancelada)cbSetaOperacaoCancelada);
	
}

void ClasseIntegracao::setCallBackProcessaMensagens(ptrCallBackProcessaMensagens cbProcessaMensagens){
  RegPDVProcessaMensagens RegPDVProcessaMensagensPtr = RegPDVProcessaMensagens(GetProcAddress(handle,"RegPDVProcessaMensagens"));
	if(RegPDVProcessaMensagensPtr != NULL)
		RegPDVProcessaMensagensPtr((pCallBackProcessaMensagens)cbProcessaMensagens);
	
}

void ClasseIntegracao::setCallBackEntraString(ptrCallBackEntraString cbEntraString){
  RegPDVEntraString RegPDVEntraStringPtr = RegPDVEntraString(GetProcAddress(handle,"RegPDVEntraString"));
	if(RegPDVEntraStringPtr != NULL)
		RegPDVEntraStringPtr((pCallBackEntraString)cbEntraString);
	
}

void ClasseIntegracao::setCallBackConsultaAVS(ptrCallBackConsultaAVS cbConsultaAVS){
  RegPDVConsultaAVS RegPDVConsultaAVSPtr = RegPDVConsultaAVS(GetProcAddress(handle,"RegPDVConsultaAVS"));
	if(RegPDVConsultaAVSPtr != NULL)
		RegPDVConsultaAVSPtr((pCallBackConsultaAVS)cbConsultaAVS);
	
}

void ClasseIntegracao::setCallBackMensagemAdicional(ptrCallBackMensagemAdicional cbMensagemAdicional){
  RegPDVMensagemAdicional RegPDVMensagemAdicionalPtr = RegPDVMensagemAdicional(GetProcAddress(handle,"RegPDVMensagemAdicional"));
	if(RegPDVMensagemAdicionalPtr != NULL)
		RegPDVMensagemAdicionalPtr((pCallBackMensagemAdicional)cbMensagemAdicional);
	
}


void ClasseIntegracao::setCallBackImagemAdicional(ptrCallBackImagemAdicional cbImagemAdicional){
	RegPDVImagemAdicional RegPDVImagemAdicionalPtr = RegPDVImagemAdicional(GetProcAddress(handle,"RegPDVImagemAdicional"));
	if(RegPDVImagemAdicionalPtr != NULL)
		RegPDVImagemAdicionalPtr((pCallBackImagemAdicional)cbImagemAdicional);
 	
} 

void ClasseIntegracao::setCallBackEntraCodigoBarras(ptrCallBackEntraCodigoBarras cbEntraCodigoBarras){
  RegPDVEntraCodigoBarras RegPDVEntraCodigoBarrasPtr = RegPDVEntraCodigoBarras(GetProcAddress(handle,"RegPDVEntraCodigoBarras"));
	if(RegPDVEntraCodigoBarrasPtr != NULL)
		RegPDVEntraCodigoBarrasPtr((pCallBackEntraCodigoBarras)cbEntraCodigoBarras);
}

void ClasseIntegracao::setCallBackEntraCodigoBarrasLido(ptrCallBackEntraCodigoBarrasLido cbEntraCodigoBarrasLido){
  RegPDVEntraCodigoBarrasLido RegPDVEntraCodigoBarrasLidoPtr = RegPDVEntraCodigoBarrasLido(GetProcAddress(handle,"RegPDVEntraCodigoBarrasLido"));
	if(RegPDVEntraCodigoBarrasLidoPtr != NULL)
		RegPDVEntraCodigoBarrasLidoPtr((pCallBackEntraCodigoBarrasLido)cbEntraCodigoBarrasLido);
	
}

void ClasseIntegracao::setCallBackMensagemAlerta(ptrCallBackMensagemAlerta cbMensagemAlerta){
	RegPDVMensagemAlerta RegPDVMensagemAlertaPtr = RegPDVMensagemAlerta(GetProcAddress(handle,"RegPDVMensagemAlerta"));
	if(RegPDVMensagemAlertaPtr != NULL)
		RegPDVMensagemAlertaPtr((pCallBackMensagemAlerta)cbMensagemAlerta);
}

void ClasseIntegracao::setCallBackPreviewComprovante(ptrCallBackPreviewComprovante cbPreviewComprovante){
	RegPDVPreviewComprovante RegPDVPreviewComprovantePtr = RegPDVPreviewComprovante(GetProcAddress(handle,"RegPDVPreviewComprovante"));
	if(RegPDVPreviewComprovantePtr != NULL)
		RegPDVPreviewComprovantePtr((pCallBackPreviewComprovante)cbPreviewComprovante);
}

void ClasseIntegracao::setCallBackSelecionaPlanos(ptrCallBackSelecionaPlanos cbSelecionaPlanos){
	RegPDVSelecionaPlanos RegPDVSelecionaPlanosPtr = RegPDVSelecionaPlanos(GetProcAddress(handle,"RegPDVSelecionaPlanos"));
	if(RegPDVSelecionaPlanosPtr != NULL)
		RegPDVSelecionaPlanosPtr((pCallBackSelecionaPlanos)cbSelecionaPlanos);
}

void ClasseIntegracao::setCallBackSelecionaPlanosEx(ptrCallBackSelecionaPlanosEx cbSelecionaPlanosEx){
	RegPDVSelecionaPlanosEx RegPDVSelecionaPlanosExPtr = RegPDVSelecionaPlanosEx(GetProcAddress(handle,"RegPDVSelecionaPlanosEx"));
	if(RegPDVSelecionaPlanosExPtr != NULL)
		RegPDVSelecionaPlanosExPtr((pCallBackSelecionaPlanosEx)cbSelecionaPlanosEx);
}

void ClasseIntegracao::RegistrarFuncoesCallBack()
{	
}


// Funções de transacao
int ClasseIntegracao::TransacaoCartaoCredito(char* valor, char* numeroCupom, char* numeroControle)
{
	int retorno = 11;
	memset(numeroControle, 0, 7);

	if(handle > 0)
	{
		FTransacaoCartaoCredito TransacaoCartaoCreditoPtr = FTransacaoCartaoCredito(GetProcAddress(handle, "TransacaoCartaoCredito"));

		if(TransacaoCartaoCreditoPtr != NULL)
		{
			retorno = TransacaoCartaoCreditoPtr(valor, numeroCupom, numeroControle);
		}
	
	}

	return retorno;
}

void ClasseIntegracao::VersaoDPOS(char *pVersao)
{ 
	FVersaoDPOS versaoDPOSPtr = FVersaoDPOS(GetProcAddress(handle, "VersaoDPOS"));
	if(versaoDPOSPtr != NULL)
	{
		versaoDPOSPtr(pVersao);
	}
}
 
int ClasseIntegracao::TransacaoCartaoFrota(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle) 
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoFrota TransacaoCartaoFrotaPtr = FTransacaoCartaoFrota(GetProcAddress(handle, "TransacaoCartaoFrota"));
		
		if(TransacaoCartaoFrotaPtr != NULL)
		{
			retorno = TransacaoCartaoFrotaPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::ConfirmaCartaoFrota(char *pNumeroControle) 
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);
	FConfirmaCartaoFrota ConfirmaCartaoFrotaPtr = FConfirmaCartaoFrota(GetProcAddress(handle, "ConfirmaCartaoFrota"));
	
	if(handle > 0)
	{		
		if(ConfirmaCartaoFrotaPtr != NULL)
		{
			retorno = ConfirmaCartaoFrotaPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoCartaoFrotaCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pTipoProduto, char *pCodigoVeiculo,
	char *pCodigoCondutor, char *pKilometragem, char *pDadosServicos,  char *pPermiteAlteracao, char *pReservado)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{	
		FTransacaoCartaoFrotaCompleta TransacaoCartaoFrotaCompletaPtr = FTransacaoCartaoFrotaCompleta(GetProcAddress(handle, "TransacaoCartaoFrotaCompleta"));
		if(TransacaoCartaoFrotaCompletaPtr != NULL)
		{
			retorno = TransacaoCartaoFrotaCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pTipoProduto, pCodigoVeiculo, pCodigoCondutor, pKilometragem,
				pDadosServicos, pPermiteAlteracao, pReservado);
		}
	}

	return retorno;
}

int ClasseIntegracao::ImprimeCupomTEF(char *pPathArquivoCupomTEF, char *pMensagemOperador)
{ 
	int retorno = 11;
	memset(pMensagemOperador, 0, 65);

	if(handle > 0)
	{	
		FImprimeCupomTEF ImprimeCupomTEFPtr = FImprimeCupomTEF(GetProcAddress(handle, "ImprimeCupomTEF"));

		if(ImprimeCupomTEFPtr != NULL)
		{
			retorno = ImprimeCupomTEFPtr(pPathArquivoCupomTEF, pMensagemOperador);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoCartaoDebito(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{	
		FTransacaoCartaoDebito	TransacaoCartaoDebitoPtr = FTransacaoCartaoDebito(GetProcAddress(handle, "TransacaoCartaoDebito"));

		if(TransacaoCartaoDebitoPtr != NULL)
		{
			retorno = TransacaoCartaoDebitoPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}

	return retorno;
}


int ClasseIntegracao::TransacaoCartaoParceleMais(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle,char *pCodigoTabela)
{ 	
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{	
		FTransacaoCartaoParceleMais TransacaoCartaoParceleMaisPtr = FTransacaoCartaoParceleMais(GetProcAddress(handle, "TransacaoCartaoParceleMais"));

		if(TransacaoCartaoParceleMaisPtr != NULL)
		{
			retorno = TransacaoCartaoParceleMaisPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pCodigoTabela);
		}
	}

	return retorno;
}


int ClasseIntegracao::TransacaoCartaoParceleMaisCompleta(char *pValorTransacao, char *pNumeroCupom,char *pNumeroControle,char *pCodigoTabela,char *pNumeroParcelas,
	char *pValorParcela,char *pVencimentoPrimeiraParcela, char *pPermiteAlteracao)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{	
		FTransacaoCartaoParceleMaisCompleta TransacaoCartaoParceleMaisCompletaPtr = FTransacaoCartaoParceleMaisCompleta(GetProcAddress(handle, "TransacaoCartaoParceleMaisCompleta"));

		if(TransacaoCartaoParceleMaisCompletaPtr != NULL)
		{
			retorno = TransacaoCartaoParceleMaisCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pCodigoTabela, pNumeroParcelas, pValorParcela,
				pVencimentoPrimeiraParcela, pPermiteAlteracao);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoCartaoVoucher(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{			
		FTransacaoCartaoVoucher TransacaoCartaoVoucherPtr = FTransacaoCartaoVoucher(GetProcAddress(handle, "TransacaoCartaoVoucher"));
		
		if(TransacaoCartaoVoucherPtr != NULL)
		{
			retorno = TransacaoCartaoVoucherPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoCheque(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pQuantidadeCheques, char *pPeriodicidadeCheques, char *pDataPrimeiroCheque, char *pCarenciaPrimeiroCheque)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoCheque TransacaoChequePtr = FTransacaoCheque(GetProcAddress(handle, "TransacaoCheque"));

		if(TransacaoChequePtr != NULL)
		{
			retorno = TransacaoChequePtr(pValorTransacao, pNumeroCupom, pNumeroControle, pQuantidadeCheques, pPeriodicidadeCheques,
			pDataPrimeiroCheque, pCarenciaPrimeiroCheque); 
		}
	}

	return retorno;
}


int ClasseIntegracao::TransacaoCelular(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCelular TransacaoCelularPtr = FTransacaoCelular(GetProcAddress(handle, "TransacaoCelular"));

		if(TransacaoCelularPtr != NULL)
		{
			retorno = TransacaoCelularPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}
	
	return retorno;
}

int ClasseIntegracao::TransacaoCancelamentoCelular(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCancelamentoCelular TransacaoCancelamentoCelularPtr = FTransacaoCancelamentoCelular(GetProcAddress(handle, "TransacaoCancelamentoCelular"));
	
		if(TransacaoCancelamentoCelularPtr != NULL)
		{
			retorno = TransacaoCancelamentoCelularPtr(pNumeroControle);
		}
	}

	return retorno;
}


int ClasseIntegracao::TransacaoCancelamentoGarantiaCheque(char *pValorTransacao, char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCancelamentoGarantiaCheque TransacaoCancelamentoGarantiaChequePtr = FTransacaoCancelamentoGarantiaCheque(GetProcAddress(handle, "TransacaoCancelamentoGarantiaCheque"));
	
		if(TransacaoCancelamentoGarantiaChequePtr != NULL)
		{
			retorno = TransacaoCancelamentoGarantiaChequePtr(pValorTransacao, pNumeroControle);
		}
	}

	return retorno;
}


int ClasseIntegracao::TransacaoCancelamentoPagamento(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCancelamentoPagamento TransacaoCancelamentoPagamentoPtr = FTransacaoCancelamentoPagamento(GetProcAddress(handle, "TransacaoCancelamentoPagamento"));
	
		if(TransacaoCancelamentoPagamentoPtr != NULL)
		{
			retorno = TransacaoCancelamentoPagamentoPtr(pNumeroControle);
		}
	}

	return retorno;
}


int ClasseIntegracao::EstornoPreAutorizacaoRedecard(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FEstornoPreAutorizacaoRedecard EstornoPreAutorizacaoRedecardPtr = FEstornoPreAutorizacaoRedecard(GetProcAddress(handle, "EstornoPreAutorizacaoRedecard"));
	
		if(EstornoPreAutorizacaoRedecardPtr != NULL)
		{
			retorno = EstornoPreAutorizacaoRedecardPtr(pNumeroControle);
		}
	}

	return retorno;
}


int ClasseIntegracao::TransacaoConfirmacaoPreAutorizacao(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoConfirmacaoPreAutorizacao TransacaoConfirmacaoPreAutorizacaoPtr = FTransacaoConfirmacaoPreAutorizacao(GetProcAddress(handle, "TransacaoConfirmacaoPreAutorizacao"));
	
		if(TransacaoConfirmacaoPreAutorizacaoPtr != NULL)
		{
			retorno = TransacaoConfirmacaoPreAutorizacaoPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoCancelamentoPagamentoCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pPermiteAlteracao, char *pReservado)
{ 
	int retorno = 11;

	if(handle > 0)
	{
		FTransacaoCancelamentoPagamentoCompleta TransacaoCancelamentoPagamentoCompletaPtr = FTransacaoCancelamentoPagamentoCompleta(GetProcAddress(handle, "TransacaoCancelamentoPagamentoCompleta"));
	
		if(TransacaoCancelamentoPagamentoCompletaPtr != NULL)
		{
			retorno = TransacaoCancelamentoPagamentoCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pPermiteAlteracao, pReservado);
		}
	}

	return retorno;
}

int ClasseIntegracao::ConfirmaCartaoCredito(char *pNumeroControle)
{ 
	int retorno = 11;

	if(handle > 0)
	{
		FConfirmaCartaoCredito ConfirmaCartaoCreditoPtr = FConfirmaCartaoCredito(GetProcAddress(handle, "ConfirmaCartaoCredito"));

		if(ConfirmaCartaoCreditoPtr != NULL)
		{
			retorno = ConfirmaCartaoCreditoPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::ConfirmaCartaoDebito(char *pNumeroControle)
{ 
	int retorno = 11;

	if(handle > 0)
	{
		FConfirmaCartaoDebito ConfirmaCartaoDebitoPtr = FConfirmaCartaoDebito(GetProcAddress(handle, "ConfirmaCartaoDebito"));

		if(ConfirmaCartaoDebitoPtr != NULL)
		{
			retorno = ConfirmaCartaoDebitoPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::ConfirmaCartaoVoucher(char *pNumeroControle)
{ 
	int retorno = 11;

	if(handle > 0)
	{
		FConfirmaCartaoVoucher ConfirmaCartaoVoucherPtr = FConfirmaCartaoVoucher(GetProcAddress(handle, "ConfirmaCartaoVoucher"));

		if(ConfirmaCartaoVoucherPtr != NULL)
		{
			retorno = ConfirmaCartaoVoucherPtr(pNumeroControle);
		}
	}

	return retorno;
}


int ClasseIntegracao::ConfirmaDebitoBeneficiario(char *pNumeroControle)
{ 
	int retorno = 11;

	if(handle > 0)
	{
		FConfirmaDebitoBeneficiario ConfirmaDebitoBeneficiarioPtr = FConfirmaDebitoBeneficiario(GetProcAddress(handle, "ConfirmaDebitoBeneficiario"));

		if(ConfirmaDebitoBeneficiarioPtr != NULL)
		{
			retorno = ConfirmaDebitoBeneficiarioPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::ConfirmaCartao(char *pNumeroControle)
{ 
	int retorno = 11;

	if(handle > 0)
	{
		FConfirmaCartao ConfirmaCartaoPtr = FConfirmaCartao(GetProcAddress(handle, "ConfirmaCartao"));

		if(ConfirmaCartaoPtr != NULL)
		{
			retorno = ConfirmaCartaoPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::DesfazCartao(char *pNumeroControle)
{ 
	int retorno = 11;

	if(handle > 0)
	{
		FDesfazCartao DesfazCartaoPtr = FDesfazCartao(GetProcAddress(handle, "DesfazCartao"));

		if(DesfazCartaoPtr != NULL)
		{
			retorno = DesfazCartaoPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::FinalizaTransacao()
{ 
	int retorno = 11;
	if(handle > 0)
	{
		FFinalizaTransacao FinalizaTransacaoPtr = FFinalizaTransacao(GetProcAddress(handle, "FinalizaTransacao"));

		if(FinalizaTransacaoPtr != NULL)
		{
			retorno = FinalizaTransacaoPtr();
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoConsultaParcelas(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoConsultaParcelas TransacaoConsultaParcelasPtr = FTransacaoConsultaParcelas(GetProcAddress(handle, "TransacaoConsultaParcelas"));
	
		if(TransacaoConsultaParcelasPtr != NULL)
		{
			retorno = TransacaoConsultaParcelasPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoConsultaParcelasCredito(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoConsultaParcelasCredito TransacaoConsultaParcelasCreditoPtr = FTransacaoConsultaParcelasCredito(GetProcAddress(handle, "TransacaoConsultaParcelasCredito"));
	
		if(TransacaoConsultaParcelasCreditoPtr != NULL)
		{
			retorno = TransacaoConsultaParcelasCreditoPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoConsultaParcelasCelular(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoConsultaParcelasCelular TransacaoConsultaParcelasCelularPtr = FTransacaoConsultaParcelasCelular(GetProcAddress(handle, "TransacaoConsultaParcelasCelular"));
	
		if(TransacaoConsultaParcelasCelularPtr != NULL)
		{
			retorno = TransacaoConsultaParcelasCelularPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoPreAutorizacao(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoPreAutorizacao TransacaoPreAutorizacaoPtr = FTransacaoPreAutorizacao(GetProcAddress(handle, "TransacaoPreAutorizacao"));
	
		if(TransacaoPreAutorizacaoPtr != NULL)
		{
			retorno = TransacaoPreAutorizacaoPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoPreAutorizacaoCartaoCredito(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoPreAutorizacaoCartaoCredito TransacaoPreAutorizacaoCartaoCreditoPtr = FTransacaoPreAutorizacaoCartaoCredito(
			GetProcAddress(handle, "TransacaoPreAutorizacaoCartaoCredito"));

		if(TransacaoPreAutorizacaoCartaoCreditoPtr != NULL)
		{
			retorno = TransacaoPreAutorizacaoCartaoCreditoPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoPreAutorizacaoCartaoFrota(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
			FTransacaoPreAutorizacaoCartaoFrota TransacaoPreAutorizacaoCartaoFrotaPtr = FTransacaoPreAutorizacaoCartaoFrota(
		GetProcAddress(handle, "TransacaoPreAutorizacaoCartaoFrota"));

		if(TransacaoPreAutorizacaoCartaoFrotaPtr != NULL)
		{
			retorno = TransacaoPreAutorizacaoCartaoFrotaPtr(pNumeroControle);
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoFuncaoEspecial()
{ 
	int retorno = 11;
	if(handle > 0)
	{
		FTransacaoFuncaoEspecial TransacaoFuncaoEspecialPtr = FTransacaoFuncaoEspecial(GetProcAddress(handle, "TransacaoFuncaoEspecial"));

		if(TransacaoFuncaoEspecialPtr != NULL)
		{
			retorno = TransacaoFuncaoEspecialPtr();
		}
	}

	return retorno;
}

int ClasseIntegracao::TransacaoResumoVendas(char *pNumeroControle)
{ 
	int retorno = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoResumoVendas TransacaoResumoVendasPtr = FTransacaoResumoVendas(GetProcAddress(handle, "TransacaoResumoVendas"));

		if(TransacaoResumoVendasPtr != NULL)
		{
			retorno = TransacaoResumoVendasPtr(pNumeroControle);
		}
	}

	return retorno;
}

void ClasseIntegracao::DadosUltimaTransacao(char *pDadosUltimaTransacao)
{ 
	memset(pDadosUltimaTransacao, 0, 512);

	if(handle > 0)
	{
		FDadosUltimaTransacao DadosUltimaTransacaoPtr = FDadosUltimaTransacao(GetProcAddress(handle, "DadosUltimaTransacao"));
	
		if(DadosUltimaTransacaoPtr != NULL)
		{
			DadosUltimaTransacaoPtr(pDadosUltimaTransacao);
		}
	}
}

void ClasseIntegracao::ObtemCodigoRetorno(int iCodigoRetorno, char *pCodigoRetorno)
{ 
	memset(pCodigoRetorno, 0, 3);

	if(handle > 0)
	{
		FObtemCodigoRetorno ObtemCodigoRetornoPtr = FObtemCodigoRetorno(GetProcAddress(handle, "ObtemCodigoRetorno"));
		if(ObtemCodigoRetornoPtr != NULL)
		{
			ObtemCodigoRetornoPtr(iCodigoRetorno, pCodigoRetorno);
		}
	}
}

void ClasseIntegracao::ObtemLogUltimaTransacao(char *oLogUltimaTransacao)
{ 
	memset(oLogUltimaTransacao, 0, 258);

	if(handle > 0)
	{
		FObtemLogUltimaTransacao ObtemLogUltimaTransacaoPtr = FObtemLogUltimaTransacao(GetProcAddress(handle, "ObtemLogUltimaTransacao"));

		if(ObtemLogUltimaTransacaoPtr != NULL)
		{
			ObtemLogUltimaTransacaoPtr(oLogUltimaTransacao);
		}
	}
}

void ClasseIntegracao::ObtemLogUltimaTransacaoTeleMarketing(char *pNumeroPDV, char *oLogUltimaTransacao)
{ 
	memset(oLogUltimaTransacao, 0, 258);

	if(handle > 0)
	{
		FObtemLogUltimaTransacaoTeleMarketing ObtemLogUltimaTransacaoTeleMarketingPtr = FObtemLogUltimaTransacaoTeleMarketing(
			GetProcAddress(handle, "ObtemLogUltimaTransacaoTeleMarketing"));
	
		if(ObtemLogUltimaTransacaoTeleMarketingPtr != NULL)
		{
			ObtemLogUltimaTransacaoTeleMarketingPtr(pNumeroPDV, oLogUltimaTransacao);
		}
	}
}

void ClasseIntegracao::ObtemLogUltimaTransacaoTeleMarketingMultiLoja(char *cNumeroEmpresa, char *cNumeroLoja, char *pNumeroPDV, char *oLogUltimaTransacao)
{ 
	memset(oLogUltimaTransacao, 0, 258);

	if(handle > 0)
	{
		FObtemLogUltimaTransacaoTeleMarketingMultiLoja ObtemLogUltimaTransacaoTeleMarketingMultiLojaPtr = FObtemLogUltimaTransacaoTeleMarketingMultiLoja(
			GetProcAddress(handle, "ObtemLogUltimaTransacaoTeleMarketingMultiLoja"));

		if(ObtemLogUltimaTransacaoTeleMarketingMultiLojaPtr != NULL)
		{
			ObtemLogUltimaTransacaoTeleMarketingMultiLojaPtr(cNumeroEmpresa, cNumeroLoja, pNumeroPDV, oLogUltimaTransacao);
		}
	}
}

void ClasseIntegracao::ObtemComprovanteTransacao(char *pNumeroControle, char *pComprovante, char *pComprovanteReduzido)
{ 
	memset(pComprovanteReduzido, 0, 320);
	memset(pComprovante, 0, 2048);

	if(handle > 0)
	{
		FObtemComprovanteTransacao ObtemComprovanteTransacaoPtr = FObtemComprovanteTransacao(GetProcAddress(handle, "ObtemComprovanteTransacao"));

		if(ObtemComprovanteTransacaoPtr != NULL)
		{
			ObtemComprovanteTransacaoPtr(pNumeroControle, pComprovante, pComprovanteReduzido);
		}
	}
}

void ClasseIntegracao::DadosUltimaTransacaoDiscada(char *oDadosUltimaTransacaoDiscada)
{ 
	memset(oDadosUltimaTransacaoDiscada, 0, 512);
	if(handle > 0)
	{
		FDadosUltimaTransacaoDiscada DadosUltimaTransacaoDiscadaPtr = FDadosUltimaTransacaoDiscada(GetProcAddress(handle, "DadosUltimaTransacaoDiscada"));

		if(DadosUltimaTransacaoDiscadaPtr != NULL)
		{
			DadosUltimaTransacaoDiscadaPtr(oDadosUltimaTransacaoDiscada);
		}
	}
}

void ClasseIntegracao::DadosUltimaTransacaoCB(char *pLogTitulo)
{ 
	memset(pLogTitulo, 0, 257);

	if(handle > 0)
	{
		FDadosUltimaTransacaoCB DadosUltimaTransacaoCBPtr = FDadosUltimaTransacaoCB(GetProcAddress(handle, "DadosUltimaTransacaoCB"));
		if(DadosUltimaTransacaoCBPtr != NULL)
		{
			DadosUltimaTransacaoCBPtr(pLogTitulo);
		}
	}
}

int ClasseIntegracao::TransacaoCartaoCreditoCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pTipoOperacao,
	char *pNumeroParcelas, char *pValorParcela, char *pValorTaxaServico, char *pPermiteAlteracao, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoCreditoCompleta TransacaoCartaoCreditoCompletaPtr = FTransacaoCartaoCreditoCompleta(GetProcAddress(handle, "TransacaoCartaoCreditoCompleta"));
		if(TransacaoCartaoCreditoCompletaPtr != NULL)
		{
			resultado = TransacaoCartaoCreditoCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pTipoOperacao, pNumeroParcelas, pValorParcela, pValorTaxaServico,
				pPermiteAlteracao, pReservado);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoCartaoDebitoCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pTipoOperacao, char *pNumeroParcelas,
	char *pSequenciaParcela, char *pDataDebito, char *pValorParcela, char *pValorTaxaServico, char *pPermiteAlteracao, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoDebitoCompleta TransacaoCartaoDebitoCompletaPtr = FTransacaoCartaoDebitoCompleta(GetProcAddress(handle, "TransacaoCartaoDebitoCompleta"));
		if(TransacaoCartaoDebitoCompletaPtr != NULL)
		{
			resultado = TransacaoCartaoDebitoCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pTipoOperacao, pNumeroParcelas,
						pSequenciaParcela, pDataDebito, pValorParcela, pValorTaxaServico, pPermiteAlteracao, pReservado);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoCartaoVoucherCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoVoucherCompleta TransacaoCartaoVoucherCompletaPtr = FTransacaoCartaoVoucherCompleta(GetProcAddress(handle, "TransacaoCartaoVoucherCompleta"));
		if(TransacaoCartaoVoucherCompletaPtr != NULL)
		{
			resultado = TransacaoCartaoVoucherCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pReservado);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoChequeCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pQuantidadeCheques, char *pPeriodicidadeCheques,
	char *pDataPrimeiroCheque, char *pCarenciaPrimeiroCheque, char *pTipoDocumento, char *pNumeroDocumento, char *pQuantidadeChequesEx, char *pSequenciaCheque,
	char *pCamaraCompensacao, char *pNumeroBanco, char *pNumeroAgencia, char *pNumeroContaCorrente, char *pNumeroCheque, char *pDataDeposito, char *pValorCheque,
	char *pDataNascimentoCliente, char *pTelefoneCliente, char *pCMC7, char *pPermiteAlteracao, char *pReservado)
{ 
	int resultado = 11;
	char ptrReservado[256];
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoChequeCompleta TransacaoChequeCompletaPtr = FTransacaoChequeCompleta(GetProcAddress(handle, "TransacaoChequeCompleta"));
		if(TransacaoChequeCompletaPtr != NULL)
		{
			resultado = TransacaoChequeCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pQuantidadeCheques, pPeriodicidadeCheques,
						pDataPrimeiroCheque, pCarenciaPrimeiroCheque, pTipoDocumento, pNumeroDocumento, pQuantidadeChequesEx, pSequenciaCheque,
						pCamaraCompensacao, pNumeroBanco, pNumeroAgencia, pNumeroContaCorrente, pNumeroCheque, pDataDeposito, pValorCheque,
						pDataNascimentoCliente, pTelefoneCliente, pCMC7, pPermiteAlteracao, pReservado);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoCartaoPrivateLabelCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pTipoOperacao,
	char *pNumeroParcelas, char *pValorEntrada, char *pValorTaxaServico, char *pPermiteAlteracao, char *pReservado)
{ 
	int resultado = 11;
	char ptrReservado[158];
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoPrivateLabelCompleta TransacaoCartaoPrivateLabelCompletaPtr = FTransacaoCartaoPrivateLabelCompleta(GetProcAddress(
		handle, "TransacaoCartaoPrivateLabelCompleta"));
		if(TransacaoCartaoPrivateLabelCompletaPtr != NULL)
		{
			resultado = TransacaoCartaoPrivateLabelCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pTipoOperacao,
						pNumeroParcelas, pValorEntrada, pValorTaxaServico, pPermiteAlteracao, pReservado);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoSimulacaoPrivateLabel(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoSimulacaoPrivateLabel TransacaoSimulacaoPrivateLabelPtr = FTransacaoSimulacaoPrivateLabel(GetProcAddress(handle, "TransacaoSimulacaoPrivateLabel"));
		if(TransacaoSimulacaoPrivateLabelPtr != NULL)
		{
			resultado = TransacaoSimulacaoPrivateLabelPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoConsultaPrivateLabel(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoConsultaPrivateLabel TransacaoConsultaPrivateLabelPtr = FTransacaoConsultaPrivateLabel(GetProcAddress(handle, "TransacaoConsultaPrivateLabel"));
		if(TransacaoConsultaPrivateLabelPtr != NULL)
		{
			resultado = TransacaoConsultaPrivateLabelPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoPagamentoPrivateLabel(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoPagamentoPrivateLabel TransacaoPagamentoPrivateLabelPtr = FTransacaoPagamentoPrivateLabel(GetProcAddress(handle, "TransacaoPagamentoPrivateLabel"));
		if(TransacaoPagamentoPrivateLabelPtr != NULL)
		{
			resultado = TransacaoPagamentoPrivateLabelPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoDebitoBeneficiario(char *pValorTransacao, char *pTipoBeneficio, char *pNumeroBeneficio, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoDebitoBeneficiario TransacaoDebitoBeneficiarioPtr = FTransacaoDebitoBeneficiario(GetProcAddress(handle, "TransacaoDebitoBeneficiario"));
		if(TransacaoDebitoBeneficiarioPtr != NULL)
		{
			resultado = TransacaoDebitoBeneficiarioPtr(pValorTransacao, pTipoBeneficio, pNumeroBeneficio, pNumeroCupom, pNumeroControle);
		}
	}

	return resultado;
}

void ClasseIntegracao::InfAdicionaisCartaoDebito(char *pDadosParcelas)
{ 
	if(handle > 0)
	{
		FInfAdicionaisCartaoDebito InfAdicionaisCartaoDebitoPtr = FInfAdicionaisCartaoDebito(GetProcAddress(handle, "InfAdicionaisCartaoDebito"));
		if(InfAdicionaisCartaoDebitoPtr != NULL)
		{
			InfAdicionaisCartaoDebitoPtr(pDadosParcelas);
		}
	}
}
void ClasseIntegracao::ObtemInfTransacaoDebitoParcelado(char *pDadosParcelas)
{ 
	if(handle > 0)
	{
		FObtemInfTransacaoDebitoParcelado ObtemInfTransacaoDebitoParceladoPtr = FObtemInfTransacaoDebitoParcelado(GetProcAddress(
			handle, "ObtemInfTransacaoDebitoParcelado"));
		if(ObtemInfTransacaoDebitoParceladoPtr != NULL)
		{
			ObtemInfTransacaoDebitoParceladoPtr(pDadosParcelas);
		}
	}
}

int ClasseIntegracao::ConsultaParametrosCB(char *pParametros)
{ 
	int resultado = 11;
	if(handle > 0)
	{
		FConsultaParametrosCB ConsultaParametrosCBPtr = FConsultaParametrosCB(GetProcAddress(handle, "ConsultaParametrosCB"));
		if(ConsultaParametrosCBPtr != NULL)
		{
			resultado = ConsultaParametrosCBPtr(pParametros);
		}
	}

	return resultado;
}

int ClasseIntegracao::ConsultaPagamentoCB(char *pTipoConta, char *pCodigoBarrasDigitado, char *pCodigoBarrasLido, char *pValorTitulo, char *pValorDesconto,
	char *pValorAcrescimo, char *pDataVencimento, char *pFormaPagamento, char *pTrilhaCartao, char *pTipoSenha, char *pSenha, char *pNSUCartao,
	char *pTipoCMC7, char *pCMC7, char *pNumeroControle, char *pMensagemTEF, char *pImprimeComprovante, char *pParametros, char *pParametros2)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pMensagemTEF, 0, 256);
	memset(pImprimeComprovante, 0, 2048);
	memset(pParametros, 0, 256);
	memset(pParametros2, 0, 256);

	if(handle > 0)
	{
		FConsultaPagamentoCB ConsultaPagamentoCBPtr = FConsultaPagamentoCB(GetProcAddress(handle, "ConsultaPagamentoCB"));
		if(ConsultaPagamentoCBPtr != NULL)
		{
			resultado = ConsultaPagamentoCBPtr(pTipoConta, pCodigoBarrasDigitado, pCodigoBarrasLido, pValorTitulo, pValorDesconto,
						pValorAcrescimo, pDataVencimento, pFormaPagamento, pTrilhaCartao, pTipoSenha, pSenha, pNSUCartao,
						pTipoCMC7, pCMC7, pNumeroControle, pMensagemTEF, pImprimeComprovante, pParametros, pParametros2);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoPagamentoCB(char *pTipoConta, char *pCodigoBarrasDigitado, char *pCodigoBarrasLido, char *pValorTitulo, char *pValorDesconto,
	char *pValorAcrescimo, char *pDataVencimento, char *pFormaPagamento, char *pTrilhaCartao, char *pTipoSenha, char *pSenha, char *pNSUCartao,
	char *pTipoCMC7, char *pCMC7, char *pParametros2, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pParametros2, 0, 256);

	if(handle > 0)
	{
		FTransacaoPagamentoCB TransacaoPagamentoCBPtr = FTransacaoPagamentoCB(GetProcAddress(handle, "TransacaoPagamentoCB"));
		if(TransacaoPagamentoCBPtr != NULL)
		{
			resultado = TransacaoPagamentoCBPtr(pTipoConta, pCodigoBarrasDigitado, pCodigoBarrasLido, pValorTitulo, pValorDesconto,
						pValorAcrescimo, pDataVencimento, pFormaPagamento, pTrilhaCartao, pTipoSenha, pSenha, pNSUCartao,
						pTipoCMC7, pCMC7, pParametros2, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoCancelamentoCB(char *pTipoConta, char *pCodigoBarrasDigitado, char *pCodigoBarrasLido, char *pValorTitulo,
	char *pNSUCartao, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCancelamentoCB TransacaoCancelamentoCBPtr = FTransacaoCancelamentoCB(GetProcAddress(handle, "TransacaoCancelamentoCB"));
		if(TransacaoCancelamentoCBPtr != NULL)
		{
			resultado = TransacaoCancelamentoCBPtr(pTipoConta, pCodigoBarrasDigitado, pCodigoBarrasLido, pValorTitulo,
						pNSUCartao, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::InicializaSessaoCB(char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FInicializaSessaoCB InicializaSessaoCBPtr = FInicializaSessaoCB(GetProcAddress(handle, "InicializaSessaoCB"));

		if(InicializaSessaoCBPtr != NULL)
		{
			resultado = InicializaSessaoCBPtr(pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::FinalizaSessaoCB(char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FFinalizaSessaoCB FinalizaSessaoCBPtr = FFinalizaSessaoCB(GetProcAddress(handle, "FinalizaSessaoCB"));
		if(FinalizaSessaoCBPtr != NULL)
		{
			resultado = FinalizaSessaoCBPtr(pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoResumoRecebimentosCB(char *pTipoRecebimento, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoResumoRecebimentosCB TransacaoResumoRecebimentosCBPtr = FTransacaoResumoRecebimentosCB(GetProcAddress(handle, "TransacaoResumoRecebimentosCB"));
		if(TransacaoResumoRecebimentosCBPtr != NULL)
		{
			resultado = TransacaoResumoRecebimentosCBPtr(pTipoRecebimento, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::UltimaMensagemTEF(char *pMensagem)
{ 
	int resultado = 11;
	memset(pMensagem, 0, 21);

	if(handle > 0)
	{
		FUltimaMensagemTEF UltimaMensagemTEFPtr = FUltimaMensagemTEF(GetProcAddress(handle, "UltimaMensagemTEF"));
		if(UltimaMensagemTEFPtr != NULL)
		{
			resultado = UltimaMensagemTEFPtr(pMensagem);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoReimpressaoCupom()
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FTransacaoReimpressaoCupom TransacaoReimpressaoCupomPtr = FTransacaoReimpressaoCupom(GetProcAddress(handle, "TransacaoReimpressaoCupom"));
		if(TransacaoReimpressaoCupomPtr != NULL)
		{
			resultado = TransacaoReimpressaoCupomPtr();
		}
	}
	return resultado;
}

void ClasseIntegracao::ConfiguraDPOS()
{ 
	if(handle > 0)
	{
		FConfiguraDPOS ConfiguraDPOSPtr = FConfiguraDPOS(GetProcAddress(handle, "ConfiguraDPOS"));
		if(ConfiguraDPOSPtr != NULL)
		{
			ConfiguraDPOSPtr();
		}
	}
}

int ClasseIntegracao::InicializaDPOS()
{ 
	int resultado = 11;
	if(handle > 0)
	{
		FInicializaDPOS InicializaDPOSPtr = FInicializaDPOS(GetProcAddress(handle, "InicializaDPOS"));
		if(InicializaDPOSPtr != NULL)
		{
			resultado = InicializaDPOSPtr();
		}
	}
	return resultado;
}

int ClasseIntegracao::FinalizaDPOS()
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FFinalizaDPOS FinalizaDPOSPtr = FFinalizaDPOS(GetProcAddress(handle, "FinalizaDPOS"));
		if(FinalizaDPOSPtr != NULL)
		{
			resultado = FinalizaDPOSPtr();
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoFechamento(char *pDataMovimento, char *pQuantidadeVendas, char *pValorTotalVendas, char *pQuantidadeVendasCanceladas,
	char *pValorTotalVendasCanceladas, char *pReservado, char *pNumeroControle, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoFechamento TransacaoFechamentoPtr = FTransacaoFechamento(GetProcAddress(handle, "TransacaoFechamento"));
		if(TransacaoFechamentoPtr != NULL)
		{
			resultado = TransacaoFechamentoPtr(pDataMovimento, pQuantidadeVendas, pValorTotalVendas, pQuantidadeVendasCanceladas,
						pValorTotalVendasCanceladas, pReservado, pNumeroControle, pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoFechamentoPOS(char *pTipoRelatorio, char *pParametrosRelatorio, char *pReservado, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoFechamentoPOS TransacaoFechamentoPOSPtr = FTransacaoFechamentoPOS(GetProcAddress(handle, "TransacaoFechamentoPOS"));

		if(TransacaoFechamentoPOSPtr != NULL)
		{
			resultado = TransacaoFechamentoPOSPtr(pTipoRelatorio, pParametrosRelatorio, pReservado, pNumeroCupom, pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoAtivacaoPOS(char *pCNPJ, char *pNumeroSerie, char *pCodAtivacao, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoAtivacaoPOS TransacaoAtivacaoPOSPtr = FTransacaoAtivacaoPOS(GetProcAddress(handle, "TransacaoAtivacaoPOS"));

		if(TransacaoAtivacaoPOSPtr != NULL)
		{
			resultado = TransacaoAtivacaoPOSPtr(pCNPJ, pNumeroSerie, pCodAtivacao, pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoInicializacaoAreaPOS(char *pCNPJ, char *pNumeroSerie, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoInicializacaoAreaPOS TransacaoInicializacaoAreaPOSPtr = FTransacaoInicializacaoAreaPOS(GetProcAddress(handle, "TransacaoInicializacaoAreaPOS"));

		if(TransacaoInicializacaoAreaPOSPtr != NULL)
		{
			resultado = TransacaoInicializacaoAreaPOSPtr(pCNPJ, pNumeroSerie, pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoLojaPOS(char *pCNPJ, char *pNumeroSerie, char *pCodigoEmpresa, char *pCodigoLoja, char *pCodigoPDV, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoLojaPOS TransacaoLojaPOSPtr = FTransacaoLojaPOS(GetProcAddress(handle, "TransacaoLojaPOS"));

		if(TransacaoLojaPOSPtr != NULL)
		{
			resultado = TransacaoLojaPOSPtr(pCNPJ, pNumeroSerie, pCodigoEmpresa, pCodigoLoja, pCodigoPDV, pNumeroControle);
		}
	}

	return resultado;
}
void ClasseIntegracao::ObtemUltimoErro(char *pErro)
{ 
	memset(pErro, 0, 256);

	if(handle > 0)
	{
		FObtemUltimoErro ObtemUltimoErroPtr = FObtemUltimoErro(GetProcAddress(handle, "ObtemUltimoErro"));

		if(ObtemUltimoErroPtr != NULL)
		{
			ObtemUltimoErroPtr(pErro);
		}
	}
}

void ClasseIntegracao::DadosUltimaTransacaoNaoAprovada(char *pDadosTransacaoNaoAprovada)
{ 
	memset(pDadosTransacaoNaoAprovada, 0, 512);

	if(handle > 0)
	{
		FDadosUltimaTransacaoNaoAprovada FDadosUltimaTransacaoNaoAprovadaPtr = FDadosUltimaTransacaoNaoAprovada(GetProcAddress(handle, "DadosUltimaTransacaoNaoAprovada"));

		if(FDadosUltimaTransacaoNaoAprovadaPtr != NULL)
		{
			FDadosUltimaTransacaoNaoAprovadaPtr(pDadosTransacaoNaoAprovada);
		}
	}
}

int ClasseIntegracao::TransacaoColeta(int nTipoCartao, char *pValorTransacao, char *pTrilha1, char *pTrilha2, char *pTrilha3, char *pParametros)
{ 
	int resultado = 11;
	memset(pTrilha1, 0, 256);
	memset(pTrilha2, 0, 256);
	memset(pTrilha3, 0, 256);

	if(handle > 0)
	{
		FTransacaoColeta TransacaoColetaPtr = FTransacaoColeta(GetProcAddress(handle, "TransacaoColeta"));

		if(TransacaoColetaPtr != NULL)
		{
			resultado = TransacaoColetaPtr(nTipoCartao, pValorTransacao, pTrilha1, pTrilha2, pTrilha3, pParametros);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoColetaCartao(int nTipoCartao, char *pTrilha1, char *pTrilha2, char *pTrilha3)
{ 
	int resultado = 11;
	memset(pTrilha1, 0, 256);
	memset(pTrilha2, 0, 256);
	memset(pTrilha3, 0, 256);

	if(handle > 0)
	{
		FTransacaoColetaCartao TransacaoColetaCartaoPtr = FTransacaoColetaCartao(GetProcAddress(handle, "TransacaoColetaCartao"));

		if(TransacaoColetaCartaoPtr != NULL)
		{
			resultado = TransacaoColetaCartaoPtr(nTipoCartao, pTrilha1, pTrilha2, pTrilha3);
		}
	}
	return resultado;
}
int ClasseIntegracao::TransacaoColetaSenha(char *pValor, char *pSenha)
{ 
	int resultado = 11;
	memset(pSenha, 0, 128);

	if(handle > 0)
	{
		FTransacaoColetaSenha TransacaoColetaSenhaPtr = FTransacaoColetaSenha(GetProcAddress(handle, "TransacaoColetaSenha"));

		if(TransacaoColetaSenhaPtr != NULL)
		{
			resultado = TransacaoColetaSenhaPtr(pValor, pSenha);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoColetaSenhaCartao(int nTipoCartao, char *pValor, char *pTrilha2, char *pReservado, char *pSenha)
{ 
	int resultado = 11;
	memset(pTrilha2, 0, 256);
	memset(pReservado, 0, 256);
	memset(pSenha, 0, 256);

	if(handle > 0)
	{
		FTransacaoColetaSenhaCartao TransacaoColetaSenhaCartaoPtr = FTransacaoColetaSenhaCartao(GetProcAddress(handle, "TransacaoColetaSenhaCartao"));

		if(TransacaoColetaSenhaCartaoPtr != NULL)
		{
			resultado = TransacaoColetaSenhaCartaoPtr(nTipoCartao, pValor, pTrilha2, pReservado, pSenha);
		}
	}

	return resultado;
}

int ClasseIntegracao::ColetaPlanoPagamento(char *pDescricaoFormaPagamento, char *pValorTransacao, char *pNumeroCupom, char *pTipoFormaPagamento, char *pNumeroControle,
	char *pNumeroParcelas, char *pValorAcrescimo, char *pValorEntrada, char *pValorTotal, char *pCodigoPlano, char *pPlano, char *pParcelas)
{ 
	int resultado = 11;
    memset(pNumeroParcelas, 0, 3);
	memset(pValorAcrescimo, 0, 13);
	memset(pValorEntrada, 0, 13);
	memset(pValorTotal, 0, 13);
	memset(pCodigoPlano, 0, 13);
	memset(pPlano, 0, 256);
	memset(pParcelas, 0, 64);
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FColetaPlanoPagamento ColetaPlanoPagamentoPtr = FColetaPlanoPagamento(GetProcAddress(handle, "ColetaPlanoPagamento"));

		if(ColetaPlanoPagamentoPtr != NULL)
		{
			resultado = ColetaPlanoPagamentoPtr(pDescricaoFormaPagamento, pValorTransacao, pNumeroCupom, pTipoFormaPagamento, pNumeroControle,
						pNumeroParcelas, pValorAcrescimo, pValorEntrada, pValorTotal, pCodigoPlano, pPlano, pParcelas);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoAdministrativaTEFDiscado(char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoAdministrativaTEFDiscado TransacaoAdministrativaTEFDiscadoPtr = FTransacaoAdministrativaTEFDiscado(GetProcAddress(handle, "TransacaoAdministrativaTEFDiscado"));

		if(TransacaoAdministrativaTEFDiscadoPtr != NULL)
		{
			resultado = TransacaoAdministrativaTEFDiscadoPtr(pNumeroControle);
		}
	}

	return resultado;
}
void ClasseIntegracao::SelecionaTEF()
{ 
	if(handle > 0)
	{
		FSelecionaTEF SelecionaTEFPtr = FSelecionaTEF(GetProcAddress(handle, "SelecionaTEF"));

		if(SelecionaTEFPtr != NULL)
		{
			SelecionaTEFPtr();
		}
	}
}
void ClasseIntegracao::ExportaPlanos()
{ 
	if(handle > 0)
	{
		FExportaPlanos ExportaPlanosPtr = FExportaPlanos(GetProcAddress(handle, "ExportaPlanos"));

		if(ExportaPlanosPtr != NULL)
		{
			ExportaPlanosPtr();
		}
	}
}

int ClasseIntegracao::TransacaoQuantidade(char *pValorTransacao, char *pValorTransacaoMaximo, char *pNumeroCupom)
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FTransacaoQuantidade TransacaoQuantidadePtr = FTransacaoQuantidade(GetProcAddress(handle, "TransacaoQuantidade"));
		if(TransacaoQuantidadePtr != NULL)
		{
			resultado = TransacaoQuantidadePtr(pValorTransacao, pValorTransacaoMaximo, pNumeroCupom);
		}
	}
	return resultado;
}
int ClasseIntegracao::TransacaoValor(char *pValorTransacao, char *pValorTransacaoMaximo, char *pNumeroCupom)
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FTransacaoValor TransacaoValorPtr = FTransacaoValor(GetProcAddress(handle, "TransacaoValor"));

		if(TransacaoValorPtr != NULL)
		{
			resultado = TransacaoValorPtr(pValorTransacao, pValorTransacaoMaximo, pNumeroCupom);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoCartaoCreditoConfirmada(char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pValorTransacao, char *pNumeroCupom,
	char *pNumeroControle, char *pNumeroCartao, char *pDataVencimento, char *pCVV2, char *pTipoOperacao, char *pNumeroParcelas, char *pValorTaxaServico,
	char *pMensagemTEF, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoCreditoConfirmada TransacaoCartaoCreditoConfirmadaPtr = FTransacaoCartaoCreditoConfirmada(GetProcAddress(handle, "TransacaoCartaoCreditoConfirmada"));

		if(TransacaoCartaoCreditoConfirmadaPtr != NULL)
		{
			resultado = TransacaoCartaoCreditoConfirmadaPtr(pMultiLoja, pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroCupom,
						pNumeroControle, pNumeroCartao, pDataVencimento, pCVV2, pTipoOperacao, pNumeroParcelas, pValorTaxaServico,
						pMensagemTEF, pReservado);
		}
	}

	return resultado;
}


int ClasseIntegracao::TransacaoCancelamentoConfirmada(char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pValorTransacao, char *pNumeroControle,
	char *pNumeroCartao, char *pMensagemTEF, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCancelamentoConfirmada TransacaoCancelamentoConfirmadaPtr = FTransacaoCancelamentoConfirmada(GetProcAddress(handle, "TransacaoCancelamentoConfirmada"));

		if(TransacaoCancelamentoConfirmadaPtr != NULL)
		{
			resultado = TransacaoCancelamentoConfirmadaPtr(pMultiLoja, pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroControle,
						pNumeroCartao, pMensagemTEF, pReservado);
		}
	}
	return resultado;
}

int ClasseIntegracao::PreAutorizacaoCreditoConfirmada(char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle,
	char *pNumeroCartao, char *pDataVencimento, char *pCVV2, char *pValorTaxaServico, char *pNumeroAutorizacao, char *pMensagemTEF, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FPreAutorizacaoCreditoConfirmada PreAutorizacaoCreditoConfirmadaPtr = FPreAutorizacaoCreditoConfirmada(GetProcAddress(handle, "PreAutorizacaoCreditoConfirmada"));

		if(PreAutorizacaoCreditoConfirmadaPtr != NULL)
		{
			resultado = PreAutorizacaoCreditoConfirmadaPtr(pMultiLoja, pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle,
						pNumeroCartao, pDataVencimento, pCVV2, pValorTaxaServico, pNumeroAutorizacao, pMensagemTEF, pReservado);
		}
	}
	return resultado;

}

int ClasseIntegracao::ConfPreAutorizacaoCreditoConfirmada(char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle,
	char *pDataPreAutor, char *pNumeroCartao, char *pDataVencimento, char *pCVV2, char *pTipoOperacao, char *pNumeroParcelas, char *pMensagemTEF, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pMensagemTEF, 0, 64);

	if(handle > 0)
	{
		FConfPreAutorizacaoCreditoConfirmada ConfPreAutorizacaoCreditoConfirmadaPtr = FConfPreAutorizacaoCreditoConfirmada(GetProcAddress(handle, "ConfPreAutorizacaoCreditoConfirmada"));

		if(ConfPreAutorizacaoCreditoConfirmadaPtr != NULL)
		{
			resultado = ConfPreAutorizacaoCreditoConfirmadaPtr(pMultiLoja, pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle,
						pDataPreAutor, pNumeroCartao, pDataVencimento, pCVV2, pTipoOperacao, pNumeroParcelas, pMensagemTEF, pReservado);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoManualPOS (char *pValorTransacao)
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FTransacaoManualPOS TransacaoManualPOSPtr = FTransacaoManualPOS(GetProcAddress(handle, "TransacaoManualPOS"));

		if(TransacaoManualPOSPtr != NULL)
		{
			resultado = TransacaoManualPOSPtr(pValorTransacao);
		}
	}

	return resultado;	
}

int ClasseIntegracao::TransacaoManualPOSCompleta (char *pValorTransacao, char *pCodigoEstabelecimento, char *pData, char *pHora, char *pNumeroAutorizadora,
	char *pNumeroCartao, char *pTipoOperacao, char *pNumeroParcelas, char *pDataPreDatado, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoManualPOSCompleta TransacaoManualPOSCompletaPtr = FTransacaoManualPOSCompleta(GetProcAddress(handle, "TransacaoManualPOSCompleta"));

		if(TransacaoManualPOSCompletaPtr != NULL)
		{
			resultado = TransacaoManualPOSCompletaPtr(pValorTransacao, pCodigoEstabelecimento, pData, pHora, pNumeroAutorizadora,
						pNumeroCartao, pTipoOperacao, pNumeroParcelas, pDataPreDatado, pNumeroControle);
		}
	}

	return resultado;	
}

int ClasseIntegracao::TransacaoCartaoFidelidade(char *pValorTransacao, char *pNumeroCupom, char *pCompraPontos, char *pQuantidadeItensTaxaVariavel,
	char *pItensTaxaVariavel, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoFidelidade TransacaoCartaoFidelidadePtr = FTransacaoCartaoFidelidade(GetProcAddress(handle, "TransacaoCartaoFidelidade"));

		if(TransacaoCartaoFidelidadePtr != NULL)
		{
			resultado = TransacaoCartaoFidelidadePtr(pValorTransacao, pNumeroCupom, pCompraPontos, pQuantidadeItensTaxaVariavel,
						pItensTaxaVariavel, pNumeroControle);
		}
	}

	return resultado;	
}

int ClasseIntegracao::TransacaoDebitoFidelidade(char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoDebitoFidelidade TransacaoDebitoFidelidadePtr = FTransacaoDebitoFidelidade(GetProcAddress(handle, "TransacaoDebitoFidelidade"));

		if(TransacaoDebitoFidelidadePtr != NULL)
		{
			resultado = TransacaoDebitoFidelidadePtr(pNumeroCupom, pNumeroControle);
		}
	}

	return resultado;	
}

int ClasseIntegracao::ConfirmaCartaoFidelidade(char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FConfirmaCartaoFidelidade ConfirmaCartaoFidelidadePtr = FConfirmaCartaoFidelidade(GetProcAddress(handle, "ConfirmaCartaoFidelidade"));

		if(ConfirmaCartaoFidelidadePtr != NULL)
		{
			resultado = ConfirmaCartaoFidelidadePtr(pNumeroControle);
		}
	}
	return resultado;	
}

int ClasseIntegracao::ExtratoCartaoAutorizadorDirecao(char *pNumeroCartao, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FExtratoCartaoAutorizadorDirecao ExtratoCartaoAutorizadorDirecaoPtr = FExtratoCartaoAutorizadorDirecao(GetProcAddress(handle, "ExtratoCartaoAutorizadorDirecao"));

		if(ExtratoCartaoAutorizadorDirecaoPtr != NULL)
		{
			resultado = ExtratoCartaoAutorizadorDirecaoPtr(pNumeroControle, pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::RecebimentoAutorizadorDirecao(char *pValorTransacao, char *pNumeroCartao, char *pNumeroControle)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FRecebimentoAutorizadorDirecao RecebimentoAutorizadorDirecaoPtr = FRecebimentoAutorizadorDirecao(GetProcAddress(handle, "RecebimentoAutorizadorDirecao"));

		if(RecebimentoAutorizadorDirecaoPtr != NULL)
		{
			resultado = RecebimentoAutorizadorDirecaoPtr(pValorTransacao, pNumeroCartao, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::EstornoRecebimentoAutorizadorDirecao(char *pValorTransacao, char *pNumeroCartao, char *pNumeroControle)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FEstornoRecebimentoAutorizadorDirecao EstornoRecebimentoAutorizadorDirecaoPtr = FEstornoRecebimentoAutorizadorDirecao(GetProcAddress(handle, "EstornoRecebimentoAutorizadorDirecao"));

		if(EstornoRecebimentoAutorizadorDirecaoPtr != NULL)
		{
			resultado = EstornoRecebimentoAutorizadorDirecaoPtr(pValorTransacao, pNumeroCartao, pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::RecebimentoCarneAutorizadorDirecao(char *pValorTransacao, char *pNumeroCartao, char *pDataVencimento, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FRecebimentoCarneAutorizadorDirecao RecebimentoCarneAutorizadorDirecaoPtr = FRecebimentoCarneAutorizadorDirecao(
			GetProcAddress(handle, "RecebimentoCarneAutorizadorDirecao"));

		if(RecebimentoCarneAutorizadorDirecaoPtr != NULL)
		{
			resultado = RecebimentoCarneAutorizadorDirecaoPtr(pValorTransacao, pNumeroCartao, pDataVencimento, pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoPagamentoConvenio(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoPagamentoConvenio TransacaoPagamentoConvenioPtr = FTransacaoPagamentoConvenio(GetProcAddress(handle, "TransacaoPagamentoConvenio"));

		if(TransacaoPagamentoConvenioPtr != NULL)
		{
			resultado = TransacaoPagamentoConvenioPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}

	return resultado;
}


int ClasseIntegracao::ConfirmaConvenio(char *pNumeroControle)
{ 
  	int resultado = 11;

	if(handle > 0)
	{
		 FConfirmaConvenio ConfirmaConvenioPtr = FConfirmaConvenio(GetProcAddress(handle, "ConfirmaConvenio"));

		if(ConfirmaConvenioPtr != NULL)
		{
			resultado = ConfirmaConvenioPtr(pNumeroControle);
		}
	}

	return resultado;
}
int ClasseIntegracao::TransacaoSaqueRedecard(char *pValorTransacao, char *pNumeroCupomFiscal, char *pNumeroControle)
{ 
  	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoSaqueRedecard TransacaoSaqueRedecardPtr = FTransacaoSaqueRedecard(GetProcAddress(handle, "TransacaoSaqueRedecard"));

		if(TransacaoSaqueRedecardPtr != NULL)
		{
			resultado = TransacaoSaqueRedecardPtr(pValorTransacao, pNumeroCupomFiscal, pNumeroControle);
		}
	}

	return resultado;
}


int ClasseIntegracao::TransacaoSaque(char *pValorTransacao, char *pNumeroCupomFiscal, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoSaque TransacaoSaquePtr = FTransacaoSaque(GetProcAddress(handle, "TransacaoSaque"));

		if(TransacaoSaquePtr != NULL)
		{
			resultado = TransacaoSaquePtr(pValorTransacao, pNumeroCupomFiscal, pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoCDC1MIN(char *pValorTransacao, char *pNumeroCupomFiscal, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCDC1MIN TransacaoCDC1MINPtr = FTransacaoCDC1MIN(GetProcAddress(handle, "TransacaoCDC1MIN"));

		if(TransacaoCDC1MINPtr != NULL)
		{
			resultado = TransacaoCDC1MINPtr(pValorTransacao, pNumeroCupomFiscal, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoSIMparcelado(char *pValorTransacao, char *pNumeroCupomFiscal, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoSIMparcelado TransacaoSIMparceladoPtr = FTransacaoSIMparcelado(GetProcAddress(handle, "TransacaoSIMparcelado"));

		if(TransacaoSIMparceladoPtr != NULL)
		{
			resultado = TransacaoSIMparceladoPtr(pValorTransacao, pNumeroCupomFiscal, pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoCartaoCreditoIATA(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoCreditoIATA TransacaoCartaoCreditoIATAPtr = FTransacaoCartaoCreditoIATA(GetProcAddress(handle, "TransacaoCartaoCreditoIATA"));

		if(TransacaoCartaoCreditoIATAPtr != NULL)
		{
			resultado = TransacaoCartaoCreditoIATAPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoCartaoCreditoIATAConfirmada(char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pValorTransacao, char *pNumeroCupom,
	char *pNumeroControle, char *pNumeroCartao, char *pDataVencimento, char *pCVV2, char *pTipoOperacao, char *pNumeroParcelas, char *pValorTaxaServico,
	char *pValorEntrada, char *pMensagemTEF, char *pReservado)
{ 
  	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoCreditoIATAConfirmada TransacaoCartaoCreditoIATAConfirmadaPtr = FTransacaoCartaoCreditoIATAConfirmada(
			GetProcAddress(handle, "TransacaoCartaoCreditoIATAConfirmada"));

		if(TransacaoCartaoCreditoIATAConfirmadaPtr != NULL)
		{
			resultado = TransacaoCartaoCreditoIATAConfirmadaPtr(pMultiLoja, pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroCupom,
						pNumeroControle, pNumeroCartao, pDataVencimento, pCVV2, pTipoOperacao, pNumeroParcelas, pValorTaxaServico,
						pValorEntrada, pMensagemTEF, pReservado);
		}
	}
	return resultado;
}
int ClasseIntegracao::TransacaoCartaoPrivateLabel(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoPrivateLabel TransacaoCartaoPrivateLabelPtr = FTransacaoCartaoPrivateLabel(GetProcAddress(handle, "TransacaoCartaoPrivateLabel"));

		if(TransacaoCartaoPrivateLabelPtr != NULL)
		{
			resultado = TransacaoCartaoPrivateLabelPtr(pValorTransacao, pNumeroCupom , pNumeroControle);
		}
	}

	return resultado;
}

void ClasseIntegracao::BeepErro()
{ 
	if(handle > 0)
	{
		FBeepErro BeepErroPtr = FBeepErro(GetProcAddress(handle, "BeepErro"));

		if(BeepErroPtr != NULL)
		{
			BeepErroPtr();
		}
	}
}

int ClasseIntegracao::TransacaoConsultaSaldo(char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoConsultaSaldo TransacaoConsultaSaldoPtr = FTransacaoConsultaSaldo(GetProcAddress(handle, "TransacaoConsultaSaldo"));

		if(TransacaoConsultaSaldoPtr != NULL)
		{
			resultado = TransacaoConsultaSaldoPtr(pNumeroCupom , pNumeroControle);
		}
	}

	return resultado;
}


int ClasseIntegracao::TransacaoConsultaSaldoCelular(char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoConsultaSaldoCelular TransacaoConsultaSaldoCelularPtr = FTransacaoConsultaSaldoCelular(GetProcAddress(handle, "TransacaoConsultaSaldoCelular"));

		if(TransacaoConsultaSaldoCelularPtr != NULL)
		{
			resultado = TransacaoConsultaSaldoCelularPtr(pNumeroCupom , pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoConsultaSaldoCompleta(char *pNumeroCupom, char *pNumeroControle, char *pTipoCartao, char *pPermiteAlteracao, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		
		FTransacaoConsultaSaldoCompleta TransacaoConsultaSaldoCompletaPtr = FTransacaoConsultaSaldoCompleta(GetProcAddress(handle, "TransacaoConsultaSaldoCompleta"));

		if(TransacaoConsultaSaldoCompletaPtr != NULL)
		{
			resultado = TransacaoConsultaSaldoCompletaPtr(pNumeroCupom, pNumeroControle, pTipoCartao, pPermiteAlteracao, pReservado);
		}
	}

	return resultado;
}

int ClasseIntegracao::ColetaCartaoDebito(char *pValorTransacao, char *pNumeroCupom, char *pParametrosTEF, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pMensagemOperador, 0, 256);

	if(handle > 0)
	{
		
		FColetaCartaoDebito ColetaCartaoDebitoPtr = FColetaCartaoDebito(GetProcAddress(handle, "ColetaCartaoDebito"));
		if(ColetaCartaoDebitoPtr != NULL)
		{
			resultado = ColetaCartaoDebitoPtr(pValorTransacao, pNumeroCupom, pParametrosTEF, pMensagemOperador);
		}
	}

	return resultado;
}

int ClasseIntegracao::ConsisteDadosCartaoDebito(char *pUltimosDigitos, char *pCodigoSeguranca, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		
		FConsisteDadosCartaoDebito ConsisteDadosCartaoDebitoPtr = FConsisteDadosCartaoDebito(GetProcAddress(handle, "ConsisteDadosCartaoDebito"));
		if(ConsisteDadosCartaoDebitoPtr != NULL)
		{
			resultado = ConsisteDadosCartaoDebitoPtr(pUltimosDigitos, pCodigoSeguranca,pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::ColetaSenhaCartaoDebito(char *pNumeroControle, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FColetaSenhaCartaoDebito ColetaSenhaCartaoDebitoPtr = FColetaSenhaCartaoDebito(GetProcAddress(handle, "ColetaSenhaCartaoDebito"));
		
		if(ColetaSenhaCartaoDebitoPtr != NULL)
		{
			resultado = ColetaSenhaCartaoDebitoPtr(pNumeroControle, pMensagemOperador);
		}
	}

	return resultado;
}

int ClasseIntegracao::ConsultaParametrosPBM(char *pNumeroCupom, char *pQuantidadeRedes, char *pDadosRedes, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FConsultaParametrosPBM ConsultaParametrosPBMPtr = FConsultaParametrosPBM(GetProcAddress(handle, "ConsultaParametrosPBM"));

		if(ConsultaParametrosPBMPtr != NULL)
		{
			resultado = ConsultaParametrosPBMPtr(pNumeroCupom, pQuantidadeRedes, pDadosRedes, pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::ConsultaProdutosPBM(char *pNumeroCupom, char *pRedePBM, char *pTrilha1, char *pTrilha2, char *pDigitado, char *pAutorizacao,
	char *pDadosCRM, char *pTipoVenda, char *pValorTotalMedicamentos, char *pValorVista, char *pValorCartao, char *pCodigoCredenciado,
	char *pQuantidadeMedicamentos, char *pMedicamentos, char *pReservado, char *pNumeroControle, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pTipoVenda, 0, 3);
	memset(pValorTotalMedicamentos, 0, 13);
	memset(pValorVista, 0, 13);
	memset(pValorCartao, 0, 13);
	memset(pCodigoCredenciado, 0, 15);
	memset(pQuantidadeMedicamentos, 0, 3);
	memset(pMedicamentos, 0, 4261);
	memset(pReservado, 0, 128);
	memset(pNumeroControle, 0, 6);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FConsultaProdutosPBM ConsultaProdutosPBMPtr = FConsultaProdutosPBM(GetProcAddress(handle, "ConsultaProdutosPBM"));

		if(ConsultaProdutosPBMPtr != NULL)
		{
			resultado = ConsultaProdutosPBMPtr(pNumeroCupom, pRedePBM, pTrilha1, pTrilha2, pDigitado, pAutorizacao,
						pDadosCRM, pTipoVenda, pValorTotalMedicamentos, pValorVista, pValorCartao, pCodigoCredenciado,
						pQuantidadeMedicamentos, pMedicamentos, pReservado, pNumeroControle, pMensagemOperador);
		}
	}

	return resultado;
}


int ClasseIntegracao::TransacaoVendaPBM(char *pValorTotalMedicamentos, char *pNumeroCupom, char *pRedePBM, char *pTrilha1, char *pTrilha2,
	char *pDigitado, char *pAutorizacao, char *pNSUConsulta, char *pDadosCRM, char *pTipoVenda, char *pValorVista, char *pValorCartao,
	char *pCodigoCredenciado, char *pRegraNegocio, char *pQuantidadeMedicamentos, char *pMedicamentos, char *pReservado, char *pNumeroControle,
	char *pNumeroControleRede, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pTipoVenda, 0, 3);
	memset(pValorTotalMedicamentos, 0, 13);
	memset(pValorVista, 0, 13);
	memset(pValorCartao, 0, 13);
	memset(pCodigoCredenciado, 0, 15);
	memset(pQuantidadeMedicamentos, 0, 3);
	memset(pMedicamentos, 0, 4261);
	memset(pReservado, 0, 128);
	memset(pNumeroControle, 0, 6);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FTransacaoVendaPBM TransacaoVendaPBMPtr = FTransacaoVendaPBM(GetProcAddress(handle, "TransacaoVendaPBM"));
		if(TransacaoVendaPBMPtr != NULL)
		{
			resultado = TransacaoVendaPBMPtr(pValorTotalMedicamentos, pNumeroCupom, pRedePBM, pTrilha1, pTrilha2,
						pDigitado, pAutorizacao, pNSUConsulta, pDadosCRM, pTipoVenda, pValorVista, pValorCartao,
						pCodigoCredenciado, pRegraNegocio, pQuantidadeMedicamentos, pMedicamentos, pReservado, pNumeroControle,
						pNumeroControleRede, pMensagemOperador);
		}
	}

	return resultado;
}

int ClasseIntegracao::ConfirmaVendaPBM(char *pNumeroControle)
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FConfirmaVendaPBM ConfirmaVendaPBMPtr = FConfirmaVendaPBM(GetProcAddress(handle, "ConfirmaVendaPBM"));

		if(ConfirmaVendaPBMPtr != NULL)
		{
			resultado = ConfirmaVendaPBMPtr(pNumeroControle);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoReimpressaoVendaPBM()
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FTransacaoReimpressaoVendaPBM TransacaoReimpressaoVendaPBMPtr = FTransacaoReimpressaoVendaPBM(GetProcAddress(handle, "TransacaoReimpressaoVendaPBM"));

		if(TransacaoReimpressaoVendaPBMPtr != NULL)
		{
			resultado = TransacaoReimpressaoVendaPBMPtr();
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoCancelamentoVendaPBM(char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCancelamentoVendaPBM TransacaoCancelamentoVendaPBMPtr = FTransacaoCancelamentoVendaPBM(GetProcAddress(handle, "TransacaoCancelamentoVendaPBM"));
		if(TransacaoCancelamentoVendaPBMPtr != NULL)
		{
			resultado = TransacaoCancelamentoVendaPBMPtr(pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoCancelamentoPreAutorizacaoPBM(char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCancelamentoPreAutorizacaoPBM TransacaoCancelamentoPreAutorizacaoPBMPtr = FTransacaoCancelamentoPreAutorizacaoPBM(GetProcAddress(
			handle, "TransacaoCancelamentoPreAutorizacaoPBM"));
		if(TransacaoCancelamentoPreAutorizacaoPBMPtr != NULL)
		{
			resultado = TransacaoCancelamentoPreAutorizacaoPBMPtr(pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoElegibilidadePBM(char *pNumeroCupom, char *pRedePBM, char *pMatricula, char *pDadosElegibilidade, char *pNumeroControle,
	char *pNumeroControleRede, char *pNomeCliente, char *pNomeMedico, char *pInformaDependente, char *pListaDependentes, char *pReservado, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 13);
	memset(pNomeCliente, 0, 41);
	memset(pNomeMedico, 0, 41);
	memset(pInformaDependente, 0, 3);
	memset(pListaDependentes, 0, 505);
	memset(pReservado, 0, 128);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FTransacaoElegibilidadePBM TransacaoElegibilidadePBMPtr = FTransacaoElegibilidadePBM(GetProcAddress(handle, "TransacaoElegibilidadePBM"));
	
		if(TransacaoElegibilidadePBMPtr != NULL)
		{
			resultado = TransacaoElegibilidadePBMPtr(pNumeroCupom, pRedePBM, pMatricula, pDadosElegibilidade, pNumeroControle,
						pNumeroControleRede, pNomeCliente, pNomeMedico, pInformaDependente, pListaDependentes, pReservado, pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoPreAutorizacaoPBM(char *pNumeroCupom, char *pRedePBM, char *pAutorizacaoElegibilidade, char *pDadosFarmaceutico,
	char *pQuantidadeMedicamentos, char *pMedicamentos, char *pNumeroControle, char *pNumeroControleRede, char *pReservado, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pMedicamentos, 0, 4261);
	memset(pNumeroControleRede, 0, 13);
	memset(pQuantidadeMedicamentos, 0, 3);
	memset(pReservado, 0, 128);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FTransacaoPreAutorizacaoPBM TransacaoPreAutorizacaoPBMPtr = FTransacaoPreAutorizacaoPBM(GetProcAddress(handle, "TransacaoPreAutorizacaoPBM"));
	
		if(TransacaoPreAutorizacaoPBMPtr != NULL)
		{
			resultado = TransacaoPreAutorizacaoPBMPtr(pNumeroCupom, pRedePBM, pAutorizacaoElegibilidade, pDadosFarmaceutico,
						pQuantidadeMedicamentos, pMedicamentos, pNumeroControle, pNumeroControleRede, pReservado, pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pMatricula,
	char *pReservado, char *pNumeroControle, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pReservado, 0, 128);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FTransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketingPtr = FTransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing(
			GetProcAddress(handle, "TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing"));

		if(TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketingPtr != NULL)
		{
			resultado = TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pMatricula,
					pReservado, pNumeroControle, pMensagemOperador);
		}
	}
	return resultado;
}


int ClasseIntegracao::TransacaoElegibilidadePBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pNumeroCupom,
	char *pRedePBM, char *pMatricula, char *pDadosElegibilidade, char *pNumeroControle, char *pNumeroControleRede, char *pNomeCliente, char *pNomeMedico,
	char *pInformaDependente, char *pListaDependentes, char *pReservado, char *pMensagemOperador)
{ 
 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pNumeroControleRede, 0, 13);
	memset(pNomeCliente, 0, 41);
	memset(pNomeMedico, 0, 41);
	memset(pReservado, 0, 128);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FTransacaoElegibilidadePBM_TeleMarketing TransacaoElegibilidadePBM_TeleMarketingPtr = FTransacaoElegibilidadePBM_TeleMarketing(
			GetProcAddress(handle, "TransacaoElegibilidadePBM_TeleMarketing"));
		if(TransacaoElegibilidadePBM_TeleMarketingPtr != NULL)
		{
			resultado = TransacaoElegibilidadePBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pNumeroCupom,
						pRedePBM, pMatricula, pDadosElegibilidade, pNumeroControle, pNumeroControleRede, pNomeCliente, pNomeMedico,
						pInformaDependente, pListaDependentes, pReservado, pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoPreAutorizacaoPBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV,
	char *pNumeroCupom, char *pRedePBM, char *pAutorizacaoElegibilidade, char *pDadosFarmaceutico, char *pQuantidadeMedicamentos, char *pMedicamentos,
	char *pNumeroControle, char *pNumeroControleRede, char *pReservado, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pNumeroControleRede, 0, 13);
	memset(pReservado, 0, 128);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FTransacaoPreAutorizacaoPBM_TeleMarketing TransacaoPreAutorizacaoPBM_TeleMarketingPtr = FTransacaoPreAutorizacaoPBM_TeleMarketing(GetProcAddress(
		 handle, "TransacaoPreAutorizacaoPBM_TeleMarketing"));
	
		if(TransacaoPreAutorizacaoPBM_TeleMarketingPtr != NULL)
		{
			resultado = TransacaoPreAutorizacaoPBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV,
						pNumeroCupom, pRedePBM, pAutorizacaoElegibilidade, pDadosFarmaceutico, pQuantidadeMedicamentos, pMedicamentos,
						pNumeroControle, pNumeroControleRede, pReservado, pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::ConsultaParametrosPBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pNumeroCupom,
	char *pQuantidadeRedes, char *pDadosRedes, char *pMensagemOperador)
{ 
 	int resultado = 11;
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FConsultaParametrosPBM_TeleMarketing ConsultaParametrosPBM_TeleMarketingPtr = FConsultaParametrosPBM_TeleMarketing(GetProcAddress(
			handle, "ConsultaParametrosPBM_TeleMarketing"));
 
	
		if(ConsultaParametrosPBM_TeleMarketingPtr != NULL)
		{
			resultado = ConsultaParametrosPBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pNumeroCupom,
						pQuantidadeRedes, pDadosRedes, pMensagemOperador);
		}
	}

	return resultado;
}

int ClasseIntegracao::ConsultaProdutosPBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pNumeroCupom,
	char *pRedePBM, char *pTrilha1, char *pTrilha2, char *pDigitado, char *pAutorizacao, char *pDadosCRM, char *pTipoVenda, char *pValorTotalMedicamentos,
	char *pValorVista, char *pValorCartao, char *pCodigoCredenciado, char *pQuantidadeMedicamentos, char *pMedicamentos, char *pReservado,
	char *pNumeroControle, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pValorVista, 0, 13);
	memset(pValorCartao, 0, 13);
	memset(pCodigoCredenciado, 0, 12);
	memset(pQuantidadeMedicamentos, 0, 3);
	memset(pMedicamentos, 0, 4261);
	memset(pReservado, 0, 128);
	memset(pNumeroControle, 0, 6);
	memset(pMensagemOperador, 0, 64);
	memset(pValorTotalMedicamentos, 0, 13);
	memset(pTipoVenda, 0, 3);

	if(handle > 0)
	{
		FConsultaProdutosPBM_TeleMarketing ConsultaProdutosPBM_TeleMarketingPtr = FConsultaProdutosPBM_TeleMarketing(
			GetProcAddress(handle, "ConsultaProdutosPBM_TeleMarketing"));
	
		if(ConsultaProdutosPBM_TeleMarketingPtr != NULL)
		{
			resultado = ConsultaProdutosPBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pNumeroCupom,
						pRedePBM, pTrilha1, pTrilha2, pDigitado, pAutorizacao, pDadosCRM, pTipoVenda, pValorTotalMedicamentos,
						pValorVista, pValorCartao, pCodigoCredenciado, pQuantidadeMedicamentos, pMedicamentos, pReservado,
						pNumeroControle, pMensagemOperador);
		}
	}
	return resultado;
}
int ClasseIntegracao::TransacaoVendaPBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV,
	char *pValorTotalMedicamentos, char *pNumeroCupom, char *pRedePBM, char *pTrilha1, char *pTrilha2, char *pDigitado, char *pAutorizacao,
	char *pNSUConsulta, char *pDadosCRM, char *pTipoVenda, char *pValorVista, char *pValorCartao, char *pCodigoCredenciado, char *pRegraNegocio,
	char *pQuantidadeMedicamentos, char *pMedicamentos, char *pReservado, char *pNumeroControle, char *pNumeroControleRede, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pNumeroControleRede, 0, 13);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FTransacaoVendaPBM_TeleMarketing TransacaoVendaPBM_TeleMarketingPtr = FTransacaoVendaPBM_TeleMarketing(
			GetProcAddress(handle, "TransacaoVendaPBM_TeleMarketing"));
	
		if(TransacaoVendaPBM_TeleMarketingPtr != NULL)
		{
			resultado = TransacaoVendaPBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV,
						pValorTotalMedicamentos, pNumeroCupom, pRedePBM, pTrilha1, pTrilha2, pDigitado, pAutorizacao,
						pNSUConsulta, pDadosCRM, pTipoVenda, pValorVista, pValorCartao, pCodigoCredenciado, pRegraNegocio,
						pQuantidadeMedicamentos, pMedicamentos, pReservado, pNumeroControle, pNumeroControleRede, pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoCancelamentoVendaPBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV,
	char *pTrilha1, char *pTrilha2, char *pDigitado, char *pReservado, char *pNumeroControle, char *pMensagemOperador)
{ 
  	int resultado = 11;

	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FTransacaoCancelamentoVendaPBM_TeleMarketing TransacaoCancelamentoVendaPBM_TeleMarketingPtr = FTransacaoCancelamentoVendaPBM_TeleMarketing(
			GetProcAddress(handle, "TransacaoCancelamentoVendaPBM_TeleMarketing"));
 
		if(TransacaoCancelamentoVendaPBM_TeleMarketingPtr != NULL)
		{
			resultado = TransacaoCancelamentoVendaPBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV,
						pTrilha1, pTrilha2, pDigitado, pReservado, pNumeroControle, pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoAberturaVendaPBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV,
	char *pRedePBM, char *pTrilha1, char *pTrilha2, char *pDigitado, char *pReservado, char *pPedirDadosComplementares, char *pDadosComplementares,
	char *pInfoDadosComplementares, char *pMensagemOperador)
{ 
   	int resultado = 11;
	memset(pReservado, 0, 128);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		 FTransacaoAberturaVendaPBM_TeleMarketing TransacaoAberturaVendaPBM_TeleMarketingPtr = FTransacaoAberturaVendaPBM_TeleMarketing(
			 GetProcAddress(handle, "TransacaoAberturaVendaPBM_TeleMarketing"));
 
		if(TransacaoAberturaVendaPBM_TeleMarketingPtr != NULL)
		{
			resultado = TransacaoAberturaVendaPBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV,
						pRedePBM, pTrilha1, pTrilha2, pDigitado, pReservado, pPedirDadosComplementares, pDadosComplementares,
						pInfoDadosComplementares, pMensagemOperador);
		}
	}
	return resultado;
}

int ClasseIntegracao::TransacaoVendaProdutoPBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pRedePBM,
	char *pTrilha1, char *pTrilha2, char *pDigitado, char *pMedicamento, char *pReservado, char *pPedirDadosComplementares, char *pDadosComplementares,
	char *pInfoDadosComplementares, char *pMensagemOperador)
{ 
    int resultado = 11;
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		  FTransacaoVendaProdutoPBM_TeleMarketing TransacaoVendaProdutoPBM_TeleMarketingPtr = FTransacaoVendaProdutoPBM_TeleMarketing(GetProcAddress(
		  handle, "TransacaoVendaProdutoPBM_TeleMarketing"));
 
		if(TransacaoVendaProdutoPBM_TeleMarketingPtr != NULL)
		{
			resultado = TransacaoVendaProdutoPBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pRedePBM,
						pTrilha1, pTrilha2, pDigitado, pMedicamento, pReservado, pPedirDadosComplementares, pDadosComplementares,
						pInfoDadosComplementares, pMensagemOperador);
		}
	}
	return resultado;
}


int ClasseIntegracao::TransacaoFechamentoVendaPBM_TeleMarketing(char *pNumeroEmpresa, char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pRedePBM,
	char *pTrilha1, char *pTrilha2, char *pDigitado, char *pConfirmacao, char *pReservado, char *pAutorizacao, char *pNumeroControle, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FTransacaoFechamentoVendaPBM_TeleMarketing TransacaoFechamentoVendaPBM_TeleMarketingPtr = FTransacaoFechamentoVendaPBM_TeleMarketing(
		GetProcAddress(handle, "TransacaoFechamentoVendaPBM_TeleMarketing"));
 
		if(TransacaoFechamentoVendaPBM_TeleMarketingPtr != NULL)
		{
			resultado = TransacaoFechamentoVendaPBM_TeleMarketingPtr(pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pRedePBM,
						pTrilha1, pTrilha2, pDigitado, pConfirmacao, pReservado, pAutorizacao, pNumeroControle, pMensagemOperador);
		}
	}

	return resultado;
}
void ClasseIntegracao::InformaDadosMedicamentos(char *pIndicativoReceita, char *pRegistroProfissional, char *pListaMedicamentos)
{ 
	if(handle > 0)
	{
		FInformaDadosMedicamentos InformaDadosMedicamentosPtr = FInformaDadosMedicamentos(GetProcAddress(handle, "InformaDadosMedicamentos"));
 
		if(InformaDadosMedicamentosPtr != NULL)
		{
			InformaDadosMedicamentosPtr(pIndicativoReceita, pRegistroProfissional, pListaMedicamentos);
		}
	}
}
int ClasseIntegracao::TransacaoSaqueSaldo(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	

	if(handle > 0)
	{
		FTransacaoSaqueSaldo TransacaoSaqueSaldoPtr = FTransacaoSaqueSaldo(GetProcAddress(handle, "TransacaoSaqueSaldo"));
 
		if(TransacaoSaqueSaldoPtr != NULL)
		{
			resultado = TransacaoSaqueSaldoPtr(pValorTransacao, pNumeroCupom ,pNumeroControle);
		}
	}
	
	return resultado;
}


int ClasseIntegracao::TransacaoSaqueExtrato(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		 FTransacaoSaqueExtrato TransacaoSaqueExtratoPtr = FTransacaoSaqueExtrato(GetProcAddress(handle, "TransacaoSaqueExtrato"));
		if(TransacaoSaqueExtratoPtr != NULL)
		{
			resultado = TransacaoSaqueExtratoPtr(pValorTransacao, pNumeroCupom ,pNumeroControle);
		}
	}
	
	return resultado;

}
int ClasseIntegracao::TransacaoConsultaAVS(char *pNumeroControle)
{ 
  	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoConsultaAVS TransacaoConsultaAVSPtr = FTransacaoConsultaAVS(GetProcAddress(handle, "TransacaoConsultaAVS"));
		if(TransacaoConsultaAVSPtr != NULL)
		{
			resultado = TransacaoConsultaAVSPtr(pNumeroControle);
		}
	}
	
	return resultado;

}
int ClasseIntegracao::TransacaoConsultaAVSConfirmada(char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pNumeroCupom, char *pNumeroControle,
	char *pNumeroCartao, char *pDataVencimento, char *pCVV2, char *pEndereco, char *pNumero, char *pApto, char *pBloco, char *pCEP, char *pBairro,
	char *pCPF, char *pMensagemTEF, char *pReservado)
{ 
   	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pMensagemTEF, 0, 64);
	 
	if(handle > 0)
	{	
		FTransacaoConsultaAVSConfirmada TransacaoConsultaAVSConfirmadaPtr = FTransacaoConsultaAVSConfirmada(GetProcAddress(handle, "TransacaoConsultaAVSConfirmada"));
		if(TransacaoConsultaAVSConfirmadaPtr != NULL)
		{
			resultado = TransacaoConsultaAVSConfirmadaPtr(pMultiLoja, pNumeroLoja, pNumeroPDV, pNumeroCupom, pNumeroControle,
						pNumeroCartao, pDataVencimento, pCVV2, pEndereco, pNumero, pApto, pBloco, pCEP, pBairro,
						pCPF, pMensagemTEF, pReservado);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoPagamentoContasVisanet(char* pTipoConta, char *pCodigoBarras, char *pFormaPagamento, char *pTrilhaCartao, char *pValorTransacao,
	char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pValorTransacao, 0, 13);
	
	if(handle > 0)
	{
		FTransacaoPagamentoContasVisanet TransacaoPagamentoContasVisanetPtr = FTransacaoPagamentoContasVisanet(GetProcAddress(handle, "TransacaoPagamentoContasVisanet"));
		if(TransacaoPagamentoContasVisanetPtr != NULL)
		{
			resultado = TransacaoPagamentoContasVisanetPtr(pTipoConta, pCodigoBarras, pFormaPagamento, pTrilhaCartao, pValorTransacao,
						pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoEspecial(int iCodigoTransacao, char *pDados)
{ 
 	int resultado = 11;	
	memset(pDados, 0, 2048);

	if(handle > 0)
	{
		FTransacaoEspecial TransacaoEspecialPtr = FTransacaoEspecial(GetProcAddress(handle, "TransacaoEspecial"));
		if(TransacaoEspecialPtr != NULL)
		{
			resultado = TransacaoEspecialPtr(iCodigoTransacao, pDados);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::ConsultaValoresPrePago(char *pNumeroControle, char *pMensagemOperador)
{ 
 	int resultado = 11;
	
	memset(pMensagemOperador, 0, 64);

	if(handle > 0)
	{
		FConsultaValoresPrePago ConsultaValoresPrePagoPtr = FConsultaValoresPrePago(GetProcAddress(handle, "ConsultaValoresPrePago"));
		if(ConsultaValoresPrePagoPtr != NULL)
		{
			resultado = ConsultaValoresPrePagoPtr(pNumeroControle, pMensagemOperador);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoRecargaCelular(char *pCodigoArea, char *pNumeroTelefone, char *pNumeroControle)
{
  	int resultado = 11;
	
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		 FTransacaoRecargaCelular TransacaoRecargaCelularPtr = FTransacaoRecargaCelular(GetProcAddress(handle, "TransacaoRecargaCelular"));
		if(TransacaoRecargaCelularPtr != NULL)
		{
			resultado = TransacaoRecargaCelularPtr(pCodigoArea, pNumeroTelefone, pNumeroControle);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::ConsultaParametrosTeledata(char *pDadosTeledata, char *pMensagemOperador)
{ 
	int resultado = 11;
	
	memset(pMensagemOperador, 0, 64);
	memset(pDadosTeledata, 0, 1025);

	if(handle > 0)
	{
		FConsultaParametrosTeledata ConsultaParametrosTeledataPtr = FConsultaParametrosTeledata(GetProcAddress(handle, "ConsultaParametrosTeledata"));
		if(ConsultaParametrosTeledataPtr != NULL)
		{
			resultado = ConsultaParametrosTeledataPtr(pDadosTeledata, pMensagemOperador);
		}
	}

	return resultado;
}

int ClasseIntegracao::ConsultaChequesGarantidos(char *pTipoDocumento, char *pNumeroDocumento, char *pDataInicialConsulta,
	char *pDataFinalConsulta, char *pNumeroControle)
{ 
	int resultado = 11;	
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FConsultaChequesGarantidos ConsultaChequesGarantidosPtr = FConsultaChequesGarantidos(GetProcAddress(handle, "ConsultaChequesGarantidos"));
		if(ConsultaChequesGarantidosPtr != NULL)
		{
			resultado = ConsultaChequesGarantidosPtr(pTipoDocumento, pNumeroDocumento, pDataInicialConsulta,
						pDataFinalConsulta, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoSaqueCompleta(char *pValorTransacao, char *pNumeroCupomFiscal, char *pNumeroControle, char *pTipoTransacao, 
	char *pPlanoPagamento, char *pNumeroParcelas, char *pPermiteAlteracao, char *pReservado)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoSaqueCompleta TransacaoSaqueCompletaPtr = FTransacaoSaqueCompleta(GetProcAddress(handle, "TransacaoSaqueCompleta"));
		if(TransacaoSaqueCompletaPtr != NULL)
		{
			resultado = TransacaoSaqueCompletaPtr(pValorTransacao, pNumeroCupomFiscal, pNumeroControle, pTipoTransacao, 
						pPlanoPagamento, pNumeroParcelas, pPermiteAlteracao, pReservado);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoCartaoCompraSaque(char *pValorCompra,char *pValorSaque, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		 FTransacaoCartaoCompraSaque TransacaoCartaoCompraSaquePtr = FTransacaoCartaoCompraSaque(GetProcAddress(handle, "TransacaoCartaoCompraSaque"));
		if(TransacaoCartaoCompraSaquePtr != NULL)
		{
			resultado = TransacaoCartaoCompraSaquePtr(pValorCompra, pValorSaque, pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoCartaoCompraSaqueCompleta(char *pValorCompra,char *pValorSaque, char *pNumeroCupom,char *pNumeroControle,char *pPermiteAlteracao)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCartaoCompraSaqueCompleta TransacaoCartaoCompraSaqueCompletaPtr = FTransacaoCartaoCompraSaqueCompleta(
		GetProcAddress(handle, "TransacaoCartaoCompraSaqueCompleta"));

		if(TransacaoCartaoCompraSaqueCompletaPtr != NULL)
		{
			resultado = TransacaoCartaoCompraSaqueCompletaPtr(pValorCompra,pValorSaque, pNumeroCupom,pNumeroControle,pPermiteAlteracao);
		}
	}
	
	return resultado;
}


int ClasseIntegracao::TesteRedeAtiva(char *pNumeroEmpresa, char *pNumeroLoja, char *pNumeroPDV, char *pCodigoRede, char *pStatusRede, char *pMensagemOperador)
{ 
	int resultado = 11;
	memset(pMensagemOperador, 0, 64);
	memset(pStatusRede, 0, 3);

	if(handle > 0)
	{
		FTesteRedeAtiva TesteRedeAtivaPtr = FTesteRedeAtiva(GetProcAddress(handle, "TesteRedeAtiva"));

		if(TesteRedeAtivaPtr != NULL)
		{
			resultado = TesteRedeAtivaPtr(pNumeroEmpresa, pNumeroLoja, pNumeroPDV, pCodigoRede, pStatusRede, pMensagemOperador);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoCadastraSenha(char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoCadastraSenha TransacaoCadastraSenhaPtr = FTransacaoCadastraSenha(GetProcAddress(handle, "TransacaoCadastraSenha"));

		if(TransacaoCadastraSenhaPtr != NULL)
		{
			resultado = TransacaoCadastraSenhaPtr(pNumeroControle);
		}
	}
	
	return resultado;
}

void  ClasseIntegracao::ConfiguraFluxoExternoDTEF5()
{ 
	if(handle > 0)
	{	
		FConfiguraFluxoExternoDTEF5 ConfiguraFluxoExternoDTEF5Ptr = FConfiguraFluxoExternoDTEF5(GetProcAddress(handle, "ConfiguraFluxoExternoDTEF5"));

		if(ConfiguraFluxoExternoDTEF5Ptr != NULL)
		{
			ConfiguraFluxoExternoDTEF5Ptr();
		}
	}	
}

int ClasseIntegracao::TrataDesfazimento(int iTratar)
{ 
	int resultado = 11;
	
	if(handle > 0)
	{
		FTrataDesfazimento TrataDesfazimentoPtr = FTrataDesfazimento(GetProcAddress(handle, "TrataDesfazimento"));

		if(TrataDesfazimentoPtr != NULL)
		{
			resultado = TrataDesfazimentoPtr(iTratar);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::ConsultaTransacao(char *pNumeroEmpresa, char *pNumeroLoja, char *pNumeroPDV, char *pSolicitacao, char *pResposta, char *pMensagemErro)
{ 
	int resultado = 11;
	
	memset(pMensagemErro, 0, 256);
	memset(pResposta, 0, 2048);

	if(handle > 0)
	{
		FConsultaTransacao ConsultaTransacaoPtr = FConsultaTransacao(GetProcAddress(handle, "ConsultaTransacao"));

		if(ConsultaTransacaoPtr != NULL)
		{
			resultado = ConsultaTransacaoPtr(pNumeroEmpresa, pNumeroLoja, pNumeroPDV, pSolicitacao, pResposta, pMensagemErro);
		}
	}
	
	return resultado;
}


int ClasseIntegracao::TransacaoeValeGas(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pNumeroValeGas)
{ 
	int resultado = 11;
	
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoeValeGas TransacaoeValeGasPtr = FTransacaoeValeGas(GetProcAddress(handle, "TransacaoeValeGas"));

		if(TransacaoeValeGasPtr != NULL)
		{
			resultado = TransacaoeValeGasPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pNumeroValeGas);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoConsultaeValeGas(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pNumeroValeGas, char *pDadosRetorno)
{ 
	int resultado = 11;	
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoConsultaeValeGas TransacaoConsultaeValeGasPtr = FTransacaoConsultaeValeGas(GetProcAddress(handle, "TransacaoConsultaeValeGas"));

		if(TransacaoConsultaeValeGasPtr != NULL)
		{
			resultado = TransacaoConsultaeValeGasPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pNumeroValeGas, pDadosRetorno);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoCancelamentoPadrao(char *pNumeroControle)
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FTransacaoCancelamentoPadrao TransacaoCancelamentoPadraoPtr = FTransacaoCancelamentoPadrao(GetProcAddress(handle, "TransacaoCancelamentoPadrao"));

		if(TransacaoCancelamentoPadraoPtr != NULL)
		{
			resultado = TransacaoCancelamentoPadraoPtr(pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::ConfiguraModoTeleMarketing(int iModo)
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FConfiguraModoTeleMarketing ConfiguraModoTeleMarketingPtr = FConfiguraModoTeleMarketing(GetProcAddress(handle, "ConfiguraModoTeleMarketing"));

		if(ConfiguraModoTeleMarketingPtr != NULL)
		{
			resultado = ConfiguraModoTeleMarketingPtr(iModo);
		}
	}
	
	return resultado;

}
int ClasseIntegracao::ConfirmaCartaoTeleMarketing(char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pNumeroControle, char *pMensagemTEF, char *pReservado)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pMensagemTEF, 0, 64);

	if(handle > 0)
	{
		FConfirmaCartaoTeleMarketing ConfirmaCartaoTeleMarketingPtr = FConfirmaCartaoTeleMarketing(GetProcAddress(handle, "ConfirmaCartaoTeleMarketing"));

		if(ConfirmaCartaoTeleMarketingPtr != NULL)
		{
			resultado = ConfirmaCartaoTeleMarketingPtr(pMultiLoja, pNumeroLoja, pNumeroPDV, pNumeroControle, pMensagemTEF, pReservado);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::DesfazCartaoTeleMarketing(char *pMultiLoja, char *pNumeroLoja, char *pNumeroPDV, char *pNumeroControle, char *pMensagemTEF, char *pReservado)
{ 
	int resultado = 11;
	memset(pMensagemTEF, 0, 64);

	if(handle > 0)
	{
		FDesfazCartaoTeleMarketing DesfazCartaoTeleMarketingPtr = FDesfazCartaoTeleMarketing(GetProcAddress(handle, "DesfazCartaoTeleMarketing"));

		if(DesfazCartaoTeleMarketingPtr != NULL)
		{
			resultado = DesfazCartaoTeleMarketingPtr(pMultiLoja, pNumeroLoja, pNumeroPDV, pNumeroControle, pMensagemTEF, pReservado);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoEstatistica(char *pNumeroControle)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoEstatistica TransacaoEstatisticaPtr = FTransacaoEstatistica(GetProcAddress(handle, "TransacaoEstatistica"));

		if(TransacaoEstatisticaPtr != NULL)
		{
			resultado = TransacaoEstatisticaPtr(pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoInjecaoChaves(char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoInjecaoChaves TransacaoInjecaoChavesPtr = FTransacaoInjecaoChaves(GetProcAddress(handle, "TransacaoInjecaoChaves"));

		if(TransacaoInjecaoChavesPtr != NULL)
		{
			resultado = TransacaoInjecaoChavesPtr(pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoTrocoSurpresa(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pMensagemTEF, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);

	if(handle > 0)
	{
		FTransacaoTrocoSurpresa TransacaoTrocoSurpresaPtr = FTransacaoTrocoSurpresa(GetProcAddress(handle, "TransacaoTrocoSurpresa"));

		if(TransacaoTrocoSurpresaPtr != NULL)
		{
			resultado = TransacaoTrocoSurpresaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pMensagemTEF, pReservado);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::IdentificacaoAutomacaoComercial(char *pNomeAutomacao, char *pVersaoAutomacao, char *pReservado)
{ 
	int resultado = 11;
	memset(pReservado, 0, 256);
	
	if(handle > 0)
	{
		FIdentificacaoAutomacaoComercial IdentificacaoAutomacaoComercialPtr = FIdentificacaoAutomacaoComercial(GetProcAddress(handle, "IdentificacaoAutomacaoComercial"));

		if(IdentificacaoAutomacaoComercialPtr != NULL)
		{
			resultado = IdentificacaoAutomacaoComercialPtr(pNomeAutomacao, pVersaoAutomacao, pReservado);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::ConsultaTabelasValeGas(char *pNumeroControle, char *pMensagemOperador)
{
	int resultado = 11;
	memset(pMensagemOperador, 0, 64);
	
	if(handle > 0)
	{
		FConsultaTabelasValeGas ConsultaTabelasValeGasPtr = FConsultaTabelasValeGas(GetProcAddress(handle, "ConsultaTabelasValeGas"));

		if(ConsultaTabelasValeGasPtr != NULL)
		{
			resultado = ConsultaTabelasValeGasPtr(pNumeroControle, pMensagemOperador);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::DefineBandeiraTransacao(char *pCodigoBandeira)
{ 
	int resultado = 11;
	
	if(handle > 0)
	{
		FDefineBandeiraTransacao DefineBandeiraTransacaoPtr = FDefineBandeiraTransacao(GetProcAddress(handle, "DefineBandeiraTransacao"));

		if(DefineBandeiraTransacaoPtr != NULL)
		{
			resultado = DefineBandeiraTransacaoPtr(pCodigoBandeira);
		}
	}

	return resultado;
}

int ClasseIntegracao::DefineRedeTransacao(char *pCodigoRede)
{ 
	int resultado = 11;
	
	if(handle > 0)
	{
		FDefineRedeTransacao DefineRedeTransacaoPtr = FDefineRedeTransacao(GetProcAddress(handle, "DefineRedeTransacao"));

		if(DefineRedeTransacaoPtr != NULL)
		{
			resultado = DefineRedeTransacaoPtr(pCodigoRede);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::ConverteCodigoRede(char *pCodigoRede, char *pCodigoRedeDTEF5, char *pCodigoRedeDTEF8)
{ 
 	int resultado = 11;
	memset(pCodigoRedeDTEF5, 0, 6);	
	memset(pCodigoRedeDTEF8, 0, 6);	

	if(handle > 0)
	{
		FConverteCodigoRede ConverteCodigoRedePtr = FConverteCodigoRede(GetProcAddress(handle, "ConverteCodigoRede"));

		if(ConverteCodigoRedePtr != NULL)
		{
			resultado = ConverteCodigoRedePtr(pCodigoRede, pCodigoRedeDTEF5, pCodigoRedeDTEF8);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoAbreLote(char *pNumeroCupom, char *pNumeroControle, char *pMensagemTEF, char *pReservado)
{
  	int resultado = 11;
	memset(pMensagemTEF, 0, 64);
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		 FTransacaoAbreLote TransacaoAbreLotePtr = FTransacaoAbreLote(GetProcAddress(handle, "TransacaoAbreLote"));

		if(TransacaoAbreLotePtr != NULL)
		{
			resultado = TransacaoAbreLotePtr(pNumeroCupom, pNumeroControle, pMensagemTEF, pReservado);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoFechaLote(char *pNumeroCupom, char *pNumeroControle, char *pMensagemTEF, char *pReservado)
{
	int resultado = 11;
	memset(pMensagemTEF, 0, 64);
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoFechaLote TransacaoFechaLotePtr = FTransacaoFechaLote(GetProcAddress(handle, "TransacaoFechaLote"));

		if(TransacaoFechaLotePtr != NULL)
		{
			resultado = TransacaoFechaLotePtr(pNumeroCupom, pNumeroControle, pMensagemTEF, pReservado);
		}
	}
	
	return resultado;
}
void ClasseIntegracao::ConfiguraEmpresaLojaPDV(char *pNumeroEmpresa, char *pNumeroLoja, char *pNumeroPDV)
{ 
 	int resultado = 11;
		
	if(handle > 0)
	{
		FConfiguraEmpresaLojaPDV ConfiguraEmpresaLojaPDVPtr = FConfiguraEmpresaLojaPDV(GetProcAddress(handle, "ConfiguraEmpresaLojaPDV"));

		if(ConfiguraEmpresaLojaPDVPtr != NULL)
		{
			ConfiguraEmpresaLojaPDVPtr(pNumeroEmpresa, pNumeroLoja, pNumeroPDV);
		}
	}
}

int ClasseIntegracao::TransacaoResgatePremio(char *pNumeroCupom, char *pNumeroControle)
{ 
   	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoResgatePremio TransacaoResgatePremioPtr = FTransacaoResgatePremio(GetProcAddress(handle, "TransacaoResgatePremio"));

		if(TransacaoResgatePremioPtr != NULL)
		{
			resultado = TransacaoResgatePremioPtr(pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoVendaPOS(char *pCNPJ, char *pNumeroSerie, char *pCodigoFrentista, char *pCPFCNPJ, char *pPagamentoTEF, char *pCartaoProprio,
	char *pValor, char *pTelefoneCliente, char *pCodigoOrigem, char *pSaldoPontos, char *pCodigoPesquisa, char *pReservado, char *pNumeroControle)
{ 
    int resultado = 11;
	memset(pNumeroControle, 0, 6);	
	
	if(handle > 0)
	{
		FTransacaoVendaPOS TransacaoVendaPOSPtr = FTransacaoVendaPOS(GetProcAddress(handle, "TransacaoVendaPOS"));

		if(TransacaoVendaPOSPtr != NULL)
		{
			resultado = TransacaoVendaPOSPtr(pCNPJ, pNumeroSerie, pCodigoFrentista, pCPFCNPJ, pPagamentoTEF, pCartaoProprio,
						pValor, pTelefoneCliente, pCodigoOrigem, pSaldoPontos, pCodigoPesquisa, pReservado, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoEstornoVendaPOS(char *pCNPJ, char *pNumeroSerie, char *pCodigoFrentista, char *pCPFCNPJ, char *pDataEstorno,
	char *pNSUEstorno, char *pAutorizacaoEstorno, char *pSaldoPontos, char *pNumeroControle)
{ 
    int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoEstornoVendaPOS TransacaoEstornoVendaPOSPtr = FTransacaoEstornoVendaPOS(GetProcAddress(handle, "TransacaoEstornoVendaPOS"));

		if(TransacaoEstornoVendaPOSPtr != NULL)
		{
			resultado = TransacaoEstornoVendaPOSPtr(pCNPJ, pNumeroSerie, pCodigoFrentista, pCPFCNPJ, pDataEstorno,
						pNSUEstorno, pAutorizacaoEstorno, pSaldoPontos, pNumeroControle);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoResgatePontosPOS(char *pCNPJ, char *pNumeroSerie, char *pCodigoFrentista, char *pCPFCNPJ, char *pQuantidadeProdutos,
	char *pListaProdutos, char *pSaldoPontos, char *pReservado, char *pNumeroControle)
{
    int resultado = 11;
	memset(pNumeroControle, 0, 6);	
	
	if(handle > 0)
	{
		FTransacaoResgatePontosPOS TransacaoResgatePontosPOSPtr = FTransacaoResgatePontosPOS(GetProcAddress(handle, "TransacaoResgatePontosPOS"));
		if(TransacaoResgatePontosPOSPtr != NULL)
		{
			resultado = TransacaoResgatePontosPOSPtr(pCNPJ, pNumeroSerie, pCodigoFrentista, pCPFCNPJ, pQuantidadeProdutos,
						pListaProdutos, pSaldoPontos, pReservado, pNumeroControle);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoConsultaPontosPOS(char *pCNPJ, char *pNumeroSerie, char *pCodigoFrentista, char *pCPFCNPJ, char *pSaldoPontos,
	char *pReservado, char *pNumeroControle)
{
    int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoConsultaPontosPOS TransacaoConsultaPontosPOSPtr = FTransacaoConsultaPontosPOS(GetProcAddress(handle, "TransacaoConsultaPontosPOS"));
		if(TransacaoConsultaPontosPOSPtr != NULL)
		{
			resultado = TransacaoConsultaPontosPOSPtr(pCNPJ, pNumeroSerie, pCodigoFrentista, pCPFCNPJ, pSaldoPontos,
						pReservado, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::AtualizacaoFrentistasPOS(char *pCNPJ, char *pNumeroSerie, char *pNumeroFrentistas, char *pListaFrentistas, char *pReservado, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FAtualizacaoFrentistasPOS  AtualizacaoFrentistasPOSPtr = FAtualizacaoFrentistasPOS(GetProcAddress(handle, "AtualizacaoFrentistasPOS"));
		if(AtualizacaoFrentistasPOSPtr != NULL)
		{
			resultado = AtualizacaoFrentistasPOSPtr(pCNPJ, pNumeroSerie, pNumeroFrentistas, pListaFrentistas, pReservado, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::BuscaTabelaDTEF(int iTipoTabela, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);	
	
	if(handle > 0)
	{
		FBuscaTabelaDTEF BuscaTabelaDTEFPtr = FBuscaTabelaDTEF(GetProcAddress(handle, "BuscaTabelaDTEF"));
		if(BuscaTabelaDTEFPtr != NULL)
		{
			resultado = BuscaTabelaDTEFPtr(iTipoTabela, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoContratacao(char *pNumeroCupom, char *pNumeroControle)
{	
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoContratacao TransacaoContratacaoPtr = FTransacaoContratacao(GetProcAddress(handle, "TransacaoContratacao"));
		if(TransacaoContratacaoPtr != NULL)
		{
			resultado = TransacaoContratacaoPtr(pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}


int ClasseIntegracao::TransacaoPrimeiraCompra(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		 FTransacaoPrimeiraCompra TransacaoPrimeiraCompraPtr = FTransacaoPrimeiraCompra(GetProcAddress(handle, "TransacaoPrimeiraCompra"));
		if(TransacaoPrimeiraCompraPtr != NULL)
		{
			resultado = TransacaoPrimeiraCompraPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoCadastro(char *pCNPJ, char *pNumeroSerie, char *pCodigoFrentista, char *pCPFCNPJ, char *pTelefoneCliente,
	char *pReservado, char *pNumeroControle)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pReservado, 0, sizeof(pReservado));
	
	if(handle > 0)
	{
		FTransacaoCadastro TransacaoCadastroPtr = FTransacaoCadastro(GetProcAddress(handle, "TransacaoCadastro"));
		if(TransacaoCadastroPtr != NULL)
		{
			resultado = TransacaoCadastroPtr(pCNPJ, pNumeroSerie, pCodigoFrentista, pCPFCNPJ, pTelefoneCliente, pReservado, pNumeroControle);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoDesativacaoPOS(char *pCNPJ, char *pNumeroSerie, char *pNumeroSerieDesativacao, char *pFrentista, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoDesativacaoPOS TransacaoDesativacaoPOSPtr = FTransacaoDesativacaoPOS(GetProcAddress(handle, "TransacaoDesativacaoPOS"));
		if(TransacaoDesativacaoPOSPtr != NULL)
		{
			resultado = TransacaoDesativacaoPOSPtr(pCNPJ, pNumeroSerie, pNumeroSerieDesativacao, pFrentista, pNumeroControle);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoConsultaPOSAtivos(char *pCNPJ, char *pNumeroSerie, char *pNumeroPOSAtivos, char *pListaPOSAtivos, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);	
	
	if(handle > 0)
	{
		FTransacaoConsultaPOSAtivos TransacaoConsultaPOSAtivosPtr = FTransacaoConsultaPOSAtivos(GetProcAddress(handle, "TransacaoConsultaPOSAtivos"));
		if(TransacaoConsultaPOSAtivosPtr != NULL)
		{
			resultado = TransacaoConsultaPOSAtivosPtr(pCNPJ, pNumeroSerie, pNumeroPOSAtivos, pListaPOSAtivos, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::ProcuraPinPad(char *pDados)
{ 
	int resultado = 11;

	if(handle > 0)
	{
		FProcuraPinPad ProcuraPinPadPtr = FProcuraPinPad(GetProcAddress(handle, "ProcuraPinPad"));
		if(ProcuraPinPadPtr != NULL)
		{
			resultado = ProcuraPinPadPtr(pDados);
		}
	}

	return resultado;
}

int ClasseIntegracao::ApagaTabelasPinPad(char *pDados)
{ 
	int resultado = 11;
	
	if(handle > 0)
	{
		FApagaTabelasPinPad ApagaTabelasPinPadPtr = FApagaTabelasPinPad(GetProcAddress(handle, "ApagaTabelasPinPad"));
		if(ApagaTabelasPinPadPtr != NULL)
		{
			resultado = ApagaTabelasPinPadPtr(pDados);
		}
	}

	return resultado;
}
int ClasseIntegracao::TransacaoFuncoesAdministrativas(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoFuncoesAdministrativas TransacaoFuncoesAdministrativasPtr = FTransacaoFuncoesAdministrativas(
			GetProcAddress(handle, "TransacaoFuncoesAdministrativas"));

		if(TransacaoFuncoesAdministrativasPtr != NULL)
		{
			resultado = TransacaoFuncoesAdministrativasPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pReservado);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoQuitacaoCartaFrete(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoQuitacaoCartaFrete TransacaoQuitacaoCartaFretePtr = FTransacaoQuitacaoCartaFrete(GetProcAddress(handle, "TransacaoQuitacaoCartaFrete"));

		if(TransacaoQuitacaoCartaFretePtr != NULL)
		{
			resultado = TransacaoQuitacaoCartaFretePtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoQuitacaoCartaFreteCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle,char *pNumeroCartaFrete,
	char *pQuantidadeChegada, char *pPermiteAlteracao, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoQuitacaoCartaFreteCompleta TransacaoQuitacaoCartaFreteCompletaPtr = FTransacaoQuitacaoCartaFreteCompleta(
			GetProcAddress(handle, "TransacaoQuitacaoCartaFreteCompleta"));

		if(TransacaoQuitacaoCartaFreteCompletaPtr != NULL)
		{
			resultado = TransacaoQuitacaoCartaFreteCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle,pNumeroCartaFrete,
						pQuantidadeChegada, pPermiteAlteracao, pReservado);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoCartaoCrediario(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoCartaoCrediario TransacaoCartaoCrediarioPtr = FTransacaoCartaoCrediario(GetProcAddress(handle, "TransacaoCartaoCrediario"));

		if(TransacaoCartaoCrediarioPtr != NULL)
		{
			resultado = TransacaoCartaoCrediarioPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoSimulacaoCrediario(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoSimulacaoCrediario TransacaoSimulacaoCrediarioPtr = FTransacaoSimulacaoCrediario(GetProcAddress(handle, "TransacaoSimulacaoCrediario"));

		if(TransacaoSimulacaoCrediarioPtr != NULL)
		{
			resultado = TransacaoSimulacaoCrediarioPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoPagamentoPrivateLabelCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pIndicadorDigitacao,
	char *pCodigoBarras, char *pNumeroCartao, char *pCodigoRede, char *pPermiteAlteracao, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);	
	
	if(handle > 0)
	{
		FTransacaoPagamentoPrivateLabelCompleta TransacaoPagamentoPrivateLabelCompletaPtr = FTransacaoPagamentoPrivateLabelCompleta(
		GetProcAddress(handle, "TransacaoPagamentoPrivateLabelCompleta"));

		if(TransacaoPagamentoPrivateLabelCompletaPtr != NULL)
		{
			resultado = TransacaoPagamentoPrivateLabelCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pIndicadorDigitacao,
						pCodigoBarras, pNumeroCartao, pCodigoRede, pPermiteAlteracao, pReservado);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::TransacaoCargaCartao(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoCargaCartao TransacaoCargaCartaoPtr = FTransacaoCargaCartao(GetProcAddress(handle, "TransacaoCargaCartao"));

		if(TransacaoCargaCartaoPtr != NULL)
		{
			resultado = TransacaoCargaCartaoPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}

	return resultado;
}
int ClasseIntegracao::TransacaoRecargaCartao(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoRecargaCartao TransacaoRecargaCartaoPtr = FTransacaoRecargaCartao(GetProcAddress(handle, "TransacaoRecargaCartao"));

		if(TransacaoRecargaCartaoPtr != NULL)
		{
			resultado = TransacaoRecargaCartaoPtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::CadastraPDV()
{ 
	int resultado = 11;
	
	if(handle > 0)
	{
		FCadastraPDV CadastraPDVPtr = FCadastraPDV(GetProcAddress(handle, "CadastraPDV"));

		if(CadastraPDVPtr != NULL)
		{
			resultado = CadastraPDVPtr();
		}
	}
	
	return resultado;
}

int ClasseIntegracao::CadastraPDVTelemarketing(char *pNumeroEmpresa, char *pNumeroLoja, char *pNumeroPDV, char *pMensagemTEF)
{ 
	int resultado = 11;
	memset(pMensagemTEF, 0, sizeof(pMensagemTEF));
	
	if(handle > 0)
	{
		FCadastraPDVTelemarketing CadastraPDVTelemarketingPtr = FCadastraPDVTelemarketing(GetProcAddress(handle, "CadastraPDVTelemarketing"));

		if(CadastraPDVTelemarketingPtr != NULL)
		{
			resultado = CadastraPDVTelemarketingPtr(pNumeroEmpresa, pNumeroLoja, pNumeroPDV, pMensagemTEF);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoCartaoCrediarioCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle, char *pNumeroParcelas,
	char *pDataParcela1, char *pValorParcela1, char *pValorEntrada, char *pPermiteAlteracao, char *pReservado)
{
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		 FTransacaoCartaoCrediarioCompleta TransacaoCartaoCrediarioCompletaPtr = FTransacaoCartaoCrediarioCompleta(GetProcAddress(handle, "TransacaoCartaoCrediarioCompleta"));

		if(TransacaoCartaoCrediarioCompletaPtr != NULL)
		{
			resultado = TransacaoCartaoCrediarioCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle, pNumeroParcelas,
						pDataParcela1, pValorParcela1, pValorEntrada, pPermiteAlteracao, pReservado);
		}
	}

	return resultado;
}
int ClasseIntegracao::TransacaoConsultaPlanos(char *pValorTransacao, char *pNumeroControle, char *pReservado, char *pPlanos)
{ 
  	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	memset(pPlanos, 0, sizeof(pPlanos));
	
	if(handle > 0)
	{
		 FTransacaoConsultaPlanos TransacaoConsultaPlanosPtr = FTransacaoConsultaPlanos(GetProcAddress(handle, "TransacaoConsultaPlanos"));

		if(TransacaoConsultaPlanosPtr != NULL)
		{
			resultado = TransacaoConsultaPlanosPtr(pValorTransacao, pNumeroControle, pReservado, pPlanos);
		}
	}
	
	return resultado;
}
int ClasseIntegracao::ConsultaCadastroPDV(char *pMensagem)
{ 
   	int resultado = 11;
	memset(pMensagem, 0, 64);
	
	if(handle > 0)
	{
		FConsultaCadastroPDV ConsultaCadastroPDVPtr = FConsultaCadastroPDV(GetProcAddress(handle, "ConsultaCadastroPDV"));

		if(ConsultaCadastroPDVPtr != NULL)
		{
			resultado = ConsultaCadastroPDVPtr(pMensagem);
		}
	}

	return resultado;
}

int ClasseIntegracao::ConsultaCadastroPDVTelemarketing(char *pNumeroEmpresa, char *pNumeroLoja, char *pNumeroPDV, char *pMensagemTEF)
{ 
    int resultado = 11;
	memset(pMensagemTEF, 0, 64);
	
	if(handle > 0)
	{
		 FConsultaCadastroPDVTelemarketing ConsultaCadastroPDVTelemarketingPtr = FConsultaCadastroPDVTelemarketing(GetProcAddress(handle, "ConsultaCadastroPDVTelemarketing"));

		if(ConsultaCadastroPDVTelemarketingPtr != NULL)
		{
			resultado = ConsultaCadastroPDVTelemarketingPtr(pNumeroEmpresa, pNumeroLoja, pNumeroPDV, pMensagemTEF);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoSimulacaoSaque(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle)
{ 
    int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoSimulacaoSaque TransacaoSimulacaoSaquePtr = FTransacaoSimulacaoSaque(GetProcAddress(handle, "TransacaoSimulacaoSaque"));

		if(TransacaoSimulacaoSaquePtr != NULL)
		{
			resultado = TransacaoSimulacaoSaquePtr(pValorTransacao, pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoBloqueioCartao(char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);	
	
	if(handle > 0)
	{
		FTransacaoBloqueioCartao TransacaoBloqueioCartaoPtr = FTransacaoBloqueioCartao(GetProcAddress(handle, "TransacaoBloqueioCartao"));

		if(TransacaoBloqueioCartaoPtr != NULL)
		{
			resultado = TransacaoBloqueioCartaoPtr(pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoDesbloqueioCartao(char *pNumeroCupom, char *pNumeroControle)
{ 
 	int resultado = 11;
	memset(pNumeroControle, 0, 6);	
	
	if(handle > 0)
	{
		 FTransacaoDesbloqueioCartao TransacaoDesbloqueioCartaoPtr = FTransacaoDesbloqueioCartao(GetProcAddress(handle, "TransacaoDesbloqueioCartao"));

		if(TransacaoDesbloqueioCartaoPtr != NULL)
		{
			resultado = TransacaoDesbloqueioCartaoPtr(pNumeroCupom, pNumeroControle);
		}
	}

	return resultado;
}

int ClasseIntegracao::TransacaoConsultaCadastroCPFCompleta(char *pValorTransacao,char *pNumeroCupom, char *pNumeroControle,char *pTipoOperacao,
	char *pDocEmissor,char *pPermiteAlteracao,char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
		
	if(handle > 0)
	{
		FTransacaoConsultaCadastroCPFCompleta TransacaoConsultaCadastroCPFCompletaPtr = FTransacaoConsultaCadastroCPFCompleta(
		GetProcAddress(handle, "TransacaoConsultaCadastroCPFCompleta"));

		if(TransacaoConsultaCadastroCPFCompletaPtr != NULL)
		{
			resultado = TransacaoConsultaCadastroCPFCompletaPtr(pValorTransacao,pNumeroCupom, pNumeroControle,pTipoOperacao,
						pDocEmissor,pPermiteAlteracao,pReservado);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoDepositoCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle,char *pTipoOperacao,char *pDocEmissor,
	char *pDocDestinatario,char *pPermiteAlteracao,char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);	
	
	if(handle > 0)
	{
		FTransacaoDepositoCompleta TransacaoDepositoCompletaPtr = FTransacaoDepositoCompleta(GetProcAddress(handle, "TransacaoDepositoCompleta"));

		if(TransacaoDepositoCompletaPtr != NULL)
		{
			resultado = TransacaoDepositoCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle,pTipoOperacao,pDocEmissor,
						pDocDestinatario,pPermiteAlteracao,pReservado);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoSaqueDomesticoCompleta(char *pValorTransacao, char *pNumeroCupom, char *pNumeroControle,char *pTipoOperacao,char *pCodigoPIN,
	char *pDocDestinatario,char *pPermiteAlteracao, char *pReservado)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);	
	
	if(handle > 0)
	{
		FTransacaoSaqueDomesticoCompleta TransacaoSaqueDomesticoCompletaPtr = FTransacaoSaqueDomesticoCompleta(GetProcAddress(handle, "TransacaoSaqueDomesticoCompleta"));

		if(TransacaoSaqueDomesticoCompletaPtr != NULL)
		{
			resultado = TransacaoSaqueDomesticoCompletaPtr(pValorTransacao, pNumeroCupom, pNumeroControle,pTipoOperacao,pCodigoPIN,
						pDocDestinatario,pPermiteAlteracao, pReservado);
		}
	}
	
	return resultado;
}

int ClasseIntegracao::TransacaoAlteraSenhaUsuarioDTEF(char *pNumeroCupom, char *pNumeroControle)
{ 
	int resultado = 11;
	memset(pNumeroControle, 0, 6);
	
	if(handle > 0)
	{
		FTransacaoAlteraSenhaUsuarioDTEF TransacaoAlteraSenhaUsuarioDTEFPtr = FTransacaoAlteraSenhaUsuarioDTEF(GetProcAddress(handle, "TransacaoAlteraSenhaUsuarioDTEF"));

		if(TransacaoAlteraSenhaUsuarioDTEFPtr != NULL)
		{
			resultado = TransacaoAlteraSenhaUsuarioDTEFPtr(pNumeroCupom, pNumeroControle);
		}
	}
	
	return resultado;
}

//DefineParamentroTransacao
int ClasseIntegracao::DefineParametroTransacao(int iCodigoParametro, char *pValorParametro, int iTamanhoParametro)
{ 
	int resultado = 11;
		
	if(handle > 0)
	{
		FDefineParametroTransacao DefineParametroTransacaoPtr = FDefineParametroTransacao(GetProcAddress(handle, "DefineParametroTransacao"));

		if(DefineParametroTransacaoPtr != NULL)
		{
			resultado = DefineParametroTransacaoPtr(iCodigoParametro, pValorParametro, iTamanhoParametro);
		}
	}

	return resultado;
}

int ClasseIntegracao::DefineParametroConfirmacao(int iCodigoParametro,char *pValorParametro,char *pTamanhoParametro)
{ 
	int resultado = 11;
		
	if(handle > 0)
	{
		FDefineParametroConfirmacao DefineParametroConfirmacaoPtr = FDefineParametroConfirmacao(GetProcAddress(handle, "DefineParametroConfirmacao"));

		if(DefineParametroConfirmacaoPtr != NULL)
		{
			resultado = DefineParametroConfirmacaoPtr(iCodigoParametro, pValorParametro, pTamanhoParametro);
		}
	}

	return resultado;
}

void ClasseIntegracao::descarregaDll()
{
	FreeLibrary(handle);
  handle = NULL;
}

void ClasseIntegracao::recarregaDll(bool bOperacoesSemTelas)
{
  descarregaDll();
  carregaDll();
  if (bOperacoesSemTelas)
    setTransacaoSemTelas();
}

ClasseIntegracao::~ClasseIntegracao(void)
{
}