using System;
using System.Runtime.InteropServices;
using System.Text;

namespace LinxDTEF
{
  public interface IGerenciadorSemTelas
  {
    void DisplayTerminal(string sMensagem);
    void DisplayErro(string sMensagem);
    void Mensagem(string sMensagem);
    void Beep();
    int SolicitaConfirmacao(string sMensagem);
    int EntraCartao(string sLabel, ref string sNumeroCartao);
    int EntraDataValidade(string sLabel, ref string sDataValidade);
    int EntraData(string sLabel, ref string sDataValidade);
    int EntraCodigoSeguranca(string sLabel, ref string sEntraCodigoSeguranca, int iTamanhoMax);
    int SelecionaOpcao(string sLabel, string sOpcoes, ref int iOpcaoSelecionada);
    int EntraValor(string sLabel, ref Decimal dValor, Decimal dValorMinimo, Decimal dValorMaximo);
    int EntraValorEspecial(string sLabel, ref Decimal dValor, Decimal dValorMinimo, Decimal dValorMaximo, int iCasasDecimaisEntraValor);
    int EntraNumero(string sLabel, ref string sNumero, int iNumeroMinimo, int iNumeroMaximo, int iMinDigitos, int iMaxDigitos, int iDigitosExatos);
    int OperacaoCancelada();
    int SetaOperacaoCancelada(bool bCancelada);
    void ProcessaMensagens();
    int EntraString(string sLabel, ref string sString, string sTamanhoMaximo);
    int ConsultaAVS(ref string sEndereco, ref string sNumero, ref string sApto, ref string sBloco, ref string sCEP, ref string sBairro, ref string sCPF);
    int MensagemAdicional(string sMensagemAdicional);
    int DadosHistorico(string sParte1, int iTamParte1, string sParte2, int iTamParte2);
    int ImagemAdicional(int iIndiceImagem);
    int EntraCodigoBarras(string sLabel, ref string sCampo);
    int EntraCodigoBarrasLido(string sLabel, ref string sCampo);
    void MensagemAlerta(string sMensagemAlerta);
    void PreviewComprovante(string sComprovante);
    int SelecionaPlanos(int iCodigoRede, int iCodigoTransacao, int iTipoFinanciamento, int iMaximoParcelas, Decimal dValorMinimoParcela, int iMaxDiasPreDatado,
      ref int iNumeroParcelas, ref Decimal dValorTransacao, ref Decimal dValorParcela, ref Decimal dValorEntrada, ref string sData);
    int SelecionaPlanosEx(string sSolicitacao, ref string sRetorno);
  }

  public class IntegracaoLinxDTEF
  {
    #region kernel32
    [DllImport("kernel32")]
    public static extern IntPtr LoadLibrary(string pFilename);

    [DllImport("kernel32")]
    public static extern IntPtr FreeLibrary(IntPtr pDll);

    [DllImport("kernel32")]
    public static extern IntPtr GetProcAddress(IntPtr pDll, string pFunction);
    #endregion

