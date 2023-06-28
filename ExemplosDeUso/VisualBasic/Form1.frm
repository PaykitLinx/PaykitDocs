VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "Form1"
   ClientHeight    =   6315
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4170
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   6315
   ScaleWidth      =   4170
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command5 
      Caption         =   "Transação de Cheque"
      Height          =   615
      Left            =   240
      TabIndex        =   6
      Top             =   5040
      Width           =   3615
   End
   Begin VB.CommandButton Command4 
      Caption         =   "Pré-Autorização de Cartão de Crédito"
      Height          =   615
      Left            =   240
      TabIndex        =   5
      Top             =   4200
      Width           =   3615
   End
   Begin VB.CommandButton Command2 
      Caption         =   "Consulta Parcelas"
      Height          =   615
      Left            =   240
      TabIndex        =   4
      Top             =   3480
      Width           =   3615
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Configura DPOS"
      Height          =   615
      Left            =   240
      TabIndex        =   3
      Top             =   120
      Width           =   3615
   End
   Begin VB.CommandButton Command3 
      Caption         =   "Transação Cartão Débito"
      Height          =   615
      Left            =   240
      TabIndex        =   2
      Top             =   1800
      Width           =   3615
   End
   Begin VB.CommandButton btnCancelamento 
      Caption         =   "Cancelamento Pagamento"
      Height          =   615
      Left            =   240
      TabIndex        =   1
      Top             =   2760
      Width           =   3615
   End
   Begin VB.CommandButton btnCartaoCredito 
      Caption         =   "Transação Cartão Crédito"
      Height          =   615
      Left            =   240
      TabIndex        =   0
      Top             =   1080
      Width           =   3615
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Declare Function ConfiguraDPOS Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" () As Long
Private Declare Function InicializaDPOS Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" () As Long
Private Declare Function FinalizaDPOS Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" () As Long

Private Declare Function TransacaoCartaoCredito Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" _
     (ByVal pValorTransacao As String, ByVal pNumeroCupom As String, _
      ByVal pNumeroControle As String) As Long
      
Private Declare Function TransacaoCartaoDebito Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" _
    (ByVal pValorTransacao As String, ByVal pNumeroCupom As String, _
     ByVal pNumeroControle As String) As Long

Private Declare Function TransacaoCheque Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" _
    (ByVal pValorTransacao As String, ByVal pNumeroCupom As String, _
     ByVal pNumeroControle As String, ByVal pQuantidadeCheques As String, _
     ByVal pPeriodicidadeCheques As String, ByVal pDataPrimeiroCheque As String, _
     ByVal pCarenciaPrimeiroCheque As String) As Long

Private Declare Function TransacaoCancelamentoPagamento Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" _
    (ByVal pNumeroControle As String) As Long
    
Private Declare Function ConfirmaCartaoCredito Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" (ByVal pNumeroControle As String) As Long
Private Declare Function ConfirmaCartaoDebito Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" (ByVal pNumeroControle As String) As Long

Private Declare Function FinalizaTransacao Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" () As Long

Private Declare Function TransacaoConsultaParcelas Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" (ByVal pNumeroControle As String) As Long
Private Declare Function TransacaoPreAutorizacaoCartaoCredito Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" (ByVal pNumeroControle As String) As Long
Private Declare Function TransacaoResumoVendas Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" (ByVal pNumeroControle As String) As Long
Private Declare Function TransacaoReimpressaoCupom Lib "C:\DPOS3X25\BIN\DPOSDRV.DLL" () As Long
     
Private Sub btnCancelamento_Click()
    Dim sNSU As String '* 7
    Dim retStatus As Long
    
    sNSU = "000000" ' ESTA FORMATACAO EH IMPORTANTE, SEM ELA DAH GPF!
    
    retStatus = TransacaoCancelamentoPagamento(sNSU)
    
    MsgBox "Número de Controle: " & sNSU
    
    ' SE A TRANSACAO FOR APROVADA (retStatus=0), DEVE-SE IMPRIMIR O
    ' COMPROVANTE DA TRANSACAO
    ' SE A IMPRESSÃO DO COMPROVANTE FOR EFETUADA COM SUCESSO, CONFIRMAR TRANSACAO
    
    If retStatus = 0 Then ' SE IMPRESSAO OK
        retStatus = ConfirmaCartaoCredito(sNSU)
    End If
       
    FinalizaTransacao
End Sub

