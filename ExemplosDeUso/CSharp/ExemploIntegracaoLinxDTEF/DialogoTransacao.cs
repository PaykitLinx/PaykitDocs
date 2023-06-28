using System;
using System.Windows.Forms;

namespace LinxDTEF
{
  public partial class FormTransacao : Form
  {
    public ModoOperacao modo;
    ExemploTelaPrincipal caller;
    private int iOpcaoSelecionada;
    public int iNumeroCasasValor = 0;

    public FormTransacao(ExemploTelaPrincipal caller)
    {
      InitializeComponent();
      this.caller = caller;
    }

    public int getOpcaoSelecionada()
    {
      return iOpcaoSelecionada;
    }

    public void SetaMensagem(string sMensagem, int iTipo = 0)
    {
      lblDisplay.Visible = false;
      lblDisplayErro.Visible = false;

      if (iTipo == 0)
      {
        lblDisplay.Visible = true;
        lblDisplay.Text = sMensagem;
      }
      else if (iTipo == 1)
      {
        lblDisplayErro.Visible = true;
        lblDisplayErro.Text = sMensagem;
      }
      else
      {
        lblMensagemDpos.Text = sMensagem;
      }
      Application.DoEvents();
    }

    public void setModo(ModoOperacao modo, string sLabel = "", string sValor = "")
    {
      this.modo = modo;
      switch (modo)
      {
        case ModoOperacao.MODO_DEFAULT:
          edtValor.Enabled = false;
          lbxOpcoes.Enabled = false;
          break;
        case ModoOperacao.MODO_ENTRA_VALOR:
          lblMensagem.Text = sLabel;
          lblMensagem.Visible = true;
          edtValor.Enabled = true;
          edtValor.Visible = true;
          edtValor.MaxLength = 16;
          edtValor.Text = sValor;
          edtValor.TextAlign = HorizontalAlignment.Right;
          edtValor.SelectionStart = edtValor.Text.Length;
          edtValor.Focus();
          lbxOpcoes.Visible = false;
          break;
        case ModoOperacao.MODO_ENTRA_VALOR_ESPECIAL:
          lblMensagem.Text = sLabel;
          lblMensagem.Visible = true;
          edtValor.Enabled = true;
          edtValor.Visible = true;
          edtValor.MaxLength = 16;
          edtValor.Text = sValor;
          edtValor.TextAlign = HorizontalAlignment.Right;
          edtValor.SelectionStart = edtValor.Text.Length;
          edtValor.Focus();
          lbxOpcoes.Visible = false;
          break;
        case ModoOperacao.MODO_ENTRA_CARTAO:
          lblMensagem.Text = sLabel;
          lblMensagem.Visible = true;
          edtValor.Enabled = true;
          edtValor.Visible = true;
          edtValor.MaxLength = 19;
          edtValor.Text = sValor;
          edtValor.Focus();
          lbxOpcoes.Visible = false;
          break;
        case ModoOperacao.MODO_ENTRA_DATAVALIDADE:
          lblMensagem.Text = sLabel;
          lblMensagem.Visible = true;
          edtValor.Enabled = true;
          edtValor.Visible = true;
          edtValor.MaxLength = 5;
          edtValor.Text = sValor;
          edtValor.Focus();
          lbxOpcoes.Visible = false;
          break;
        case ModoOperacao.MODO_ENTRA_DATA:
          lblMensagem.Text = sLabel;
          lblMensagem.Visible = true;
          edtValor.Enabled = true;
          edtValor.Visible = true;
          edtValor.MaxLength = 8;
          edtValor.Text = sValor;
          edtValor.Focus();
          lbxOpcoes.Visible = false;
          break;
        case ModoOperacao.MODO_ENTRA_CODIGO_SEGURANCA:
          lblMensagem.Text = sLabel;
          lblMensagem.Visible = true;
          edtValor.Enabled = true;
          edtValor.Visible = true;
          edtValor.MaxLength = 5;
          edtValor.Text = sValor;
          edtValor.Focus();
          lbxOpcoes.Visible = false;
          break;
        case ModoOperacao.MODO_SELECIONA_OPCAO:
          lblMensagem.Text = sLabel;
          lblMensagem.Visible = true;
          lbxOpcoes.Enabled = true;
          lbxOpcoes.Visible = true;
          lbxOpcoes.Focus();
          edtValor.Visible = false;
          break;
        case ModoOperacao.MODO_ENTRA_NUMERO:
          lblMensagem.Text = sLabel;
          lblMensagem.Visible = true;
          edtValor.Enabled = true;
          edtValor.Visible = true;
          edtValor.Text = sValor;
          edtValor.Focus();
          lbxOpcoes.Visible = false;
          break;
        case ModoOperacao.MODO_ENTRA_STRING:
          lblMensagem.Text = sLabel;
          lblMensagem.Visible = true;
          edtValor.Enabled = true;
          edtValor.Visible = true;
          edtValor.Text = sValor;
          edtValor.Focus();
          lbxOpcoes.Visible = false;
          break;
        case ModoOperacao.MODO_VAZIO:

          break;
      }
    }

    public void AjustaBoxOpcoes(string sOpcoes)
    {
      lbxOpcoes.Items.Clear();
      string[] VetorOpcoes = sOpcoes.Split('#');
      for (int i = 0; i < VetorOpcoes.Length; i++)
      {
        string sOpcao = RetiraPrimeiroEUltimoCaracter(VetorOpcoes[i]);

        string[] VetorOpcao = sOpcao.Split(',');
        lbxOpcoes.Items.Add(RetiraPrimeiroEUltimoCaracter(VetorOpcao[1]));
      }

      lbxOpcoes.SelectedIndex = 0;
    }

