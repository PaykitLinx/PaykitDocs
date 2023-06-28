unit Unit1;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  StdCtrls, uDPOSDLL;

type

  TForm1 = class(TForm)
    btnCC: TButton;
    btnCD: TButton;
    btnCV: TButton;
    btnCancelamento: TButton;
    btnResumo: TButton;
    btnConsultaParcelas: TButton;
    btnReimpressao: TButton;
    btnPreAut: TButton;
    GroupBox1: TGroupBox;
    Button1: TButton;
    Button2: TButton;
    Button3: TButton;
    Button4: TButton;
    Button5: TButton;
    procedure btnCCClick(Sender: TObject);
    procedure btnCDClick(Sender: TObject);
    procedure btnCVClick(Sender: TObject);
    procedure btnCancelamentoClick(Sender: TObject);
    procedure btnResumoClick(Sender: TObject);
    procedure btnConsultaParcelasClick(Sender: TObject);
    procedure btnReimpressaoClick(Sender: TObject);
    procedure btnPreAutClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure Button3Click(Sender: TObject);
    procedure Button4Click(Sender: TObject);
    procedure Button5Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  Form1: TForm1;

implementation

{$R *.DFM}

procedure TForm1.btnCCClick(Sender: TObject);
var
   pValorTransacao, pNumeroCupomVenda, pNumeroControle : PChar;
   RetDPOS, nStatus 	: Integer;
begin
   if not CarregaModuloDPOS then
      exit;

   pValorTransacao      := StrAlloc(100);
   pNumeroCupomVenda    := StrAlloc(100);
   pNumeroControle      := StrAlloc(100);

	StrPLCopy(pValorTransacao,'000000000100',12);
	StrPLCopy(pNumeroCupomVenda,'000123',6);
	StrPLCopy(pNumeroControle,'',6);

	pValorTransacao[12]  := #0;
	pNumeroCupomVenda[6]      := #0;
	pNumeroControle[6]   := #0;

   RetDPOS := TransacaoCartaoCredito(pValorTransacao, pNumeroCupomVenda, pNumeroControle);
	if RetDPOS = 0 then
	  begin // transacao realizada com sucesso ...

       // IMPRIMIR CUPOM DE TEF ...

       // SE IMPRESSAO OK
       begin
       	nStatus        := ConfirmaCartaoCredito(pNumeroControle);
         if nStatus = 11 then
         	MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);
       end;

       FinalizaTransacao; // SE NAO CONFIRMAR, EH REALIZADO O DESFAZIMENTO!
	  end;

   DescarregaModuloDPOS;

   if (pValorTransacao <> nil) then StrDispose(pValorTransacao);
   if (pNumeroCupomVenda <> nil) then StrDispose(pNumeroCupomVenda);
   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);
end;

procedure TForm1.btnCDClick(Sender: TObject);
var
   pValorTransacao, pNumeroCupomVenda, pNumeroControle : PChar;
   RetDPOS, nStatus : Integer;
begin
   if not CarregaModuloDPOS then
      exit;

   pValorTransacao      := StrAlloc(100);
   pNumeroCupomVenda    := StrAlloc(100);
   pNumeroControle      := StrAlloc(100);

	StrPLCopy(pValorTransacao,'000000002500',12);
	StrPLCopy(pNumeroCupomVenda,'000123',6);
	StrPLCopy(pNumeroControle,'',6);

	pValorTransacao[12]  := #0;
	pNumeroCupomVenda[6] := #0;
	pNumeroControle[6]   := #0;

   RetDPOS := TransacaoCartaoDebito (pValorTransacao, pNumeroCupomVenda, pNumeroControle);
   if RetDPOS <> 0 then
   begin
   	//TRANSACAO NAO REALIZADA
   end
   else
    begin // transacao realizada com sucesso ...

       // IMPRIMIR CUPOM DE TEF ...

       // SE IMPRESSAO OK
       begin
       	nStatus := ConfirmaCartaoDebito(pNumeroControle);
         if nStatus = 11 then
         	MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);
       end;

       FinalizaTransacao; // SE NAO CONFIRMAR, EH REALIZADO O DESFAZIMENTO!
    end;

   DescarregaModuloDPOS;

   if (pValorTransacao <> nil) then StrDispose(pValorTransacao);
   if (pNumeroCupomVenda <> nil) then StrDispose(pNumeroCupomVenda);
   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);
