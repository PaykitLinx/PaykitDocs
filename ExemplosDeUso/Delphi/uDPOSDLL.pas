unit uDPOSDLL;


interface

uses SysUtils, Windows, Forms, Dialogs, Classes, Messages, ExtCtrls, Controls;

type
   TDadosAdicionaisCartaoCredito = record
      aTipoOperacao           : Array[1..3] of Char;
      aNumeroParcelas         : Array[1..3] of Char;
      aValorParcela           : Array[1..13] of Char;
      aValorTaxaServico       : Array[1..13] of Char;
      aPermiteAlteracao       : Array[1..2] of Char;
      aReservado              : Array[1..159] of Char;
   end;

   TDadosAdicionaisCartaoDebito = record
      aTipoOperacao           : Array[1..3] of Char;
      aNumeroParcelas         : Array[1..3] of Char;
      aSequenciaParcela       : Array[1..3] of Char;
      aDataDebito             : Array[1..9] of Char;
      aValorParcela           : Array[1..13] of Char;
      aValorTaxaServico       : Array[1..13] of Char;
      aPermiteAlteracao       : Array[1..2] of Char;
      aReservado              : Array[1..149] of Char;
   end;

   TDadosAdicionaisCartaoVoucher = record
      aReservado              : Array[1..187] of Char;
   end;

   TDadosParcelasDebito = record
      aDataParcela   : Array[1..8] of Char;
      aValorParcela  : Array[1..12] of Char;
   end;

   TInfDadosParcelasAdicionais = record
      NumeroParcelas : Integer;
      DadosParcela   : Array[1..99] of TDadosParcelasDebito;
   end;
   //TInfDadosParcelasAdicionais = Array[1..99] of TInfAdicionaisParcelasTransacaoDebito; //ALTERA-EDERSON-0207

   TDadosAdicionaisCheque = record
      aTipoDocumento          : Array[1..1] of Char;
      aNumeroDocumento        : Array[1..14] of Char;
      aQuantidadeCheques      : Array[1..2] of Char;
      aSequenciaCheques       : Array[1..2] of Char;
      aCamaraCompensacao      : Array[1..3] of Char;
      aNumeroBanco            : Array[1..3] of Char;
      aNumeroAgencia          : Array[1..4] of Char;
      aNumeroContaCorrente    : Array[1..10] of Char;
      aNumeroCheque           : Array[1..7] of Char;
      aDataDeposito           : Array[1..8] of Char;
      aValorCheque            : Array[1..12] of Char;
      aDataNascimentoCliente  : Array[1..8] of Char;
      aTelefoneCliente        : Array[1..12] of Char;
      aCMC7                   : Array[1..50] of Char;
      aPermiteAlteracao       : Array[1..1] of Char;
      aReservado              : Array[1..51] of Char;
   end;

   TDadosUltimaTransacao = record
      aEmpresa                : Array[1..4] of Char;
      aLoja                   : Array[1..6] of Char;
      aTipoRegistro           : Array[1..3] of Char;
      aData                   : Array[1..8] of Char;
      aHora                   : Array[1..6] of Char;
      aCodigoTransacao        : Array[1..2] of Char;
      aNumeroPDV              : Array[1..3] of Char;
      aNumeroFiscalEquipamento: Array[1..8] of Char;
      aNumeroCupom            : Array[1..6] of Char;

      // CREDITO
      aValor                  : Array[1..12] of Char;
      aTipoColeta             : Array[1..1] of Char;
      aNumeroAutorizadora     : Array[1..2] of Char;
      aNumeroCartao           : Array[1..37] of Char;
      aVencimentoCartao       : Array[1..4] of Char;

      // DEBITO
      aTipoTransacao          : Array[1..1] of Char;
      aCodigoSupervisor       : Array[1..8] of Char;

      // GERAL CARTOES
      aTipoOperacao           : Array[1..2] of Char;
      aNumeroParcelas         : Array[1..2] of Char;
      aSequenciaParcela       : Array[1..2] of Char;
      aDataParcela            : Array[1..8] of Char;
      aValorParcela           : Array[1..12] of Char;
      aValorTaxaServico       : Array[1..12] of Char;

      // CHEQUE
      aTipoDocumento          : Array[1..1] of Char;
      aNumeroDocumento        : Array[1..14] of Char;
      aQuantidadeCheques      : Array[1..2] of Char;
      aSequenciaCheque        : Array[1..2] of Char;
      aCamaraCompensacao      : Array[1..3] of Char;
      aNumeroBanco            : Array[1..3] of Char;
      aNumeroAgencia          : Array[1..4] of Char;
      aNumeroContaCorrente    : Array[1..10] of Char;
      aNumeroCheque           : Array[1..7] of Char;
      aDataDeposito           : Array[1..8] of Char;
      aValorCheque            : Array[1..12] of Char;
      aDataNascimento         : Array[1..8] of Char;
      aTelefone               : Array[1..12] of Char;
      aCMC7                   : Array[1..50] of Char;

      // Resposta
      aCodigoResposta            : Array[1..2] of Char;
      aNumeroControleAutorizadora: Array[1..9] of Char;
      aNSU                       : Array[1..6] of Char;
      aNumeroAutorizacaoRede     : Array[1..6] of Char;
      aMensagemErro              : Array[1..20] of Char;
   end;

  TTransacaoCheque = function (pValorTransacao, pNumeroCupomVenda, pNumeroControle, pQuantidadeCheques,
                             pPeriodicidadeCheques, pDataPrimeiroCheque, pCarenciaPrimeiroCheque: PChar): Integer; stdcall;
  TTransacaoCartaoCredito = function (pValorTransacao, pNumeroCupomVenda, pNumeroControle: PChar): Integer; stdcall;
  TConfirmacaoCartaoCredito = function (pNumeroControle: PChar): Integer; stdcall;

  TTransacaoCartaoDebito = function (pValorTransacao, pNumeroCupomVenda, pNumeroControle: PChar): Integer; stdcall;
  TConfirmacaoCartaoDebito = function (pNumeroControle: PChar): Integer; stdcall;

  TTransacaoCartaoVoucher = function (pValorTransacao, pNumeroCupomVenda, pNumeroControle: PChar): Integer; stdcall;
  TConfirmacaoCartaoVoucher = function (pNumeroControle: PChar): Integer; stdcall;

  TTransacaoCancelamentoPagamento = function (pNumeroControle: PChar): Integer; stdcall;
  TTransacaoPreAutorizacaoCartaoCredito = function (pNumeroControle: PChar): Integer; stdcall;
  TTransacaoConsultaParcelas = function (pNumeroControle: PChar): Integer; stdcall;
  TTransacaoResumoVendas = function (pNumeroControle: PChar): Integer; stdcall;
  TTransacaoReimpressaoCupom = function : Integer; stdcall;

  TConfirmacaoCartao = function (pNumeroControle: PChar): Integer; stdcall;
  TFinalizaTransacao = function : Integer; stdcall;

  TObtemLogUltimaTransacao = procedure (oLogUltimaTransacao: PChar); stdcall;

  TInicializaDPOS = function : Integer; stdcall;
  TFinalizaDPOS = function : Integer; stdcall;

  // Definicao das funcoes de transacao completa
  TTransacaoCartaoCreditoCompleta = function (
      pValorTransacao,   pNumeroCupomVenda, pNumeroControle,
      pTipoOperacao,     pNumeroParcelas,   pValorParcela,   pValorTaxaServico,
      pPermiteAlteracao, pReservado: PChar): Integer; stdcall;

   TTransacaoCartaoDebitoCompleta = function (
      pValorTransacao, pNumeroCupomVenda, pNumeroControle,
      pTipoOperacao,   pNumeroParcelas,   pSequenciaParcela, pDataDebito,
      pValorParcela,   pValorTaxaServico, pPermiteAlteracao, pReservado: PChar): Integer; stdcall;

   TTransacaoCartaoVoucherCompleta = function (
      pValorTransacao, pNumeroCupomVenda, pNumeroControle, pReservado: PChar): Integer; stdcall;

	TTransacaoConciliacaoFinanceiraCompleta = function (
   	pValorTransacao: PChar;	pCodigoEstabelecimento, pData, pHora, pNumeroAutorizadora,
   	pNumeroCartao, pTipoOperacao, pNumeroParcelas, pDataPreDatado, pNumeroControle: PChar): Integer; stdcall;

