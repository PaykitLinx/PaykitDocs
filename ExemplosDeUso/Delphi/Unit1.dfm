object Form1: TForm1
  Left = 274
  Top = 243
  Width = 457
  Height = 312
  Caption = 'Form1'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object btnCC: TButton
    Left = 24
    Top = 16
    Width = 105
    Height = 33
    Caption = 'Cart'#227'o Cr'#233'dito'
    TabOrder = 0
    OnClick = btnCCClick
  end
  object btnCD: TButton
    Left = 136
    Top = 16
    Width = 105
    Height = 33
    Caption = 'Cart'#227'o D'#233'bito'
    TabOrder = 1
    OnClick = btnCDClick
  end
  object btnCV: TButton
    Left = 248
    Top = 16
    Width = 105
    Height = 33
    Caption = 'Cart'#227'o Voucher'
    TabOrder = 2
    OnClick = btnCVClick
  end
  object btnCancelamento: TButton
    Left = 24
    Top = 112
    Width = 105
    Height = 33
    Caption = 'Cancelamento'
    TabOrder = 3
    OnClick = btnCancelamentoClick
  end
  object btnPreAut: TButton
    Left = 24
    Top = 232
    Width = 105
    Height = 33
    Caption = 'Pr'#233'-Autoriza'#231#227'o'
    TabOrder = 4
    OnClick = btnPreAutClick
  end
  object btnResumo: TButton
    Left = 24
    Top = 152
    Width = 105
    Height = 33
    Caption = 'Resumo de Vendas'
    TabOrder = 5
    OnClick = btnResumoClick
  end
  object btnConsultaParcelas: TButton
    Left = 24
    Top = 72
    Width = 105
    Height = 33
    Caption = 'Consulta Parcelas'
    TabOrder = 6
    OnClick = btnConsultaParcelasClick
  end
  object btnReimpressao: TButton
    Left = 24
    Top = 192
    Width = 105
    Height = 33
    Caption = 'Reimpress'#227'o'
    TabOrder = 7
    OnClick = btnReimpressaoClick
  end
  object GroupBox1: TGroupBox
    Left = 136
    Top = 72
    Width = 297
    Height = 193
    Caption = 'Transa'#231#245'es Completas'
    TabOrder = 8
    object Button1: TButton
      Left = 8
      Top = 24
      Width = 129
      Height = 33
      Caption = 'Credito Completa'
      TabOrder = 0
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 144
      Top = 24
      Width = 129
      Height = 33
      Caption = 'Debito Completa (AV)'
      TabOrder = 1
      OnClick = Button2Click
    end
    object Button3: TButton
      Left = 8
      Top = 64
      Width = 129
      Height = 33
      Caption = 'Voucher Completa'
      TabOrder = 2
      OnClick = Button3Click
    end
    object Button4: TButton
      Left = 144
      Top = 64
      Width = 129
      Height = 33
      Caption = 'Debito Completa (Parc)'
      TabOrder = 3
      OnClick = Button4Click
    end
    object Button5: TButton
      Left = 144
      Top = 104
      Width = 129
      Height = 33
      Caption = 'Debito Completa (Pr'#233')'
      TabOrder = 4
      OnClick = Button5Click
    end
  end
end
