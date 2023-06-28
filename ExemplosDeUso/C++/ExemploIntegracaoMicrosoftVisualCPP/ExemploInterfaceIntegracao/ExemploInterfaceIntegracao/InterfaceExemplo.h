#pragma once
#include "ClasseIntegracao.h"
#include "DialogoTransacao.h"
#include "Logger.h"
#include "Define.h"
#include <iostream>
#include <vector>
#include "frmTransacoesCompletas.h"
#include "FuncoesComuns.h"

using namespace std;
using namespace System::Runtime::InteropServices;
using namespace msclr::interop;

namespace ExemploInterfaceIntegracao {

  using namespace System;
  using namespace System::ComponentModel;
  using namespace System::Collections;
  using namespace System::Windows::Forms;
  using namespace System::Data;
  using namespace System::Drawing;

  /// <summary>
  /// Classe do form inicial do programa, onde são feitos so delegates, registros de funções e callbacks
  /// </summary>
  public ref class InterfaceExemplo : public System::Windows::Forms::Form
  {
  public:

#pragma region delegates
    delegate void _CallBackDisplayTerminal(char *);
    GCHandle _GCDislpayTerminal;
    delegate void _CallBackDisplayErro(char *);
    GCHandle _GCDisplayErro;
    delegate void _CallBackMensagem(char *);
    GCHandle _GCMensagem;
    delegate void _CallBackBeep(void);
    GCHandle _GCBEep;
    delegate int _CallBackSolicitaConfirmacao(char *);
    GCHandle _GCSolicitaConfirmacao;
    delegate int _CallBackEntraCartao(char *, char *);
    GCHandle _GCEntraCartao;
    delegate int _CallBackEntraDataValidade(char *, char *);
    GCHandle _GCEntraDataValidade;
    delegate int _CallBackEntraData(char *, char *);
    GCHandle _GCEntraData;
    delegate int _CallBackEntraCodigoSeguranca(char *, char *, int);
    GCHandle _GCEntraCodigoSeguranca;
    delegate int _CallBackSelecionaOpcao(char *, char *, int*);
    GCHandle _GCSelecionaOpcao;
    delegate int _CallBackEntraValor(char *, char *, char *, char *);
    GCHandle _GCEntraValor;
    delegate int _CallBackEntraValorEspecial(char *, char *, char *);
    GCHandle _GCEntraValorEspecial;
    delegate int _CallBackEntraNumero(char *, char *, char *, char *, int, int, int);
    GCHandle _GCEntraNumero;
    delegate int _CallBackOperacaoCancelada(void);
    GCHandle _GCOperacaoCancelada;
    delegate int _CallBackSetaOperacaoCancelada(bool cancelada);
    GCHandle _GCSetaOperacaoCancelada;
    delegate void _CallBackProcessaMensagens(void);
    GCHandle _GCProcessaMensagens;
    delegate int _CallBackEntraString(char *, char *, char *);
    GCHandle _GCEntraString;
    delegate int _CallBackConsultaAVS(char *, char *, char *, char *, char *, char *, char *);
    GCHandle _GCConsultaAVS;
    delegate int _CallBackMensagemAdicional(char *);
    GCHandle _GCMensagemAdicional;
    delegate int _CallBackEntraCodigoBarras(char *, char *);
    GCHandle _GCEntraCodigoBarras;
    delegate int _CallBackEntraCodigoBarrasLido(char *, char *);
    GCHandle _GCEntraCodigoBarrasLido;
    delegate void _CallBackMensagemAlerta(char *);
    GCHandle _GCMensagemAlerta;
    delegate void _CallBackPreviewComprovante(char *);
    GCHandle _GCPreviewComprovante;
    delegate int _CallBackSelecionaPlanos(int, int, int, int, char *, int, char *, char *, char *, char *, char *);
    GCHandle _GCSelecionaPlanos;
    delegate int _CallBackSelecionaPlanosEx(char *, char *);
    GCHandle _GCSelecionaPlanosEx;
#pragma endregion	

    bool operacaoCancelada;
    bool teclaPressionada;
    String^ displayTerminal;
    String^ displayErro;
    Form^ dTransacao;
    ClasseIntegracao *classe;

  private: System::Windows::Forms::Button^  btRecarga;
  private: System::Windows::Forms::Button^  btLogTransTelemarketing;
  private: System::Windows::Forms::Button^  btLogUltimaTransacao;

  private: System::Windows::Forms::Button^  btPagamentoPrivate;

  private: System::Windows::Forms::Button^  btPreAutorizacao;


  private: System::Windows::Forms::Button^  btCancelamento;
  private: System::Windows::Forms::Button^  btConfigDpos;
  private: System::Windows::Forms::TabControl^  tabControl;
  private: System::Windows::Forms::TabPage^  mainTab;

  private: System::Windows::Forms::TabPage^  tabPage2;
  private: System::Windows::Forms::GroupBox^  groupBox6;
  private: System::Windows::Forms::Label^  lblNSU;

  private: System::Windows::Forms::Label^  lblCupom;

  private: System::Windows::Forms::Label^  lblValorDefault;
  private: System::Windows::Forms::TextBox^  tbNSU;

  private: System::Windows::Forms::TextBox^  tbCupom;

  private: System::Windows::Forms::TextBox^  tbValor;
  private: System::Windows::Forms::GroupBox^  groupBox1;
  private: System::Windows::Forms::RichTextBox^  rtbLog;
  private: System::Windows::Forms::Panel^  panel3;
  private: System::Windows::Forms::Panel^  panel2;
  private: System::Windows::Forms::Panel^  panel1;




  private: System::Windows::Forms::Button^  btConsultaAVS;

  public:
    InterfaceExemplo(void);
    void doEvents();
    void setOperacaoCancelada(bool isCancelada){ operacaoCancelada = isCancelada; }
    Logger^ getLog(){ return oLog; }

  private:
    Logger^ oLog;

    typedef void *(__stdcall *pCallBackDisplayTerminal)(char *);
    typedef void *(__stdcall *pCallBackDisplayErro)(char *);
    typedef void *(__stdcall *pCallBackMensagem)(char *);
    typedef void *(__stdcall *pCallBackBeep)(void);
    typedef int  *(__stdcall *pCallBackSolicitaConfirmacao)(char *);
    typedef int *(__stdcall *pCallBackEntraCartao)(char *, char *);
    typedef int *(__stdcall *pCallBackEntraDataValidade)(char *, char *);
    typedef int *(__stdcall *pCallBackEntraData)(char *, char *);
    typedef int *(__stdcall *pCallBackEntraCodigoSeguranca)(char *, char *, int);
    typedef int *(__stdcall *pCallBackSelecionaOpcao)(char *, char *, int *);
    typedef int *(__stdcall *pCallBackEntraValor)(char *, char *, char *, char *);
    typedef int *(__stdcall *pCallBackEntraValorEspecial)(char *, char *, char *);
    typedef int *(__stdcall *pCallBackEntraNumero)(char *, char *, char *, char *, int, int, int);
    typedef int *(__stdcall *pCallBackOperacaoCancelada) (void);
    typedef int *(__stdcall *pCallBackSetaOperacaoCancelada) (bool);
    typedef void *(__stdcall *pCallBackProcessaMensagens) (void);
    typedef int *(__stdcall *pCallBackEntraString)(char *, char *, char *);
    typedef int *(__stdcall *pCallBackConsultaAVS)(char *, char *, char *, char *, char *, char *, char *);
    typedef int *(__stdcall *pCallBackMensagemAdicional)(char *);
    typedef int *(__stdcall *pCallBackEntraCodigoBarras) (char *, char *);
    typedef int *(__stdcall *pCallBackEntraCodigoBarrasLido)(char *, char *);
    typedef void *(__stdcall *pCallBackMensagemAlerta) (char *);
    typedef void *(__stdcall *pCallBackPreviewComprovante) (char *);
    typedef int *(__stdcall *pCallBackSelecionaPlanos)(int, int, int, int, char *, int, char *, char *, char *, char *, char *);
    typedef int *(__stdcall *pCallBackSelecionaPlanosEx)(char *, char *);

    void registrarFuncoesCallBack();
    void aguardar();
    void aguardarConfirmacao();
    void callBackDisplayTerminal(char *pMensagem);
    void callBackDisplayErro(char *pMensagem);
    void callBackDisplayMensagem(char *pMensagem);
    void callBackBeep();
    int callBackSolicitaConfirmacao(char *pMensagem);
    int callBackEntraCartao(char *pLabel, char *pCartao);
    int callBackEntraDataValidade(char *pLabel, char *pDataValidade);
    int callBackEntraData(char *pLabel, char *pDataValidade);
    int callBackEntraCodigoSeguranca(char *pLabel, char *pEntraCodigoSeguranca, int iTamanhoMax);
    int callBackSelecionaOpcao(char *pLabel, char *pOpcoes, int *iOpcaoSelecionada);
    int callBackEntraValor(char *pLabel, char *pValor, char *pValorMinimo, char *pValorMaximo);
    int callBackEntraValorEspecial(char *pLabel, char *pValor, char *pParametros);
    int callBackEntraNumero(char *pLabel, char *pNumero, char *pNumeroMinimo, char *pNumeroMaximo, int iMinimoDigitos, int iMaximoDigitos, int iDigitosExatos);
    int callBackOperacaoCancelada(void);
    int callBackSetaOperacaoCancelada(bool bCancelada);
    void callBackProcessaMensagens();
    int callBackEntraString(char *pLabel, char *pString, char *pTamanhoMaximo);
    int callBackConsultaAVS(char *cEndereco, char *cNumero, char *cApto, char *cBloco, char *cCEP, char *cBairro, char *cCPF);
    int callBackMensagemAdicional(char *pMensagemAdicional);
    int callBackImagemAdicional(int iIndiceImagem);
    int callBackEntraCodigoBarras(char *pLabel, char *pCampo);
    int callBackEntraCodigoBarrasLido(char *pLabel, char *pCampo);
    void callBackMensagemAlerta(char *pMensagemAlerta);
    void callBackPreviewComprovante(char * cComprovante);
    int callBackSelecionaPlanos(int iCodigoRede, int iCodigoTransacao, int iTipoFinanciamento, int iMaximoParcelas, char *pValorMinimoParcela,
      int iMaxDiasPreDatado, char *pNumeroParcelas, char *pValorTransacao, char *pValorParcela, char *pValorEntrada, char *pData);


    int callBackSelecionaPlanosEx(char *pSolicitacao, char *pRetorno);

    void FechaDialogo(void);
    void VerificaInstanciaDialogoTransacao(void);

  private:
    /// <summary>
    /// Required designer variable.
    /// </summary>
    System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
  protected:

    ~InterfaceExemplo()
    {
      classe->descarregaDll();

      if (components)
      {
        delete components;
      }
    }

  protected:
  private: System::Windows::Forms::PictureBox^  pictureBox1;

  private: System::Windows::Forms::GroupBox^  groupBox5;

  private: System::Windows::Forms::Label^  lblTitulo;



  private: System::Windows::Forms::Button^  btPrivateLblCompleta;


  private: System::Windows::Forms::Button^  btCartaoCrediarioCompleta;


  private: System::Windows::Forms::Button^  btVoucherCompleta;



  private: System::Windows::Forms::Button^  btCartaoDebitoCompleta;



  private: System::Windows::Forms::Button^  btCartaoCreditoCompleta;




  private: System::Windows::Forms::Button^  btReimpressao;

  private: System::Windows::Forms::Button^  btValeGas;

  private: System::Windows::Forms::Button^  btCartaoFrota;

  private: System::Windows::Forms::Button^  btConsultaSaldo;

  private: System::Windows::Forms::Button^  btConsultaParcelas;

  private: System::Windows::Forms::Button^  btVoucher;

  private: System::Windows::Forms::Button^  btDebito;
  private: System::Windows::Forms::Button^  btCredito;







  private:

#pragma endregion

#pragma region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent(void)
    {
      System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(InterfaceExemplo::typeid));
      this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
      this->groupBox5 = (gcnew System::Windows::Forms::GroupBox());
      this->btLogUltimaTransacao = (gcnew System::Windows::Forms::Button());
      this->btLogTransTelemarketing = (gcnew System::Windows::Forms::Button());
      this->btConsultaAVS = (gcnew System::Windows::Forms::Button());
      this->btPagamentoPrivate = (gcnew System::Windows::Forms::Button());
      this->btPreAutorizacao = (gcnew System::Windows::Forms::Button());
      this->btCancelamento = (gcnew System::Windows::Forms::Button());
      this->lblTitulo = (gcnew System::Windows::Forms::Label());
      this->btCartaoCrediarioCompleta = (gcnew System::Windows::Forms::Button());
      this->btVoucherCompleta = (gcnew System::Windows::Forms::Button());
      this->btCartaoDebitoCompleta = (gcnew System::Windows::Forms::Button());
      this->btPrivateLblCompleta = (gcnew System::Windows::Forms::Button());
      this->btRecarga = (gcnew System::Windows::Forms::Button());
      this->btCartaoCreditoCompleta = (gcnew System::Windows::Forms::Button());
      this->btCartaoFrota = (gcnew System::Windows::Forms::Button());
      this->btConsultaSaldo = (gcnew System::Windows::Forms::Button());
      this->btVoucher = (gcnew System::Windows::Forms::Button());
      this->btConsultaParcelas = (gcnew System::Windows::Forms::Button());
      this->btDebito = (gcnew System::Windows::Forms::Button());
      this->btCredito = (gcnew System::Windows::Forms::Button());
      this->btValeGas = (gcnew System::Windows::Forms::Button());
      this->btReimpressao = (gcnew System::Windows::Forms::Button());
      this->btConfigDpos = (gcnew System::Windows::Forms::Button());
      this->tabControl = (gcnew System::Windows::Forms::TabControl());
      this->mainTab = (gcnew System::Windows::Forms::TabPage());
      this->panel3 = (gcnew System::Windows::Forms::Panel());
      this->panel2 = (gcnew System::Windows::Forms::Panel());
      this->panel1 = (gcnew System::Windows::Forms::Panel());
      this->tabPage2 = (gcnew System::Windows::Forms::TabPage());
      this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
      this->rtbLog = (gcnew System::Windows::Forms::RichTextBox());
      this->groupBox6 = (gcnew System::Windows::Forms::GroupBox());
      this->lblNSU = (gcnew System::Windows::Forms::Label());
      this->lblCupom = (gcnew System::Windows::Forms::Label());
      this->lblValorDefault = (gcnew System::Windows::Forms::Label());
      this->tbNSU = (gcnew System::Windows::Forms::TextBox());
      this->tbCupom = (gcnew System::Windows::Forms::TextBox());
      this->tbValor = (gcnew System::Windows::Forms::TextBox());
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
      this->groupBox5->SuspendLayout();
      this->tabControl->SuspendLayout();
      this->mainTab->SuspendLayout();
      this->panel3->SuspendLayout();
      this->panel2->SuspendLayout();
      this->panel1->SuspendLayout();
      this->tabPage2->SuspendLayout();
      this->groupBox1->SuspendLayout();
      this->groupBox6->SuspendLayout();
      this->SuspendLayout();
      // 
      // pictureBox1
      // 
      this->pictureBox1->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox1.Image")));
      this->pictureBox1->Location = System::Drawing::Point(12, 3);
      this->pictureBox1->Name = L"pictureBox1";
      this->pictureBox1->Size = System::Drawing::Size(163, 104);
      this->pictureBox1->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
      this->pictureBox1->TabIndex = 4;
      this->pictureBox1->TabStop = false;
      // 
      // groupBox5
      // 
      this->groupBox5->BackColor = System::Drawing::SystemColors::Control;
      this->groupBox5->Controls->Add(this->btLogUltimaTransacao);
      this->groupBox5->Controls->Add(this->btLogTransTelemarketing);
      this->groupBox5->Location = System::Drawing::Point(6, 6);
      this->groupBox5->Name = L"groupBox5";
      this->groupBox5->Size = System::Drawing::Size(207, 318);
      this->groupBox5->TabIndex = 4;
      this->groupBox5->TabStop = false;
      this->groupBox5->Text = L"Obtenções de Log";
      // 
      // btLogUltimaTransacao
      // 
      this->btLogUltimaTransacao->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btLogUltimaTransacao->Location = System::Drawing::Point(20, 33);
      this->btLogUltimaTransacao->Name = L"btLogUltimaTransacao";
      this->btLogUltimaTransacao->Size = System::Drawing::Size(163, 30);
      this->btLogUltimaTransacao->TabIndex = 8;
      this->btLogUltimaTransacao->Text = L"Obtém Log Últ. Transação";
      this->btLogUltimaTransacao->UseVisualStyleBackColor = true;
      this->btLogUltimaTransacao->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btObtemUltimoLogTran_Click);
      // 
      // btLogTransTelemarketing
      // 
      this->btLogTransTelemarketing->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btLogTransTelemarketing->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 7.5F, System::Drawing::FontStyle::Regular,
        System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(0)));
      this->btLogTransTelemarketing->Location = System::Drawing::Point(20, 90);
      this->btLogTransTelemarketing->Name = L"btLogTransTelemarketing";
      this->btLogTransTelemarketing->Size = System::Drawing::Size(163, 38);
      this->btLogTransTelemarketing->TabIndex = 6;
      this->btLogTransTelemarketing->Text = L"Obtém Log Última Transacao TeleMarketing ";
      this->btLogTransTelemarketing->UseVisualStyleBackColor = true;
      this->btLogTransTelemarketing->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btLogTransTelemarketing_Click);
      // 
      // btConsultaAVS
      // 
      this->btConsultaAVS->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btConsultaAVS->Location = System::Drawing::Point(17, 263);
      this->btConsultaAVS->Name = L"btConsultaAVS";
      this->btConsultaAVS->Size = System::Drawing::Size(165, 30);
      this->btConsultaAVS->TabIndex = 18;
      this->btConsultaAVS->Text = L"Consulta AVS";
      this->btConsultaAVS->UseVisualStyleBackColor = true;
      this->btConsultaAVS->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btConsultaAVS_Click);
      // 
      // btPagamentoPrivate
      // 
      this->btPagamentoPrivate->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btPagamentoPrivate->Location = System::Drawing::Point(17, 215);
      this->btPagamentoPrivate->Name = L"btPagamentoPrivate";
      this->btPagamentoPrivate->Size = System::Drawing::Size(165, 30);
      this->btPagamentoPrivate->TabIndex = 17;
      this->btPagamentoPrivate->Text = L"Pagamento Private Label";
      this->btPagamentoPrivate->UseVisualStyleBackColor = true;
      this->btPagamentoPrivate->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btPagamentoPrivate_Click);
      // 
      // btPreAutorizacao
      // 
      this->btPreAutorizacao->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btPreAutorizacao->Location = System::Drawing::Point(17, 163);
      this->btPreAutorizacao->Name = L"btPreAutorizacao";
      this->btPreAutorizacao->Size = System::Drawing::Size(165, 30);
      this->btPreAutorizacao->TabIndex = 16;
      this->btPreAutorizacao->Text = L"Pré Autorização";
      this->btPreAutorizacao->UseVisualStyleBackColor = true;
      this->btPreAutorizacao->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btPreAutorizacao_Click);
      // 
      // btCancelamento
      // 
      this->btCancelamento->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btCancelamento->Location = System::Drawing::Point(17, 113);
      this->btCancelamento->Name = L"btCancelamento";
      this->btCancelamento->Size = System::Drawing::Size(165, 30);
      this->btCancelamento->TabIndex = 15;
      this->btCancelamento->Text = L"Cancelamento";
      this->btCancelamento->UseVisualStyleBackColor = true;
      this->btCancelamento->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btCancelamento_Click);
      // 
      // lblTitulo
      // 
      this->lblTitulo->AutoSize = true;
      this->lblTitulo->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 12, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->lblTitulo->Location = System::Drawing::Point(260, 9);
      this->lblTitulo->Name = L"lblTitulo";
      this->lblTitulo->Size = System::Drawing::Size(251, 20);
      this->lblTitulo->TabIndex = 6;
      this->lblTitulo->Text = L"Exemplo de Integração D-TEF";
      // 
      // btCartaoCrediarioCompleta
      // 
      this->btCartaoCrediarioCompleta->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btCartaoCrediarioCompleta->Location = System::Drawing::Point(20, 263);
      this->btCartaoCrediarioCompleta->Name = L"btCartaoCrediarioCompleta";
      this->btCartaoCrediarioCompleta->Size = System::Drawing::Size(155, 30);
      this->btCartaoCrediarioCompleta->TabIndex = 12;
      this->btCartaoCrediarioCompleta->Text = L"Cartao Crediário Completa";
      this->btCartaoCrediarioCompleta->UseVisualStyleBackColor = true;
      this->btCartaoCrediarioCompleta->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btCartaoCrediarioCompleta_Click);
      // 
      // btVoucherCompleta
      // 
      this->btVoucherCompleta->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btVoucherCompleta->Location = System::Drawing::Point(20, 215);
      this->btVoucherCompleta->Name = L"btVoucherCompleta";
      this->btVoucherCompleta->Size = System::Drawing::Size(155, 30);
      this->btVoucherCompleta->TabIndex = 11;
      this->btVoucherCompleta->Text = L"Voucher Completa";
      this->btVoucherCompleta->UseVisualStyleBackColor = true;
      this->btVoucherCompleta->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btVoucherCompleta_Click);
      // 
      // btCartaoDebitoCompleta
      // 
      this->btCartaoDebitoCompleta->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btCartaoDebitoCompleta->Location = System::Drawing::Point(20, 163);
      this->btCartaoDebitoCompleta->Name = L"btCartaoDebitoCompleta";
      this->btCartaoDebitoCompleta->Size = System::Drawing::Size(155, 30);
      this->btCartaoDebitoCompleta->TabIndex = 10;
      this->btCartaoDebitoCompleta->Text = L"Cartão Débito Completa";
      this->btCartaoDebitoCompleta->UseVisualStyleBackColor = true;
      this->btCartaoDebitoCompleta->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btCartaoDebitoCompleta_Click);
      // 
      // btPrivateLblCompleta
      // 
      this->btPrivateLblCompleta->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btPrivateLblCompleta->Location = System::Drawing::Point(20, 63);
      this->btPrivateLblCompleta->Name = L"btPrivateLblCompleta";
      this->btPrivateLblCompleta->Size = System::Drawing::Size(155, 30);
      this->btPrivateLblCompleta->TabIndex = 8;
      this->btPrivateLblCompleta->Text = L"Private Label Completa";
      this->btPrivateLblCompleta->UseVisualStyleBackColor = true;
      this->btPrivateLblCompleta->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btPrivateLblCompleta_Click);
      // 
      // btRecarga
      // 
      this->btRecarga->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btRecarga->Location = System::Drawing::Point(20, 13);
      this->btRecarga->Name = L"btRecarga";
      this->btRecarga->Size = System::Drawing::Size(155, 30);
      this->btRecarga->TabIndex = 7;
      this->btRecarga->Text = L"Recarga Celular";
      this->btRecarga->UseVisualStyleBackColor = true;
      this->btRecarga->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btRecarga_Click);
      // 
      // btCartaoCreditoCompleta
      // 
      this->btCartaoCreditoCompleta->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btCartaoCreditoCompleta->Location = System::Drawing::Point(20, 110);
      this->btCartaoCreditoCompleta->Name = L"btCartaoCreditoCompleta";
      this->btCartaoCreditoCompleta->Size = System::Drawing::Size(155, 30);
      this->btCartaoCreditoCompleta->TabIndex = 9;
      this->btCartaoCreditoCompleta->Text = L"Cartão Crédito Completa";
      this->btCartaoCreditoCompleta->UseVisualStyleBackColor = true;
      this->btCartaoCreditoCompleta->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btCartaoCreditoCompleta_Click);
      // 
      // btCartaoFrota
      // 
      this->btCartaoFrota->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btCartaoFrota->Location = System::Drawing::Point(21, 216);
      this->btCartaoFrota->Name = L"btCartaoFrota";
      this->btCartaoFrota->Size = System::Drawing::Size(155, 30);
      this->btCartaoFrota->TabIndex = 5;
      this->btCartaoFrota->Text = L"Cartão Frota (F6)";
      this->btCartaoFrota->UseVisualStyleBackColor = true;
      this->btCartaoFrota->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btCartaoFrota_Click);
      // 
      // btConsultaSaldo
      // 
      this->btConsultaSaldo->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btConsultaSaldo->Location = System::Drawing::Point(21, 164);
      this->btConsultaSaldo->Name = L"btConsultaSaldo";
      this->btConsultaSaldo->Size = System::Drawing::Size(155, 30);
      this->btConsultaSaldo->TabIndex = 4;
      this->btConsultaSaldo->Text = L"Consulta Saldo (F5)";
      this->btConsultaSaldo->UseVisualStyleBackColor = true;
      this->btConsultaSaldo->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btConsultaSaldo_Click);
      // 
      // btVoucher
      // 
      this->btVoucher->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btVoucher->Location = System::Drawing::Point(21, 111);
      this->btVoucher->Name = L"btVoucher";
      this->btVoucher->Size = System::Drawing::Size(155, 30);
      this->btVoucher->TabIndex = 3;
      this->btVoucher->Text = L"Voucher (F3)";
      this->btVoucher->UseVisualStyleBackColor = true;
      this->btVoucher->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btVoucher_Click);
      // 
      // btConsultaParcelas
      // 
      this->btConsultaParcelas->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btConsultaParcelas->Location = System::Drawing::Point(21, 264);
      this->btConsultaParcelas->Name = L"btConsultaParcelas";
      this->btConsultaParcelas->Size = System::Drawing::Size(155, 30);
      this->btConsultaParcelas->TabIndex = 6;
      this->btConsultaParcelas->Text = L"Consulta Parcelas (F4)";
      this->btConsultaParcelas->UseVisualStyleBackColor = true;
      this->btConsultaParcelas->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btConsultaParcelas_Click);
      // 
      // btDebito
      // 
      this->btDebito->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btDebito->Location = System::Drawing::Point(21, 64);
      this->btDebito->Name = L"btDebito";
      this->btDebito->Size = System::Drawing::Size(155, 30);
      this->btDebito->TabIndex = 2;
      this->btDebito->Text = L"Transação de Débito (F2)";
      this->btDebito->UseVisualStyleBackColor = true;
      this->btDebito->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btDebito_Click);
      // 
      // btCredito
      // 
      this->btCredito->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btCredito->Location = System::Drawing::Point(21, 14);
      this->btCredito->Name = L"btCredito";
      this->btCredito->Size = System::Drawing::Size(155, 30);
      this->btCredito->TabIndex = 1;
      this->btCredito->Text = L"Transação de Crédito (F1)";
      this->btCredito->UseVisualStyleBackColor = true;
      this->btCredito->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btCredito_Click);
      // 
      // btValeGas
      // 
      this->btValeGas->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btValeGas->Location = System::Drawing::Point(17, 13);
      this->btValeGas->Name = L"btValeGas";
      this->btValeGas->Size = System::Drawing::Size(165, 30);
      this->btValeGas->TabIndex = 13;
      this->btValeGas->Text = L"Vale Gás";
      this->btValeGas->UseVisualStyleBackColor = true;
      this->btValeGas->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btValeGas_Click);
      // 
      // btReimpressao
      // 
      this->btReimpressao->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btReimpressao->Location = System::Drawing::Point(17, 63);
      this->btReimpressao->Name = L"btReimpressao";
      this->btReimpressao->Size = System::Drawing::Size(165, 33);
      this->btReimpressao->TabIndex = 14;
      this->btReimpressao->Text = L"Reimpressão de Comprovante";
      this->btReimpressao->UseVisualStyleBackColor = true;
      this->btReimpressao->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btReimpressao_Click);
      // 
      // btConfigDpos
      // 
      this->btConfigDpos->BackgroundImage = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"btConfigDpos.BackgroundImage")));
      this->btConfigDpos->BackgroundImageLayout = System::Windows::Forms::ImageLayout::Zoom;
      this->btConfigDpos->FlatStyle = System::Windows::Forms::FlatStyle::Popup;
      this->btConfigDpos->Location = System::Drawing::Point(626, 72);
      this->btConfigDpos->Name = L"btConfigDpos";
      this->btConfigDpos->Size = System::Drawing::Size(39, 30);
      this->btConfigDpos->TabIndex = 8;
      this->btConfigDpos->UseVisualStyleBackColor = true;
      this->btConfigDpos->Click += gcnew System::EventHandler(this, &InterfaceExemplo::btConfigDpos_Click);
      // 
      // tabControl
      // 
      this->tabControl->Alignment = System::Windows::Forms::TabAlignment::Left;
      this->tabControl->Controls->Add(this->mainTab);
      this->tabControl->Controls->Add(this->tabPage2);
      this->tabControl->Location = System::Drawing::Point(12, 113);
      this->tabControl->Multiline = true;
      this->tabControl->Name = L"tabControl";
      this->tabControl->SelectedIndex = 0;
      this->tabControl->Size = System::Drawing::Size(657, 334);
      this->tabControl->TabIndex = 9;
      // 
      // mainTab
      // 
      this->mainTab->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->mainTab->Controls->Add(this->panel3);
      this->mainTab->Controls->Add(this->panel2);
      this->mainTab->Controls->Add(this->panel1);
      this->mainTab->Location = System::Drawing::Point(23, 4);
      this->mainTab->Name = L"mainTab";
      this->mainTab->Padding = System::Windows::Forms::Padding(3);
      this->mainTab->Size = System::Drawing::Size(630, 326);
      this->mainTab->TabIndex = 0;
      this->mainTab->Text = L"Comuns";
      // 
      // panel3
      // 
      this->panel3->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel3->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
      this->panel3->Controls->Add(this->btValeGas);
      this->panel3->Controls->Add(this->btConsultaAVS);
      this->panel3->Controls->Add(this->btCancelamento);
      this->panel3->Controls->Add(this->btReimpressao);
      this->panel3->Controls->Add(this->btPreAutorizacao);
      this->panel3->Controls->Add(this->btPagamentoPrivate);
      this->panel3->Location = System::Drawing::Point(425, 6);
      this->panel3->Name = L"panel3";
      this->panel3->Size = System::Drawing::Size(199, 315);
      this->panel3->TabIndex = 14;
      // 
      // panel2
      // 
      this->panel2->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel2->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
      this->panel2->Controls->Add(this->btCartaoCrediarioCompleta);
      this->panel2->Controls->Add(this->btVoucherCompleta);
      this->panel2->Controls->Add(this->btCartaoCreditoCompleta);
      this->panel2->Controls->Add(this->btCartaoDebitoCompleta);
      this->panel2->Controls->Add(this->btRecarga);
      this->panel2->Controls->Add(this->btPrivateLblCompleta);
      this->panel2->Location = System::Drawing::Point(220, 6);
      this->panel2->Name = L"panel2";
      this->panel2->Size = System::Drawing::Size(199, 315);
      this->panel2->TabIndex = 13;
      // 
      // panel1
      // 
      this->panel1->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
      this->panel1->Controls->Add(this->btCartaoFrota);
      this->panel1->Controls->Add(this->btConsultaParcelas);
      this->panel1->Controls->Add(this->btConsultaSaldo);
      this->panel1->Controls->Add(this->btCredito);
      this->panel1->Controls->Add(this->btVoucher);
      this->panel1->Controls->Add(this->btDebito);
      this->panel1->Location = System::Drawing::Point(7, 5);
      this->panel1->Name = L"panel1";
      this->panel1->Size = System::Drawing::Size(206, 315);
      this->panel1->TabIndex = 11;
      // 
      // tabPage2
      // 
      this->tabPage2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->tabPage2->Controls->Add(this->groupBox1);
      this->tabPage2->Controls->Add(this->groupBox5);
      this->tabPage2->Location = System::Drawing::Point(23, 4);
      this->tabPage2->Name = L"tabPage2";
      this->tabPage2->Padding = System::Windows::Forms::Padding(3);
      this->tabPage2->Size = System::Drawing::Size(630, 326);
      this->tabPage2->TabIndex = 1;
      this->tabPage2->Text = L"Obter Log";
      // 
      // groupBox1
      // 
      this->groupBox1->BackColor = System::Drawing::SystemColors::Control;
      this->groupBox1->Controls->Add(this->rtbLog);
      this->groupBox1->Location = System::Drawing::Point(229, 6);
      this->groupBox1->Name = L"groupBox1";
      this->groupBox1->Size = System::Drawing::Size(395, 318);
      this->groupBox1->TabIndex = 7;
      this->groupBox1->TabStop = false;
      this->groupBox1->Text = L"Texto log";
      // 
      // rtbLog
      // 
      this->rtbLog->Location = System::Drawing::Point(4, 15);
      this->rtbLog->Name = L"rtbLog";
      this->rtbLog->Size = System::Drawing::Size(385, 297);
      this->rtbLog->TabIndex = 0;
      this->rtbLog->Text = L"";
      // 
      // groupBox6
      // 
      this->groupBox6->Controls->Add(this->lblNSU);
      this->groupBox6->Controls->Add(this->lblCupom);
      this->groupBox6->Controls->Add(this->lblValorDefault);
      this->groupBox6->Controls->Add(this->tbNSU);
      this->groupBox6->Controls->Add(this->tbCupom);
      this->groupBox6->Controls->Add(this->tbValor);
      this->groupBox6->Location = System::Drawing::Point(171, 55);
      this->groupBox6->Name = L"groupBox6";
      this->groupBox6->Size = System::Drawing::Size(441, 52);
      this->groupBox6->TabIndex = 10;
      this->groupBox6->TabStop = false;
      this->groupBox6->Text = L"Parametros default";
      // 
      // lblNSU
      // 
      this->lblNSU->AutoSize = true;
      this->lblNSU->Location = System::Drawing::Point(319, 26);
      this->lblNSU->Name = L"lblNSU";
      this->lblNSU->Size = System::Drawing::Size(33, 13);
      this->lblNSU->TabIndex = 5;
      this->lblNSU->Text = L"NSU:";
      // 
      // lblCupom
      // 
      this->lblCupom->AutoSize = true;
      this->lblCupom->Location = System::Drawing::Point(166, 26);
      this->lblCupom->Name = L"lblCupom";
      this->lblCupom->Size = System::Drawing::Size(43, 13);
      this->lblCupom->TabIndex = 4;
      this->lblCupom->Text = L"Cupom:";
      // 
      // lblValorDefault
      // 
      this->lblValorDefault->AutoSize = true;
      this->lblValorDefault->Location = System::Drawing::Point(13, 26);
      this->lblValorDefault->Name = L"lblValorDefault";
      this->lblValorDefault->Size = System::Drawing::Size(34, 13);
      this->lblValorDefault->TabIndex = 3;
      this->lblValorDefault->Text = L"Valor:";
      // 
      // tbNSU
      // 
      this->tbNSU->Location = System::Drawing::Point(358, 23);
      this->tbNSU->MaxLength = 6;
      this->tbNSU->Name = L"tbNSU";
      this->tbNSU->Size = System::Drawing::Size(67, 20);
      this->tbNSU->TabIndex = 2;
      this->tbNSU->Text = L"000000";
      this->tbNSU->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &InterfaceExemplo::tbNSU_KeyPress);
      this->tbNSU->Leave += gcnew System::EventHandler(this, &InterfaceExemplo::tbNSU_Leave);
      // 
      // tbCupom
      // 
      this->tbCupom->Location = System::Drawing::Point(215, 23);
      this->tbCupom->MaxLength = 6;
      this->tbCupom->Name = L"tbCupom";
      this->tbCupom->Size = System::Drawing::Size(88, 20);
      this->tbCupom->TabIndex = 1;
      this->tbCupom->Text = L"000000";
      this->tbCupom->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &InterfaceExemplo::tbCupom_KeyPress);
      this->tbCupom->Leave += gcnew System::EventHandler(this, &InterfaceExemplo::tbCupom_Leave);
      // 
      // tbValor
      // 
      this->tbValor->Location = System::Drawing::Point(53, 23);
      this->tbValor->MaxLength = 8;
      this->tbValor->Name = L"tbValor";
      this->tbValor->Size = System::Drawing::Size(104, 20);
      this->tbValor->TabIndex = 0;
      this->tbValor->Text = L"00000000";
      this->tbValor->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &InterfaceExemplo::tbValor_KeyPress);
      this->tbValor->Leave += gcnew System::EventHandler(this, &InterfaceExemplo::tbValor_Leave);
      // 
      // InterfaceExemplo
      // 
      this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
      this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
      this->ClientSize = System::Drawing::Size(672, 450);
      this->Controls->Add(this->groupBox6);
      this->Controls->Add(this->pictureBox1);
      this->Controls->Add(this->btConfigDpos);
      this->Controls->Add(this->tabControl);
      this->Controls->Add(this->lblTitulo);
      this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedSingle;
      this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
      this->MaximizeBox = false;
      this->Name = L"InterfaceExemplo";
      this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
      this->Text = L"InterfaceExemplo";
      this->FormClosing += gcnew System::Windows::Forms::FormClosingEventHandler(this, &InterfaceExemplo::InterfaceExemplo_FormClosing);
      this->Load += gcnew System::EventHandler(this, &InterfaceExemplo::InterfaceExemplo_Load);
      this->KeyDown += gcnew System::Windows::Forms::KeyEventHandler(this, &InterfaceExemplo::InterfaceExemplo_KeyDown);
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
      this->groupBox5->ResumeLayout(false);
      this->tabControl->ResumeLayout(false);
      this->mainTab->ResumeLayout(false);
      this->panel3->ResumeLayout(false);
      this->panel2->ResumeLayout(false);
      this->panel1->ResumeLayout(false);
      this->tabPage2->ResumeLayout(false);
      this->groupBox1->ResumeLayout(false);
      this->groupBox6->ResumeLayout(false);
      this->groupBox6->PerformLayout();
      this->ResumeLayout(false);
      this->PerformLayout();

    }