var
  hDLL  : THandle;

  fTransacaoCheque                        : TTransacaoCheque;

  fTransacaoCartaoCredito                 : TTransacaoCartaoCredito;
  fConfirmaCartaoCredito                  : TConfirmacaoCartaoCredito;

  fTransacaoCartaoDebito                  : TTransacaoCartaoDebito;
  fConfirmaCartaoDebito                   : TConfirmacaoCartaoDebito;

  fTransacaoCartaoVoucher                 : TTransacaoCartaoVoucher;
  fConfirmaCartaoVoucher                  : TConfirmacaoCartaoVoucher;

  fTransacaoCancelamento                  : TTransacaoCancelamentoPagamento;
  fTransacaoPreAutorizacaoCartaoCredito   : TTransacaoPreAutorizacaoCartaoCredito;
  fTransacaoConsultaParcelas              : TTransacaoConsultaParcelas;
  fTransacaoResumoVendas						: TTransacaoResumoVendas;
  fTransacaoReimpressaoCupom					: TTransacaoReimpressaoCupom;

  fConfirmaCartao                  			: TConfirmacaoCartao;
  fFinalizaTransacao                      : TFinalizaTransacao;

  fLogUltimaTransacao							: TObtemLogUltimaTransacao;

  fInicializaDPOS                         : TInicializaDPOS;
  fFinalizaDPOS                           : TFinalizaDPOS;

  fTransacaoCartaoCreditoCompleta         : TTransacaoCartaoCreditoCompleta;
  fTransacaoCartaoDebitoCompleta          : TTransacaoCartaoDebitoCompleta;
  fTransacaoCartaoVoucherCompleta         : TTransacaoCartaoVoucherCompleta;
  fTransacaoConciliacaoFinanceiraCompleta : TTransacaoConciliacaoFinanceiraCompleta;

  procedure memcpy(pDest, pSource: PChar; nBytes: integer);

  function CarregaModuloDPOS:Boolean;
  procedure DescarregaModuloDPOS;

  procedure InicializaDPOS;
  procedure FinalizaDPOS;

  function TransacaoCheque(pValorTransacao, pNumeroCupomVenda, pNumeroControle, pQuantidadeCheques,
               pPeriodicidadeCheques, pDataPrimeiroCheque, pCarenciaPrimeiroCheque: PChar): Integer;

  function TransacaoCartaoCredito(pValorTransacao, pNumeroCupomVenda, pNumeroControle: PChar): Integer;
  function ConfirmaCartaoCredito(pNumeroControle: PChar): Integer;

  function TransacaoCartaoDebito(pValorTransacao, pNumeroCupomVenda, pNumeroControle: PChar): Integer;
  function ConfirmaCartaoDebito(pNumeroControle: PChar): Integer;

  function TransacaoCartaoVoucher(pValorTransacao, pNumeroCupomVenda, pNumeroControle: PChar): Integer;
  function ConfirmaCartaoVoucher(pNumeroControle: PChar): Integer;

  function CancelamentoPagamento(pNumeroControle: PChar): Integer;
  function TransacaoPreAutorizacaoCartaoCredito (pNumeroControle: PChar):Integer;
  function TransacaoConsultaParcelas(pNumeroControle: PChar): Integer;
  function TransacaoResumoVendas(pNumeroControle: PChar): Integer;
  function TransacaoReimpressaoCupom: Integer;

  procedure DadosUltimaTransacao(oLogUltimaTransacao: PChar);

  function ConfirmaCartao(pNumeroControle: PChar): Integer;
  function FinalizaTransacao:Integer;

  function TransacaoCartaoCreditoCompleta (
                  pValorTransacao,   pNumeroCupomVenda, pNumeroControle,
                  pTipoOperacao,     pNumeroParcelas,   pValorParcela,   pValorTaxaServico,
                  pPermiteAlteracao, pReservado: PChar): Integer;

  function TransacaoCartaoDebitoCompleta(
                  pValorTransacao, pNumeroCupomVenda, pNumeroControle,
                  pTipoOperacao,   pNumeroParcelas,   pSequenciaParcela, pDataDebito,
                  pValorParcela,   pValorTaxaServico, pPermiteAlteracao, pReservado: PChar): Integer;

  function TransacaoCartaoVoucherCompleta(
                  pValorTransacao, pNumeroCupomVenda, pNumeroControle, pReservado: PChar): Integer;

  function TransacaoManualPOSCompleta(
   					pValorTransacao, pCodigoEstabelecimento, pData, pHora, pNumeroAutorizadora,
   					pNumeroCartao, pTipoOperacao, pNumeroParcelas, pDataPreDatado, pNumeroControle: PChar): Integer;
  
