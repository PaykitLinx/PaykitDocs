#pragma once
#include "FuncoesComuns.h"

namespace ExemploInterfaceIntegracao {

  using namespace System;
  using namespace System::ComponentModel;
  using namespace System::Collections;
  using namespace System::Windows::Forms;
  using namespace System::Data;
  using namespace System::Drawing;

  /// <summary>
  /// Form para inserção de dados de transações completas, 
  /// é utilizado apenas para obter os parâmetros para a chamada da transação
  /// </summary>


// É importante observar que cada campo possui um tamanho esperado conforme descrito no manual
// os tratamentos para dos tamanhos estão sendo realizados diretamente na entrada dos dados onde é repassado o char pointer, 
// entretanto também é possível que seja repassado o array de char com o tamanho definido  garantindo assim o envio do tamanho esperado

  typedef struct{
                                  // esperam os tamanhos:
    char* tipo;                   // [2 + 1]
    char* numeroParcelas;         // [2 + 1]       
    char* valorParcela;           // [12 + 1]
    char* valorTaxaServico;       // [12 + 1]
    char* permiteAlteracao;       // [1 + 1]
    char* reservado;              // [158 + 1]
  }tsParamCreditoCompleta;
      
  typedef struct{
                                  // esperam os tamanhos:
    char* tipo;                   // [2 + 1]
    char* numeroParcelas;         // [2 + 1]
    char* valorParcela;           // [12 + 1]
    char* valorTaxaServico;       // [12 + 1]
    char* permiteAlteracao;       // [1 + 1]
    char* dataDebito;             // [8 + 1]
    char* sequenciaParcela;       // [2 + 1]
    char* reservado;              // [2 + 1]
  }tsParamDebitoCompleta;

  typedef struct{
    char* tipo;
    char* numeroParcelas;
    char* permiteAlteracao;
    char* reservado;
  }tsParamPrivateLblCompleta;

  typedef struct{
    char* numeroParcelas;
    char* dataParcela1;
    char* valorParcela1;
    char* valorEntrada;
    char* permiteAlteracao;
    char* reservado;
  }tsParamCrediarioCompleta;


