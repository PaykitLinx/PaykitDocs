namespace LinxDTEF
{
  partial class ConsultaAVS
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
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.label1 = new System.Windows.Forms.Label();
      this.panel2 = new System.Windows.Forms.Panel();
      this.btOk = new System.Windows.Forms.Button();
      this.btCancelar = new System.Windows.Forms.Button();
      this.boxCPF = new System.Windows.Forms.TextBox();
      this.boxCEP = new System.Windows.Forms.TextBox();
      this.boxBairro = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label5 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.boxBloco = new System.Windows.Forms.TextBox();
      this.boxApartamento = new System.Windows.Forms.TextBox();
      this.boxNumero = new System.Windows.Forms.TextBox();
      this.boxEndereco = new System.Windows.Forms.TextBox();
      this.groupBox1.SuspendLayout();
      this.panel2.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.Color.Silver;
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.panel2);
      this.groupBox1.Controls.Add(this.panel1);
      this.groupBox1.Location = new System.Drawing.Point(1, 2);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(666, 320);
      this.groupBox1.TabIndex = 0;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Informações ";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(272, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(122, 22);
      this.label1.TabIndex = 2;
      this.label1.Text = "Consulta AVS";
      // 
      // panel2
      // 
      this.panel2.BackColor = System.Drawing.Color.LightGray;
      this.panel2.Controls.Add(this.btOk);
      this.panel2.Controls.Add(this.btCancelar);
      this.panel2.Controls.Add(this.boxCPF);
      this.panel2.Controls.Add(this.boxCEP);
      this.panel2.Controls.Add(this.boxBairro);
      this.panel2.Controls.Add(this.label8);
      this.panel2.Controls.Add(this.label7);
      this.panel2.Controls.Add(this.label6);
      this.panel2.Location = new System.Drawing.Point(353, 60);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(307, 243);
      this.panel2.TabIndex = 1;
      // 
      // btOk
      // 
      this.btOk.Location = new System.Drawing.Point(180, 201);
      this.btOk.Name = "btOk";
      this.btOk.Size = new System.Drawing.Size(95, 27);
      this.btOk.TabIndex = 2;
      this.btOk.Text = "Ok";
      this.btOk.UseVisualStyleBackColor = true;
      this.btOk.Click += new System.EventHandler(this.btOk_Click);
      // 
      // btCancelar
      // 
      this.btCancelar.Location = new System.Drawing.Point(46, 201);
      this.btCancelar.Name = "btCancelar";
      this.btCancelar.Size = new System.Drawing.Size(95, 27);
      this.btCancelar.TabIndex = 2;
      this.btCancelar.Text = "Cancelar";
      this.btCancelar.UseVisualStyleBackColor = true;
      // 
      // boxCPF
      // 
      this.boxCPF.Location = new System.Drawing.Point(71, 134);
      this.boxCPF.Name = "boxCPF";
      this.boxCPF.Size = new System.Drawing.Size(229, 20);
      this.boxCPF.TabIndex = 0;
      // 
      // boxCEP
      // 
      this.boxCEP.Location = new System.Drawing.Point(71, 36);
      this.boxCEP.Name = "boxCEP";
      this.boxCEP.Size = new System.Drawing.Size(229, 20);
      this.boxCEP.TabIndex = 0;
      // 
      // boxBairro
      // 
      this.boxBairro.Location = new System.Drawing.Point(71, 88);
      this.boxBairro.Name = "boxBairro";
      this.boxBairro.Size = new System.Drawing.Size(229, 20);
      this.boxBairro.TabIndex = 0;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(24, 91);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(37, 13);
      this.label8.TabIndex = 1;
      this.label8.Text = "Bairro:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(24, 137);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(30, 13);
      this.label7.TabIndex = 1;
      this.label7.Text = "CPF:";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(24, 39);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(31, 13);
      this.label6.TabIndex = 1;
      this.label6.Text = "CEP:";
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.LightGray;
      this.panel1.Controls.Add(this.label5);
      this.panel1.Controls.Add(this.label4);
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.boxBloco);
      this.panel1.Controls.Add(this.boxApartamento);
      this.panel1.Controls.Add(this.boxNumero);
      this.panel1.Controls.Add(this.boxEndereco);
      this.panel1.Location = new System.Drawing.Point(6, 60);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(341, 243);
      this.panel1.TabIndex = 0;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(18, 185);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(34, 13);
      this.label5.TabIndex = 1;
      this.label5.Text = "Bloco";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(18, 137);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(70, 13);
      this.label4.TabIndex = 1;
      this.label4.Text = "Apartamento:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(18, 91);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(47, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Número:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(18, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(56, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Endereço:";
      // 
      // boxBloco
      // 
      this.boxBloco.Location = new System.Drawing.Point(91, 182);
      this.boxBloco.Name = "boxBloco";
      this.boxBloco.Size = new System.Drawing.Size(229, 20);
      this.boxBloco.TabIndex = 0;
      // 
      // boxApartamento
      // 
      this.boxApartamento.Location = new System.Drawing.Point(91, 134);
      this.boxApartamento.Name = "boxApartamento";
      this.boxApartamento.Size = new System.Drawing.Size(229, 20);
      this.boxApartamento.TabIndex = 0;
      // 
      // boxNumero
      // 
      this.boxNumero.Location = new System.Drawing.Point(91, 88);
      this.boxNumero.Name = "boxNumero";
      this.boxNumero.Size = new System.Drawing.Size(229, 20);
      this.boxNumero.TabIndex = 0;
      // 
      // boxEndereco
      // 
      this.boxEndereco.Location = new System.Drawing.Point(91, 36);
      this.boxEndereco.Name = "boxEndereco";
      this.boxEndereco.Size = new System.Drawing.Size(229, 20);
      this.boxEndereco.TabIndex = 0;
      // 
      // ConsultaAVS
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.SeaShell;
      this.ClientSize = new System.Drawing.Size(665, 324);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "ConsultaAVS";
      this.Text = "ConsultaAVScs";
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.panel2.ResumeLayout(false);
      this.panel2.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Panel panel2;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button btOk;
    private System.Windows.Forms.Button btCancelar;
    public System.Windows.Forms.TextBox boxBloco;
    public System.Windows.Forms.TextBox boxApartamento;
    public System.Windows.Forms.TextBox boxNumero;
    public System.Windows.Forms.TextBox boxEndereco;
    public System.Windows.Forms.TextBox boxCPF;
    public System.Windows.Forms.TextBox boxCEP;
    public System.Windows.Forms.TextBox boxBairro;
  }
}