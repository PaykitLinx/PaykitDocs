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
	/// Este form foi criado para efetuar tratamento de planos caso haja, entretanto ainda não há implementação 
  /// deixando assim reservado para uso futuro.
	/// </summary>

typedef struct{
  char * sValorTransacao;
  char * sValorEntrada;
  char * sNumeroParcelas;
  char * sValorParcela;
  char * sData;
}tsSelecionaPlanos;

	public ref class DialogoSelecionaPlanos : public System::Windows::Forms::Form
	{

  private: System::Windows::Forms::Label^  label1;
  private: System::Windows::Forms::Panel^  panel3;
  private: System::Windows::Forms::Panel^  panel2;
  private: System::Windows::Forms::PictureBox^  pictureBox1;

	public:
		
		DialogoSelecionaPlanos(String^ maxDias, String^ NumMaxParcelas, String^ valorMinParcelas)
		{
			InitializeComponent();
      lblMaxDias->Text += maxDias;
      lblMaxParcelas->Text += NumMaxParcelas;
      lblValorMinParcela->Text += valorMinParcelas;
		}

    tsSelecionaPlanos* getParametros();

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~DialogoSelecionaPlanos()
		{
			if (components)
			{
				delete components;
			}
		}

#pragma region windows forms component generated code
	private: System::Windows::Forms::GroupBox^  groupBox1;
	protected: 

	private: System::Windows::Forms::Button^  btCancelar;
	private: System::Windows::Forms::GroupBox^  groupBox2;
	public: System::Windows::Forms::Label^  lblMaxDias;
	private: 
	public: System::Windows::Forms::Label^  lblMaxParcelas;
	public: System::Windows::Forms::Label^  lblValorMinParcela;
	private: System::Windows::Forms::Button^  btOk;
	public: 

	private: System::Windows::Forms::Panel^  panel1;
	public: System::Windows::Forms::TextBox^  boxData;
	private: 
	public: System::Windows::Forms::TextBox^  boxValorParcela;
	public: System::Windows::Forms::TextBox^  boxValorEntrada;
	public: System::Windows::Forms::TextBox^  boxNumeroParcelas;
	public: System::Windows::Forms::TextBox^  boxValorTransacao;

	private: System::Windows::Forms::Label^  label3;
	public: 
	private: System::Windows::Forms::Label^  label2;
	private: System::Windows::Forms::Label^  label8;
	private: System::Windows::Forms::Label^  label7;
	private: System::Windows::Forms::Label^  label6;

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
      System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(DialogoSelecionaPlanos::typeid));
      this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
      this->panel3 = (gcnew System::Windows::Forms::Panel());
      this->label1 = (gcnew System::Windows::Forms::Label());
      this->panel2 = (gcnew System::Windows::Forms::Panel());
      this->pictureBox1 = (gcnew System::Windows::Forms::PictureBox());
      this->btCancelar = (gcnew System::Windows::Forms::Button());
      this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
      this->lblMaxDias = (gcnew System::Windows::Forms::Label());
      this->lblMaxParcelas = (gcnew System::Windows::Forms::Label());
      this->lblValorMinParcela = (gcnew System::Windows::Forms::Label());
      this->btOk = (gcnew System::Windows::Forms::Button());
      this->panel1 = (gcnew System::Windows::Forms::Panel());
      this->boxData = (gcnew System::Windows::Forms::TextBox());
      this->boxValorParcela = (gcnew System::Windows::Forms::TextBox());
      this->boxValorEntrada = (gcnew System::Windows::Forms::TextBox());
      this->boxNumeroParcelas = (gcnew System::Windows::Forms::TextBox());
      this->boxValorTransacao = (gcnew System::Windows::Forms::TextBox());
      this->label3 = (gcnew System::Windows::Forms::Label());
      this->label2 = (gcnew System::Windows::Forms::Label());
      this->label8 = (gcnew System::Windows::Forms::Label());
      this->label7 = (gcnew System::Windows::Forms::Label());
      this->label6 = (gcnew System::Windows::Forms::Label());
      this->groupBox1->SuspendLayout();
      this->panel3->SuspendLayout();
      this->panel2->SuspendLayout();
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->BeginInit();
      this->groupBox2->SuspendLayout();
      this->panel1->SuspendLayout();
      this->SuspendLayout();
      // 
      // groupBox1
      // 
      this->groupBox1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->groupBox1->Controls->Add(this->panel3);
      this->groupBox1->Controls->Add(this->panel2);
      this->groupBox1->Controls->Add(this->btCancelar);
      this->groupBox1->Controls->Add(this->groupBox2);
      this->groupBox1->Controls->Add(this->btOk);
      this->groupBox1->Controls->Add(this->panel1);
      this->groupBox1->Location = System::Drawing::Point(1, -5);
      this->groupBox1->Name = L"groupBox1";
      this->groupBox1->Size = System::Drawing::Size(535, 320);
      this->groupBox1->TabIndex = 4;
      this->groupBox1->TabStop = false;
      // 
      // panel3
      // 
      this->panel3->BackColor = System::Drawing::SystemColors::Control;
      this->panel3->Controls->Add(this->label1);
      this->panel3->Location = System::Drawing::Point(6, 11);
      this->panel3->Name = L"panel3";
      this->panel3->Size = System::Drawing::Size(310, 67);
      this->panel3->TabIndex = 12;
      // 
      // label1
      // 
      this->label1->AutoSize = true;
      this->label1->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 13, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label1->Location = System::Drawing::Point(67, 22);
      this->label1->Name = L"label1";
      this->label1->Size = System::Drawing::Size(149, 22);
      this->label1->TabIndex = 6;
      this->label1->Text = L"Seleciona Planos";
      // 
      // panel2
      // 
      this->panel2->BackColor = System::Drawing::SystemColors::Control;
      this->panel2->Controls->Add(this->pictureBox1);
      this->panel2->Location = System::Drawing::Point(322, 11);
      this->panel2->Name = L"panel2";
      this->panel2->Size = System::Drawing::Size(204, 112);
      this->panel2->TabIndex = 11;
      // 
      // pictureBox1
      // 
      this->pictureBox1->BackColor = System::Drawing::SystemColors::Control;
      this->pictureBox1->Image = (cli::safe_cast<System::Drawing::Image^>(resources->GetObject(L"pictureBox1.Image")));
      this->pictureBox1->Location = System::Drawing::Point(3, -3);
      this->pictureBox1->Name = L"pictureBox1";
      this->pictureBox1->Size = System::Drawing::Size(201, 112);
      this->pictureBox1->SizeMode = System::Windows::Forms::PictureBoxSizeMode::StretchImage;
      this->pictureBox1->TabIndex = 10;
      this->pictureBox1->TabStop = false;
      // 
      // btCancelar
      // 
      this->btCancelar->BackColor = System::Drawing::SystemColors::Control;
      this->btCancelar->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btCancelar->ForeColor = System::Drawing::SystemColors::InfoText;
      this->btCancelar->Location = System::Drawing::Point(428, 278);
      this->btCancelar->Name = L"btCancelar";
      this->btCancelar->Size = System::Drawing::Size(98, 24);
      this->btCancelar->TabIndex = 7;
      this->btCancelar->Text = L"Cancelar";
      this->btCancelar->UseVisualStyleBackColor = false;
      this->btCancelar->Click += gcnew System::EventHandler(this, &DialogoSelecionaPlanos::btCancelar_Click);
      // 
      // groupBox2
      // 
      this->groupBox2->BackColor = System::Drawing::SystemColors::Control;
      this->groupBox2->Controls->Add(this->lblMaxDias);
      this->groupBox2->Controls->Add(this->lblMaxParcelas);
      this->groupBox2->Controls->Add(this->lblValorMinParcela);
      this->groupBox2->Location = System::Drawing::Point(322, 129);
      this->groupBox2->Name = L"groupBox2";
      this->groupBox2->Size = System::Drawing::Size(204, 143);
      this->groupBox2->TabIndex = 0;
      this->groupBox2->TabStop = false;
      this->groupBox2->Text = L"Informações";
      // 
      // lblMaxDias
      // 
      this->lblMaxDias->AutoSize = true;
      this->lblMaxDias->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->lblMaxDias->Location = System::Drawing::Point(5, 119);
      this->lblMaxDias->Name = L"lblMaxDias";
      this->lblMaxDias->Size = System::Drawing::Size(131, 15);
      this->lblMaxDias->TabIndex = 3;
      this->lblMaxDias->Text = L"Máx. Dias Pré-Datado:";
      // 
      // lblMaxParcelas
      // 
      this->lblMaxParcelas->AutoSize = true;
      this->lblMaxParcelas->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->lblMaxParcelas->Location = System::Drawing::Point(5, 81);
      this->lblMaxParcelas->Name = L"lblMaxParcelas";
      this->lblMaxParcelas->Size = System::Drawing::Size(159, 15);
      this->lblMaxParcelas->TabIndex = 2;
      this->lblMaxParcelas->Text = L"Num. Máximo de Parcelas :";
      // 
      // lblValorMinParcela
      // 
      this->lblValorMinParcela->AutoSize = true;
      this->lblValorMinParcela->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->lblValorMinParcela->Location = System::Drawing::Point(5, 44);
      this->lblValorMinParcela->Name = L"lblValorMinParcela";
      this->lblValorMinParcela->Size = System::Drawing::Size(110, 15);
      this->lblValorMinParcela->TabIndex = 1;
      this->lblValorMinParcela->Text = L"Valor Mín. Parcela:";
      // 
      // btOk
      // 
      this->btOk->BackColor = System::Drawing::SystemColors::Control;
      this->btOk->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btOk->ForeColor = System::Drawing::SystemColors::InfoText;
      this->btOk->Location = System::Drawing::Point(322, 278);
      this->btOk->Name = L"btOk";
      this->btOk->Size = System::Drawing::Size(100, 24);
      this->btOk->TabIndex = 6;
      this->btOk->Text = L"Ok";
      this->btOk->UseVisualStyleBackColor = false;
      this->btOk->Click += gcnew System::EventHandler(this, &DialogoSelecionaPlanos::btOk_Click);
      // 
      // panel1
      // 
      this->panel1->BackColor = System::Drawing::SystemColors::Control;
      this->panel1->Controls->Add(this->boxData);
      this->panel1->Controls->Add(this->boxValorParcela);
      this->panel1->Controls->Add(this->boxValorEntrada);
      this->panel1->Controls->Add(this->boxNumeroParcelas);
      this->panel1->Controls->Add(this->boxValorTransacao);
      this->panel1->Controls->Add(this->label3);
      this->panel1->Controls->Add(this->label2);
      this->panel1->Controls->Add(this->label8);
      this->panel1->Controls->Add(this->label7);
      this->panel1->Controls->Add(this->label6);
      this->panel1->Location = System::Drawing::Point(6, 84);
      this->panel1->Name = L"panel1";
      this->panel1->Size = System::Drawing::Size(310, 225);
      this->panel1->TabIndex = 0;
      // 
      // boxData
      // 
      this->boxData->Location = System::Drawing::Point(135, 192);
      this->boxData->Name = L"boxData";
      this->boxData->Size = System::Drawing::Size(152, 20);
      this->boxData->TabIndex = 5;
      this->boxData->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
      this->boxData->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &DialogoSelecionaPlanos::boxData_KeyPress);
      // 
      // boxValorParcela
      // 
      this->boxValorParcela->Location = System::Drawing::Point(135, 152);
      this->boxValorParcela->Name = L"boxValorParcela";
      this->boxValorParcela->Size = System::Drawing::Size(152, 20);
      this->boxValorParcela->TabIndex = 4;
      this->boxValorParcela->Text = L"0,00";
      this->boxValorParcela->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
      this->boxValorParcela->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &DialogoSelecionaPlanos::boxValorParcela_KeyPress);
      // 
      // boxValorEntrada
      // 
      this->boxValorEntrada->Location = System::Drawing::Point(135, 68);
      this->boxValorEntrada->Name = L"boxValorEntrada";
      this->boxValorEntrada->Size = System::Drawing::Size(152, 20);
      this->boxValorEntrada->TabIndex = 2;
      this->boxValorEntrada->Text = L"0,00";
      this->boxValorEntrada->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
      this->boxValorEntrada->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &DialogoSelecionaPlanos::boxValorEntrada_KeyPress);
      // 
      // boxNumeroParcelas
      // 
      this->boxNumeroParcelas->Location = System::Drawing::Point(135, 109);
      this->boxNumeroParcelas->Name = L"boxNumeroParcelas";
      this->boxNumeroParcelas->Size = System::Drawing::Size(152, 20);
      this->boxNumeroParcelas->TabIndex = 3;
      this->boxNumeroParcelas->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
      // 
      // boxValorTransacao
      // 
      this->boxValorTransacao->Location = System::Drawing::Point(135, 27);
      this->boxValorTransacao->Name = L"boxValorTransacao";
      this->boxValorTransacao->Size = System::Drawing::Size(152, 20);
      this->boxValorTransacao->TabIndex = 1;
      this->boxValorTransacao->Text = L"0,00";
      this->boxValorTransacao->TextAlign = System::Windows::Forms::HorizontalAlignment::Right;
      this->boxValorTransacao->KeyPress += gcnew System::Windows::Forms::KeyPressEventHandler(this, &DialogoSelecionaPlanos::boxValorTransacao_KeyPress);
      // 
      // label3
      // 
      this->label3->AutoSize = true;
      this->label3->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label3->Location = System::Drawing::Point(25, 73);
      this->label3->Name = L"label3";
      this->label3->Size = System::Drawing::Size(101, 15);
      this->label3->TabIndex = 1;
      this->label3->Text = L"Valor de Entrada:";
      // 
      // label2
      // 
      this->label2->AutoSize = true;
      this->label2->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label2->Location = System::Drawing::Point(13, 32);
      this->label2->Name = L"label2";
      this->label2->Size = System::Drawing::Size(116, 15);
      this->label2->TabIndex = 1;
      this->label2->Text = L"Valor da Transação:";
      // 
      // label8
      // 
      this->label8->AutoSize = true;
      this->label8->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label8->Location = System::Drawing::Point(29, 157);
      this->label8->Name = L"label8";
      this->label8->Size = System::Drawing::Size(100, 15);
      this->label8->TabIndex = 1;
      this->label8->Text = L"Valor da Parcela:";
      // 
      // label7
      // 
      this->label7->AutoSize = true;
      this->label7->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label7->Location = System::Drawing::Point(90, 197);
      this->label7->Name = L"label7";
      this->label7->Size = System::Drawing::Size(36, 15);
      this->label7->TabIndex = 1;
      this->label7->Text = L"Data:";
      // 
      // label6
      // 
      this->label6->AutoSize = true;
      this->label6->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Regular, System::Drawing::GraphicsUnit::Point,
        static_cast<System::Byte>(0)));
      this->label6->Location = System::Drawing::Point(8, 116);
      this->label6->Name = L"label6";
      this->label6->Size = System::Drawing::Size(123, 15);
      this->label6->TabIndex = 1;
      this->label6->Text = L"Número de Parcelas:";
      // 
      // DialogoSelecionaPlanos
      // 
      this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
      this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
      this->ClientSize = System::Drawing::Size(536, 307);
      this->Controls->Add(this->groupBox1);
      this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedToolWindow;
      this->Name = L"DialogoSelecionaPlanos";
      this->Text = L"DialogoSelecionaPlanos";
      this->Load += gcnew System::EventHandler(this, &DialogoSelecionaPlanos::DialogoSelecionaPlanos_Load);
      this->groupBox1->ResumeLayout(false);
      this->panel3->ResumeLayout(false);
      this->panel3->PerformLayout();
      this->panel2->ResumeLayout(false);
      (cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->pictureBox1))->EndInit();
      this->groupBox2->ResumeLayout(false);
      this->groupBox2->PerformLayout();
      this->panel1->ResumeLayout(false);
      this->panel1->PerformLayout();
      this->ResumeLayout(false);

    }
#pragma endregion

#pragma region CLI Form Actions

private: System::Void btCancelar_Click(System::Object^  sender, System::EventArgs^  e) {
				Close();
			}
private: System::Void btOk_Click(System::Object^  sender, System::EventArgs^  e) {
        this->DialogResult = Windows::Forms::DialogResult::OK;
			  Close();
		  }
private: System::Void boxValorTransacao_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) 
		 {
       FuncoesComuns::InputHandlerValor(e, boxValorTransacao);
		 }
private: System::Void boxValorEntrada_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) 
		 {
       FuncoesComuns::InputHandlerValor(e, boxValorEntrada);
		 }
private: System::Void boxValorParcela_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) 
		 {
       FuncoesComuns::InputHandlerValor(e, boxValorParcela);
		 }
private: System::Void boxData_KeyPress(System::Object^  sender, System::Windows::Forms::KeyPressEventArgs^  e) 
		 {
       FuncoesComuns::InputHandlerData(e, boxData);
		 }
private: System::Void DialogoSelecionaPlanos_Load(System::Object^  sender, System::EventArgs^  e) {
			  this->ControlBox = false;
			  boxValorTransacao->Focus();
		 }

#pragma endregion

};
}