implementation

procedure memcpy(pDest, pSource: PChar; nBytes: integer);
var
 i: integer;
begin
 for i := 0 to nBytes - 1 do
  pDest[i] := pSource[i];
end;

function CarregaModuloDPOS:Boolean;
begin
   Result := False;

   hDLL := LoadLibrary(PChar('DPOSDRV.DLL'));

   if hDLL < 32 then
   begin
      Exit;
   end;

   fTransacaoCheque                       := GetProcAddress(hDLL,'TransacaoCheque');

   fTransacaoCartaoCredito                := GetProcAddress(hDLL,'TransacaoCartaoCredito');
   fConfirmaCartaoCredito                 := GetProcAddress(hDLL,'ConfirmaCartaoCredito');

   fTransacaoCartaoDebito                 := GetProcAddress(hDLL,'TransacaoCartaoDebito');
   fConfirmaCartaoDebito                  := GetProcAddress(hDLL,'ConfirmaCartaoDebito');

   fTransacaoCartaoVoucher                := GetProcAddress(hDLL,'TransacaoCartaoVoucher');
   fConfirmaCartaoVoucher                 := GetProcAddress(hDLL,'ConfirmaCartaoVoucher');

   fTransacaoCancelamento                 := GetProcAddress(hDLL,'TransacaoCancelamentoPagamento');
   fTransacaoPreAutorizacaoCartaoCredito  := GetProcAddress(hDLL,'TransacaoPreAutorizacaoCartaoCredito');
   fTransacaoConsultaParcelas             := GetProcAddress(hDLL,'TransacaoConsultaParcelas');
   fTransacaoResumoVendas                 := GetProcAddress(hDLL,'TransacaoResumoVendas');
   fTransacaoReimpressaoCupom					:= GetProcAddress(hDLL,'TransacaoReimpressaoCupom');

   fConfirmaCartao                 			:= GetProcAddress(hDLL,'ConfirmaCartao');
   fFinalizaTransacao                     := GetProcAddress(hDLL,'FinalizaTransacao');

   fLogUltimaTransacao							:= GetProcAddress(hDLL,'ObtemLogUltimaTransacao');

   fInicializaDPOS                        := GetProcAddress(hDLL,'InicializaDPOS');
   fFinalizaDPOS                          := GetProcAddress(hDLL,'FinalizaDPOS');

   fTransacaoCartaoCreditoCompleta        := GetProcAddress(hDLL,'TransacaoCartaoCreditoCompleta');
   fTransacaoCartaoDebitoCompleta         := GetProcAddress(hDLL,'TransacaoCartaoDebitoCompleta');
   fTransacaoCartaoVoucherCompleta        := GetProcAddress(hDLL,'TransacaoCartaoVoucherCompleta');
   fTransacaoConciliacaoFinanceiraCompleta:= GetProcAddress(hDLL,'TransacaoManualPOSCompleta');
   
   Result := True;