Private Sub btnCartaoCredito_Click()
    Dim sValor As String '* 13
    Dim sCupom As String '* 7
    Dim sNSU As String '* 7
    Dim retStatus As Long
    
    sValor = Trim(Format("10000", "000000000000")) 'VALOR DE TESTE
    sCupom = Trim(Format("123", "000000")) 'VALOR DE TESTE

    sNSU = "000000" ' ESTA FORMATACAO EH IMPORTANTE, SEM ELA DAH GPF!
    retStatus = TransacaoCartaoCredito(sValor, sCupom, sNSU)
    
    MsgBox "Número de Controle: " & sNSU
       
    ' SE A TRANSACAO FOR APROVADA (retStatus=0), DEVE-SE IMPRIMIR O
    ' COMPROVANTE DA TRANSACAO
    ' SE A IMPRESSÃO DO COMPROVANTE FOR EFETUADA COM SUCESSO, CONFIRMAR TRANSACAO
    
    If retStatus = 0 Then ' SE IMPRESSAO OK
        retStatus = ConfirmaCartaoCredito(sNSU)
    End If
    
    FinalizaTransacao
    
    MsgBox "VAI ENCERRAR A FUNÇÃO DE CRÉDITO..."
End Sub

Private Sub Command1_Click()
    ConfiguraDPOS
End Sub

Private Sub Command2_Click()
    Dim sNSU As String '* 7
    Dim retStatus As Long
    
    sNSU = "000000" ' ESTA FORMATACAO EH IMPORTANTE, SEM ELA DAH GPF!
    retStatus = TransacaoConsultaParcelas(sNSU)
    
    MsgBox "Número de Controle: " & sNSU
            
    FinalizaTransacao
    
    MsgBox "VAI ENCERRAR A FUNÇÃO DE CONSULTA..."
End Sub

Private Sub Command3_Click()
    Dim sValor As String '* 13
    Dim sCupom As String '* 7
    Dim sNSU As String '* 7
    Dim retStatus As Long
    
    sValor = Trim(Format("10000", "000000000000")) 'VALOR DE TESTE
    sCupom = Trim(Format("123", "000000")) 'VALOR DE TESTE

    sNSU = "000000" ' ESTA FORMATACAO EH IMPORTANTE, SEM ELA DAH GPF!
    retStatus = TransacaoCartaoDebito(sValor, sCupom, sNSU)
    
    MsgBox "Número de Controle: " & sNSU
    
    ' SE A TRANSACAO FOR APROVADA (retStatus=0), DEVE-SE IMPRIMIR O
    ' COMPROVANTE DA TRANSACAO
    ' SE A IMPRESSÃO DO COMPROVANTE FOR EFETUADA COM SUCESSO, CONFIRMAR TRANSACAO
    
    If retStatus = 0 Then ' SE IMPRESSAO OK
        retStatus = ConfirmaCartaoDebito(sNSU)
    End If
        
    FinalizaTransacao
    
    MsgBox "VAI ENCERRAR A FUNÇÃO DE CRÉDITO..."
End Sub

Private Sub Command4_Click()
    Dim sNSU As String '* 7
    Dim retStatus As Long
    
    sNSU = "000000" ' ESTA FORMATACAO EH IMPORTANTE, SEM ELA DAH GPF!
    retStatus = TransacaoPreAutorizacaoCartaoCredito(sNSU)
    
    MsgBox "Número de Controle: " & sNSU
            
    FinalizaTransacao
    
    MsgBox "VAI ENCERRAR A FUNÇÃO DE PRÉ-AUTORIZACAO..."
End Sub

Private Sub Command5_Click()
    Dim sValor As String '* 13
    Dim sCupom As String '* 7
    Dim sNSU As String '* 7
    Dim sQtdeCheques As String
    Dim sPeriodoCheques As String
    Dim sDataPrimeiroCheque As String
    Dim sCarenciaPrimeiroCheque As String
    Dim retStatus As Long
    
    sValor = Trim(Format("10000", "000000000000")) 'VALOR DE TESTE
    sCupom = Trim(Format("123", "000000")) 'VALOR DE TESTE
          
    sNSU = "000000" ' ESTA FORMATACAO EH IMPORTANTE, SEM ELA DAH GPF!
    sQtdeCheques = "00"
    sPeriodoCheques = "000000"
    sDataPrimeiroCheque = ""
    sCarenciaPrimeiroCheque = "000"
    
    retStatus = TransacaoCheque(sValor, sCupom, sNSU, sQtdeCheques, _
        sPeriodoCheques, sDataPrimeiroCheque, sCarenciaPrimeiroCheque)
    
    MsgBox "Número de Controle: " & sNSU
End Sub
