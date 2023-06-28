namespace LinxDTEF
{
  partial class SelecionaPlanos
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
      this.boxValorTrans = new System.Windows.Forms.TextBox();
      this.btOk = new System.Windows.Forms.Button();
      this.btCancelar = new System.Windows.Forms.Button();
      this.boxData = new System.Windows.Forms.TextBox();
      this.boxNumeroParcelas = new System.Windows.Forms.TextBox();
      this.boxValorParcela = new System.Windows.Forms.TextBox();
      this.label8 = new System.Windows.Forms.Label();
      this.lblValorMinParcela = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.label7 = new System.Windows.Forms.Label();
      this.panel1 = new System.Windows.Forms.Panel();
      this.boxValorEntrada = new System.Windows.Forms.TextBox();
      this.label6 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.lblMaxDias = new System.Windows.Forms.Label();
      this.lblMaxParcelas = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // boxValorTrans
      // 
      this.boxValorTrans.Location = new System.Drawing.Point(138, 40);
      this.boxValorTrans.Name = "boxValorTrans";
      this.boxValorTrans.Size = new System.Drawing.Size(152, 20);
      this.boxValorTrans.TabIndex = 0;
      // 
      // btOk
      // 
      this.btOk.Location = new System.Drawing.Point(308, 387);
      this.btOk.Name = "btOk";
      this.btOk.Size = new System.Drawing.Size(95, 27);
      this.btOk.TabIndex = 2;
      this.btOk.Text = "Ok";
      this.btOk.UseVisualStyleBackColor = true;
      this.btOk.Click += new System.EventHandler(this.btOk_Click);
      // 
      // btCancelar
      // 
      this.btCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.btCancelar.Location = new System.Drawing.Point(150, 387);
      this.btCancelar.Name = "btCancelar";
      this.btCancelar.Size = new System.Drawing.Size(95, 27);
      this.btCancelar.TabIndex = 2;
      this.btCancelar.Text = "Cancelar";
      this.btCancelar.UseVisualStyleBackColor = true;
      this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
      // 
      // boxData
      // 
      this.boxData.Location = new System.Drawing.Point(138, 226);
      this.boxData.Name = "boxData";
      this.boxData.Size = new System.Drawing.Size(152, 20);
      this.boxData.TabIndex = 0;
      // 
      // boxNumeroParcelas
      // 
      this.boxNumeroParcelas.Location = new System.Drawing.Point(138, 130);
      this.boxNumeroParcelas.Name = "boxNumeroParcelas";
      this.boxNumeroParcelas.Size = new System.Drawing.Size(152, 20);
      this.boxNumeroParcelas.TabIndex = 0;
      // 
      // boxValorParcela
      // 
      this.boxValorParcela.Location = new System.Drawing.Point(138, 180);
      this.boxValorParcela.Name = "boxValorParcela";
      this.boxValorParcela.Size = new System.Drawing.Size(152, 20);
      this.boxValorParcela.TabIndex = 0;
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(31, 183);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(88, 13);
      this.label8.TabIndex = 1;
      this.label8.Text = "Valor da Parcela:";
      // 
      // lblValorMinParcela
      // 
      this.lblValorMinParcela.AutoSize = true;
      this.lblValorMinParcela.Location = new System.Drawing.Point(16, 43);
      this.lblValorMinParcela.Name = "lblValorMinParcela";
      this.lblValorMinParcela.Size = new System.Drawing.Size(98, 13);
      this.lblValorMinParcela.TabIndex = 1;
      this.lblValorMinParcela.Text = "Valor Mín. Parcela:";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(30, 91);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(89, 13);
      this.label3.TabIndex = 1;
      this.label3.Text = "Valor de Entrada:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(18, 43);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(103, 13);
      this.label2.TabIndex = 1;
      this.label2.Text = "Valor da Transação:";
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(86, 229);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(33, 13);
      this.label7.TabIndex = 1;
      this.label7.Text = "Data:";
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.LightGray;
      this.panel1.Controls.Add(this.label3);
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.boxData);
      this.panel1.Controls.Add(this.boxValorParcela);
      this.panel1.Controls.Add(this.boxValorEntrada);
      this.panel1.Controls.Add(this.label8);
      this.panel1.Controls.Add(this.boxNumeroParcelas);
      this.panel1.Controls.Add(this.label7);
      this.panel1.Controls.Add(this.boxValorTrans);
      this.panel1.Controls.Add(this.label6);
      this.panel1.Location = new System.Drawing.Point(7, 68);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(306, 284);
      this.panel1.TabIndex = 0;
      // 
      // boxValorEntrada
      // 
      this.boxValorEntrada.Location = new System.Drawing.Point(138, 88);
      this.boxValorEntrada.Name = "boxValorEntrada";
      this.boxValorEntrada.Size = new System.Drawing.Size(152, 20);
      this.boxValorEntrada.TabIndex = 0;
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(13, 134);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(106, 13);
      this.label6.TabIndex = 1;
      this.label6.Text = "Número de Parcelas:";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.Location = new System.Drawing.Point(195, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(149, 22);
      this.label1.TabIndex = 2;
      this.label1.Text = "Seleciona Planos";
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
      this.groupBox1.Controls.Add(this.groupBox2);
      this.groupBox1.Controls.Add(this.btOk);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Controls.Add(this.btCancelar);
      this.groupBox1.Controls.Add(this.panel1);
      this.groupBox1.Location = new System.Drawing.Point(2, 2);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(551, 420);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Dados";
      // 
      // groupBox2
      // 
      this.groupBox2.BackColor = System.Drawing.Color.Silver;
      this.groupBox2.Controls.Add(this.lblMaxDias);
      this.groupBox2.Controls.Add(this.lblMaxParcelas);
      this.groupBox2.Controls.Add(this.lblValorMinParcela);
      this.groupBox2.Location = new System.Drawing.Point(328, 68);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(214, 283);
      this.groupBox2.TabIndex = 3;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Informações";
      // 
      // lblMaxDias
      // 
      this.lblMaxDias.AutoSize = true;
      this.lblMaxDias.Location = new System.Drawing.Point(16, 166);
      this.lblMaxDias.Name = "lblMaxDias";
      this.lblMaxDias.Size = new System.Drawing.Size(114, 13);
      this.lblMaxDias.TabIndex = 3;
      this.lblMaxDias.Text = "Máx. Dias Pré-Datado:";
      // 
      // lblMaxParcelas
      // 
      this.lblMaxParcelas.AutoSize = true;
      this.lblMaxParcelas.Location = new System.Drawing.Point(16, 108);
      this.lblMaxParcelas.Name = "lblMaxParcelas";
      this.lblMaxParcelas.Size = new System.Drawing.Size(136, 13);
      this.lblMaxParcelas.TabIndex = 2;
      this.lblMaxParcelas.Text = "Num. Máximo de Parcelas :";
      // 
      // SelecionaPlanos
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.LightSkyBlue;
      this.CancelButton = this.btCancelar;
      this.ClientSize = new System.Drawing.Size(555, 423);
      this.Controls.Add(this.groupBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Name = "SelecionaPlanos";
      this.Text = "SelecionaPlanos";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    public System.Windows.Forms.TextBox boxValorTrans;
    private System.Windows.Forms.Button btOk;
    private System.Windows.Forms.Button btCancelar;
    public System.Windows.Forms.TextBox boxData;
    public System.Windows.Forms.TextBox boxNumeroParcelas;
    public System.Windows.Forms.TextBox boxValorParcela;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Panel panel1;
    public System.Windows.Forms.TextBox boxValorEntrada;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    public System.Windows.Forms.Label lblValorMinParcela;
    public System.Windows.Forms.Label lblMaxDias;
    public System.Windows.Forms.Label lblMaxParcelas;

  }
}