end;

procedure TForm1.btnCVClick(Sender: TObject);
var
   pValorTransacao, pNumeroCupomVenda,  pNumeroControle : PChar;
   RetDPOS, nStatus : Integer;
begin
   if not CarregaModuloDPOS then
      exit;

   pValorTransacao      := StrAlloc(100);
   pNumeroCupomVenda    := StrAlloc(100);
   pNumeroControle      := StrAlloc(100);

	StrPLCopy(pValorTransacao,'000000000100',12);
	StrPLCopy(pNumeroCupomVenda,'000123',6);
	StrPLCopy(pNumeroControle,'',6);

	pValorTransacao[12]  := #0;
	pNumeroCupomVenda[6]      := #0;
	pNumeroControle[6]   := #0;

   RetDPOS := TransacaoCartaoVoucher(pValorTransacao, pNumeroCupomVenda, pNumeroControle);
	if RetDPOS <> 0 then
	  begin
	  		// TRANSACAO NAO REALIZADA ...
	  end
	  else
	  begin // transacao realizada com sucesso ...

       // IMPRIMIR CUPOM DE TEF ...

       // SE IMPRESSAO OK
       begin
       	nStatus        := ConfirmaCartaoVoucher(pNumeroControle);
         if nStatus = 11 then
         	MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);
       end;

       FinalizaTransacao; // SE NAO CONFIRMAR, EH REALIZADO O DESFAZIMENTO!
	  end;

   DescarregaModuloDPOS;

   if (pValorTransacao <> nil) then StrDispose(pValorTransacao);
   if (pNumeroCupomVenda <> nil) then StrDispose(pNumeroCupomVenda);
   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);
end;

procedure TForm1.btnCancelamentoClick(Sender: TObject);
var
   pNumeroControle   : PChar;
   RetDPOS, nStatus	: Integer;
begin
   if not CarregaModuloDPOS then
      exit;

   pNumeroControle      := StrAlloc(100);

   StrPLCopy(pNumeroControle,'000000',6);
   pNumeroControle[6]   := #0;

   RetDPOS := CancelamentoPagamento(pNumeroControle);
	if RetDPOS <> 0 then
	  begin
	  		// TRANSACAO NAO REALIZADA ...
	  end
	  else
	  begin // transacao realizada com sucesso ...

       // IMPRIMIR CUPOM DE TEF ...

       // SE IMPRESSAO OK
       begin
       	nStatus        := ConfirmaCartao(pNumeroControle);
         if nStatus = 11 then
         	MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);
       end;

       FinalizaTransacao; // SE NAO CONFIRMAR, EH REALIZADO O DESFAZIMENTO!
	  end;

   DescarregaModuloDPOS;

   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);
end;

procedure TForm1.btnResumoClick(Sender: TObject);
var
   pNumeroControle   	: PChar;
   RetDPOS, nStatus	 	: Integer;
begin
   if not CarregaModuloDPOS then
      exit;

   pNumeroControle      := StrAlloc(100);

   StrPLCopy(pNumeroControle,'000000',6);
   pNumeroControle[6]   := #0;

   RetDPOS := TransacaoResumoVendas(pNumeroControle);
   if RetDPOS = 0 then
      begin
      	// transacao realizada com sucesso ...

       	// IMPRIMIR CUPOM DE TEF ...

         // SE IMPRESSAO OK
         begin
           nStatus        := ConfirmaCartao(pNumeroControle);
           if nStatus = 11 then
              MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);
         end;

         FinalizaTransacao; // SE NAO CONFIRMAR, EH REALIZADO O DESFAZIMENTO!
      end
   else
      begin
      	// transacao nao realizada
      end;

   DescarregaModuloDPOS;