    private string RetiraPrimeiroEUltimoCaracter(string sTexto)
    {
      sTexto = sTexto.Remove(sTexto.Length - 1);
      sTexto = sTexto.Remove(0, 1);
      return sTexto;
    }

    public Decimal getValorSemMascara()
    {
      string sValor = edtValor.Text;
      string sValor2 = "";

      // somente numero
      for (int i = 0; i < sValor.Length; i++)
      {
        if ((sValor[i] >= '0') && (sValor[i] <= '9'))
          sValor2 = sValor2 + sValor[i];
      }

      return Conversor.ToDecimalDef(sValor2, 0);
    }

    public Decimal getValorSemMascara(int iNumeroCasas)
    {
      return getValorSemMascara() / (Decimal)Math.Pow(10, iNumeroCasas);
    }

    #region eventos
    private void btnCancelar_Click(object sender, EventArgs e)
    {
      //se estiver aguardando qualquer tecla, não considera como um aborto
      if (caller.getAguardandoQualquerTecla())
      {
        caller.bTeclaPressionada = true;
      }
      else
      {
        caller.bOperacaoCancelada = true;
        caller.bTeclaPressionada = true;
      }
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      caller.bTeclaPressionada = true;
    }

    private void dlgTransacao_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Escape)
      {
        btnCancelar_Click(sender, e);
      }

      if (caller.getAguardandoQualquerTecla())
      {
        caller.bTeclaPressionada = true;
      }
    }

    private void lbxOpcoes_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Escape)
      {
        btnCancelar_Click(sender, e);
      }
      if (e.KeyCode == Keys.Enter)
      {
        btnOK_Click(sender, e);
      }
    }

    private void btnOK_Click(object sender, EventArgs e)
    {
      if (modo == ModoOperacao.MODO_ENTRA_DATAVALIDADE)
        edtValor.Text = edtValor.Text.Replace("/", "");

      if (modo == ModoOperacao.MODO_SELECIONA_OPCAO)
        iOpcaoSelecionada = lbxOpcoes.SelectedIndex + 1;

      caller.bTeclaPressionada = true;
      caller.bOperacaoCancelada = false;
    }

    private void dlgTransacao_Load(object sender, EventArgs e)
    {
      this.CenterToScreen();
    }

    private void edtValor_TextChanged(object sender, EventArgs e)
    {
      if (modo == ModoOperacao.MODO_ENTRA_DATAVALIDADE)
      {
        if (edtValor.Text.Length == 2)
          edtValor.Text += "/";
        edtValor.Select(edtValor.Text.Length, 0);
      }
      if (modo == ModoOperacao.MODO_ENTRA_DATA)
      {
        if (edtValor.Text.Length == 2 || edtValor.Text.Length == 5)
          edtValor.Text += "/";
        edtValor.Select(edtValor.Text.Length, 0);
      }
    }

    private void edtValor_KeyDown(object sender, KeyEventArgs e)
    {

    }

    private void edtValor_KeyPress(object sender, KeyPressEventArgs e)
    {
      if ((e.KeyChar == (char)Keys.Enter) || (e.KeyChar == (char)Keys.Return))
      {
        e.Handled = true;
        btnOK_Click(sender, e);
        return;
      }
      if (e.KeyChar == (char)Keys.Escape)
      {
        e.Handled = true;
        btnCancelar_Click(sender, e);
        return;
      }

      if (modo == ModoOperacao.MODO_ENTRA_VALOR || modo == ModoOperacao.MODO_ENTRA_VALOR_ESPECIAL)
      {
        e.Handled = true;
        bool bAtualizaValor = false;
        bool bRemoverValor = false;

        if ((e.KeyChar == (char)Keys.Delete) || (e.KeyChar == (char)Keys.Back))
        {
          bRemoverValor = true;
        }
        else if ((e.KeyChar >= '0') && (e.KeyChar <= '9'))
        {
          if (edtValor.Text.Length < edtValor.MaxLength)
            bAtualizaValor = true;
        }

        if (bAtualizaValor || bRemoverValor)
        {
          string sValorSemMascara = Conversor.DecimalToString(getValorSemMascara(), 0);

          if (sValorSemMascara == "0")
            sValorSemMascara = "";

          if (bAtualizaValor)
            sValorSemMascara += e.KeyChar;
          else if (bRemoverValor)
            sValorSemMascara = sValorSemMascara.Remove(sValorSemMascara.Length - 1);

          Decimal dValor = Conversor.ToDecimalDef(sValorSemMascara, 0) / (Decimal)Math.Pow(10, iNumeroCasasValor);
          edtValor.Text = Conversor.DecimalToString(dValor, iNumeroCasasValor);
          edtValor.SelectionStart = edtValor.Text.Length;
        }
      }
      else if (modo != ModoOperacao.MODO_ENTRA_STRING)
      {
        if ((e.KeyChar != (char)Keys.Delete) && (e.KeyChar != (char)Keys.Back) && ((e.KeyChar < '0') || (e.KeyChar > '9')))
          e.Handled = true;
      }
    }

    #endregion

    //desativa o close do form
    private const int CP_NOCLOSE_BUTTON = 0x200;
    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams myCp = base.CreateParams;
        myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
        return myCp;
      }
    }
  }
}
