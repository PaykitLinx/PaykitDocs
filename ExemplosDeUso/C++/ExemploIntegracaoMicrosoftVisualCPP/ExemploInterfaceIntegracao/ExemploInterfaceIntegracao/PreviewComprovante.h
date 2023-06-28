#pragma once

namespace ExemploInterfaceIntegracao {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Summary for PreviewComprovante
	/// </summary>
	public ref class PreviewComprovante : public System::Windows::Forms::Form
	{
	public:
		PreviewComprovante(void)
		{
			InitializeComponent();
			//
			//TODO: Add the constructor code here
			//
		}

	void RealizarDialogo(String^ comprovante);

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~PreviewComprovante()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::GroupBox^  groupBox1;
	private: System::Windows::Forms::RichTextBox^  rtbComprovante;
	private: System::Windows::Forms::Button^  btFechar;
	protected: 




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
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->rtbComprovante = (gcnew System::Windows::Forms::RichTextBox());
			this->btFechar = (gcnew System::Windows::Forms::Button());
			this->groupBox1->SuspendLayout();
			this->SuspendLayout();
			// 
			// groupBox1
			// 
			this->groupBox1->BackColor = System::Drawing::SystemColors::Control;
			this->groupBox1->Controls->Add(this->btFechar);
			this->groupBox1->Controls->Add(this->rtbComprovante);
			this->groupBox1->Location = System::Drawing::Point(1, 2);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(328, 458);
			this->groupBox1->TabIndex = 8;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Comprovante";
			// 
			// rtbComprovante
			// 
			this->rtbComprovante->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->rtbComprovante->Location = System::Drawing::Point(5, 11);
			this->rtbComprovante->Name = L"rtbComprovante";
			this->rtbComprovante->Size = System::Drawing::Size(317, 401);
			this->rtbComprovante->TabIndex = 0;
			this->rtbComprovante->Text = L"";
			// 
			// btFechar
			// 
			this->btFechar->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->btFechar->ForeColor = System::Drawing::SystemColors::InfoText;
			this->btFechar->Location = System::Drawing::Point(124, 425);
			this->btFechar->Name = L"btFechar";
			this->btFechar->Size = System::Drawing::Size(87, 27);
			this->btFechar->TabIndex = 10;
			this->btFechar->Text = L"Fechar";
			this->btFechar->UseVisualStyleBackColor = true;
			this->btFechar->Click += gcnew System::EventHandler(this, &PreviewComprovante::btFechar_Click);
			// 
			// PreviewComprovante
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(331, 472);
			this->Controls->Add(this->groupBox1);
			this->FormBorderStyle = System::Windows::Forms::FormBorderStyle::FixedToolWindow;
			this->Name = L"PreviewComprovante";
			this->Text = L"PreviewComprovante";
			this->Load += gcnew System::EventHandler(this, &PreviewComprovante::PreviewComprovante_Load);
			this->groupBox1->ResumeLayout(false);
			this->ResumeLayout(false);

		}
#pragma endregion
	private: System::Void PreviewComprovante_Load(System::Object^  sender, System::EventArgs^  e) {
			 }
	private: System::Void btFechar_Click(System::Object^  sender, System::EventArgs^  e) {
				 Close();
			 }
	};
}
