#pragma once

namespace ExemploInterfaceIntegracao {

  using namespace System;
  using namespace System::ComponentModel;
  using namespace System::Collections;
  using namespace System::Windows::Forms;
  using namespace System::Data;
  using namespace System::Drawing;

  // estrutura que será utilizada para transferir os ponteiros dos conteúdos dos textboxes
  typedef struct{
    char* endereco;
    char* numero;
    char* apartamento;
    char* bloco;
    char* bairro;
    char* CEP;
    char* CPF;
  }tsConsultaAVS;

  /// <summary>
  /// Form para preenchimento dos dados referentes à consulta AVS
  /// </summary>

  public ref class ConsultaAVS : public System::Windows::Forms::Form
  {
  public:
    bool bOperacaoCancelada;

    ConsultaAVS(void)
    {
      InitializeComponent();
    }

    tsConsultaAVS* getParametros();

  protected:

    ~ConsultaAVS()
    {
      if (components)
      {
        delete components;
      }
    }

#pragma region Windows Forms Generated Componentes

  protected:
  private: System::Windows::Forms::Button^  btOk;
  public:

  private:
  private: System::Windows::Forms::Label^  label1;
  public:

  private: System::Windows::Forms::GroupBox^  groupBox1;
  private: System::Windows::Forms::PictureBox^  imgLogo;

  private: System::Windows::Forms::Button^  btCancelar;

  private:

  public: System::Windows::Forms::TextBox^  boxBloco;
  private:

  public: System::Windows::Forms::TextBox^  boxApartamento;
  private:

  public: System::Windows::Forms::TextBox^  boxEndereco;
  public: System::Windows::Forms::TextBox^  boxNumero;



  private: System::Windows::Forms::Label^  label3;
  public:

  private: System::Windows::Forms::Label^  label8;
  private: System::Windows::Forms::Label^  label7;
  private: System::Windows::Forms::Label^  label6;
  public: System::Windows::Forms::TextBox^  boxCEP;
  public: System::Windows::Forms::TextBox^  boxCPF;
  private:

  private:

  public: System::Windows::Forms::TextBox^  boxBairro;

  private: System::Windows::Forms::Label^  label4;
  public:
  private: System::Windows::Forms::Label^  label5;
  private: System::Windows::Forms::Label^  label9;
  private: System::Windows::Forms::Panel^  panel4;
  private: System::Windows::Forms::Panel^  panel3;
  private: System::Windows::Forms::Panel^  panel2;
  private: System::Windows::Forms::Panel^  panel1;

  public:

  private:



  public:




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
      System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(ConsultaAVS::typeid));
      this->btOk = (gcnew System::Windows::Forms::Button());
      this->label1 = (gcnew System::Windows::Forms::Label());
      this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
      this->panel4 = (gcnew System::Windows::Forms::Panel());
      this->panel3 = (gcnew System::Windows::Forms::Panel());
      this->imgLogo = (gcnew System::Windows::Forms::PictureBox());
      this->panel2 = (gcnew System::Windows::Forms::Panel());
      this->boxCEP = (gcnew System::Windows::Forms::TextBox());
      this->boxCPF = (gcnew System::Windows::Forms::TextBox());
      this->label9 = (gcnew System::Windows::Forms::Label());
      this->boxBairro = (gcnew System::Windows::Forms::TextBox());
      this->label5 = (gcnew System::Windows::Forms::Label());
      this->label4 = (gcnew System::Windows::Forms::Label());
      this->panel1 = (gcnew System::Windows::Forms::Panel());
      this->boxBloco = (gcnew System::Windows::Forms::TextBox());
      this->label8 = (gcnew System::Windows::Forms::Label());
      this->label3 = (gcnew System::Windows::Forms::Label());
      this->label7 = (gcnew System::Windows::Forms::Label());
      this->boxApartamento = (gcnew System::Windows::Forms::TextBox());
      this->boxNumero = (gcnew System::Windows::Forms::TextBox());
      this->label6 = (gcnew System::Windows::Forms::Label());
      this->boxEndereco = (gcnew System::Windows::Forms::TextBox());
      this->btCancelar = (gcnew System::Windows::Forms::Button());
      this->groupBox1->SuspendLayout();
      this->panel4->SuspendLayout();
      this->panel3->SuspendLayout();
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->imgLogo))->BeginInit();
      this->panel2->SuspendLayout();
      this->panel1->SuspendLayout();
      this->SuspendLayout();
      // 
      // btOk
      // 
      this->btOk->BackColor = System::Drawing::SystemColors::Control;
      this->btOk->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btOk->ForeColor = System::Drawing::SystemColors::InfoText;
      this->btOk->Location = System::Drawing::Point(444, 252);
      this->btOk->Name = L"btOk";
      this->btOk->Size = System::Drawing::Size(111, 29);
      this->btOk->TabIndex = 7;
      this->btOk->Text = L"Ok";
      this->btOk->UseVisualStyleBackColor = false;
      this->btOk->Click += gcnew System::EventHandler(this, &ConsultaAVS::btOk_Click);
      // 
      // label1
      // 
      this->label1->AutoSize = true;
      this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label1->Location = System::Drawing::Point(142, 21);
      this->label1->Name = L"label1";
      this->label1->Size = System::Drawing::Size(122, 22);
      this->label1->TabIndex = 2;
      this->label1->Text = L"Consulta AVS";
      // 
      // groupBox1
      // 
      this->groupBox1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->groupBox1->Controls->Add(this->panel4);
      this->groupBox1->Controls->Add(this->panel3);
      this->groupBox1->Controls->Add(this->panel2);
      this->groupBox1->Controls->Add(this->panel1);
      this->groupBox1->Controls->Add(this->btCancelar);
      this->groupBox1->Controls->Add(this->btOk);
      this->groupBox1->Location = System::Drawing::Point(0, -7);
      this->groupBox1->Name = L"groupBox1";
      this->groupBox1->Size = System::Drawing::Size(571, 291);
      this->groupBox1->TabIndex = 5;
      this->groupBox1->TabStop = false;
      // 
      // panel4
      // 
      this->panel4->BackColor = System::Drawing::SystemColors::Control;
      this->panel4->Controls->Add(this->label1);
      this->panel4->Location = System::Drawing::Point(6, 10);
      this->panel4->Name = L"panel4";
      this->panel4->Size = System::Drawing::Size(432, 62);
      this->panel4->TabIndex = 14;
      // 
      // panel3
      // 
      this->panel3->BackColor = System::Drawing::SystemColors::Control;
      this->panel3->Controls->Add(this->imgLogo);
      this->panel3->Location = System::Drawing::Point(441, 10);
      this->panel3->Name = L"panel3";
      this->panel3->Size = System::Drawing::Size(115, 62);
      this->panel3->TabIndex = 13;
      // 
      // imgLogo
      // 
      this->imgLogo->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"imgLogo.Image")));
      this->imgLogo->Location = System::Drawing::Point(8, 1);
      this->imgLogo->Name = L"imgLogo";
      this->imgLogo->Size = System::Drawing::Size(101, 59);
      this->imgLogo->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
      this->imgLogo->TabIndex = 10;
      this->imgLogo->TabStop = false;
      // 
      // panel2
      // 
      this->panel2->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel2->Controls->Add(this->boxCEP);
      this->panel2->Controls->Add(this->boxCPF);
      this->panel2->Controls->Add(this->label9);
      this->panel2->Controls->Add(this->boxBairro);
      this->panel2->Controls->Add(this->label5);
      this->panel2->Controls->Add(this->label4);
      this->panel2->Location = System::Drawing::Point(320, 75);
      this->panel2->Name = L"panel2";
      this->panel2->Size = System::Drawing::Size(235, 173);
      this->panel2->TabIndex = 12;
      // 
      // boxCEP
      // 
      this->boxCEP->Location = System::Drawing::Point(56, 82);
      this->boxCEP->Name = L"boxCEP";
      this->boxCEP->Size = System::Drawing::Size(172, 20);
      this->boxCEP->TabIndex = 5;
      // 
      // boxCPF
      // 
      this->boxCPF->Location = System::Drawing::Point(56, 125);
      this->boxCPF->Name = L"boxCPF";
      this->boxCPF->Size = System::Drawing::Size(172, 20);
      this->boxCPF->TabIndex = 6;
      // 
      // label9
      // 
      this->label9->AutoSize = true;
      this->label9->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label9->Location = System::Drawing::Point(7, 130);
      this->label9->Name = L"label9";
      this->label9->Size = System::Drawing::Size(33, 15);
      this->label9->TabIndex = 17;
      this->label9->Text = L"CPF:";
      // 
      // boxBairro
      // 
      this->boxBairro->Location = System::Drawing::Point(56, 45);
      this->boxBairro->Name = L"boxBairro";
      this->boxBairro->Size = System::Drawing::Size(172, 20);
      this->boxBairro->TabIndex = 4;
      // 
      // label5
      // 
      this->label5->AutoSize = true;
      this->label5->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label5->Location = System::Drawing::Point(7, 46);
      this->label5->Name = L"label5";
      this->label5->Size = System::Drawing::Size(43, 15);
      this->label5->TabIndex = 15;
      this->label5->Text = L"Bairro:";
      // 
      // label4
      // 
      this->label4->AutoSize = true;
      this->label4->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label4->Location = System::Drawing::Point(7, 87);
      this->label4->Name = L"label4";
      this->label4->Size = System::Drawing::Size(34, 15);
      this->label4->TabIndex = 16;
      this->label4->Text = L"CEP:";
      // 
      // panel1
      // 
      this->panel1->BackColor = System::Drawing::SystemColors::Control;
      this->panel1->Controls->Add(this->boxBloco);
      this->panel1->Controls->Add(this->label8);
      this->panel1->Controls->Add(this->label3);
      this->panel1->Controls->Add(this->label7);
      this->panel1->Controls->Add(this->boxApartamento);
      this->panel1->Controls->Add(this->boxNumero);
      this->panel1->Controls->Add(this->label6);
      this->panel1->Controls->Add(this->boxEndereco);
      this->panel1->Location = System::Drawing::Point(8, 75);
      this->panel1->Name = L"panel1";
      this->panel1->Size = System::Drawing::Size(308, 206);
      this->panel1->TabIndex = 11;
      // 
      // boxBloco
      // 
      this->boxBloco->Location = System::Drawing::Point(98, 167);
      this->boxBloco->Name = L"boxBloco";
      this->boxBloco->Size = System::Drawing::Size(191, 20);
      this->boxBloco->TabIndex = 3;
      // 
      // label8
      // 
      this->label8->AutoSize = true;
      this->label8->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label8->Location = System::Drawing::Point(12, 132);
      this->label8->Name = L"label8";
      this->label8->Size = System::Drawing::Size(80, 15);
      this->label8->TabIndex = 9;
      this->label8->Text = L"Apartamento:";
      // 
      // label3
      // 
      this->label3->AutoSize = true;
      this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label3->Location = System::Drawing::Point(12, 48);
      this->label3->Name = L"label3";
      this->label3->Size = System::Drawing::Size(63, 15);
      this->label3->TabIndex = 8;
      this->label3->Text = L"Endereço:";
      // 
      // label7
      // 
      this->label7->AutoSize = true;
      this->label7->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label7->Location = System::Drawing::Point(12, 172);
      this->label7->Name = L"label7";
      this->label7->Size = System::Drawing::Size(41, 15);
      this->label7->TabIndex = 11;
      this->label7->Text = L"Bloco:";
      // 
      // boxApartamento
      // 
      this->boxApartamento->Location = System::Drawing::Point(98, 127);
      this->boxApartamento->Name = L"boxApartamento";
      this->boxApartamento->Size = System::Drawing::Size(191, 20);
      this->boxApartamento->TabIndex = 2;
      // 
      // boxNumero
      // 
      this->boxNumero->Location = System::Drawing::Point(98, 88);
      this->boxNumero->Name = L"boxNumero";
      this->boxNumero->Size = System::Drawing::Size(191, 20);
      this->boxNumero->TabIndex = 1;
      // 
      // label6
      // 
      this->label6->AutoSize = true;
      this->label6->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label6->Location = System::Drawing::Point(12, 89);
      this->label6->Name = L"label6";
      this->label6->Size = System::Drawing::Size(55, 15);
      this->label6->TabIndex = 10;
      this->label6->Text = L"Número:";
      // 
      // boxEndereco
      // 
      this->boxEndereco->Location = System::Drawing::Point(98, 47);
      this->boxEndereco->Name = L"boxEndereco";
      this->boxEndereco->Size = System::Drawing::Size(191, 20);
      this->boxEndereco->TabIndex = 0;
      // 
      // btCancelar
      // 
      this->btCancelar->BackColor = System::Drawing::SystemColors::Control;
      this->btCancelar->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btCancelar->ForeColor = System::Drawing::SystemColors::InfoText;
      this->btCancelar->Location = System::Drawing::Point(320, 252);
      this->btCancelar->Name = L"btCancelar";
      this->btCancelar->Size = System::Drawing::Size(117, 29);
      this->btCancelar->TabIndex = 8;
      this->btCancelar->Text = L"Cancelar";
      this->btCancelar->UseVisualStyleBackColor = false;
      this->btCancelar->Click += gcnew System::EventHandler(this, &ConsultaAVS::btCancelar_Click);
      // 
      // ConsultaAVS
      // 
      this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
      this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
      this->ClientSize = System::Drawing::Size(560, 278);
      this->Controls->Add(this->groupBox1);
      this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedToolWindow;
      this->Name = L"ConsultaAVS";
      this->StartPosition = System::Windows::Forms::FormStartPosition::CenterParent;
      this->Text = L"ConsultaAVS";
      this->groupBox1->ResumeLayout(false);
      this->panel4->ResumeLayout(false);
      this->panel4->PerformLayout();
      this->panel3->ResumeLayout(false);
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->imgLogo))->EndInit();
      this->panel2->ResumeLayout(false);
      this->panel2->PerformLayout();
      this->panel1->ResumeLayout(false);
      this->panel1->PerformLayout();
      this->ResumeLayout(false);

    }
#pragma endregion

#pragma region CLI Form Actions
  private: System::Void btOk_Click(System::Object^  sender, System::EventArgs^  e) {
    this->DialogResult = Windows::Forms::DialogResult::OK;
    Close();
  }
  private: System::Void btCancelar_Click(System::Object^  sender, System::EventArgs^  e) {
    bOperacaoCancelada = true;
    Close();
  }
#pragma endregion

  };
}
