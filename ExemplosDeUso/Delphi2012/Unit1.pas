unit Unit1;

interface

uses
  Winapi.Windows, Winapi.Messages, System.SysUtils, System.Variants, System.Classes, Vcl.Graphics,
  Vcl.Controls, Vcl.Forms, Vcl.Dialogs, Vcl.StdCtrls;

type
  TForm1 = class(TForm)
    Button1: TButton;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

  TtransacaoCartaoCredito = function (paValorTransacao, paNumeroCupomVenda, paNumeroControle: PAnsiChar): Integer; stdcall;
  TConfirmaCartao = function (paNumeroControle: PAnsiChar): Integer; stdcall;
  TFinalizaTransacao = function: Integer; stdcall;

var
  Form1: TForm1;
  hDLL: THandle;
  fTransacaoCartaoCredito: TtransacaoCartaoCredito;
  fConfirmaCartao: TConfirmaCartao;
  fFinalizaTransacao: TFinalizaTransacao;

implementation

{$R *.dfm}

function CarregaModuloDPOS: Boolean;
begin
  Result := false;

  hDLL := LoadLibrary(PChar('DPOSDRV.DLL'));
  if hDLL < 32 then
    exit;

  fTransacaoCartaoCredito := GetProcAddress(hDLL, 'TransacaoCartaoCredito');
  fConfirmaCartao := GetProcAddress(hDLL, 'ConfirmaCartao');
  fFinalizaTransacao := GetProcAddress(hDLL, 'FinalizaTransacao');

  Result := true;
end;

procedure DescarregaModuloDPOS;
begin
  fTransacaoCartaoCredito := nil;
  fConfirmaCartao := nil;
  fFinalizaTransacao := nil;

  if hDLL <> 0 then FreeLibrary(hDLL);
end;

function TransacaoCartaoCredito(paValorTransacao, paNumeroCupomVenda, paNumeroControle: PAnsiChar): Integer;
begin
  Result := 11;

  if Assigned (fTransacaoCartaoCredito) then
  begin
    Result := fTransacaoCartaoCredito(paValorTransacao, paNumeroCupomVenda, paNumeroControle);
  end;
end;

function ConfirmaCartao(paNumeroControle: PAnsiChar): Integer;
begin
  Result := 11;

  if Assigned (fConfirmaCartao) then
  begin
    Result := fConfirmaCartao(paNumeroControle);
  end;
end;

function FinalizaTransacaoCartao: Integer;
begin
  Result := 11;

  if Assigned (fFinalizaTransacao) then
  begin
    Result := fFinalizaTransacao;
  end;
end;

procedure TForm1.Button1Click(Sender: TObject);
var
  //paValorTransacao: array[0..12] of AnsiChar;
  //paNumeroCupomVenda: array[0..6] of AnsiChar;
  //paNumeroControle: array[0..6] of AnsiChar;
  paValorTransacao, paNumeroCupomVenda, paNumeroControle: PAnsiChar;
  iRetDPOS, iStatus: Integer;
begin
  // exemplo de uso da DPOSDRV.DLL para uma transação de crédito

  if not CarregaModuloDPOS then
    exit;

  paValorTransacao      := AnsiStrAlloc(12+1); //+1 para o #0
  paNumeroCupomVenda    := AnsiStrAlloc(6+1);
  paNumeroControle      := AnsiStrAlloc(6+1);

  StrPLCopy(paValorTransacao, '000000000500',12);
  StrPLCopy(paNumeroCupomVenda, '000123',6);
  StrPLCopy(paNumeroControle, '000000',6);

  iRetDPOS := TransacaoCartaoCredito(paValorTransacao, paNumeroCupomVenda, paNumeroControle);
  if iRetDPOS = 0 then
  begin
    // se transacao realizada com sucesso ...
      // IMPRIMIR CUPOM DE TEF ...
      // SE IMPRESSAO OK

    iStatus := ConfirmaCartao(paNumeroControle);
    if iStatus = 11 then
      MessageDlg('Transação não pode ser confirmada...', mtInformation, [mbOk], 0);

    FinalizaTransacaoCartao; // SE NAO CONFIRMAR, SERÁ REALIZADO O DESFAZIMENTO NESTA FUNÇÃO!
  end;

  DescarregaModuloDPOS;

  StrDispose(paValorTransacao);
  StrDispose(paNumeroCupomVenda);
  StrDispose(paNumeroControle);
end;

end.