end;

procedure TForm1.btnConsultaParcelasClick(Sender: TObject);
var
   RetDPOS : Integer;
   pNumeroControle : PChar;
begin
   if not CarregaModuloDPOS then
      exit;

   pNumeroControle      := StrAlloc(100);

   StrPLCopy(pNumeroControle,'000000',6);
   pNumeroControle[6]   := #0;

   RetDPOS := TransacaoConsultaParcelas(pNumeroControle);
   if RetDPOS = 0 then
      begin
      	// transacao realizada com sucesso ...

       	// IMPRIMIR CUPOM DE TEF ...
      end
   else
      begin
      	// transacao nao realizada
      end;

   StrDispose(pNumeroControle);

   DescarregaModuloDPOS;
end;

procedure TForm1.btnReimpressaoClick(Sender: TObject);
var
   nStatus: Integer;
begin
   if not CarregaModuloDPOS then
      exit;

	nStatus := TransacaoReimpressaoCupom;

   if nStatus = 0 then
   begin
   	// transacao realizada com sucesso
   	// imprimir arquivo ULTIMO.PRN
   end;

   DescarregaModuloDPOS;
end;

procedure TForm1.btnPreAutClick(Sender: TObject);
var
   RetDPOS : Integer;
   pNumeroControle : PChar;
begin
   if not CarregaModuloDPOS then
      exit;

   pNumeroControle      := StrAlloc(100);
	StrPLCopy(pNumeroControle,'000000',6);
	pNumeroControle[6]   := #0;

   RetDPOS := TransacaoPreAutorizacaoCartaoCredito (pNumeroControle);
	if RetDPOS = 0 then
	  begin
     	// transacao realizada com sucesso ...

      // IMPRIMIR CUPOM DE TEF ...
	  end;

   DescarregaModuloDPOS;

   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);
end;

procedure TForm1.Button1Click(Sender: TObject);
var
   pValorTransacao,
   pNumeroCupomVenda,
   pNumeroControle   : PChar;
   RetDPOS,
   nStatus           : Integer;

   pTipoOperacao,	    pNumeroParcelas, pValorParcela, pValorTaxaServico,
   pPermiteAlteracao, pReservado : PChar;
begin
   if not CarregaModuloDPOS then
      exit;

   pValorTransacao      := StrAlloc(100);
   pNumeroCupomVenda    := StrAlloc(100);
   pNumeroControle      := StrAlloc(100);
   pTipoOperacao        := StrAlloc(3);
   pNumeroParcelas      := StrAlloc(3);
   pValorParcela        := StrAlloc(13);
   pValorTaxaServico    := StrAlloc(13);
   pPermiteAlteracao    := StrAlloc(2);
   pReservado           := StrAlloc(160);

	StrPLCopy(pValorTransacao,'000000050000',12);
	StrPLCopy(pNumeroCupomVenda,'000123',6);
	StrPLCopy(pNumeroControle,'',6);
   // Dados Adicionais ...
	StrPLCopy(pTipoOperacao, 'FA', 2);
    StrPLCopy(pNumeroParcelas, '02', 2);
    StrPLCopy(pValorParcela, '000000000000', 12);
    StrPLCopy(pValorTaxaServico, '000000000000', 12);
    StrPLCopy(pPermiteAlteracao, 'S', 1);
    StrPLCopy(pReservado, '', 158);

	pValorTransacao[12]  := #0;
	pNumeroCupomVenda[6] := #0;
	pNumeroControle[6]   := #0;

   RetDPOS := TransacaoCartaoCreditoCompleta(
                  pValorTransacao,   pNumeroCupomVenda, pNumeroControle,
	               pTipoOperacao,     pNumeroParcelas,   pValorParcela,
                  pValorTaxaServico, pPermiteAlteracao, pReservado);

	if RetDPOS <> 0 then
	  begin
	  		// TRANSACAO NAO REALIZADA ...
	  end
	  else
	  begin // transacao realizada com sucesso ...

      	// IMPRIMIR CUPOM DE TEF ...

         // SE IMPRESSAO OK, CONFIRMA TRANSACAO
         	nStatus        := ConfirmaCartaoCredito(pNumeroControle);

         	if nStatus = 11 then
            	MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);

         FinalizaTransacao; // SE NAO CONFIRMAR, EH REALIZADO O DESFAZIMENTO!
	  end;

   DescarregaModuloDPOS;

   if (pValorTransacao <> nil) then StrDispose(pValorTransacao);
   if (pNumeroCupomVenda <> nil) then StrDispose(pNumeroCupomVenda);
   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);

   if (pTipoOperacao <> nil) then StrDispose(pTipoOperacao);
   if (pNumeroParcelas <> nil) then StrDispose(pNumeroParcelas);
   if (pValorParcela <> nil) then StrDispose(pValorParcela);
   if (pValorTaxaServico <> nil) then StrDispose(pValorTaxaServico);
   if (pPermiteAlteracao <> nil) then StrDispose(pPermiteAlteracao);
   if (pReservado <> nil) then StrDispose(pReservado);