end;

procedure DescarregaModuloDPOS;
begin
   fTransacaoCheque                       := nil;

   fTransacaoCartaoCredito                := nil;
   fConfirmaCartaoCredito                 := nil;

   fTransacaoCartaoDebito                 := nil;
   fConfirmaCartaoDebito                  := nil;

   fTransacaoCartaoVoucher                := nil;
   fConfirmaCartaoVoucher                 := nil;

   fTransacaoCancelamento                 := nil;
   fTransacaoPreAutorizacaoCartaoCredito  := nil;
   fTransacaoConsultaParcelas             := nil;
   fTransacaoResumoVendas                 := nil;
   fTransacaoReimpressaoCupom					:= nil;

   fConfirmaCartao                        := nil;
   fFinalizaTransacao                     := nil;

   fLogUltimaTransacao							:= nil;

   fInicializaDPOS                        := nil;
   fFinalizaDPOS                          := nil;

   fTransacaoCartaoCreditoCompleta        := nil;
   fTransacaoCartaoDebitoCompleta         := nil;
   fTransacaoCartaoVoucherCompleta        := nil;
   fTransacaoConciliacaoFinanceiraCompleta:= nil;
   
   if hDLL <> 0 then FreeLibrary(hDLL);
end;

procedure InicializaDPOS;
var Ret : Integer;
begin
	Ret := 11;
   if Assigned (fInicializaDPOS) then
      Ret := fInicializaDPOS;
