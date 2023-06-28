#pragma once

namespace ExemploInterfaceIntegracao {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for frmComprovante
	/// </summary>
	public ref class frmComprovante : public System::Windows::Forms::Form
	{
	public:
		frmComprovante(String^ sTexto)
		{
			InitializeComponent();
      rtbComprovante->Text = sTexto;
			//
			//TODO: Add the constructor code here
			//
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~frmComprovante()
		{
			if (components)
			{
				delete components;
			}
		}
  private: System::Windows::Forms::RichTextBox^  rtbComprovante;
  protected:

  protected:
  private: System::Windows::Forms::Button^  btOk;
  private: System::Windows::Forms::Panel^  panel1;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
      System::ComponentModel::ComponentResourceManager^  resources = (gcnew System::ComponentModel::ComponentResourceManager(frmComprovante::typeid));
      this->rtbComprovante = (gcnew System::Windows::Forms::RichTextBox());
      this->btOk = (gcnew System::Windows::Forms::Button());
      this->panel1 = (gcnew System::Windows::Forms::Panel());
      this->panel1->SuspendLayout();
      this->SuspendLayout();
      // 
      // rtbComprovante
      // 
      this->rtbComprovante->Location = System::Drawing::Point(5, 3);
      this->rtbComprovante->Name = L"rtbComprovante";
      this->rtbComprovante->Size = System::Drawing::Size(322, 355);
      this->rtbComprovante->TabIndex = 0;
      this->rtbComprovante->Text = L"";
      // 
      // btOk
      // 
      this->btOk->BackColor = System::Drawing::SystemColors::Control;
      this->btOk->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
      this->btOk->ForeColor = System::Drawing::Color::Black;
      this->btOk->Location = System::Drawing::Point(107, 3);
      this->btOk->Name = L"btOk";
      this->btOk->Size = System::Drawing::Size(109, 31);
      this->btOk->TabIndex = 1;
      this->btOk->Text = L"Ok";
      this->btOk->UseVisualStyleBackColor = false;
      this->btOk->Click += gcnew System::EventHandler(this, &frmComprovante::btOk_Click);
      // 
      // panel1
      // 
      this->panel1->BackColor = System::Drawing::Color::WhiteSmoke;
      this->panel1->BorderStyle = System::Windows::Forms::BorderStyle::FixedSingle;
      this->panel1->Controls->Add(this->btOk);
      this->panel1->Location = System::Drawing::Point(5, 363);
      this->panel1->Name = L"panel1";
      this->panel1->Size = System::Drawing::Size(324, 39);
      this->panel1->TabIndex = 2;
      // 
      // frmComprovante
      // 
      this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
      this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
      this->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
        static_cast<System::Int32>(static_cast<System::Byte>(255)));
      this->ClientSize = System::Drawing::Size(331, 403);
      this->Controls->Add(this->panel1);
      this->Controls->Add(this->rtbComprovante);
      this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedDialog;
      this->Icon = (cli::safe_cast<System::Drawing::Icon^>(resources->GetObject(L"$this.Icon")));
      this->Name = L"frmComprovante";
      this->Text = L"frmComprovante";
      this->panel1->ResumeLayout(false);
      this->ResumeLayout(false);

    }
#pragma endregion
  private: System::Void btOk_Click(System::Object^  sender, System::EventArgs^  e) {
    Close();
  }
  };
}
