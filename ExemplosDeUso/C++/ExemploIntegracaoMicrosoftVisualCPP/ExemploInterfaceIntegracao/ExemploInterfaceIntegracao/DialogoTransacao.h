#pragma once
#include <stdio.h>
#include <iostream>
#include "Define.h"
#using <mscorlib.dll>
#include <msclr\marshal_cppstd.h>
#include "InterfaceExemplo.h"
#include "Logger.h"
#include <iterator>
#include "FuncoesComuns.h"

using namespace std;
using namespace System;
using namespace System::Runtime::InteropServices;

namespace ExemploInterfaceIntegracao {
 
  using namespace System;
  using namespace System::ComponentModel;
  using namespace System::Collections;
  using namespace System::Windows::Forms;
  using namespace System::Data;
  using namespace System::Drawing;

  /// <summary>
  /// Esta classe é utilizada para gerenciar as diferentes formas de entrada e exibição de dados, 
  /// e seu comportamento está dividido de acordo com os modos definidos em Define.h, assim como dados retornados/enviados, 
  /// são passados de acordo com o modo como especificado na documentação
  /// </summary>
  public ref class DialogoTransacao : public System::Windows::Forms::Form
  {

  private:
    int iConfirmacao;
    int indiceSelecionado;
    int iMinimoDigitos;
    int iMaximoDigitos;
    int iDigitosExatos;
    Logger^ oLog;

  public:
    int iModo;
    int iCasasDecimais;
    int iOpcaoSelecionada;
    bool bAguardandokeyPress;
    String^ sTransicao;
    Form^ caller;

  private: System::Windows::Forms::Label^  lblMensagemAdicional;
  private: System::Windows::Forms::PictureBox^  imgInfo;
  private: System::Windows::Forms::ToolTip^  ttInfo;
  private: System::Windows::Forms::Label^  lblMensagemTerminal;
  private: System::Windows::Forms::Panel^  panelFeedBack;
  private: System::Windows::Forms::PictureBox^  pictureBox1;
  private: System::Windows::Forms::Button^  btOk;
  private: System::Windows::Forms::Button^  btCancelar;



  public:
    DialogoTransacao(void);
    DialogoTransacao(String^ sMensagem, Form^ frmCaller);
    bool getOperacaoCancelada(){ return bOperacaoCancelada; }
    int getIndiceSelecionado(){ return indiceSelecionado; }
    int RetornaTipoConfirmacao(){ return iConfirmacao; iConfirmacao = 0; }
    void setModo(int iModo, String^ slabel);
    void setModo(int iModo, String^ slabel, String^ sParametros);
    void setMensagem(String^ mensagem, int iTipo);
    void setMensagemAdicional(String^ sMensagem);
    void EnviaTeclaPressionada();
    void ConverteBoxParaValor();
    void AguardarConfirmacao();
    void setModoSelecionaOpcoes(String^ slabel, String^ sOpcoes, int iOpcaoSelecionada);
    void AjustaBoxOpcoes(String^ sOpcoes);
    void EnviaOperacaoCancelada(bool bCancelada);
    void setInfo(int iModo, String^ sMensagem);
    void AjustaModoEntraNumero(int iMinimoDigitos, int iMaximoDigitos, int iDigitosExatos, int iNumero);
    void AjustaModoEntraString(String^ sLabel, String^ sSTR, int iTamanhoMax);
    int ToIntDef(String^ str, int i);

  protected:
    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    ~DialogoTransacao()
    {
      if (components)
      {
        caller->TopMost = false;
        EnviaOperacaoCancelada(false);
        delete components;
      }
    }

#pragma region Windows Components generated code

  public: System::Windows::Forms::Label^  lblDisplayTerminal;
  protected:
  private: System::Windows::Forms::Panel^  panel1;
  public:


  public: System::Windows::Forms::Label^  lblMensagem;
  private:


  private: System::Windows::Forms::Panel^  panel2;
  public: System::Windows::Forms::TextBox^  boxValor;
  private:

  private:
    bool bOperacaoCancelada;
  private: System::Windows::Forms::ComboBox^  cboxSelecionaOpcao;
  private: System::ComponentModel::IContainer^  components;
           /// <summary>
           /// Required designer variable.
           /// </summary>

#pragma endregion

#pragma region Windows Form Designer generated code
           /// <summary>
           /// Required method for Designer support - do not modify
           /// the contents of this method with the code editor.
           /// </summary>
           void InitializeComponent(void)
           {
             this->components = (gcnew System::ComponentModel::Container());
             System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(DialogoTransacao::typeid));
             this->lblDisplayTerminal = (gcnew System::Windows::Forms::Label());
             this->panel1 = (gcnew System::Windows::Forms::Panel());
             this->lblMensagemTerminal = (gcnew System::Windows::Forms::Label());
             this->lblMensagemAdicional = (gcnew System::Windows::Forms::Label());
             this->cboxSelecionaOpcao = (gcnew System::Windows::Forms::ComboBox());
             this->lblMensagem = (gcnew System::Windows::Forms::Label());
             this->imgInfo = (gcnew System::Windows::Forms::PictureBox());
             this->boxValor = (gcnew System::Windows::Forms::TextBox());
             this->panel2 = (gcnew System::Windows::Forms::Panel());
             this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
             this->btOk = (gcnew System::Windows::Forms::Button());
             this->btCancelar = (gcnew System::Windows::Forms::Button());
             this->ttInfo = (gcnew System::Windows::Forms::ToolTip(this->components));
             this->panelFeedBack = (gcnew System::Windows::Forms::Panel());
             this->panel1->SuspendLayout();
             (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->imgInfo))->BeginInit();
             this->panel2->SuspendLayout();
             (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
             this->panelFeedBack->SuspendLayout();
             this->SuspendLayout();
             // 
             // lblDisplayTerminal
             // 
             this->lblDisplayTerminal->AutoSize = true;
             this->lblDisplayTerminal->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
               static_cast<System::Byte>(0)));
             this->lblDisplayTerminal->Location = System::Drawing::Point(150, 4);
             this->lblDisplayTerminal->Name = L"lblDisplayTerminal";
             this->lblDisplayTerminal->Size = System::Drawing::Size(124, 20);
             this->lblDisplayTerminal->TabIndex = 3;
             this->lblDisplayTerminal->Text = L"Display Terminal";
             this->lblDisplayTerminal->SizeChanged += gcnew System::EventHandler(this, &DialogoTransacao::lblDisplayTerminal_SizeChanged);
             // 
             // panel1
             // 
             this->panel1->BackColor = System::Drawing::Color::WhiteSmoke;
             this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
             this->panel1->Controls->Add(this->lblMensagemTerminal);
             this->panel1->Controls->Add(this->lblMensagemAdicional);
             this->panel1->Controls->Add(this->cboxSelecionaOpcao);
             this->panel1->Controls->Add(this->lblMensagem);
             this->panel1->Controls->Add(this->imgInfo);
             this->panel1->Controls->Add(this->boxValor);
             this->panel1->Location = System::Drawing::Point(3, 4);
             this->panel1->Name = L"panel1";
             this->panel1->Size = System::Drawing::Size(300, 174);
             this->panel1->TabIndex = 2;
             // 
             // lblMensagemTerminal
             // 
             this->lblMensagemTerminal->AutoSize = true;
             this->lblMensagemTerminal->Location = System::Drawing::Point(27, 153);
             this->lblMensagemTerminal->Name = L"lblMensagemTerminal";
             this->lblMensagemTerminal->Size = System::Drawing::Size(67, 13);
             this->lblMensagemTerminal->TabIndex = 0;
             this->lblMensagemTerminal->Text = L"MsgTerminal";
             this->lblMensagemTerminal->Visible = false;
             // 
             // lblMensagemAdicional
             // 
             this->lblMensagemAdicional->AutoSize = true;
             this->lblMensagemAdicional->Location = System::Drawing::Point(27, 8);
             this->lblMensagemAdicional->Name = L"lblMensagemAdicional";
             this->lblMensagemAdicional->Size = System::Drawing::Size(74, 13);
             this->lblMensagemAdicional->TabIndex = 8;
             this->lblMensagemAdicional->Text = L"MensagemAD";
             this->lblMensagemAdicional->Visible = false;
             // 
             // cboxSelecionaOpcao
             // 
             this->cboxSelecionaOpcao->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
               static_cast<System::Byte>(0)));
             this->cboxSelecionaOpcao->FormattingEnabled = true;
             this->cboxSelecionaOpcao->Location = System::Drawing::Point(9, 119);
             this->cboxSelecionaOpcao->Name = L"cboxSelecionaOpcao";
             this->cboxSelecionaOpcao->Size = System::Drawing::Size(267, 28);
             this->cboxSelecionaOpcao->TabIndex = 1;
             this->cboxSelecionaOpcao->Visible = false;
             this->cboxSelecionaOpcao->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &DialogoTransacao::cboxSelecionaOpcao_KeyPress);
             // 
             // lblMensagem
             // 
             this->lblMensagem->AutoSize = true;
             this->lblMensagem->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 10, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
               static_cast<System::Byte>(0)));
             this->lblMensagem->Location = System::Drawing::Point(27, 40);
             this->lblMensagem->Name = L"lblMensagem";
             this->lblMensagem->Size = System::Drawing::Size(217, 17);
             this->lblMensagem->TabIndex = 3;
             this->lblMensagem->Text = L"Digite o Valor da Transação:";
             // 
             // imgInfo
             // 
             this->imgInfo->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"imgInfo.Image")));
             this->imgInfo->Location = System::Drawing::Point(281, 153);
             this->imgInfo->Name = L"imgInfo";
             this->imgInfo->Size = System::Drawing::Size(16, 16);
             this->imgInfo->SizeMode = System::Windows::Forms::PictureBoxSizeMode::AutoSize;
             this->imgInfo->TabIndex = 1;
             this->imgInfo->TabStop = false;
             this->imgInfo->Visible = false;
             // 
             // boxValor
             // 
             this->boxValor->Enabled = false;
             this->boxValor->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 20, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
               static_cast<System::Byte>(0)));
             this->boxValor->Location = System::Drawing::Point(9, 75);
             this->boxValor->Name = L"boxValor";
             this->boxValor->Size = System::Drawing::Size(272, 38);
             this->boxValor->TabIndex = 0;
             this->boxValor->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
             this->boxValor->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &DialogoTransacao::boxValor_KeyPress);
             // 
             // panel2
             // 
             this->panel2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
               static_cast<System::Int32>(static_cast<System::Byte>(255)));
             this->panel2->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
             this->panel2->Controls->Add(this->pictureBox1);
             this->panel2->Controls->Add(this->btOk);
             this->panel2->Controls->Add(this->btCancelar);
             this->panel2->Location = System::Drawing::Point(309, 4);
             this->panel2->Name = L"panel2";
             this->panel2->Size = System::Drawing::Size(124, 174);
             this->panel2->TabIndex = 2;
             // 
             // pictureBox1
             // 
             this->pictureBox1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
               static_cast<System::Int32>(static_cast<System::Byte>(255)));
             this->pictureBox1->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox1.Image")));
             this->pictureBox1->Location = System::Drawing::Point(10, 7);
             this->pictureBox1->Name = L"pictureBox1";
             this->pictureBox1->Size = System::Drawing::Size(112, 71);
             this->pictureBox1->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
             this->pictureBox1->TabIndex = 7;
             this->pictureBox1->TabStop = false;
             // 
             // btOk
             // 
             this->btOk->BackColor = System::Drawing::SystemColors::Control;
             this->btOk->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
             this->btOk->ForeColor = System::Drawing::SystemColors::InfoText;
             this->btOk->Location = System::Drawing::Point(16, 96);
             this->btOk->Name = L"btOk";
             this->btOk->Size = System::Drawing::Size(89, 26);
             this->btOk->TabIndex = 2;
             this->btOk->Text = L"Ok";
             this->btOk->UseVisualStyleBackColor = false;
             this->btOk->Click += gcnew System::EventHandler(this, &DialogoTransacao::btOk_Click);
             this->btOk->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &DialogoTransacao::btOk_KeyDown);
             // 
             // btCancelar
             // 
             this->btCancelar->BackColor = System::Drawing::SystemColors::Control;
             this->btCancelar->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
             this->btCancelar->ForeColor = System::Drawing::SystemColors::InfoText;
             this->btCancelar->Location = System::Drawing::Point(17, 135);
             this->btCancelar->Name = L"btCancelar";
             this->btCancelar->Size = System::Drawing::Size(89, 26);
             this->btCancelar->TabIndex = 3;
             this->btCancelar->Text = L"Cancelar";
             this->btCancelar->UseVisualStyleBackColor = false;
             this->btCancelar->Click += gcnew System::EventHandler(this, &DialogoTransacao::btCancelar_Click);
             this->btCancelar->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &DialogoTransacao::btCancelar_KeyDown);
             // 
             // ttInfo
             // 
             this->ttInfo->AutoPopDelay = 5000;
             this->ttInfo->InitialDelay = 100;
             this->ttInfo->IsBalloon = true;
             this->ttInfo->ReshowDelay = 100;
             this->ttInfo->ShowAlways = true;
             this->ttInfo->Tag = L"TESTE";
             // 
             // panelFeedBack
             // 
             this->panelFeedBack->BackColor = System::Drawing::Color::WhiteSmoke;
             this->panelFeedBack->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
             this->panelFeedBack->Controls->Add(this->lblDisplayTerminal);
             this->panelFeedBack->Location = System::Drawing::Point(3, 181);
             this->panelFeedBack->Name = L"panelFeedBack";
             this->panelFeedBack->Size = System::Drawing::Size(430, 32);
             this->panelFeedBack->TabIndex = 4;
             // 
             // DialogoTransacao
             // 
             this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
             this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
             this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
               static_cast<System::Int32>(static_cast<System::Byte>(255)));
             this->ClientSize = System::Drawing::Size(437, 216);
             this->Controls->Add(this->panelFeedBack);
             this->Controls->Add(this->panel1);
             this->Controls->Add(this->panel2);
             this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedToolWindow;
             this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
             this->MaximizeBox = false;
             this->Name = L"DialogoTransacao";
             this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
             this->Text = L"DialogoTransacao";
             this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &DialogoTransacao::DialogoTransacao_FormClosing);
             this->Load += gcnew System::EventHandler(this, &DialogoTransacao::DialogoTransacao_Load);
             this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &DialogoTransacao::DialogoTransacao_KeyDown);
             this->panel1->ResumeLayout(false);
             this->panel1->PerformLayout();
             (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->imgInfo))->EndInit();
             this->panel2->ResumeLayout(false);
             (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
             this->panelFeedBack->ResumeLayout(false);
             this->panelFeedBack->PerformLayout();
             this->ResumeLayout(false);

           }
