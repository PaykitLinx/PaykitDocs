using System;
using System.Windows.Forms;

namespace LinxDTEF
{
  public partial class ExemploTelaPrincipal : Form, IGerenciadorSemTelas
  {
    public bool bAguardandoQualquerTecla;
    public bool bTeclaPressionada;
    public bool bOperacaoCancelada;
    private FormTransacao _dlgTransacao;
    public FormTransacao dlgTransacao
    {
      get
      {
        if (_dlgTransacao == null)
        {
          _dlgTransacao = new FormTransacao(this);
          _dlgTransacao.Show();
        }
        return _dlgTransacao;
      }
      set
      {
        _dlgTransacao = value;
      }
    }

    public ExemploTelaPrincipal()
    {
      bOperacaoCancelada = false;
      bTeclaPressionada = false;
      bAguardandoQualquerTecla = false;
      InitializeComponent();
    }

    #region Implementação da interface IGerenciadorSemTelas

    public void DisplayTerminal(string sMensagem)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "DisplayTerminal", sMensagem);
      dlgTransacao.SetaMensagem(sMensagem);
    }
    
    public void DisplayErro(string sMensagem)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "DisplayErro", sMensagem);
      dlgTransacao.SetaMensagem(sMensagem, 1);
    }
    
    public void Mensagem(string sMensagem)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "Mensagem", sMensagem);
      dlgTransacao.SetaMensagem(sMensagem, 2);
    }
    
    public void Beep()
    {
      System.Diagnostics.Debug.Print("Beep --- " + DateTime.Now.ToString());
      //System.Media.SystemSounds.Beep.Play();
    }
    
    public int SolicitaConfirmacao(string sMensagem)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "SolicitaConfirmacao", sMensagem);

      if (sMensagem == "")
      {
        aguardar(true);
      }
      else
      {
        DialogResult dialogResult = MessageBox.Show(sMensagem, "Solicita Confirmação", MessageBoxButtons.YesNo);
        if (dialogResult == DialogResult.No)
        {
          return -1;
        }
      }

      return 0;
    }
    
    public int EntraCartao(string sLabel, ref string sNumeroCartao)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraCartao", sLabel);

      sNumeroCartao = "";

      dlgTransacao.setModo(ModoOperacao.MODO_ENTRA_CARTAO, sLabel);

      dlgTransacao.lblMensagem.Text = sLabel;
      dlgTransacao.lblMensagem.Visible = true;
      dlgTransacao.edtValor.MaxLength = 30;

      aguardar();

      dlgTransacao.setModo(ModoOperacao.MODO_DEFAULT);

      if (bOperacaoCancelada)
      {
        bOperacaoCancelada = false;
        return -1;
      }
      sNumeroCartao = dlgTransacao.edtValor.Text;
      return 0;
    }

    public int EntraDataValidade(string sLabel, ref string sDataValidade)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraDataValidade", sLabel);

      dlgTransacao.setModo(ModoOperacao.MODO_ENTRA_DATAVALIDADE, sLabel);

      aguardar();

      dlgTransacao.setModo(ModoOperacao.MODO_DEFAULT);
      
      if (bOperacaoCancelada)
      {
        bOperacaoCancelada = false;
        return -1;
      }
      sDataValidade = dlgTransacao.edtValor.Text;
      return 0;
    }
    
    public int EntraData(string sLabel, ref string sDataValidade)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraData", sLabel);

      dlgTransacao.setModo(ModoOperacao.MODO_ENTRA_DATA, sLabel);

      aguardar();

      dlgTransacao.setModo(ModoOperacao.MODO_DEFAULT);

      if (bOperacaoCancelada)
      {
        bOperacaoCancelada = false;
        return -1;
      }
      sDataValidade = dlgTransacao.edtValor.Text;
      return 0;
    }
    
    public int EntraCodigoSeguranca(string sLabel, ref string sEntraCodigoSeguranca, int iTamanhoMax)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraCodigoSeguranca", sLabel);

      dlgTransacao.setModo(ModoOperacao.MODO_ENTRA_CODIGO_SEGURANCA, sLabel);

      dlgTransacao.edtValor.MaxLength = iTamanhoMax;

      aguardar();

      dlgTransacao.setModo(ModoOperacao.MODO_DEFAULT); 
      
      if (bOperacaoCancelada)
      {
        bOperacaoCancelada = false;
        return -1;
      }
      sEntraCodigoSeguranca = dlgTransacao.edtValor.Text;
      return 0;
    }
    
    public int SelecionaOpcao(string sLabel, string sOpcoes, ref int iOpcaoSelecionada)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2} - {3}", DateTime.Now, "SelecionaOpcao", sLabel, sOpcoes);

      dlgTransacao.setModo(ModoOperacao.MODO_SELECIONA_OPCAO, sLabel);

      dlgTransacao.AjustaBoxOpcoes(sOpcoes);

      aguardar();

      dlgTransacao.setModo(ModoOperacao.MODO_DEFAULT); 
      if (bOperacaoCancelada)
      {
        bOperacaoCancelada = false;
        return -1;
      }

      iOpcaoSelecionada = dlgTransacao.getOpcaoSelecionada();

      return 0;
    }
    
    public int EntraValor(string sLabel, ref Decimal dValor, Decimal dValorMinimo, Decimal dValorMaximo)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraValor", sLabel);

      if (dValor < 0)
        dValor = 0;

      dlgTransacao.setModo(ModoOperacao.MODO_ENTRA_VALOR, sLabel, Conversor.DecimalToString(dValor, 2));
      
      //edita o maximo de digitos permitidos de acordo com o valor máximo aceito
      dlgTransacao.edtValor.MaxLength = Math.Max(Conversor.DecimalToString(dValorMaximo, 2).Length, 2 + 2);
      dlgTransacao.iNumeroCasasValor = 2;
      
      while (true)
      {
        aguardar();

        if (bOperacaoCancelada)
        {
          bOperacaoCancelada = false;
          return -1;
        }

        dValor = dlgTransacao.getValorSemMascara(2);

        if (dValor < dValorMinimo)
          dlgTransacao.SetaMensagem(String.Format("VALOR MIN. DE {0:#,##0.00}", dValorMinimo), 1);
        else if (dValor > dValorMaximo)
          dlgTransacao.SetaMensagem(String.Format("VALOR MAX. DE {0:#,##0.00}", dValorMaximo), 1);
        else
          break;
      }

      dlgTransacao.setModo(ModoOperacao.MODO_DEFAULT);

      return 0;
    }
    public int EntraValorEspecial(string sLabel, ref Decimal dValor, Decimal dValorMinimo, Decimal dValorMaximo, int iCasasDecimaisEntraValor)
    {
      //VDEUNER: em construção
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraValorEspecial", sLabel);

      if (dValor < 0)
        dValor = 0;

      dlgTransacao.setModo(ModoOperacao.MODO_ENTRA_VALOR_ESPECIAL, sLabel, Conversor.DecimalToString(dValor, iCasasDecimaisEntraValor));
      
      //edita o maximo de digitos permitidos de acordo com o valor máximo aceito
      dlgTransacao.edtValor.MaxLength = Math.Max(Conversor.DecimalToString(dValorMaximo, iCasasDecimaisEntraValor).Length, iCasasDecimaisEntraValor + 2);
      dlgTransacao.iNumeroCasasValor = iCasasDecimaisEntraValor;

      while (true)
      {
        aguardar();

        if (bOperacaoCancelada)
        {
          bOperacaoCancelada = false;
          return -1;
        }

        dValor = dlgTransacao.getValorSemMascara(iCasasDecimaisEntraValor);

        if (dValor < dValorMinimo)
          dlgTransacao.SetaMensagem(String.Format("VALOR MIN. DE {0}", Conversor.DecimalToString(dValorMinimo, iCasasDecimaisEntraValor)), 1);
        else if (dValor > dValorMaximo)
          dlgTransacao.SetaMensagem(String.Format("VALOR MAX. DE {0}", Conversor.DecimalToString(dValorMaximo, iCasasDecimaisEntraValor)), 1);
        else
          break;
      }

      dlgTransacao.setModo(ModoOperacao.MODO_DEFAULT);

      return 0;
    }
    
    public int EntraNumero(string sLabel, ref string sNumero, int iNumeroMinimo, int iNumeroMaximo, int iMinimoDigitos, int iMaximoDigitos, int iDigitosExatos)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraNumero", sLabel);

      dlgTransacao.setModo(ModoOperacao.MODO_ENTRA_NUMERO, sLabel, sNumero.Trim());

      if (iDigitosExatos > 0)
        dlgTransacao.edtValor.MaxLength = iDigitosExatos;
      else
        dlgTransacao.edtValor.MaxLength = iMaximoDigitos;

      while (true)
      {
        aguardar();

        sNumero = dlgTransacao.edtValor.Text;

        if (bOperacaoCancelada)
        {
          bOperacaoCancelada = false;
          return -1;
        }

        int iValorTemp = 0;
        if (int.TryParse(sNumero, out iValorTemp))
          iValorTemp = 0;

        if (iDigitosExatos > 0 && sNumero.Length != iDigitosExatos)
          dlgTransacao.SetaMensagem(String.Format("DEVE CONTER {0} DIGITOS", iDigitosExatos), 1);
        else if (sNumero.Length < iMinimoDigitos)
          dlgTransacao.SetaMensagem(String.Format("DEVE CONTER AO MENOS {0} DIGITOS", iMinimoDigitos), 1);
        else if (iValorTemp < iNumeroMinimo)
          dlgTransacao.SetaMensagem(String.Format("VALOR MIN. DE {0}", iNumeroMinimo), 1);
        else if (iValorTemp > iNumeroMaximo)
          dlgTransacao.SetaMensagem(String.Format("VALOR MAX. DE {0}", iNumeroMaximo), 1);
        else
          break;
      }

      dlgTransacao.setModo(ModoOperacao.MODO_DEFAULT);

      return 0;
    }
    
    public int OperacaoCancelada()
    {
      //System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "OperacaoCancelada", bOperacaoCancelada);

      if (bOperacaoCancelada)
        return 1;

      return 0;
    }
    
    public int SetaOperacaoCancelada(bool bCancelada)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - de {2} para {3}", DateTime.Now, "SetaOperacaoCancelada", bOperacaoCancelada, bCancelada);

      bOperacaoCancelada = bCancelada;
      return 0;
    }

    public void ProcessaMensagens()
    {
      Application.DoEvents();
    }

    public int EntraString(string sLabel, ref string sString, string sTamanhoMaximo)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraString", sLabel);
      
      int iTamMaximo = 0;
      if (int.TryParse(sTamanhoMaximo, out iTamMaximo))
        iTamMaximo = 0;

      dlgTransacao.setModo(ModoOperacao.MODO_ENTRA_STRING, sLabel, sString.Trim());
      dlgTransacao.edtValor.MaxLength = iTamMaximo;

      aguardar();

      sString = dlgTransacao.edtValor.Text;

      if (bOperacaoCancelada)
      {
        bOperacaoCancelada = false;
        return -1;
      }

      dlgTransacao.setModo(ModoOperacao.MODO_DEFAULT);
      return 0;
    }

    public void MensagemAlerta(string sMensagemAlerta)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "MensagemAlerta", sMensagemAlerta);

      MessageBox.Show(sMensagemAlerta, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    
    #endregion

    #region em construção
    public int ConsultaAVS(ref string sEndereco, ref string sNumero, ref string sApto, ref string sBloco, ref string sCEP, ref string sBairro, ref string sCPF)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1}", DateTime.Now, "ConsultaAVS");

      ConsultaAVS AVSForm = new ConsultaAVS();
      AVSForm.ShowDialog();
      sEndereco = AVSForm.boxEndereco.Text;
      sNumero = AVSForm.boxNumero.Text;
      sApto = AVSForm.boxApartamento.Text;
      sBloco = AVSForm.boxBloco.Text;
      sCEP = AVSForm.boxBloco.Text;
      sBairro = AVSForm.boxBairro.Text;
      sCPF = AVSForm.boxCPF.Text;
      return 0;
    }

    public int MensagemAdicional(string sMensagemAdicional)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "MensagemAdicional", sMensagemAdicional);

      return 0;
    }

    public int DadosHistorico(string sParte1, int sTamParte1, string sParte2, int iTamParte2)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2} e {3}", DateTime.Now, "DadosHistorico", sParte1, sParte2);

      return 0;
    }

    public int ImagemAdicional(int iIndiceImagem)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "ImagemAdicional", iIndiceImagem);

      return 0;
    }

    public int EntraCodigoBarras(string sLabel, ref string sCampo)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraCodigoBarras", sLabel);

      sCampo = "";
      return 0;
    }
    public int EntraCodigoBarrasLido(string sLabel, ref string sCampo)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "EntraCodigoBarrasLido", sLabel);

      sCampo = "";
      return 0;
    }

    public void PreviewComprovante(string sComprovante)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1} - {2}", DateTime.Now, "PreviewComprovante");
    }

    public int SelecionaPlanosEx(string sSolicitacao, ref string sRetorno)
    {
      sRetorno = "";
      System.Diagnostics.Debug.Print("O método Seleciona Planos Ex foi chamado, mas não implementado neste exemplo");
      return -1;
    }

    public int SelecionaPlanos(int iCodigoRede, int iCodigoTransacao, int iTipoFinanciamento, int iMaximoParcelas, Decimal dValorMinimoParcela, int iMaxDiasPreDatado,
     ref int iNumeroParcelas, ref Decimal dValorTransacao, ref Decimal dValorParcela, ref Decimal dValorEntrada, ref string sData)
    {
      System.Diagnostics.Debug.Print("{0:dd/MM/yyyy HH:mm:SS.ss} | {1}", DateTime.Now, "SelecionaPlanos");

      dValorTransacao = 0;
      dValorParcela = 0;
      dValorEntrada = 0;
      sData = "";

      try
      {
        SelecionaPlanos formSelecionaPlanos = new SelecionaPlanos();
        formSelecionaPlanos.lblValorMinParcela.Text += " " + dValorMinimoParcela;
        formSelecionaPlanos.lblMaxDias.Text += " " + iMaxDiasPreDatado.ToString();
        formSelecionaPlanos.lblMaxParcelas.Text += " " + iMaximoParcelas.ToString();
        formSelecionaPlanos.ShowDialog();
        if (formSelecionaPlanos.status == -2)
          return -2;
        dValorTransacao = Conversor.ToDecimalDef(formSelecionaPlanos.boxValorTrans.Text, 0);
        dValorEntrada = Conversor.ToDecimalDef(formSelecionaPlanos.boxValorEntrada.Text, 0);
        iNumeroParcelas = Conversor.ToIntDef(formSelecionaPlanos.boxNumeroParcelas.Text, 0);
        dValorParcela = Conversor.ToIntDef(formSelecionaPlanos.boxValorParcela.Text, 0);
        sData = formSelecionaPlanos.boxData.Text;
        formSelecionaPlanos.Dispose();

        return 0;
      }
      catch (Exception e)
      {
        return -1;
      }

    }
    #endregion

    private void btnCartaoCredito_Click(object sender, EventArgs e)
    {
      int numeroControle;
      Decimal valorTransacao = 0;
      int numeroCupom = 0;
      IntegracaoLinxDTEF integracaoLinxDTEF = new IntegracaoLinxDTEF();
      integracaoLinxDTEF.setGerenciadorSemTelas(this);

      int resultado = integracaoLinxDTEF.TransacaoCartaoCredito(valorTransacao, numeroCupom, out numeroControle);
      if (resultado == 0)
      {
        DialogResult result = MessageBox.Show("Transação concluída com sucesso. Número controle (NSU D-TEF) = {0}. Deseja confirmar a transação " + numeroControle, "Confirmar transação?", MessageBoxButtons.YesNo);

        if (result == DialogResult.Yes)
          integracaoLinxDTEF.ConfirmaCartao(numeroControle);
        else
          integracaoLinxDTEF.DesfazCartao(numeroControle);
      }         
   
      integracaoLinxDTEF.FinalizaTransacao();
      bOperacaoCancelada = false;
      if (dlgTransacao != null)
      {
        dlgTransacao.Close();
        dlgTransacao = null;
      }

    }

    private void InterfaceExemplo_Load(object sender, EventArgs e)
    {
      this.CenterToScreen();
    }

    private void ExemploTelaPrincipal_Load(object sender, EventArgs e)
    {
      this.CenterToScreen();
    }

    private void aguardar(bool bQualquerTecla = false)
    {
      bTeclaPressionada = false;

      if (bQualquerTecla)
        setAguardandoQualquerTecla(true);

      while (true)
      {
        if (bTeclaPressionada)
          break;

        System.Threading.Thread.Sleep(100);
        Application.DoEvents();
      }

      //retorna controles
      bTeclaPressionada = false;
      if (bQualquerTecla)
        setAguardandoQualquerTecla(false);
    }

    public bool getAguardandoQualquerTecla()
    {
      return bAguardandoQualquerTecla;
    }

    public void setAguardandoQualquerTecla(bool bAguardandoQualquerTecla)
    {
      this.bAguardandoQualquerTecla = bAguardandoQualquerTecla;
    }

    private void btnObtemLog_Click(object sender, EventArgs e)
    {
      string s = "";
      IntegracaoLinxDTEF integracaoLinxDTEF = new IntegracaoLinxDTEF();
      integracaoLinxDTEF.setGerenciadorSemTelas(this);

      integracaoLinxDTEF.ObtemLogUltimaTransacao(ref s);
      MessageBox.Show(s, "Resultado obtem log");
    }

    private void button1_Click(object sender, EventArgs e)
    {
      string sNormal = "";
      string sEstendido = "";
      IntegracaoLinxDTEF integracaoLinxDTEF = new IntegracaoLinxDTEF();
      integracaoLinxDTEF.setGerenciadorSemTelas(this);

      integracaoLinxDTEF.ObtemLogUltimaTransacao(ref sNormal, ref sEstendido);
      MessageBox.Show(sNormal, "Resultado obtem log");
      MessageBox.Show(sEstendido, "Resultado obtem log Estendido");
    }
  }

  public enum ModoOperacao
  {
    MODO_DEFAULT = 0,
    MODO_ENTRA_VALOR = 1,
    MODO_ENTRA_CARTAO = 2,
    MODO_ENTRA_DATAVALIDADE = 3,
    MODO_ENTRA_DATA = 4,
    MODO_ENTRA_CODIGO_SEGURANCA = 5,
    MODO_SELECIONA_OPCAO = 6,
    MODO_ENTRA_NUMERO = 7,
    MODO_ENTRA_STRING = 8,
    MODO_VAZIO = 9,
    MODO_ENTRA_VALOR_ESPECIAL = 10
  }
}
