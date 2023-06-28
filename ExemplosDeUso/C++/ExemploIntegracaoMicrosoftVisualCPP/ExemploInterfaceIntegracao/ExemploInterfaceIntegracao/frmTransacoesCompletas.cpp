#include "stdafx.h"
#include "Define.h"
#include "frmTransacoesCompletas.h"
#include "InterfaceExemplo.h"

using namespace ExemploInterfaceIntegracao;

void frmTransacoesCompletas::ajustaOpcoes()
{
  switch (iModo)
  {
    case CREDITO_COMPLETA:
      selecionaTab("Crédito Completa");
      break;
    case DEBITO_COMPLETA:
      selecionaTab("Débito Completa");
      break;
    case PRIVATE_LABEL_COMPLETA:
      selecionaTab("Private Label Completa");
      break;
    case VOUCHER_COMPLETA:
      selecionaTab("Voucher Completa");
      break;
    case CREDIARIO_COMPLETA:
      selecionaTab("Crediário Completa");
      break;

    default:
      break;
  }
}

void frmTransacoesCompletas::selecionaTab(String^ sSelecionada)
{
  for each (TabPage^ ctl in tcPrincipal->TabPages)
  {
    if (ctl->Text != sSelecionada)
      tcPrincipal->Controls->Remove(ctl);
  }
}

tsParamCreditoCompleta* frmTransacoesCompletas::getParametrosCreditoCompleta()
{
  tsParamCreditoCompleta* stParamCreditoCompleta = new tsParamCreditoCompleta;

  String^ sNumeroParcelas;
  String^ sValorParcela;
  String^ sValorTaxaServico;

  FuncoesComuns::ExtraiNumeros(tbNumParcelasCR->Text, sNumeroParcelas);
  FuncoesComuns::ExtraiNumeros(tbValorParcelaCR->Text, sValorParcela);
  FuncoesComuns::ExtraiNumeros(tbTaxaServicoCR->Text, sValorTaxaServico);

  stParamCreditoCompleta->numeroParcelas   = FuncoesComuns::SystemStrToCharPtr(sNumeroParcelas->PadLeft(2, '0') + '\0');
  stParamCreditoCompleta->permiteAlteracao = FuncoesComuns::SystemStrToCharPtr(cbPermiteAlteracaoCR->Text + '\0');
  stParamCreditoCompleta->reservado        = FuncoesComuns::SystemStrToCharPtr(tbReservadoCR->Text->PadLeft(158, '0') + '\0');
  stParamCreditoCompleta->tipo             = FuncoesComuns::SystemStrToCharPtr(cbTipoOperacaoCR->Text + '\0');
  stParamCreditoCompleta->valorParcela     = FuncoesComuns::SystemStrToCharPtr(sValorParcela->PadLeft(12, '0') + '\0');
  stParamCreditoCompleta->valorTaxaServico = FuncoesComuns::SystemStrToCharPtr(sValorTaxaServico->PadLeft(12, '0') + '\0');

  return stParamCreditoCompleta;
}

tsParamDebitoCompleta* frmTransacoesCompletas::getParametrosDebitoCompleta()
{
  tsParamDebitoCompleta* stParamDebitoCompleta = new tsParamDebitoCompleta;

  String^ sNumeroParcelas;
  String^ sValorParcela;
  String^ sValorTaxaServico;
  String^ sData;

  FuncoesComuns::ExtraiNumeros(tbNumeroParcelasDB->Text, sNumeroParcelas);
  FuncoesComuns::ExtraiNumeros(tbValorParcelaDB->Text, sValorParcela);
  FuncoesComuns::ExtraiNumeros(tbTaxaServicoDB->Text, sValorTaxaServico);
  FuncoesComuns::ExtraiNumeros(tbDataDB->Text, sData, false);

  stParamDebitoCompleta->numeroParcelas     = FuncoesComuns::SystemStrToCharPtr(sNumeroParcelas->PadLeft(2, '0'));
  stParamDebitoCompleta->permiteAlteracao   = FuncoesComuns::SystemStrToCharPtr(cbPermiteAlteracaoDB->Text);
  stParamDebitoCompleta->reservado          = FuncoesComuns::SystemStrToCharPtr(tbReservadoDB->Text->PadLeft(158, '0'));
  stParamDebitoCompleta->tipo               = FuncoesComuns::SystemStrToCharPtr(cbTipoOperacaoDB->Text->PadLeft(8,'0'));
  stParamDebitoCompleta->valorParcela       = FuncoesComuns::SystemStrToCharPtr(sValorParcela->PadLeft(12, '0') );
  stParamDebitoCompleta->valorTaxaServico   = FuncoesComuns::SystemStrToCharPtr(sValorTaxaServico->PadLeft(12, '0'));
  stParamDebitoCompleta->dataDebito         = FuncoesComuns::SystemStrToCharPtr(sData->PadLeft(8, '0'));
  stParamDebitoCompleta->sequenciaParcela   = FuncoesComuns::SystemStrToCharPtr(tbSequenciaDB->Text->PadLeft(2, '0'));

  return stParamDebitoCompleta;
}

char* frmTransacoesCompletas::getParametrosVoucherCompleta()
{
  return FuncoesComuns::SystemStrToCharPtr(tbReservadoVC->Text->PadLeft(8, '0'));
}

tsParamPrivateLblCompleta* frmTransacoesCompletas::getParametrosPrivateLabel()
{
  tsParamPrivateLblCompleta* stParamPrivateLblCompleta = new tsParamPrivateLblCompleta;

  char* tipo           = FuncoesComuns::SystemStrToCharPtr(cbTipoOperacaoPL->Text);
  char* numeroParcelas = FuncoesComuns::SystemStrToCharPtr(tbNumeroParcelasPL->Text->PadLeft(2, '0'));
  char* pAlteracao     = FuncoesComuns::SystemStrToCharPtr(cbPermiteAlteracaoPL->Text);
  char* reservado      = FuncoesComuns::SystemStrToCharPtr(tbReservadoPL->Text->PadLeft(158, '0'));

  stParamPrivateLblCompleta->numeroParcelas = numeroParcelas;
  stParamPrivateLblCompleta->permiteAlteracao = pAlteracao;
  stParamPrivateLblCompleta->reservado = reservado;
  stParamPrivateLblCompleta->tipo = tipo;

  return stParamPrivateLblCompleta;
}

tsParamCrediarioCompleta* frmTransacoesCompletas::getParametrosCrediarioCompleta()
{
  tsParamCrediarioCompleta* stParamCrediarioCompleta = new tsParamCrediarioCompleta;

  stParamCrediarioCompleta->dataParcela1     = FuncoesComuns::SystemStrToCharPtr(tbDataParcelaCC->Text->PadLeft(8,'0'));
  stParamCrediarioCompleta->numeroParcelas   = FuncoesComuns::SystemStrToCharPtr(tbNumeroParcelasCC->Text->PadLeft(2, '0'));
  stParamCrediarioCompleta->permiteAlteracao = FuncoesComuns::SystemStrToCharPtr(cbPermiteAlteracaoCC->Text);
  stParamCrediarioCompleta->reservado        = FuncoesComuns::SystemStrToCharPtr(tbReservadoCC->Text->PadLeft(158, '0'));
  stParamCrediarioCompleta->valorEntrada     = FuncoesComuns::SystemStrToCharPtr(tbValorEntradaCC->Text->PadLeft(12, '0'));
  stParamCrediarioCompleta->valorParcela1    = FuncoesComuns::SystemStrToCharPtr(tbValorParcelaCC->Text->PadLeft(12, '0'));

  return stParamCrediarioCompleta;
}