    #region Delegates das funções do D-POS
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _VersaoDPOS(StringBuilder versao);
    private _VersaoDPOS dllVersaoDPOS;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoFrota(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoCartaoFrota dllTransacaoCartaoFrota;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaCartaoFrota(StringBuilder numeroControle);
    private _ConfirmaCartaoFrota dllConfirmaCartaoFrota;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoFrotaCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder tipoProduto, StringBuilder codigoVeiculo, StringBuilder codigoCondutor, StringBuilder kilometragem, StringBuilder dadosServicos,
    StringBuilder permiteAlteracao, StringBuilder reservado);
    private _TransacaoCartaoFrotaCompleta dllTransacaoCartaoFrotaCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoCredito(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoCartaoCredito dllTransacaoCartaoCredito;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoDebito(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoCartaoDebito dllTransacaoCartaoDebito;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoParceleMais(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder codigoTabela);
    private _TransacaoCartaoParceleMais dllTransacaoCartaoParceleMais;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoParceleMaisCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder codigoTabela, StringBuilder numeroParcelas, StringBuilder valorParcela, StringBuilder vencimentoPrimeiraParcela, StringBuilder permiteAlteracao);
    private _TransacaoCartaoParceleMaisCompleta dllTransacaoCartaoParceleMaisCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoVoucher(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoCartaoVoucher dllTransacaoCartaoVoucher;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCheque(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder quantidadeDeCheques,
    StringBuilder periodicidadeDeCheques, StringBuilder dataPrimeiroCheque, StringBuilder carenciaPrimeiroCheque);
    private _TransacaoCheque dllTransacaoCheque;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCelular(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoCelular dllTransacaoCelular;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoCelular(StringBuilder numeroControle);
    private _TransacaoCancelamentoCelular dllTransacaoCancelamentoCelular;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoGarantiaCheque(StringBuilder valorTransacao, StringBuilder numeroControle);
    private _TransacaoCancelamentoGarantiaCheque dllTransacaoCancelamentoGarantiaCheque;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoPagamento(StringBuilder numeroControle);
    private _TransacaoCancelamentoPagamento dllTransacaoCancelamentoPagamento;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _EstornoPreAutorizacaoRedecard(StringBuilder numeroControle);
    private _EstornoPreAutorizacaoRedecard dllEstornoPreAutorizacaoRedecard;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConfirmacaoPreAutorizacao(StringBuilder numeroControle);
    private _TransacaoConfirmacaoPreAutorizacao dllTransacaoConfirmacaoPreAutorizacao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoPagamentoCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder permiteAlteracao, byte[] reservado);
    private _TransacaoCancelamentoPagamentoCompleta dllTransacaoCancelamentoPagamentoCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaCartaoCredito(StringBuilder numeroControle);
    private _ConfirmaCartaoCredito dllConfirmaCartaoCredito;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaCartaoDebito(StringBuilder numeroControle);
    private _ConfirmaCartaoDebito dllConfirmaCartaoDebito;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaCartaoVoucher(StringBuilder numeroControle);
    private _ConfirmaCartaoVoucher dllConfirmaCartaoVoucher;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaDebitoBeneficiario(StringBuilder numeroControle);
    private _ConfirmaDebitoBeneficiario dllConfirmaDebitoBeneficiario;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaCartao(StringBuilder numeroControle);
    private _ConfirmaCartao dllConfirmaCartao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _DesfazCartao(StringBuilder numeroControle);
    private _DesfazCartao dllDesfazCartao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _FinalizaTransacao();
    private _FinalizaTransacao dllFinalizaTransacao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaParcelas(StringBuilder numeroControle);
    private _TransacaoConsultaParcelas dllTransacaoConsultaParcelas;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaParcelasCredito(StringBuilder numeroControle);
    private _TransacaoConsultaParcelasCredito dllTransacaoConsultaParcelasCredito;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaParcelasCelular(StringBuilder numeroControle);
    private _TransacaoConsultaParcelasCelular dllTransacaoConsultaParcelasCelular;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPreAutorizacao(StringBuilder numeroControle);
    private _TransacaoPreAutorizacao dllTransacaoPreAutorizacao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPreAutorizacaoCartaoCredito(StringBuilder numeroControle);
    private _TransacaoPreAutorizacaoCartaoCredito dllTransacaoPreAutorizacaoCartaoCredito;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPreAutorizacaoCartaoFrota(StringBuilder numeroControle);
    private _TransacaoPreAutorizacaoCartaoFrota dllTransacaoPreAutorizacaoCartaoFrota;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoFuncaoEspecial();
    private _TransacaoFuncaoEspecial dllTransacaoFuncaoEspecial;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoResumoVendas(StringBuilder numeroControle);
    private _TransacaoResumoVendas dllTransacaoResumoVendas;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _ObtemCodigoRetorno(StringBuilder iCodigoRetorno, byte[] pCodigoRetorno);
    private _ObtemCodigoRetorno dllObtemCodigoRetorno;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _ObtemLogUltimaTransacao(byte[] logUltimaTransacao);
    private _ObtemLogUltimaTransacao dllObtemLogUltimaTransacao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _ObtemLogUltimaTransacaoTeleMarketing(int numeroPDV, byte[] logUltimaTransacao);
    private _ObtemLogUltimaTransacaoTeleMarketing dllObtemLogUltimaTransacaoTeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _ObtemLogUltimaTransacaoTeleMarketingMultiLoja(StringBuilder numeroEmpresa, StringBuilder numeroLoja, StringBuilder numeroPDV, byte[] logUltimaTransacao);
    private _ObtemLogUltimaTransacaoTeleMarketingMultiLoja dllObtemLogUltimaTransacaoTeleMarketingMultiLoja;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _ObtemComprovanteTransacao(StringBuilder numeroControle, byte[] comprovante, byte[] comprovanteReduzido);
    private _ObtemComprovanteTransacao dllObtemComprovanteTransacao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _DadosUltimaTransacaoDiscada(byte[] dadosUltimaTransacaoDiscada);
    private _DadosUltimaTransacaoDiscada dllDadosUltimaTransacaoDiscada;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _DadosUltimaTransacaoCB(byte[] logTitulo);
    private _DadosUltimaTransacaoCB dllDadosUltimaTransacaoCB;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoCreditoCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder pTipoOperacao, StringBuilder numeroParcelas, StringBuilder valorParcela, StringBuilder valorTaxaServico, StringBuilder permiteAlteracao,
    byte[] reservado);
    private _TransacaoCartaoCreditoCompleta dllTransacaoCartaoCreditoCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoDebitoCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder tipoOperacao,
    StringBuilder numeroParcelas, StringBuilder sequenciaParcela, StringBuilder dataDebito, StringBuilder valorParcela,
    StringBuilder valorTaxaServico, StringBuilder permiteAlteracao, byte[] reservado);
    private _TransacaoCartaoDebitoCompleta dllTransacaoCartaoDebitoCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoVoucherCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle, byte[] reservado);
    private _TransacaoCartaoVoucherCompleta dllTransacaoCartaoVoucherCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoChequeCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder quantidadeCheques,
    StringBuilder periodicidadeCheques, StringBuilder dataPrimeiroCheque, StringBuilder carenciaPrimeiroCheque, StringBuilder tipoDocumento,
    StringBuilder numeroDocumento, StringBuilder quantidadeChequesEx, StringBuilder pSequenciaCheque, StringBuilder camaraCompensacao,
    StringBuilder numeroBanco, StringBuilder numeroAgencia, StringBuilder numeroContaCorrente, StringBuilder numeroCheque, StringBuilder dataDeposito,
    StringBuilder valorCheque, StringBuilder dataNascimentoCliente, StringBuilder telefoneCliente, StringBuilder cMC7, StringBuilder permiteAlteracao,
    byte[] reservado);
    private _TransacaoChequeCompleta dllTransacaoChequeCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoPrivateLabelCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder tipoOperacao, StringBuilder numeroParcelas, StringBuilder valorEntrada, StringBuilder valorTaxaServico, StringBuilder permiteAlteracao,
    byte[] reservado);
    private _TransacaoCartaoPrivateLabelCompleta dllTransacaoCartaoPrivateLabelCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSimulacaoPrivateLabel(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoSimulacaoPrivateLabel dllTransacaoSimulacaoPrivateLabel;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaPrivateLabel(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoConsultaPrivateLabel dllTransacaoConsultaPrivateLabel;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPagamentoPrivateLabel(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoPagamentoPrivateLabel dllTransacaoPagamentoPrivateLabel;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoDebitoBeneficiario(StringBuilder valorTransacao, StringBuilder tipoBeneficio, StringBuilder numeroBeneficio,
    StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoDebitoBeneficiario dllTransacaoDebitoBeneficiario;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ObtemInfTransacaoDebitoParcelado(byte[] dadosParcelas);
    private _ObtemInfTransacaoDebitoParcelado dllObtemInfTransacaoDebitoParcelado;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaParametrosCB(byte[] parametros);
    private _ConsultaParametrosCB dllConsultaParametrosCB;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaPagamentoCB(StringBuilder tipoConta, StringBuilder codigoBarrasDigitado, StringBuilder codigoBarrasLido,
    StringBuilder valorTitulo, StringBuilder valorDesconto, StringBuilder valorAcrescimo, StringBuilder dataVencimento, StringBuilder formaDePagamento,
    StringBuilder trilhaDoCartao, StringBuilder tipoSenha, StringBuilder senha, StringBuilder NSUcartao, StringBuilder tipoCMC7, StringBuilder numeroControle,
    byte[] mensagemTEF, byte[] imprimeComprovante, byte[] parametros, byte[] parametros2);
    private _ConsultaPagamentoCB dllConsultaPagamentoCB;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPagamentoCB(StringBuilder tipoConta, StringBuilder codigoBarrasDigitado, StringBuilder codigoBarrasLido,
    StringBuilder valorTitulo, StringBuilder valorDesconto, StringBuilder valorAcrescimo, StringBuilder dataVencimento, StringBuilder FormaPagamento, StringBuilder trilhaCartao,
    StringBuilder tipoSenha, StringBuilder NSUCartao, StringBuilder tipoCMC7, StringBuilder CMC7, StringBuilder parametros, StringBuilder parametros2,
    StringBuilder numeroControle);
    private _TransacaoPagamentoCB dllTransacaoPagamentoCB;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoCB(StringBuilder tipoConta, StringBuilder codigoBarrasDigitado, StringBuilder codigoBarrasLido,
    StringBuilder valorTitulo, StringBuilder NSUCartao, StringBuilder numeroControle);
    private _TransacaoCancelamentoCB dllTransacaoCancelamentoCB;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _InicializaSessaoCB(StringBuilder numeroControle);
    private _InicializaSessaoCB dllInicializaSessaoCB;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _FinalizaSessaoCB(StringBuilder numeroControle);
    private _FinalizaSessaoCB dllFinalizaSessaoCB;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoResumoRecebimentosCB(StringBuilder tipoRecebimento, StringBuilder numeroControle);
    private _TransacaoResumoRecebimentosCB dllTransacaoResumoRecebimentosCB;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _UltimaMensagemTEF(byte[] mensagem);
    private _UltimaMensagemTEF dllUltimaMensagemTEF;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoReimpressaoCupom();
    private _TransacaoReimpressaoCupom dllTransacaoReimpressaoCupom;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfiguraDPOS();
    private _ConfiguraDPOS dllConfiguraDPOS;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _InicializaDPOS();
    private _InicializaDPOS dllInicializaDPOS;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _FinalizaDPOS();
    private _FinalizaDPOS dllFinalizaDPOS;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoFechamento(StringBuilder dataMovimetno, StringBuilder quantidadeVendas, StringBuilder valorTotalVendas,
    StringBuilder quantidadeVendasCanceladas, StringBuilder valorTotalVendasCanceladas, byte[] reservado, StringBuilder numeroControle,
    byte[] mensagemOperador);
    private _TransacaoFechamento dllTransacaoFechamento;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ObtemUltimoErro(byte[] erro);
    private _ObtemUltimoErro dllObtemUltimoErro;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _DadosUltimaTransacaoNaoAprovada(byte[] dadosTransacaoNaoAprovada);
    private _DadosUltimaTransacaoNaoAprovada dllDadosUltimaTransacaoNaoAprovada;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoColeta(StringBuilder tipoCartao, StringBuilder valorTransacao, byte[] trilha1, byte[] trilha2,
    byte[] trilha3, StringBuilder parametros);
    private _TransacaoColeta dllTransacaoColeta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoColetaCartao(StringBuilder tipoCartao, byte[] trilha1, byte[] trilha2, byte[] trilha3);
    private _TransacaoColetaCartao dllTransacaoColetaCartao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoColetaSenha(StringBuilder valor, byte[] senha);
    private _TransacaoColetaSenha dllTransacaoColetaSenha;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoColetaSenhaCartao(StringBuilder tipoCartao, StringBuilder valor, byte[] trilha2, byte[] reservado, byte[] senha);
    private _TransacaoColetaSenhaCartao dllTransacaoColetaSenhaCartao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ColetaPlanoPagamento(StringBuilder descricaoFormaPagamento, StringBuilder valorTransacao, StringBuilder numeroCupom,
    StringBuilder tipoFormaPagamento, StringBuilder numeroControle, StringBuilder numeroParcelas, StringBuilder valorAcrescimo, StringBuilder valorEntrada,
    StringBuilder valorTotal, StringBuilder codigoPlano, StringBuilder plano, StringBuilder parcelas);
    private _ColetaPlanoPagamento dllColetaPlanoPagamento;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoAdministrativaTEFDiscado(StringBuilder numeroControle);
    private _TransacaoAdministrativaTEFDiscado dllTransacaoAdministrativaTEFDiscado;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ExportaPlanos();
    private _ExportaPlanos dllExportaPlanos;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ColetaChequesPre(byte[] descricaoPlanoPagamento, byte[] parcelas);
    private _ColetaChequesPre dllColetaChequesPre;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoQuantidade(StringBuilder valorTransacao, StringBuilder valorTransacaoMaximo, StringBuilder numeroCupom);
    private _TransacaoQuantidade dllTransacaoQuantidade;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoValor(StringBuilder valorTransacao, StringBuilder valorTransacaoMaximo, StringBuilder numeroCupom);
    private _TransacaoValor dllTransacaoValor;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoCreditoConfirmada(StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder valorTransacao,
    StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder numeroCartao, StringBuilder dataVencimento, StringBuilder CVV2, StringBuilder tipoOperacao,
    StringBuilder numeroParcelas, StringBuilder valorTaxaServico, byte[] mensagemTEF, byte[] reservado);
    private _TransacaoCartaoCreditoConfirmada dllTransacaoCartaoCreditoConfirmada;
    private IntPtr dllHandle;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoConfirmada(StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder valorTransacao,
    StringBuilder numeroControle, StringBuilder numeroCartao, byte[] mensagemTEF, byte[] reservado);
    private _TransacaoCancelamentoConfirmada dllTransacaoCancelamentoConfirmada;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _PreAutorizacaoCreditoConfirmada(StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder valorTransacao,
    StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder numeroCartao, StringBuilder dataVencimento, StringBuilder CVV2, StringBuilder valorTaxaServico,
    StringBuilder numeroAutorizacao, byte[] mensagemTEF, byte[] reservado);
    private _PreAutorizacaoCreditoConfirmada dllPreAutorizacaoCreditoConfirmada;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfPreAutorizacaoCreditoConfirmada(StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder valorTransacao,
    StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder dataPreAutor, StringBuilder numeroCartao, StringBuilder dataVencimento, StringBuilder CVV2,
    StringBuilder tipoOperacao, StringBuilder numeroParcelas, byte[] mensagemTEF, byte[] reservado);
    private _ConfPreAutorizacaoCreditoConfirmada dllConfPreAutorizacaoCreditoConfirmada;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoManualPOSCompleta(StringBuilder valorTransacao, StringBuilder codigoEstabelecimento, StringBuilder data,
    StringBuilder hora, StringBuilder numeroAutorizadora, StringBuilder numeroCartao, StringBuilder tipoOperacao, StringBuilder numeroParcelas,
    StringBuilder dataPreDatado, StringBuilder numeroControle);
    private _TransacaoManualPOSCompleta dllTransacaoManualPOSCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoFidelidade(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder compraPontos,
    StringBuilder quantidadeItensTaxaVariavel, StringBuilder itensTaxaVariavel, StringBuilder numeroControle);
    private _TransacaoCartaoFidelidade dllTransacaoCartaoFidelidade;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoDebitoFidelidade(StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoDebitoFidelidade dllTransacaoDebitoFidelidade;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ExtratoCartaoAutorizadorDirecao(StringBuilder numeroCartao, StringBuilder numeroControle);
    private _ExtratoCartaoAutorizadorDirecao dllExtratoCartaoAutorizadorDirecao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaCartaoFidelidade(StringBuilder numeroCupom);
    private _ConfirmaCartaoFidelidade dllConfirmaCartaoFidelidade;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _RecebimentoAutorizadorDirecao(StringBuilder valorTransacao, StringBuilder numeroCartao, StringBuilder numeroControle);
    private _RecebimentoAutorizadorDirecao dllRecebimentoAutorizadorDirecao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _EstornoRecebimentoAutorizadorDirecao(StringBuilder valorTransacao, StringBuilder numeroCartao, StringBuilder numeroControle);
    private _EstornoRecebimentoAutorizadorDirecao dllEstornoRecebimentoAutorizadorDirecao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _RecebimentoCarneAutorizadorDirecao(StringBuilder valorTransacao, StringBuilder numeroCartao, StringBuilder dataVencimento,
    StringBuilder numeroControle);
    private _RecebimentoCarneAutorizadorDirecao dllRecebimentoCarneAutorizadorDirecao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPagamentoConvenio(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoPagamentoConvenio dllTransacaoPagamentoConvenio;


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaConvenio(StringBuilder numeroCupom);
    private _ConfirmaConvenio dllConfirmaConvenio;


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSaqueRedecard(StringBuilder valorTransacao, StringBuilder numeroCupomFiscal, StringBuilder numeroControle);
    private _TransacaoSaqueRedecard dllTransacaoSaqueRedecard;


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSaque(StringBuilder valorTransacao, StringBuilder numeroCupomFiscal, StringBuilder numeroCupom);
    private _TransacaoSaque dllTransacaoSaque;


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCDC1MIN(StringBuilder valorTransacao, StringBuilder numeroCupomFiscal, StringBuilder numeroCupom);
    private _TransacaoCDC1MIN dllTransacaoCDC1MIN;


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSIMparcelado(StringBuilder valorTransacao, StringBuilder numeroCupomFiscal, StringBuilder numeroCupom);
    private _TransacaoSIMparcelado dllTransacaoSIMparcelado;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoCreditoIATA(StringBuilder valorTransacao, StringBuilder numeroCupomFiscal, StringBuilder numeroCupom);
    private _TransacaoCartaoCreditoIATA dllTransacaoCartaoCreditoIATA;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoCreditoIATAConfirmada(StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder valorTransacao,
    StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder numeroCartao, StringBuilder dataVencimento, StringBuilder CVV2, StringBuilder tipoOperacao,
    StringBuilder numeroParcelas, StringBuilder valorTaxaServico, StringBuilder valorEntrada, byte[] mensagemTEF, byte[] reservado);
    private _TransacaoCartaoCreditoIATAConfirmada dllTransacaoCartaoCreditoIATAConfirmada;


    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoPrivateLabel(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoCartaoPrivateLabel dllTransacaoCartaoPrivateLabel;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaSaldo(StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoConsultaSaldo dllTransacaoConsultaSaldo;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaSaldoCelular(StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoConsultaSaldoCelular dllTransacaoConsultaSaldoCelular;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaSaldoCompleta(StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder tipoCartao,
    StringBuilder permiteAlteracao, byte[] reservado);
    private _TransacaoConsultaSaldoCompleta dllTransacaoConsultaSaldoCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ColetaCartaoDebito(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder parametrosTEF, StringBuilder mensagemOperador);
    private _ColetaCartaoDebito dllColetaCartaoDebito;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsisteDadosCartaoDebito(StringBuilder ultimosDigitos, StringBuilder codigoSeguranca, byte[] mensagemOperador);
    private _ConsisteDadosCartaoDebito dllConsisteDadosCartaoDebito;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ColetaSenhaCartaoDebito(StringBuilder numeroControle, byte[] mensagemOperador);
    private _ColetaSenhaCartaoDebito dllColetaSenhaCartaoDebito;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaParametrosPBM(StringBuilder numeroCupom, byte[] quantidadeRedes, byte[] dadosRedes, byte[] mensagemOperador);
    private _ConsultaParametrosPBM dllConsultaParametrosPBM;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaProdutosPBM(StringBuilder numeroCupom, StringBuilder redePBM, StringBuilder trilha1, StringBuilder trilha2,
    StringBuilder digitado, StringBuilder autorizacao, byte[] dadosCRM, int tipoVenda, byte[] valorTotalMedicamentos,
    byte[] valorVista, byte[] valorCartao, byte[] codigoCredenciado, byte[] quantidadeMedicamentos, byte[] medicamentos,
    byte[] reservado, StringBuilder numeroControle, byte[] mensagemOperador);
    private _ConsultaProdutosPBM dllConsultaProdutosPBM;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoVendaPBM(StringBuilder valorTotalMedicamentos, StringBuilder numeroCupom, StringBuilder redePBM, StringBuilder trilha1,
    StringBuilder trilha2, StringBuilder digitado, StringBuilder autorizacao, StringBuilder nSUConsulta, StringBuilder dadosCRM, StringBuilder tipoVenda,
    StringBuilder valorVista, StringBuilder valorCartao, StringBuilder codigoCredenciado, StringBuilder regraNegocio, byte[] quantidadeMedicamentos,
    byte[] medicamentos, byte[] reservado, StringBuilder numeroControle, StringBuilder numeroControleRede, byte[] mensagemOperador);
    private _TransacaoVendaPBM dllTransacaoVendaPBM;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaVendaPBM(StringBuilder numeroControle);
    private _ConfirmaVendaPBM dllConfirmaVendaPBM;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoReimpressaoVendaPBM();
    private _TransacaoReimpressaoVendaPBM dllTransacaoReimpressaoVendaPBM;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoVendaPBM(StringBuilder numeroControle);
    private _TransacaoCancelamentoVendaPBM dllTransacaoCancelamentoVendaPBM;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoPreAutorizacaoPBM(StringBuilder numeroControle);
    private _TransacaoCancelamentoPreAutorizacaoPBM dllTransacaoCancelamentoPreAutorizacaoPBM;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoElegibilidadePBM(StringBuilder numeroCupom, StringBuilder redePBM, StringBuilder matricula, StringBuilder dadosElegibilidade,
    StringBuilder numeroControle, byte[] numeroControleRede, byte[] nomeCliente, byte[] nomeMedico, byte[] InformaDependente,
    byte[] listaDependentes, byte[] reservado, byte[] mensagemOperador);
    private _TransacaoElegibilidadePBM dllTransacaoElegibilidadePBM;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPreAutorizacaoPBM(StringBuilder numeroCupom, StringBuilder redePBM, StringBuilder autorizacaoElegibilidade,
    StringBuilder dadosFarmaceutico, byte[] quantidadeMedicamentos, byte[] medicamentos, StringBuilder numeroControle, byte[] numeroControleRede,
    byte[] reservado, byte[] mensagemOperador);
    private _TransacaoPreAutorizacaoPBM dllTransacaoPreAutorizacaoPBM;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV,
    StringBuilder matricula, byte[] reservado, StringBuilder numeroControle, byte[] MensagemOperador);
    private _TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing dllTransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoElegibilidadePBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja,
    StringBuilder numeroPDV, StringBuilder numeroCupom, StringBuilder redePBM, StringBuilder Matricula, StringBuilder dadosElegibilidade, StringBuilder numeroControle,
    StringBuilder numeroControleRede, byte[] nomeCliente, byte[] nomeMedico, StringBuilder informaDependente, StringBuilder listaDependentes,
    byte[] reservado, byte[] mensagemOperador);
    private _TransacaoElegibilidadePBM_TeleMarketing dllTransacaoElegibilidadePBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPreAutorizacaoPBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV,
    StringBuilder numeroCupom, StringBuilder redePBM, StringBuilder autorizacaoElegibilidade, StringBuilder dadosFarmaceutico, byte[] quantidadeMedicamentos,
    byte[] medicamentos, StringBuilder numeroControle, byte[] numeroControleRede, byte[] reservado, byte[] mensagemOperador);
    private _TransacaoPreAutorizacaoPBM_TeleMarketing dllTransacaoPreAutorizacaoPBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaParametrosPBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV,
    StringBuilder numeroCupom, byte[] quantidadeRedes, byte[] dadosRedes, byte[] mensagemOperador);
    private _ConsultaParametrosPBM_TeleMarketing dllConsultaParametrosPBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaProdutosPBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV,
    StringBuilder numeroCupom, StringBuilder redePBM, StringBuilder trilha1, StringBuilder trilha2, StringBuilder digitado, StringBuilder autorizacao,
    StringBuilder dadosCRM, byte[] tipoVenda, byte[] valorTotalMedicamentos, byte[] valorVista, byte[] valorCartao, byte[] codigoCredenciado, byte[] quantidadeMedicamentos,
    byte[] medicamentos, byte[] reservado, StringBuilder numeroControle, byte[] mensagemOperador);
    private _ConsultaProdutosPBM_TeleMarketing dllConsultaProdutosPBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoVendaPBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV,
    StringBuilder valorTotalMedicamentos, StringBuilder numeroCupom, StringBuilder redePBM, StringBuilder trilha1, StringBuilder trilha2, StringBuilder digitado,
    StringBuilder autorizacao, StringBuilder NSUConsulta, StringBuilder dadosCRM, StringBuilder tipoVenda, StringBuilder valorVista, StringBuilder valorCartao,
    StringBuilder codigoCredenciado, StringBuilder regraNegocio, byte[] quantidadeMedicamentos, byte[] medicamentos, byte[] reservado,
    StringBuilder numeroControle, byte[] numeroControleRede, byte[] mensagemOperador);
    private _TransacaoVendaPBM_TeleMarketing dllTransacaoVendaPBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoVendaPBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja,
    StringBuilder numeroPDV, StringBuilder trilha1, StringBuilder trilha2, StringBuilder digitado, byte[] reservado, StringBuilder numeroControle,
    byte[] mensagemOperador);
    private _TransacaoCancelamentoVendaPBM_TeleMarketing dllTransacaoCancelamentoVendaPBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoAberturaVendaPBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja,
    StringBuilder numeroPDV, StringBuilder redePBM, StringBuilder trilha1, StringBuilder trilha2, StringBuilder digitado, byte[] reservado,
    byte[] PedirDadosComplementares, byte[] dadosComplementares, byte[] infoDadosComplementares, byte[] mensagemOperador);
    private _TransacaoAberturaVendaPBM_TeleMarketing dllTransacaoAberturaVendaPBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoVendaProdutoPBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja,
    StringBuilder numeroPDV, StringBuilder redePBM, StringBuilder trilha1, StringBuilder trilha2, StringBuilder digitado, byte[] Medicamento,
    byte[] reservado, byte[] pedirDadosComplementares, StringBuilder dadosComplementares, byte[] infoDadosComplementares,
    byte[] mensagemOperador);
    private _TransacaoVendaProdutoPBM_TeleMarketing dllTransacaoVendaProdutoPBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoFechamentoVendaPBM_TeleMarketing(StringBuilder numeroEmpresa, StringBuilder multiLoja, StringBuilder numeroLoja,
    StringBuilder numeroPDV, StringBuilder redePBM, StringBuilder trilha1, StringBuilder trilha2, StringBuilder digitado, StringBuilder confirmacao,
    byte[] reservado, StringBuilder autorizacao, StringBuilder numeroControle, byte[] mensagemOperador);
    private _TransacaoFechamentoVendaPBM_TeleMarketing dllTransacaoFechamentoVendaPBM_TeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _InformaDadosMedicamentos(StringBuilder indicativoReceita, StringBuilder registroProfissional, StringBuilder listaMedicamentos);
    private _InformaDadosMedicamentos dllInformaDadosMedicamentos;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSaqueSaldo(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoSaqueSaldo dllTransacaoSaqueSaldo;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSaqueExtrato(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoSaqueExtrato dllTransacaoSaqueExtrato;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaAVS(StringBuilder numeroControle);
    private _TransacaoConsultaAVS dllTransacaoConsultaAVS;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaAVSConfirmada(StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder numeroCupom,
    StringBuilder numeroControle, StringBuilder numeroCartao, StringBuilder dataVencimento, StringBuilder CVV2, StringBuilder endereco, StringBuilder numero,
    StringBuilder apto, StringBuilder bloco, StringBuilder CEP, StringBuilder bairro, StringBuilder CPF, byte[] mensagemTEF, byte[] reservado);
    private _TransacaoConsultaAVSConfirmada dllTransacaoConsultaAVSConfirmada;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPagamentoContasVisanet(byte[] tipoConta, byte[] codigoBarras, byte[] formaPagamento,
    byte[] trilhaCartao, byte[] valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoPagamentoContasVisanet dllTransacaoPagamentoContasVisanet;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoEspecial(int codigoTransacao, byte[] dados);
    private _TransacaoEspecial dllTransacaoEspecial;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaValoresPrePago(StringBuilder numeroControle, byte[] mensagemOperador);
    private _ConsultaValoresPrePago dllConsultaValoresPrePago;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoRecargaCelular(StringBuilder codigoArea, StringBuilder numeroTelefone, StringBuilder numeroControle);
    private _TransacaoRecargaCelular dllTransacaoRecargaCelular;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaParametrosTeledata(byte[] dadosTeledata, byte[] mensagemOperador);
    private _ConsultaParametrosTeledata dllConsultaParametrosTeledata;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaChequesGarantidos(byte[] tipoDocumento, byte[] numeroDocumento, byte[] dataInicialConsulta,
    byte[] dataFinalConsulta, StringBuilder numeroControle);
    private _ConsultaChequesGarantidos dllConsultaChequesGarantidos;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSaqueCompleta(StringBuilder valorTransacao, StringBuilder numeroCupomFiscal, StringBuilder numeroControle,
    StringBuilder tipoTransacao, StringBuilder planoPagamento, StringBuilder numeroParcelas, StringBuilder permiteAlteracao, StringBuilder reservado);
    private _TransacaoSaqueCompleta dllTransacaoSaqueCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoCompraSaque(byte[] valorCompra, byte[] valorSaque, byte[] numeroCupom,
    StringBuilder numeroControle);
    private _TransacaoCartaoCompraSaque dllTransacaoCartaoCompraSaque;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoCompraSaqueCompleta(byte[] valorCompra, byte[] valorSaque, byte[] numeroCupom,
    StringBuilder numeroControle, StringBuilder permiteAlteracao);
    private _TransacaoCartaoCompraSaqueCompleta dllTransacaoCartaoCompraSaqueCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TesteRedeAtiva(StringBuilder numeroEmpresa, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder codigoRede,
    byte[] statusRede, byte[] mensagemOperador);
    private _TesteRedeAtiva dllTesteRedeAtiva;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCadastraSenha(StringBuilder numeroControle);
    private _TransacaoCadastraSenha dllTransacaoCadastraSenha;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfiguraFluxoExternoDTEF5();
    private _ConfiguraFluxoExternoDTEF5 dllConfiguraFluxoExternoDTEF5;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TrataDesfazimento(int tratar);
    private _TrataDesfazimento dllTrataDesfazimento;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaTransacao(StringBuilder numeroEmpresa, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder solicitacao,
    byte[] resposta, byte[] mensagemErro);
    private _ConsultaTransacao dllConsultaTransacao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoeValeGas(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder numeroValeGas);
    private _TransacaoeValeGas dllTransacaoeValeGas;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaeValeGas(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder numeroValeGas, byte[] dadosRetorno);
    private _TransacaoConsultaeValeGas dllTransacaoConsultaeValeGas;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCancelamentoPadrao(StringBuilder numeroControle);
    private _TransacaoCancelamentoPadrao dllTransacaoCancelamentoPadrao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfiguraModoTeleMarketing(StringBuilder modo);
    private _ConfiguraModoTeleMarketing dllConfiguraModoTeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfirmaCartaoTeleMarketing(StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder numeroControle,
    byte[] mensagemTEF, StringBuilder reservado);
    private _ConfirmaCartaoTeleMarketing dllConfirmaCartaoTeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _DesfazCartaoTeleMarketing(StringBuilder multiLoja, StringBuilder numeroLoja, StringBuilder numeroPDV, StringBuilder numeroControle,
    byte[] mensagemTEF, StringBuilder reservado);
    private _DesfazCartaoTeleMarketing dllDesfazCartaoTeleMarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoEstatistica(StringBuilder numeroControle);
    private _TransacaoEstatistica dllTransacaoEstatistica;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoInjecaoChaves(StringBuilder numeroControle);
    private _TransacaoInjecaoChaves dllTransacaoInjecaoChaves;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoTrocoSurpresa(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle, byte[] mensagemTEF,
    StringBuilder reservado);
    private _TransacaoTrocoSurpresa dllTransacaoTrocoSurpresa;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _IdentificacaoAutomacaoComercial(StringBuilder nomeAutomacao, StringBuilder versaoAutomacao, StringBuilder reservado);
    private _IdentificacaoAutomacaoComercial dllIdentificacaoAutomacaoComercial;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaTabelasValeGas(StringBuilder numeroControle, byte[] mensagemOperador);
    private _ConsultaTabelasValeGas dllConsultaTabelasValeGas;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _DefineBandeiraTransacao(StringBuilder codigoBandeira);
    private _DefineBandeiraTransacao dllDefineBandeiraTransacao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _DefineRedeTransacao(StringBuilder codigoRede);
    private _DefineRedeTransacao dllDefineRedeTransacao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoAbreLote(StringBuilder numeroCupom, StringBuilder numeroControle, byte[] MensagemTEF, byte[] reservado);
    private _TransacaoAbreLote dllTransacaoAbreLote;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoFechaLote(StringBuilder numeroCupom, StringBuilder numeroControle, byte[] mensagemTEF, byte[] reservado);
    private _TransacaoFechaLote dllTransacaoFechaLote;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConfiguraEmpresaLojaPDV(StringBuilder numeroEmpresa, StringBuilder numeroLoja, StringBuilder numeroPDV);
    private _ConfiguraEmpresaLojaPDV dllConfiguraEmpresaLojaPDV;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoResgatePremio(StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoResgatePremio dllTransacaoResgatePremio;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoVendaPOS(StringBuilder CNPJ, StringBuilder numeroSerie, StringBuilder codigoFrentista, StringBuilder CPFCNPJ,
    StringBuilder pagamentoTEF, StringBuilder cartaoProprio, StringBuilder valor, StringBuilder telefoneCliente, StringBuilder codigoOrigem,
    StringBuilder saldoPontos, StringBuilder codigoPesquisa, StringBuilder reservado, StringBuilder numeroControle);
    private _TransacaoVendaPOS dllTransacaoVendaPOS;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoEstornoVendaPOS(StringBuilder CNPJ, StringBuilder numeroSerie, StringBuilder codigoFrentista, StringBuilder CPFCNPJ,
    StringBuilder dataEstorno, StringBuilder NSUEstorno, StringBuilder autorizacaoEstorno, StringBuilder saldoPontos, StringBuilder numeroControle);
    private _TransacaoEstornoVendaPOS dllTransacaoEstornoVendaPOS;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _BuscaTabelaDTEF(int tipoTabela, StringBuilder numeroControle);
    private _BuscaTabelaDTEF dllBuscaTabelaDTEF;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoContratacao(StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoContratacao dllTransacaoContratacao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPrimeiraCompra(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoPrimeiraCompra dllTransacaoPrimeiraCompra;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCadastro(StringBuilder CNPJ, StringBuilder numeroSerie, StringBuilder codigoFrentista, StringBuilder CPFCNPJ,
    StringBuilder telefoneCliente, StringBuilder reservado, StringBuilder numeroControle);
    private _TransacaoCadastro dllTransacaoCadastro;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ProcuraPinPad(byte[] dados);
    private _ProcuraPinPad dllProcuraPinPad;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoFuncoesAdministrativas(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder reservado);
    private _TransacaoFuncoesAdministrativas dllTransacaoFuncoesAdministrativas;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoQuitacaoCartaFrete(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoQuitacaoCartaFrete dllTransacaoQuitacaoCartaFrete;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoQuitacaoCartaFreteCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder numeroCartaFrete, StringBuilder quantidadeChegada, StringBuilder permiteAlteracao, StringBuilder reservado);
    private _TransacaoQuitacaoCartaFreteCompleta dllTransacaoQuitacaoCartaFreteCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoCrediario(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoCartaoCrediario dllTransacaoCartaoCrediario;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSimulacaoCrediario(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoSimulacaoCrediario dllTransacaoSimulacaoCrediario;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoPagamentoPrivateLabelCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder indicadorDigitacao, StringBuilder codigoBarras, StringBuilder numeroCartao, StringBuilder codigoRede, StringBuilder permiteAlteracao,
    StringBuilder reservado);
    private _TransacaoPagamentoPrivateLabelCompleta dllTransacaoPagamentoPrivateLabelCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCargaCartao(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoCargaCartao dllTransacaoCargaCartao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoRecargaCartao(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoRecargaCartao dllTransacaoRecargaCartao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _CadastraPDVTelemarketing(StringBuilder numeroEmpresa, StringBuilder numeroLoja, StringBuilder numeroPDV, byte[] mensagemTEF);
    private _CadastraPDVTelemarketing dllCadastraPDVTelemarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoCartaoCrediarioCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder numeroParcelas, StringBuilder dataParcela1, StringBuilder valorParcela1, StringBuilder valorEntrada, StringBuilder permiteAlteracao,
    byte[] reservado);
    private _TransacaoCartaoCrediarioCompleta dllTransacaoCartaoCrediarioCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaPlanos(StringBuilder valorTransacao, StringBuilder numeroControle, StringBuilder reservado, StringBuilder planos);
    private _TransacaoConsultaPlanos dllTransacaoConsultaPlanos;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaCadastroPDV(byte[] Mensagem);
    private _ConsultaCadastroPDV dllConsultaCadastroPDV;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _ConsultaCadastroPDVTelemarketing(StringBuilder numeroEmpresa, StringBuilder numeroLoja, StringBuilder numeroPDV, byte[] mensagemTEF);
    private _ConsultaCadastroPDVTelemarketing dllConsultaCadastroPDVTelemarketing;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSimulacaoSaque(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoSimulacaoSaque dllTransacaoSimulacaoSaque;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoBloqueioCartao(StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoBloqueioCartao dllTransacaoBloqueioCartao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoDesbloqueioCartao(StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoDesbloqueioCartao dllTransacaoDesbloqueioCartao;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoConsultaCadastroCPFCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle,
    StringBuilder tipoOperacao, byte[] docEmissor, StringBuilder permiteAlteracao, StringBuilder reservado);
    private _TransacaoConsultaCadastroCPFCompleta dllTransacaoConsultaCadastroCPFCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoDepositoCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder tipoOperacao,
    byte[] docEmissor, byte[] docDestinatario, StringBuilder permiteAlteracao, StringBuilder reservado);
    private _TransacaoDepositoCompleta dllTransacaoDepositoCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoSaqueDomesticoCompleta(StringBuilder valorTransacao, StringBuilder numeroCupom, StringBuilder numeroControle, StringBuilder tipoOperacao,
    StringBuilder codigoPIN, StringBuilder docDestinatario, StringBuilder permiteAlteracao, StringBuilder reservado);
    private _TransacaoSaqueDomesticoCompleta dllTransacaoSaqueDomesticoCompleta;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _TransacaoAlteraSenhaUsuarioDTEF(StringBuilder numeroCupom, StringBuilder numeroControle);
    private _TransacaoAlteraSenhaUsuarioDTEF dllTransacaoAlteraSenhaUsuarioDTEF;

    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate int _DefineParametroTransacao(int codigoParametro, StringBuilder valorParametro, int tamanhoParametro);
    private _DefineParametroTransacao dllDefineParametroTransacao;
    #endregion

    #region Delegates das funções de CallBack

    //CallBack DisplayTerminal
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVDisplayTerminal(_CallBackPDVDisplayTerminal cbDisplayTerminal);
    private _RegPDVDisplayTerminal dllRegPDVDisplayTerminal;

    public delegate void _CallBackPDVDisplayTerminal(StringBuilder mensagem);
    GCHandle gcHandleDisplayTerminal;

    //CallBack DisplayErro
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVDisplayErro(_CallBackPDVDisplayErro cbDisplayErro);
    private _RegPDVDisplayErro dllRegPDVDisplayErro;

    public delegate void _CallBackPDVDisplayErro(StringBuilder mensagem);
    GCHandle gcHandleDisplayErro;

    //CallBack Mensagem
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVMensagem(_CallBackPDVMensagem cbPDVMensagem);
    private _RegPDVMensagem dllRegPDVMensagem;

    public delegate void _CallBackPDVMensagem(StringBuilder mensagem);
    GCHandle gcHandleMensagem;

    //CallBack Beep
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVBeep(_CallBackPDVBeep cbPDVBeep);
    private _RegPDVBeep dllRegPDVBeep;

    public delegate void _CallBackPDVBeep();
    GCHandle gcHandleBeep;

    //CallBack SolicitaConfirmacao
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVSolicitaConfirmacao(_CallBackPDVSolicitaConfirmacao cbSolicitaConfirmacao);
    private _RegPDVSolicitaConfirmacao dllRegPDVSolicitaConfirmacao;

    public delegate int _CallBackPDVSolicitaConfirmacao(StringBuilder mensagem);
    GCHandle gcHandleSolicitaConfirmacao;

    //CallBack EntraCartao
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraCartao(_CallBackEntraCartao cbEntraCartao);
    private _RegPDVEntraCartao dllRegPDVEntraCartao;

    public delegate int _CallBackEntraCartao(StringBuilder label, IntPtr cartao);
    GCHandle gcHandleEntraCartao;

    //CallBack EntraDataValidade
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraDataValidade(_CallBackPDVEntraDataValidade cbPDVEntraDataValidade);
    private _RegPDVEntraDataValidade dllRegPDVEntraDataValidade;

    public delegate int _CallBackPDVEntraDataValidade(StringBuilder label, IntPtr dataValidade);
    GCHandle gcHandleEntraDataValidade;

    //CallBack EntraData
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraData(_CallBackEntraData bcEntraData);
    private _RegPDVEntraData dllRegPDVEntraData;

    public delegate int _CallBackEntraData(StringBuilder label, IntPtr dataValidade);
    GCHandle gcHandleEntraData;

    //CallBack EntraCodigoSeguranca 
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraCodigoSeguranca(_CallBackPDVEntraCodigoSeguranca cbEntraCodigoSeguranca);
    private _RegPDVEntraCodigoSeguranca dllRegPDVEntraCodigoSeguranca;

    public delegate int _CallBackPDVEntraCodigoSeguranca(StringBuilder label, IntPtr entraCodigoSeguranca, int tamanhoMax);
    GCHandle gcHandleEntraCodigoSeguranca;

    //CallBack SelecionaOpcao
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVSelecionaOpcao(_CallBackPDVSelecionaOpcao cbPDVSelecionaOpcao);
    private _RegPDVSelecionaOpcao dllRegPDVSelecionaOpcao;

    public delegate int _CallBackPDVSelecionaOpcao(StringBuilder label, StringBuilder opcoes, ref int opcaoSelecionada);
    GCHandle gcHandleSelecionaOpcao;

    //CallBack EntraValor
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraValor(_CallBackPDVEntraValor cbPDVEntraValor);
    private _RegPDVEntraValor dllRegPDVEntraValor;

    public delegate int _CallBackPDVEntraValor(StringBuilder label, IntPtr valor, StringBuilder valorMinimo, StringBuilder valorMaximo);
    GCHandle gcHandleEntraValor;

    //CallBack EntraValorEspecial
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraValorEspecial(_CallBackPDVEntraValorEspecial cbPDVEntraValorEspecial);
    private _RegPDVEntraValorEspecial dllRegPDVEntraValorEspecial;

    public delegate int _CallBackPDVEntraValorEspecial(StringBuilder label, IntPtr valor, StringBuilder parametros);
    GCHandle gcHandleEntraValorEspecial;

    //CallBack EntraNumero
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraNumero(_CallBackPDVEntraNumero cbEntraNumero);
    private _RegPDVEntraNumero dllRegPDVEntraNumero;

    public delegate int _CallBackPDVEntraNumero(StringBuilder label, IntPtr numero, StringBuilder numeroMinimo, StringBuilder numeroMaximo,
    int minimoDigitos, int maximoDigitos, int digitosExatos);
    GCHandle gcHandleEntraNumero;

    //CallBack OperacaoCancelada
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVOperacaoCancelada(_CallBackOperacaoCancelada cbPDVOperacaoCancelada);
    private _RegPDVOperacaoCancelada dllRegPDVOperacaoCancelada;

    public delegate int _CallBackOperacaoCancelada();
    GCHandle gcHandleOperacaoCancelada;

    //CallBack SetaOperacaoCancelada
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVSetaOperacaoCancelada(_CallBackPDVSetaOperacaoCancelada cbSetaOperacaoCancelada);
    private _RegPDVSetaOperacaoCancelada dllRegPDVSetaOperacaoCancelada;

    public delegate void _CallBackPDVSetaOperacaoCancelada([MarshalAs(UnmanagedType.I1)] bool cancelada);
    GCHandle gcHandleSetaOperacaoCancelada;

    //CallBack ProcessaMensagens
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVProcessaMensagens(_CallBackPDVProcessaMensagem cbProcessaMensagem);
    private _RegPDVProcessaMensagens dllRegPDVProcessaMensagens;

    public delegate void _CallBackPDVProcessaMensagem();
    GCHandle gcHandleProcessaMensagem;

    //CallBack EntraString
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraString(_CallBackPDVEntraString cbPDVEntraString);
    private _RegPDVEntraString dllRegPDVEntraString;

    public delegate int _CallBackPDVEntraString(StringBuilder label, IntPtr pString, StringBuilder tamanhoMaximo);
    GCHandle gcHandleEntraString;

    //CallBack ConsultaAVS
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVConsultaAVS(_CallBackPDVConsultaAVS cbConsultaAVS);
    private _RegPDVConsultaAVS dllRegPDVConsultaAVS;

    public delegate int _CallBackPDVConsultaAVS(IntPtr endereco, IntPtr numero, IntPtr apto, IntPtr bloco, IntPtr CEP, IntPtr bairro, IntPtr CPF);
    GCHandle gcHandleConsultaAVS;

    //CallBack MensagemAdicional
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVMensagemAdicional(_CallBackPDVMensagemAdicional cbPDVMensagemAdicional);
    private _RegPDVMensagemAdicional dllRegPDVMensagemAdicional;

    public delegate int _CallBackPDVMensagemAdicional(StringBuilder mensagemAdicional);
    GCHandle gcHandleMensagemAdicional;

    //CallBack ImagemAdicional
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVImagemAdicional(_CallBackPDVImagemAdicional cbPDVImagemAdicional);
    private _RegPDVImagemAdicional dllRegPDVImagemAdicional;

    public delegate int _CallBackPDVImagemAdicional(int indiceImagem);
    GCHandle gcHandleImagemAdicional;

    //CallBack EntraCodigoBarras
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraCodigoBarras(_CallBackPDVEntraCodigoBarras cbPDVEntraCodigoBarras);
    private _RegPDVEntraCodigoBarras dllRegPDVEntraCodigoBarras;

    public delegate int _CallBackPDVEntraCodigoBarras(StringBuilder label, IntPtr campo);
    GCHandle gcHandleEntraCodigoBarras;

    //CallBack EntraCodigoBarrasLido
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVEntraCodigoBarrasLido(_CallBackPDVEtraCodigoBarrasLido cbPDVEntraCodigoBarrasLido);
    private _RegPDVEntraCodigoBarrasLido dllRegPDVEntraCodigoBarrasLido;

    public delegate int _CallBackPDVEtraCodigoBarrasLido(StringBuilder label, IntPtr campo);
    GCHandle gcHandleEntraCodigoBarrasLido;

    //CallBack MensagemAlerta
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVMensagemAlerta(_CallBackPDVMensagemAlerta cbPDVMensagemAlerta);
    private _RegPDVMensagemAlerta dllRegPDVMensagemAlerta;

    public delegate void _CallBackPDVMensagemAlerta(StringBuilder mensagemAlerta);
    GCHandle gcHandleMensagemAlerta;

    //CallBack PreviewComprovante
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVPreviewComprovante(_CallBackPDVPreviewComprovante cbPDVPreviewComprovante);
    private _RegPDVPreviewComprovante dllRegPDVPreviewComprovante;

    public delegate int _CallBackPDVPreviewComprovante(StringBuilder comprovante);
    GCHandle gcHandlePreviewComprovante;

    //CallBack SelecionaPlanos
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVSelecionaPlanos(_CallBackPDVSelecionaPlanos cbPDVSelecionaPlanos);
    private _RegPDVSelecionaPlanos dllRegPDVSelecionaPlanos;

    public delegate int _CallBackPDVSelecionaPlanos(int codigoRede, int codigoTransacao, int tipoFinanciamento, int maximoParcelas, IntPtr valorMinimoParcela,
    int maxDiasPreDatado, IntPtr numeroParcelas, IntPtr valorTransacao, IntPtr valorParcela, IntPtr valorEntrada, IntPtr data);
    GCHandle gcHandleSelecionaPlanos;

    //CallBack SelecionaPlanosEx
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVSelecionaPlanosEx(_CallBackPDVSelecionaPlanosEx cbSelecionaPlanosEx);
    private _RegPDVSelecionaPlanosEx dllRegPDVSelecionaPlanosEx;

    public delegate int _CallBackPDVSelecionaPlanosEx(StringBuilder solicitacao, IntPtr retorno);
    GCHandle gcHandleSelecionaPlanosEx;

    //CallBack DadosHistorico
    [UnmanagedFunctionPointer(CallingConvention.StdCall)]
    public delegate void _RegPDVDadosHistorico(_CallBackPDVDadosHistorico cbDadosHistorico);
    private _RegPDVDadosHistorico dllRegPDVDadosHistorico;

    public delegate int _CallBackPDVDadosHistorico(StringBuilder parte1, int tamParte1, StringBuilder parte2, int tamParte2);
    GCHandle gcHandleDadosHistorico;
    #endregion

    bool bSemTelas;
    bool bManterDLLCarregada;
    String sNomeDLL;
    IGerenciadorSemTelas oGerenciadorSemTelas;

    public IntegracaoLinxDTEF()
    {
      dllHandle = (IntPtr)0;

      bSemTelas = false;
      bManterDLLCarregada = false;
      sNomeDLL = "DPOSDRV.DLL";
    }

    ~IntegracaoLinxDTEF()
    {
      if (gcHandleDisplayTerminal.IsAllocated)
        gcHandleDisplayTerminal.Free();

      if (gcHandleDisplayErro.IsAllocated)
        gcHandleDisplayErro.Free();

      if (gcHandleMensagem.IsAllocated)
        gcHandleMensagem.Free();

      if (gcHandleBeep.IsAllocated)
        gcHandleBeep.Free();

      if (gcHandleSolicitaConfirmacao.IsAllocated)
        gcHandleSolicitaConfirmacao.Free();

      if (gcHandleEntraCartao.IsAllocated)
        gcHandleEntraCartao.Free();

      if (gcHandleEntraDataValidade.IsAllocated)
        gcHandleEntraDataValidade.Free();

      if (gcHandleEntraData.IsAllocated)
        gcHandleEntraData.Free();

      if (gcHandleEntraCodigoSeguranca.IsAllocated)
        gcHandleEntraCodigoSeguranca.Free();

      if (gcHandleSelecionaOpcao.IsAllocated)
        gcHandleSelecionaOpcao.Free();

      if (gcHandleEntraValor.IsAllocated)
        gcHandleEntraValor.Free();

      if (gcHandleEntraValorEspecial.IsAllocated)
        gcHandleEntraValorEspecial.Free();

      if (gcHandleEntraNumero.IsAllocated)
        gcHandleEntraNumero.Free();

      if (gcHandleOperacaoCancelada.IsAllocated)
        gcHandleOperacaoCancelada.Free();

      if (gcHandleSetaOperacaoCancelada.IsAllocated)
        gcHandleSetaOperacaoCancelada.Free();

      if (gcHandleProcessaMensagem.IsAllocated)
        gcHandleProcessaMensagem.Free();

      if (gcHandleEntraString.IsAllocated)
        gcHandleEntraString.Free();

      if (gcHandleConsultaAVS.IsAllocated)
        gcHandleConsultaAVS.Free();

      if (gcHandleMensagemAdicional.IsAllocated)
        gcHandleMensagemAdicional.Free();

      if (gcHandleImagemAdicional.IsAllocated)
        gcHandleImagemAdicional.Free();

      if (gcHandleEntraCodigoBarras.IsAllocated)
        gcHandleEntraCodigoBarras.Free();

      if (gcHandleEntraCodigoBarrasLido.IsAllocated)
        gcHandleEntraCodigoBarrasLido.Free();

      if (gcHandleMensagemAlerta.IsAllocated)
        gcHandleMensagemAlerta.Free();

      if (gcHandlePreviewComprovante.IsAllocated)
        gcHandlePreviewComprovante.Free();

      if (gcHandleSelecionaPlanos.IsAllocated)
        gcHandleSelecionaPlanos.Free();

      if (gcHandleSelecionaPlanosEx.IsAllocated)
        gcHandleSelecionaPlanosEx.Free();

      if (gcHandleBeep.IsAllocated)
        gcHandleDadosHistorico.Free();
    }

    #region Funções callback exportadas
    //========================== funções exportadas para registro das funções callback de telas chamadas pela automação ================================================================
    private void CallBackPDVDisplayTerminal(StringBuilder mensagem)
    {
      oGerenciadorSemTelas.DisplayTerminal(mensagem.ToString());
    }

    public void CallBackPDVDisplayErro(StringBuilder mensagem)
    {
      oGerenciadorSemTelas.DisplayErro(mensagem.ToString());
    }

    private void CallBackPDVMensagem(StringBuilder mensagem)
    {
      oGerenciadorSemTelas.Mensagem(mensagem.ToString());
    }

    private void CallBackPDVBeep()
    {
      oGerenciadorSemTelas.Beep();
    }

    private int CallBackPDVSolicitaConfirmacao(StringBuilder mensagem)
    {
      return oGerenciadorSemTelas.SolicitaConfirmacao(mensagem.ToString());
    }

    private int CallBackPDVEntraCartao(StringBuilder label, IntPtr cartao)
    {
      string sLabel = label.ToString();
      string sCartaoColetado = "";

      int res = oGerenciadorSemTelas.EntraCartao(sLabel, ref sCartaoColetado);
      if (res == 0)
      {
        byte[] dados = new byte[sCartaoColetado.Length + 1];
        dados = ASCIIEncoding.ASCII.GetBytes((sCartaoColetado + "\0").ToCharArray());
        Marshal.Copy(dados, 0, cartao, dados.Length);
      }

      return res;
    }

    private int CallBackEntraDataValidade(StringBuilder label, IntPtr dataValidade)
    {
      string sLabel = label.ToString();
      byte[] pDados = new byte[5];
      Marshal.Copy(dataValidade, pDados, 0, pDados.Length);
      string sDataValidade = ASCIIEncoding.ASCII.GetString(pDados);
      int res = oGerenciadorSemTelas.EntraDataValidade(sLabel, ref sDataValidade);
      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes((sDataValidade + "\0").ToCharArray());
        Marshal.Copy(pDados, 0, dataValidade, pDados.Length);
      }
      return res;
    }

    private int CallBackEntraData(StringBuilder label, IntPtr dataValidade)
    {
      string sLabel = label.ToString();
      byte[] pDados = new byte[9];
      Marshal.Copy(dataValidade, pDados, 0, pDados.Length);
      string sDataValidade = ASCIIEncoding.ASCII.GetString(pDados);
      int res = oGerenciadorSemTelas.EntraDataValidade(sLabel, ref sDataValidade);
      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes((sDataValidade + "\0").ToCharArray());
        Marshal.Copy(pDados, 0, dataValidade, pDados.Length);
      }
      return res;
    }

    private int CallBackPDVEntraCodigoSeguranca(StringBuilder label, IntPtr entraCodigoSeguranca, int tamanhoMax)
    {
      string sLabel = label.ToString();
      byte[] pDados = new byte[tamanhoMax + 1];
      string sCodigoSeguranca = ASCIIEncoding.ASCII.GetString(pDados);
      int res = oGerenciadorSemTelas.EntraCodigoSeguranca(sLabel, ref sCodigoSeguranca, tamanhoMax);
      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes((sCodigoSeguranca + "\0").ToCharArray());
        Marshal.Copy(pDados, 0, entraCodigoSeguranca, pDados.Length);
      }
      return res;
    }

    private int CallBackPDVSelecionaOpcao(StringBuilder label, StringBuilder opcoes, ref int opcaoSelecionada)
    {
      String sLabel = label.ToString();
      String sOpcoes = opcoes.ToString();
      int iOpcaoSelecionada = opcaoSelecionada;
      int res = oGerenciadorSemTelas.SelecionaOpcao(sLabel, sOpcoes, ref iOpcaoSelecionada);
      if (res == 0)
      {
        opcaoSelecionada = iOpcaoSelecionada;
      }
      return res;
    }

    private int CallBackPDVEntraValor(StringBuilder label, IntPtr valor, StringBuilder valorMinimo, StringBuilder valorMaximo)
    {
      byte[] pDados = new byte[12];
      char[] pArray = new char[12];
      string sLabel = label.ToString();
      Decimal dValorMin = Conversor.ToDecimalDef(valorMinimo.ToString(), 0) / 100.0M;
      Decimal dValorMax = Conversor.ToDecimalDef(valorMaximo.ToString(), 0) / 100.0M;      
      Marshal.Copy(valor, pDados, 0, pDados.Length);
      string sValor = ASCIIEncoding.ASCII.GetString(pDados);

      Decimal dValor = Conversor.ToDecimalDef(sValor, 0) / 100.0M;

      int res = oGerenciadorSemTelas.EntraValor(sLabel, ref dValor, dValorMin, dValorMax);
      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes((FormataValorDPOS(12, dValor) + '\0').ToCharArray());
        Marshal.Copy(pDados, 0, valor, pDados.Length);
      }
      return res;
    }

    private int CallBackPDVEntraValorEspecial(StringBuilder label, IntPtr valor, StringBuilder parametros)
    {
      byte[] pDados = new byte[12];
      char[] pArray = new char[12];
      string sLabel = label.ToString();
      string sParametros = parametros.ToString();
      
      Marshal.Copy(valor, pDados, 0, pDados.Length);
      string sValor = ASCIIEncoding.ASCII.GetString(pDados);

      int iCasasDecimaisEntraValor = Conversor.ToIntDef(sParametros.Substring(24, 1), 0);
      Decimal dValorMinimo = Conversor.ToDecimalDef(sParametros.Substring(0, 12), 0) / (Decimal) Math.Pow(10, iCasasDecimaisEntraValor);
      Decimal dValorMaximo = Conversor.ToDecimalDef(sParametros.Substring(12, 12), 0) / (Decimal) Math.Pow(10, iCasasDecimaisEntraValor);
      Decimal dValor = Conversor.ToDecimalDef(sValor, 0) / (Decimal) Math.Pow(10, iCasasDecimaisEntraValor);

      int res = oGerenciadorSemTelas.EntraValorEspecial(sLabel, ref dValor, dValorMinimo, dValorMaximo, iCasasDecimaisEntraValor);
      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes((FormataValorDPOS(12, dValor) + '\0').ToCharArray());
        Marshal.Copy(pDados, 0, valor, pDados.Length);
      }
      return res;
    }

    private int CallBackPDVEntraNumero(StringBuilder label, IntPtr numero, StringBuilder numeroMinimo, StringBuilder numeroMaximo, int minimoDigitos, int maximoDigitos, int digitosExatos)
    {
      byte[] pDados = new byte[13];
      string sLabel = label.ToString();
      int iNumeroMin = Conversor.ToIntDef(numeroMinimo.ToString(), 0);
      int iNumeroMax = Conversor.ToIntDef(numeroMaximo.ToString(), 0);

      Marshal.Copy(numero, pDados, 0, pDados.Length);
      string sNumeroInformado = ASCIIEncoding.ASCII.GetString(pDados);

      int res = oGerenciadorSemTelas.EntraNumero(sLabel, ref sNumeroInformado, iNumeroMin, iNumeroMax, minimoDigitos, maximoDigitos, digitosExatos);

      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes(sNumeroInformado.ToCharArray());
        Marshal.Copy(pDados, 0, numero, pDados.Length);
      }

      return res;
    }

    private int CallBackPDVOperacaoCancelada()
    {
      return oGerenciadorSemTelas.OperacaoCancelada();
    }

    private void CallBackPDVSetaOperacaoCancelada(bool cancelada)
    {
      oGerenciadorSemTelas.SetaOperacaoCancelada(cancelada);
    }

    private void CallBackPDVProcessaMensagens()
    {
      oGerenciadorSemTelas.ProcessaMensagens();
    }

    private int CallBackPDVEntraString(StringBuilder label, IntPtr pString, StringBuilder tamanhoMaximo)
    {
      String sLabel = label.ToString();
      int iTamanhoMaximo = Conversor.ToIntDef(tamanhoMaximo.ToString(), 0);
      byte[] pDados = new byte[iTamanhoMaximo];
      string sStringColetada = ASCIIEncoding.ASCII.GetString(pDados);

      int res = oGerenciadorSemTelas.EntraString(sLabel, ref sStringColetada, iTamanhoMaximo.ToString());

      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes(sStringColetada.ToCharArray());
        Marshal.Copy(pDados, 0, pString, pDados.Length);
      }

      return res;
    }

    private int CallBackPDVConsultaAVS(IntPtr endereco, IntPtr numero, IntPtr apto, IntPtr bloco, IntPtr CEP, IntPtr bairro, IntPtr CPF)
    {
      byte[] pEndereco = new byte[97];
      byte[] pNumero = new byte[17];
      byte[] pApto = new byte[9];
      byte[] pBloco = new byte[33];
      byte[] pCEP = new byte[9];
      byte[] pBairro = new byte[33];
      byte[] pCPF = new byte[12];

      string sEndereco = ASCIIEncoding.ASCII.GetString(pEndereco);
      string sNumero = ASCIIEncoding.ASCII.GetString(pNumero);
      string sApto = ASCIIEncoding.ASCII.GetString(pApto);
      string sBloco = ASCIIEncoding.ASCII.GetString(pBloco);
      string sCEP = ASCIIEncoding.ASCII.GetString(pCEP);
      string sBairro = ASCIIEncoding.ASCII.GetString(pBairro);
      string sCPF = ASCIIEncoding.ASCII.GetString(pCPF);

      int res = oGerenciadorSemTelas.ConsultaAVS(ref sEndereco, ref sNumero, ref sApto, ref sBloco, ref sCEP, ref sBairro, ref sCPF);
      if (res == 0)
      {
        pEndereco = ASCIIEncoding.ASCII.GetBytes((sEndereco + "\0").ToCharArray());
        pNumero = ASCIIEncoding.ASCII.GetBytes((sNumero + "\0").ToCharArray());
        pApto = ASCIIEncoding.ASCII.GetBytes((sApto + "\0").ToCharArray());
        pBloco = ASCIIEncoding.ASCII.GetBytes((sBloco + "\0").ToCharArray());
        pCEP = ASCIIEncoding.ASCII.GetBytes((sCEP + "\0").ToCharArray());
        pBairro = ASCIIEncoding.ASCII.GetBytes((sBairro + "\0").ToCharArray());
        pCPF = ASCIIEncoding.ASCII.GetBytes((sCPF + "\0").ToCharArray());

        Marshal.Copy(pEndereco, 0, endereco, pEndereco.Length);
        Marshal.Copy(pNumero, 0, numero, pNumero.Length);
        Marshal.Copy(pApto, 0, apto, pApto.Length);
        Marshal.Copy(pBloco, 0, bloco, pBloco.Length);
        Marshal.Copy(pCEP, 0, CEP, pCEP.Length);
        Marshal.Copy(pBairro, 0, bairro, pBairro.Length);
        Marshal.Copy(pCPF, 0, CPF, pCPF.Length);
      }

      return res;
    }

    private int CallBackPDVMensagemAdicional(StringBuilder mensagemAdicional)
    {
      return oGerenciadorSemTelas.MensagemAdicional(mensagemAdicional.ToString());
    }

    private int CallBackPDVImagemAdicional(int indiceImagem)
    {
      return oGerenciadorSemTelas.ImagemAdicional(indiceImagem);
    }

    private int CallBackPDVEntraCodigoBarras(StringBuilder label, IntPtr campo)
    {
      string sLabel = label.ToString();
      byte[] pDados = new byte[49];
      string sCodigoBarras = ASCIIEncoding.ASCII.GetString(pDados);

      int res = oGerenciadorSemTelas.EntraCodigoBarras(sLabel, ref sCodigoBarras);
      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes((sCodigoBarras + "\0").ToCharArray());
        Marshal.Copy(pDados, 0, campo, pDados.Length);
      }

      return res;
    }

    private int CallBackPDVEntraCodigoBarrasLido(StringBuilder label, IntPtr campo)
    {
      string sLabel = label.ToString();
      byte[] pDados = new byte[49];
      string sCodigoBarras = ASCIIEncoding.ASCII.GetString(pDados);

      int res = oGerenciadorSemTelas.EntraCodigoBarras(sLabel, ref sCodigoBarras);
      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes((sCodigoBarras + "\0").ToCharArray());
        Marshal.Copy(pDados, 0, campo, pDados.Length);
      }

      return res;
    }

    private void CallBackPDVMensagemAlerta(StringBuilder mensagem)
    {
      oGerenciadorSemTelas.MensagemAlerta(mensagem.ToString());
    }

    private int CallBackPDVPreviewComprovante(StringBuilder comprovante)
    {
      oGerenciadorSemTelas.PreviewComprovante(comprovante.ToString());
      return 0;
    }

    private int CallBackPDVSelecionaPlanos(int codigoRede, int codigoTransacao, int tipoFinanciamento, int maximoParcelas, IntPtr valorMinimoParcela,
    int maxDiasPreDatado, IntPtr numeroParcelas, IntPtr valorTransacao, IntPtr valorParcela, IntPtr valorEntrada, IntPtr data)
    {
      byte[] pValorMinimoParcela = new byte[13];
      byte[] pNumeroParcelas = new byte[3];
      byte[] pValorTransacao = new byte[13];
      byte[] pValorParcela = new byte[13];
      byte[] pValorEntrada = new byte[13];
      byte[] pData = new byte[11];
      byte[] pMaximoParcelas = new byte[3];

      Marshal.Copy(valorMinimoParcela, pValorMinimoParcela, 0, pValorMinimoParcela.Length);
      Marshal.Copy(numeroParcelas, pNumeroParcelas, 0, pNumeroParcelas.Length);
      Marshal.Copy(valorTransacao, pValorTransacao, 0, pValorTransacao.Length);
      Marshal.Copy(valorParcela, pValorParcela, 0, pValorParcela.Length);
      Marshal.Copy(valorEntrada, pValorEntrada, 0, pValorEntrada.Length);
      Marshal.Copy(data, pData, 0, pData.Length);

      Decimal dValorMinimoParcela = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(pValorMinimoParcela), 0);
      dValorMinimoParcela = dValorMinimoParcela / 100.0M;

      int iNumeroParcelas = Conversor.ToIntDef(ASCIIEncoding.ASCII.GetString(pNumeroParcelas), 0);

      Decimal dValorTransacao = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(pValorTransacao), 0);
      dValorMinimoParcela = dValorMinimoParcela / 100.0M;

      Decimal dValorParcela = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(pValorParcela), 0);
      dValorMinimoParcela = dValorMinimoParcela / 100.0M;

      Decimal dValorEntrada = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(pValorEntrada), 0);
      dValorMinimoParcela = dValorMinimoParcela / 100.0M;

      string sData = ASCIIEncoding.ASCII.GetString(pData);

      int res = oGerenciadorSemTelas.SelecionaPlanos(codigoRede, codigoTransacao, tipoFinanciamento, maximoParcelas, dValorMinimoParcela, maxDiasPreDatado,
      ref iNumeroParcelas, ref dValorTransacao, ref dValorParcela, ref dValorEntrada, ref sData);

      if (res == 0)
      {
        pValorMinimoParcela = ASCIIEncoding.ASCII.GetBytes((dValorMinimoParcela.ToString() + "\0").ToCharArray());
        pNumeroParcelas = ASCIIEncoding.ASCII.GetBytes((string.Format("{0:d2}", iNumeroParcelas) + "\0").ToCharArray());
        pValorTransacao = ASCIIEncoding.ASCII.GetBytes((dValorTransacao.ToString() + "\0").ToCharArray());
        pValorParcela = ASCIIEncoding.ASCII.GetBytes((dValorParcela.ToString() + "\0").ToCharArray());
        pValorEntrada = ASCIIEncoding.ASCII.GetBytes((dValorEntrada.ToString() + "\0").ToCharArray());
        pData = ASCIIEncoding.ASCII.GetBytes((sData + "\0").ToCharArray());

        Marshal.Copy(pValorMinimoParcela, 0, valorMinimoParcela, pValorMinimoParcela.Length);
        Marshal.Copy(pNumeroParcelas, 0, numeroParcelas, pNumeroParcelas.Length);
        Marshal.Copy(pValorTransacao, 0, valorTransacao, pValorTransacao.Length);
        Marshal.Copy(pValorParcela, 0, valorParcela, pValorParcela.Length);
        Marshal.Copy(pValorEntrada, 0, valorEntrada, pValorEntrada.Length);
        Marshal.Copy(pData, 0, data, pData.Length);
      }
      return res;
    }

    private int CallBackPDVSelecionaPlanosEx(StringBuilder solicitacao, IntPtr retorno)
    {
      string sSolicitacao = solicitacao.ToString();
      byte[] pDados = new byte[sSolicitacao.Length + 1];
      string sRetorno = ASCIIEncoding.ASCII.GetString(pDados);
      int res = oGerenciadorSemTelas.SelecionaPlanosEx(sSolicitacao, ref sRetorno);

      if (res == 0)
      {
        pDados = ASCIIEncoding.ASCII.GetBytes((sRetorno + "\0").ToCharArray());
        Marshal.Copy(pDados, 0, retorno, pDados.Length);
      }

      return res;
    }

    private int CallBackPDVDadosHistorico(StringBuilder parte1, int tamParte1, StringBuilder parte2, int tamParte2)
    {
      string pt1 = parte1.ToString();
      string pt2 = parte2.ToString();

      oGerenciadorSemTelas.DadosHistorico(pt1, tamParte1, pt2, tamParte2);

      return 0;
    }

    #endregion

    #region Métodos auxiliares

    public bool getSemTelas()
    {
      return bSemTelas;
    }

    public void setSemTelas(bool bSemTelas)
    {
      this.bSemTelas = bSemTelas;
    }

    public bool getManterDLLCarregada()
    {
      return bManterDLLCarregada;
    }

    public void setManterDLLCarregada(bool bManterDLLCarregada)
    {
      this.bManterDLLCarregada = bManterDLLCarregada;
    }

    public string getNomeDLL()
    {
      return sNomeDLL;
    }

    public void setNomeDLL(string sNomeDLL)
    {
      this.sNomeDLL = sNomeDLL;
    }

    public void setGerenciadorSemTelas(IGerenciadorSemTelas oGerenciadorSemTelas)
    {
      this.oGerenciadorSemTelas = oGerenciadorSemTelas;
      setSemTelas(true);
    }

    public bool CarregaDLL()
    {
      if (dllHandle == (IntPtr)0)
        dllHandle = LoadLibrary(sNomeDLL);

      if (dllHandle == (IntPtr)0)
        return false;

      //carrega cada um dos callbacks
      if (getSemTelas())
      {
        dllRegPDVDisplayTerminal = (_RegPDVDisplayTerminal)GetDelegateFromDLL("RegPDVDisplayTerminal", typeof(_RegPDVDisplayTerminal));
        _CallBackPDVDisplayTerminal cbDisplayTerminal = new _CallBackPDVDisplayTerminal(CallBackPDVDisplayTerminal);
        gcHandleDisplayTerminal = GCHandle.Alloc(cbDisplayTerminal);
        dllRegPDVDisplayTerminal((_CallBackPDVDisplayTerminal)gcHandleDisplayTerminal.Target);

        dllRegPDVDisplayErro = (_RegPDVDisplayErro)GetDelegateFromDLL("RegPDVDisplayErro", typeof(_RegPDVDisplayErro));
        _CallBackPDVDisplayErro cbDisplayErro = new _CallBackPDVDisplayErro(CallBackPDVDisplayErro);
        gcHandleDisplayErro = GCHandle.Alloc(cbDisplayErro);
        dllRegPDVDisplayErro((_CallBackPDVDisplayErro)gcHandleDisplayErro.Target);

        dllRegPDVMensagem = (_RegPDVMensagem)GetDelegateFromDLL("RegPDVMensagem", typeof(_RegPDVMensagem));
        _CallBackPDVMensagem cbMensagem = new _CallBackPDVMensagem(CallBackPDVMensagem);
        gcHandleMensagem = GCHandle.Alloc(cbMensagem);
        dllRegPDVMensagem((_CallBackPDVMensagem)gcHandleMensagem.Target);

        dllRegPDVBeep = (_RegPDVBeep)GetDelegateFromDLL("RegPDVBeep", typeof(_RegPDVBeep));
        _CallBackPDVBeep cbBeep = new _CallBackPDVBeep(CallBackPDVBeep);
        gcHandleBeep = GCHandle.Alloc(cbBeep);
        dllRegPDVBeep((_CallBackPDVBeep)gcHandleBeep.Target);

        dllRegPDVSolicitaConfirmacao = (_RegPDVSolicitaConfirmacao)GetDelegateFromDLL("RegPDVSolicitaConfirmacao", typeof(_RegPDVSolicitaConfirmacao));
        _CallBackPDVSolicitaConfirmacao cbSolicitaConfirmacao = new _CallBackPDVSolicitaConfirmacao(CallBackPDVSolicitaConfirmacao);
        gcHandleSolicitaConfirmacao = GCHandle.Alloc(cbSolicitaConfirmacao);
        dllRegPDVSolicitaConfirmacao((_CallBackPDVSolicitaConfirmacao)gcHandleSolicitaConfirmacao.Target);

        dllRegPDVEntraCartao = (_RegPDVEntraCartao)GetDelegateFromDLL("RegPDVEntraCartao", typeof(_RegPDVEntraCartao));
        _CallBackEntraCartao cbEntraCartao = new _CallBackEntraCartao(CallBackPDVEntraCartao);
        gcHandleEntraCartao = GCHandle.Alloc(cbEntraCartao);
        dllRegPDVEntraCartao((_CallBackEntraCartao)gcHandleEntraCartao.Target);

        dllRegPDVEntraDataValidade = (_RegPDVEntraDataValidade)GetDelegateFromDLL("RegPDVEntraDataValidade", typeof(_RegPDVEntraDataValidade));
        _CallBackPDVEntraDataValidade cbEntraDataValidade = new _CallBackPDVEntraDataValidade(CallBackEntraDataValidade);
        gcHandleEntraDataValidade = GCHandle.Alloc(cbEntraDataValidade);
        dllRegPDVEntraDataValidade((_CallBackPDVEntraDataValidade)gcHandleEntraDataValidade.Target);

        dllRegPDVEntraData = (_RegPDVEntraData)GetDelegateFromDLL("RegPDVEntraData", typeof(_RegPDVEntraData));
        _CallBackEntraData cbEntraData = new _CallBackEntraData(CallBackEntraData);
        gcHandleEntraData = GCHandle.Alloc(cbEntraData);
        dllRegPDVEntraData((_CallBackEntraData)gcHandleEntraData.Target);

        dllRegPDVEntraCodigoSeguranca = (_RegPDVEntraCodigoSeguranca)GetDelegateFromDLL("RegPDVEntraCodigoSeguranca", typeof(_RegPDVEntraCodigoSeguranca));
        _CallBackPDVEntraCodigoSeguranca cbEntraCodigoSeguranca = new _CallBackPDVEntraCodigoSeguranca(CallBackPDVEntraCodigoSeguranca);
        gcHandleEntraCodigoSeguranca = GCHandle.Alloc(cbEntraCodigoSeguranca);
        dllRegPDVEntraCodigoSeguranca((_CallBackPDVEntraCodigoSeguranca)gcHandleEntraCodigoSeguranca.Target);

        dllRegPDVSelecionaOpcao = (_RegPDVSelecionaOpcao)GetDelegateFromDLL("RegPDVSelecionaOpcao", typeof(_RegPDVSelecionaOpcao));
        _CallBackPDVSelecionaOpcao cbSelecionaOpcao = new _CallBackPDVSelecionaOpcao(CallBackPDVSelecionaOpcao);
        gcHandleSelecionaOpcao = GCHandle.Alloc(cbSelecionaOpcao);
        dllRegPDVSelecionaOpcao((_CallBackPDVSelecionaOpcao)gcHandleSelecionaOpcao.Target);

        dllRegPDVEntraValor = (_RegPDVEntraValor)GetDelegateFromDLL("RegPDVEntraValor", typeof(_RegPDVEntraValor));
        _CallBackPDVEntraValor cbEntraValor = new _CallBackPDVEntraValor(CallBackPDVEntraValor);
        gcHandleEntraValor = GCHandle.Alloc(cbEntraValor);
        dllRegPDVEntraValor((_CallBackPDVEntraValor)gcHandleEntraValor.Target);

        dllRegPDVEntraValorEspecial = (_RegPDVEntraValorEspecial)GetDelegateFromDLL("RegPDVEntraValorEspecial", typeof(_RegPDVEntraValorEspecial));
        _CallBackPDVEntraValorEspecial cbEntraValorEspecial = new _CallBackPDVEntraValorEspecial(CallBackPDVEntraValorEspecial);
        gcHandleEntraValorEspecial = GCHandle.Alloc(cbEntraValorEspecial);
        dllRegPDVEntraValorEspecial((_CallBackPDVEntraValorEspecial)gcHandleEntraValorEspecial.Target);

        dllRegPDVEntraNumero = (_RegPDVEntraNumero)GetDelegateFromDLL("RegPDVEntraNumero", typeof(_RegPDVEntraNumero));
        _CallBackPDVEntraNumero cbEntraNumero = new _CallBackPDVEntraNumero(CallBackPDVEntraNumero);
        gcHandleEntraNumero = GCHandle.Alloc(cbEntraNumero);
        dllRegPDVEntraNumero((_CallBackPDVEntraNumero)gcHandleEntraNumero.Target);

        dllRegPDVSetaOperacaoCancelada = (_RegPDVSetaOperacaoCancelada)GetDelegateFromDLL("RegPDVSetaOperacaoCancelada", typeof(_RegPDVSetaOperacaoCancelada));
        _CallBackPDVSetaOperacaoCancelada cbSetaOperacaoCancelada = new _CallBackPDVSetaOperacaoCancelada(CallBackPDVSetaOperacaoCancelada);
        gcHandleSetaOperacaoCancelada = GCHandle.Alloc(cbSetaOperacaoCancelada);
        dllRegPDVSetaOperacaoCancelada((_CallBackPDVSetaOperacaoCancelada)gcHandleSetaOperacaoCancelada.Target);

        dllRegPDVOperacaoCancelada = (_RegPDVOperacaoCancelada)GetDelegateFromDLL("RegPDVOperacaoCancelada", typeof(_RegPDVOperacaoCancelada));
        _CallBackOperacaoCancelada cbOperacaoCancelada = new _CallBackOperacaoCancelada(CallBackPDVOperacaoCancelada);
        gcHandleOperacaoCancelada = GCHandle.Alloc(cbOperacaoCancelada);
        dllRegPDVOperacaoCancelada((_CallBackOperacaoCancelada)gcHandleOperacaoCancelada.Target);

        dllRegPDVProcessaMensagens = (_RegPDVProcessaMensagens)GetDelegateFromDLL("RegPDVProcessaMensagens", typeof(_RegPDVProcessaMensagens));
        _CallBackPDVProcessaMensagem cbProcessaMensagem = new _CallBackPDVProcessaMensagem(CallBackPDVProcessaMensagens);
        gcHandleProcessaMensagem = GCHandle.Alloc(cbProcessaMensagem);
        dllRegPDVProcessaMensagens((_CallBackPDVProcessaMensagem)gcHandleProcessaMensagem.Target);

        dllRegPDVEntraString = (_RegPDVEntraString)GetDelegateFromDLL("RegPDVEntraString", typeof(_RegPDVEntraString));
        _CallBackPDVEntraString cbEntraString = new _CallBackPDVEntraString(CallBackPDVEntraString);
        gcHandleEntraString = GCHandle.Alloc(cbEntraString);
        dllRegPDVEntraString(CallBackPDVEntraString);

        dllRegPDVConsultaAVS = (_RegPDVConsultaAVS)GetDelegateFromDLL("RegPDVConsultaAVS", typeof(_RegPDVConsultaAVS));
        _CallBackPDVConsultaAVS cbConsultaAVS = new _CallBackPDVConsultaAVS(CallBackPDVConsultaAVS);
        gcHandleConsultaAVS = GCHandle.Alloc(cbConsultaAVS);
        dllRegPDVConsultaAVS((_CallBackPDVConsultaAVS)gcHandleConsultaAVS.Target);

        dllRegPDVMensagemAdicional = (_RegPDVMensagemAdicional)GetDelegateFromDLL("RegPDVMensagemAdicional", typeof(_RegPDVMensagemAdicional));
        _CallBackPDVMensagemAdicional cbMensagemAdicional = new _CallBackPDVMensagemAdicional(CallBackPDVMensagemAdicional);
        gcHandleMensagemAdicional = GCHandle.Alloc(cbMensagemAdicional);
        dllRegPDVMensagemAdicional((_CallBackPDVMensagemAdicional)gcHandleMensagemAdicional.Target);

        dllRegPDVImagemAdicional = (_RegPDVImagemAdicional)GetDelegateFromDLL("RegPDVImagemAdicional", typeof(_RegPDVImagemAdicional));
        _CallBackPDVImagemAdicional cbImagemAdicional = new _CallBackPDVImagemAdicional(CallBackPDVImagemAdicional);
        gcHandleImagemAdicional = GCHandle.Alloc(cbImagemAdicional);
        dllRegPDVImagemAdicional((_CallBackPDVImagemAdicional)gcHandleImagemAdicional.Target);

        dllRegPDVEntraCodigoBarras = (_RegPDVEntraCodigoBarras)GetDelegateFromDLL("RegPDVEntraCodigoBarras", typeof(_RegPDVEntraCodigoBarras));
        _CallBackPDVEntraCodigoBarras cbEntraCodigoBarras = new _CallBackPDVEntraCodigoBarras(CallBackPDVEntraCodigoBarras);
        gcHandleEntraCodigoBarras = GCHandle.Alloc(cbEntraCodigoBarras);
        dllRegPDVEntraCodigoBarras((_CallBackPDVEntraCodigoBarras)gcHandleEntraCodigoBarras.Target);

        dllRegPDVEntraCodigoBarrasLido = (_RegPDVEntraCodigoBarrasLido)GetDelegateFromDLL("RegPDVEntraCodigoBarrasLido", typeof(_RegPDVEntraCodigoBarrasLido));
        _CallBackPDVEtraCodigoBarrasLido cbEntraCodigoBarrasLido = new _CallBackPDVEtraCodigoBarrasLido(CallBackPDVEntraCodigoBarrasLido);
        gcHandleEntraCodigoBarrasLido = GCHandle.Alloc(cbEntraCodigoBarrasLido);
        dllRegPDVEntraCodigoBarrasLido((_CallBackPDVEtraCodigoBarrasLido)gcHandleEntraCodigoBarrasLido.Target);

        dllRegPDVMensagemAlerta = (_RegPDVMensagemAlerta)GetDelegateFromDLL("RegPDVMensagemAlerta", typeof(_RegPDVMensagemAlerta));
        _CallBackPDVMensagemAlerta cbMensagemAlerta = new _CallBackPDVMensagemAlerta(CallBackPDVMensagemAlerta);
        gcHandleMensagemAlerta = GCHandle.Alloc(cbMensagemAlerta);
        dllRegPDVMensagemAlerta((_CallBackPDVMensagemAlerta)gcHandleMensagemAlerta.Target);

        dllRegPDVPreviewComprovante = (_RegPDVPreviewComprovante)GetDelegateFromDLL("RegPDVPreviewComprovante", typeof(_RegPDVPreviewComprovante));
        _CallBackPDVPreviewComprovante cbPreviewComprovante = new _CallBackPDVPreviewComprovante(CallBackPDVPreviewComprovante);
        gcHandlePreviewComprovante = GCHandle.Alloc(cbPreviewComprovante);
        dllRegPDVPreviewComprovante((_CallBackPDVPreviewComprovante)gcHandlePreviewComprovante.Target);

        /* Não registra pois ainda não esta implementada (só deve ser registrada se for implementada, pois trata-se de uma função especifica para tratamento de planos
        dllRegPDVSelecionaPlanos = (_RegPDVSelecionaPlanos)GetDelegateFromDLL("RegPDVSelecionaPlanos", typeof(_RegPDVSelecionaPlanos));
        _CallBackPDVSelecionaPlanos cbSelecionaPlanos = new _CallBackPDVSelecionaPlanos(CallBackPDVSelecionaPlanos);
        gcHandleSelecionaPlanos = GCHandle.Alloc(cbSelecionaPlanos);
        dllRegPDVSelecionaPlanos((_CallBackPDVSelecionaPlanos)gcHandleSelecionaPlanos.Target);
        */
        dllRegPDVSelecionaPlanosEx = (_RegPDVSelecionaPlanosEx)GetDelegateFromDLL("RegPDVSelecionaPlanosEx", typeof(_RegPDVSelecionaPlanosEx));
        _CallBackPDVSelecionaPlanosEx cbSelecionaPlanosEx = new _CallBackPDVSelecionaPlanosEx(CallBackPDVSelecionaPlanosEx);
        gcHandleSelecionaPlanosEx = GCHandle.Alloc(cbSelecionaPlanosEx);
        dllRegPDVSelecionaPlanosEx((_CallBackPDVSelecionaPlanosEx)gcHandleSelecionaPlanosEx.Target);

        dllRegPDVDadosHistorico = (_RegPDVDadosHistorico)GetDelegateFromDLL("RegPDVDadosHistorico", typeof(_RegPDVDadosHistorico));
        _CallBackPDVDadosHistorico cbDadosHistorico = new _CallBackPDVDadosHistorico(CallBackPDVDadosHistorico);
        gcHandleDadosHistorico = GCHandle.Alloc(cbDadosHistorico);
        dllRegPDVDadosHistorico((_CallBackPDVDadosHistorico)gcHandleDadosHistorico.Target);
      }

      return true;
    }

    public bool DescarregaDLL()
    {
      FreeLibrary(dllHandle);
      dllHandle = (IntPtr)0;
      return true;
    }

    public object GetDelegateFromDLL(string pFunction, Type pType)
    {
      IntPtr lTemp = GetProcAddress(dllHandle, pFunction);
      object gTemp = Marshal.GetDelegateForFunctionPointer(lTemp, pType);
      return gTemp;
    }

    #endregion

    #region funções auxiliares de formatação
    private string FormataValorDPOS(int iQuantDigitos, Decimal dValor)
    {
      string sFormato = "{0:d" + iQuantDigitos + "}";

      return String.Format(sFormato, (int)(dValor * 100.0M));
    }
    private string FormataSimNaoDPOS(bool bSim)
    {
      if (bSim)
        return "S";
      else
        return "N";
    }
    private string FormataDataDPOS(DateTime dtData)
    {
      return String.Format("{0:dd/MM/yy}", dtData);
    }
    #endregion

    #region funcoes de transacao
    public int TransacaoCartaoCredito(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCartaoCredito = (_TransacaoCartaoCredito)GetDelegateFromDLL("TransacaoCartaoCredito", typeof(_TransacaoCartaoCredito));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("000000");

      int iRes = dllTransacaoCartaoCredito(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoDebito(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCartaoDebito = (_TransacaoCartaoDebito)GetDelegateFromDLL("TransacaoCartaoDebito", typeof(_TransacaoCartaoDebito));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoCartaoDebito(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoEstatistica(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoEstatistica = (_TransacaoEstatistica)GetDelegateFromDLL("TransacaoEstatistica", typeof(_TransacaoEstatistica));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoEstatistica(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoParceleMais(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, int iCodigoTabela)
    {
      if (!CarregaDLL())
      {
        iNumeroControle = 0;
        return 11;
      }
      dllTransacaoCartaoParceleMais = (_TransacaoCartaoParceleMais)GetDelegateFromDLL("TransacaoCartaoParceleMais", typeof(_TransacaoCartaoParceleMais));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder pCodigoTabela = new StringBuilder(String.Format("{0:d2}", iCodigoTabela));

      int iRes = dllTransacaoCartaoParceleMais(pValorTransacao, pNumeroCupom, pNumeroControle, pCodigoTabela);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }
      else
      {
        iNumeroControle = 0;
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoParceleMaisCompleta(Decimal dValorTransacao, int iNumeroCupom, int iNumeroControle, int iCodigoTabela, int iNumeroParcelas, Decimal dValorParcela, int iVencimentoPrimeiraParcela, bool bPermiteAlteracao)
    {
      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder pCodigoTabela = new StringBuilder(String.Format("{0:d2}", iCodigoTabela));
      StringBuilder pNumeroParcelas = new StringBuilder(String.Format("{0:d2}", iNumeroParcelas));
      StringBuilder pValorParcela = new StringBuilder(FormataValorDPOS(12, dValorParcela));
      StringBuilder pVencimentoPrimeiraParcela = new StringBuilder(String.Format("{0:d2}", iVencimentoPrimeiraParcela));
      StringBuilder pPermiteAlteracao = new StringBuilder(FormataSimNaoDPOS(bPermiteAlteracao));

      if (!CarregaDLL())
      {
        return 11;
      }

      dllTransacaoCartaoParceleMaisCompleta = (_TransacaoCartaoParceleMaisCompleta)GetDelegateFromDLL("TransacaoCartaoParceleMaisCompleta", typeof(_TransacaoCartaoParceleMaisCompleta));

      int iRes = dllTransacaoCartaoParceleMaisCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, pCodigoTabela, pNumeroParcelas, pValorParcela, pVencimentoPrimeiraParcela, pPermiteAlteracao);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoVoucher(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCartaoVoucher = (_TransacaoCartaoVoucher)GetDelegateFromDLL("TransacaoCartaoVoucher", typeof(_TransacaoCartaoVoucher));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoCartaoVoucher(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCheque(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, int iQuantidadeDeCheques, int iPeriodicidadeDeCheques, DateTime dtDataPrimeiroCheque, int iCarenciaPrimeiroCheque)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCheque = (_TransacaoCheque)GetDelegateFromDLL("TransacaoCheque", typeof(_TransacaoCheque));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder pQuantidadeDeCheques = new StringBuilder(String.Format("{0:d2}", iQuantidadeDeCheques));
      StringBuilder pPeriodicidadeDeCheques = new StringBuilder(String.Format("{0:d6}", iPeriodicidadeDeCheques));
      StringBuilder pDataPrimeiroCheque = new StringBuilder(FormataDataDPOS(dtDataPrimeiroCheque));
      StringBuilder pCarenciaPrimeiroCheque = new StringBuilder(String.Format("{0:d3}", iCarenciaPrimeiroCheque));

      int iRes = dllTransacaoCheque(pValorTransacao, pNumeroCupom, pNumeroControle, pQuantidadeDeCheques, pPeriodicidadeDeCheques, pDataPrimeiroCheque, pCarenciaPrimeiroCheque);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCelular(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCelular = (_TransacaoCelular)GetDelegateFromDLL("TransacaoCelular", typeof(_TransacaoCelular));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoCelular(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCancelamentoCelular(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCancelamentoCelular = (_TransacaoCancelamentoCelular)GetDelegateFromDLL("TransacaoCancelamentoCelular", typeof(_TransacaoCancelamentoCelular));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoCancelamentoCelular(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCancelamentoGarantiaCheque(Decimal dValorTransacao, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCancelamentoGarantiaCheque = (_TransacaoCancelamentoGarantiaCheque)GetDelegateFromDLL("TransacaoCancelamentoGarantiaCheque", typeof(_TransacaoCancelamentoGarantiaCheque));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoCancelamentoGarantiaCheque(pValorTransacao, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCancelamentoPagamento(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCancelamentoPagamento = (_TransacaoCancelamentoPagamento)GetDelegateFromDLL("TransacaoCancelamentoPagamento", typeof(_TransacaoCancelamentoPagamento));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoCancelamentoPagamento(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int EstornoPreAutorizacaoRedecard(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllEstornoPreAutorizacaoRedecard = (_EstornoPreAutorizacaoRedecard)GetDelegateFromDLL("EstornoPreAutorizacaoRedecard", typeof(_EstornoPreAutorizacaoRedecard));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllEstornoPreAutorizacaoRedecard(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoConfirmacaoPreAutorizacao(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoConfirmacaoPreAutorizacao = (_TransacaoConfirmacaoPreAutorizacao)GetDelegateFromDLL("TransacaoConfirmacaoPreAutorizacao", typeof(_TransacaoConfirmacaoPreAutorizacao));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoConfirmacaoPreAutorizacao(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCancelamentoPagamentoCompleta(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, bool bPermiteAlteracao, string sReservado)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCancelamentoPagamentoCompleta = (_TransacaoCancelamentoPagamentoCompleta)GetDelegateFromDLL("TransacaoCancelamentoPagamentoCompleta", typeof(_TransacaoCancelamentoPagamentoCompleta));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder pPermiteAlteracao = new StringBuilder(FormataSimNaoDPOS(bPermiteAlteracao));
      byte[] pReservado = ASCIIEncoding.ASCII.GetBytes(String.Format("{0:-158}", sReservado).ToCharArray());

      int iRes = dllTransacaoCancelamentoPagamentoCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, pPermiteAlteracao, pReservado);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoConsultaParcelas(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoConsultaParcelas = (_TransacaoConsultaParcelas)GetDelegateFromDLL("TransacaoConsultaParcelas", typeof(_TransacaoConsultaParcelas));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      int iRes = dllTransacaoConsultaParcelas(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoConsultaParcelasCredito(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoConsultaParcelasCredito = (_TransacaoConsultaParcelasCredito)GetDelegateFromDLL("TransacaoConsultaParcelasCredito", typeof(_TransacaoConsultaParcelasCredito));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoConsultaParcelasCredito(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoConsultaParcelasCelular(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoConsultaParcelasCelular = (_TransacaoConsultaParcelasCelular)GetDelegateFromDLL("TransacaoConsultaParcelasCelular", typeof(_TransacaoConsultaParcelasCelular));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoConsultaParcelasCelular(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoPreAutorizacao(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoPreAutorizacao = (_TransacaoPreAutorizacao)GetDelegateFromDLL("TransacaoPreAutorizacao", typeof(_TransacaoPreAutorizacao));

      StringBuilder pNumeroControle = new StringBuilder("00000000");

      int iRes = dllTransacaoPreAutorizacao(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoPreAutorizacaoCartaoCredito(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoPreAutorizacaoCartaoCredito = (_TransacaoPreAutorizacaoCartaoCredito)GetDelegateFromDLL("TransacaoPreAutorizacaoCartaoCredito", typeof(_TransacaoPreAutorizacaoCartaoCredito));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoPreAutorizacaoCartaoCredito(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoPreAutorizacaoCartaoFrota(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoPreAutorizacaoCartaoFrota = (_TransacaoPreAutorizacaoCartaoFrota)GetDelegateFromDLL("TransacaoPreAutorizacaoCartaoFrota", typeof(_TransacaoPreAutorizacaoCartaoFrota));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoPreAutorizacaoCartaoFrota(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoFuncaoEspecial()
    {
      if (!CarregaDLL())
        return 11;

      dllTransacaoFuncaoEspecial = (_TransacaoFuncaoEspecial)GetDelegateFromDLL("TransacaoFuncaoEspecial", typeof(_TransacaoFuncaoEspecial));

      int iRes = dllTransacaoFuncaoEspecial();

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;

    }

    public int TransacaoResumoVendas(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoResumoVendas = (_TransacaoResumoVendas)GetDelegateFromDLL("TransacaoResumoVendas", typeof(_TransacaoResumoVendas));

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoResumoVendas(pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoCreditoCompleta(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, string sTipoOperacao, int iNumeroParcelas, Decimal dValorParcela, Decimal dValorTaxaServico, bool bPermiteAlteracao, ref string sReservado)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCartaoCreditoCompleta = (_TransacaoCartaoCreditoCompleta)GetDelegateFromDLL("TransacaoCartaoCreditoCompleto",
        typeof(_TransacaoCartaoCreditoCompleta));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder pTipoOperacao = new StringBuilder(sTipoOperacao); //[AV] À vista, [FL] Financiamento Lojista, [FA] Financiamento Administradora
      StringBuilder pNumeroParcelas = new StringBuilder(String.Format("{0:d2}", iNumeroParcelas));
      StringBuilder pValorParcela = new StringBuilder(FormataValorDPOS(12, dValorParcela));
      StringBuilder pValorTaxaServico = new StringBuilder(FormataValorDPOS(12, dValorTaxaServico));
      StringBuilder pPermiteAlteracao = new StringBuilder(FormataSimNaoDPOS(bPermiteAlteracao));
      byte[] pReservado = ASCIIEncoding.ASCII.GetBytes(String.Format("{0,-158}", sReservado).ToCharArray());

      int iRes = dllTransacaoCartaoCreditoCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, pTipoOperacao, pNumeroParcelas, pValorParcela, pValorTaxaServico, pPermiteAlteracao, pReservado);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
        sReservado = ASCIIEncoding.ASCII.GetString(pReservado);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoDebitoCompleta(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, string sTipoOperacao, int iNumeroParcelas,
      int iSequenciaParcela, DateTime dtDataDebito, Decimal dValorParcela, Decimal dValorTaxaServico, bool bPermiteAlteracao, ref string sReservado)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCartaoDebitoCompleta = (_TransacaoCartaoDebitoCompleta)GetDelegateFromDLL("TransacaoCartaoDebitoCompleta", typeof(_TransacaoCartaoDebitoCompleta));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder pTipoOperacao = new StringBuilder(sTipoOperacao); //[AV] À Vista, [PS] Parcelada (sem juros), [PC] Parcelada (com juros), [PD] Pré-datada
      StringBuilder pNumeroParcelas = new StringBuilder(String.Format("{0:d2}", iNumeroParcelas));
      StringBuilder pValorParcela = new StringBuilder(FormataValorDPOS(12, dValorParcela));
      StringBuilder pValorTaxaServico = new StringBuilder(FormataValorDPOS(12, dValorTaxaServico));
      StringBuilder pPermiteAlteracao = new StringBuilder(FormataSimNaoDPOS(bPermiteAlteracao));
      byte[] pReservado = ASCIIEncoding.ASCII.GetBytes(String.Format("{0,-148}", sReservado).ToCharArray());
      StringBuilder pSequenciaParcela = new StringBuilder(String.Format("{0:d2}", iSequenciaParcela));
      StringBuilder pDataDebito = new StringBuilder(FormataDataDPOS(dtDataDebito));

      int iRes = dllTransacaoCartaoDebitoCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, pTipoOperacao, pNumeroParcelas, pSequenciaParcela, pDataDebito,
        pValorParcela, pValorTaxaServico, pPermiteAlteracao, pReservado);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
        sReservado = ASCIIEncoding.ASCII.GetString(pReservado);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoVoucherCompleta(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, ref string sReservado)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoCartaoVoucherCompleta = (_TransacaoCartaoVoucherCompleta)GetDelegateFromDLL("TransacaoCartaoVoucherCompleta",
        typeof(_TransacaoCartaoVoucherCompleta));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      byte[] pReservado = ASCIIEncoding.ASCII.GetBytes(String.Format("{0,-187}", sReservado).ToCharArray());

      int iRes = dllTransacaoCartaoVoucherCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, pReservado);
      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
        sReservado = ASCIIEncoding.ASCII.GetString(pReservado);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoeValeGas(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, int iNumeroValeGas)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder pNumeroValeGas = new StringBuilder(String.Format("{0:d7}", iNumeroValeGas));

      dllTransacaoeValeGas = (_TransacaoeValeGas)GetDelegateFromDLL("TransacaoeValeGas", typeof(_TransacaoeValeGas));

      int iRes = dllTransacaoeValeGas(pValorTransacao, pNumeroCupom, pNumeroControle, pNumeroValeGas);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoConsultaeValeGas(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, ref int iNumeroValeGas, out string sDadosRetorno)
    {
      iNumeroControle = 0;
      sDadosRetorno = "";

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder pNumeroValeGas = new StringBuilder(String.Format("{0:d7}",iNumeroValeGas));
      byte[] pDadosRetorno = new byte[256];

      dllTransacaoConsultaeValeGas = (_TransacaoConsultaeValeGas)GetDelegateFromDLL("TransacaoConsultaeValeGas", typeof(_TransacaoConsultaeValeGas));

      int iRes = dllTransacaoConsultaeValeGas(pValorTransacao, pNumeroCupom, pNumeroControle, pNumeroValeGas, pDadosRetorno);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroValeGas = Conversor.ToIntDef(iNumeroValeGas.ToString(), 0);
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
        sDadosRetorno = ASCIIEncoding.ASCII.GetString(pDadosRetorno);
      }

      return iRes;
    }

    public int TransacaoCancelamentoPadrao(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoCancelamentoPadrao = (_TransacaoCancelamentoPadrao)GetDelegateFromDLL("TransacaoCancelamentoPadrao", typeof(_TransacaoCancelamentoPadrao));

      int iRes = dllTransacaoCancelamentoPadrao(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int ConsultaValoresPrePago(out int iNumeroControle, out string sMensagemOperador)
    {
      iNumeroControle = 0;
      sMensagemOperador = "";

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder("0000000");
      byte[] pMensagemOperador = new byte[64];

      dllConsultaValoresPrePago = (_ConsultaValoresPrePago)GetDelegateFromDLL("ConsultaValoresPrePago", typeof(_ConsultaValoresPrePago));

      int iRes = dllConsultaValoresPrePago(pNumeroControle, pMensagemOperador);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
        sMensagemOperador = ASCIIEncoding.ASCII.GetString(pMensagemOperador);
      }

      return iRes;
    }

    public int TransacaoRecargaCelular(int iCodigoArea, string sNumeroTelefone, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pCodigoArea = new StringBuilder(String.Format("{0:d2}", iCodigoArea));
      StringBuilder pNumeroTelefone = new StringBuilder(String.Format("{0:-9}", sNumeroTelefone));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoRecargaCelular = (_TransacaoRecargaCelular)GetDelegateFromDLL("TransacaoRecargaCelular", typeof(_TransacaoRecargaCelular));

      int iRes = dllTransacaoRecargaCelular(pCodigoArea, pNumeroTelefone, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoResgatePremio(int iNumeroCupom, ref int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder("000000");
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));

      dllTransacaoResgatePremio = (_TransacaoResgatePremio)GetDelegateFromDLL("TransacaoResgatePremio", typeof(_TransacaoResgatePremio));

      int iRes = dllTransacaoResgatePremio(pNumeroControle, pNumeroCupom);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoVendaPOS(string sCNPJ, string sNumeroSerie, string sCodigoFrentista, string sCPFCNPJ, bool bPagamentoTEF, string sCartaoProprio,
      Decimal dValor, string sTelefoneCliente, string sCodigoOrigem, Decimal dSaldoPontos, string sCodigoPesquisa, string sReservado, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pCNPJ = new StringBuilder(String.Format("{0:-14}", sCNPJ));
      StringBuilder pNumeroSerie = new StringBuilder(String.Format("{0:-11}", sNumeroSerie));
      StringBuilder pCodigoFrentista = new StringBuilder(String.Format("{0:-5}", sCodigoFrentista));
      StringBuilder pCPFCNPJ = new StringBuilder(String.Format("{0:-14}", sCPFCNPJ));
      StringBuilder pPagamentoTEF = new StringBuilder(FormataSimNaoDPOS(bPagamentoTEF));
      StringBuilder pCartaoProprio = new StringBuilder(String.Format("{0:-6}", sCartaoProprio));
      StringBuilder pValor = new StringBuilder(FormataValorDPOS(12, dValor));
      StringBuilder pTelefoneCliente = new StringBuilder(String.Format("{0:-10}", sTelefoneCliente));
      StringBuilder pCodigoOrigem = new StringBuilder(String.Format("{0:-5}", sCodigoOrigem));
      StringBuilder pSaldoPontos = new StringBuilder(FormataValorDPOS(12, dSaldoPontos));
      StringBuilder pCodigoPesquisa = new StringBuilder(String.Format("{0:-4}", sCodigoPesquisa));
      StringBuilder pReservado = new StringBuilder(String.Format("{0,-250}",sReservado));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoVendaPOS = (_TransacaoVendaPOS)GetDelegateFromDLL("TransacaoVendaPOS", typeof(_TransacaoVendaPOS));

      int iRes = dllTransacaoVendaPOS(pCNPJ, pNumeroSerie, pCodigoFrentista, pCPFCNPJ, pPagamentoTEF, pCartaoProprio, pValor, pTelefoneCliente,
        pCodigoOrigem, pSaldoPontos, pCodigoPesquisa, pReservado, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoEstornoVendaPOS(string sCNPJ, string sNumeroSerie, string sCodigoFrentista, string sCPFCNPJ, DateTime dtEstorno, int iNSUEstorno,
      string sAutorizacaoEstorno, Decimal dSaldoPontos, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pCNPJ = new StringBuilder(String.Format("{0:-14}", sCNPJ));
      StringBuilder pNumeroSerie = new StringBuilder(String.Format("{0:-11}", sNumeroSerie));
      StringBuilder pCodigoFrentista = new StringBuilder(String.Format("{0:-5}", sCodigoFrentista));
      StringBuilder pCPFCNPJ = new StringBuilder(String.Format("{0:-14}", sCPFCNPJ));
      StringBuilder pDataEstorno = new StringBuilder(FormataDataDPOS(dtEstorno));
      StringBuilder pNSUEstorno = new StringBuilder(String.Format("{0:d6}", iNSUEstorno));
      StringBuilder pAutorizacaoEstorno = new StringBuilder(String.Format("{0:-8}", sAutorizacaoEstorno));
      StringBuilder pSaldoPontos = new StringBuilder(FormataValorDPOS(12, dSaldoPontos));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoEstornoVendaPOS = (_TransacaoEstornoVendaPOS)GetDelegateFromDLL("TransacaoEstornoVendaPOS", typeof(_TransacaoEstornoVendaPOS));

      int iRes = dllTransacaoEstornoVendaPOS(pCNPJ, pNumeroSerie, pCodigoFrentista, pCPFCNPJ, pDataEstorno, pNSUEstorno, pAutorizacaoEstorno, pSaldoPontos, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoCargaCartao(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoCargaCartao = (_TransacaoCargaCartao)GetDelegateFromDLL("TransacaoCargaCartao", typeof(_TransacaoCargaCartao));

      int iRes = dllTransacaoCargaCartao(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoRecargaCartao(Decimal valorTransacao, string numeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder();
      pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
      StringBuilder pNumeroCupom = new StringBuilder();
      pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoRecargaCartao = (_TransacaoRecargaCartao)GetDelegateFromDLL("TransacaoRecargaCartao", typeof(_TransacaoRecargaCartao));

      int iRes = dllTransacaoRecargaCartao(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoConsultaPlanos(Decimal valorTransacao, out int iNumeroControle, string reservado, out string planos)
    {
      iNumeroControle = 0;
      planos = "";

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder();
      pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder p_reservado = new StringBuilder(reservado);
      StringBuilder p_planos = new StringBuilder(planos);

      dllTransacaoConsultaPlanos = (_TransacaoConsultaPlanos)GetDelegateFromDLL("TransacaoConsultaPlanos", typeof(_TransacaoConsultaPlanos));

      int iRes = dllTransacaoConsultaPlanos(pValorTransacao, pNumeroControle, p_reservado, p_planos);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
        planos = p_planos.ToString();
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoFrota(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoCartaoFrota = (_TransacaoCartaoFrota)GetDelegateFromDLL("TransacaoCartaoFrota", typeof(_TransacaoCartaoFrota));

      int iRes = dllTransacaoCartaoFrota(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoCrediario(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoCartaoCrediario = (_TransacaoCartaoCrediario)GetDelegateFromDLL("TransacaoCartaoCrediario", typeof(_TransacaoCartaoCrediario));

      int iRes = dllTransacaoCartaoCrediario(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoSimulacaoCrediario(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoSimulacaoCrediario = (_TransacaoSimulacaoCrediario)GetDelegateFromDLL("TransacaoSimulacaoCrediario", typeof(_TransacaoSimulacaoCrediario));

      int iRes = dllTransacaoSimulacaoCrediario(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoSimulacaoPrivateLabel(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoSimulacaoPrivateLabel = (_TransacaoSimulacaoPrivateLabel)GetDelegateFromDLL("TransacaoSimulacaoPrivateLabel", typeof(_TransacaoSimulacaoPrivateLabel));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoSimulacaoPrivateLabel(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoConsultaPrivateLabel(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoConsultaPrivateLabel = (_TransacaoConsultaPrivateLabel)GetDelegateFromDLL("TransacaoConsultaPrivateLabel", typeof(_TransacaoConsultaPrivateLabel));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoConsultaPrivateLabel(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoPagamentoPrivateLabel(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      dllTransacaoPagamentoPrivateLabel = (_TransacaoPagamentoPrivateLabel)GetDelegateFromDLL("TransacaoPagamentoPrivateLabel", typeof(_TransacaoPagamentoPrivateLabel));

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      int iRes = dllTransacaoPagamentoPrivateLabel(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoCartaoPrivateLabel(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoCartaoPrivateLabel = (_TransacaoCartaoPrivateLabel)GetDelegateFromDLL("TransacaoCartaoPrivateLabel", typeof(_TransacaoCartaoPrivateLabel));

      int iRes = dllTransacaoCartaoPrivateLabel(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoSaqueRedecard(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoSaqueRedecard = (_TransacaoSaqueRedecard)GetDelegateFromDLL("TransacaoSaqueRedecard", typeof(_TransacaoSaqueRedecard));

      int iRes = dllTransacaoSaqueRedecard(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoSaque(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoSaque = (_TransacaoSaque)GetDelegateFromDLL("TransacaoSaque", typeof(_TransacaoSaque));

      int iRes = dllTransacaoSaque(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoConsultaSaldo(int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoConsultaSaldo = (_TransacaoConsultaSaldo)GetDelegateFromDLL("TransacaoConsultaSaldo", typeof(_TransacaoConsultaSaldo));

      int iRes = dllTransacaoConsultaSaldo(pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoConsultaSaldoCelular(int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoConsultaSaldoCelular = (_TransacaoConsultaSaldoCelular)GetDelegateFromDLL("TransacaoConsultaSaldoCelular", typeof(_TransacaoConsultaSaldoCelular));

      int iRes = dllTransacaoConsultaSaldoCelular(pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoSaqueSaldo(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoSaqueSaldo = (_TransacaoSaqueSaldo)GetDelegateFromDLL("TransacaoSaqueSaldo", typeof(_TransacaoSaqueSaldo));

      int iRes = dllTransacaoSaqueSaldo(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoSaqueExtrato(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoSaqueExtrato = (_TransacaoSaqueExtrato)GetDelegateFromDLL("TransacaoSaqueExtrato", typeof(_TransacaoSaqueExtrato));

      int iRes = dllTransacaoSaqueExtrato(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }
    
    public int TransacaoQuitacaoCartaFrete(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoQuitacaoCartaFrete = (_TransacaoQuitacaoCartaFrete)GetDelegateFromDLL("TransacaoQuitacaoCartaFrete", typeof(_TransacaoQuitacaoCartaFrete));

      int iRes = dllTransacaoQuitacaoCartaFrete(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }


    #endregion

    #region funções administrativas

    public int ConfirmaCartaoFrota(int iNumeroControle)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder(String.Format("{0:d6}", iNumeroControle));

      dllConfirmaCartaoFrota = (_ConfirmaCartaoFrota)GetDelegateFromDLL("ConfirmaCartaoFrota", typeof(_ConfirmaCartaoFrota));

      int iRes = dllConfirmaCartaoFrota(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int ConfirmaCartaoCredito(int iNumeroControle)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder(String.Format("{0:d6}", iNumeroControle));

      dllConfirmaCartaoCredito = (_ConfirmaCartaoCredito)GetDelegateFromDLL("ConfirmaCartaoCredito", typeof(_ConfirmaCartaoCredito));
      int iRes = dllConfirmaCartaoCredito(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int ConfirmaCartaoDebito(int iNumeroControle)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder(String.Format("{0:d6}", iNumeroControle));

      dllConfirmaCartaoDebito = (_ConfirmaCartaoDebito)GetDelegateFromDLL("ConfirmaCartaoDebito", typeof(_ConfirmaCartaoDebito));
      int iRes = dllConfirmaCartaoDebito(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int ConfirmaCartaoVoucher(int iNumeroControle)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder(String.Format("{0:d6}", iNumeroControle));

      dllConfirmaCartaoVoucher = (_ConfirmaCartaoVoucher)GetDelegateFromDLL("ConfirmaCartaoVoucher", typeof(_ConfirmaCartaoVoucher));

      int iRes = dllConfirmaCartaoVoucher(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int ConfirmaDebitoBeneficiario(int iNumeroControle)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder(String.Format("{0:d6}", iNumeroControle));

      dllConfirmaDebitoBeneficiario = (_ConfirmaDebitoBeneficiario)GetDelegateFromDLL("ConfirmaDebitoBeneficiario", typeof(_ConfirmaDebitoBeneficiario));

      int iRes = dllConfirmaDebitoBeneficiario(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int ConfirmaCartao(int iNumeroControle)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder(String.Format("{0:d6}", iNumeroControle));

      dllConfirmaCartao = (_ConfirmaCartao)GetDelegateFromDLL("ConfirmaCartao", typeof(_ConfirmaCartao));

      int iRes = dllConfirmaCartao(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int DesfazCartao(int iNumeroControle)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder(String.Format("{0:d6}", iNumeroControle));

      dllDesfazCartao = (_DesfazCartao)GetDelegateFromDLL("DesfazCartao", typeof(_DesfazCartao));

      int iRes = dllDesfazCartao(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int FinalizaTransacao()
    {
      if (!CarregaDLL())
        return 11;

      dllFinalizaTransacao = (_FinalizaTransacao)GetDelegateFromDLL("FinalizaTransacao", typeof(_FinalizaTransacao));

      int iRes = dllFinalizaTransacao();

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;

    }
    
    public int UltimaMensagemTEF(out string sMensagem)
    {
      sMensagem = "";

      if (!CarregaDLL())
        return 11;

      byte[] pMensagem = new byte[21];

      dllUltimaMensagemTEF = (_UltimaMensagemTEF)GetDelegateFromDLL("UltimaMensagemTEF", typeof(_UltimaMensagemTEF));

      int iRes = dllUltimaMensagemTEF(pMensagem);

      if (iRes == 0)
      {
        sMensagem = ASCIIEncoding.ASCII.GetString(pMensagem);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoReimpressaoCupom()
    {
      if (!CarregaDLL())
        return 11;

      dllTransacaoReimpressaoCupom = (_TransacaoReimpressaoCupom)GetDelegateFromDLL("TransacaoReimpressaoCupom", typeof(_TransacaoReimpressaoCupom));

      int iRes = dllTransacaoReimpressaoCupom();

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int ConfiguraDPOS()
    {
      if (!CarregaDLL())
        return 11;

      dllConfiguraDPOS = (_ConfiguraDPOS)GetDelegateFromDLL("ConfiguraDPOS", typeof(_ConfiguraDPOS));

      int iRes = dllConfiguraDPOS();

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int InicializaDPOS()
    {
      if (!CarregaDLL())
        return 11;

      dllInicializaDPOS = (_InicializaDPOS)GetDelegateFromDLL("InicializaDPOS", typeof(_InicializaDPOS));

      int iRes = dllInicializaDPOS();

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int FinalizaDPOS()
    {
      if (!CarregaDLL())
        return 11;

      dllFinalizaDPOS = (_FinalizaDPOS)GetDelegateFromDLL("FinalizaDPOS", typeof(_FinalizaDPOS));

      int iRes = dllFinalizaDPOS();

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public void ObtemUltimoErro(out string sErro)
    {
      sErro = "";

      if (!CarregaDLL())
        return;

      byte[] pErro = new byte[256];

      dllObtemUltimoErro = (_ObtemUltimoErro)GetDelegateFromDLL("ObtemUltimoErro", typeof(_ObtemUltimoErro));

      int iRes = dllObtemUltimoErro(pErro);

      if (iRes == 0)
      {
        sErro = ASCIIEncoding.ASCII.GetString(pErro);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return;
    }

    public void DadosUltimaTransacaoNaoAprovada(ref string sDadosTransacaoNaoAprovada)
    {
      sDadosTransacaoNaoAprovada = "";

      if (!CarregaDLL())
        return;

      byte[] pDadosTransacaoNaoAprovada = ASCIIEncoding.ASCII.GetBytes(String.Format("{0,-512}", sDadosTransacaoNaoAprovada).ToCharArray());

      dllDadosUltimaTransacaoNaoAprovada = (_DadosUltimaTransacaoNaoAprovada)GetDelegateFromDLL("DadosUltimaTransacaoNaoAprovada",
      typeof(_DadosUltimaTransacaoNaoAprovada));

      int iRes = dllDadosUltimaTransacaoNaoAprovada(pDadosTransacaoNaoAprovada);

      if (iRes == 0)
      {
        sDadosTransacaoNaoAprovada = ASCIIEncoding.ASCII.GetString(pDadosTransacaoNaoAprovada);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return;
    }

    public int TransacaoEspecial(int iCodigoTransacao, ref string sDados)
    {
      sDados = "";

      if (!CarregaDLL())
        return 11;

      byte[] pDados = ASCIIEncoding.ASCII.GetBytes(String.Format("{0,-2048}", sDados).ToCharArray());

      int iRes = dllTransacaoEspecial(iCodigoTransacao, pDados);

      if (iRes == 0)
      {
        sDados = ASCIIEncoding.ASCII.GetString(pDados);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public void ConfiguraFluxoExternoDTEF5()
    {
      if (!CarregaDLL())
        return;

      dllConfiguraFluxoExternoDTEF5 = (_ConfiguraFluxoExternoDTEF5)GetDelegateFromDLL("ConfiguraFluxoExternoDTEF5", typeof(_ConfiguraFluxoExternoDTEF5));

      dllConfiguraFluxoExternoDTEF5();

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return;
    }

    public int TrataDesfazimento(int iTratar)
    {
      if (!CarregaDLL())
        return 11;

      dllTrataDesfazimento = (_TrataDesfazimento)GetDelegateFromDLL("TrataDesfazimento", typeof(_TrataDesfazimento));

      int iRes = dllTrataDesfazimento(iTratar);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int ConsultaTransacao(int iNumeroEmpresa, int iNumeroLoja, int iNumeroPDV, string sSolicitacao, out string sResposta, out string sMensagemErro)
    {
      sResposta = "";
      sMensagemErro = "";

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroEmpresa = new StringBuilder(String.Format("{0:d4}", iNumeroEmpresa));
      StringBuilder pNumeroLoja = new StringBuilder(String.Format("{0:d4}", iNumeroLoja));
      StringBuilder pNumeroPDV = new StringBuilder(String.Format("{0:d3}", iNumeroPDV));
      StringBuilder pSolicitacao = new StringBuilder(String.Format("{0:-102}", sSolicitacao));
      byte[] pResposta = new byte[102];
      byte[] pMensagemErro = new byte[64];

      dllConsultaTransacao = (_ConsultaTransacao)GetDelegateFromDLL("ConsultaTransacao", typeof(_ConsultaTransacao));

      int iRes = dllConsultaTransacao(pNumeroEmpresa, pNumeroLoja, pNumeroPDV, pSolicitacao, pResposta, pMensagemErro);

      if (iRes == 0)
      {
        sResposta = ASCIIEncoding.ASCII.GetString(pResposta);
        sMensagemErro = ASCIIEncoding.ASCII.GetString(pMensagemErro);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int IdentificacaoAutomacaoComercial(string sNomeAutomacao, string sVersaoAutomacao, string sReservado)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pNomeAutomacao = new StringBuilder(String.Format("{0:-20}", sNomeAutomacao));
      StringBuilder pVersaoAutomacao = new StringBuilder(String.Format("{0:-20}", sVersaoAutomacao));
      StringBuilder pReservado = new StringBuilder(String.Format("{0:-256}", sReservado));

      dllIdentificacaoAutomacaoComercial = (_IdentificacaoAutomacaoComercial)GetDelegateFromDLL("IdentificacaoAutomacaoComercial", typeof(_IdentificacaoAutomacaoComercial));

      int iRes = dllIdentificacaoAutomacaoComercial(pNomeAutomacao, pVersaoAutomacao, pReservado);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int DefineBandeiraTransacao(string sCodigoBandeira)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pCodigoBandeira = new StringBuilder(sCodigoBandeira);

      dllDefineBandeiraTransacao = (_DefineBandeiraTransacao)GetDelegateFromDLL("DefineBandeiraTransacao", typeof(_DefineBandeiraTransacao));

      int iRes = dllDefineBandeiraTransacao(pCodigoBandeira);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int DefineRedeTransacao(string sCodigoRede)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pCodigoRede = new StringBuilder(sCodigoRede);

      dllDefineRedeTransacao = (_DefineRedeTransacao)GetDelegateFromDLL("DefineRedeTransacao", typeof(_DefineRedeTransacao));

      int iRes = dllDefineRedeTransacao(pCodigoRede);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int ConfiguraEmpresaLojaPDV(int iNumeroEmpresa, int iNumeroLoja, int iNumeroPDV)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroEmpresa = new StringBuilder(String.Format("{0:d4}", iNumeroEmpresa));
      StringBuilder pNumeroLoja = new StringBuilder(String.Format("{0:d4}", iNumeroLoja));
      StringBuilder pNumeroPDV = new StringBuilder(String.Format("{0:d3}", iNumeroPDV));

      dllConfiguraEmpresaLojaPDV = (_ConfiguraEmpresaLojaPDV)GetDelegateFromDLL("ConfiguraEmpresaLojaPDV", typeof(_ConfiguraEmpresaLojaPDV));

      int iRes = dllConfiguraEmpresaLojaPDV(pNumeroEmpresa, pNumeroEmpresa, pNumeroEmpresa);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int BuscaTabelaDTEF(int iTipoTabela, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllBuscaTabelaDTEF = (_BuscaTabelaDTEF)GetDelegateFromDLL("BuscaTabelaDTEF", typeof(_BuscaTabelaDTEF));

      int iRes = dllBuscaTabelaDTEF(iTipoTabela, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int ProcuraPinPad(out string sDados)
    {
      sDados = "";

      if (!CarregaDLL())
        return 11;

      byte[] pDados = new byte[590];

      dllProcuraPinPad = (_ProcuraPinPad)GetDelegateFromDLL("ProcuraPinPad", typeof(_ProcuraPinPad));

      int iRes = dllProcuraPinPad(pDados);

      if (iRes == 0)
      {
        sDados = ASCIIEncoding.ASCII.GetString(pDados);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public int TransacaoFuncoesAdministrativas(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, string sReservado)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");
      StringBuilder pReservado = new StringBuilder(String.Format("{0:-128}", sReservado));

      dllTransacaoFuncoesAdministrativas = (_TransacaoFuncoesAdministrativas)GetDelegateFromDLL("TransacaoFuncoesAdministrativas", typeof(_TransacaoFuncoesAdministrativas));

      int iRes = dllTransacaoFuncoesAdministrativas(pValorTransacao, pNumeroCupom, pNumeroControle, pReservado);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int DefineParametroTransacao(int iCodigoParametro, string sValorParametro, int iTamanhoParametro)
    {
      if (!CarregaDLL())
        return 11;

      StringBuilder pValorParametro = new StringBuilder(sValorParametro);

      dllDefineParametroTransacao = (_DefineParametroTransacao)GetDelegateFromDLL("DefineParametroTransacao", typeof(_DefineParametroTransacao));

      int iRes = dllDefineParametroTransacao(iCodigoParametro, pValorParametro, iTamanhoParametro);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return iRes;
    }

    public void VersaoDPOS(out string sVersao)
    {
      sVersao = "";

      if (!CarregaDLL())
        return;

      StringBuilder pVersao = new StringBuilder();

      dllVersaoDPOS = (_VersaoDPOS)GetDelegateFromDLL("VersaoDPOS", typeof(_VersaoDPOS));

      dllVersaoDPOS(pVersao);

      sVersao = pVersao.ToString();

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return;
    }

    public void ObtemLogUltimaTransacao(ref string sLogUltimaTransacao)
    {
      if (!CarregaDLL())
      {
        return;
      }

      byte[] pLogUltimaTransacao = Encoding.ASCII.GetBytes(sLogUltimaTransacao.PadRight(256).ToCharArray());

      dllObtemLogUltimaTransacao = (_ObtemLogUltimaTransacao)GetDelegateFromDLL("ObtemLogUltimaTransacao", typeof(_ObtemLogUltimaTransacao));

      dllObtemLogUltimaTransacao(pLogUltimaTransacao);

      sLogUltimaTransacao = ASCIIEncoding.ASCII.GetString(pLogUltimaTransacao);
      
      if (!bManterDLLCarregada)
        DescarregaDLL();

      return;
    }

    public void ObtemLogUltimaTransacao(ref string sLogUltimaTransacao, ref string sLogUltimaTransacaoEstendido)
    {
      if (!CarregaDLL())
      {
        return;
      }

      sLogUltimaTransacaoEstendido = "LOGESTENDIDO";

      byte[] pLogUltimaTransacao = Encoding.ASCII.GetBytes(sLogUltimaTransacao.PadRight(256).ToCharArray());
      byte[] pLogUltimaTransacaoEstendido = Encoding.ASCII.GetBytes(sLogUltimaTransacaoEstendido.PadRight(256).ToCharArray());

      dllObtemLogUltimaTransacao = (_ObtemLogUltimaTransacao)GetDelegateFromDLL("ObtemLogUltimaTransacao", typeof(_ObtemLogUltimaTransacao));

      dllObtemLogUltimaTransacao(pLogUltimaTransacao);
      dllObtemLogUltimaTransacao(pLogUltimaTransacaoEstendido);

      sLogUltimaTransacao = Encoding.ASCII.GetString(pLogUltimaTransacao);
      sLogUltimaTransacaoEstendido = Encoding.ASCII.GetString(pLogUltimaTransacaoEstendido);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      return;
    }

    public void ObtemLogUltimaTransacaoTeleMarketing(int iNumeroPDV, ref string sLogUltimaTransacao)
    {
      if (!CarregaDLL())
      {
        return;
      }
      
      byte[] pLogUltimaTransacao = Encoding.ASCII.GetBytes(sLogUltimaTransacao.PadRight(257).ToCharArray());

      dllObtemLogUltimaTransacaoTeleMarketing = (_ObtemLogUltimaTransacaoTeleMarketing)GetDelegateFromDLL(
        "ObtemLogUltimaTransacaoTeleMarketing", typeof(_ObtemLogUltimaTransacaoTeleMarketing));

      dllObtemLogUltimaTransacaoTeleMarketing(iNumeroPDV, pLogUltimaTransacao);

      sLogUltimaTransacao = ASCIIEncoding.ASCII.GetString(pLogUltimaTransacao);
      
      if (!bManterDLLCarregada)
        DescarregaDLL();
    }

    public void ObtemLogUltimaTransacaoTeleMarketingMultiLoja(int iNumeroEmpresa, int iNumeroLoja, int iNumeroPDV, ref string sLogUltimaTransacao)
    {
      if (!CarregaDLL())
        return;

      StringBuilder pNumeroEmpresa = new StringBuilder(String.Format("{0:d4}", iNumeroEmpresa));
      StringBuilder pNumeroLoja = new StringBuilder(String.Format("{0:d4}", iNumeroLoja));
      StringBuilder pNumeroPDV = new StringBuilder(String.Format("{0:d3}", iNumeroPDV));

      byte[] pLogUltimaTransacao = Encoding.ASCII.GetBytes(sLogUltimaTransacao.PadRight(257).ToCharArray());

      dllObtemLogUltimaTransacaoTeleMarketingMultiLoja = (_ObtemLogUltimaTransacaoTeleMarketingMultiLoja)GetDelegateFromDLL(
        "ObtemLogUltimaTransacaoTeleMarketingMultiLoja", typeof(_ObtemLogUltimaTransacaoTeleMarketingMultiLoja));

      dllObtemLogUltimaTransacaoTeleMarketingMultiLoja(pNumeroEmpresa, pNumeroLoja, pNumeroPDV, pLogUltimaTransacao);

      sLogUltimaTransacao = ASCIIEncoding.ASCII.GetString(pLogUltimaTransacao);
      
      if (!bManterDLLCarregada)
        DescarregaDLL();
    }

    public void ObtemComprovanteTransacao(int iNumeroControle, out string sComprovante, out string sComprovanteReduzido)
    {
      sComprovante = "";
      sComprovanteReduzido = "";

      if (!CarregaDLL())
        return;

      byte[] pComprovante = new byte[2048];
      byte[] pComprovanteReduzido = new byte[320];
      StringBuilder pNumeroControle = new StringBuilder(String.Format("{0:d6}", iNumeroControle));

      dllObtemComprovanteTransacao = (_ObtemComprovanteTransacao)GetDelegateFromDLL("ObtemComprovanteTransacao", typeof(_ObtemComprovanteTransacao));

      dllObtemComprovanteTransacao(pNumeroControle, pComprovante, pComprovanteReduzido);
      
      sComprovante = ASCIIEncoding.ASCII.GetString(pComprovante);
      sComprovanteReduzido = ASCIIEncoding.ASCII.GetString(pComprovanteReduzido);
      
      if (!bManterDLLCarregada)
        DescarregaDLL();

      return;
    }

    public void DadosUltimaTransacaoDiscada(out string sDadosUltimaTransacaoDiscada)
    {
      sDadosUltimaTransacaoDiscada = "";

      if (!CarregaDLL())
        return;

      byte[] pDados = new byte[512];

      dllDadosUltimaTransacaoDiscada = (_DadosUltimaTransacaoDiscada)GetDelegateFromDLL("DadosUltimaTransacaoDiscada", typeof(_DadosUltimaTransacaoDiscada));

      dllDadosUltimaTransacaoDiscada(pDados);

      sDadosUltimaTransacaoDiscada = ASCIIEncoding.ASCII.GetString(pDados);
      
      if (!bManterDLLCarregada)
        DescarregaDLL();

      return;
    }

    public void DadosUltimaTransacaoCB(ref string sDadosUltimaTranLogTitulo)
    {
      if (!CarregaDLL())
        return;

      byte[] pDadosUltimaTranLogTitulo = ASCIIEncoding.ASCII.GetBytes(String.Format("{0,-256}", sDadosUltimaTranLogTitulo).ToCharArray());

      dllDadosUltimaTransacaoCB = (_DadosUltimaTransacaoCB)GetDelegateFromDLL("DadosUltimaTransacaoCB", typeof(_DadosUltimaTransacaoCB));

      dllDadosUltimaTransacaoCB(pDadosUltimaTranLogTitulo);

      if (pDadosUltimaTranLogTitulo != null)
      {
        sDadosUltimaTranLogTitulo = ASCIIEncoding.ASCII.GetString(pDadosUltimaTranLogTitulo);
      }

      if (!bManterDLLCarregada)
        DescarregaDLL();
    }

    public int TransacaoBloqueioCartao(int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoBloqueioCartao = (_TransacaoBloqueioCartao)GetDelegateFromDLL("TransacaoBloqueioCartao", typeof(_TransacaoBloqueioCartao));

      int iRes = dllTransacaoBloqueioCartao(pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoDesbloqueioCartao(int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoDesbloqueioCartao = (_TransacaoDesbloqueioCartao)GetDelegateFromDLL("TransacaoDesbloqueioCartao", typeof(_TransacaoDesbloqueioCartao));

      int iRes = dllTransacaoDesbloqueioCartao(pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoConsultaAVS(out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoConsultaAVS = (_TransacaoConsultaAVS)GetDelegateFromDLL("TransacaoConsultaAVS", typeof(_TransacaoConsultaAVS));

      int iRes = dllTransacaoConsultaAVS(pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    public int TransacaoSimulacaoSaque(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle)
    {
      iNumeroControle = 0;

      if (!CarregaDLL())
        return 11;

      StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
      StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
      StringBuilder pNumeroControle = new StringBuilder("0000000");

      dllTransacaoSimulacaoSaque = (_TransacaoSimulacaoSaque)GetDelegateFromDLL("TransacaoSimulacaoSaque", typeof(_TransacaoSimulacaoSaque));

      int iRes = dllTransacaoSimulacaoSaque(pValorTransacao, pNumeroCupom, pNumeroControle);

      if (!bManterDLLCarregada)
        DescarregaDLL();

      if (iRes == 0)
      {
        iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
      }

      return iRes;
    }

    #endregion

    #region funções em construção
    /*    
        public int TransacaoChequeCompleta(Decimal dValorTransacao, int iNumeroCupom, out int iNumeroControle, int iQuantidadeCheques, string sPeriodicidadeCheques, string sDataPrimeiroCheque,
          int iCarenciaPrimeiroCheque, string sTipoDocumento, int numeroDocumento, int quantidadeChequesEx, int sequenciaCheque, string camaraCompensacao, int numeroBanco,
          int sNumeroAgencia, string sNumeroContaCorrente, string sNumeroCheque, DateTime dtDataDeposito, Decimal dValorCheque, DateTime dtDataNascimentoCliente, string telefoneCliente,
          string CMC7, bool permiteAlteracao, ref string reservado)
        {
          iNumeroControle = 0;
          if (!CarregaDLL())
            return 11;

          dllTransacaoChequeCompleta = (_TransacaoChequeCompleta)GetDelegateFromDLL("TransacaoChequeCompleta", typeof(_TransacaoChequeCompleta));

          StringBuilder pValorTransacao = new StringBuilder(FormataValorDPOS(12, dValorTransacao));
          StringBuilder pNumeroCupom = new StringBuilder(String.Format("{0:d6}", iNumeroCupom));
          StringBuilder pNumeroControle = new StringBuilder("000000");
          StringBuilder p_quantidadeCheques = new StringBuilder(String.Format("{0:d3}", iQuantidadeCheques));
          StringBuilder p_periodicidadeCheques = new StringBuilder(sPeriodicidadeCheques);
          StringBuilder p_dataPrimeiroCheque = new StringBuilder(sDataPrimeiroCheque);
          StringBuilder p_carenciaPrimeiroCheque = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d3}", iCarenciaPrimeiroCheque);
          StringBuilder p_tipoDocumento = new StringBuilder(sTipoDocumento);
          StringBuilder p_numeroDocumento = new StringBuilder();
          p_numeroDocumento.AppendFormat("{0:d10}", numeroDocumento);
          StringBuilder p_quantidadeChequesEx = new StringBuilder(iQuantidadeCheques);
          StringBuilder p_sequenciaCheque = new StringBuilder(sequenciaCheque);
          StringBuilder p_camaraCompensacao = new StringBuilder(camaraCompensacao);
          StringBuilder p_numeroBanco = new StringBuilder(numeroBanco);
          StringBuilder p_numeroAgencia = new StringBuilder(sNumeroAgencia);
          StringBuilder p_numeroContaCorrente = new StringBuilder(sNumeroContaCorrente);
          StringBuilder p_numeroCheque = new StringBuilder(sNumeroCheque);
          StringBuilder p_dataDeposito = new StringBuilder(dtDataDeposito);
          StringBuilder p_valorCheque = new StringBuilder();
          p_valorCheque.AppendFormat("{0:d12}", (int)(dValorCheque * 100.0M));
          StringBuilder p_dataNascimentoCliente = new StringBuilder(dtDataNascimentoCliente);
          StringBuilder p_telefoneCliente = new StringBuilder(telefoneCliente);
          StringBuilder p_CMC7 = new StringBuilder(CMC7);
          StringBuilder p_permiteAlteração = new StringBuilder(permiteAlteracao.ToString());
          byte[] p_reservado = new byte[256];
          p_reservado = ASCIIEncoding.ASCII.GetBytes(reservado.ToCharArray());

          int iRes = dllTransacaoChequeCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, p_quantidadeCheques, p_periodicidadeCheques, p_dataPrimeiroCheque,
          p_carenciaPrimeiroCheque, p_tipoDocumento, p_numeroDocumento, p_quantidadeChequesEx, p_sequenciaCheque, p_camaraCompensacao,
          p_numeroBanco, p_numeroAgencia, p_numeroContaCorrente, p_numeroCheque, p_dataDeposito, p_valorCheque, p_dataNascimentoCliente,
          p_telefoneCliente, p_CMC7, p_permiteAlteração, p_reservado);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = p_reservado.ToString();
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoCartaoPrivateLabelCompleta(Decimal valorTransacao, int numeroCupom, out int iNumeroControle, string tipoOperacao, int numeroParcelas,
        Decimal valorParcela, Decimal valorTaxaServico, bool permiteAlteracao, ref string reservado)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          dllTransacaoCartaoPrivateLabelCompleta = (_TransacaoCartaoPrivateLabelCompleta)GetDelegateFromDLL(
          "TransacaoCartaoPrivateLabelCompleta", typeof(_TransacaoCartaoPrivateLabelCompleta));

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_tipoOperacao = new StringBuilder(tipoOperacao);
          StringBuilder pNumeroParcelas = new StringBuilder(numeroParcelas);
          StringBuilder pValorParcela = new StringBuilder();
          pValorParcela.AppendFormat("{0:d12}", (int)(valorParcela * 100.0M));
          StringBuilder p_valorTaxaServico = new StringBuilder();
          p_valorTaxaServico.AppendFormat("{0:d12}", (int)(valorTaxaServico * 100.0M));
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao.ToString());
          byte[] p_reservado = new byte[158];
          p_reservado = ASCIIEncoding.ASCII.GetBytes(reservado.ToCharArray());

          int iRes = dllTransacaoCartaoPrivateLabelCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, p_tipoOperacao, pNumeroParcelas,
          pValorParcela, p_valorTaxaServico, pPermiteAlteracao, p_reservado);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = p_reservado.ToString();
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoDebitoBeneficiario(Decimal valorTransacao, string tipoBeneficio, string numeroBeneficio, int numeroCupom, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          dllTransacaoDebitoBeneficiario = (_TransacaoDebitoBeneficiario)GetDelegateFromDLL("TransacaoDebitoBeneficiario", typeof(_TransacaoDebitoBeneficiario));

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_tipoBeneficio = new StringBuilder(tipoBeneficio);
          StringBuilder p_numeroBeneficio = new StringBuilder(numeroBeneficio);

          int iRes = dllTransacaoDebitoBeneficiario(pValorTransacao, p_tipoBeneficio, p_numeroBeneficio, pNumeroCupom, pNumeroControle);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public void ObtemInfTransacaoDebitoParcelado(out string dadosParcelas)
        {

          dadosParcelas = "";

          if (!CarregaDLL())
            return;

          byte[] p_dadosParcelas = new byte[964];
          dllObtemInfTransacaoDebitoParcelado = (_ObtemInfTransacaoDebitoParcelado)GetDelegateFromDLL("ObtemInfTransacaoDebitoParcelado", typeof(_ObtemInfTransacaoDebitoParcelado));

          int iRes = dllObtemInfTransacaoDebitoParcelado(p_dadosParcelas);

          if (iRes == 0)
          {
            dadosParcelas = p_dadosParcelas.ToString();
          }

          return;
        }

        public int ConsultaParametrosCB(out string parametros)
        {
          parametros = "";

          if (!CarregaDLL())
            return 11;

          byte[] p_parametros = new byte[255];
          dllConsultaParametrosCB = (_ConsultaParametrosCB)GetDelegateFromDLL("ConsultaParametrosCB", typeof(_ConsultaParametrosCB));

          int iRes = dllConsultaParametrosCB(p_parametros);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ConsultaPagamentoCB(string tipoConta, string codigoBarrasDigitado, string codigoBarrasLido, Decimal valorTitulo, Decimal valorDesconto,
        Decimal valorAcrescimo, string dataVencimento, string formaPagamento, string trilhaCartao, string tipoSenha, string senha, string NSUCartao,
        string TipoCMC7, string CMC7, out int iNumeroControle, out string mensagemTEF, out string imprimeComprovante, out string parametros, out string parametros2)
        {
          iNumeroControle = 0;
          mensagemTEF = "";
          imprimeComprovante = "";
          parametros2 = "";
          parametros = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_tipoConta = new StringBuilder(tipoConta);
          StringBuilder p_codigoBarrasLido = new StringBuilder(codigoBarrasLido);
          StringBuilder p_codigoBarrasDigitado = new StringBuilder(codigoBarrasDigitado);
          StringBuilder p_valorTitulo = new StringBuilder();
          p_valorTitulo.AppendFormat("{0:d12}", (int)(valorTitulo * 100.0M));
          StringBuilder p_valorDesconto = new StringBuilder();
          p_valorDesconto.AppendFormat("{0:d12}", (int)(valorDesconto * 100.0M));
          StringBuilder p_valorAcrescimo = new StringBuilder();
          p_valorAcrescimo.AppendFormat("{0:d12}", (int)(valorAcrescimo * 100.0M));
          StringBuilder p_dataVencimento = new StringBuilder(dataVencimento);
          StringBuilder p_formaPagamento = new StringBuilder(formaPagamento);
          StringBuilder p_trilhaCartao = new StringBuilder(trilhaCartao);
          StringBuilder p_tipoSenha = new StringBuilder(tipoSenha);
          StringBuilder p_senha = new StringBuilder(senha);
          StringBuilder p_NSUCartao = new StringBuilder(NSUCartao);
          StringBuilder p_tipoCMC7 = new StringBuilder(TipoCMC7);
          StringBuilder p_CMC7 = new StringBuilder(CMC7);
          StringBuilder pNumeroControle = new StringBuilder(iNumeroControle);
          byte[] p_mensagemTEF = new byte[256];
          byte[] p_imprimeComprovante = new byte[256];
          byte[] p_parametros = new byte[256];
          byte[] p_parametros2 = new byte[256];

          dllConsultaPagamentoCB = (_ConsultaPagamentoCB)GetDelegateFromDLL("ConsultaPagamentoCB", typeof(_ConsultaPagamentoCB));

          int iRes = dllConsultaPagamentoCB(p_tipoConta, p_codigoBarrasDigitado, p_codigoBarrasLido, p_valorTitulo, p_valorDesconto, p_valorAcrescimo, p_dataVencimento, p_formaPagamento,
          p_trilhaCartao, p_tipoSenha, p_senha, p_NSUCartao, p_tipoCMC7, pNumeroControle, p_mensagemTEF, p_imprimeComprovante, p_parametros, p_parametros2);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            mensagemTEF = p_mensagemTEF.ToString();
            imprimeComprovante = p_imprimeComprovante.ToString();
            parametros2 = p_parametros2.ToString();
            parametros = p_parametros.ToString();
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoPagamentoCB(string tipoConta, string codigoBarrasDigitado, string codigoBarrasLido, Decimal valorTitulo, Decimal valorDesconto,
            Decimal valorAcrescimo, string dataVencimento, string formaPagamento, string trilhaCartao, string tipoSenha, string senha, string NSUCartao,
            string TipoCMC7, string CMC7, out int iNumeroControle, out string parametros, out string parametros2)
        {
          iNumeroControle = 0;
          parametros = "";
          parametros2 = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_tipoConta = new StringBuilder(tipoConta);
          StringBuilder p_codigoBarrasLido = new StringBuilder(codigoBarrasLido);
          StringBuilder p_codigoBarrasDigitado = new StringBuilder(codigoBarrasDigitado);
          StringBuilder p_valorTitulo = new StringBuilder(valorTitulo.ToString());
          StringBuilder p_valorDesconto = new StringBuilder(valorDesconto.ToString());
          StringBuilder p_valorAcrescimo = new StringBuilder(valorAcrescimo.ToString());
          StringBuilder p_dataVencimento = new StringBuilder(dataVencimento);
          StringBuilder p_formaPagamento = new StringBuilder(formaPagamento);
          StringBuilder p_trilhaCartao = new StringBuilder(trilhaCartao);
          StringBuilder p_tipoSenha = new StringBuilder(tipoSenha);
          StringBuilder p_senha = new StringBuilder(senha);
          StringBuilder p_NSUCartao = new StringBuilder(NSUCartao);
          StringBuilder p_tipoCMC7 = new StringBuilder(TipoCMC7);
          StringBuilder p_CMC7 = new StringBuilder(CMC7);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_parametros = new StringBuilder(parametros);
          StringBuilder p_parametros2 = new StringBuilder(parametros2);

          dllTransacaoPagamentoCB = (_TransacaoPagamentoCB)GetDelegateFromDLL("TransacaoPagamentoCB", typeof(_TransacaoPagamentoCB));

          int iRes = dllTransacaoPagamentoCB(p_tipoConta, p_codigoBarrasDigitado, p_codigoBarrasLido, p_valorTitulo, p_valorDesconto, p_valorAcrescimo, p_dataVencimento, p_formaPagamento,
          p_trilhaCartao, p_tipoSenha, p_senha, p_NSUCartao, p_tipoCMC7, pNumeroControle, p_parametros, p_parametros2);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            parametros = p_parametros.ToString();
            parametros2 = p_parametros2.ToString();
          }


          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoCancelamentoCB(string tipoConta, string codigoBarrasDigitado, string codigoBarrasLido, Decimal valorTitulo, string NSUCartao, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder p_tipoConta = new StringBuilder(tipoConta);
          StringBuilder p_codigoBarrasLido = new StringBuilder(codigoBarrasLido);
          StringBuilder p_codigoBarrasDigitado = new StringBuilder(codigoBarrasDigitado);
          StringBuilder p_valorTitulo = new StringBuilder(valorTitulo.ToString());
          StringBuilder p_NSUCartao = new StringBuilder(NSUCartao);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoCancelamentoCB = (_TransacaoCancelamentoCB)GetDelegateFromDLL("TransacaoCancelamentoCB", typeof(_TransacaoCancelamentoCB));

          int iRes = dllTransacaoCancelamentoCB(p_tipoConta, p_codigoBarrasDigitado, p_codigoBarrasLido, p_valorTitulo, p_NSUCartao, pNumeroControle);
          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int InicializaSessaoCB(out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllInicializaSessaoCB = (_InicializaSessaoCB)GetDelegateFromDLL("InicializaSessaoCB", typeof(_InicializaSessaoCB));

          int iRes = dllInicializaSessaoCB(pNumeroControle);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int FinalizaSessaoCB(out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllFinalizaSessaoCB = (_FinalizaSessaoCB)GetDelegateFromDLL("FinalizaSessaoCB", typeof(_FinalizaSessaoCB));

          int iRes = dllFinalizaSessaoCB(pNumeroControle);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoResumoRecebimentosCB(string tipoRecebimento, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder p_tipoRecebimento = new StringBuilder(tipoRecebimento);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoResumoRecebimentosCB = (_TransacaoResumoRecebimentosCB)GetDelegateFromDLL("TransacaoResumoRecebimentosCB", typeof(_TransacaoResumoRecebimentosCB));

          int iRes = dllTransacaoResumoRecebimentosCB(p_tipoRecebimento, pNumeroControle);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoFechamento(String dataMovimento, int quantidadeVendas, Decimal valorTotalVendas, int quantidadeVendasCanceladas, Decimal valorTotalVendasCanceladas,
        out string reservado, out int iNumeroControle, out string mensagemOperador)
        {
          iNumeroControle = 0;
          mensagemOperador = "";
          reservado = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_dataMovimento = new StringBuilder(dataMovimento);
          StringBuilder p_quantidadeVendas = new StringBuilder(quantidadeVendas);
          StringBuilder p_valorTotalVendas = new StringBuilder(valorTotalVendas.ToString());
          StringBuilder p_quantidadeVendasCanceladas = new StringBuilder(quantidadeVendasCanceladas);
          StringBuilder p_valorTotalVendasCanceladas = new StringBuilder(valorTotalVendasCanceladas.ToString());
          byte[] p_reservado = new byte[255];
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] p_mensagemOperador = new byte[64];


          dllTransacaoFechamento = (_TransacaoFechamento)GetDelegateFromDLL("TransacaoFechamento", typeof(_TransacaoFechamento));

          int iRes = dllTransacaoFechamento(p_dataMovimento, p_quantidadeVendas, p_valorTotalVendas, p_quantidadeVendasCanceladas, p_valorTotalVendasCanceladas,
          p_reservado, pNumeroControle, p_mensagemOperador);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoColeta(int tipoCartao, Decimal valorTransacao, out string trilha1, out string trilha2, out string trilha3, string parametros)
        {
          trilha1 = "";
          trilha2 = "";
          trilha3 = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_tipoCartao = new StringBuilder(tipoCartao);
          StringBuilder pValorTransacao = new StringBuilder(valorTransacao.ToString());
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          byte[] p_trilha1 = new byte[256];
          byte[] p_trilha2 = new byte[256];
          byte[] p_trilha3 = new byte[256];
          StringBuilder p_parametros = new StringBuilder(parametros);

          dllTransacaoColeta = (_TransacaoColeta)GetDelegateFromDLL("TransacaoColeta", typeof(_TransacaoColeta));

          int iRes = dllTransacaoColeta(p_tipoCartao, pValorTransacao, p_trilha1, p_trilha2, p_trilha3, p_parametros);

          if (iRes == 0)
          {
            trilha1 = ASCIIEncoding.ASCII.GetString(p_trilha1);
            trilha2 = ASCIIEncoding.ASCII.GetString(p_trilha2);
            trilha3 = ASCIIEncoding.ASCII.GetString(p_trilha3);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoColetaCartao(int tipoCartao, out string trilha1, out string trilha2, out string trilha3)
        {

          trilha1 = "";
          trilha2 = "";
          trilha3 = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_tipoCartao = new StringBuilder();
          byte[] p_trilha1 = new byte[256];
          byte[] p_trilha2 = new byte[256];
          byte[] p_trilha3 = new byte[256];

          dllTransacaoColetaCartao = (_TransacaoColetaCartao)GetDelegateFromDLL("TransacaoColetaCartao", typeof(_TransacaoColetaCartao));

          int iRes = dllTransacaoColetaCartao(p_tipoCartao, p_trilha1, p_trilha2, p_trilha3);

          if (iRes == 0)
          {
            trilha1 = ASCIIEncoding.ASCII.GetString(p_trilha1);
            trilha2 = ASCIIEncoding.ASCII.GetString(p_trilha2);
            trilha3 = ASCIIEncoding.ASCII.GetString(p_trilha3);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoColetaSenha(Decimal valor, out string senha)
        {
          senha = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_valor = new StringBuilder();

          byte[] p_senha = new byte[128];

          dllTransacaoColetaSenha = (_TransacaoColetaSenha)GetDelegateFromDLL("TransacaoColetaSenha", typeof(_TransacaoColetaSenha));

          int iRes = dllTransacaoColetaSenha(p_valor, p_senha);

          if (iRes == 0)
          {
            senha = ASCIIEncoding.ASCII.GetString(p_senha);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoColetaSenhaCartao(int nTipoCartao, Decimal valor, ref string trilha2, ref string reservado, ref string senha)
        {
          if (!CarregaDLL())
            return 11;

          StringBuilder p_tipoCartao = new StringBuilder(nTipoCartao);
          StringBuilder p_valor = new StringBuilder();
          p_valor.AppendFormat("{0:d12}", (int)(valor * 100.0M));
          byte[] p_trilha2 = ASCIIEncoding.ASCII.GetBytes(trilha2.ToCharArray());
          byte[] p_reservado = ASCIIEncoding.ASCII.GetBytes(reservado.ToCharArray());
          byte[] p_senha = new byte[256];

          dllTransacaoColetaSenhaCartao = (_TransacaoColetaSenhaCartao)GetDelegateFromDLL("TransacaoColetaSenhaCartao", typeof(_TransacaoColetaSenhaCartao));

          int iRes = dllTransacaoColetaSenhaCartao(p_tipoCartao, p_valor, p_trilha2, p_reservado, p_senha);
          if (iRes == 0)
          {
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            senha = ASCIIEncoding.ASCII.GetString(p_senha);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ColetaPlanoPagamento(string descricaoFormaPagamento, Decimal valorTransacao, int numeroCupom, string tipoFormaPagamento, out int iNumeroControle,
          ref int numeroParcelas, ref Decimal valorAcrescimo, ref Decimal valorEntrada, ref Decimal valorTotal, ref string codigoPlano, ref string plano, ref string parcelas)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder p_descricaoFormaPagamento = new StringBuilder();
          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_tipoFormaPagamento = new StringBuilder(tipoFormaPagamento);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pNumeroParcelas = new StringBuilder(numeroParcelas);
          StringBuilder p_valorAcrescimo = new StringBuilder(valorAcrescimo.ToString());
          StringBuilder p_valorEntrada = new StringBuilder(valorEntrada.ToString());
          StringBuilder p_valorTotal = new StringBuilder(valorTotal.ToString());
          StringBuilder p_codigoPlano = new StringBuilder(codigoPlano);
          StringBuilder p_plano = new StringBuilder(plano);
          StringBuilder p_parcelas = new StringBuilder(parcelas);

          dllColetaPlanoPagamento = (_ColetaPlanoPagamento)GetDelegateFromDLL("ColetaPlanoPagamento", typeof(_ColetaPlanoPagamento));

          int iRes = dllColetaPlanoPagamento(p_descricaoFormaPagamento, pValorTransacao, pNumeroCupom, p_tipoFormaPagamento, pNumeroControle, pNumeroParcelas,
          p_valorAcrescimo, p_valorEntrada, p_valorTotal, p_codigoPlano, p_plano, p_parcelas);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            numeroParcelas = Conversor.ToIntDef(pNumeroParcelas.ToString(), 0);
            valorAcrescimo = Conversor.ToDecimalDef(p_valorAcrescimo, 0);
            valorEntrada = Conversor.ToDecimalDef(p_valorEntrada, 0);
            valorTotal = Conversor.ToDecimalDef(p_valorTotal, 0);
            codigoPlano = p_codigoPlano.ToString();
            plano = p_plano.ToString();
            parcelas = p_parcelas.ToString();
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoAdministrativaTEFDiscado(out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoAdministrativaTEFDiscado = (_TransacaoAdministrativaTEFDiscado)GetDelegateFromDLL("TransacaoAdministrativaTEFDiscado", typeof(_TransacaoAdministrativaTEFDiscado));

          int iRes = dllTransacaoAdministrativaTEFDiscado(pNumeroControle);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        //ExportaPlanos
        public void ExportaPlanos()
        {
          if (!CarregaDLL())
            return;

          dllExportaPlanos = (_ExportaPlanos)GetDelegateFromDLL("ExportaPlanos", typeof(_ExportaPlanos));

          dllExportaPlanos();

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return;
        }

        public int TransacaoQuantidade(Decimal valorTransacao, Decimal valorTransacaoMaximo, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pValorTransacaoMaximo = new StringBuilder();
          pValorTransacaoMaximo.AppendFormat("{0:d12}", (int)(valorTransacaoMaximo * 100.0M));
          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));

          dllTransacaoQuantidade = (_TransacaoQuantidade)GetDelegateFromDLL("TransacaoQuantidade", typeof(_TransacaoQuantidade));

          int iRes = dllTransacaoQuantidade(pValorTransacao, pValorTransacaoMaximo, pNumeroControle);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ColetaChequesPre(out string descricaoPlanoPagamento, out string parcelas)
        {
          descricaoPlanoPagamento = "";
          parcelas = "";

          if (!CarregaDLL())
            return 11;

          byte[] p_descricaoPlanoPagamento = new byte[4097];
          byte[] p_parcelas = new byte[2048];

          dllColetaChequesPre = (_ColetaChequesPre)GetDelegateFromDLL("ColetaChequesPre", typeof(_ColetaChequesPre));

          int iRes = dllColetaChequesPre(p_descricaoPlanoPagamento, p_parcelas);

          if (iRes == 0)
          {
            parcelas = ASCIIEncoding.ASCII.GetString(p_parcelas);
            descricaoPlanoPagamento = ASCIIEncoding.ASCII.GetString(p_descricaoPlanoPagamento);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoValor(Decimal valorTransacao, Decimal valorTransacaoMaximo, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pValorTransacaoMaximo = new StringBuilder();
          pValorTransacaoMaximo.AppendFormat("{0:d12}", (int)(valorTransacaoMaximo * 100.0M));
          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));

          dllTransacaoValor = (_TransacaoValor)GetDelegateFromDLL("TransacaoValor", typeof(_TransacaoValor));

          int iRes = dllTransacaoValor(pValorTransacao, pValorTransacaoMaximo, pNumeroControle);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoCartaoCreditoConfirmada(string multiLoja, int numeroLoja, int numeroPDV, Decimal valorTransacao, int numeroCupom, out int iNumeroControle,
          string numeroCartao, String dataVencimento, string CVV2, string tipoOperacao, int numeroParcelas, Decimal valorTaxaServico, out string mensagemTEF, out string reservado)
        {
          iNumeroControle = 0;
          reservado = "";
          mensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder(numeroCupom.ToString());
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao.ToString());
          StringBuilder p_dataVencimento = new StringBuilder(dataVencimento.ToString());
          StringBuilder p_CVV2 = new StringBuilder(CVV2.ToString());
          StringBuilder p_tipoOperacao = new StringBuilder(tipoOperacao);
          StringBuilder pNumeroParcelas = new StringBuilder(numeroParcelas);
          StringBuilder p_valorTaxaServico = new StringBuilder();
          p_valorTaxaServico.AppendFormat("{0:d12}", (int)(valorTaxaServico * 100.0M));
          byte[] p_mensagemTEF = new byte[64];
          byte[] p_reservado = new byte[255];
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoCartaoCreditoConfirmada = (_TransacaoCartaoCreditoConfirmada)GetDelegateFromDLL("TransacaoCartaoCreditoConfirmada", typeof(_TransacaoCartaoCreditoConfirmada));

          int iRes = dllTransacaoCartaoCreditoConfirmada(p_multiLoja, p_numeroLoja, p_numeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle, p_numeroCartao, p_dataVencimento,
          p_CVV2, p_tipoOperacao, pNumeroParcelas, p_valorTaxaServico, p_mensagemTEF, p_reservado);

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoCancelamentoConfirmada(string multiLoja, int numeroLoja, int numeroPDV, Decimal valorTransacao, out int iNumeroControle,
        string numeroCartao, out string mensagemTEF, ref string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          byte[] p_mensagemTEF = new byte[64];
          byte[] p_reservado = new byte[148];
          p_reservado = ASCIIEncoding.ASCII.GetBytes(reservado.ToCharArray());
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoCancelamentoConfirmada = (_TransacaoCancelamentoConfirmada)GetDelegateFromDLL("TransacaoCancelamentoConfirmada",
            typeof(_TransacaoCancelamentoConfirmada));

          int iRes = dllTransacaoCancelamentoConfirmada(p_multiLoja, p_numeroLoja, p_numeroPDV, pValorTransacao, pNumeroControle,
            p_numeroCartao, p_mensagemTEF, p_reservado);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);

          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int PreAutorizacaoCreditoConfirmada(string multiLoja, int numeroLoja, int numeroPDV, Decimal valorTransacao, int numeroCupom, out int iNumeroControle,
        string numeroCartao, String dataVencimento, string CVV2, Decimal valorTaxaServico, string numeroAutorizacao, out string mensagemTEF, out string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";
          reservado = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder p_dataVencimento = new StringBuilder(dataVencimento);
          StringBuilder p_CVV2 = new StringBuilder(CVV2);
          StringBuilder p_numeroAutorizacao = new StringBuilder(numeroAutorizacao);
          StringBuilder p_valorTaxaServico = new StringBuilder();
          p_valorTaxaServico.AppendFormat("{0:d12}", (int)(valorTaxaServico * 100.0M));
          byte[] p_mensagemTEF = new byte[64];
          byte[] p_reservado = new byte[255];
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllPreAutorizacaoCreditoConfirmada = (_PreAutorizacaoCreditoConfirmada)GetDelegateFromDLL("PreAutorizacaoCreditoConfirmada", typeof(_PreAutorizacaoCreditoConfirmada));

          int iRes = dllPreAutorizacaoCreditoConfirmada(p_multiLoja, p_numeroLoja, p_numeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle, p_numeroCartao, p_dataVencimento,
          p_CVV2, p_valorTaxaServico, p_numeroAutorizacao, p_mensagemTEF, p_reservado);

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ConfPreAutorizacaoCreditoConfirmada(string multiLoja, int numeroLoja, int numeroPDV, Decimal valorTransacao, int numeroCupom, out int iNumeroControle,
        String dataPreAutor, string numeroCartao, string dataVencimento, string CVV2, string tipoOperacao, int numeroParcelas, out string mensagemTEF, ref string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_dataPreAutor = new StringBuilder(dataPreAutor);
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder p_dataVencimento = new StringBuilder(dataVencimento);
          StringBuilder p_CVV2 = new StringBuilder(CVV2);
          StringBuilder p_tipoOperacao = new StringBuilder(tipoOperacao);
          byte[] p_mensagemTEF = new byte[64];
          byte[] p_reservado = new byte[255];
          p_reservado = ASCIIEncoding.ASCII.GetBytes(reservado);
          StringBuilder pNumeroParcelas = new StringBuilder(numeroParcelas);

          dllConfPreAutorizacaoCreditoConfirmada = (_ConfPreAutorizacaoCreditoConfirmada)GetDelegateFromDLL("ConfPreAutorizacaoCreditoConfirmada",
            typeof(_ConfPreAutorizacaoCreditoConfirmada));

          int iRes = dllConfPreAutorizacaoCreditoConfirmada(p_multiLoja, p_numeroLoja, p_numeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle,
            p_dataPreAutor, p_numeroCartao, p_dataVencimento, p_CVV2, p_tipoOperacao, pNumeroParcelas, p_mensagemTEF, p_reservado);

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoCartaoFidelidade(Decimal valorTransacao, int numeroCupom, string compraPontos, int quantidadeItensTaxaVariavel, string itensTaxaVariavel,
          out int iNumeroControle)
        {
          iNumeroControle = 0;
          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_compraPontos = new StringBuilder(compraPontos);
          StringBuilder p_quantidadeItensTaxaVariavel = new StringBuilder(quantidadeItensTaxaVariavel);
          StringBuilder p_itensTaxaVariavel = new StringBuilder(itensTaxaVariavel);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoCartaoFidelidade = (_TransacaoCartaoFidelidade)GetDelegateFromDLL("TransacaoManualPOS", typeof(_TransacaoManualPOS));

          int iRes = dllTransacaoCartaoFidelidade(pValorTransacao, pNumeroCupom, p_compraPontos, p_quantidadeItensTaxaVariavel, p_itensTaxaVariavel, pNumeroControle);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoDebitoFidelidade(Decimal valorTransacao, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoDebitoFidelidade = (_TransacaoDebitoFidelidade)GetDelegateFromDLL("TransacaoDebitoFidelidade", typeof(_TransacaoDebitoFidelidade));

          int iRes = dllTransacaoDebitoFidelidade(pValorTransacao, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int ConfirmaCartaoFidelidade(int iNumeroControle)
        {

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder(iNumeroControle);

          dllConfirmaCartaoFidelidade = (_ConfirmaCartaoFidelidade)GetDelegateFromDLL("ConfirmaCartaoFidelidade", typeof(_ConfirmaCartaoFidelidade));

          int iRes = dllConfirmaCartaoFidelidade(pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ExtratoCartaoAutorizadorDirecao(string numeroCartao, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllExtratoCartaoAutorizadorDirecao = (_ExtratoCartaoAutorizadorDirecao)GetDelegateFromDLL("ExtratoCartaoAutorizadorDirecao",
            typeof(_ExtratoCartaoAutorizadorDirecao));

          int iRes = dllExtratoCartaoAutorizadorDirecao(p_numeroCartao, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int RecebimentoAutorizadorDirecao(Decimal valorTransacao, string numeroCartao, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllRecebimentoAutorizadorDirecao = (_RecebimentoAutorizadorDirecao)GetDelegateFromDLL("RecebimentoAutorizadorDirecao", typeof(_RecebimentoAutorizadorDirecao));

          int iRes = dllRecebimentoAutorizadorDirecao(pValorTransacao, p_numeroCartao, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int EstornoRecebimentoAutorizadorDirecao(Decimal valorTransacao, string numeroCartao, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllEstornoRecebimentoAutorizadorDirecao = (_EstornoRecebimentoAutorizadorDirecao)GetDelegateFromDLL("EstornoRecebimentoAutorizadorDirecao", typeof(_EstornoRecebimentoAutorizadorDirecao));

          int iRes = dllEstornoRecebimentoAutorizadorDirecao(pValorTransacao, p_numeroCartao, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int RecebimentoCarneAutorizadorDirecao(Decimal valorTransacao, string numeroCartao, string dataVencimento, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_dataVencimento = new StringBuilder(dataVencimento);

          dllRecebimentoCarneAutorizadorDirecao = (_RecebimentoCarneAutorizadorDirecao)GetDelegateFromDLL("RecebimentoCarneAutorizadorDirecao", typeof(_RecebimentoCarneAutorizadorDirecao));

          int iRes = dllRecebimentoCarneAutorizadorDirecao(pValorTransacao, p_numeroCartao, p_dataVencimento, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoPagamentoConvenio(Decimal valorTransacao, string numeroCartao, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoPagamentoConvenio = (_TransacaoPagamentoConvenio)GetDelegateFromDLL("TransacaoPagamentoConvenio", typeof(_TransacaoPagamentoConvenio));

          int iRes = dllTransacaoPagamentoConvenio(pValorTransacao, p_numeroCartao, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int ConfirmaConvenio(int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllConfirmaConvenio = (_ConfirmaConvenio)GetDelegateFromDLL("ConfirmaConvenio", typeof(_ConfirmaConvenio));

          int iRes = dllConfirmaConvenio(pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoCDC1MIN(Decimal valorTransacao, string numeroCartao, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_numeroCartao = new StringBuilder(iNumeroControle);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoCDC1MIN = (_TransacaoCDC1MIN)GetDelegateFromDLL("TransacaoCDC1MIN", typeof(_TransacaoCDC1MIN));

          int iRes = dllTransacaoCDC1MIN(pValorTransacao, p_numeroCartao, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoSIMparcelado(Decimal valorTransacao, string numeroCartao, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoSIMparcelado = (_TransacaoSIMparcelado)GetDelegateFromDLL("TransacaoSIMparcelado", typeof(_TransacaoSIMparcelado));

          int iRes = dllTransacaoSIMparcelado(pValorTransacao, p_numeroCartao, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoCartaoCreditoIATA(Decimal valorTransacao, string numeroCartao, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_numeroCartao = new StringBuilder(iNumeroControle);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoCartaoCreditoIATA = (_TransacaoCartaoCreditoIATA)GetDelegateFromDLL("TransacaoCartaoCreditoIATA", typeof(_TransacaoCartaoCreditoIATA));

          int iRes = dllTransacaoCartaoCreditoIATA(pValorTransacao, p_numeroCartao, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoCartaoCreditoIATAConfirmada(string multiLoja, int numeroLoja, int numeroPDV, Decimal valorTransacao, int numeroCupom,
        out int iNumeroControle, string numeroCartao, string dataVencimento, string CVV2, string tipoOperacao, string numeroParcelas, string valorTaxaServico,
        string valorEntrada, out string mensagemTEF, out string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";
          reservado = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder(numeroCupom);
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder p_dataVencimento = new StringBuilder(dataVencimento);
          StringBuilder p_CVV2 = new StringBuilder(CVV2);
          StringBuilder p_tipoOperacao = new StringBuilder(tipoOperacao);
          StringBuilder pNumeroParcelas = new StringBuilder(numeroParcelas);
          StringBuilder p_valorTaxaServico = new StringBuilder();
          p_valorTaxaServico.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_valorEntrada = new StringBuilder();
          p_valorEntrada.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          byte[] p_mensagemTEF = new byte[64];
          byte[] p_reservado = new byte[255];

          dllTransacaoCartaoCreditoIATAConfirmada = (_TransacaoCartaoCreditoIATAConfirmada)GetDelegateFromDLL("TransacaoCartaoCreditoIATAConfirmada", typeof(_TransacaoCartaoCreditoIATAConfirmada));

          int iRes = dllTransacaoCartaoCreditoIATAConfirmada(p_multiLoja, p_numeroLoja, p_numeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle, p_numeroCartao, p_dataVencimento, p_CVV2,
          p_tipoOperacao, pNumeroParcelas, p_valorTaxaServico, p_valorEntrada, p_mensagemTEF, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
          }

          return iRes;
        }

        public int TransacaoConsultaSaldoCompleta(int numeroCupom, out int iNumeroControle, string tipoCartao, bool permiteAlteracao, out string reservado)
        {
          iNumeroControle = 0;
          reservado = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_tipoCartao = new StringBuilder(tipoCartao);
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao.ToString());
          byte[] p_reservado = new byte[158];

          dllTransacaoConsultaSaldoCompleta = (_TransacaoConsultaSaldoCompleta)GetDelegateFromDLL("TransacaoConsultaSaldoCompleta", typeof(_TransacaoConsultaSaldoCompleta));

          int iRes = dllTransacaoConsultaSaldoCompleta(pNumeroCupom, pNumeroControle, p_tipoCartao, pPermiteAlteracao, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int ColetaCartaoDebito(Decimal valorTransacao, int numeroCupom, string parametrosTEF, string mensagemOperador)
        {
          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_parametrosTEF = new StringBuilder(parametrosTEF);
          StringBuilder p_mensagemOperador = new StringBuilder(mensagemOperador);

          dllColetaCartaoDebito = (_ColetaCartaoDebito)GetDelegateFromDLL("ColetaCartaoDebito", typeof(_ColetaCartaoDebito));

          int iRes = dllColetaCartaoDebito(pValorTransacao, pNumeroCupom, p_parametrosTEF, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ConsisteDadosCartaoDebito(string ultimosDigitos, string codigoSeguranca, string mensagemOperador)
        {
          if (!CarregaDLL())
            return 11;

          StringBuilder p_ultimosDigitos = new StringBuilder(ultimosDigitos);
          StringBuilder p_codigoSeguranca = new StringBuilder(codigoSeguranca);
          byte[] p_mensagemOperador = new byte[64];

          dllConsisteDadosCartaoDebito = (_ConsisteDadosCartaoDebito)GetDelegateFromDLL("ConsisteDadosCartaoDebito", typeof(_ConsisteDadosCartaoDebito));

          int iRes = dllConsisteDadosCartaoDebito(p_ultimosDigitos, p_codigoSeguranca, p_mensagemOperador);

          if (iRes == 0)
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ColetaSenhaCartaoDebito(out int iNumeroControle, out string mensagemOperador)
        {
          iNumeroControle = 0;
          mensagemOperador = "";

          if (!CarregaDLL())
            return 11;

          byte[] p_mensagemOperador = new byte[64];
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllColetaSenhaCartaoDebito = (_ColetaSenhaCartaoDebito)GetDelegateFromDLL("ColetaSenhaCartaoDebito", typeof(_ColetaSenhaCartaoDebito));

          int iRes = dllColetaSenhaCartaoDebito(pNumeroControle, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
          }

          return iRes;
        }

        public int ConsultaParametrosPBM(int numeroCupom, out int quantidadeRedes, out string dadosRedes, out string mensagemOperador)
        {
          quantidadeRedes = 0;
          dadosRedes = "";
          mensagemOperador = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          byte[] p_quantidadeRedes = new byte[3];
          byte[] p_dadosRedes = new byte[560];
          byte[] p_mensagemOperador = new byte[64];

          dllConsultaParametrosPBM = (_ConsultaParametrosPBM)GetDelegateFromDLL("ConsultaParametrosPBM", typeof(_ConsultaParametrosPBM));

          int iRes = dllConsultaParametrosPBM(pNumeroCupom, p_quantidadeRedes, p_dadosRedes, p_mensagemOperador);

          if (iRes == 0)
          {
            quantidadeRedes = Conversor.ToIntDef(p_quantidadeRedes.ToString(), 0);
            dadosRedes = ASCIIEncoding.ASCII.GetString(p_dadosRedes);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ConsultaProdutosPBM(int numeroCupom, string redePBM, string trilha1, string trilha2, string digitado, string autorizacao, out string dadosCRM,
        out int tipoVenda, out Decimal valorTotalMedicamentos, out Decimal valorVista, out Decimal valorCartao, out string codigoCredenciado, out int quantidadeMedicamentos,
        string medicamentos, out string reservado, out int iNumeroControle, out string mensagemOperador)
        {
          iNumeroControle = 0;
          tipoVenda = 0;
          valorTotalMedicamentos = 0;
          valorVista = 0;
          valorCartao = 0;
          codigoCredenciado = "";
          quantidadeMedicamentos = 0;
          reservado = "";
          mensagemOperador = "";
          dadosCRM = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroCupom = new StringBuilder(numeroCupom);
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_trilha1 = new StringBuilder(trilha1);
          StringBuilder p_trilha2 = new StringBuilder(trilha2);
          StringBuilder p_digitado = new StringBuilder(digitado);
          StringBuilder p_autorizacao = new StringBuilder(autorizacao);
          byte[] p_dadosCRM = new byte[13];
          int p_tipoVenda = 0;
          byte[] p_valorTotalMedicamentos = new byte[13];
          byte[] p_valorVista = new byte[12];
          byte[] p_valorCartao = new byte[12];
          byte[] p_codigoCredenciado = new byte[15];
          byte[] p_quantidadeMedicamentos = new byte[3];
          p_quantidadeMedicamentos = ASCIIEncoding.ASCII.GetBytes(quantidadeMedicamentos.ToString().ToCharArray());
          byte[] p_medicamentos = new byte[4261];
          p_medicamentos = ASCIIEncoding.ASCII.GetBytes(medicamentos.ToCharArray());
          byte[] p_reservado = new byte[128];
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] p_mensagemOperador = new byte[64];

          dllConsultaProdutosPBM = (_ConsultaProdutosPBM)GetDelegateFromDLL("ConsultaProdutosPBM", typeof(_ConsultaProdutosPBM));

          int iRes = dllConsultaProdutosPBM(pNumeroCupom, p_redePBM, p_trilha1, p_trilha2, p_digitado, p_autorizacao, p_dadosCRM, p_tipoVenda, p_valorTotalMedicamentos,
          p_valorVista, p_valorCartao, p_codigoCredenciado, p_quantidadeMedicamentos, p_medicamentos, p_reservado, pNumeroControle, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            tipoVenda = p_tipoVenda;
            valorTotalMedicamentos = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(p_valorTotalMedicamentos), 0);
            valorVista = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(p_valorVista), 0);
            valorCartao = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(p_valorCartao), 0);
            codigoCredenciado = ASCIIEncoding.ASCII.GetString(p_codigoCredenciado);
            quantidadeMedicamentos = Conversor.ToIntDef(ASCIIEncoding.ASCII.GetString(p_quantidadeMedicamentos), 0);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            dadosCRM = ASCIIEncoding.ASCII.GetString(p_dadosCRM);
            medicamentos = ASCIIEncoding.ASCII.GetString(p_medicamentos);
          }

          return iRes;
        }

        public int TransacaoVendaPBM(Decimal valorTotalMedicamentos, int numeroCupom, string redePBM, string trilha1, string trilha2, string digitado,
        string autorizacao, string NSUConsulta, string dadosCRM, string tipoVenda, Decimal valorVista, Decimal valorCartao, string codigoCredenciado,
        string regraNegocio, ref int quantidadeMedicamentos, ref string medicamentos, out string reservado, out int iNumeroControle, string numeroControleRede,
        out string mensagemOperador)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
          {
            reservado = "";
            mensagemOperador = "";
            return 11;
          }

          StringBuilder p_valorTotalMedicamentos = new StringBuilder();
          p_valorTotalMedicamentos.AppendFormat("{0:d12}", (int)(valorTotalMedicamentos * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_trilha1 = new StringBuilder(trilha1);
          StringBuilder p_trilha2 = new StringBuilder(trilha2);
          StringBuilder p_digitado = new StringBuilder(digitado);
          StringBuilder p_autorizacao = new StringBuilder(autorizacao);
          StringBuilder p_NSUConsulta = new StringBuilder(NSUConsulta);
          StringBuilder p_dadosCRM = new StringBuilder(dadosCRM);
          StringBuilder p_tipoVenda = new StringBuilder(tipoVenda);
          StringBuilder p_valorVista = new StringBuilder();
          p_valorVista.AppendFormat("{0:d12}", (int)(valorVista * 100.0M));
          StringBuilder p_valorCartao = new StringBuilder();
          p_valorCartao.AppendFormat("{0:d12}", (int)(valorCartao * 100.0M));
          StringBuilder p_codigoCredenciado = new StringBuilder(codigoCredenciado);
          StringBuilder p_regraNegocio = new StringBuilder(regraNegocio);
          byte[] p_quantidadeMedicamentos = ASCIIEncoding.ASCII.GetBytes(quantidadeMedicamentos.ToString().ToCharArray());
          byte[] p_medicamentos = new byte[4261];
          p_medicamentos = ASCIIEncoding.ASCII.GetBytes(medicamentos.ToCharArray());
          byte[] p_reservado = new byte[128];
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pNumeroControleRede = new StringBuilder(numeroControleRede);
          byte[] p_mensagemOperador = new byte[64];

          dllTransacaoVendaPBM = (_TransacaoVendaPBM)GetDelegateFromDLL("TransacaoVendaPBM", typeof(_TransacaoVendaPBM));

          int iRes = dllTransacaoVendaPBM(p_valorTotalMedicamentos, pNumeroCupom, p_redePBM, p_trilha1, p_trilha2, p_digitado, p_autorizacao, p_NSUConsulta,
          p_dadosCRM, p_tipoVenda, p_valorVista, p_valorCartao, p_codigoCredenciado, p_regraNegocio, p_quantidadeMedicamentos, p_medicamentos, p_reservado,
          pNumeroControle, pNumeroControleRede, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            quantidadeMedicamentos = Conversor.ToIntDef(p_quantidadeMedicamentos.ToString(), 0);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            medicamentos = ASCIIEncoding.ASCII.GetString(p_medicamentos);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
          }
          else
          {
            reservado = "";
            mensagemOperador = "";
          }

          return iRes;
        }

        public int ConfirmaVendaPBM(int iNumeroControle)
        {
          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");
          pNumeroControle.AppendFormat("{0:D7}", iNumeroControle);

          dllConfirmaVendaPBM = (_ConfirmaVendaPBM)GetDelegateFromDLL("ConfirmaVendaPBM", typeof(_ConfirmaVendaPBM));

          int iRes = dllConfirmaVendaPBM(pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoReimpressaoVendaPBM()
        {

          if (!CarregaDLL())
            return 11;

          dllTransacaoReimpressaoVendaPBM = (_TransacaoReimpressaoVendaPBM)GetDelegateFromDLL("TransacaoReimpressaoVendaPBM", typeof(_TransacaoReimpressaoVendaPBM));

          int iRes = dllTransacaoReimpressaoVendaPBM();

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }


        public int TransacaoCancelamentoPreAutorizacao(out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder();
          pNumeroControle.AppendFormat("{0:D7}", iNumeroControle);
          dllTransacaoCancelamentoPreAutorizacaoPBM = (_TransacaoCancelamentoPreAutorizacaoPBM)GetDelegateFromDLL("TransacaoCancelamentoPreAutorizacaoPBM", typeof(_TransacaoCancelamentoPreAutorizacaoPBM));

          int iRes = dllTransacaoCancelamentoVendaPBM(pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoCancelamentoVendaPBM(out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder();
          pNumeroControle.AppendFormat("{0:D7}", iNumeroControle);
          dllTransacaoCancelamentoVendaPBM = (_TransacaoCancelamentoVendaPBM)GetDelegateFromDLL("TransacaoCancelamentoVendaPBM", typeof(_TransacaoCancelamentoVendaPBM));

          int iRes = dllTransacaoCancelamentoVendaPBM(pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoElegibilidadePBM(int numeroCupom, string redePBM, string matricula, string autorizacaoElegibilidade, string dadosFarmaceutico, out int iNumeroControle,
        out string numeroControleRede, out string nomeCliente, out string nomeMedico, out string informaDependente, out string listaDependentes, out string reservado,
        out string mensagemOperador)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
          {
            numeroControleRede = "";
            nomeCliente = "";
            nomeMedico = "";
            informaDependente = "";
            listaDependentes = "";
            reservado = "";
            mensagemOperador = "";
            return 11;
          }

          StringBuilder pNumeroCupom = new StringBuilder(numeroCupom);
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_matricula = new StringBuilder(matricula);
          StringBuilder p_dadosElegibilidade = new StringBuilder();
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] pNumeroControleRede = new byte[13];
          byte[] p_nomeCliente = new byte[41];
          byte[] p_nomeMedico = new byte[41];
          byte[] p_informaDependente = new byte[3];
          byte[] p_listaDependentes = new byte[505];
          byte[] p_reservado = new byte[128];
          byte[] p_mensagemOperador = new byte[64];

          dllTransacaoElegibilidadePBM = (_TransacaoElegibilidadePBM)GetDelegateFromDLL("TransacaoElegibilidadePBM", typeof(_TransacaoElegibilidadePBM));

          int iRes = dllTransacaoElegibilidadePBM(pNumeroCupom, p_redePBM, p_matricula, p_dadosElegibilidade, pNumeroControle, pNumeroControleRede,
          p_nomeCliente, p_nomeMedico, p_informaDependente, p_listaDependentes, p_reservado, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            numeroControleRede = ASCIIEncoding.ASCII.GetString(pNumeroControleRede);
            nomeCliente = ASCIIEncoding.ASCII.GetString(p_nomeCliente);
            nomeMedico = ASCIIEncoding.ASCII.GetString(p_nomeMedico);
            informaDependente = ASCIIEncoding.ASCII.GetString(p_informaDependente);
            listaDependentes = ASCIIEncoding.ASCII.GetString(p_listaDependentes);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }
          else
          {
            numeroControleRede = "";
            nomeCliente = "";
            nomeMedico = "";
            informaDependente = "";
            listaDependentes = "";
            reservado = "";
            mensagemOperador = "";
          }

          return iRes;
        }

        public int TransacaoPreAutorizacaoPBM(int numeroCupom, string redePBM, string autorizacaoElegibilidade, string dadosFarmaceutico, ref int quantidadeMedicamentos,
        ref string medicamentos, out int iNumeroControle, out string numeroControleRede, out string reservado, out string mensagemOperador)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
          {
            medicamentos = "";
            numeroControleRede = "";
            reservado = "";
            mensagemOperador = "Erro ao carregar dll";
            quantidadeMedicamentos = 0;
            return 11;
          }

          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_autorizacaoElegibilidade = new StringBuilder(autorizacaoElegibilidade);
          StringBuilder p_dadosFarmaceutico = new StringBuilder(dadosFarmaceutico);
          byte[] p_quantidadeMedicamentos = new byte[3];
          p_quantidadeMedicamentos = ASCIIEncoding.ASCII.GetBytes(quantidadeMedicamentos.ToString().ToCharArray());
          byte[] p_medicamentos = new byte[4261];
          p_medicamentos = ASCIIEncoding.ASCII.GetBytes(medicamentos.ToCharArray());
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] pNumeroControleRede = new byte[13];
          byte[] p_reservado = new byte[128];
          byte[] p_mensagemOperador = new byte[64];

          dllTransacaoPreAutorizacaoPBM = (_TransacaoPreAutorizacaoPBM)GetDelegateFromDLL("TransacaoPreAutorizacaoPBM", typeof(_TransacaoPreAutorizacaoPBM));

          int iRes = dllTransacaoPreAutorizacaoPBM(pNumeroCupom, p_redePBM, p_autorizacaoElegibilidade, p_dadosFarmaceutico, p_quantidadeMedicamentos, p_medicamentos,
          pNumeroControle, pNumeroControleRede, p_reservado, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            medicamentos = ASCIIEncoding.ASCII.GetString(p_medicamentos);
            numeroControleRede = ASCIIEncoding.ASCII.GetString(pNumeroControleRede);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            quantidadeMedicamentos = Conversor.ToIntDef(ASCIIEncoding.ASCII.GetString(p_quantidadeMedicamentos), 0);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }
          else
          {
            medicamentos = "";
            numeroControleRede = "";
            reservado = "";
            mensagemOperador = "falha na transação";
            quantidadeMedicamentos = 0;
          }

          return iRes;
        }

        public int TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing(string numeroEmpresa, string multiLoja, string numeroLoja, string numeroPDV, string matricula,
        out string reservado, out int iNumeroControle, out string mensagemOperador)
        {
          iNumeroControle = 0;
          reservado = "";
          mensagemOperador = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder p_matricula = new StringBuilder(matricula);
          byte[] p_reservado = new byte[128];
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] p_mensagemOperador = new byte[64];

          dllTransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing = (_TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing)GetDelegateFromDLL(
          "TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing", typeof(_TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing));

          int iRes = dllTransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, p_matricula,
          p_reservado, pNumeroControle, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoElegibilidadePBM_TeleMarketing(int numeroEmpresa, string multiLoja, int numeroLoja, int numeroPDV, int numeroCupom,
        string redePBM, string matricula, string dadosElegibilidade, out int iNumeroControle, string numeroControleRede, out string NomeCliente, out string NomeMedico,
        string informaDependente, string listaDependentes, out string reservado, out string mensagemOperador)
        {
          reservado = "";
          mensagemOperador = "";
          iNumeroControle = 0;
          NomeMedico = "";
          NomeCliente = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_matricula = new StringBuilder(matricula);
          StringBuilder p_dadosElegibilidade = new StringBuilder(dadosElegibilidade);
          StringBuilder pNumeroControle = new StringBuilder(iNumeroControle);
          StringBuilder pNumeroControleRede = new StringBuilder(numeroControleRede);
          byte[] p_nomeCliente = new byte[41];
          byte[] p_nomeMedico = new byte[41];
          StringBuilder p_informaDependente = new StringBuilder(informaDependente);
          StringBuilder p_listaDependentes = new StringBuilder(listaDependentes);
          byte[] p_reservado = new byte[128];
          byte[] p_mensagemOperador = new byte[64];

          dllTransacaoElegibilidadePBM_TeleMarketing = (_TransacaoElegibilidadePBM_TeleMarketing)GetDelegateFromDLL("TransacaoElegibilidadePBM_TeleMarketing",
          typeof(_TransacaoElegibilidadePBM_TeleMarketing));

          int iRes = dllTransacaoElegibilidadePBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, pNumeroCupom, p_redePBM, p_matricula,
          p_dadosElegibilidade, pNumeroControle, pNumeroControleRede, p_nomeCliente, p_nomeMedico, p_informaDependente, p_listaDependentes, p_reservado,
          p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            NomeMedico = ASCIIEncoding.ASCII.GetString(p_nomeMedico);
            NomeCliente = ASCIIEncoding.ASCII.GetString(p_nomeCliente);
          }

          return iRes;
        }

        public int TransacaoPreAutorizacaoPBM_TeleMarketing(int numeroEmpresa, string multiLoja, int numeroLoja, int numeroPDV, int numeroCupom, string redePBM,
        string autorizacaoElegibilidade, string dadosFarmaceutico, ref int quantidadeMedicamentos, ref string medicamentos, out int iNumeroControle, out string numeroControleRede,
        out string reservado, out string mensagemOperador)
        {
          iNumeroControle = 0;
          reservado = "";
          numeroControleRede = "";
          mensagemOperador = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_autorizacaoElegibilidade = new StringBuilder(autorizacaoElegibilidade);
          StringBuilder p_dadosFarmaceutico = new StringBuilder(dadosFarmaceutico);
          byte[] p_quantidadeMedicamentos = new byte[3];
          p_quantidadeMedicamentos = ASCIIEncoding.ASCII.GetBytes(quantidadeMedicamentos.ToString().ToCharArray());
          byte[] p_medicamentos = new byte[4261];
          p_medicamentos = ASCIIEncoding.ASCII.GetBytes(medicamentos.ToCharArray());
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] pNumeroControleRede = new byte[13];
          byte[] p_reservado = new byte[128];
          byte[] p_mensagemOperador = new byte[64];

          dllTransacaoPreAutorizacaoPBM_TeleMarketing = (_TransacaoPreAutorizacaoPBM_TeleMarketing)GetDelegateFromDLL("TransacaoPreAutorizacaoPBM_TeleMarketing",
          typeof(_TransacaoPreAutorizacaoPBM_TeleMarketing));

          int iRes = dllTransacaoPreAutorizacaoPBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, pNumeroCupom, p_redePBM,
          p_autorizacaoElegibilidade, p_dadosFarmaceutico, p_quantidadeMedicamentos, p_medicamentos, pNumeroControle, pNumeroControleRede, p_reservado, p_mensagemOperador);

          if (iRes == 0)
          {
            quantidadeMedicamentos = Conversor.ToIntDef(p_quantidadeMedicamentos.ToString(), 0);
            medicamentos = ASCIIEncoding.ASCII.GetString(p_medicamentos);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ConsultaParametrosPBM_TeleMarketing(int numeroEmpresa, string multiLoja, int numeroLoja, int numeroPDV, int numeroCupom, ref int quantidadeRedes,
        out string dadosRedes, out string mensagemOperador)
        {
          mensagemOperador = "";
          dadosRedes = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          byte[] p_quantidadeRedes = new byte[3];
          byte[] p_dadosRedes = new byte[560];
          byte[] p_mensagemOperador = new byte[64];

          dllConsultaParametrosPBM_TeleMarketing = (_ConsultaParametrosPBM_TeleMarketing)GetDelegateFromDLL("ConsultaParametrosPBM_TeleMarketing",
              typeof(_ConsultaParametrosPBM_TeleMarketing));

          int iRes = dllConsultaParametrosPBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, pNumeroCupom, p_quantidadeRedes,
          p_dadosRedes, p_mensagemOperador);

          if (iRes == 0)
          {
            quantidadeRedes = Conversor.ToIntDef(p_quantidadeRedes.ToString(), 0);
            dadosRedes = ASCIIEncoding.ASCII.GetString(p_dadosRedes);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ConsultaProdutosPBM_TeleMarketing(int numeroEmpresa, string multiLoja, int numeroLoja, int numeroPDV, string numeroCupom, string redePBM,
        string trilha1, string trilha2, string digitado, string autorizacao, string dadosCRM, out int tipoVenda, out Decimal valorTotalMedicamentos, out Decimal valorVista,
        out Decimal valorCartao, out string codigoCredenciado, ref int quantidadeMedicamentos, ref string medicamentos, out string reservado, out int iNumeroControle, out string mensagemOperador)
        {
          iNumeroControle = 0;
          reservado = "";
          mensagemOperador = "";
          tipoVenda = 0;
          valorTotalMedicamentos = 0;
          valorVista = 0;
          valorCartao = 0;
          codigoCredenciado = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_trilha1 = new StringBuilder(trilha1);
          StringBuilder p_trilha2 = new StringBuilder(trilha2);
          StringBuilder p_digitado = new StringBuilder(digitado);
          StringBuilder p_autorizacao = new StringBuilder(autorizacao);
          StringBuilder p_dadosCRM = new StringBuilder(dadosCRM);
          byte[] p_tipoVenda = new byte[3];
          byte[] p_valorTotalMedicamentos = new byte[12];
          byte[] p_valorVista = new byte[12];
          byte[] p_valorCartao = new byte[12];
          byte[] p_codigoCredenciado = new byte[12];
          byte[] p_quantidadeMedicamentos = new byte[2];
          byte[] p_medicamentos = new byte[4261];
          byte[] p_reservado = new byte[128];
          StringBuilder pNumeroControle = new StringBuilder();
          byte[] p_mensagemOperador = new byte[64];

          dllConsultaProdutosPBM_TeleMarketing = (_ConsultaProdutosPBM_TeleMarketing)GetDelegateFromDLL("ConsultaProdutosPBM_TeleMarketing",
          typeof(_ConsultaProdutosPBM_TeleMarketing));

          int iRes = dllConsultaProdutosPBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, pNumeroCupom, p_redePBM, p_trilha1,
          p_trilha2, p_digitado, p_autorizacao, p_dadosCRM, p_tipoVenda, p_valorTotalMedicamentos, p_valorVista, p_valorCartao, p_codigoCredenciado,
          p_quantidadeMedicamentos, p_medicamentos, p_reservado, pNumeroControle, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            tipoVenda = Conversor.ToIntDef(p_tipoVenda.ToString(), 0);
            valorTotalMedicamentos = Conversor.ToDecimalDef(p_valorTotalMedicamentos.ToString(), 0);
            valorVista = Conversor.ToDecimalDef(p_valorVista.ToString(), 0);
            valorCartao = Conversor.ToDecimalDef(p_valorCartao.ToString(), 0);
            codigoCredenciado = ASCIIEncoding.ASCII.GetString(p_codigoCredenciado);
            quantidadeMedicamentos = Conversor.ToIntDef(p_quantidadeMedicamentos.ToString(), 0);
            medicamentos = ASCIIEncoding.ASCII.GetString(p_medicamentos);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);

          }

          return iRes;
        }

        public int TransacaoVendaPBM_TeleMarketing(int numeroEmpresa, string multiLoja, int numeroLoja, int numeroPDV, Decimal valorTotalMedicamentos, int numeroCupom,
        string redePBM, string trilha1, string trilha2, string digitado, string autorizacao, string NSUConsulta, string dadosCRM, string tipoVenda, Decimal valorVista,
        Decimal valorCartao, string codigoCredenciado, string regraNegocio, ref int quantidadeMedicamentos, ref string medicamentos, out string reservado, out int iNumeroControle,
        out string numeroControleRede, out string mensagemOperador)
        {
          iNumeroControle = 0;
          mensagemOperador = "";
          numeroControleRede = "";
          reservado = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_NSUConsulta = new StringBuilder(NSUConsulta);
          StringBuilder p_regraNegocio = new StringBuilder(regraNegocio);
          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_trilha1 = new StringBuilder(trilha1);
          StringBuilder p_trilha2 = new StringBuilder(trilha2);
          StringBuilder p_digitado = new StringBuilder(digitado);
          StringBuilder p_autorizacao = new StringBuilder(autorizacao);
          StringBuilder p_dadosCRM = new StringBuilder(dadosCRM);
          StringBuilder p_tipoVenda = new StringBuilder(tipoVenda);
          StringBuilder p_valorTotalMedicamentos = new StringBuilder();
          p_valorTotalMedicamentos.AppendFormat("{0:d12}", (int)(valorTotalMedicamentos * 100.0M));
          StringBuilder p_valorVista = new StringBuilder();
          p_valorVista.AppendFormat("{0:d12}", (int)(valorVista * 100.0M));
          StringBuilder p_valorCartao = new StringBuilder();
          p_valorCartao.AppendFormat("{0:d12}", (int)(valorCartao * 100.0M));
          StringBuilder p_codigoCredenciado = new StringBuilder();
          byte[] p_quantidadeMedicamentos = new byte[3];
          p_quantidadeMedicamentos = ASCIIEncoding.ASCII.GetBytes(quantidadeMedicamentos.ToString().ToCharArray());
          byte[] p_medicamentos = new byte[4261];
          p_medicamentos = ASCIIEncoding.ASCII.GetBytes(medicamentos.ToCharArray());
          byte[] p_reservado = new byte[129];
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] pNumeroControleRede = new byte[13];
          byte[] p_mensagemOperador = new byte[65];

          dllTransacaoVendaPBM_TeleMarketing = (_TransacaoVendaPBM_TeleMarketing)GetDelegateFromDLL("TransacaoVendaPBM_TeleMarketing",
              typeof(_TransacaoVendaPBM_TeleMarketing));

          int iRes = dllTransacaoVendaPBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, p_valorTotalMedicamentos, pNumeroCupom, p_redePBM,
            p_trilha1, p_trilha2, p_digitado, p_autorizacao, p_NSUConsulta, p_dadosCRM, p_tipoVenda, p_valorVista, p_valorCartao, p_codigoCredenciado, p_regraNegocio,
            p_quantidadeMedicamentos, p_medicamentos, p_reservado, pNumeroControle, pNumeroControleRede, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            quantidadeMedicamentos = Conversor.ToIntDef(p_quantidadeMedicamentos.ToString(), 0);
            medicamentos = ASCIIEncoding.ASCII.GetString(p_medicamentos);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            numeroControleRede = ASCIIEncoding.ASCII.GetString(pNumeroControleRede);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
          }

          return iRes;
        }

        public int TransacaoCancelamentoVendaPBM_TeleMarketing(int numeroEmpresa, string multiLoja, string numeroLoja, int numeroPDV, string trilha1, string trilha2,
        string digitado, out string reservado, out int iNumeroControle, out string mensagemOperador)
        {
          iNumeroControle = 0;
          mensagemOperador = "";
          reservado = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder p_trilha1 = new StringBuilder(trilha1);
          StringBuilder p_trilha2 = new StringBuilder(trilha2);
          StringBuilder p_digitado = new StringBuilder(digitado);
          byte[] p_reservado = new byte[128];
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] p_mensagemOperador = new byte[64];

          dllTransacaoCancelamentoVendaPBM_TeleMarketing = (_TransacaoCancelamentoVendaPBM_TeleMarketing)GetDelegateFromDLL("TransacaoCancelamentoVendaPBM_TeleMarketing",
          typeof(_TransacaoCancelamentoVendaPBM_TeleMarketing));

          int iRes = dllTransacaoCancelamentoVendaPBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, p_trilha1, p_trilha2, p_digitado, p_reservado,
          pNumeroControle, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoAberturaVendaPBM_TeleMarketing(int numeroEmpresa, string multiLoja, int numeroLoja, int numeroPDV, string redePBM,
        string trilha1, string trilha2, string digitado, out string reservado, ref string pedirDadosComplementares, string dadosComplementares,
        ref string infoDadosComplementares, out string mensagemOperador)
        {
          mensagemOperador = "";
          reservado = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_trilha1 = new StringBuilder(trilha1);
          StringBuilder p_trilha2 = new StringBuilder(trilha2);
          StringBuilder p_digitado = new StringBuilder(digitado);
          byte[] p_reservado = new byte[129];
          byte[] p_pedirDadosComplementares = new byte[2];  // 'S' ou 'N'
          p_pedirDadosComplementares = ASCIIEncoding.ASCII.GetBytes(pedirDadosComplementares.ToCharArray());
          byte[] p_dadosComplementares = new byte[129];
          p_dadosComplementares = ASCIIEncoding.ASCII.GetBytes(dadosComplementares.ToCharArray());
          byte[] p_infoDadosComplementares = new byte[65];
          p_infoDadosComplementares = ASCIIEncoding.ASCII.GetBytes(infoDadosComplementares.ToCharArray());
          byte[] p_mensagemOperador = new byte[65];

          dllTransacaoAberturaVendaPBM_TeleMarketing = (_TransacaoAberturaVendaPBM_TeleMarketing)GetDelegateFromDLL("TransacaoAberturaVendaPBM_TeleMarketing",
              typeof(_TransacaoAberturaVendaPBM_TeleMarketing));

          int iRes = dllTransacaoAberturaVendaPBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, p_redePBM, p_trilha1, p_trilha2, p_digitado,
          p_reservado, p_pedirDadosComplementares, p_dadosComplementares, p_infoDadosComplementares, p_mensagemOperador);

          if (iRes == 0)
          {
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            infoDadosComplementares = ASCIIEncoding.ASCII.GetString(p_infoDadosComplementares);
            pedirDadosComplementares = ASCIIEncoding.ASCII.GetString(p_pedirDadosComplementares);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoVendaProdutoPBM_TeleMarketing(int numeroEmpresa, string multiLoja, int numeroLoja, int numeroPDV, string redePBM, string trilha1,
        string trilha2, string digitado, ref string medicamento, out string reservado, ref string pedirDadosComplementares, string dadosComplementares,
        ref string infoDadosComplementares, out string mensagemOperador)
        {
          mensagemOperador = "";
          reservado = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_trilha1 = new StringBuilder(trilha1);
          StringBuilder p_trilha2 = new StringBuilder(trilha2);
          StringBuilder p_digitado = new StringBuilder(digitado);
          byte[] p_medicamento = new byte[561];
          byte[] p_reservado = new byte[129];
          byte[] p_pedirDadosComplementares = new byte[2];
          p_pedirDadosComplementares = ASCIIEncoding.ASCII.GetBytes(pedirDadosComplementares.ToCharArray());
          StringBuilder p_DadosComplementares = new StringBuilder(dadosComplementares);
          byte[] p_infoDadosComplementares = new byte[65];
          p_infoDadosComplementares = ASCIIEncoding.ASCII.GetBytes(infoDadosComplementares.ToCharArray());
          byte[] p_mensagemOperador = new byte[65];

          dllTransacaoVendaProdutoPBM_TeleMarketing = (_TransacaoVendaProdutoPBM_TeleMarketing)GetDelegateFromDLL("TransacaoVendaProdutoPBM_TeleMarketing",
              typeof(_TransacaoVendaProdutoPBM_TeleMarketing));

          int iRes = dllTransacaoVendaProdutoPBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, p_redePBM, p_trilha1, p_trilha2,
              p_digitado, p_medicamento, p_reservado, p_pedirDadosComplementares, p_DadosComplementares, p_infoDadosComplementares, p_mensagemOperador);

          if (iRes == 0)
          {
            medicamento = ASCIIEncoding.ASCII.GetString(p_medicamento);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            pedirDadosComplementares = ASCIIEncoding.ASCII.GetString(p_pedirDadosComplementares);
            infoDadosComplementares = ASCIIEncoding.ASCII.GetString(p_infoDadosComplementares);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoFechamentoVendaPBM_TeleMarketing(int numeroEmpresa, string multiLoja, int numeroLoja, int numeroPDV, string redePBM, string trilha1,
        string trilha2, string digitado, string confirmacao, string reservado, string autorizacao, out int iNumeroControle, string mensagemOperador)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder p_redePBM = new StringBuilder(redePBM);
          StringBuilder p_trilha1 = new StringBuilder(trilha1);
          StringBuilder p_trilha2 = new StringBuilder(trilha2);
          StringBuilder p_digitado = new StringBuilder(digitado);
          StringBuilder p_confirmacao = new StringBuilder(confirmacao);
          byte[] p_reservado = new byte[129];
          StringBuilder p_autorizacao = new StringBuilder(autorizacao);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] p_mensagemOperador = new byte[65];

          dllTransacaoFechamentoVendaPBM_TeleMarketing = (_TransacaoFechamentoVendaPBM_TeleMarketing)GetDelegateFromDLL("TransacaoFechamentoVendaPBM_TeleMarketing",
          typeof(_TransacaoFechamentoVendaPBM_TeleMarketing));

          int iRes = dllTransacaoFechamentoVendaPBM_TeleMarketing(p_numeroEmpresa, p_multiLoja, p_numeroLoja, p_numeroPDV, p_redePBM, p_trilha1, p_trilha2, p_digitado,
          p_confirmacao, p_reservado, p_autorizacao, pNumeroControle, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public void InformaDadosMedicamentos(string indicativoReceita, string registroProfissional, string listaMedicamentos)
        {
          if (!CarregaDLL())
            return;

          StringBuilder p_indicativoReceita = new StringBuilder(indicativoReceita);
          StringBuilder p_registroProfissional = new StringBuilder(registroProfissional);
          StringBuilder p_listaMedicamentos = new StringBuilder(listaMedicamentos);

          dllInformaDadosMedicamentos = (_InformaDadosMedicamentos)GetDelegateFromDLL("InformaDadosMedicamentos",
          typeof(_InformaDadosMedicamentos));

          int iRes = dllInformaDadosMedicamentos(p_indicativoReceita, p_registroProfissional, p_listaMedicamentos);

          if (!bManterDLLCarregada)
            DescarregaDLL();

        }

        public int TransacaoConsultaAVSConfirmada(string MultiLoja, string numeroLoja, string numeroPDV, string numeroCupom,
        string iNumeroControle, string numeroCartao, string dataVencimento, string CVV2, string Endereco, string numero,
        string Apto, string Bloco, string CEP, string Bairro, string CPF, out string MensagemTEF, ref string reservado)
        {
          MensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_MultiLoja = new StringBuilder(MultiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pNumeroCupom = new StringBuilder(numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder(iNumeroControle);
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder p_dataVencimento = new StringBuilder(dataVencimento);
          StringBuilder p_CVV2 = new StringBuilder(CVV2);
          StringBuilder p_Endereco = new StringBuilder(Endereco);
          StringBuilder p_numero = new StringBuilder(numero);
          StringBuilder p_Apto = new StringBuilder(Apto);
          StringBuilder p_Bloco = new StringBuilder(Bloco);
          StringBuilder p_CEP = new StringBuilder(CEP);
          StringBuilder p_Bairro = new StringBuilder(Bairro);
          StringBuilder p_CPF = new StringBuilder(CPF);
          byte[] bMensagemTEF = new byte[2048];
          byte[] bReservado = new byte[1024];

          dllTransacaoConsultaAVSConfirmada = (_TransacaoConsultaAVSConfirmada)GetDelegateFromDLL("TransacaoConsultaAVSConfirmada", typeof(_TransacaoConsultaAVSConfirmada));

          int iRes = dllTransacaoConsultaAVSConfirmada(p_MultiLoja, p_numero, p_numeroPDV, pNumeroCupom, pNumeroControle, p_numeroCartao, p_dataVencimento,
                    p_CVV2, p_Endereco, p_numero, p_Apto, p_Bloco, p_CEP, p_Bairro, p_CPF, bMensagemTEF, bReservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            MensagemTEF = ASCIIEncoding.ASCII.GetString(bMensagemTEF);
            reservado = ASCIIEncoding.ASCII.GetString(bReservado);
          }

          return iRes;
        }

        public int TransacaoConsultaAVSConfirmada(string multiLoja, int numeroLoja, int numeroPDV, int numeroCupom, int iNumeroControle, string numeroCartao,
        String dataVencimento, string CVV2, string endereco, string numero, string apto, string bloco, string CEP, string bairro, string CPF,
        out string mensagemTEF, ref string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder p_dataVencimento = new StringBuilder(dataVencimento);
          StringBuilder p_CVV2 = new StringBuilder(CVV2);
          StringBuilder p_endereco = new StringBuilder(endereco);
          StringBuilder p_numero = new StringBuilder(numero);
          StringBuilder p_apto = new StringBuilder(apto);
          StringBuilder p_bloco = new StringBuilder(bloco);
          StringBuilder p_CEP = new StringBuilder(CEP);
          StringBuilder p_bairro = new StringBuilder(bairro);
          StringBuilder p_CPF = new StringBuilder(CPF);
          byte[] p_mensagemTEF = new byte[64];
          byte[] p_reservado = new byte[256];
          p_reservado = ASCIIEncoding.ASCII.GetBytes(reservado.ToCharArray());

          dllTransacaoConsultaAVS = (_TransacaoConsultaAVS)GetDelegateFromDLL("TransacaoConsultaAVS", typeof(_TransacaoConsultaAVS));

          int iRes = dllTransacaoConsultaAVSConfirmada(p_multiLoja, p_numeroLoja, p_numeroPDV, pNumeroCupom, pNumeroControle, p_numeroCartao, p_dataVencimento,
          p_CVV2, p_endereco, p_numero, p_apto, p_bloco, p_CEP, p_bairro, p_CPF, p_mensagemTEF, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
          }

          return iRes;
        }

        public int TransacaoPagamentoContasVisanet(out string tipoConta, out string codigoBarras, out string formaPagamento, out string trilhaCartao, out Decimal valorTransacao,
        int numeroCupom, out int iNumeroControle)
        {
          iNumeroControle = 0;
          tipoConta = "";
          codigoBarras = "";
          formaPagamento = "";
          trilhaCartao = "";
          valorTransacao = 0;

          if (!CarregaDLL())
            return 11;

          byte[] p_tipoConta = new byte[3];
          byte[] p_codigoBarras = new byte[45];
          byte[] p_formaPagamento = new byte[3];
          byte[] p_trilhaCartao = new byte[38];
          byte[] pValorTransacao = new byte[13];
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoPagamentoContasVisanet = (_TransacaoPagamentoContasVisanet)GetDelegateFromDLL("TransacaoPagamentoContasVisanet", typeof(_TransacaoPagamentoContasVisanet));

          int iRes = dllTransacaoPagamentoContasVisanet(p_tipoConta, p_codigoBarras, p_formaPagamento, p_trilhaCartao, pValorTransacao, pNumeroCupom, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            tipoConta = ASCIIEncoding.ASCII.GetString(p_tipoConta);
            codigoBarras = ASCIIEncoding.ASCII.GetString(p_codigoBarras);
            formaPagamento = ASCIIEncoding.ASCII.GetString(p_formaPagamento);
            trilhaCartao = ASCIIEncoding.ASCII.GetString(p_trilhaCartao);
            valorTransacao = Conversor.ToDecimalDef(pValorTransacao.ToString(), 0);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int ConsultaParametrosTeledata(out string dadosTeledata, out string mensagemOperador)
        {
          mensagemOperador = "";
          dadosTeledata = "";

          if (!CarregaDLL())
            return 11;

          byte[] p_dadosTeledata = new byte[1025];
          byte[] p_mensagemOperador = new byte[64];

          dllConsultaParametrosTeledata = (_ConsultaParametrosTeledata)GetDelegateFromDLL("ConsultaParametrosTeledata", typeof(_ConsultaParametrosTeledata));

          int iRes = dllConsultaParametrosTeledata(p_dadosTeledata, p_mensagemOperador);

          if (iRes == 0)
          {
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            dadosTeledata = ASCIIEncoding.ASCII.GetString(p_dadosTeledata);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ConsultaChequesGarantidos(out int tipoDocumento, out int numeroDocumento, out string dataInicialConsulta, string dataFinalConsulta, out int iNumeroControle)
        {
          tipoDocumento = 0;
          numeroDocumento = 0;
          dataFinalConsulta = "";
          dataInicialConsulta = "";
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          byte[] p_tipoDocumento = new byte[3];
          byte[] p_numeroDocumento = new byte[15];
          byte[] p_dataInicialConsulta = new byte[9];
          byte[] p_dataFinalConsulta = new byte[9];
          StringBuilder pNumeroControle = new StringBuilder(numeroDocumento);

          dllConsultaChequesGarantidos = (_ConsultaChequesGarantidos)GetDelegateFromDLL("ConsultaChequesGarantidos", typeof(_ConsultaChequesGarantidos));

          int iRes = dllConsultaChequesGarantidos(p_tipoDocumento, p_numeroDocumento, p_dataInicialConsulta, p_dataFinalConsulta, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            tipoDocumento = Conversor.ToIntDef(p_tipoDocumento.ToString(), 0);
            numeroDocumento = Conversor.ToIntDef(p_numeroDocumento.ToString(), 0);
            dataInicialConsulta = ASCIIEncoding.ASCII.GetString(p_dataInicialConsulta);
            dataFinalConsulta = ASCIIEncoding.ASCII.GetString(p_dataFinalConsulta);
          }

          return iRes;
        }

        public int TransacaoSaqueCompleta(Decimal valorTransacao, int numeroCupomFiscal, out int iNumeroControle, string tipoTransacao, string planoPagamento,
        string numeroParcelas, string permiteAlteracao, string reservado)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupomfiscal = new StringBuilder(numeroCupomFiscal);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_tipoTransacao = new StringBuilder(tipoTransacao);
          StringBuilder p_planoPagamento = new StringBuilder(planoPagamento);
          StringBuilder pNumeroParcelas = new StringBuilder(numeroParcelas);
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao);
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllTransacaoSaqueCompleta = (_TransacaoSaqueCompleta)GetDelegateFromDLL("TransacaoSaqueCompleta", typeof(_TransacaoSaqueCompleta));

          int iRes = dllTransacaoSaqueCompleta(pValorTransacao, pNumeroCupomfiscal, pNumeroControle, p_tipoTransacao, p_planoPagamento,
          pNumeroParcelas, pPermiteAlteracao, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }


          return iRes;
        }

        public int TransacaoCartaoCompraSaque(ref Decimal valorCompra, ref Decimal valorSaque, int numeroCupom, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          byte[] p_valorCompra = new byte[12];
          p_valorCompra = ASCIIEncoding.ASCII.GetBytes(valorCompra.ToString());
          byte[] p_valorSaque = new byte[12];
          p_valorSaque = ASCIIEncoding.ASCII.GetBytes(valorSaque.ToString());
          byte[] pNumeroCupom = new byte[6];
          pNumeroCupom = ASCIIEncoding.ASCII.GetBytes(numeroCupom.ToString());
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoCartaoCompraSaque = (_TransacaoCartaoCompraSaque)GetDelegateFromDLL("TransacaoCartaoCompraSaque", typeof(_TransacaoCartaoCompraSaque));

          int iRes = dllTransacaoCartaoCompraSaque(p_valorCompra, p_valorSaque, pNumeroCupom, pNumeroControle);

          if (iRes == 0)
          {
            valorCompra = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(p_valorCompra), 0);
            valorSaque = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(p_valorSaque), 0);
            numeroCupom = Conversor.ToIntDef(ASCIIEncoding.ASCII.GetString(pNumeroCupom), 0);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoCartaoCompraSaqueCompleta(ref Decimal valorCompra, ref Decimal valorSaque, ref int numeroCupom, out int iNumeroControle, string permiteAlteracao)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          byte[] p_valorCompra = new byte[12];
          p_valorCompra = ASCIIEncoding.ASCII.GetBytes(valorCompra.ToString());
          byte[] p_valorSaque = new byte[12];
          p_valorSaque = ASCIIEncoding.ASCII.GetBytes(valorSaque.ToString());
          byte[] pNumeroCupom = new byte[6];
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao);

          dllTransacaoCartaoCompraSaqueCompleta = (_TransacaoCartaoCompraSaqueCompleta)GetDelegateFromDLL("TransacaoCartaoCompraSaqueCompleta",
          typeof(_TransacaoCartaoCompraSaqueCompleta));

          int iRes = dllTransacaoCartaoCompraSaqueCompleta(p_valorCompra, p_valorSaque, pNumeroCupom, pNumeroControle, pPermiteAlteracao);

          if (iRes == 0)
          {
            valorCompra = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(p_valorCompra), 0);
            valorSaque = Conversor.ToDecimalDef(ASCIIEncoding.ASCII.GetString(p_valorSaque), 0);
            numeroCupom = Conversor.ToIntDef(ASCIIEncoding.ASCII.GetString(pNumeroCupom), 0);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TesteRedeAtiva(int numeroEmpresa, int numeroLoja, int numeroPDV, string codigoRede, out string statusRede, out string mensagemOperador)
        {
          mensagemOperador = "";
          statusRede = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder p_codigoRede = new StringBuilder(codigoRede);
          byte[] p_statusRede = new byte[3];
          byte[] p_mensagemOperador = new byte[64];


          dllTesteRedeAtiva = (_TesteRedeAtiva)GetDelegateFromDLL("TesteRedeAtiva", typeof(_TesteRedeAtiva));

          int iRes = dllTesteRedeAtiva(p_numeroLoja, p_numeroEmpresa, p_numeroPDV, p_codigoRede, p_statusRede, p_mensagemOperador);

          if (iRes == 0)
          {
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            statusRede = ASCIIEncoding.ASCII.GetString(p_statusRede);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoCadastraSenha(out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoCadastraSenha = (_TransacaoCadastraSenha)GetDelegateFromDLL("TransacaoCadastraSenha", typeof(_TransacaoCadastraSenha));

          int iRes = dllTransacaoCadastraSenha(pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int ConfiguraModoTeleMarketing(int modo)
        {

          if (!CarregaDLL())
            return 11;

          StringBuilder p_modo = new StringBuilder(modo);

          dllConfiguraModoTeleMarketing = (_ConfiguraModoTeleMarketing)GetDelegateFromDLL("ConfiguraModoTeleMarketing", typeof(_ConfiguraModoTeleMarketing));

          int iRes = dllConfiguraModoTeleMarketing(p_modo);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ConfirmaCartaoTeleMarketing(string multiLoja, int numeroLoja, int numeroPDV, out int iNumeroControle, out string mensagemTEF, string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] p_mensagemTEF = new byte[64];
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllConfirmaCartaoTeleMarketing = (_ConfirmaCartaoTeleMarketing)GetDelegateFromDLL("ConfirmaCartaoTeleMarketing", typeof(_ConfirmaCartaoTeleMarketing));

          int iRes = dllConfirmaCartaoTeleMarketing(p_multiLoja, p_numeroLoja, p_numeroPDV, pNumeroControle, p_mensagemTEF, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int DesfazCartaoTeleMarketing(string multiLoja, int numeroLoja, int numeroPDV, out int iNumeroControle, out string mensagemTEF, string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";
          if (!CarregaDLL())
            return 11;

          StringBuilder p_multiLoja = new StringBuilder(multiLoja);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] p_mensagemTEF = new byte[65];
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllDesfazCartaoTeleMarketing = (_DesfazCartaoTeleMarketing)GetDelegateFromDLL("DesfazCartaoTeleMarketing", typeof(_DesfazCartaoTeleMarketing));

          int iRes = dllDesfazCartaoTeleMarketing(p_multiLoja, p_numeroLoja, p_numeroPDV, pNumeroControle, p_mensagemTEF, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoInjecaoChaves(out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoInjecaoChaves = (_TransacaoInjecaoChaves)GetDelegateFromDLL("TransacaoInjecaoChaves", typeof(_TransacaoInjecaoChaves));

          int iRes = dllTransacaoInjecaoChaves(pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoTrocoSurpresa(Decimal valorTransacao, string numeroCupom, out int iNumeroControle, out string mensagemTEF, string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] p_mensagemTEF = new byte[64];
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllTransacaoTrocoSurpresa = (_TransacaoTrocoSurpresa)GetDelegateFromDLL("TransacaoTrocoSurpresa", typeof(_TransacaoTrocoSurpresa));

          int iRes = dllTransacaoTrocoSurpresa(pValorTransacao, pNumeroCupom, pNumeroControle, p_mensagemTEF, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int ConsultaTabelasValeGas(out int iNumeroControle, out string mensagemOperador)
        {
          iNumeroControle = 0;
          mensagemOperador = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");
          byte[] p_mensagemOperador = new byte[64];

          dllConsultaTabelasValeGas = (_ConsultaTabelasValeGas)GetDelegateFromDLL("ConsultaTabelasValeGas", typeof(_ConsultaTabelasValeGas));

          int iRes = dllConsultaTabelasValeGas(pNumeroControle, p_mensagemOperador);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            mensagemOperador = ASCIIEncoding.ASCII.GetString(p_mensagemOperador);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoAbreLote(out int iNumeroControle, int numeroCupom, out string mensagemTEF, ref string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          byte[] p_mensagemTEF = new byte[64];
          byte[] p_reservado = new byte[1024];
          p_reservado = ASCIIEncoding.ASCII.GetBytes(reservado.ToCharArray());

          dllTransacaoAbreLote = (_TransacaoAbreLote)GetDelegateFromDLL("TransacaoAbreLote", typeof(_TransacaoAbreLote));

          int iRes = dllTransacaoAbreLote(pNumeroControle, pNumeroCupom, p_mensagemTEF, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoFechaLote(out int iNumeroControle, int numeroCupom, out string mensagemTEF, ref string reservado)
        {
          iNumeroControle = 0;
          mensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          byte[] p_mensagemTEF = new byte[64];
          byte[] p_reservado = new byte[1024];
          p_reservado = ASCIIEncoding.ASCII.GetBytes(reservado.ToCharArray());

          dllTransacaoFechaLote = (_TransacaoFechaLote)GetDelegateFromDLL("TransacaoFechaLote", typeof(_TransacaoFechaLote));

          int iRes = dllTransacaoFechaLote(pNumeroControle, pNumeroCupom, p_mensagemTEF, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = ASCIIEncoding.ASCII.GetString(p_reservado);
          }

          return iRes;
        }

        public int TransacaoContratacao(string numeroCupom, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);

          dllTransacaoContratacao = (_TransacaoContratacao)GetDelegateFromDLL("TransacaoContratacao", typeof(_TransacaoContratacao));

          int iRes = dllTransacaoContratacao(pNumeroCupom, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoPrimeiraCompra(Decimal valorTransacao, string numeroCupom, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder(numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoPrimeiraCompra = (_TransacaoPrimeiraCompra)GetDelegateFromDLL("TransacaoPrimeiraCompra", typeof(_TransacaoPrimeiraCompra));

          int iRes = dllTransacaoPrimeiraCompra(pValorTransacao, pNumeroCupom, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoCadastro(string CNPJ, int numeroSerie, string codigoFrentista, string CPFCNPJ, string telefoneCliente, string reservado, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder p_CNPJ = new StringBuilder(CNPJ);
          StringBuilder p_numeroSerie = new StringBuilder(numeroSerie);
          StringBuilder p_codigoFrentista = new StringBuilder(codigoFrentista);
          StringBuilder p_CPFCNPJ = new StringBuilder(CPFCNPJ);
          StringBuilder p_telefoneCliente = new StringBuilder(telefoneCliente);
          StringBuilder p_reservado = new StringBuilder(reservado);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoCadastro = (_TransacaoCadastro)GetDelegateFromDLL("TransacaoCadastro", typeof(_TransacaoCadastro));

          int iRes = dllTransacaoCadastro(p_CNPJ, p_numeroSerie, p_codigoFrentista, p_CPFCNPJ, p_telefoneCliente, p_reservado, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int ConsultaCadastroPDV(out string mensagem)
        {
          mensagem = "";

          if (!CarregaDLL())
            return 11;

          byte[] p_mensagem = new byte[64];

          dllConsultaCadastroPDV = (_ConsultaCadastroPDV)GetDelegateFromDLL("ConsultaCadastroPDV", typeof(_ConsultaCadastroPDV));

          int iRes = dllConsultaCadastroPDV(p_mensagem);

          if (iRes == 0)
          {
            mensagem = ASCIIEncoding.ASCII.GetString(p_mensagem);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int ConsultaCadastroPDVTelemarketing(string numeroEmpresa, string numeroLoja, string numeroPDV, out string mensagemTEF)
        {
          mensagemTEF = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder p_numeroEmpresa = new StringBuilder(numeroEmpresa);
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          byte[] p_mensagemTEF = new byte[64];

          dllConsultaCadastroPDVTelemarketing = (_ConsultaCadastroPDVTelemarketing)GetDelegateFromDLL("ConsultaCadastroPDVTelemarketing", typeof(_ConsultaCadastroPDVTelemarketing));

          int iRes = dllConsultaCadastroPDVTelemarketing(p_numeroEmpresa, p_numeroLoja, p_numeroPDV, p_mensagemTEF);

          if (iRes == 0)
          {
            mensagemTEF = ASCIIEncoding.ASCII.GetString(p_mensagemTEF);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }


        public int TransacaoConsultaCadastroCPFCompleta(Decimal valorTransacao, int numeroCupom, out int iNumeroControle, string tipoOperacao,
        out string docEmissor, bool permiteAlteracao, string reservado)
        {
          iNumeroControle = 0;
          docEmissor = "";
          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_tipoOperacao = new StringBuilder(tipoOperacao);
          byte[] p_docEmissor = new byte[12];
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao.ToString());
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllTransacaoConsultaCadastroCPFCompleta = (_TransacaoConsultaCadastroCPFCompleta)GetDelegateFromDLL("TransacaoConsultaCadastroCPFCompleta",
          typeof(_TransacaoConsultaCadastroCPFCompleta));

          int iRes = dllTransacaoConsultaCadastroCPFCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, p_tipoOperacao, p_docEmissor,
          pPermiteAlteracao, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            docEmissor = ASCIIEncoding.ASCII.GetString(p_docEmissor);
          }

          return iRes;
        }

        public int TransacaoDepositoCompleta(Decimal valorTransacao, int numeroCupom, out int iNumeroControle, string tipoOperacao,
        out string docEmissor, string docDestinatario, bool permiteAlteracao, string reservado)
        {
          iNumeroControle = 0;
          docEmissor = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_tipoOperacao = new StringBuilder(tipoOperacao);
          byte[] p_docEmissor = new byte[11];
          p_docEmissor = ASCIIEncoding.ASCII.GetBytes((docEmissor + "\0").ToCharArray());
          byte[] p_docDestinatario = ASCIIEncoding.ASCII.GetBytes(docDestinatario.ToCharArray());
          p_docEmissor = ASCIIEncoding.ASCII.GetBytes((docEmissor + "\0").ToCharArray());
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao.ToString());
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllTransacaoDepositoCompleta = (_TransacaoDepositoCompleta)GetDelegateFromDLL("TransacaoDepositoCompleta",
          typeof(_TransacaoDepositoCompleta));

          int iRes = dllTransacaoDepositoCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, p_tipoOperacao, p_docEmissor,
          p_docDestinatario, pPermiteAlteracao, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            docEmissor = ASCIIEncoding.ASCII.GetString(p_docEmissor);
            docDestinatario = ASCIIEncoding.ASCII.GetString(p_docDestinatario);
          }

          return iRes;
        }

        public int TransacaoSaqueDomesticoCompleta(Decimal valorTransacao, int numeroCupom, out int iNumeroControle, string tipoOperacao, string codigoPIN,
        string docDestinatario, bool permiteAlteracao, string reservado)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_tipoOperacao = new StringBuilder(tipoOperacao);
          StringBuilder p_codigoPIN = new StringBuilder(codigoPIN);
          StringBuilder p_docDestinatario = new StringBuilder(docDestinatario);
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao.ToString());
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllTransacaoSaqueDomesticoCompleta = (_TransacaoSaqueDomesticoCompleta)GetDelegateFromDLL("TransacaoSaqueDomesticoCompleta",
          typeof(_TransacaoSaqueDomesticoCompleta));

          int iRes = dllTransacaoSaqueDomesticoCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, p_tipoOperacao, p_codigoPIN,
          p_docDestinatario, pPermiteAlteracao, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoAlteraSenhaUsuarioDTEF(string numeroCupom, out int iNumeroControle)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");

          dllTransacaoAlteraSenhaUsuarioDTEF = (_TransacaoAlteraSenhaUsuarioDTEF)GetDelegateFromDLL("TransacaoAlteraSenhaUsuarioDTEF", typeof(_TransacaoAlteraSenhaUsuarioDTEF));

          int iRes = dllTransacaoAlteraSenhaUsuarioDTEF(pNumeroCupom, pNumeroControle);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoQuitacaoCartaFreteCompleta(Decimal valorTransacao, int numeroCupom, out int iNumeroControle, int numeroCartaFrete,
          int quantidadeChegada, int permiteAlteracao, int reservado)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder p_numeroCartaFrete = new StringBuilder(numeroCartaFrete);
          StringBuilder p_quantidadeChegada = new StringBuilder(quantidadeChegada);
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao);
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllTransacaoQuitacaoCartaFreteCompleta = (_TransacaoQuitacaoCartaFreteCompleta)GetDelegateFromDLL("TransacaoQuitacaoCartaFreteCompleta",
          typeof(_TransacaoQuitacaoCartaFreteCompleta));

          int iRes = dllTransacaoQuitacaoCartaFreteCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, p_numeroCartaFrete, p_quantidadeChegada,
          pPermiteAlteracao, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int TransacaoPagamentoPrivateLabelCompleta(Decimal valorTransacao, string numeroCupom, out int iNumeroControle, string indicadorDigitacao,
          string codigoBarras, string numeroCartao, string codigoRede, string permiteAlteracao, string reservado)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder P_indicadorDigitacao = new StringBuilder(indicadorDigitacao);
          StringBuilder p_codigoBarras = new StringBuilder(codigoBarras);
          StringBuilder p_numeroCartao = new StringBuilder(numeroCartao);
          StringBuilder P_codigoRede = new StringBuilder(codigoRede);
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao);
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllTransacaoPagamentoPrivateLabelCompleta = (_TransacaoPagamentoPrivateLabelCompleta)GetDelegateFromDLL("TransacaoPagamentoPrivateLabelCompleta",
          typeof(_TransacaoPagamentoPrivateLabelCompleta));

          int iRes = dllTransacaoPagamentoPrivateLabelCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, P_indicadorDigitacao, p_codigoBarras,
          p_numeroCartao, P_codigoRede, pPermiteAlteracao, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }

        public int CadastraPDVTelemarketing(Decimal valorTransacao, string numeroLoja, int numeroPDV, out string mensagemPDV)
        {
          mensagemPDV = "";

          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder p_numeroLoja = new StringBuilder(numeroLoja);
          StringBuilder p_numeroPDV = new StringBuilder(numeroPDV);
          byte[] p_mensagemPDV = new byte[64];

          dllCadastraPDVTelemarketing = (_CadastraPDVTelemarketing)GetDelegateFromDLL("CadastraPDVTelemarketing", typeof(_CadastraPDVTelemarketing));

          int iRes = dllCadastraPDVTelemarketing(pValorTransacao, p_numeroLoja, p_numeroPDV, p_mensagemPDV);

          if (iRes == 0)
          {
            mensagemPDV = ASCIIEncoding.ASCII.GetString(p_mensagemPDV);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoCartaoCrediarioCompleta(Decimal valorTransacao, int numeroCupom, out int iNumeroControle, int numeroParcelas,
          string dataParcela1, Decimal valorParcela1, Decimal valorEntrada, string PermiteAlteracao, out string reservado)
        {
          iNumeroControle = 0;
          reservado = "";
          if (!CarregaDLL())
            return 11;

          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder(numeroCupom);
          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pNumeroParcelas = new StringBuilder(numeroParcelas);
          StringBuilder p_dataParcela1 = new StringBuilder(dataParcela1);
          StringBuilder pValorParcela1 = new StringBuilder();
          pValorParcela1.AppendFormat("{0:d12}", (int)(valorParcela1 * 100.0M));
          StringBuilder p_valorEntrada = new StringBuilder();
          p_valorEntrada.AppendFormat("{0:d12}", (int)(valorEntrada * 100.0M));
          StringBuilder pPermiteAlteracao = new StringBuilder(PermiteAlteracao);
          byte[] bReservado = new byte[2048];

          dllTransacaoCartaoCrediarioCompleta = (_TransacaoCartaoCrediarioCompleta)GetDelegateFromDLL("TransacaoCartaoCrediarioCompleta", typeof(_TransacaoCartaoCrediarioCompleta));

          int iRes = dllTransacaoCartaoCrediarioCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, pNumeroParcelas, p_dataParcela1, pValorParcela1,
            p_valorEntrada, pPermiteAlteracao, bReservado);

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
            reservado = ASCIIEncoding.ASCII.GetString(bReservado);
          }

          if (!bManterDLLCarregada)
            DescarregaDLL();

          return iRes;
        }

        public int TransacaoCartaoFrotaCompleta(Decimal valorTransacao, int numeroCupom, out int iNumeroControle, string tipoProduto, string codigoVeiculo,
          string codigoCondutor, int kilometragem, string dadosServicos, bool permiteAlteracao, string reservado)
        {
          iNumeroControle = 0;

          if (!CarregaDLL())
            return 11;

          StringBuilder pNumeroControle = new StringBuilder("0000000");
          StringBuilder pValorTransacao = new StringBuilder();
          pValorTransacao.AppendFormat("{0:d12}", (int)(valorTransacao * 100.0M));
          StringBuilder pNumeroCupom = new StringBuilder();
          pNumeroCupom.AppendFormat("{0:d6}", numeroCupom);
          StringBuilder p_tipoProduto = new StringBuilder(tipoProduto);
          StringBuilder p_codigoVeiculo = new StringBuilder(codigoVeiculo);
          StringBuilder p_codigoCondutor = new StringBuilder(codigoCondutor);
          StringBuilder p_kilometragem = new StringBuilder(kilometragem);
          StringBuilder p_dadosServicos = new StringBuilder(dadosServicos);
          StringBuilder pPermiteAlteracao = new StringBuilder(permiteAlteracao.ToString());
          StringBuilder p_reservado = new StringBuilder(reservado);

          dllTransacaoCartaoFrotaCompleta = (_TransacaoCartaoFrotaCompleta)GetDelegateFromDLL("TransacaoCartaoFrotaCompleta", typeof(_TransacaoCartaoFrotaCompleta));

          int iRes = dllTransacaoCartaoFrotaCompleta(pValorTransacao, pNumeroCupom, pNumeroControle, p_tipoProduto, p_codigoVeiculo, p_codigoCondutor, p_kilometragem,
          p_dadosServicos, pPermiteAlteracao, p_reservado);

          if (!bManterDLLCarregada)
            DescarregaDLL();

          if (iRes == 0)
          {
            iNumeroControle = Conversor.ToIntDef(pNumeroControle.ToString(), 0);
          }

          return iRes;
        }
    */
    #endregion

  }
}