end;

procedure TForm1.Button2Click(Sender: TObject);
var
   pValorTransacao,
   pNumeroCupomVenda,
   pNumeroControle                      : PChar;
   RetDPOS,
   nStatus, nAuxCont, NumeroParcelas    : Integer;

   oDadosAdicionaisCartaoCredito : TDadosAdicionaisCartaoCredito;
   oDadosAdicionaisCartaoDebito  : TDadosAdicionaisCartaoDebito;

	pTipoOperacao,	    pNumeroParcelas, pValorParcela, pValorTaxaServico,
   pPermiteAlteracao, pReservado : PChar;

begin
   if not CarregaModuloDPOS then
      exit;

   pValorTransacao      := StrAlloc(100);
   pNumeroCupomVenda    := StrAlloc(100);
   pNumeroControle      := StrAlloc(100);
	pTipoOperacao        := StrAlloc(3);
   pNumeroParcelas      := StrAlloc(3);
   pValorParcela        := StrAlloc(13);
   pValorTaxaServico    := StrAlloc(13);
   pPermiteAlteracao    := StrAlloc(2);
   pReservado           := StrAlloc(160);

	StrPLCopy(pValorTransacao,'000000000000',12);
	StrPLCopy(pNumeroCupomVenda,'000123',6);
	StrPLCopy(pNumeroControle,'',6);
   // Dados Adicionais ...
   (*
	StrPLCopy(pTipoOperacao, 'FL', 2);
   StrPLCopy(pNumeroParcelas, '00', 2);
   StrPLCopy(pValorParcela, '000000000100', 12);
   StrPLCopy(pValorTaxaServico, '000000000000', 12);
   StrPLCopy(pPermiteAlteracao, 'N', 1);
   StrPLCopy(pReservado, '', 158);
   *)
	pValorTransacao[12]  := #0;
	pNumeroCupomVenda[6] := #0;
	pNumeroControle[6]   := #0;

   //TRANSACAO A VISTA...
	nAuxCont := 1;
   NumeroParcelas := 1;
   while (nAuxCont <= NumeroParcelas) do
   begin
	   // obtem Dados Adicionais ...
	   memcpy(@oDadosAdicionaisCartaoDebito.aTipoOperacao[1],PChar('AV'),2);
	   memcpy(@oDadosAdicionaisCartaoDebito.aNumeroParcelas[1],PChar(Format('%2.2d',[NumeroParcelas])),2);
	   memcpy(@oDadosAdicionaisCartaoDebito.aSequenciaParcela[1],PChar(Format('%2.2d',[nAuxCont])),2);
	   memcpy(@oDadosAdicionaisCartaoDebito.aDataDebito[1],PChar('01122001'),8);
	   memcpy(@oDadosAdicionaisCartaoDebito.aValorParcela[1],PChar('000000005000'),12);
	   memcpy(@oDadosAdicionaisCartaoDebito.aValorTaxaServico[1],PChar('000000000000'),12);
	   memcpy(@oDadosAdicionaisCartaoDebito.aPermiteAlteracao[1],'S',1);
	   memcpy(@oDadosAdicionaisCartaoDebito.aReservado[1],'',148);

      RetDPOS := TransacaoCartaoDebitoCompleta(pValorTransacao, pNumeroCupomVenda, pNumeroControle,
                      @oDadosAdicionaisCartaoDebito.aTipoOperacao[1],
                      @oDadosAdicionaisCartaoDebito.aNumeroParcelas[1],
                      @oDadosAdicionaisCartaoDebito.aSequenciaParcela[1],
                      @oDadosAdicionaisCartaoDebito.aDataDebito[1],
                      @oDadosAdicionaisCartaoDebito.aValorParcela[1],
                      @oDadosAdicionaisCartaoDebito.aValorTaxaServico[1],
                      @oDadosAdicionaisCartaoDebito.aPermiteAlteracao[1],
                      @oDadosAdicionaisCartaoDebito.aReservado[1]);

		INC(nAuxCont);
	end;

	if RetDPOS <> 0 then
	  begin
	  		// TRANSACAO NAO REALIZADA ...
	  end
	  else
	  begin // transacao realizada com sucesso ...

      	// IMPRIMIR CUPOM DE TEF ...

         // SE IMPRESSAO OK, CONFIRMA TRANSACAO
           nStatus        := ConfirmaCartaoCredito(pNumeroControle);

           if nStatus = 11 then
              MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);

         FinalizaTransacao; // SE NAO CONFIRMAR, EH REALIZADO O DESFAZIMENTO!
	  end;

   DescarregaModuloDPOS;

   if (pValorTransacao <> nil) then StrDispose(pValorTransacao);
   if (pNumeroCupomVenda <> nil) then StrDispose(pNumeroCupomVenda);
   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);

   if (pTipoOperacao <> nil) then StrDispose(pTipoOperacao);
   if (pNumeroParcelas <> nil) then StrDispose(pNumeroParcelas);
   if (pValorParcela <> nil) then StrDispose(pValorParcela);
   if (pValorTaxaServico <> nil) then StrDispose(pValorTaxaServico);
   if (pPermiteAlteracao <> nil) then StrDispose(pPermiteAlteracao);
   if (pReservado <> nil) then StrDispose(pReservado);
