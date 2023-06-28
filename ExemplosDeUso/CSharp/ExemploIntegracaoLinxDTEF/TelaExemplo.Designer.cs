namespace LinxDTEF
{
  partial class TelaExemplo
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
      this.button1 = new System.Windows.Forms.Button();
      this.lblDisplayTerminal = new System.Windows.Forms.Label();
      this.lblDisplayErro = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(59, 31);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(221, 23);
      this.button1.TabIndex = 0;
      this.button1.Text = "Transação Cartão Crédito";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // lblDisplayTerminal
      // 
      this.lblDisplayTerminal.AutoSize = true;
      this.lblDisplayTerminal.Location = new System.Drawing.Point(12, 70);
      this.lblDisplayTerminal.Name = "lblDisplayTerminal";
      this.lblDisplayTerminal.Size = new System.Drawing.Size(81, 13);
      this.lblDisplayTerminal.TabIndex = 1;
      this.lblDisplayTerminal.Text = "DisplayTerminal";
      // 
      // lblDisplayErro
      // 
      this.lblDisplayErro.AutoSize = true;
      this.lblDisplayErro.Location = new System.Drawing.Point(12, 108);
      this.lblDisplayErro.Name = "lblDisplayErro";
      this.lblDisplayErro.Size = new System.Drawing.Size(60, 13);
      this.lblDisplayErro.TabIndex = 2;
      this.lblDisplayErro.Text = "DisplayErro";
      // 
      // TelaExemplo
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(350, 130);
      this.Controls.Add(this.lblDisplayErro);
      this.Controls.Add(this.lblDisplayTerminal);
      this.Controls.Add(this.button1);
      this.Name = "TelaExemplo";
      this.Text = "Exemplo C# - Integração Linx D-TEF ";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Label lblDisplayTerminal;
    private System.Windows.Forms.Label lblDisplayErro;
  }
}

