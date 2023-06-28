/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package testedpos;

import com.sun.jna.win32.StdCallLibrary;
import com.sun.jna.Library;
import com.sun.jna.Native;
import com.sun.jna.Platform;
import com.sun.jna.Pointer;
import java.lang.reflect.Method;

public interface TefSharedLibrary extends Library {

       TefSharedLibrary INSTANCE = (TefSharedLibrary) Native.loadLibrary((Platform.isWindows() ? "dposdrv" : "libdposdrv"),
            TefSharedLibrary.class);

   // public int TransacaoCartaoCredito(String pValorTransacao, String pNumeroCupomVenda, byte [] pNumeroControle);
   
    //------------------------------------------------
    
    
    public void VersaoDPOS(String pVersao);
    public int TransacaoCartaoFrota(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int ConfirmaCartaoFrota(byte [] pNumeroControle);
    public int TransacaoCartaoFrotaCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pTipoProduto, String pCodigoVeiculo, String pCodigoCondutor, String pKilometragem, String pDadosServicos,  String pPermiteAlteracao, String pReservado);
    public int ImprimeCupomTEF(String pPathArquivoCupomTEF, String pMensagemOperador);
    public int TransacaoCartaoCredito(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoCartaoDebito(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoCartaoParceleMais(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle,String pCodigoTabela);
    public int TransacaoCartaoParceleMaisCompleta(String pValorTransacao, String pNumeroCupom,byte [] pNumeroControle,String pCodigoTabela,String pNumeroParcelas, String pValorParcela,String pVencimentoPrimeiraParcela, String pPermiteAlteracao);
    public int TransacaoCartaoVoucher(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoCheque(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pQuantidadeCheques, String pPeriodicidadeCheques, String pDataPrimeiroCheque, String pCarenciaPrimeiroCheque);
    public int TransacaoCelular(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoCancelamentoCelular(byte [] pNumeroControle);
    public int TransacaoCancelamentoGarantiaCheque(String pValorTransacao, byte [] pNumeroControle);
    public int TransacaoCancelamentoPagamento(byte [] pNumeroControle);
    public int EstornoPreAutorizacaoRedecard(byte [] pNumeroControle);
    public int TransacaoConfirmacaoPreAutorizacao(byte [] pNumeroControle);
    public int TransacaoCancelamentoPagamentoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pPermiteAlteracao, byte [] pReservado);
    public int ConfirmaCartaoCredito(byte [] pNumeroControle);
    public int ConfirmaCartaoDebito(byte [] pNumeroControle);
    public int ConfirmaCartaoVoucher(byte [] pNumeroControle);
    public int ConfirmaDebitoBeneficiario(byte [] pNumeroControle);
    public int ConfirmaCartao(byte [] pNumeroControle);
    public int DesfazCartao(byte [] pNumeroControle);
    public int FinalizaTransacao();
    public int TransacaoConsultaParcelas(byte [] pNumeroControle);
    public int TransacaoConsultaParcelasCredito(byte [] pNumeroControle);
    public int TransacaoConsultaParcelasCelular(byte [] pNumeroControle);
    public int TransacaoPreAutorizacao(byte [] pNumeroControle);
    public int TransacaoPreAutorizacaoCartaoCredito(byte [] pNumeroControle);
    public int TransacaoPreAutorizacaoCartaoFrota(byte [] pNumeroControle);
    public int TransacaoFuncaoEspecial();
    public int TransacaoResumoVendas(byte [] pNumeroControle);
    public void DadosUltimaTransacao(byte [] pDadosUltimaTransacao);
    public void ObtemCodigoRetorno(int iCodigoRetorno, byte [] pCodigoRetorno);
    public void ObtemLogUltimaTransacao(byte [] oLogUltimaTransacao);
    public void ObtemLogUltimaTransacaoTeleMarketing(String pNumeroPDV, byte [] oLogUltimaTransacao);
    public void ObtemLogUltimaTransacaoTeleMarketingMultiLoja(String cNumeroEmpresa, String cNumeroLoja, String pNumeroPDV, byte [] oLogUltimaTransacao);
    public void ObtemComprovanteTransacao(String pNumeroControle, byte [] pComprovante, byte [] pComprovanteReduzido);
    public void DadosUltimaTransacaoDiscada(byte [] oDadosUltimaTransacaoDiscada);
    public void DadosUltimaTransacaoCB(byte [] pLogTitulo);
    public int TransacaoCartaoCreditoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pTipoOperacao, String pNumeroParcelas, String pValorParcela, String pValorTaxaServico, String pPermiteAlteracao, byte [] pReservado);
    public int TransacaoCartaoDebitoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pTipoOperacao, String pNumeroParcelas, String pSequenciaParcela, String pDataDebito, String pValorParcela, String pValorTaxaServico, String pPermiteAlteracao, String pReservado);
    public int TransacaoCartaoVoucherCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, byte [] pReservado);
    public int TransacaoChequeCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pQuantidadeCheques, String pPeriodicidadeCheques, String pDataPrimeiroCheque, String pCarenciaPrimeiroCheque, String pTipoDocumento, String pNumeroDocumento, String pQuantidadeChequesEx, String pSequenciaCheque, String pCamaraCompensacao, String pNumeroBanco, String pNumeroAgencia, String pNumeroContaCorrente, String pNumeroCheque, String pDataDeposito, String pValorCheque, String pDataNascimentoCliente, String pTelefoneCliente, String pCMC7, String pPermiteAlteracao, byte [] pReservado);
    public int TransacaoCartaoPrivateLabelCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pTipoOperacao, String pNumeroParcelas, String pValorEntrada, String pValorTaxaServico, String pPermiteAlteracao, byte [] pReservado);
    public int TransacaoSimulacaoPrivateLabel(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoConsultaPrivateLabel(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoPagamentoPrivateLabel(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoDebitoBeneficiario(String pValorTransacao, String pTipoBeneficio, String pNumeroBeneficio, String pNumeroCupom, byte [] pNumeroControle);
    public void InfAdicionaisCartaoDebito(byte [] pDadosParcelas);
    public void ObtemInfTransacaoDebitoParcelado(byte [] pDadosParcelas);
    public int ConsultaParametrosCB(byte [] pParametros);
    public int ConsultaPagamentoCB(String pTipoConta, String pCodigoBarrasDigitado, String pCodigoBarrasLido, String pValorTitulo, String pValorDesconto, String pValorAcrescimo, String pDataVencimento, String pFormaPagamento, String pTrilhaCartao, String pTipoSenha, String pSenha, String pNSUCartao, String pTipoCMC7, String pCMC7, byte [] pNumeroControle, byte [] pMensagemTEF, byte [] pImprimeComprovante, byte [] pParametros, byte [] pParametros2);
    public int TransacaoPagamentoCB(String pTipoConta, String pCodigoBarrasDigitado, String pCodigoBarrasLido, String pValorTitulo, String pValorDesconto, String pValorAcrescimo, String pDataVencimento, String pFormaPagamento, String pTrilhaCartao, String pTipoSenha, String pSenha, String pNSUCartao, String pTipoCMC7, String pCMC7, byte [] pParametros2, byte [] pNumeroControle);
    public int TransacaoCancelamentoCB(String pTipoConta, String pCodigoBarrasDigitado, String pCodigoBarrasLido, String pValorTitulo, String pNSUCartao, byte [] pNumeroControle);
    public int InicializaSessaoCB(byte [] pNumeroControle);
    public int FinalizaSessaoCB(byte [] pNumeroControle);
    public int TransacaoResumoRecebimentosCB(String pTipoRecebimento, byte [] pNumeroControle);
    public int UltimaMensagemTEF(byte [] pMensagem);
    public int TransacaoReimpressaoCupom();
    public void ConfiguraDPOS();
    public int InicializaDPOS();
    public int FinalizaDPOS();
    public int TransacaoFechamento(String pDataMovimento, String pQuantidadeVendas, String pValorTotalVendas, String pQuantidadeVendasCanceladas, String pValorTotalVendasCanceladas, String pReservado, byte [] pNumeroControle, byte [] pMensagemOperador);
    public int TransacaoFechamentoPOS(String pTipoRelatorio, String pParametrosRelatorio, String pReservado, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoAtivacaoPOS(String pCNPJ, String pNumeroSerie, String pCodAtivacao, byte [] pNumeroControle);
    public int TransacaoInicializacaoAreaPOS(String pCNPJ, String pNumeroSerie, byte [] pNumeroControle);
    public int TransacaoLojaPOS(String pCNPJ, String pNumeroSerie, String pCodigoEmpresa, String pCodigoLoja, String pCodigoPDV, byte [] pNumeroControle);
    public void ObtemUltimoErro(byte [] pErro);
    public void DadosUltimaTransacaoNaoAprovada(byte [] pDadosTransacaoNaoAprovada);
    public int TransacaoColeta(int nTipoCartao, String pValorTransacao, byte [] pTrilha1, byte [] pTrilha2, byte [] pTrilha3, String pParametros);
    public int TransacaoColetaCartao(int nTipoCartao, byte [] pTrilha1, byte [] pTrilha2, byte [] pTrilha3);
    public int TransacaoColetaSenha(String pValor, byte [] pSenha);
    public int TransacaoColetaSenhaCartao(int nTipoCartao, String pValor, String pTrilha2, String pReservado, byte [] pSenha);
    public int ColetaPlanoPagamento(String pDescricaoFormaPagamento, String pValorTransacao, String pNumeroCupom, String pTipoFormaPagamento, byte [] pNumeroControle, byte [] pNumeroParcelas, byte [] pValorAcrescimo, byte [] pValorEntrada, byte [] pValorTotal, byte [] pCodigoPlano, byte [] pPlano, byte [] pParcelas);
    public int TransacaoAdministrativaTEFDiscado(byte [] pNumeroControle);
    public void SelecionaTEF();
    public void ExportaPlanos();
    //public int ColetaChequesPre(String pDescricaoPlanoPagamento, TList *oParcelas);
    public int TransacaoQuantidade(String pValorTransacao, String pValorTransacaoMaximo, String pNumeroCupom);
    public int TransacaoValor(String pValorTransacao, String pValorTransacaoMaximo, String pNumeroCupom);
    public int TransacaoCartaoCreditoConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pNumeroCartao, String pDataVencimento, String pCVV2, String pTipoOperacao, String pNumeroParcelas, String pValorTaxaServico, byte [] pMensagemTEF, String pReservado);
    public int TransacaoCancelamentoConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, byte [] pNumeroControle, String pNumeroCartao, byte [] pMensagemTEF, byte [] pReservado);
    public int PreAutorizacaoCreditoConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pNumeroCartao, String pDataVencimento, String pCVV2, String pValorTaxaServico, String pNumeroAutorizacao, byte [] pMensagemTEF, byte [] pReservado);
    public int ConfPreAutorizacaoCreditoConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pDataPreAutor, String pNumeroCartao, String pDataVencimento, String pCVV2, String pTipoOperacao, String pNumeroParcelas, byte [] pMensagemTEF, byte [] pReservado);
    public int TransacaoManualPOS (String pValorTransacao);
    public int TransacaoManualPOSCompleta (byte [] pValorTransacao, byte [] pCodigoEstabelecimento, byte [] pData, byte [] pHora, byte [] pNumeroAutorizadora, byte [] pNumeroCartao, byte [] pTipoOperacao, byte [] pNumeroParcelas, byte [] pDataPreDatado, byte [] pNumeroControle);
    public int TransacaoCartaoFidelidade(String pValorTransacao, String pNumeroCupom, String pCompraPontos, String pQuantidadeItensTaxaVariavel, String pItensTaxaVariavel, byte [] pNumeroControle);
    public int TransacaoDebitoFidelidade(String pNumeroCupom, byte [] pNumeroControle);
    public int ConfirmaCartaoFidelidade(byte [] pNumeroControle);
    public int ExtratoCartaoAutorizadorDirecao(String pNumeroCartao, byte [] pNumeroControle);
    public int RecebimentoAutorizadorDirecao(String pValorTransacao, String pNumeroCartao, byte [] pNumeroControle);
    public int EstornoRecebimentoAutorizadorDirecao(String pValorTransacao, String pNumeroCartao, byte [] pNumeroControle);
    public int RecebimentoCarneAutorizadorDirecao(String pValorTransacao, String pNumeroCartao, String pDataVencimento, byte [] pNumeroControle);
    public int TransacaoPagamentoConvenio(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int ConfirmaConvenio(byte [] pNumeroControle);
    public int TransacaoSaqueRedecard(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle);
    public int TransacaoSaque(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle);
    public int TransacaoCDC1MIN(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle);
    public int TransacaoSIMparcelado(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle);
    public int TransacaoCartaoCreditoIATA(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoCartaoCreditoIATAConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pNumeroCartao, String pDataVencimento, String pCVV2, String pTipoOperacao, String pNumeroParcelas, String pValorTaxaServico,String pValorEntrada, byte [] pMensagemTEF, byte [] pReservado);
    public int TransacaoCartaoPrivateLabel(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public void BeepErro();
    public int TransacaoConsultaSaldo(String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoConsultaSaldoCelular(String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoConsultaSaldoCompleta(String pNumeroCupom, byte [] pNumeroControle, String pTipoCartao, String pPermiteAlteracao, String pReservado);
    public int ColetaCartaoDebito(String pValorTransacao, String pNumeroCupom, byte [] pParametrosTEF, byte [] pMensagemOperador);
    public int ConsisteDadosCartaoDebito(String pUltimosDigitos, String pCodigoSeguranca, byte [] pMensagemOperador);
    public int ColetaSenhaCartaoDebito(byte [] pNumeroControle, byte [] pMensagemOperador);
    public int ConsultaParametrosPBM(String pNumeroCupom, String pQuantidadeRedes, String pDadosRedes, String pMensagemOperador);
    public int ConsultaProdutosPBM(String pNumeroCupom, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, String pAutorizacao, byte [] pDadosCRM, byte [] pTipoVenda, byte [] pValorTotalMedicamentos, byte [] pValorVista, byte [] pValorCartao, byte [] pCodigoCredenciado, byte [] pQuantidadeMedicamentos, byte [] pMedicamentos, byte [] pReservado, byte [] pNumeroControle, byte [] pMensagemOperador);
    public int TransacaoVendaPBM(byte [] pValorTotalMedicamentos, String pNumeroCupom, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, String pAutorizacao, String pNSUConsulta, String pDadosCRM, String pTipoVenda, String pValorVista, String pValorCartao, String pCodigoCredenciado, String pRegraNegocio, byte [] pQuantidadeMedicamentos, byte [] pMedicamentos, byte [] pReservado, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pMensagemOperador);
    public int ConfirmaVendaPBM(byte [] pNumeroControle);
    public int TransacaoReimpressaoVendaPBM();
    public int TransacaoCancelamentoVendaPBM(byte [] pNumeroControle);
    public int TransacaoCancelamentoPreAutorizacaoPBM(byte [] pNumeroControle);
    public int TransacaoElegibilidadePBM(String pNumeroCupom, String pRedePBM, String pMatricula, String pDadosElegibilidade, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pNomeCliente, byte [] pNomeMedico, byte [] pInformaDependente, byte [] pListaDependentes, byte [] pReservado, byte [] pMensagemOperador);
    public int TransacaoPreAutorizacaoPBM(String pNumeroCupom, String pRedePBM, String pAutorizacaoElegibilidade, String pDadosFarmaceutico, byte [] pQuantidadeMedicamentos, byte [] pMedicamentos, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pReservado, byte [] pMensagemOperador);
    public int TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pMatricula, String pReservado, byte [] pNumeroControle, byte [] pMensagemOperador);
    public int TransacaoElegibilidadePBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom, String pRedePBM, String pMatricula, String pDadosElegibilidade, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pNomeCliente, byte [] pNomeMedico, byte [] pInformaDependente, byte [] pListaDependentes, byte [] pReservado, byte [] pMensagemOperador);
    public int TransacaoPreAutorizacaoPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom, String pRedePBM, String pAutorizacaoElegibilidade, String pDadosFarmaceutico, byte [] pQuantidadeMedicamentos, byte [] pMedicamentos, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pReservado, byte [] pMensagemOperador);
    public int ConsultaParametrosPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom, byte [] pQuantidadeRedes, byte [] pDadosRedes, byte [] pMensagemOperador);
    public int ConsultaProdutosPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, String pAutorizacao, String pDadosCRM, byte [] pTipoVenda, byte [] pValorTotalMedicamentos, byte [] pValorVista, byte [] pValorCartao, byte [] pCodigoCredenciado, byte [] pQuantidadeMedicamentos, byte [] pMedicamentos, byte [] pReservado, byte [] pNumeroControle, byte [] pMensagemOperador);
    public int TransacaoVendaPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTotalMedicamentos, String pNumeroCupom, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, String pAutorizacao, String pNSUConsulta, String pDadosCRM, String pTipoVenda, String pValorVista, String pValorCartao, String pCodigoCredenciado, String pRegraNegocio, byte [] pQuantidadeMedicamentos, byte [] pMedicamentos, byte [] pReservado, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pMensagemOperador);
    public int TransacaoCancelamentoVendaPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pTrilha1, String pTrilha2, String pDigitado, byte [] pReservado, byte [] pNumeroControle, byte [] pMensagemOperador);
    public int TransacaoAberturaVendaPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, byte [] pReservado, byte [] pPedirDadosComplementares, byte [] pDadosComplementares, byte [] pInfoDadosComplementares, byte [] pMensagemOperador);
    public int TransacaoVendaProdutoPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, byte [] pMedicamento, byte [] pReservado, byte [] pPedirDadosComplementares, byte [] pDadosComplementares,  byte [] pInfoDadosComplementares, byte [] pMensagemOperador);
    public int TransacaoFechamentoVendaPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, String pConfirmacao, byte [] pReservado, byte [] pAutorizacao, byte [] pNumeroControle, byte [] pMensagemOperador);
    public void InformaDadosMedicamentos(byte [] pIndicativoReceita, byte [] pRegistroProfissional, byte [] pListaMedicamentos);
    public int TransacaoSaqueSaldo(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoSaqueExtrato(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoConsultaAVS(byte [] pNumeroControle);
    public int TransacaoConsultaAVSConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom, byte [] pNumeroControle, String pNumeroCartao, String pDataVencimento, String pCVV2, String pEndereco, String pNumero, String pApto, String pBloco, String pCEP, String pBairro, String pCPF, byte [] pMensagemTEF, byte [] pReservado);
    public int TransacaoPagamentoContasVisanet(byte [] pTipoConta, byte [] pCodigoBarras, byte [] pFormaPagamento, byte [] pTrilhaCartao, byte [] pValorTransacao, byte [] pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoEspecial(int iCodigoTransacao, String pDados);
    public int ConsultaValoresPrePago(byte [] pNumeroControle, byte [] pMensagemOperador);
    public int TransacaoRecargaCelular(byte [] pCodigoArea, byte [] pNumeroTelefone, byte [] pNumeroControle);
    public int ConsultaParametrosTeledata(byte [] pDadosTeledata, byte [] pMensagemOperador);
    public int ConsultaChequesGarantidos(String pTipoDocumento, String pNumeroDocumento, String pDataInicialConsulta, String pDataFinalConsulta, byte [] pNumeroControle);
    public int TransacaoSaqueCompleta(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle, String pTipoTransacao, String pPlanoPagamento, String pNumeroParcelas, String pPermiteAlteracao, String pReservado);
    public int TransacaoCartaoCompraSaque(String pValorCompra,String pValorSaque, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoCartaoCompraSaqueCompleta(String pValorCompra,String pValorSaque, String pNumeroCupom,byte [] pNumeroControle,String pPermiteAlteracao);
    public int TesteRedeAtiva(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV, String pCodigoRede, byte [] pStatusRede, byte [] pMensagemOperador);
    public int TransacaoCadastraSenha(byte [] pNumeroControle);
    public void ConfiguraFluxoExternoDTEF5();
    public int TrataDesfazimento(int iTratar);
    public int ConsultaTransacao(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV, String pSolicitacao, byte [] pResposta, byte [] pMensagemErro);
    public int TransacaoeValeGas(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pNumeroValeGas);
    public int TransacaoConsultaeValeGas(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pNumeroValeGas, byte [] pDadosRetorno);
    public int TransacaoCancelamentoPadrao(byte [] pNumeroControle);
    public int ConfiguraModoTeleMarketing(int iModo);
    public int ConfirmaCartaoTeleMarketing(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, byte [] pNumeroControle, byte [] pMensagemTEF, String pReservado);
    public int DesfazCartaoTeleMarketing(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, byte [] pNumeroControle, byte [] pMensagemTEF, String pReservado);
    public int TransacaoEstatistica(byte [] pNumeroControle);
    public int TransacaoInjecaoChaves(byte [] pNumeroControle);
    public int TransacaoTrocoSurpresa(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, byte [] pMensagemTEF, String pReservado);
    public int IdentificacaoAutomacaoComercial(String pNomeAutomacao, String pVersaoAutomacao, String pReservado);
    public int ConsultaTabelasValeGas(byte [] pNumeroControle, byte [] pMensagemOperador);
    public int DefineBandeiraTransacao(String pCodigoBandeira);
    public int DefineRedeTransacao(String pCodigoRede);
    public int ConverteCodigoRede(String pCodigoRede, byte [] pCodigoRedeDTEF5, byte [] pCodigoRedeDTEF8);
    public int TransacaoAbreLote(String pNumeroCupom, byte [] pNumeroControle, byte [] pMensagemTEF, String pReservado);
    public int TransacaoFechaLote(String pNumeroCupom, byte [] pNumeroControle, String pMensagemTEF, String pReservado);
    public void ConfiguraEmpresaLojaPDV(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV);
    public int TransacaoResgatePremio(String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoVendaPOS(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, String pPagamentoTEF, String pCartaoProprio, String pValor, String pTelefoneCliente, String pCodigoOrigem, byte [] pSaldoPontos, byte [] pCodigoPesquisa, byte [] pReservado, byte [] pNumeroControle);
    public int TransacaoEstornoVendaPOS(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, String pDataEstorno, String pNSUEstorno, String pAutorizacaoEstorno, byte [] pSaldoPontos, byte [] pNumeroControle);
    public int TransacaoResgatePontosPOS(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, String pQuantidadeProdutos, String pListaProdutos, byte [] pSaldoPontos, String pReservado, byte [] pNumeroControle);
    public int TransacaoConsultaPontosPOS(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, byte [] pSaldoPontos, String pReservado, byte [] pNumeroControle);
    public int AtualizacaoFrentistasPOS(String pCNPJ, String pNumeroSerie, byte [] pNumeroFrentistas, byte [] pListaFrentistas, String pReservado, byte [] pNumeroControle);
    public int BuscaTabelaDTEF(int iTipoTabela, byte [] pNumeroControle);
    public int TransacaoContratacao(String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoPrimeiraCompra(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoCadastro(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, String pTelefoneCliente, String pReservado, byte [] pNumeroControle);
    public int TransacaoDesativacaoPOS(String pCNPJ, String pNumeroSerie, String pNumeroSerieDesativacao, String pFrentista, byte [] pNumeroControle);
    public int TransacaoConsultaPOSAtivos(String pCNPJ, String pNumeroSerie, String pNumeroPOSAtivos, String pListaPOSAtivos, byte [] pNumeroControle);
    public int ProcuraPinPad(byte [] pDados);
    public int ApagaTabelasPinPad(String pDados);
    public int TransacaoFuncoesAdministrativas(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pReservado);
    public int TransacaoQuitacaoCartaFrete(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoQuitacaoCartaFreteCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle,String pNumeroCartaFrete,String pQuantidadeChegada, String pPermiteAlteracao, String pReservado);
    public int TransacaoCartaoCrediario(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoSimulacaoCrediario(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoPagamentoPrivateLabelCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pIndicadorDigitacao, String pCodigoBarras, String pNumeroCartao, String pCodigoRede, String pPermiteAlteracao, String pReservado);
    public int TransacaoCargaCartao(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoRecargaCartao(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int CadastraPDV();
    public int CadastraPDVTelemarketing(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV, byte [] pMensagemTEF);
    public int TransacaoCartaoCrediarioCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, byte [] pNumeroParcelas, byte [] pDataParcela1, byte [] pValorParcela1, byte [] pValorEntrada, String pPermiteAlteracao, byte [] pReservado);
    public int TransacaoConsultaPlanos(String pValorTransacao, byte [] pNumeroControle, byte [] pReservado, byte [] pPlanos);
    public int ConsultaCadastroPDV(byte [] pMensagem);
    public int ConsultaCadastroPDVTelemarketing(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV, byte [] pMensagemTEF);
    public int TransacaoSimulacaoSaque(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoBloqueioCartao(String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoDesbloqueioCartao(String pNumeroCupom, byte [] pNumeroControle);
    public int TransacaoConsultaCadastroCPFCompleta(String pValorTransacao,String pNumeroCupom, byte [] pNumeroControle,byte [] pTipoOperacao,byte [] pDocEmissor,byte [] pPermiteAlteracao,byte [] pReservado);
    public int TransacaoDepositoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle,byte [] pTipoOperacao,byte [] pDocEmissor,byte [] pDocDestinatario,byte [] pPermiteAlteracao,byte [] pReservado);
    public int TransacaoSaqueDomesticoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle,byte [] pTipoOperacao,byte [] pCodigoPIN,byte [] pDocDestinatario,byte [] pPermiteAlteracao, byte [] pReservado);
    public int TransacaoAlteraSenhaUsuarioDTEF(String pNumeroCupom, byte [] pNumeroControle);
    public int DefineParametroTransacao(int iCodigoParametro, String pValorParametro, int iTamanhoParametro);
//================testes===========================================================================================================
    
    // funções exportadas para registro das funções callback de telas chamadas pela automação
    public void RegPDVDisplayTerminal(iDisplayTerminal displayTerminal);
    public void RegPDVDisplayErro(iDisplayErro displayErro);
    public void RegPDVMensagem(iMensagem mensagem);
    public void RegPDVBeep(iBeep beep);
    public void RegPDVSolicitaConfirmacao(iSolicitaConfirmacao solicitaConfirmacao);
    public void RegPDVEntraCartao(iEntraCartao entraCartao);
    public void RegPDVEntraDataValidade(iEntraDataValidade entraDataValidade);
    public void RegPDVEntraData(iEntraData entraData);
    public void RegPDVEntraCodigoSeguranca(iEntraCodigoSeguranca entraCodigoSeguranca);
    public void RegPDVSelecionaOpcao(iSelecionaOpcao selecionaOpcao);
    public void RegPDVEntraValor(iEntraValor entraValor);
    public void RegPDVEntraNumero(iEntraNumero entraNumero);
    public void RegPDVOperacaoCancelada(iOperacaoCancelada operacaoCancelada);
    public void RegPDVSetaOperacaoCancelada(iSetaOperacaoCancelada setaOperacaoCancelada);
    public void RegPDVProcessaMensagens(iProcessaMensagens processaMensagens);
    public void RegPDVEntraString(iEntraString entraString);
    public void RegPDVConsultaAVS(iConsultaAVS consultaAVS);
    public void RegPDVMensagemAdicional(iMensagemAdicional mensagemAdicional);
    public void RegPDVImagemAdicional(iImagemAdicional imagemAdicional);
    public void RegPDVDadosHistorico(iDadosHistorico dadosHistorico);
    public void RegPDVEntraCodigoBarras(iEntraCodigoBarras entraCodigoBarras);
    public void RegPDVEntraCodigoBarrasLido(iEntraCodigoBarrasLido entraCodigoBarrasLido);
    public void RegPDVMensagemAlerta(iMensagemAlerta mensagemAlerta);
    public void RegPDVPreviewComprovante(iPreviewComprovante previewComprovante);
    public void RegPDVSelecionaPlanos(iSelecionaPlanos selecionaPlanos);
    public void RegPDVSelecionaPlanosEx(iSelecionaPlanosEx selecionaPlanosEx);
    
    public interface iDisplayTerminal extends StdCallLibrary.StdCallCallback{
        public void pCallBackDisplayTerminal(String pMensagem);
    }
    
    public interface iDisplayErro extends  StdCallLibrary.StdCallCallback{
        public void pCallBackDisplayErro(String pMensagem);
    }
    
    public interface iMensagem extends  StdCallLibrary.StdCallCallback{
        public void pCallBackMensagem(String pMensagem);
    }
            
    public interface iBeep extends  StdCallLibrary.StdCallCallback{
        public void pCallBackBeep();
    }
    
    public interface iSolicitaConfirmacao extends  StdCallLibrary.StdCallCallback{
        public int pCallBackSolicitaConfirmacao(String pMensagem);
    }
    
    public interface iEntraCartao extends StdCallLibrary.StdCallCallback{
        public int pCallBackEntraCartao(String pLabel, Pointer pCartao);
    }
    
    public interface iEntraData extends  StdCallLibrary.StdCallCallback{
        public int pCallBackEntraData(String pLabel, Pointer pDataValidade);
    }
    
    public interface iEntraDataValidade extends  StdCallLibrary.StdCallCallback{
        public int pCallBackEntraDataValidade(String pLabel, Pointer pDataValidade);
    }
        
    public interface iEntraCodigoSeguranca extends  StdCallLibrary.StdCallCallback{
        public int pCallBackEntraCodigoSeguranca(String pLabel, Pointer pEntraCodigoSeguranca,int iTamanhoMax);
    }
    
    public interface iSelecionaOpcao extends  StdCallLibrary.StdCallCallback{
        public int pCallBackSelecionaOpcao(String pLabel, String pOpcoes, int iOpcaoSelecionada);
    }
       
    public interface iEntraValor extends  StdCallLibrary.StdCallCallback{
        public int pCallBackEntraValor(String pLabel, Pointer pValor, String pValorMinimo, String pValorMaximo);
    }    
    
    public interface iEntraNumero extends  StdCallLibrary.StdCallCallback{
        public int pCallBackEntraNumero(String pLabel, Pointer pNumero, String pNumeroMinimo, String pNumeroMaximo,int iMinimoDigitos,int iMaximoDigitos,int iDigitosExatos);
    }
    
    public interface iOperacaoCancelada extends  StdCallLibrary.StdCallCallback{
        public int pCallBackOperacaoCancelada ();
    }
    public interface iSetaOperacaoCancelada extends  StdCallLibrary.StdCallCallback{
        public int pCallBackSetaOperacaoCancelada(boolean bCancelada);
    }
    public interface iProcessaMensagens extends  StdCallLibrary.StdCallCallback{
        public void pCallBackProcessaMensagens();
    }
    public interface iEntraString extends  StdCallLibrary.StdCallCallback{
        public int pCallBackEntraString(String pLabel, Pointer pString, String pTamanhoMaximo);
    }
    public interface iConsultaAVS extends  StdCallLibrary.StdCallCallback{
        public int pCallBackConsultaAVS(Pointer cEndereco,Pointer cNumero,Pointer cApto,Pointer cBloco,Pointer cCEP,Pointer cBairro,Pointer cCPF);
    }
    public interface iMensagemAdicional extends  StdCallLibrary.StdCallCallback{
        public int pCallBackMensagemAdicional(String pMensagemAdicional); 
    }
    public interface iImagemAdicional extends  StdCallLibrary.StdCallCallback{
        public int pCallBackImagemAdicional(int iIndiceImagem);
    }
    public interface iEntraCodigoBarras extends  StdCallLibrary.StdCallCallback{
        public int pCallBackEntraCodigoBarras(String Label,Pointer Campo);
    }
    public interface iEntraCodigoBarrasLido extends  StdCallLibrary.StdCallCallback{
        public int pCallBackEntraCodigoBarrasLido(String Label,Pointer Campo);
    }
    public interface iMensagemAlerta extends  StdCallLibrary.StdCallCallback{
        public void pCallBackMensagemAlerta(String pMensagemAlerta);
    }
    public interface iPreviewComprovante extends  StdCallLibrary.StdCallCallback{
        public void pCallBackPreviewComprovante(String cComprovante);
    }
    public interface iSelecionaPlanos extends  StdCallLibrary.StdCallCallback{
        public int pCallBackSelecionaPlanos(int iCodigoRede, int iCodigoTransacao, int iTipoFinanciamento, int iMaximoParcelas, Pointer pValorMinimoParcela,
                   int iMaxDiasPreDatado, Pointer pNumeroParcelas, Pointer pValorTransacao, Pointer pValorParcela, Pointer pValorEntrada, Pointer pData);
    }
    public interface iSelecionaPlanosEx extends  StdCallLibrary.StdCallCallback{
        public int pCallBackSelecionaPlanosEx(Pointer pSolicitacao, Pointer pRetorno);
    }
    public interface iDadosHistorico extends  StdCallLibrary.StdCallCallback{
        public int pCallBackDadosHistorico(String parte1, int tamParte1, String parte2, int tamParte2);
    }     
}