end;

procedure TForm1.Button3Click(Sender: TObject);
var
   pValorTransacao,
   pNumeroCupomVenda,
   pNumeroControle   : PChar;
   pReservado        : PChar;
   RetDPOS,
   nStatus           : Integer;
//   oDadosUltimaTransacao         : TDadosUltimaTransacao;
begin
   if not CarregaModuloDPOS then
      exit;

   pValorTransacao      := StrAlloc(100);
   pNumeroCupomVenda    := StrAlloc(100);
   pNumeroControle      := StrAlloc(100);
   pReservado           := StrAlloc(258);

	StrPLCopy(pValorTransacao,'000000000100',12);
	StrPLCopy(pNumeroCupomVenda,'000123',6);
	StrPLCopy(pNumeroControle,'',6);
   StrPLCopy(pReservado, '', 10);

	pValorTransacao[12]  := #0;
	pNumeroCupomVenda[6] := #0;
	pNumeroControle[6]   := #0;
   pReservado[10]       := #0;

   // obtem Dados Adicionais ...
   //StrLCopy(@oDadosAdicionaisCartaoVoucher.aReservado[1],'',187);

   RetDPOS := TransacaoCartaoVoucherCompleta(pValorTransacao, pNumeroCupomVenda, pNumeroControle, pReservado);
	if RetDPOS <> 0 then
	  begin
	  		// TRANSACAO NAO REALIZADA ...
	  end
	  else
	  begin // transacao realizada com sucesso ...

      	// IMPRIMIR CUPOM DE TEF ...

         // SE IMPRESSAO OK
             nStatus        := ConfirmaCartaoVoucher(pNumeroControle);

             if nStatus = 0 then
                begin
                   nStatus  := FinalizaTransacao;

                   if nStatus = 0 then
                      MessageDlg('Transação concluída com sucesso...', mtWarning, [mbOk], 0)
                   else
                      MessageDlg('Transação não pode ser concluída...', mtInformation, [mbOk], 0);
                end
             else
                MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);
	  end;

   DescarregaModuloDPOS;

   if (pValorTransacao <> nil) then StrDispose(pValorTransacao);
   if (pNumeroCupomVenda <> nil) then StrDispose(pNumeroCupomVenda);
   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);