end;

procedure FinalizaDPOS;
begin
   if Assigned (fFinalizaDPOS) then
      fFinalizaDPOS;
end;

function TransacaoCheque (pValorTransacao, pNumeroCupomVenda, pNumeroControle, pQuantidadeCheques,
                        pPeriodicidadeCheques, pDataPrimeiroCheque, pCarenciaPrimeiroCheque: PChar): Integer;
var
   aNSU : Array[0..99] of Char;
begin
	Result := 11;
   if Assigned (fTransacaoCheque) then
      Result := fTransacaoCheque(pValorTransacao, pNumeroCupomVenda, aNSU, pQuantidadeCheques,
                     pPeriodicidadeCheques, pDataPrimeiroCheque, pCarenciaPrimeiroCheque);

   StrCopy(pNumeroControle,aNSU);
end;

function TransacaoCartaoCredito(pValorTransacao, pNumeroCupomVenda, pNumeroControle: PChar): Integer;
var
   aNSU : Array[0..100] of Char;
begin
	Result := 11;
   if Assigned (fTransacaoCartaoCredito) then
         Result := fTransacaoCartaoCredito(pValorTransacao, pNumeroCupomVenda, aNSU);
   StrCopy(pNumeroControle,aNSU);
end;

function ConfirmaCartaoCredito(pNumeroControle: PChar): Integer;
begin
	Result := 11;
   if Assigned (fConfirmaCartaoCredito) then
      Result := fConfirmaCartaoCredito(pNumeroControle);
end;

function TransacaoCartaoDebito(pValorTransacao, pNumeroCupomVenda, pNumeroControle: PChar): Integer;
var
   aNSU : PChar;
begin
	Result := 11;
   aNSU := StrAlloc(100);

   if Assigned (fTransacaoCartaoDebito) then
      Result := fTransacaoCartaoDebito(pValorTransacao, pNumeroCupomVenda, aNSU); //aNSU);

   StrCopy(pNumeroControle,aNSU);
   StrDispose(aNSU);
end;

function ConfirmaCartaoDebito(pNumeroControle: PChar): Integer;
begin
	Result := 11;
   if Assigned (fConfirmaCartaoDebito) then
      Result := fConfirmaCartaoDebito(pNumeroControle);
end;

function TransacaoCartaoVoucher(pValorTransacao, pNumeroCupomVenda, pNumeroControle: PChar): Integer;
begin
	Result := 11;
   if Assigned (fTransacaoCartaoVoucher) then
      Result := fTransacaoCartaoVoucher(pValorTransacao, pNumeroCupomVenda, pNumeroControle);
end;

function ConfirmaCartaoVoucher(pNumeroControle: PChar): Integer;
begin
	Result := 11;
   if Assigned (fConfirmaCartaoVoucher) then
      Result := fConfirmaCartaoVoucher(pNumeroControle);
end;

function CancelamentoPagamento(pNumeroControle: PChar): Integer;
begin
	Result := 11;
   if Assigned (fTransacaoCancelamento) then
      Result := fTransacaoCancelamento(pNumeroControle);
end;