  public ref class frmTransacoesCompletas : public System::Windows::Forms::Form
  {
  public:

    int iModo;
  private: System::Windows::Forms::TabPage^  tabPage5;
  private: System::Windows::Forms::GroupBox^  groupBox5;
  private: System::Windows::Forms::Label^  label1;
  private: System::Windows::Forms::Label^  label2;
  private: System::Windows::Forms::Label^  label3;
  private: System::Windows::Forms::Label^  label4;
  private: System::Windows::Forms::TextBox^  tbReservadoCC;



  private: System::Windows::Forms::TextBox^  tbNumeroParcelasCC;

  private: System::Windows::Forms::Label^  label6;
  private: System::Windows::Forms::Label^  label5;
  private: System::Windows::Forms::ComboBox^  cbPermiteAlteracaoCC;

  private: System::Windows::Forms::TextBox^  tbValorParcelaCC;
  private: System::Windows::Forms::TextBox^  tbValorEntradaCC;


  private: System::Windows::Forms::TextBox^  tbDataParcelaCC;
  private: System::Windows::Forms::Label^  label18;
  private: System::Windows::Forms::Panel^  panel1;
  private: System::Windows::Forms::Panel^  panel2;
  private: System::Windows::Forms::PictureBox^  pictureBox1;
  private: System::Windows::Forms::Panel^  panel3;
  private: System::Windows::Forms::Panel^  panel4;
  private: System::Windows::Forms::PictureBox^  pictureBox2;
  private: System::Windows::Forms::Panel^  panel5;
  private: System::Windows::Forms::PictureBox^  pictureBox4;
  private: System::Windows::Forms::PictureBox^  pictureBox3;

  public:
    Form^ caller;

    frmTransacoesCompletas(int iModo)
    {
      this->iModo = iModo;
      InitializeComponent();
      ajustaOpcoes();
    }

    frmTransacoesCompletas(int iModo, Form^ caller)
    {
      this->caller = caller;
      this->iModo = iModo;
      InitializeComponent();
      ajustaOpcoes();
    }

  public: void ajustaOpcoes();
          void selecionaTab(String^ sSelecionada);
          char* getParametrosVoucherCompleta();
          tsParamCreditoCompleta* getParametrosCreditoCompleta();
          tsParamDebitoCompleta* getParametrosDebitoCompleta();
          tsParamPrivateLblCompleta* getParametrosPrivateLabel();
          tsParamCrediarioCompleta* getParametrosCrediarioCompleta();

  protected:
    ~frmTransacoesCompletas()
    {
      if (components)
      {
        delete components;
      }
    }
  private: System::Windows::Forms::TabControl^  tcPrincipal;
  protected:

#pragma region Windows Form Designer generated code 

  protected:
  private: System::Windows::Forms::TabPage^  tabPage1;
  private: System::Windows::Forms::GroupBox^  groupBox1;
  private: System::Windows::Forms::Label^  lblReservado;

  private: System::Windows::Forms::Label^  lblPermiteAlteracao;

  private: System::Windows::Forms::Label^  lblValorParcela;
  private: System::Windows::Forms::Label^  lblTaxaServico;


  private: System::Windows::Forms::Label^  lblNumParcelas;

  private: System::Windows::Forms::Label^  lblTipoOp;
  private: System::Windows::Forms::ComboBox^  cbPermiteAlteracaoCR;


  private: System::Windows::Forms::ComboBox^  cbTipoOperacaoCR;
  private: System::Windows::Forms::TextBox^  tbReservadoCR;



  private: System::Windows::Forms::TextBox^  tbTaxaServicoCR;



  private: System::Windows::Forms::TextBox^  tbValorParcelaCR;


  private: System::Windows::Forms::TextBox^  tbNumParcelasCR;


  private: System::Windows::Forms::TabPage^  tabPage2;
  private: System::Windows::Forms::GroupBox^  groupBox2;
  private: System::Windows::Forms::Label^  label14;
  private: System::Windows::Forms::Label^  label13;
  private: System::Windows::Forms::Label^  label7;
  private: System::Windows::Forms::Label^  label8;
  private: System::Windows::Forms::Label^  label9;
  private: System::Windows::Forms::Label^  label10;
  private: System::Windows::Forms::Label^  label11;
  private: System::Windows::Forms::Label^  label12;
  private: System::Windows::Forms::ComboBox^  cbPermiteAlteracaoDB;
  private: System::Windows::Forms::TextBox^  tbSequenciaDB;


  private: System::Windows::Forms::TextBox^  tbDataDB;

  private: System::Windows::Forms::ComboBox^  cbTipoOperacaoDB;
  private: System::Windows::Forms::TextBox^  tbReservadoDB;



  private: System::Windows::Forms::TextBox^  tbTaxaServicoDB;

  private: System::Windows::Forms::TextBox^  tbValorParcelaDB;

  private: System::Windows::Forms::TextBox^  tbNumeroParcelasDB;

  private: System::Windows::Forms::TabPage^  tabPage3;
  private: System::Windows::Forms::TabPage^  tabPage4;
  private: System::Windows::Forms::GroupBox^  groupBox3;
  private: System::Windows::Forms::Label^  label17;
  private: System::Windows::Forms::TextBox^  tbReservadoVC;

  private: System::Windows::Forms::GroupBox^  groupBox4;
  private: System::Windows::Forms::Label^  label15;
  private: System::Windows::Forms::Label^  label16;
  private: System::Windows::Forms::Label^  label20;
  private: System::Windows::Forms::Label^  label21;
  private: System::Windows::Forms::ComboBox^  cbPermiteAlteracaoPL;

  private: System::Windows::Forms::ComboBox^  cbTipoOperacaoPL;
  private: System::Windows::Forms::TextBox^  tbReservadoPL;


  private: System::Windows::Forms::TextBox^  tbNumeroParcelasPL;

  private: System::Windows::Forms::Button^  btCancelar;
  private: System::Windows::Forms::Button^  btOk;

  private:
    /// <summary>
    /// Required designer variable.
    /// </summary>
    System::ComponentModel::Container ^components;
#pragma endregion

#pragma region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    void InitializeComponent(void)
    {
      System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(frmTransacoesCompletas::typeid));
      this->tcPrincipal = (gcnew System::Windows::Forms::TabControl());
      this->tabPage1 = (gcnew System::Windows::Forms::TabPage());
      this->pictureBox4 = (gcnew System::Windows::Forms::PictureBox());
      this->panel1 = (gcnew System::Windows::Forms::Panel());
      this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
      this->lblReservado = (gcnew System::Windows::Forms::Label());
      this->lblPermiteAlteracao = (gcnew System::Windows::Forms::Label());
      this->lblValorParcela = (gcnew System::Windows::Forms::Label());
      this->lblTaxaServico = (gcnew System::Windows::Forms::Label());
      this->lblNumParcelas = (gcnew System::Windows::Forms::Label());
      this->lblTipoOp = (gcnew System::Windows::Forms::Label());
      this->cbPermiteAlteracaoCR = (gcnew System::Windows::Forms::ComboBox());
      this->cbTipoOperacaoCR = (gcnew System::Windows::Forms::ComboBox());
      this->tbReservadoCR = (gcnew System::Windows::Forms::TextBox());
      this->tbTaxaServicoCR = (gcnew System::Windows::Forms::TextBox());
      this->tbValorParcelaCR = (gcnew System::Windows::Forms::TextBox());
      this->tbNumParcelasCR = (gcnew System::Windows::Forms::TextBox());
      this->tabPage2 = (gcnew System::Windows::Forms::TabPage());
      this->panel2 = (gcnew System::Windows::Forms::Panel());
      this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
      this->label14 = (gcnew System::Windows::Forms::Label());
      this->label13 = (gcnew System::Windows::Forms::Label());
      this->label7 = (gcnew System::Windows::Forms::Label());
      this->label8 = (gcnew System::Windows::Forms::Label());
      this->label9 = (gcnew System::Windows::Forms::Label());
      this->label10 = (gcnew System::Windows::Forms::Label());
      this->label11 = (gcnew System::Windows::Forms::Label());
      this->label12 = (gcnew System::Windows::Forms::Label());
      this->cbPermiteAlteracaoDB = (gcnew System::Windows::Forms::ComboBox());
      this->tbSequenciaDB = (gcnew System::Windows::Forms::TextBox());
      this->tbDataDB = (gcnew System::Windows::Forms::TextBox());
      this->cbTipoOperacaoDB = (gcnew System::Windows::Forms::ComboBox());
      this->tbReservadoDB = (gcnew System::Windows::Forms::TextBox());
      this->tbTaxaServicoDB = (gcnew System::Windows::Forms::TextBox());
      this->tbValorParcelaDB = (gcnew System::Windows::Forms::TextBox());
      this->tbNumeroParcelasDB = (gcnew System::Windows::Forms::TextBox());
      this->tabPage3 = (gcnew System::Windows::Forms::TabPage());
      this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
      this->panel3 = (gcnew System::Windows::Forms::Panel());
      this->groupBox3 = (gcnew System::Windows::Forms::GroupBox());
      this->label17 = (gcnew System::Windows::Forms::Label());
      this->tbReservadoVC = (gcnew System::Windows::Forms::TextBox());
      this->tabPage4 = (gcnew System::Windows::Forms::TabPage());
      this->panel4 = (gcnew System::Windows::Forms::Panel());
      this->groupBox4 = (gcnew System::Windows::Forms::GroupBox());
      this->label15 = (gcnew System::Windows::Forms::Label());
      this->label16 = (gcnew System::Windows::Forms::Label());
      this->label20 = (gcnew System::Windows::Forms::Label());
      this->label21 = (gcnew System::Windows::Forms::Label());
      this->cbPermiteAlteracaoPL = (gcnew System::Windows::Forms::ComboBox());
      this->cbTipoOperacaoPL = (gcnew System::Windows::Forms::ComboBox());
      this->tbReservadoPL = (gcnew System::Windows::Forms::TextBox());
      this->tbNumeroParcelasPL = (gcnew System::Windows::Forms::TextBox());
      this->pictureBox2 = (gcnew System::Windows::Forms::PictureBox());
      this->tabPage5 = (gcnew System::Windows::Forms::TabPage());
      this->pictureBox3 = (gcnew System::Windows::Forms::PictureBox());
      this->panel5 = (gcnew System::Windows::Forms::Panel());
      this->groupBox5 = (gcnew System::Windows::Forms::GroupBox());
      this->label1 = (gcnew System::Windows::Forms::Label());
      this->label2 = (gcnew System::Windows::Forms::Label());
      this->label6 = (gcnew System::Windows::Forms::Label());
      this->label3 = (gcnew System::Windows::Forms::Label());
      this->label5 = (gcnew System::Windows::Forms::Label());
      this->label18 = (gcnew System::Windows::Forms::Label());
      this->label4 = (gcnew System::Windows::Forms::Label());
      this->cbPermiteAlteracaoCC = (gcnew System::Windows::Forms::ComboBox());
      this->tbReservadoCC = (gcnew System::Windows::Forms::TextBox());
      this->tbValorParcelaCC = (gcnew System::Windows::Forms::TextBox());
      this->tbValorEntradaCC = (gcnew System::Windows::Forms::TextBox());
      this->tbDataParcelaCC = (gcnew System::Windows::Forms::TextBox());
      this->tbNumeroParcelasCC = (gcnew System::Windows::Forms::TextBox());
      this->btCancelar = (gcnew System::Windows::Forms::Button());
      this->btOk = (gcnew System::Windows::Forms::Button());
      this->tcPrincipal->SuspendLayout();
      this->tabPage1->SuspendLayout();
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox4))->BeginInit();
      this->panel1->SuspendLayout();
      this->groupBox1->SuspendLayout();
      this->tabPage2->SuspendLayout();
      this->panel2->SuspendLayout();
      this->groupBox2->SuspendLayout();
      this->tabPage3->SuspendLayout();
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
      this->panel3->SuspendLayout();
      this->groupBox3->SuspendLayout();
      this->tabPage4->SuspendLayout();
      this->panel4->SuspendLayout();
      this->groupBox4->SuspendLayout();
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->BeginInit();
      this->tabPage5->SuspendLayout();
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox3))->BeginInit();
      this->panel5->SuspendLayout();
      this->groupBox5->SuspendLayout();
      this->SuspendLayout();
      // 
      // tcPrincipal
      // 
      this->tcPrincipal->Controls->Add(this->tabPage1);
      this->tcPrincipal->Controls->Add(this->tabPage2);
      this->tcPrincipal->Controls->Add(this->tabPage3);
      this->tcPrincipal->Controls->Add(this->tabPage4);
      this->tcPrincipal->Controls->Add(this->tabPage5);
      this->tcPrincipal->Location = System::Drawing::Point(5, 11);
      this->tcPrincipal->Name = L"tcPrincipal";
      this->tcPrincipal->SelectedIndex = 0;
      this->tcPrincipal->Size = System::Drawing::Size(378, 412);
      this->tcPrincipal->TabIndex = 0;
      this->tcPrincipal->TabStop = false;
      // 
      // tabPage1
      // 
      this->tabPage1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->tabPage1->Controls->Add(this->pictureBox4);
      this->tabPage1->Controls->Add(this->panel1);
      this->tabPage1->Location = System::Drawing::Point(4, 22);
      this->tabPage1->Name = L"tabPage1";
      this->tabPage1->Padding = System::Windows::Forms::Padding(3);
      this->tabPage1->Size = System::Drawing::Size(370, 386);
      this->tabPage1->TabIndex = 0;
      this->tabPage1->Text = L"Crédito Completa";
      // 
      // pictureBox4
      // 
      this->pictureBox4->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox4.Image")));
      this->pictureBox4->Location = System::Drawing::Point(127, 297);
      this->pictureBox4->Name = L"pictureBox4";
      this->pictureBox4->Size = System::Drawing::Size(143, 86);
      this->pictureBox4->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
      this->pictureBox4->TabIndex = 3;
      this->pictureBox4->TabStop = false;
      // 
      // panel1
      // 
      this->panel1->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      this->panel1->Controls->Add(this->groupBox1);
      this->panel1->Location = System::Drawing::Point(6, 3);
      this->panel1->Name = L"panel1";
      this->panel1->Size = System::Drawing::Size(358, 293);
      this->panel1->TabIndex = 1;
      // 
      // groupBox1
      // 
      this->groupBox1->BackColor = System::Drawing::Color::WhiteSmoke;
      this->groupBox1->Controls->Add(this->lblReservado);
      this->groupBox1->Controls->Add(this->lblPermiteAlteracao);
      this->groupBox1->Controls->Add(this->lblValorParcela);
      this->groupBox1->Controls->Add(this->lblTaxaServico);
      this->groupBox1->Controls->Add(this->lblNumParcelas);
      this->groupBox1->Controls->Add(this->lblTipoOp);
      this->groupBox1->Controls->Add(this->cbPermiteAlteracaoCR);
      this->groupBox1->Controls->Add(this->cbTipoOperacaoCR);
      this->groupBox1->Controls->Add(this->tbReservadoCR);
      this->groupBox1->Controls->Add(this->tbTaxaServicoCR);
      this->groupBox1->Controls->Add(this->tbValorParcelaCR);
      this->groupBox1->Controls->Add(this->tbNumParcelasCR);
      this->groupBox1->Location = System::Drawing::Point(3, 9);
      this->groupBox1->Name = L"groupBox1";
      this->groupBox1->Size = System::Drawing::Size(340, 277);
      this->groupBox1->TabIndex = 0;
      this->groupBox1->TabStop = false;
      this->groupBox1->Text = L"Transação de Crédito Completa";
      // 
      // lblReservado
      // 
      this->lblReservado->AutoSize = true;
      this->lblReservado->Location = System::Drawing::Point(15, 246);
      this->lblReservado->Name = L"lblReservado";
      this->lblReservado->Size = System::Drawing::Size(59, 13);
      this->lblReservado->TabIndex = 2;
      this->lblReservado->Text = L"Reservado";
      // 
      // lblPermiteAlteracao
      // 
      this->lblPermiteAlteracao->AutoSize = true;
      this->lblPermiteAlteracao->Location = System::Drawing::Point(15, 208);
      this->lblPermiteAlteracao->Name = L"lblPermiteAlteracao";
      this->lblPermiteAlteracao->Size = System::Drawing::Size(90, 13);
      this->lblPermiteAlteracao->TabIndex = 2;
      this->lblPermiteAlteracao->Text = L"Permite Alteração";
      // 
      // lblValorParcela
      // 
      this->lblValorParcela->AutoSize = true;
      this->lblValorParcela->Location = System::Drawing::Point(15, 121);
      this->lblValorParcela->Name = L"lblValorParcela";
      this->lblValorParcela->Size = System::Drawing::Size(85, 13);
      this->lblValorParcela->TabIndex = 2;
      this->lblValorParcela->Text = L"Valor da Parcela";
      // 
      // lblTaxaServico
      // 
      this->lblTaxaServico->AutoSize = true;
      this->lblTaxaServico->Location = System::Drawing::Point(15, 162);
      this->lblTaxaServico->Name = L"lblTaxaServico";
      this->lblTaxaServico->Size = System::Drawing::Size(70, 13);
      this->lblTaxaServico->TabIndex = 2;
      this->lblTaxaServico->Text = L"Taxa Serviço";
      // 
      // lblNumParcelas
      // 
      this->lblNumParcelas->AutoSize = true;
      this->lblNumParcelas->Location = System::Drawing::Point(15, 77);
      this->lblNumParcelas->Name = L"lblNumParcelas";
      this->lblNumParcelas->Size = System::Drawing::Size(88, 13);
      this->lblNumParcelas->TabIndex = 2;
      this->lblNumParcelas->Text = L"Número Parcelas";
      // 
      // lblTipoOp
      // 
      this->lblTipoOp->AutoSize = true;
      this->lblTipoOp->Location = System::Drawing::Point(15, 38);
      this->lblTipoOp->Name = L"lblTipoOp";
      this->lblTipoOp->Size = System::Drawing::Size(78, 13);
      this->lblTipoOp->TabIndex = 2;
      this->lblTipoOp->Text = L"Tipo Operação";
      // 
      // cbPermiteAlteracaoCR
      // 
      this->cbPermiteAlteracaoCR->FormattingEnabled = true;
      this->cbPermiteAlteracaoCR->Items->AddRange(gcnew cli::array< System::Object^  >(2) { L"S", L"N" });
      this->cbPermiteAlteracaoCR->Location = System::Drawing::Point(135, 204);
      this->cbPermiteAlteracaoCR->Name = L"cbPermiteAlteracaoCR";
      this->cbPermiteAlteracaoCR->Size = System::Drawing::Size(80, 21);
      this->cbPermiteAlteracaoCR->TabIndex = 4;
      // 
      // cbTipoOperacaoCR
      // 
      this->cbTipoOperacaoCR->FormattingEnabled = true;
      this->cbTipoOperacaoCR->Items->AddRange(gcnew cli::array< System::Object^  >(3) { L"AV", L"FL", L"FA" });
      this->cbTipoOperacaoCR->Location = System::Drawing::Point(133, 35);
      this->cbTipoOperacaoCR->Name = L"cbTipoOperacaoCR";
      this->cbTipoOperacaoCR->Size = System::Drawing::Size(80, 21);
      this->cbTipoOperacaoCR->TabIndex = 0;
      // 
      // tbReservadoCR
      // 
      this->tbReservadoCR->Location = System::Drawing::Point(133, 243);
      this->tbReservadoCR->MaxLength = 158;
      this->tbReservadoCR->Name = L"tbReservadoCR";
      this->tbReservadoCR->Size = System::Drawing::Size(188, 20);
      this->tbReservadoCR->TabIndex = 5;
      this->tbReservadoCR->Text = L"000000000000000000000000000000000000000000000000000000000000000000000000000000000"
        L"00000000000000000000000000000000000000000000000000000000000000000000000000000";
      // 
      // tbTaxaServicoCR
      // 
      this->tbTaxaServicoCR->Location = System::Drawing::Point(135, 162);
      this->tbTaxaServicoCR->Name = L"tbTaxaServicoCR";
      this->tbTaxaServicoCR->Size = System::Drawing::Size(143, 20);
      this->tbTaxaServicoCR->TabIndex = 3;
      this->tbTaxaServicoCR->Text = L"0,00";
      this->tbTaxaServicoCR->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &frmTransacoesCompletas::tbTaxaServicoCR_KeyPress);
      // 
      // tbValorParcelaCR
      // 
      this->tbValorParcelaCR->Location = System::Drawing::Point(133, 118);
      this->tbValorParcelaCR->MaxLength = 13;
      this->tbValorParcelaCR->Name = L"tbValorParcelaCR";
      this->tbValorParcelaCR->Size = System::Drawing::Size(145, 20);
      this->tbValorParcelaCR->TabIndex = 2;
      this->tbValorParcelaCR->Text = L"0,00";
      this->tbValorParcelaCR->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &frmTransacoesCompletas::tbValorParcelaCR_KeyPress);
      // 
      // tbNumParcelasCR
      // 
      this->tbNumParcelasCR->Location = System::Drawing::Point(133, 74);
      this->tbNumParcelasCR->MaxLength = 2;
      this->tbNumParcelasCR->Name = L"tbNumParcelasCR";
      this->tbNumParcelasCR->Size = System::Drawing::Size(80, 20);
      this->tbNumParcelasCR->TabIndex = 1;
      this->tbNumParcelasCR->Text = L"0";
      // 
      // tabPage2
      // 
      this->tabPage2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->tabPage2->Controls->Add(this->panel2);
      this->tabPage2->Location = System::Drawing::Point(4, 22);
      this->tabPage2->Name = L"tabPage2";
      this->tabPage2->Padding = System::Windows::Forms::Padding(3);
      this->tabPage2->Size = System::Drawing::Size(370, 386);
      this->tabPage2->TabIndex = 1;
      this->tabPage2->Text = L"Débito Completa";
      // 
      // panel2
      // 
      this->panel2->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel2->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      this->panel2->Controls->Add(this->groupBox2);
      this->panel2->Location = System::Drawing::Point(5, 7);
      this->panel2->Name = L"panel2";
      this->panel2->RightToLeft = System::Windows::Forms::RightToLeft::No;
      this->panel2->Size = System::Drawing::Size(356, 374);
      this->panel2->TabIndex = 0;
      // 
      // groupBox2
      // 
      this->groupBox2->BackColor = System::Drawing::Color::WhiteSmoke;
      this->groupBox2->Controls->Add(this->label14);
      this->groupBox2->Controls->Add(this->label13);
      this->groupBox2->Controls->Add(this->label7);
      this->groupBox2->Controls->Add(this->label8);
      this->groupBox2->Controls->Add(this->label9);
      this->groupBox2->Controls->Add(this->label10);
      this->groupBox2->Controls->Add(this->label11);
      this->groupBox2->Controls->Add(this->label12);
      this->groupBox2->Controls->Add(this->cbPermiteAlteracaoDB);
      this->groupBox2->Controls->Add(this->tbSequenciaDB);
      this->groupBox2->Controls->Add(this->tbDataDB);
      this->groupBox2->Controls->Add(this->cbTipoOperacaoDB);
      this->groupBox2->Controls->Add(this->tbReservadoDB);
      this->groupBox2->Controls->Add(this->tbTaxaServicoDB);
      this->groupBox2->Controls->Add(this->tbValorParcelaDB);
      this->groupBox2->Controls->Add(this->tbNumeroParcelasDB);
      this->groupBox2->Location = System::Drawing::Point(3, 3);
      this->groupBox2->Name = L"groupBox2";
      this->groupBox2->Size = System::Drawing::Size(346, 368);
      this->groupBox2->TabIndex = 1;
      this->groupBox2->TabStop = false;
      this->groupBox2->Text = L"Transação de Débito Completa";
      // 
      // label14
      // 
      this->label14->AutoSize = true;
      this->label14->Location = System::Drawing::Point(22, 345);
      this->label14->Name = L"label14";
      this->label14->Size = System::Drawing::Size(97, 13);
      this->label14->TabIndex = 2;
      this->label14->Text = L"Sequencia Parcela";
      // 
      // label13
      // 
      this->label13->AutoSize = true;
      this->label13->Location = System::Drawing::Point(22, 302);
      this->label13->Name = L"label13";
      this->label13->Size = System::Drawing::Size(79, 13);
      this->label13->TabIndex = 2;
      this->label13->Text = L"Data do Débito";
      // 
      // label7
      // 
      this->label7->AutoSize = true;
      this->label7->Location = System::Drawing::Point(22, 259);
      this->label7->Name = L"label7";
      this->label7->Size = System::Drawing::Size(59, 13);
      this->label7->TabIndex = 2;
      this->label7->Text = L"Reservado";
      // 
      // label8
      // 
      this->label8->AutoSize = true;
      this->label8->Location = System::Drawing::Point(22, 221);
      this->label8->Name = L"label8";
      this->label8->Size = System::Drawing::Size(90, 13);
      this->label8->TabIndex = 2;
      this->label8->Text = L"Permite Alteração";
      // 
      // label9
      // 
      this->label9->AutoSize = true;
      this->label9->Location = System::Drawing::Point(22, 134);
      this->label9->Name = L"label9";
      this->label9->Size = System::Drawing::Size(85, 13);
      this->label9->TabIndex = 2;
      this->label9->Text = L"Valor da Parcela";
      // 
      // label10
      // 
      this->label10->AutoSize = true;
      this->label10->Location = System::Drawing::Point(22, 175);
      this->label10->Name = L"label10";
      this->label10->Size = System::Drawing::Size(70, 13);
      this->label10->TabIndex = 2;
      this->label10->Text = L"Taxa Serviço";
      // 
      // label11
      // 
      this->label11->AutoSize = true;
      this->label11->Location = System::Drawing::Point(22, 90);
      this->label11->Name = L"label11";
      this->label11->Size = System::Drawing::Size(88, 13);
      this->label11->TabIndex = 2;
      this->label11->Text = L"Número Parcelas";
      // 
      // label12
      // 
      this->label12->AutoSize = true;
      this->label12->Location = System::Drawing::Point(22, 51);
      this->label12->Name = L"label12";
      this->label12->Size = System::Drawing::Size(78, 13);
      this->label12->TabIndex = 2;
      this->label12->Text = L"Tipo Operação";
      // 
      // cbPermiteAlteracaoDB
      // 
      this->cbPermiteAlteracaoDB->FormattingEnabled = true;
      this->cbPermiteAlteracaoDB->Items->AddRange(gcnew cli::array< System::Object^  >(2) { L"S", L"N" });
      this->cbPermiteAlteracaoDB->Location = System::Drawing::Point(140, 218);
      this->cbPermiteAlteracaoDB->Name = L"cbPermiteAlteracaoDB";
      this->cbPermiteAlteracaoDB->Size = System::Drawing::Size(80, 21);
      this->cbPermiteAlteracaoDB->TabIndex = 4;
      // 
      // tbSequenciaDB
      // 
      this->tbSequenciaDB->Location = System::Drawing::Point(140, 342);
      this->tbSequenciaDB->MaxLength = 2;
      this->tbSequenciaDB->Name = L"tbSequenciaDB";
      this->tbSequenciaDB->Size = System::Drawing::Size(42, 20);
      this->tbSequenciaDB->TabIndex = 7;
      this->tbSequenciaDB->Text = L"00";
      // 
      // tbDataDB
      // 
      this->tbDataDB->Location = System::Drawing::Point(140, 299);
      this->tbDataDB->MaxLength = 10;
      this->tbDataDB->Name = L"tbDataDB";
      this->tbDataDB->Size = System::Drawing::Size(80, 20);
      this->tbDataDB->TabIndex = 6;
      this->tbDataDB->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &frmTransacoesCompletas::tbDataDB_KeyPress);
      // 
      // cbTipoOperacaoDB
      // 
      this->cbTipoOperacaoDB->DisplayMember = L"1";
      this->cbTipoOperacaoDB->FormattingEnabled = true;
      this->cbTipoOperacaoDB->Items->AddRange(gcnew cli::array< System::Object^  >(6) { L"AV", L"PS", L"PC", L"PD", L"PE", L"PM" });
      this->cbTipoOperacaoDB->Location = System::Drawing::Point(140, 48);
      this->cbTipoOperacaoDB->Name = L"cbTipoOperacaoDB";
      this->cbTipoOperacaoDB->Size = System::Drawing::Size(67, 21);
      this->cbTipoOperacaoDB->TabIndex = 0;
      this->cbTipoOperacaoDB->ValueMember = L"1";
      // 
      // tbReservadoDB
      // 
      this->tbReservadoDB->Location = System::Drawing::Point(140, 256);
      this->tbReservadoDB->MaxLength = 158;
      this->tbReservadoDB->Name = L"tbReservadoDB";
      this->tbReservadoDB->Size = System::Drawing::Size(199, 20);
      this->tbReservadoDB->TabIndex = 5;
      this->tbReservadoDB->Text = L"000000000000000000000000000000000000000000000000000000000000000000000000000000000"
        L"00000000000000000000000000000000000000000000000000000000000000000000000000000";
      // 
      // tbTaxaServicoDB
      // 
      this->tbTaxaServicoDB->Location = System::Drawing::Point(140, 175);
      this->tbTaxaServicoDB->Name = L"tbTaxaServicoDB";
      this->tbTaxaServicoDB->Size = System::Drawing::Size(143, 20);
      this->tbTaxaServicoDB->TabIndex = 3;
      this->tbTaxaServicoDB->Text = L"0,00";
      this->tbTaxaServicoDB->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &frmTransacoesCompletas::tbTaxaServicoDB_KeyPress);
      // 
      // tbValorParcelaDB
      // 
      this->tbValorParcelaDB->Location = System::Drawing::Point(140, 131);
      this->tbValorParcelaDB->Name = L"tbValorParcelaDB";
      this->tbValorParcelaDB->Size = System::Drawing::Size(145, 20);
      this->tbValorParcelaDB->TabIndex = 2;
      this->tbValorParcelaDB->Text = L"0,00";
      this->tbValorParcelaDB->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &frmTransacoesCompletas::tbValorParcelaDB_KeyPress);
      // 
      // tbNumeroParcelasDB
      // 
      this->tbNumeroParcelasDB->Location = System::Drawing::Point(140, 87);
      this->tbNumeroParcelasDB->MaxLength = 2;
      this->tbNumeroParcelasDB->Name = L"tbNumeroParcelasDB";
      this->tbNumeroParcelasDB->Size = System::Drawing::Size(80, 20);
      this->tbNumeroParcelasDB->TabIndex = 1;
      this->tbNumeroParcelasDB->Text = L"00";
      // 
      // tabPage3
      // 
      this->tabPage3->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->tabPage3->BackgroundImageLayout = System::Windows::Forms::ImageLayout::None;
      this->tabPage3->Controls->Add(this->pictureBox1);
      this->tabPage3->Controls->Add(this->panel3);
      this->tabPage3->Location = System::Drawing::Point(4, 22);
      this->tabPage3->Name = L"tabPage3";
      this->tabPage3->Size = System::Drawing::Size(370, 386);
      this->tabPage3->TabIndex = 2;
      this->tabPage3->Text = L"Voucher Completa";
      // 
      // pictureBox1
      // 
      this->pictureBox1->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox1.Image")));
      this->pictureBox1->Location = System::Drawing::Point(112, 259);
      this->pictureBox1->Name = L"pictureBox1";
      this->pictureBox1->Size = System::Drawing::Size(177, 109);
      this->pictureBox1->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
      this->pictureBox1->TabIndex = 1;
      this->pictureBox1->TabStop = false;
      // 
      // panel3
      // 
      this->panel3->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel3->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      this->panel3->Controls->Add(this->groupBox3);
      this->panel3->Location = System::Drawing::Point(6, 6);
      this->panel3->Name = L"panel3";
      this->panel3->Size = System::Drawing::Size(355, 247);
      this->panel3->TabIndex = 0;
      // 
      // groupBox3
      // 
      this->groupBox3->BackColor = System::Drawing::Color::WhiteSmoke;
      this->groupBox3->Controls->Add(this->label17);
      this->groupBox3->Controls->Add(this->tbReservadoVC);
      this->groupBox3->Location = System::Drawing::Point(3, 3);
      this->groupBox3->Name = L"groupBox3";
      this->groupBox3->Size = System::Drawing::Size(345, 206);
      this->groupBox3->TabIndex = 2;
      this->groupBox3->TabStop = false;
      this->groupBox3->Text = L"Transação de Voucher Completa";
      // 
      // label17
      // 
      this->label17->AutoSize = true;
      this->label17->Location = System::Drawing::Point(12, 38);
      this->label17->Name = L"label17";
      this->label17->Size = System::Drawing::Size(59, 13);
      this->label17->TabIndex = 2;
      this->label17->Text = L"Reservado";
      // 
      // tbReservadoVC
      // 
      this->tbReservadoVC->Location = System::Drawing::Point(89, 35);
      this->tbReservadoVC->MaxLength = 158;
      this->tbReservadoVC->Name = L"tbReservadoVC";
      this->tbReservadoVC->Size = System::Drawing::Size(246, 20);
      this->tbReservadoVC->TabIndex = 0;
      this->tbReservadoVC->Text = L"000000000000000000000000000000000000000000000000000000000000000000000000000000000"
        L"00000000000000000000000000000000000000000000000000000000000000000000000000000";
      // 
      // tabPage4
      // 
      this->tabPage4->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->tabPage4->Controls->Add(this->panel4);
      this->tabPage4->Controls->Add(this->pictureBox2);
      this->tabPage4->Location = System::Drawing::Point(4, 22);
      this->tabPage4->Name = L"tabPage4";
      this->tabPage4->Size = System::Drawing::Size(370, 386);
      this->tabPage4->TabIndex = 3;
      this->tabPage4->Text = L"Private Label Completa";
      // 
      // panel4
      // 
      this->panel4->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel4->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      this->panel4->Controls->Add(this->groupBox4);
      this->panel4->Location = System::Drawing::Point(4, 4);
      this->panel4->Name = L"panel4";
      this->panel4->Size = System::Drawing::Size(358, 251);
      this->panel4->TabIndex = 3;
      // 
      // groupBox4
      // 
      this->groupBox4->BackColor = System::Drawing::Color::WhiteSmoke;
      this->groupBox4->Controls->Add(this->label15);
      this->groupBox4->Controls->Add(this->label16);
      this->groupBox4->Controls->Add(this->label20);
      this->groupBox4->Controls->Add(this->label21);
      this->groupBox4->Controls->Add(this->cbPermiteAlteracaoPL);
      this->groupBox4->Controls->Add(this->cbTipoOperacaoPL);
      this->groupBox4->Controls->Add(this->tbReservadoPL);
      this->groupBox4->Controls->Add(this->tbNumeroParcelasPL);
      this->groupBox4->Location = System::Drawing::Point(4, 3);
      this->groupBox4->Name = L"groupBox4";
      this->groupBox4->Size = System::Drawing::Size(359, 219);
      this->groupBox4->TabIndex = 1;
      this->groupBox4->TabStop = false;
      this->groupBox4->Text = L"Transação de cartão private label completa";
      // 
      // label15
      // 
      this->label15->AutoSize = true;
      this->label15->Location = System::Drawing::Point(21, 170);
      this->label15->Name = L"label15";
      this->label15->Size = System::Drawing::Size(59, 13);
      this->label15->TabIndex = 2;
      this->label15->Text = L"Reservado";
      // 
      // label16
      // 
      this->label16->AutoSize = true;
      this->label16->Location = System::Drawing::Point(21, 132);
      this->label16->Name = L"label16";
      this->label16->Size = System::Drawing::Size(90, 13);
      this->label16->TabIndex = 2;
      this->label16->Text = L"Permite Alteração";
      // 
      // label20
      // 
      this->label20->AutoSize = true;
      this->label20->Location = System::Drawing::Point(21, 88);
      this->label20->Name = L"label20";
      this->label20->Size = System::Drawing::Size(88, 13);
      this->label20->TabIndex = 2;
      this->label20->Text = L"Número Parcelas";
      // 
      // label21
      // 
      this->label21->AutoSize = true;
      this->label21->Location = System::Drawing::Point(21, 49);
      this->label21->Name = L"label21";
      this->label21->Size = System::Drawing::Size(78, 13);
      this->label21->TabIndex = 2;
      this->label21->Text = L"Tipo Operação";
      // 
      // cbPermiteAlteracaoPL
      // 
      this->cbPermiteAlteracaoPL->FormattingEnabled = true;
      this->cbPermiteAlteracaoPL->Items->AddRange(gcnew cli::array< System::Object^  >(2) { L"S", L"N" });
      this->cbPermiteAlteracaoPL->Location = System::Drawing::Point(141, 128);
      this->cbPermiteAlteracaoPL->Name = L"cbPermiteAlteracaoPL";
      this->cbPermiteAlteracaoPL->Size = System::Drawing::Size(80, 21);
      this->cbPermiteAlteracaoPL->TabIndex = 3;
      // 
      // cbTipoOperacaoPL
      // 
      this->cbTipoOperacaoPL->FormattingEnabled = true;
      this->cbTipoOperacaoPL->Items->AddRange(gcnew cli::array< System::Object^  >(4) { L"AV", L"FL", L"FA", L"PD" });
      this->cbTipoOperacaoPL->Location = System::Drawing::Point(139, 46);
      this->cbTipoOperacaoPL->Name = L"cbTipoOperacaoPL";
      this->cbTipoOperacaoPL->Size = System::Drawing::Size(80, 21);
      this->cbTipoOperacaoPL->TabIndex = 1;
      // 
      // tbReservadoPL
      // 
      this->tbReservadoPL->Location = System::Drawing::Point(139, 167);
      this->tbReservadoPL->MaxLength = 158;
      this->tbReservadoPL->Name = L"tbReservadoPL";
      this->tbReservadoPL->Size = System::Drawing::Size(204, 20);
      this->tbReservadoPL->TabIndex = 4;
      this->tbReservadoPL->Text = L"000000000000000000000000000000000000000000000000000000000000000000000000000000000"
        L"00000000000000000000000000000000000000000000000000000000000000000000000000000";
      // 
      // tbNumeroParcelasPL
      // 
      this->tbNumeroParcelasPL->Location = System::Drawing::Point(139, 85);
      this->tbNumeroParcelasPL->MaxLength = 2;
      this->tbNumeroParcelasPL->Name = L"tbNumeroParcelasPL";
      this->tbNumeroParcelasPL->Size = System::Drawing::Size(80, 20);
      this->tbNumeroParcelasPL->TabIndex = 2;
      this->tbNumeroParcelasPL->Text = L"00";
      // 
      // pictureBox2
      // 
      this->pictureBox2->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox2.Image")));
      this->pictureBox2->Location = System::Drawing::Point(108, 261);
      this->pictureBox2->Name = L"pictureBox2";
      this->pictureBox2->Size = System::Drawing::Size(177, 109);
      this->pictureBox2->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
      this->pictureBox2->TabIndex = 2;
      this->pictureBox2->TabStop = false;
      // 
      // tabPage5
      // 
      this->tabPage5->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->tabPage5->Controls->Add(this->pictureBox3);
      this->tabPage5->Controls->Add(this->panel5);
      this->tabPage5->Location = System::Drawing::Point(4, 22);
      this->tabPage5->Name = L"tabPage5";
      this->tabPage5->Size = System::Drawing::Size(370, 386);
      this->tabPage5->TabIndex = 4;
      this->tabPage5->Text = L"Crediário Completa";
      // 
      // pictureBox3
      // 
      this->pictureBox3->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox3.Image")));
      this->pictureBox3->Location = System::Drawing::Point(126, 292);
      this->pictureBox3->Name = L"pictureBox3";
      this->pictureBox3->Size = System::Drawing::Size(144, 88);
      this->pictureBox3->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
      this->pictureBox3->TabIndex = 2;
      this->pictureBox3->TabStop = false;
      // 
      // panel5
      // 
      this->panel5->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel5->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
      this->panel5->Controls->Add(this->groupBox5);
      this->panel5->Location = System::Drawing::Point(3, 5);
      this->panel5->Name = L"panel5";
      this->panel5->Size = System::Drawing::Size(364, 284);
      this->panel5->TabIndex = 0;
      // 
      // groupBox5
      // 
      this->groupBox5->BackColor = System::Drawing::Color::WhiteSmoke;
      this->groupBox5->Controls->Add(this->label1);
      this->groupBox5->Controls->Add(this->label2);
      this->groupBox5->Controls->Add(this->label6);
      this->groupBox5->Controls->Add(this->label3);
      this->groupBox5->Controls->Add(this->label5);
      this->groupBox5->Controls->Add(this->label18);
      this->groupBox5->Controls->Add(this->label4);
      this->groupBox5->Controls->Add(this->cbPermiteAlteracaoCC);
      this->groupBox5->Controls->Add(this->tbReservadoCC);
      this->groupBox5->Controls->Add(this->tbValorParcelaCC);
      this->groupBox5->Controls->Add(this->tbValorEntradaCC);
      this->groupBox5->Controls->Add(this->tbDataParcelaCC);
      this->groupBox5->Controls->Add(this->tbNumeroParcelasCC);
      this->groupBox5->Location = System::Drawing::Point(3, 3);
      this->groupBox5->Name = L"groupBox5";
      this->groupBox5->Size = System::Drawing::Size(359, 268);
      this->groupBox5->TabIndex = 2;
      this->groupBox5->TabStop = false;
      this->groupBox5->Text = L"Transação de cartão crediário completa";
      // 
      // label1
      // 
      this->label1->AutoSize = true;
      this->label1->Location = System::Drawing::Point(21, 236);
      this->label1->Name = L"label1";
      this->label1->Size = System::Drawing::Size(59, 13);
      this->label1->TabIndex = 2;
      this->label1->Text = L"Reservado";
      // 
      // label2
      // 
      this->label2->AutoSize = true;
      this->label2->Location = System::Drawing::Point(21, 198);
      this->label2->Name = L"label2";
      this->label2->Size = System::Drawing::Size(90, 13);
      this->label2->TabIndex = 2;
      this->label2->Text = L"Permite Alteração";
      // 
      // label6
      // 
      this->label6->AutoSize = true;
      this->label6->Location = System::Drawing::Point(21, 155);
      this->label6->Name = L"label6";
      this->label6->Size = System::Drawing::Size(71, 13);
      this->label6->TabIndex = 2;
      this->label6->Text = L"Valor Entrada";
      // 
      // label3
      // 
      this->label3->AutoSize = true;
      this->label3->Location = System::Drawing::Point(21, 38);
      this->label3->Name = L"label3";
      this->label3->Size = System::Drawing::Size(88, 13);
      this->label3->TabIndex = 2;
      this->label3->Text = L"Número Parcelas";
      // 
      // label5
      // 
      this->label5->AutoSize = true;
      this->label5->Location = System::Drawing::Point(21, 116);
      this->label5->Name = L"label5";
      this->label5->Size = System::Drawing::Size(79, 13);
      this->label5->TabIndex = 2;
      this->label5->Text = L"Valor Parcela 1";
      // 
      // label18
      // 
      this->label18->AutoSize = true;
      this->label18->Location = System::Drawing::Point(221, 78);
      this->label18->Name = L"label18";
      this->label18->Size = System::Drawing::Size(65, 13);
      this->label18->TabIndex = 2;
      this->label18->Text = L"(ddmmaaaa)";
      // 
      // label4
      // 
      this->label4->AutoSize = true;
      this->label4->Location = System::Drawing::Point(21, 78);
      this->label4->Name = L"label4";
      this->label4->Size = System::Drawing::Size(78, 13);
      this->label4->TabIndex = 2;
      this->label4->Text = L"Data Parcela 1";
      // 
      // cbPermiteAlteracaoCC
      // 
      this->cbPermiteAlteracaoCC->FormattingEnabled = true;
      this->cbPermiteAlteracaoCC->Items->AddRange(gcnew cli::array< System::Object^  >(2) { L"S", L"N" });
      this->cbPermiteAlteracaoCC->Location = System::Drawing::Point(139, 195);
      this->cbPermiteAlteracaoCC->Name = L"cbPermiteAlteracaoCC";
      this->cbPermiteAlteracaoCC->Size = System::Drawing::Size(80, 21);
      this->cbPermiteAlteracaoCC->TabIndex = 4;
      // 
      // tbReservadoCC
      // 
      this->tbReservadoCC->Location = System::Drawing::Point(139, 233);
      this->tbReservadoCC->MaxLength = 158;
      this->tbReservadoCC->Name = L"tbReservadoCC";
      this->tbReservadoCC->Size = System::Drawing::Size(204, 20);
      this->tbReservadoCC->TabIndex = 5;
      this->tbReservadoCC->Text = L"000000000000000000000000000000000000000000000000000000000000000000000000000000000"
        L"00000000000000000000000000000000000000000000000000000000000000000000000000000";
      // 
      // tbValorParcelaCC
      // 
      this->tbValorParcelaCC->Location = System::Drawing::Point(139, 109);
      this->tbValorParcelaCC->MaxLength = 12;
      this->tbValorParcelaCC->Name = L"tbValorParcelaCC";
      this->tbValorParcelaCC->Size = System::Drawing::Size(80, 20);
      this->tbValorParcelaCC->TabIndex = 2;
      this->tbValorParcelaCC->Text = L"000000000000";
      // 
      // tbValorEntradaCC
      // 
      this->tbValorEntradaCC->Location = System::Drawing::Point(139, 152);
      this->tbValorEntradaCC->MaxLength = 12;
      this->tbValorEntradaCC->Name = L"tbValorEntradaCC";
      this->tbValorEntradaCC->Size = System::Drawing::Size(80, 20);
      this->tbValorEntradaCC->TabIndex = 3;
      this->tbValorEntradaCC->Text = L"00000000000";
      // 
      // tbDataParcelaCC
      // 
      this->tbDataParcelaCC->Location = System::Drawing::Point(139, 75);
      this->tbDataParcelaCC->MaxLength = 8;
      this->tbDataParcelaCC->Name = L"tbDataParcelaCC";
      this->tbDataParcelaCC->Size = System::Drawing::Size(80, 20);
      this->tbDataParcelaCC->TabIndex = 1;
      // 
      // tbNumeroParcelasCC
      // 
      this->tbNumeroParcelasCC->Location = System::Drawing::Point(139, 35);
      this->tbNumeroParcelasCC->MaxLength = 2;
      this->tbNumeroParcelasCC->Name = L"tbNumeroParcelasCC";
      this->tbNumeroParcelasCC->Size = System::Drawing::Size(80, 20);
      this->tbNumeroParcelasCC->TabIndex = 0;
      this->tbNumeroParcelasCC->Text = L"00";
      // 
      // btCancelar
      // 
      this->btCancelar->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btCancelar->ForeColor = System::Drawing::SystemColors::InfoText;
      this->btCancelar->Location = System::Drawing::Point(180, 429);
      this->btCancelar->Name = L"btCancelar";
      this->btCancelar->Size = System::Drawing::Size(87, 26);
      this->btCancelar->TabIndex = 10;
      this->btCancelar->Text = L"Cancelar";
      this->btCancelar->UseVisualStyleBackColor = true;
      this->btCancelar->Click += gcnew System::EventHandler(this, &frmTransacoesCompletas::btCancelar_Click);
      // 
      // btOk
      // 
      this->btOk->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btOk->ForeColor = System::Drawing::SystemColors::InfoText;
      this->btOk->Location = System::Drawing::Point(284, 429);
      this->btOk->Name = L"btOk";
      this->btOk->Size = System::Drawing::Size(87, 26);
      this->btOk->TabIndex = 9;
      this->btOk->Text = L"Ok";
      this->btOk->UseVisualStyleBackColor = true;
      this->btOk->Click += gcnew System::EventHandler(this, &frmTransacoesCompletas::btOk_Click);
      // 
      // frmTransacoesCompletas
      // 
      this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
      this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
      this->BackColor = System::Drawing::Color::WhiteSmoke;
      this->ClientSize = System::Drawing::Size(388, 467);
      this->Controls->Add(this->btCancelar);
      this->Controls->Add(this->btOk);
      this->Controls->Add(this->tcPrincipal);
      this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedToolWindow;
      this->Name = L"frmTransacoesCompletas";
      this->StartPosition = System::Windows::Forms::FormStartPosition::CenterParent;
      this->Text = L"frmTransacoesCompletas";
      this->Load += gcnew System::EventHandler(this, &frmTransacoesCompletas::frmTransacoesCompletas_Load);
      this->tcPrincipal->ResumeLayout(false);
      this->tabPage1->ResumeLayout(false);
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox4))->EndInit();
      this->panel1->ResumeLayout(false);
      this->groupBox1->ResumeLayout(false);
      this->groupBox1->PerformLayout();
      this->tabPage2->ResumeLayout(false);
      this->panel2->ResumeLayout(false);
      this->groupBox2->ResumeLayout(false);
      this->groupBox2->PerformLayout();
      this->tabPage3->ResumeLayout(false);
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
      this->panel3->ResumeLayout(false);
      this->groupBox3->ResumeLayout(false);
      this->groupBox3->PerformLayout();
      this->tabPage4->ResumeLayout(false);
      this->panel4->ResumeLayout(false);
      this->groupBox4->ResumeLayout(false);
      this->groupBox4->PerformLayout();
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox2))->EndInit();
      this->tabPage5->ResumeLayout(false);
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox3))->EndInit();
      this->panel5->ResumeLayout(false);
      this->groupBox5->ResumeLayout(false);
      this->groupBox5->PerformLayout();
      this->ResumeLayout(false);

    }
#pragma endregion

  private: System::Void frmTransacoesCompletas_Load(System::Object^  sender, System::EventArgs^  e) {
  }
  private: System::Void btCancelar_Click(System::Object^  sender, System::EventArgs^  e) {
    Close();
  }
  private: System::Void btOk_Click(System::Object^  sender, System::EventArgs^  e) {
    this->DialogResult = Windows::Forms::DialogResult::OK;
    Close();
  }
  private: System::Void tbValorParcelaCR_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
    FuncoesComuns::InputHandlerValor(e, tbValorParcelaCR);
  }
  private: System::Void tbTaxaServicoCR_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
    FuncoesComuns::InputHandlerValor(e, tbTaxaServicoCR);
  }
  private: System::Void tbValorParcelaDB_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
    FuncoesComuns::InputHandlerValor(e, tbValorParcelaDB);
  }
  private: System::Void tbTaxaServicoDB_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
    FuncoesComuns::InputHandlerValor(e, tbTaxaServicoDB);
  }
  private: System::Void tbDataDB_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) {
    FuncoesComuns::InputHandlerData(e, tbDataDB);
  }
};
}