end;

procedure TForm1.Button4Click(Sender: TObject);
var
   pValorTransacao,
   pNumeroCupomVenda,
   pNumeroControle                      : PChar;
   RetDPOS,
   nStatus, nAuxCont, NumeroParcelas    : Integer;

   oDadosAdicionaisCartaoCredito : TDadosAdicionaisCartaoCredito;
   oDadosAdicionaisCartaoDebito  : TDadosAdicionaisCartaoDebito;

	pTipoOperacao,	    pNumeroParcelas, pValorParcela, pValorTaxaServico,
   pPermiteAlteracao, pReservado : PChar;

   Data, DiaAtual, MesAtual, AnoAtual : String;

begin
   if not CarregaModuloDPOS then
      exit;

   pValorTransacao      := StrAlloc(100);
   pNumeroCupomVenda    := StrAlloc(100);
   pNumeroControle      := StrAlloc(100);
	pTipoOperacao        := StrAlloc(3);
   pNumeroParcelas      := StrAlloc(3);
   pValorParcela        := StrAlloc(13);
   pValorTaxaServico    := StrAlloc(13);
   pPermiteAlteracao    := StrAlloc(2);
   pReservado           := StrAlloc(160);

	StrPLCopy(pValorTransacao,'000000000000',12);
	StrPLCopy(pNumeroCupomVenda,'000123',6);
	StrPLCopy(pNumeroControle,'',6);
   // Dados Adicionais ...
   (*
	StrPLCopy(pTipoOperacao, 'FL', 2);
   StrPLCopy(pNumeroParcelas, '00', 2);
   StrPLCopy(pValorParcela, '000000000100', 12);
   StrPLCopy(pValorTaxaServico, '000000000000', 12);
   StrPLCopy(pPermiteAlteracao, 'N', 1);
   StrPLCopy(pReservado, '', 158);
   *)
	pValorTransacao[12]  := #0;
	pNumeroCupomVenda[6] := #0;
	pNumeroControle[6]   := #0;

	nAuxCont := 1;

   NumeroParcelas := 3;
   while (nAuxCont <= NumeroParcelas) do
   begin
	   // obtem Dados Adicionais ...
	   memcpy(@oDadosAdicionaisCartaoDebito.aTipoOperacao[1],PChar('PS'),2);
	   memcpy(@oDadosAdicionaisCartaoDebito.aNumeroParcelas[1],PChar(Format('%2.2d',[NumeroParcelas])),2);
	   memcpy(@oDadosAdicionaisCartaoDebito.aSequenciaParcela[1],PChar(Format('%2.2d',[nAuxCont])),2);

      DiaAtual := '01'; //FormatDateTime('dd',Date);
      MesAtual := FormatDateTime('mm',Date);
      AnoAtual := FormatDateTime('yyyy',Date);
      if ((StrToInt(MesAtual)+nAuxCont) > 12) then
         Data := DiaAtual + Format('%2.2d',[((StrToInt(MesAtual)+nAuxCont)-12)]) + AnoAtual
      else
         Data := DiaAtual + Format('%2.2d',[(StrToInt(MesAtual)+nAuxCont)]) + AnoAtual;

	   memcpy(@oDadosAdicionaisCartaoDebito.aDataDebito[1],PChar(Data),8);
	   memcpy(@oDadosAdicionaisCartaoDebito.aValorParcela[1],PChar('000000001000'),12);
	   memcpy(@oDadosAdicionaisCartaoDebito.aValorTaxaServico[1],PChar('000000000000'),12);
	   memcpy(@oDadosAdicionaisCartaoDebito.aPermiteAlteracao[1],'S',1);
	   memcpy(@oDadosAdicionaisCartaoDebito.aReservado[1],'',148);

      RetDPOS := TransacaoCartaoDebitoCompleta(pValorTransacao, pNumeroCupomVenda, pNumeroControle,
                      @oDadosAdicionaisCartaoDebito.aTipoOperacao[1],
                      @oDadosAdicionaisCartaoDebito.aNumeroParcelas[1],
                      @oDadosAdicionaisCartaoDebito.aSequenciaParcela[1],
                      @oDadosAdicionaisCartaoDebito.aDataDebito[1],
                      @oDadosAdicionaisCartaoDebito.aValorParcela[1],
                      @oDadosAdicionaisCartaoDebito.aValorTaxaServico[1],
                      @oDadosAdicionaisCartaoDebito.aPermiteAlteracao[1],
                      @oDadosAdicionaisCartaoDebito.aReservado[1]);

		INC(nAuxCont);
	end;

	if RetDPOS <> 0 then
	  begin
	  		// TRANSACAO NAO REALIZADA ...
	  end
	  else
	  begin // transacao realizada com sucesso ...

      	// IMPRIMIR CUPOM DE TEF ...

         // SE IMPRESSAO OK, CONFIRMA TRANSACAO
           nStatus        := ConfirmaCartaoCredito(pNumeroControle);

           if nStatus = 11 then
              MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);

         FinalizaTransacao; // SE NAO CONFIRMAR, EH REALIZADO O DESFAZIMENTO!
	  end;

   DescarregaModuloDPOS;

   if (pValorTransacao <> nil) then StrDispose(pValorTransacao);
   if (pNumeroCupomVenda <> nil) then StrDispose(pNumeroCupomVenda);
   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);

	if (pTipoOperacao <> nil) then StrDispose(pTipoOperacao);
   if (pNumeroParcelas <> nil) then StrDispose(pNumeroParcelas);
   if (pValorParcela <> nil) then StrDispose(pValorParcela);
   if (pValorTaxaServico <> nil) then StrDispose(pValorTaxaServico);
   if (pPermiteAlteracao <> nil) then StrDispose(pPermiteAlteracao);
   if (pReservado <> nil) then StrDispose(pReservado);
