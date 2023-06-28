using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace LinxDTEF
{
  public partial class InterfaceExemplo : Form, IGerenciadorSemTelas
  {

    public string displayErro;
    
    public InterfaceExemplo()
    {
      InitializeComponent();
    }
	  public void DisplayTerminal(string mensagem)
    {
        lblDisplayTerminal.Text = mensagem;
    }
    public void DisplayErro(string mensagem)
    {
      lblDisplayErro.Text = mensagem;
       displayErro = mensagem;
    }
    public void Mensagem(string mensagem)
    {       
        mensagem = "";
        return;
    }
    public void Beep()
    {

    }
    public int SolicitaConfirmacao(string mensagem)
    {
        return 0;
    }
    public int EntraCartao(string label, out string numeroCartao)
    {
        DialogoTransacao d = new DialogoTransacao(1, label);
        d.lblDisplayTerminal.Text = displayErro;
        d.ShowDialog();
        numeroCartao = d.boxValor.Text;
        return 0;
    }
    public int EntraDataValidade(string label, out string dataValidade)
    {
        DialogoTransacao d = new DialogoTransacao(2, label);
        d.lblDisplayTerminal.Text = displayErro;
        d.ShowDialog();
        dataValidade = d.boxValor.Text;
        return 0;
    }
    public int EntraData(string label, out string dataValidade)
    {
        DialogoTransacao d = new DialogoTransacao(2, label);
        d.lblDisplayTerminal.Text = displayErro;
        d.ShowDialog();
        dataValidade = d.boxValor.Text;
        return 0;
    }
    public int EntraCodigoSeguranca(string label, out string EntraCodigoSeguranca, int tamanhoMax)
    {
        EntraCodigoSeguranca = Interaction.InputBox("Insira o código de segurança", "EntraCodigoSeguranca", "");
        return 0;
    }
    public int SelecionaOpcao(string label, string opcoes, out int opcaoSelecionada)
    {
        opcaoSelecionada = 1;
        return 0;
    }
    public int EntraValor(string label, out Decimal valor, Decimal valorMinimo, Decimal valorMaximo)
    {
        valor = 0;
        DialogoTransacao d = new DialogoTransacao();
        d.lblDisplayTerminal.Text = displayErro;
        d.ShowDialog();
        string input = d.boxValor.Text;
        int vlrConv = 0;
         bool validaOp = int.TryParse(input, out vlrConv);
      
        if (!input.Equals(""))
        {
          if (vlrConv > 0 || vlrConv > valorMaximo || !validaOp)
          {
            Decimal vlrConvertido = Convert.ToDecimal(input);
            valor = vlrConvertido;
            return 0;
          }
        }
        return -1;
    } 
    public int EntraNumero(string label, out string numero, int numeroMinimo, int numeroMaximo, int minDigitos, int digitosExatos)
    {
        numero = Interaction.InputBox("Insira o numero", " EntraNumero", "");
        return 0;
    }
    public int OperacaoCancelada()
    {
        return 0;
    }
    public int SetaOperacaoCancelada(bool cancelada)
    {
        return 0;
    }
    public void ProcesaMensagens()
    {
        Application.DoEvents();
    }
    public int EntraString(string label, out string sString, string tamanhoMaximo)
    {
        sString = "";
        string input = Interaction.InputBox("Digite a string", "EntraString", null);
        if (input != null)
          sString = input;
        return 0;
    }
    public int ConsultaAVS(out string endereco, out string numero, out string apto, out string bloco, out string CEP, out string bairro, out string CPF)
    {
        ConsultaAVS AVSForm = new ConsultaAVS();
        AVSForm.ShowDialog();
        endereco = AVSForm.boxEndereco.Text;
        numero = AVSForm.boxNumero.Text;
        apto = AVSForm.boxApartamento.Text;
        bloco = AVSForm.boxBloco.Text;
        CEP = AVSForm.boxBloco.Text;
        bairro = AVSForm.boxBairro.Text;
        CPF = AVSForm.boxCPF.Text;
        return 0;
    }
    public int MensagemAdicional(string mensagemAdicional)
    {
        return 0;
    }

    public int DadosHistorico(string parte1, int tamParte1, string parte2, int tamParte2)
    {
        return 0;
    }

    public int ImagemAdicional(int indiceImagem)
    {
        return 0;
    }
    
    public int EntraCodigoBarras(string label, string Campo)
    {
        return 0;
    }
    public int EntraCodigoBarrasLido(string label, string Campo)
    {
        return 0;
    }
    public void MensagemAlerta(string mensagemAlerta)
    {
        MessageBox.Show(mensagemAlerta, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public void PreviewComprovante(string comprovante)
    {
    
    }
    public int SelecionaPlanos(int codigoRede, int codigoTransacao, int tipoFinanciamento, int maximoParcelas, out Decimal valorMinimoParcela, out int maxDiasPreDatado,
     out string numeroParcelas, out Decimal ValorTransacao, out Decimal valorParcela, out Decimal valorEntrada, out string Data)
    {
        SelecionaPlanos formSelecionaPlanos = new SelecionaPlanos();
        formSelecionaPlanos.ShowDialog();
        ValorTransacao = Convert.ToDecimal(formSelecionaPlanos.boxValorTrans.Text);
        valorEntrada = Convert.ToDecimal(formSelecionaPlanos.boxValorEntrada.Text);
        valorMinimoParcela = Convert.ToDecimal(formSelecionaPlanos.boxValorMinParcela.Text);
        maxDiasPreDatado = Convert.ToInt32(formSelecionaPlanos.boxMaxDiasPreDatado.Text);
        numeroParcelas = formSelecionaPlanos.boxNumeroParcelas.Text;
        valorParcela = Convert.ToInt32(formSelecionaPlanos.boxValorParcela.Text);
        Data = formSelecionaPlanos.boxData.Text;
      
        return 0;
    }

    public int SelecionaPlanosEx(string solicitacao, out string retorno)
    {
        retorno="";
        return 0;
    }

    private void btCartaoCredito_Click(object sender, EventArgs e)
    {
        int numeroControle;
        Decimal valorTransacao = 100.0M;
        int numeroCupom = 0;
        IntegracaoLinxDTEF integracaoLinxDTEF = new IntegracaoLinxDTEF();
        integracaoLinxDTEF.setGerenciadorSemTelas(this);

        int resultado = integracaoLinxDTEF.TransacaoCartaoCredito(valorTransacao, numeroCupom, out numeroControle);
        if (resultado == 0)
          MessageBox.Show("Transação concluída com sucesso. Número controle (NSU D-TEF) = " + numeroControle, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        else
          MessageBox.Show("Erro ao executar transação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void InterfaceExemplo_Load(object sender, EventArgs e)
    {
      this.CenterToScreen();
    }

    private void btConsultaAVS_Click(object sender, EventArgs e)
    {
      int numeroControle;
      IntegracaoLinxDTEF integracaoLinxDTEF = new IntegracaoLinxDTEF();
      integracaoLinxDTEF.setGerenciadorSemTelas(this);

      int resultado = integracaoLinxDTEF.TransacaoConsultaAVS(out numeroControle);
      if (resultado == 0)
        MessageBox.Show("Transação concluída com sucesso. Número controle (NSU D-TEF) = " + numeroControle, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
      else
        MessageBox.Show("Erro ao executar transação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void btCartaoDebito_Click(object sender, EventArgs e)
    {
      int numeroControle;
      Decimal valorTransacao = 100.0M;
      int numeroCupom = 0;
      IntegracaoLinxDTEF integracaoLinxDTEF = new IntegracaoLinxDTEF();
      //integracaoLinxDTEF.setGerenciadorSemTelas(this);

      int resultado = integracaoLinxDTEF.TransacaoCartaoDebito(valorTransacao, numeroCupom, out numeroControle);
      if (resultado == 0)
        MessageBox.Show("Transação concluída com sucesso. Número controle (NSU D-TEF) = " + numeroControle, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
      else
        MessageBox.Show("Erro ao executar transação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void btCartaoVoucher_Click(object sender, EventArgs e)
    {
      int numeroControle;
      Decimal valorTransacao = 100.0M;
      int numeroCupom = 0;
      IntegracaoLinxDTEF integracaoLinxDTEF = new IntegracaoLinxDTEF();
      //integracaoLinxDTEF.setGerenciadorSemTelas(this);

      int resultado = integracaoLinxDTEF.TransacaoCartaoVoucher(valorTransacao, numeroCupom, out numeroControle);
      if (resultado == 0)
        MessageBox.Show("Transação concluída com sucesso. Número controle (NSU D-TEF) = " + numeroControle, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
      else
        MessageBox.Show("Erro ao executar transação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
  }
}
