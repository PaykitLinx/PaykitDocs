namespace LinxDTEF
{
  partial class FormTransacao
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTransacao));
      this.btnCancelar = new System.Windows.Forms.Button();
      this.btnOK = new System.Windows.Forms.Button();
      this.lblMensagemDpos = new System.Windows.Forms.Label();
      this.lblMensagem = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.pctLogoLinx = new System.Windows.Forms.PictureBox();
      this.lbxOpcoes = new System.Windows.Forms.ListBox();
      this.lblDisplay = new System.Windows.Forms.Label();
      this.lblDisplayErro = new System.Windows.Forms.Label();
      this.edtValor = new System.Windows.Forms.TextBox();
      ((System.ComponentModel.ISupportInitialize)(this.pctLogoLinx)).BeginInit();
      this.SuspendLayout();
      // 
      // btnCancelar
      // 
      this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnCancelar.Location = new System.Drawing.Point(324, 135);
      this.btnCancelar.Name = "btnCancelar";
      this.btnCancelar.Size = new System.Drawing.Size(87, 26);
      this.btnCancelar.TabIndex = 5;
      this.btnCancelar.Text = "Cancelar";
      this.btnCancelar.UseVisualStyleBackColor = true;
      this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
      // 
      // btnOK
      // 
      this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btnOK.Location = new System.Drawing.Point(324, 102);
      this.btnOK.Name = "btnOK";
      this.btnOK.Size = new System.Drawing.Size(87, 26);
      this.btnOK.TabIndex = 4;
      this.btnOK.Text = "Ok";
      this.btnOK.UseVisualStyleBackColor = true;
      this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
      // 
      // lblMensagemDpos
      // 
      this.lblMensagemDpos.AutoSize = true;
      this.lblMensagemDpos.Location = new System.Drawing.Point(13, 9);
      this.lblMensagemDpos.Name = "lblMensagemDpos";
      this.lblMensagemDpos.Size = new System.Drawing.Size(27, 13);
      this.lblMensagemDpos.TabIndex = 8;
      this.lblMensagemDpos.Text = "men";
      // 
      // lblMensagem
      // 
      this.lblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblMensagem.Location = new System.Drawing.Point(13, 27);
      this.lblMensagem.Name = "lblMensagem";
      this.lblMensagem.Size = new System.Drawing.Size(271, 17);
      this.lblMensagem.TabIndex = 3;
      this.lblMensagem.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.Silver;
      this.panel2.Location = new System.Drawing.Point(294, 1);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(10, 159);
      this.panel2.TabIndex = 2;
      // 
      // pctLogoLinx
      // 
      this.pctLogoLinx.Image = ((System.Drawing.Image)(resources.GetObject("pctLogoLinx.Image")));
      this.pctLogoLinx.Location = new System.Drawing.Point(322, 9);
      this.pctLogoLinx.Name = "pctLogoLinx";
      this.pctLogoLinx.Size = new System.Drawing.Size(98, 84);
      this.pctLogoLinx.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pctLogoLinx.TabIndex = 1;
      this.pctLogoLinx.TabStop = false;
      // 
      // lbxOpcoes
      // 
      this.lbxOpcoes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lbxOpcoes.FormattingEnabled = true;
      this.lbxOpcoes.ItemHeight = 25;
      this.lbxOpcoes.Location = new System.Drawing.Point(12, 57);
      this.lbxOpcoes.Name = "lbxOpcoes";
      this.lbxOpcoes.Size = new System.Drawing.Size(272, 104);
      this.lbxOpcoes.TabIndex = 9;
      this.lbxOpcoes.Visible = false;
      this.lbxOpcoes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lbxOpcoes_KeyDown);
      // 
      // lblDisplay
      // 
      this.lblDisplay.BackColor = System.Drawing.Color.CornflowerBlue;
      this.lblDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDisplay.ForeColor = System.Drawing.Color.White;
      this.lblDisplay.Location = new System.Drawing.Point(12, 172);
      this.lblDisplay.Name = "lblDisplay";
      this.lblDisplay.Size = new System.Drawing.Size(408, 31);
      this.lblDisplay.TabIndex = 10;
      this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblDisplay.Visible = false;
      // 
      // lblDisplayErro
      // 
      this.lblDisplayErro.BackColor = System.Drawing.Color.Red;
      this.lblDisplayErro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblDisplayErro.ForeColor = System.Drawing.Color.White;
      this.lblDisplayErro.Location = new System.Drawing.Point(12, 172);
      this.lblDisplayErro.Name = "lblDisplayErro";
      this.lblDisplayErro.Size = new System.Drawing.Size(408, 31);
      this.lblDisplayErro.TabIndex = 11;
      this.lblDisplayErro.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.lblDisplayErro.Visible = false;
      // 
      // edtValor
      // 
      this.edtValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.edtValor.Location = new System.Drawing.Point(12, 97);
      this.edtValor.Name = "edtValor";
      this.edtValor.Size = new System.Drawing.Size(272, 30);
      this.edtValor.TabIndex = 13;
      this.edtValor.TextChanged += new System.EventHandler(this.edtValor_TextChanged);
      this.edtValor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.edtValor_KeyDown);
      this.edtValor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.edtValor_KeyPress);
      // 
      // FormTransacao
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.SeaShell;
      this.ClientSize = new System.Drawing.Size(430, 212);
      this.Controls.Add(this.edtValor);
      this.Controls.Add(this.lblDisplayErro);
      this.Controls.Add(this.lblDisplay);
      this.Controls.Add(this.lbxOpcoes);
      this.Controls.Add(this.pctLogoLinx);
      this.Controls.Add(this.btnCancelar);
      this.Controls.Add(this.btnOK);
      this.Controls.Add(this.lblMensagemDpos);
      this.Controls.Add(this.panel2);
      this.Controls.Add(this.lblMensagem);
      this.Cursor = System.Windows.Forms.Cursors.Default;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.KeyPreview = true;
      this.MaximizeBox = false;
      this.Name = "FormTransacao";
      this.Text = "DialogoTransacao";
      this.Load += new System.EventHandler(this.dlgTransacao_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dlgTransacao_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.pctLogoLinx)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnOK;
    private System.Windows.Forms.Label lblMensagemDpos;
    public System.Windows.Forms.Label lblMensagem;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.PictureBox pctLogoLinx;
    public System.Windows.Forms.ListBox lbxOpcoes;
    public System.Windows.Forms.Label lblDisplay;
    public System.Windows.Forms.Label lblDisplayErro;
    public System.Windows.Forms.TextBox edtValor;


  }
}