#pragma endregion

// Métodos de ações de componentes gerados automaticamente pelo VS são implementados aqui
#pragma region CLI Form Action
  private: System::Void btCredito_Click(System::Object^  sender, System::EventArgs^  e) {  
        char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
        char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
        char numeroControle[7];

        
        oLog->GravarLog("Iniciando Transação De Crédito");
        if (classe->TransacaoCartaoCredito(valor, numeroCupom, numeroControle) == 0){
        classe->ConfirmaCartao(numeroControle);
        }

        tbNSU->Text = gcnew String(numeroControle);        
        oLog->GravarLog("Final da transação de crédito" + Environment::NewLine);
        FechaDialogo();
        classe->FinalizaTransacao();
  }

  private: System::Void InterfaceExemplo_Load(System::Object^  sender, System::EventArgs^  e) {
    this->KeyPreview = true;
  }
  private: System::Void btDebito_Click(System::Object^  sender, System::EventArgs^  e) {
    char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char numeroControle[7];

    
    oLog->GravarLog("Iniciando Transação De débito");
    if (classe->TransacaoCartaoDebito(valor, numeroCupom, numeroControle) == 0){
      classe->ConfirmaCartao(numeroControle);
    }
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Final da transação de débito" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btVoucher_Click(System::Object^  sender, System::EventArgs^  e) {
    char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char numeroControle[7];

    
    oLog->GravarLog("Iniciando Transação Voucher");
    if (classe->TransacaoCartaoVoucher(valor, numeroCupom, numeroControle) == 0){
      classe->ConfirmaCartao(numeroControle);
    }
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Final da transação voucher" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btConsultaParcelas_Click(System::Object^  sender, System::EventArgs^  e) {
    char numeroControle[7];

    
    oLog->GravarLog("Iniciando Consulta Parcelas");
    classe->TransacaoConsultaParcelas(numeroControle);
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando Consulta Parcelas" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btConsultaSaldo_Click(System::Object^  sender, System::EventArgs^  e) {
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char numeroControle[7];

    
    oLog->GravarLog("Iniciando Consulta Saldo");
    classe->TransacaoConsultaSaldo(numeroCupom, numeroControle);
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando Consulta Saldo" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btCartaoFrota_Click(System::Object^  sender, System::EventArgs^  e) {
    char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char numeroControle[7];

    
    oLog->GravarLog("Iniciando Transação Cartão Frota");
    if (classe->TransacaoCartaoFrota(valor, numeroCupom, numeroControle) == 0){
      classe->ConfirmaCartao(numeroControle);
    }
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando Transação Cartão Frota" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btValeGas_Click(System::Object^  sender, System::EventArgs^  e) {
    char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroValeGas = "00000";
    char numeroControle[7];
    
    
    oLog->GravarLog("Iniciando Transação Vale Gás");
    if (classe->TransacaoeValeGas(valor, numeroCupom, numeroControle, numeroValeGas) == 0){
      classe->ConfirmaCartao(numeroControle);
    }
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando Transação Vale Gás" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btReimpressao_Click(System::Object^  sender, System::EventArgs^  e) {
    
    oLog->GravarLog("Iniciando Função de reimpressão de cupom");
    classe->TransacaoReimpressaoCupom();
    oLog->GravarLog("Finalizando função de reimpressão de cupom" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btCartaoCreditoCompleta_Click(System::Object^  sender, System::EventArgs^  e)  {   
    char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char numeroControle[7];

    tsParamCreditoCompleta* stparamCreditoCompleta;

    frmTransacoesCompletas^ frmCompletas = gcnew frmTransacoesCompletas(CREDITO_COMPLETA);
   
    
    if (frmCompletas->ShowDialog() != System::Windows::Forms::DialogResult::OK)
      return;
    
    stparamCreditoCompleta = frmCompletas->getParametrosCreditoCompleta();
    
    oLog->GravarLog("Iniciando cartão crédito completa");

    if (classe->TransacaoCartaoCreditoCompleta(valor, numeroCupom, numeroControle, stparamCreditoCompleta->tipo,
      stparamCreditoCompleta->numeroParcelas, stparamCreditoCompleta->valorParcela, stparamCreditoCompleta->valorTaxaServico,
      stparamCreditoCompleta->permiteAlteracao, stparamCreditoCompleta->reservado) == 0)
    {
      classe->ConfirmaCartao(numeroControle);
    }
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando cartão crédito completa" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();

  }
  private: System::Void btCartaoDebitoCompleta_Click(System::Object^  sender, System::EventArgs^  e) {

    char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char numeroControle[7];

    tsParamDebitoCompleta* stparamDebitoCompleta;

    
    oLog->GravarLog("Iniciando cartão débito completa");

    frmTransacoesCompletas^ frmCompletas = gcnew frmTransacoesCompletas(DEBITO_COMPLETA);

    if (frmCompletas->ShowDialog() != System::Windows::Forms::DialogResult::OK)
      return;

    stparamDebitoCompleta = frmCompletas->getParametrosDebitoCompleta();

    if (classe->TransacaoCartaoDebitoCompleta(valor, numeroCupom, numeroControle, stparamDebitoCompleta->tipo, stparamDebitoCompleta->numeroParcelas, stparamDebitoCompleta->sequenciaParcela, stparamDebitoCompleta->dataDebito, stparamDebitoCompleta->valorParcela, stparamDebitoCompleta->valorTaxaServico, stparamDebitoCompleta->permiteAlteracao, stparamDebitoCompleta->reservado) == 0)
    {
      classe->ConfirmaCartao(numeroControle);
    }
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando cartão débito completa" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btVoucherCompleta_Click(System::Object^  sender, System::EventArgs^  e) {
    char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* reservado;
    char numeroControle[7];

    
    oLog->GravarLog("Iniciando transação voucher completa");

    frmTransacoesCompletas^ frmCompletas = gcnew frmTransacoesCompletas(VOUCHER_COMPLETA);

    if (frmCompletas->ShowDialog() != System::Windows::Forms::DialogResult::OK)
      return;
  
    reservado = frmCompletas->getParametrosVoucherCompleta();

    if (classe->TransacaoCartaoVoucherCompleta(valor, numeroCupom, numeroControle, reservado) == 0)
    {
      classe->ConfirmaCartao(numeroControle);
    }

    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando transação voucher completa" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();

  }
  private: System::Void btCartaoCrediarioCompleta_Click(System::Object^  sender, System::EventArgs^  e) {
    char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char numeroControle[6 + 1];

    tsParamCrediarioCompleta* stParamCrediarioCompleta;

    
    oLog->GravarLog("Iniciando transação cartão crediario completa");

    frmTransacoesCompletas^ frmCompletas = gcnew frmTransacoesCompletas(CREDIARIO_COMPLETA);

    if (frmCompletas->ShowDialog() != System::Windows::Forms::DialogResult::OK)
      return;

    stParamCrediarioCompleta = frmCompletas->getParametrosCrediarioCompleta();

    if (classe->TransacaoCartaoCrediarioCompleta(valor, numeroCupom, numeroControle, stParamCrediarioCompleta->numeroParcelas,
      stParamCrediarioCompleta->dataParcela1, stParamCrediarioCompleta->valorParcela1, stParamCrediarioCompleta->valorEntrada,
      stParamCrediarioCompleta->permiteAlteracao, stParamCrediarioCompleta->reservado) == 0)
    {
      classe->ConfirmaCartao(numeroControle);
    }
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando transação cartão crediario completa" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btPrivateLblCompleta_Click(System::Object^  sender, System::EventArgs^  e) {

    char* valor = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char* numeroCupom = FuncoesComuns::SystemStrToCharPtr(tbValor->Text);
    char numeroControle[6 + 1];
    tsParamPrivateLblCompleta* stPrivateLabel;

    // Parâmetros opcionais. Podem ser preenchidos com zeros conforme descrito no manual
    char* valorParcela = FuncoesComuns::SystemStrToCharPtr("00000000000");
    char* valorTaxaServico = FuncoesComuns::SystemStrToCharPtr("00000000000");

    
    oLog->GravarLog("Iniciando transação private label completa");

    frmTransacoesCompletas^ frmCompletas = gcnew frmTransacoesCompletas(PRIVATE_LABEL_COMPLETA);

    if (frmCompletas->ShowDialog() != System::Windows::Forms::DialogResult::OK)
      return;

    stPrivateLabel = frmCompletas->getParametrosPrivateLabel();

    if (classe->TransacaoCartaoPrivateLabelCompleta(valor, numeroCupom, numeroControle, stPrivateLabel->tipo, stPrivateLabel->numeroParcelas,
      valorParcela, valorTaxaServico, stPrivateLabel->permiteAlteracao, stPrivateLabel->reservado) == 0)
    {
      classe->ConfirmaCartao(numeroControle);
    }
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando transação private label completa" + Environment::NewLine);
    FechaDialogo();
    classe->FinalizaTransacao();
  }
  private: System::Void btRecarga_Click(System::Object^  sender, System::EventArgs^  e) {
    char codigoArea[2 + 1] = "00";
    char numeroTelefone[8 + 1] = "00000000";
    char numeroControle[6 + 1] = "000000";
    
    
    oLog->GravarLog("Iniciando transação de recarga");
    classe->TransacaoRecargaCelular(codigoArea, numeroTelefone, numeroControle);
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando transação de recarga" + Environment::NewLine);
    FechaDialogo();
    classe->ConfirmaCartao(numeroControle);
    classe->FinalizaTransacao();
  }
  private: System::Void btObtemUltimoLogTran_Click(System::Object^  sender, System::EventArgs^  e) {
    char logUltimaTransacao[500];
    
    oLog->GravarLog("Iniciando a obtenção do log da última transação");
    classe->ObtemLogUltimaTransacao(logUltimaTransacao);

    if (logUltimaTransacao[0] != 0)
    {
      rtbLog->Text = marshal_as<String^>(logUltimaTransacao);
    }
    oLog->GravarLog("a obtenção do log da última transação" + Environment::NewLine);
  }
  private: System::Void btLogTransTelemarketing_Click(System::Object^  sender, System::EventArgs^  e) {
    char logUltimaTransacao[500];
    char numeroPDV[50];
    
    oLog->GravarLog("Iniciando a obtenção do log da última transação telemarking");
    classe->ObtemLogUltimaTransacaoTeleMarketing(numeroPDV, logUltimaTransacao);

    if (logUltimaTransacao[0] != 0)
    {
      rtbLog->Text = marshal_as<String^>(logUltimaTransacao);
    }
    oLog->GravarLog("a obtenção do log da última transação telemarketing" + Environment::NewLine);
  }

  private: System::Void btPagamentoPrivate_Click(System::Object^  sender, System::EventArgs^  e) {
    char valor[12 + 1];
    char numeroCupom[6 + 1];
    char numeroControle[6 + 1];

    
    oLog->GravarLog("Iniciando pagamento private label");
    classe->TransacaoPagamentoPrivateLabel(valor, numeroCupom, numeroControle);

    FechaDialogo();

    classe->ConfirmaCartao(numeroControle);
    classe->FinalizaTransacao();
    tbNSU->Text = gcnew String(numeroControle);
    
    oLog->GravarLog("Finalizando pagamento private label" + Environment::NewLine);
  }
  private: System::Void btPreAutorizacao_Click(System::Object^  sender, System::EventArgs^  e) {
    char numeroControle[6 + 1] = "000000";
    classe->TransacaoPreAutorizacao(numeroControle);
    FechaDialogo();
    classe->ConfirmaCartao(numeroControle);
    classe->FinalizaTransacao();
    tbNSU->Text = gcnew String(numeroControle);
  }
  private: System::Void btCancelamento_Click(System::Object^  sender, System::EventArgs^  e) {
    char numeroControle[6 + 1] = "000000";
    
    oLog->GravarLog("Iniciando Cancelamento");
    classe->TransacaoCancelamentoPagamento(numeroControle);
    FechaDialogo();
    classe->ConfirmaCartao(numeroControle);
    classe->FinalizaTransacao();
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando Cancelamento" + Environment::NewLine);
  }
  private: System::Void btConsultaAVS_Click(System::Object^  sender, System::EventArgs^  e) {
    char numeroControle[6 + 1] = "000000";

    
    oLog->GravarLog("Iniciando Consulta AVS");
    classe->TransacaoConsultaAVS(numeroControle);
    FechaDialogo();
    classe->FinalizaTransacao();
    tbNSU->Text = gcnew String(numeroControle);
    oLog->GravarLog("Finalizando Consulta AVS" + Environment::NewLine);
  }
  private: System::Void InterfaceExemplo_FormClosing(System::Object^  sender, System::Windows::Forms::FormClosingEventArgs^  e) {
    if (dTransacao != nullptr)
      e->Cancel = true;
  }
  private: System::Void btConfigDpos_Click(System::Object^  sender, System::EventArgs^  e) {
    classe->ConfiguraDPOS();
    classe->recarregaDll(true);
    registrarFuncoesCallBack();
  } 

private: System::Void InterfaceExemplo_KeyDown(System::Object^  sender, System::Windows::Forms::KeyEventArgs^  e) {
  switch (e->KeyCode)
  {
  case Keys::F1:
    btCredito_Click(sender, e);
    break;
  case Keys::F2:
    btDebito_Click(sender, e);
    break;
  case Keys::F3:
    btVoucherCompleta_Click(sender, e);
    break;
  case Keys::F4:
    btConsultaParcelas_Click(sender, e);
    break;
  case Keys::F5:
    btConsultaSaldo_Click(sender, e);
    break;
  case Keys::F6:
    btValeGas_Click(sender, e);
    break;
  }

}
private: System::Void tbValor_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
  
  if (!Char::IsDigit(e->KeyChar))
  {
    if (e->KeyChar != 0x08)
    {
      e->Handled = true;
      return;
    }
  }

}
private: System::Void tbCupom_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
  if (!Char::IsDigit(e->KeyChar))
  {
    if (e->KeyChar != 0x08)
    {
      e->Handled = true;
      return;
    }
  }
}
private: System::Void tbNSU_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
  if (!Char::IsDigit(e->KeyChar))
  {
    if (e->KeyChar != 0x08)
    {
      e->Handled = true;
      return;
    }
  }
}
private: System::Void tbValor_Leave(System::Object^  sender, System::EventArgs^  e) {
  tbValor->Text = tbValor->Text->PadLeft(8, '0');
}
private: System::Void tbCupom_Leave(System::Object^  sender, System::EventArgs^  e) {
  tbValor->Text = tbValor->Text->PadLeft(6, '0');
}
private: System::Void tbNSU_Leave(System::Object^  sender, System::EventArgs^  e) {
  tbValor->Text = tbValor->Text->PadLeft(6, '0');
}
#pragma endregion

};
}