function TransacaoPreAutorizacaoCartaoCredito (pNumeroControle: PChar):Integer;
begin
	Result := 11;
   if Assigned (fTransacaoPreAutorizacaoCartaoCredito) then
      Result := fTransacaoPreAutorizacaoCartaoCredito(pNumeroControle);
end;

function TransacaoConsultaParcelas (pNumeroControle: PChar): Integer;
begin
	Result := 11;
   if Assigned (fTransacaoConsultaParcelas) then
      Result := fTransacaoConsultaParcelas(pNumeroControle);
end;

function TransacaoResumoVendas(pNumeroControle: PChar): Integer;
begin
	Result := 11;
   if Assigned (fTransacaoResumoVendas) then
      Result := fTransacaoResumoVendas(pNumeroControle);
end;

function TransacaoReimpressaoCupom: Integer;
begin
	Result := 11;
   if Assigned (fTransacaoReimpressaoCupom) then
      Result := fTransacaoReimpressaoCupom;
end;

function ConfirmaCartao(pNumeroControle: PChar): Integer;
begin
	Result := 11;
   if Assigned (fConfirmaCartao) then
      Result := fConfirmaCartao(pNumeroControle);
end;

procedure DadosUltimaTransacao(oLogUltimaTransacao: PChar);
begin
   if Assigned (fLogUltimaTransacao) then
      fLogUltimaTransacao(oLogUltimaTransacao);
end;

function FinalizaTransacao:Integer;
begin
	Result := 11;
   if Assigned (fFinalizaTransacao) then
      Result := fFinalizaTransacao;
end;

function TransacaoCartaoCreditoCompleta(
               pValorTransacao,   pNumeroCupomVenda, pNumeroControle,
               pTipoOperacao,     pNumeroParcelas,   pValorParcela,   pValorTaxaServico,
               pPermiteAlteracao, pReservado: PChar): Integer;
begin
   if Assigned(fTransacaoCartaoCreditoCompleta) then
      Result := fTransacaoCartaoCreditoCompleta(
                     pValorTransacao,   pNumeroCupomVenda, pNumeroControle,
                     pTipoOperacao,     pNumeroParcelas,   pValorParcela,   pValorTaxaServico,
                     pPermiteAlteracao, pReservado);

end;

function  TransacaoCartaoDebitoCompleta(pValorTransacao, pNumeroCupomVenda, pNumeroControle,
                                        pTipoOperacao,   pNumeroParcelas,   pSequenciaParcela, pDataDebito,
                                        pValorParcela,   pValorTaxaServico, pPermiteAlteracao, pReservado: PChar): Integer;
begin
   if Assigned(fTransacaoCartaoDebitoCompleta) then
      Result := fTransacaoCartaoDebitoCompleta(
                  pValorTransacao, pNumeroCupomVenda, pNumeroControle,
                  pTipoOperacao,   pNumeroParcelas,   pSequenciaParcela, pDataDebito,
                  pValorParcela,   pValorTaxaServico, pPermiteAlteracao, pReservado);
end;

function  TransacaoCartaoVoucherCompleta(pValorTransacao, pNumeroCupomVenda, pNumeroControle, pReservado: PChar): Integer;
begin
   if Assigned(fTransacaoCartaoVoucherCompleta) then
      Result := fTransacaoCartaoVoucherCompleta(
                  pValorTransacao, pNumeroCupomVenda, pNumeroControle, pReservado);
end;

function  TransacaoManualPOSCompleta(pValorTransacao, pCodigoEstabelecimento, pData, pHora,
	pNumeroAutorizadora, pNumeroCartao, pTipoOperacao, pNumeroParcelas, pDataPreDatado,
   pNumeroControle: PChar): Integer;
begin
   if Assigned(fTransacaoConciliacaoFinanceiraCompleta) then
      Result := fTransacaoConciliacaoFinanceiraCompleta(
      	pValorTransacao, pCodigoEstabelecimento, pData, pHora,
			pNumeroAutorizadora, pNumeroCartao, pTipoOperacao, pNumeroParcelas, pDataPreDatado,
         pNumeroControle);
end;

end.