end;

procedure TForm1.Button5Click(Sender: TObject);
var
   pValorTransacao,
   pNumeroCupomVenda,
   pNumeroControle                      : PChar;
   RetDPOS,
   nStatus, nAuxCont, NumeroParcelas    : Integer;

   oDadosAdicionaisCartaoCredito : TDadosAdicionaisCartaoCredito;
   oDadosAdicionaisCartaoDebito  : TDadosAdicionaisCartaoDebito;

	pTipoOperacao,	    pNumeroParcelas, pValorParcela, pValorTaxaServico,
   pPermiteAlteracao, pReservado : PChar;

begin
   if not CarregaModuloDPOS then
      exit;

   pValorTransacao      := StrAlloc(100);
   pNumeroCupomVenda    := StrAlloc(100);
   pNumeroControle      := StrAlloc(100);
	pTipoOperacao        := StrAlloc(3);
   pNumeroParcelas      := StrAlloc(3);
   pValorParcela        := StrAlloc(13);
   pValorTaxaServico    := StrAlloc(13);
   pPermiteAlteracao    := StrAlloc(2);
   pReservado           := StrAlloc(160);

	StrPLCopy(pValorTransacao,'000000000000',12);
	StrPLCopy(pNumeroCupomVenda,'000123',6);
	StrPLCopy(pNumeroControle,'',6);
   // Dados Adicionais ...
   (*
	StrPLCopy(pTipoOperacao, 'FL', 2);
   StrPLCopy(pNumeroParcelas, '00', 2);
   StrPLCopy(pValorParcela, '000000000100', 12);
   StrPLCopy(pValorTaxaServico, '000000000000', 12);
   StrPLCopy(pPermiteAlteracao, 'N', 1);
   StrPLCopy(pReservado, '', 158);
   *)
	pValorTransacao[12]  := #0;
	pNumeroCupomVenda[6] := #0;
	pNumeroControle[6]   := #0;

   //TRANSACAO PRE-DATADA...
	nAuxCont := 1;
   NumeroParcelas := 1;
   while (nAuxCont <= NumeroParcelas) do
   begin
	   // obtem Dados Adicionais ...
	   memcpy(@oDadosAdicionaisCartaoDebito.aTipoOperacao[1],PChar('PD'),2);
	   memcpy(@oDadosAdicionaisCartaoDebito.aNumeroParcelas[1],PChar(Format('%2.2d',[NumeroParcelas])),2);
	   memcpy(@oDadosAdicionaisCartaoDebito.aSequenciaParcela[1],PChar(Format('%2.2d',[nAuxCont])),2);
	   memcpy(@oDadosAdicionaisCartaoDebito.aDataDebito[1],PChar('00000000'),8);
	   memcpy(@oDadosAdicionaisCartaoDebito.aValorParcela[1],PChar('000000005000'),12);
	   memcpy(@oDadosAdicionaisCartaoDebito.aValorTaxaServico[1],PChar('000000000000'),12);
	   memcpy(@oDadosAdicionaisCartaoDebito.aPermiteAlteracao[1],'N',1);
	   memcpy(@oDadosAdicionaisCartaoDebito.aReservado[1],'',148);

      RetDPOS := TransacaoCartaoDebitoCompleta(pValorTransacao, pNumeroCupomVenda, pNumeroControle,
                      @oDadosAdicionaisCartaoDebito.aTipoOperacao[1],
                      @oDadosAdicionaisCartaoDebito.aNumeroParcelas[1],
                      @oDadosAdicionaisCartaoDebito.aSequenciaParcela[1],
                      @oDadosAdicionaisCartaoDebito.aDataDebito[1],
                      @oDadosAdicionaisCartaoDebito.aValorParcela[1],
                      @oDadosAdicionaisCartaoDebito.aValorTaxaServico[1],
                      @oDadosAdicionaisCartaoDebito.aPermiteAlteracao[1],
                      @oDadosAdicionaisCartaoDebito.aReservado[1]);

		INC(nAuxCont);
	end;

	if RetDPOS <> 0 then
	  begin
	  		// TRANSACAO NAO REALIZADA ...
	  end
	  else
	  begin // transacao realizada com sucesso ...

      	// IMPRIMIR CUPOM DE TEF ...

         // SE IMPRESSAO OK, CONFIRMA TRANSACAO
         	nStatus        := ConfirmaCartaoCredito(pNumeroControle);

         	if nStatus = 11 then
            	MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);

         FinalizaTransacao; // SE NAO CONFIRMAR, EH REALIZADO O DESFAZIMENTO!
	  end;

   DescarregaModuloDPOS;

   if (pValorTransacao <> nil) then StrDispose(pValorTransacao);
   if (pNumeroCupomVenda <> nil) then StrDispose(pNumeroCupomVenda);
   if (pNumeroControle <> nil) then StrDispose(pNumeroControle);

	if (pTipoOperacao <> nil) then StrDispose(pTipoOperacao);
   if (pNumeroParcelas <> nil) then StrDispose(pNumeroParcelas);
   if (pValorParcela <> nil) then StrDispose(pValorParcela);
   if (pValorTaxaServico <> nil) then StrDispose(pValorTaxaServico);
   if (pPermiteAlteracao <> nil) then StrDispose(pPermiteAlteracao);
   if (pReservado <> nil) then StrDispose(pReservado);
end;

end.
