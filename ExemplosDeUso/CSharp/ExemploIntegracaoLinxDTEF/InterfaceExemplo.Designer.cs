namespace LinxDTEF
{
  partial class InterfaceExemplo
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InterfaceExemplo));
      this.panel1 = new System.Windows.Forms.Panel();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.lblDisplayTerminal = new System.Windows.Forms.Label();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.panel4 = new System.Windows.Forms.Panel();
      this.panel3 = new System.Windows.Forms.Panel();
      this.button1 = new System.Windows.Forms.Button();
      this.btConsultaAVS = new System.Windows.Forms.Button();
      this.btCartaoVoucher = new System.Windows.Forms.Button();
      this.btCartaoDebito = new System.Windows.Forms.Button();
      this.btCartaoCredito = new System.Windows.Forms.Button();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.lblDisplayErro = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      this.panel3.SuspendLayout();
      this.SuspendLayout();
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.SeaShell;
      this.panel1.Controls.Add(this.groupBox1);
      this.panel1.Controls.Add(this.pictureBox1);
      this.panel1.Controls.Add(this.tabControl1);
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(513, 568);
      this.panel1.TabIndex = 0;
      // 
      // groupBox1
      // 
      this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
      this.groupBox1.Controls.Add(this.lblDisplayErro);
      this.groupBox1.Controls.Add(this.lblDisplayTerminal);
      this.groupBox1.Location = new System.Drawing.Point(127, 12);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(371, 92);
      this.groupBox1.TabIndex = 2;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Display Terminal";
      // 
      // lblDisplayTerminal
      // 
      this.lblDisplayTerminal.AutoSize = true;
      this.lblDisplayTerminal.Location = new System.Drawing.Point(128, 28);
      this.lblDisplayTerminal.Name = "lblDisplayTerminal";
      this.lblDisplayTerminal.Size = new System.Drawing.Size(84, 13);
      this.lblDisplayTerminal.TabIndex = 0;
      this.lblDisplayTerminal.Text = "Display Terminal";
      // 
      // pictureBox1
      // 
      this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(5, 3);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(116, 101);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.pictureBox1.TabIndex = 1;
      this.pictureBox1.TabStop = false;
      // 
      // tabControl1
      // 
      this.tabControl1.AccessibleDescription = "";
      this.tabControl1.AccessibleName = "";
      this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(0, 110);
      this.tabControl1.Multiline = true;
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(502, 455);
      this.tabControl1.TabIndex = 0;
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.Color.SeaShell;
      this.tabPage1.Controls.Add(this.panel4);
      this.tabPage1.Controls.Add(this.panel3);
      this.tabPage1.Location = new System.Drawing.Point(4, 4);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(475, 447);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Transações Comuns";
      // 
      // panel4
      // 
      this.panel4.BackColor = System.Drawing.SystemColors.ControlLight;
      this.panel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel4.Location = new System.Drawing.Point(254, 6);
      this.panel4.Name = "panel4";
      this.panel4.Size = new System.Drawing.Size(234, 420);
      this.panel4.TabIndex = 4;
      // 
      // panel3
      // 
      this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
      this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.panel3.Controls.Add(this.button1);
      this.panel3.Controls.Add(this.btConsultaAVS);
      this.panel3.Controls.Add(this.btCartaoVoucher);
      this.panel3.Controls.Add(this.btCartaoDebito);
      this.panel3.Controls.Add(this.btCartaoCredito);
      this.panel3.Location = new System.Drawing.Point(6, 6);
      this.panel3.Name = "panel3";
      this.panel3.Size = new System.Drawing.Size(242, 420);
      this.panel3.TabIndex = 2;
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.SeaShell;
      this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button1.Location = new System.Drawing.Point(17, 268);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(147, 32);
      this.button1.TabIndex = 3;
      this.button1.Text = "Consulta Saldo";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.btConsultaAVS_Click);
      // 
      // btConsultaAVS
      // 
      this.btConsultaAVS.BackColor = System.Drawing.Color.SeaShell;
      this.btConsultaAVS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btConsultaAVS.Location = new System.Drawing.Point(17, 204);
      this.btConsultaAVS.Name = "btConsultaAVS";
      this.btConsultaAVS.Size = new System.Drawing.Size(147, 32);
      this.btConsultaAVS.TabIndex = 3;
      this.btConsultaAVS.Text = "Consulta AVS";
      this.btConsultaAVS.UseVisualStyleBackColor = false;
      this.btConsultaAVS.Click += new System.EventHandler(this.btConsultaAVS_Click);
      // 
      // btCartaoVoucher
      // 
      this.btCartaoVoucher.BackColor = System.Drawing.Color.SeaShell;
      this.btCartaoVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCartaoVoucher.Location = new System.Drawing.Point(17, 139);
      this.btCartaoVoucher.Name = "btCartaoVoucher";
      this.btCartaoVoucher.Size = new System.Drawing.Size(147, 32);
      this.btCartaoVoucher.TabIndex = 2;
      this.btCartaoVoucher.Text = "Cartão Voucher";
      this.btCartaoVoucher.UseVisualStyleBackColor = false;
      this.btCartaoVoucher.Click += new System.EventHandler(this.btCartaoVoucher_Click);
      // 
      // btCartaoDebito
      // 
      this.btCartaoDebito.BackColor = System.Drawing.Color.SeaShell;
      this.btCartaoDebito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCartaoDebito.Location = new System.Drawing.Point(17, 79);
      this.btCartaoDebito.Name = "btCartaoDebito";
      this.btCartaoDebito.Size = new System.Drawing.Size(147, 32);
      this.btCartaoDebito.TabIndex = 1;
      this.btCartaoDebito.Text = "Transação de Débito";
      this.btCartaoDebito.UseVisualStyleBackColor = false;
      this.btCartaoDebito.Click += new System.EventHandler(this.btCartaoDebito_Click);
      // 
      // btCartaoCredito
      // 
      this.btCartaoCredito.BackColor = System.Drawing.Color.SeaShell;
      this.btCartaoCredito.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.btCartaoCredito.Location = new System.Drawing.Point(17, 18);
      this.btCartaoCredito.Name = "btCartaoCredito";
      this.btCartaoCredito.Size = new System.Drawing.Size(147, 32);
      this.btCartaoCredito.TabIndex = 0;
      this.btCartaoCredito.Text = "Transação de Crédito";
      this.btCartaoCredito.UseVisualStyleBackColor = false;
      this.btCartaoCredito.Click += new System.EventHandler(this.btCartaoCredito_Click);
      // 
      // tabPage2
      // 
      this.tabPage2.Location = new System.Drawing.Point(4, 4);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(475, 447);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // lblDisplayErro
      // 
      this.lblDisplayErro.AutoSize = true;
      this.lblDisplayErro.Location = new System.Drawing.Point(128, 64);
      this.lblDisplayErro.Name = "lblDisplayErro";
      this.lblDisplayErro.Size = new System.Drawing.Size(63, 13);
      this.lblDisplayErro.TabIndex = 1;
      this.lblDisplayErro.Text = "Display Erro";
      // 
      // InterfaceExemplo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(504, 563);
      this.Controls.Add(this.panel1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "InterfaceExemplo";
      this.Text = "InterfaceExemplo";
      this.Load += new System.EventHandler(this.InterfaceExemplo_Load);
      this.panel1.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      this.panel3.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Panel panel4;
    private System.Windows.Forms.Panel panel3;
    private System.Windows.Forms.Button btConsultaAVS;
    private System.Windows.Forms.Button btCartaoVoucher;
    private System.Windows.Forms.Button btCartaoDebito;
    private System.Windows.Forms.Button btCartaoCredito;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label lblDisplayTerminal;
    private System.Windows.Forms.Label lblDisplayErro;
  }
}