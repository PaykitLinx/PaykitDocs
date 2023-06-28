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
  public partial class TelaExemplo : Form, IGerenciadorSemTelas
  {
    /*
       * A Implementação Abaixo da Interface IGerenciarSemTelas tem o objetivo de exemplificar
       * o modo de implementação do mesmo. Suas telas de Input devem ser substituídas pelas da
       * própria aplicação o qual está se integrando.   
    */

    public TelaExemplo()
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
      DialogResult dialogResult = MessageBox.Show(mensagem, "Solicita Confirmação", MessageBoxButtons.YesNo);
      if (dialogResult == DialogResult.Yes)
      {
        return 0;
      }

      return -1;
    }
    public int EntraCartao(string label, out string numeroCartao)
    {
      numeroCartao = Interaction.InputBox("Insira o numero do cartao", " EntraCartao", "");
      if (numeroCartao == "")
        return -1;
      return 0;
    }
    public int EntraDataValidade(string label, out string dataValidade)
    {
      dataValidade = Interaction.InputBox("Insira a data", " EntraDataValidade", "");
      if (dataValidade == "")
        return -1;
      return 0;
    }
    public int EntraData(string label, out string dataValidade)
    {
      dataValidade = Interaction.InputBox("Insira a data", " EntraData", "");
      if (dataValidade == "")
        return -1;
      return 0;
    }
    public int EntraCodigoSeguranca(string label, out string EntraCodigoSeguranca, int tamanhoMax)
    {
      EntraCodigoSeguranca = Interaction.InputBox("Insira o código de segurança", "EntraCodigoSeguranca", "");
      if (EntraCodigoSeguranca == "")
        return -1;
      return 0;
    }
    public int SelecionaOpcao(string label, string opcoes, out int opcaoSelecionada)
    {
      opcaoSelecionada = -1;
      string selecionada = Interaction.InputBox(opcoes, label, "");
      if (selecionada != "" && int.TryParse(selecionada, out opcaoSelecionada))
        return 0;
      return -1;
    }
    public int EntraValor(string label, out Decimal valor, Decimal valorMinimo, Decimal valorMaximo)
    {
      valor = 0;
      string input = Interaction.InputBox("Digite o valor", "valor", null);
      int vlrConv;
      bool validaOp = int.TryParse(input, out vlrConv);

      if (input != null && input != "" && vlrConv > 0)
      {
        if (vlrConv < valorMaximo && validaOp)
        {
          Decimal vlrConvertido = Convert.ToDecimal(input);
          valor = vlrConvertido;
          return 0;
        }
      }
      return -1;
    }
    public int EntraNumero(string label, out string numero, int numeroMinimo, int numeroMaximo, int minDigitos, int maximoDigitos, int digitosExatos)
    {
      numero = Interaction.InputBox(label, " EntraNumero", "");
      if (numero == "")
        return -1;
      return 0;
    }

    //Deverá ser retornado a indicação se o operador cancelou a operação de TEF ou não, 0 = Op. não Cancelada, 1 = Op. Cancelada
    public int OperacaoCancelada()
    {
      return 0;
    }

    //Esta função inicializa a variavel que controla se a operação foi cancelada
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
      endereco = Interaction.InputBox("Insira o endereço (passo 1/7)", "ConsultaAVS", "");
      numero = Interaction.InputBox("Insira o numero (passo 2/7)", "ConsultaAVS", "");
      apto = Interaction.InputBox("Insira o apto (passo 3/7)", "ConsultaAVS", "");
      bloco = Interaction.InputBox("Insira o bloco (passo 4/7)", "ConsultaAVS", ""); ;
      CEP = Interaction.InputBox("Insira o CEP (passo 5/7)", " ConsultaAVS", "");
      bairro = Interaction.InputBox("Insira o bairro (passo 6/7)", "ConsultaAVS", "");
      CPF = Interaction.InputBox("Insira o CPF (passo 7/7)", "ConsultaAVS", "");

      if (endereco == "" || numero == "" || bairro == "" || CPF == "" || CEP == "")
        return -1;

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

    public int EntraCodigoBarras(string label, out string campo)
    {
      campo = Interaction.InputBox(label, "EntraCodigoBarrasLido", "");
      if (campo == "")
        return -1;
      return 0;
    }

    public int EntraCodigoBarrasLido(string label, out string campo)
    {
      campo = Interaction.InputBox(label, "EntraCodigoBarrasLido", "");
      if (campo == "")
        return -1;

      return 0;
    }

    public void MensagemAlerta(string mensagemAlerta)
    {
      MessageBox.Show(mensagemAlerta, "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    public void PreviewComprovante(string comprovante)
    {

    }

    public int SelecionaPlanos(int codigoRede, int codigoTransacao, int tipoFinanciamento, int maximoParcelas, Decimal valorMinimoParcela, int maxDiasPreDatado,
     out string numeroParcelas, out Decimal ValorTransacao, out Decimal valorParcela, out Decimal valorEntrada, out string Data)
    {
      numeroParcelas = "";
      ValorTransacao = 0;
      valorParcela = 0;
      valorEntrada = 0;
      Data = "";

      try
      {
        SelecionaPlanos formSelecionaPlanos = new SelecionaPlanos();
        formSelecionaPlanos.lblValorMinParcela.Text += " " + valorMinimoParcela;
        formSelecionaPlanos.lblMaxDias.Text += " " + maxDiasPreDatado.ToString();
        formSelecionaPlanos.lblMaxParcelas.Text += " " + maximoParcelas.ToString();
        formSelecionaPlanos.ShowDialog();
        if (formSelecionaPlanos.status == -2)
          return -2;
        ValorTransacao = Convert.ToDecimal(formSelecionaPlanos.boxValorTrans.Text);
        valorEntrada = Convert.ToDecimal(formSelecionaPlanos.boxValorEntrada.Text);
        numeroParcelas = formSelecionaPlanos.boxNumeroParcelas.Text;
        valorParcela = Convert.ToInt32(formSelecionaPlanos.boxValorParcela.Text);
        Data = formSelecionaPlanos.boxData.Text;
        formSelecionaPlanos.Dispose();

        return 0;
      }
      catch (Exception e)
      {
        return -1;
      }

    }

    public int SelecionaPlanosEx(string solicitacao, out string retorno)
    {
      retorno = Interaction.InputBox("Insira os dados", "Seleciona Planos Ex", "");
      if (retorno == "")
        return -1;
      return 0;
    }

    private void button1_Click(object sender, EventArgs e)
    {
      int numeroControle;
      Decimal valorTransacao = 100.0M;
      int numeroCupom = 0;
      IntegracaoLinxDTEF integracaoLinxDTEF = new IntegracaoLinxDTEF();
      integracaoLinxDTEF.setGerenciadorSemTelas(this);

      int resultado = integracaoLinxDTEF.TransacaoCartaoCredito(valorTransacao, numeroCupom, out numeroControle);
      if (resultado == 0)
      {
        MessageBox.Show("Transação concluída com sucesso. Número controle (NSU D-TEF) = " + numeroControle, "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        integracaoLinxDTEF.ConfirmaCartao(numeroControle);
      }
      else
        MessageBox.Show("Erro ao executar transação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

      integracaoLinxDTEF.FinalizaTransacao();
    }
  }
}