#pragma endregion

// Métodos de ações criados automaticamente pelo VS, implementações de comportamento de componentes são realizados aqui
#pragma region Forms CLI actions 
  private: System::Void btOk_Click(System::Object^  sender, System::EventArgs^  e) {
    String^ sConc;

    switch (iModo)
    {
    case MODO_ENTRA_VALOR:     
      sTransicao = "000000000000";
      FuncoesComuns::ExtraiNumeros(boxValor->Text, sConc);
      if (sConc != "")
        sTransicao = sConc;
      break;
    case MODO_ENTRA_VALOR_ESPECIAL:
      sTransicao = "000000000000";
      FuncoesComuns::ExtraiNumeros(boxValor->Text, sConc);
      if (sConc != "")
        sTransicao = sConc;
      break;
    case MODO_SELECIONA_OPCOES:
      indiceSelecionado = cboxSelecionaOpcao->SelectedIndex;
      cboxSelecionaOpcao->Enabled = false;
      break;
    case MODO_ENTRA_CARTAO:
      sTransicao = boxValor->Text;
      break;
    case MODO_ENTRA_CODIGO_SEGURANCA:
      sTransicao = boxValor->Text;
      break;
    case MODO_ENTRA_NUMERO:
      sTransicao = boxValor->Text;
      break;
    case MODO_ENTRA_STRING:
      sTransicao = boxValor->Text;
      break;
    case MODO_ENTRA_DATA_VALIDADE:
      FuncoesComuns::ExtraiNumeros(boxValor->Text, sConc, false);
      sTransicao = sConc;
      break;
    case MODO_ENTRA_DATA:
        if (boxValor->Text->Length == 8)
          sTransicao = boxValor->Text;
      else
        sTransicao = " / / ";
      break;
    case MODO_ENTRA_CODIGO_BARRAS:
      sTransicao = boxValor->Text;
      break;
    }

    imgInfo->Visible = false;
    boxValor->Enabled = false;
    EnviaTeclaPressionada();
  }
  private: System::Void btCancelar_Click(System::Object^  sender, System::EventArgs^  e) {

    if (iModo == MODO_CONFIRMACAO)
    {
      btOk_Click(sender, e);
      iConfirmacao = 1;
      bOperacaoCancelada = false;
      setModo(MODO_INTERMEDIARIO_AGUARDA_ACAO, lblDisplayTerminal->Text);
      return;
    }

    bOperacaoCancelada = true;

    EnviaOperacaoCancelada(true);

    EnviaTeclaPressionada();
  }
  private: System::Void boxValor_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
    if (e->KeyChar == (char)Keys::Tab)
      btOk->Focus();

    switch (iModo)
    {
      //Ajusta o modo de entrada para entrada de valores com duas casas decimais
    case MODO_ENTRA_VALOR:
      FuncoesComuns::InputHandlerValor(e, boxValor);
      break;

    case MODO_ENTRA_VALOR_ESPECIAL:
      FuncoesComuns::InputHandlerValor(e, boxValor, iCasasDecimais);
      break;
      //Ajusta o Modo de entrada para conter uma barra para a data 
    case MODO_ENTRA_DATA_VALIDADE:
      FuncoesComuns::InputHandlerData(e, boxValor);
      break;
      //Ajusta o Modo de entrada para conter duas barras para a data 
    case MODO_ENTRA_DATA:
      FuncoesComuns::InputHandlerData(e, boxValor);
      break;
    case MODO_ENTRA_CARTAO:
      if (!Char::IsDigit(e->KeyChar) && e->KeyChar != (char)Keys::Back)
      {
        e->Handled = true;
        return;
      }
      break;
    case MODO_ENTRA_CODIGO_BARRAS:
      if (!Char::IsDigit(e->KeyChar) && e->KeyChar != (char)Keys::Back)
      {
        e->Handled = true;
        return;
      }
      break;
      //ajusta o modo de entrada para tratar os caracteres máximos e mínimos do callback
    case MODO_ENTRA_NUMERO:
      if (iDigitosExatos != 0)
      {

        if (!Char::IsDigit(e->KeyChar))
        {
          if (e->KeyChar == BOTAO_BACKSPACE)
          {
            btOk->Enabled = false;
            return;
          }
          e->Handled = true;
          return;
        }

        if (boxValor->Text->Length == iDigitosExatos)
        {
          e->Handled = true;
          return;
        }
        else if (boxValor->Text->Length + 1 == iDigitosExatos)
        {
          btOk->Enabled = true;
        }

      }
      else if (iMaximoDigitos > 0)
      {
        if (!Char::IsDigit(e->KeyChar))
        {
          if (e->KeyChar == BOTAO_BACKSPACE)
          {
            return;
          }
          e->Handled = true;
          return;
        }

        if (boxValor->Text->Length == iMaximoDigitos)
        {
          e->Handled = true;
          return;
        }

        if (boxValor->Text->Length >= iMinimoDigitos - 1)
          btOk->Enabled = true;
      }
      else if (Char::IsDigit(e->KeyChar))
        btOk->Enabled = true;

      break;
    }
    boxValor->Select(boxValor->Text->Length, 0);
  }
  private: System::Void cboxSelecionaOpcao_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
    e->Handled = true;
    return;
  }
  private: System::Void DialogoTransacao_Load(System::Object^  sender, System::EventArgs^  e) {
    this->ControlBox = false;
    this->KeyPreview = true;
  }
  private: System::Void DialogoTransacao_FormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e) {
    e->Cancel = true;

    caller->Enabled = true;
  }
  private: System::Void DialogoTransacao_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
    if (e->KeyCode == Keys::Enter)
      btOk_Click(sender, e);
  }
  private: System::Void lblDisplayTerminal_SizeChanged(System::Object^  sender, System::EventArgs^  e) {
    lblDisplayTerminal->Left = (this->ClientSize.Width - lblDisplayTerminal->Width) / 2;
  }
  private: System::Void btOk_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
    if (e->KeyCode == Keys::Tab)
    {
      btCancelar->Focus();
    }
  }
  private: System::Void btCancelar_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
    if (boxValor->Visible)
      boxValor->Focus();
    else
      cboxSelecionaOpcao->Focus();
  }
#pragma endregion

};
}
