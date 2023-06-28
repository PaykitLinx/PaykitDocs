/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package testedpos;

import com.sun.jna.Memory;
import com.sun.jna.Pointer;
import java.nio.charset.Charset;


/**
 *
 * @author jmachado
 */
public class TefManager {
    
    
    public int TransacaoCartaoCredito(String pValorTransacao, String pNumeroCupomVenda, byte[] pNumeroControle) {
        return TefSharedLibrary.INSTANCE.TransacaoCartaoCredito(pValorTransacao,
                pNumeroCupomVenda, pNumeroControle);
    }
    
    public int TransacaoCartaoDebito(String pValorTransacao, String pNumeroCupomVenda, byte[] pNumeroControle) {
        return TefSharedLibrary.INSTANCE.TransacaoCartaoDebito(pValorTransacao,
                pNumeroCupomVenda, pNumeroControle);
    }
    
    public int TransacaoCartaoParceleMais(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle,String pCodigoTabela){ 
         return TefSharedLibrary.INSTANCE.TransacaoCartaoParceleMais(pValorTransacao,
                 pNumeroCupom, pNumeroControle, pCodigoTabela);
    }
    public int TransacaoCartaoParceleMaisCompleta(String pValorTransacao, String pNumeroCupom,byte [] pNumeroControle,String pCodigoTabela,
               String pNumeroParcelas, String pValorParcela,String pVencimentoPrimeiraParcela, String pPermiteAlteracao){ 
        return TefSharedLibrary.INSTANCE.TransacaoCartaoParceleMaisCompleta(pValorTransacao,
                pNumeroCupom, pNumeroControle, pCodigoTabela, pNumeroParcelas, 
                pValorParcela,pVencimentoPrimeiraParcela,pPermiteAlteracao);
    }
    public int TransacaoCartaoVoucher(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoCartaoVoucher(pValorTransacao,
                pNumeroCupom, pNumeroControle);       
    }
    public int TransacaoCheque(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pQuantidadeCheques,
               String pPeriodicidadeCheques, String pDataPrimeiroCheque, String pCarenciaPrimeiroCheque){ 
        return TefSharedLibrary.INSTANCE.TransacaoCheque(pValorTransacao, pNumeroCupom,
                pNumeroControle, pQuantidadeCheques, pPeriodicidadeCheques, pDataPrimeiroCheque,
                pCarenciaPrimeiroCheque);
    }
    public int TransacaoCelular(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoCelular(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int TransacaoCancelamentoCelular(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoCelular(pNumeroControle);
    }
    public int TransacaoCancelamentoGarantiaCheque(String pValorTransacao, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoGarantiaCheque(pValorTransacao, pNumeroControle);
    }
    public int TransacaoCancelamentoPagamento(byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoPadrao(pNumeroControle);
    }
    public int EstornoPreAutorizacaoRedecard(byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.EstornoPreAutorizacaoRedecard(pNumeroControle);
    }
    public int TransacaoConfirmacaoPreAutorizacao(byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoConfirmacaoPreAutorizacao(pNumeroControle);
    }
    public int TransacaoCancelamentoPagamentoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pPermiteAlteracao, byte [] pReservado){ 
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoPagamentoCompleta(pValorTransacao,
                pNumeroCupom, pNumeroControle, pPermiteAlteracao, pReservado);
    }
    public int ConfirmaCartaoCredito(byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.ConfirmaCartaoCredito(pNumeroControle);
    }
    public int ConfirmaCartaoDebito(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.ConfirmaCartaoDebito(pNumeroControle);
    }
    public int ConfirmaCartaoVoucher(byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.ConfirmaCartaoVoucher(pNumeroControle);
    }
    public int ConfirmaDebitoBeneficiario(byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.ConfirmaDebitoBeneficiario(pNumeroControle);
    }
    public int ConfirmaCartao(byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.ConfirmaCartao(pNumeroControle);
    }
    public int DesfazCartao(byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.DesfazCartao(pNumeroControle);
    }
    public int FinalizaTransacao(){ 
        return TefSharedLibrary.INSTANCE.FinalizaTransacao();
    }
    public int TransacaoConsultaParcelas(byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoConsultaParcelas(pNumeroControle);
    }
    public int TransacaoConsultaParcelasCredito(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoConsultaParcelasCredito(pNumeroControle);
    }
    public int TransacaoConsultaParcelasCelular(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoConsultaParcelasCelular(pNumeroControle);
    }
    public int TransacaoPreAutorizacao(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoPreAutorizacao(pNumeroControle);
    }
    public int TransacaoPreAutorizacaoCartaoCredito(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoPreAutorizacaoCartaoCredito(pNumeroControle);
    }
    public int TransacaoPreAutorizacaoCartaoFrota(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoPreAutorizacaoCartaoFrota(pNumeroControle);
    }
    public int TransacaoFuncaoEspecial(){
        return TefSharedLibrary.INSTANCE.TransacaoFuncaoEspecial();
    }
    public int TransacaoResumoVendas(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoResumoVendas(pNumeroControle);
    }
    public void DadosUltimaTransacao(byte [] pDadosUltimaTransacao){
         TefSharedLibrary.INSTANCE.DadosUltimaTransacao(pDadosUltimaTransacao);
    }
    public void ObtemCodigoRetorno(int iCodigoRetorno, byte [] pCodigoRetorno){ 
         TefSharedLibrary.INSTANCE.ObtemCodigoRetorno(iCodigoRetorno, pCodigoRetorno);
    }
    public void ObtemLogUltimaTransacao(byte [] oLogUltimaTransacao){
        TefSharedLibrary.INSTANCE.ObtemLogUltimaTransacao(oLogUltimaTransacao);
    }
    public void ObtemLogUltimaTransacaoTeleMarketing(String pNumeroPDV, byte [] oLogUltimaTransacao){
        TefSharedLibrary.INSTANCE.ObtemLogUltimaTransacaoTeleMarketing(pNumeroPDV, oLogUltimaTransacao);
    }
    public void ObtemLogUltimaTransacaoTeleMarketingMultiLoja(String cNumeroEmpresa, String cNumeroLoja, String pNumeroPDV, byte [] oLogUltimaTransacao){
        TefSharedLibrary.INSTANCE.ObtemLogUltimaTransacaoTeleMarketingMultiLoja(cNumeroEmpresa,
                cNumeroLoja, pNumeroPDV, oLogUltimaTransacao);
    }
    public void ObtemComprovanteTransacao(String pNumeroControle, byte [] pComprovante, byte [] pComprovanteReduzido){ 
        TefSharedLibrary.INSTANCE.ObtemComprovanteTransacao(pNumeroControle,
                pComprovante, pComprovanteReduzido);
    }
    public void DadosUltimaTransacaoDiscada(byte [] oDadosUltimaTransacaoDiscada){
        TefSharedLibrary.INSTANCE.DadosUltimaTransacaoDiscada(oDadosUltimaTransacaoDiscada);
    }
    public void DadosUltimaTransacaoCB(byte [] pLogTitulo){
        TefSharedLibrary.INSTANCE.DadosUltimaTransacaoCB(pLogTitulo);
    }
    public int TransacaoCartaoCreditoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pTipoOperacao,
               String pNumeroParcelas, String pValorParcela, String pValorTaxaServico, String pPermiteAlteracao, byte [] pReservado){
        
        return TefSharedLibrary.INSTANCE.TransacaoCartaoCreditoCompleta(pValorTransacao,
               pNumeroCupom, pNumeroControle, pTipoOperacao, pNumeroParcelas,
               pValorParcela, pValorTaxaServico, pPermiteAlteracao, pReservado);
    }
    public int TransacaoCartaoDebitoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pTipoOperacao,
               String pNumeroParcelas, String pSequenciaParcela, String pDataDebito, String pValorParcela, String pValorTaxaServico,
               String pPermiteAlteracao, String pReservado){ 
        
        return TefSharedLibrary.INSTANCE.TransacaoCartaoDebitoCompleta(pValorTransacao, pNumeroCupom,
                pNumeroControle, pTipoOperacao, pNumeroParcelas, pSequenciaParcela,
                pDataDebito, pValorParcela, pValorTaxaServico, pPermiteAlteracao, pReservado);
    }
    public int TransacaoCartaoVoucherCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, byte [] pReservado){
        return TefSharedLibrary.INSTANCE.TransacaoCartaoVoucherCompleta(pValorTransacao,
                pNumeroCupom, pNumeroControle, pReservado);
    }
    public int TransacaoChequeCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pQuantidadeCheques,
               String pPeriodicidadeCheques, String pDataPrimeiroCheque, String pCarenciaPrimeiroCheque, String pTipoDocumento,
               String pNumeroDocumento, String pQuantidadeChequesEx, String pSequenciaCheque, String pCamaraCompensacao, String pNumeroBanco,
               String pNumeroAgencia, String pNumeroContaCorrente, String pNumeroCheque, String pDataDeposito, String pValorCheque,
               String pDataNascimentoCliente, String pTelefoneCliente, String pCMC7, String pPermiteAlteracao, byte [] pReservado){ 
        
        return TefSharedLibrary.INSTANCE.TransacaoChequeCompleta(pValorTransacao, pNumeroCupom,
                pNumeroControle, pQuantidadeCheques, pPeriodicidadeCheques, pDataPrimeiroCheque,
                pCarenciaPrimeiroCheque, pTipoDocumento, pNumeroDocumento, pQuantidadeChequesEx,
                pSequenciaCheque, pCamaraCompensacao, pNumeroBanco, pNumeroAgencia, pNumeroContaCorrente,
                pNumeroCheque, pDataDeposito, pValorCheque, pDataNascimentoCliente, pTelefoneCliente,
                pCMC7, pPermiteAlteracao, pReservado);
    }
    public int TransacaoCartaoPrivateLabelCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pTipoOperacao,
               String pNumeroParcelas, String pValorEntrada, String pValorTaxaServico, String pPermiteAlteracao, byte [] pReservado){
        
        return TefSharedLibrary.INSTANCE.TransacaoCartaoPrivateLabelCompleta(pValorTransacao,
                pNumeroCupom, pNumeroControle, pTipoOperacao, pNumeroParcelas, pValorEntrada,
                pValorTaxaServico, pPermiteAlteracao, pReservado);
    }
    public int TransacaoSimulacaoPrivateLabel(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoSimulacaoPrivateLabel(pValorTransacao,
               pNumeroCupom, pNumeroControle);      
    }
    public int TransacaoConsultaPrivateLabel(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoConsultaPrivateLabel(pValorTransacao,
               pNumeroCupom, pNumeroControle);
        
    }
    public int TransacaoPagamentoPrivateLabel(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoPagamentoPrivateLabel(pValorTransacao,
               pNumeroCupom, pNumeroControle);
    }
    public int TransacaoDebitoBeneficiario(String pValorTransacao, String pTipoBeneficio, String pNumeroBeneficio, String pNumeroCupom, byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoDebitoBeneficiario(pValorTransacao,
               pTipoBeneficio, pNumeroBeneficio, pNumeroCupom, pNumeroControle);
    }
    public void InfAdicionaisCartaoDebito(byte [] pDadosParcelas){
        TefSharedLibrary.INSTANCE.InfAdicionaisCartaoDebito(pDadosParcelas);
    }
    public void ObtemInfTransacaoDebitoParcelado(byte [] pDadosParcelas){
        TefSharedLibrary.INSTANCE.ObtemInfTransacaoDebitoParcelado(pDadosParcelas);
    }
    public int ConsultaParametrosCB(byte [] pParametros){
       return TefSharedLibrary.INSTANCE.ConsultaParametrosCB(pParametros);
    }
    public int ConsultaPagamentoCB(String pTipoConta, String pCodigoBarrasDigitado, String pCodigoBarrasLido, String pValorTitulo, String pValorDesconto,
            String pValorAcrescimo, String pDataVencimento, String pFormaPagamento, String pTrilhaCartao, String pTipoSenha, String pSenha, String pNSUCartao,
            String pTipoCMC7, String pCMC7, byte [] pNumeroControle, byte [] pMensagemTEF, byte [] pImprimeComprovante, byte [] pParametros, byte [] pParametros2){
        
        return TefSharedLibrary.INSTANCE.ConsultaPagamentoCB(pTipoConta, pCodigoBarrasDigitado,
                pCodigoBarrasLido, pValorTitulo, pValorDesconto, pValorAcrescimo, pDataVencimento,
                pFormaPagamento, pTrilhaCartao, pTipoSenha, pSenha, pNSUCartao, pTipoCMC7, pCMC7,
                pNumeroControle, pMensagemTEF, pImprimeComprovante, pParametros, pParametros2);
                
    }
    public int TransacaoPagamentoCB(String pTipoConta, String pCodigoBarrasDigitado, String pCodigoBarrasLido, String pValorTitulo, String pValorDesconto,
            String pValorAcrescimo, String pDataVencimento, String pFormaPagamento, String pTrilhaCartao, String pTipoSenha, String pSenha, String pNSUCartao,
            String pTipoCMC7, String pCMC7, byte [] pParametros2, byte [] pNumeroControle){
        
        return TefSharedLibrary.INSTANCE.TransacaoPagamentoCB(pTipoConta, pCodigoBarrasDigitado,
                pCodigoBarrasLido, pValorTitulo, pValorDesconto, pValorAcrescimo, pDataVencimento,
                pFormaPagamento, pTrilhaCartao, pTipoSenha, pSenha, pNSUCartao, pTipoCMC7, pCMC7,
                pParametros2, pNumeroControle);
    
    }
    public int TransacaoCancelamentoCB(String pTipoConta, String pCodigoBarrasDigitado, String pCodigoBarrasLido, String pValorTitulo, String pNSUCartao, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoCB(pTipoConta, pCodigoBarrasDigitado,
                pCodigoBarrasLido, pValorTitulo, pNSUCartao, pNumeroControle);
    }
    public int InicializaSessaoCB(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.InicializaSessaoCB(pNumeroControle);
    }
    public int FinalizaSessaoCB(byte [] pNumeroControle){
       return TefSharedLibrary.INSTANCE.FinalizaSessaoCB(pNumeroControle);
    }
    public int TransacaoResumoRecebimentosCB(String pTipoRecebimento, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoResumoRecebimentosCB(pTipoRecebimento, pNumeroControle);
    }
    public int UltimaMensagemTEF(byte [] pMensagem){
        return TefSharedLibrary.INSTANCE.UltimaMensagemTEF(pMensagem);
    }
    public int TransacaoReimpressaoCupom(){
        return TefSharedLibrary.INSTANCE.TransacaoReimpressaoCupom();
    }
    public void ConfiguraDPOS(){ 
         TefSharedLibrary.INSTANCE.ConfiguraDPOS();
    }
    public int InicializaDPOS(){
        return TefSharedLibrary.INSTANCE.InicializaDPOS();
    }
    public int FinalizaDPOS(){ 
        return TefSharedLibrary.INSTANCE.FinalizaDPOS();
    }
    public int TransacaoFechamento(String pDataMovimento, String pQuantidadeVendas, String pValorTotalVendas, String pQuantidadeVendasCanceladas,
               String pValorTotalVendasCanceladas, String pReservado, byte [] pNumeroControle, byte [] pMensagemOperador){
        
        return TefSharedLibrary.INSTANCE.TransacaoFechamento(pDataMovimento, pQuantidadeVendas,
                pValorTotalVendas, pQuantidadeVendasCanceladas, pValorTotalVendasCanceladas,
                pReservado, pNumeroControle, pMensagemOperador);
    }
    public int TransacaoFechamentoPOS(String pTipoRelatorio, String pParametrosRelatorio, String pReservado, String pNumeroCupom, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoFechamentoPOS(pTipoRelatorio,
                pParametrosRelatorio, pReservado, pNumeroCupom, pNumeroControle);
    }
    public int TransacaoAtivacaoPOS(String pCNPJ, String pNumeroSerie, String pCodAtivacao, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoAtivacaoPOS(pCNPJ, pNumeroSerie,
                pCodAtivacao, pNumeroControle);
    }
    public int TransacaoInicializacaoAreaPOS(String pCNPJ, String pNumeroSerie, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoInicializacaoAreaPOS(pCNPJ, pNumeroSerie,
                pNumeroControle);
    }
    public int TransacaoLojaPOS(String pCNPJ, String pNumeroSerie, String pCodigoEmpresa, String pCodigoLoja, String pCodigoPDV, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoLojaPOS(pCNPJ, pNumeroSerie, pCodigoEmpresa,
                pCodigoLoja, pCodigoPDV, pNumeroControle);
    }
    public void ObtemUltimoErro(byte [] pErro){
         TefSharedLibrary.INSTANCE.ObtemUltimoErro(pErro);
    }
    public void DadosUltimaTransacaoNaoAprovada(byte [] pDadosTransacaoNaoAprovada){
        TefSharedLibrary.INSTANCE.DadosUltimaTransacaoNaoAprovada(pDadosTransacaoNaoAprovada);
    }
    public int TransacaoColeta(int nTipoCartao, String pValorTransacao, byte [] pTrilha1, byte [] pTrilha2, byte [] pTrilha3, String pParametros){
        return TefSharedLibrary.INSTANCE.TransacaoColeta(nTipoCartao, pValorTransacao,
                pTrilha1, pTrilha2, pTrilha3, pParametros);
    }
    public int TransacaoColetaCartao(int nTipoCartao, byte [] pTrilha1, byte [] pTrilha2, byte [] pTrilha3){
        return TefSharedLibrary.INSTANCE.TransacaoColetaCartao(nTipoCartao, pTrilha1,
                pTrilha2, pTrilha3);
    }
    public int TransacaoColetaSenha(String pValor, byte [] pSenha){
        return TefSharedLibrary.INSTANCE.TransacaoColetaSenha(pValor, pSenha);
    }
    public int TransacaoColetaSenhaCartao(int nTipoCartao, String pValor, String pTrilha2, String pReservado, byte [] pSenha){
        return TefSharedLibrary.INSTANCE.TransacaoColetaSenhaCartao(nTipoCartao,
                pValor, pTrilha2, pReservado, pSenha);
    }
    public int ColetaPlanoPagamento(String pDescricaoFormaPagamento, String pValorTransacao, String pNumeroCupom, String pTipoFormaPagamento, byte [] pNumeroControle,
               byte [] pNumeroParcelas, byte [] pValorAcrescimo, byte [] pValorEntrada, byte [] pValorTotal, byte [] pCodigoPlano, byte [] pPlano, byte [] pParcelas){
    
        return TefSharedLibrary.INSTANCE.ColetaPlanoPagamento(pDescricaoFormaPagamento,
                pValorTransacao, pNumeroCupom, pTipoFormaPagamento, pNumeroControle,
                pNumeroParcelas, pValorAcrescimo, pValorEntrada, pValorTotal, pCodigoPlano,
                pPlano, pParcelas);
    }
    public int TransacaoAdministrativaTEFDiscado(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoAdministrativaTEFDiscado(pNumeroControle);
    }
    public void SelecionaTEF(){
        TefSharedLibrary.INSTANCE.SelecionaTEF();
    }
    public void ExportaPlanos(){
        TefSharedLibrary.INSTANCE.ExportaPlanos();
    }
    
    //public int ColetaChequesPre(String pDescricaoPlanoPagamento, TList *oParcelas){ }
    
    public int TransacaoQuantidade(String pValorTransacao, String pValorTransacaoMaximo, String pNumeroCupom){
        return TefSharedLibrary.INSTANCE.TransacaoQuantidade(pValorTransacao, pValorTransacaoMaximo, pNumeroCupom);
    }
    public int TransacaoValor(String pValorTransacao, String pValorTransacaoMaximo, String pNumeroCupom){
        return TefSharedLibrary.INSTANCE.TransacaoValor(pValorTransacao, pValorTransacaoMaximo, pNumeroCupom);
    }
    public int TransacaoCartaoCreditoConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, String pNumeroCupom,
               byte [] pNumeroControle, String pNumeroCartao, String pDataVencimento, String pCVV2, String pTipoOperacao, String pNumeroParcelas,
               String pValorTaxaServico, byte [] pMensagemTEF, String pReservado){
        
        return TefSharedLibrary.INSTANCE.TransacaoCartaoCreditoConfirmada(pMultiLoja,
                pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle,
                pNumeroCartao, pDataVencimento, pCVV2, pTipoOperacao, pNumeroParcelas,
                pValorTaxaServico, pMensagemTEF, pReservado);
        
    }
    public int TransacaoCancelamentoConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, byte [] pNumeroControle,
               String pNumeroCartao, byte [] pMensagemTEF, byte [] pReservado){
        
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoConfirmada(pMultiLoja,
                pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroControle, pNumeroCartao,
                pMensagemTEF, pReservado);
    
    }
    public int PreAutorizacaoCreditoConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, String pNumeroCupom,
               byte [] pNumeroControle, String pNumeroCartao, String pDataVencimento, String pCVV2, String pValorTaxaServico, String pNumeroAutorizacao,
               byte [] pMensagemTEF, byte [] pReservado){
        
        return TefSharedLibrary.INSTANCE.PreAutorizacaoCreditoConfirmada(pMultiLoja,
                pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle,
                pNumeroCartao, pDataVencimento, pCVV2, pValorTaxaServico, pNumeroAutorizacao,
                pMensagemTEF, pReservado);
    
    }
    public int ConfPreAutorizacaoCreditoConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, String pNumeroCupom,
               byte [] pNumeroControle, String pDataPreAutor, String pNumeroCartao, String pDataVencimento, String pCVV2, String pTipoOperacao,
               String pNumeroParcelas, byte [] pMensagemTEF, byte [] pReservado){
        
        return TefSharedLibrary.INSTANCE.ConfPreAutorizacaoCreditoConfirmada(pMultiLoja,
                pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle,
                pDataPreAutor, pNumeroCartao, pDataVencimento, pCVV2, pTipoOperacao,
                pNumeroParcelas, pMensagemTEF, pReservado);
    
    }
    public int TransacaoManualPOS (String pValorTransacao){ 
        return TefSharedLibrary.INSTANCE.TransacaoManualPOS(pValorTransacao);
    }
    public int TransacaoManualPOSCompleta (byte [] pValorTransacao, byte [] pCodigoEstabelecimento, byte [] pData, byte [] pHora, byte [] pNumeroAutorizadora,
               byte [] pNumeroCartao, byte [] pTipoOperacao, byte [] pNumeroParcelas, byte [] pDataPreDatado, byte [] pNumeroControle){
        
        return TefSharedLibrary.INSTANCE.TransacaoManualPOSCompleta(pValorTransacao,
                pCodigoEstabelecimento, pData, pHora, pNumeroAutorizadora, pNumeroCartao,
                pTipoOperacao, pNumeroParcelas, pDataPreDatado, pNumeroControle);   
    }
    public int TransacaoCartaoFidelidade(String pValorTransacao, String pNumeroCupom, String pCompraPontos, String pQuantidadeItensTaxaVariavel,
            String pItensTaxaVariavel, byte [] pNumeroControle){
        
        return TefSharedLibrary.INSTANCE.TransacaoCartaoFidelidade(pValorTransacao,
                pNumeroCupom, pCompraPontos, pQuantidadeItensTaxaVariavel,
                pItensTaxaVariavel, pNumeroControle);
        
    }
    public int TransacaoDebitoFidelidade(String pNumeroCupom, byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoDebitoFidelidade(pNumeroCupom,
                pNumeroControle);  
    }
    public int ConfirmaCartaoFidelidade(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.ConfirmaCartaoFidelidade(pNumeroControle);
    }
    public int ExtratoCartaoAutorizadorDirecao(String pNumeroCartao, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.ExtratoCartaoAutorizadorDirecao(pNumeroCartao, pNumeroControle);
    }
    public int RecebimentoAutorizadorDirecao(String pValorTransacao, String pNumeroCartao, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.RecebimentoAutorizadorDirecao(pValorTransacao,
                pNumeroCartao, pNumeroControle);
    }
    public int EstornoRecebimentoAutorizadorDirecao(String pValorTransacao, String pNumeroCartao, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.EstornoRecebimentoAutorizadorDirecao(pValorTransacao,
                pNumeroCartao, pNumeroControle);
    }
    public int RecebimentoCarneAutorizadorDirecao(String pValorTransacao, String pNumeroCartao, String pDataVencimento, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.RecebimentoCarneAutorizadorDirecao(pValorTransacao,
                pNumeroCartao, pDataVencimento, pNumeroControle);
    }
    public int TransacaoPagamentoConvenio(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoPagamentoConvenio(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int ConfirmaConvenio(byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.ConfirmaConvenio(pNumeroControle);
    }
    public int TransacaoSaqueRedecard(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoSaqueRedecard(pValorTransacao,
                pNumeroCupomFiscal, pNumeroControle);
    }
    public int TransacaoSaque(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoSaque(pValorTransacao,
                pNumeroCupomFiscal, pNumeroControle);
    }
    public int TransacaoCDC1MIN(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoCDC1MIN(pValorTransacao,
                pNumeroCupomFiscal, pNumeroControle);
    }
    public int TransacaoSIMparcelado(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoSIMparcelado(pValorTransacao,
                pNumeroCupomFiscal, pNumeroControle);
    }
    public int TransacaoCartaoCreditoIATA(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoCartaoCreditoIATA(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int TransacaoCartaoCreditoIATAConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTransacao, String pNumeroCupom,
            byte [] pNumeroControle, String pNumeroCartao, String pDataVencimento, String pCVV2, String pTipoOperacao, String pNumeroParcelas,
            String pValorTaxaServico,String pValorEntrada, byte [] pMensagemTEF, byte [] pReservado){ 
        
        return TefSharedLibrary.INSTANCE.TransacaoCartaoCreditoIATAConfirmada(pMultiLoja,
                pNumeroLoja, pNumeroPDV, pValorTransacao, pNumeroCupom, pNumeroControle,
                pNumeroCartao, pDataVencimento, pCVV2, pTipoOperacao, pNumeroParcelas, 
                pValorTaxaServico, pValorEntrada, pMensagemTEF, pReservado);
    }
    public int TransacaoCartaoPrivateLabel(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){ 
        return TefSharedLibrary.INSTANCE.TransacaoCartaoPrivateLabel(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public void BeepErro(){    
    }
    public int TransacaoConsultaSaldo(String pNumeroCupom, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoConsultaSaldo(pNumeroCupom,
                pNumeroControle);
    }
    public int TransacaoConsultaSaldoCelular(String pNumeroCupom, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoConsultaSaldoCelular(pNumeroCupom,
                pNumeroControle);
    }
    public int TransacaoConsultaSaldoCompleta(String pNumeroCupom, byte [] pNumeroControle, String pTipoCartao, String pPermiteAlteracao, String pReservado){    
        return TefSharedLibrary.INSTANCE.TransacaoConsultaSaldoCompleta(pNumeroCupom,
                pNumeroControle, pTipoCartao, pPermiteAlteracao, pReservado);
    }
    public int ColetaCartaoDebito(String pValorTransacao, String pNumeroCupom, byte [] pParametrosTEF, byte [] pMensagemOperador){
            return TefSharedLibrary.INSTANCE.ColetaCartaoDebito(pValorTransacao,
                    pNumeroCupom, pParametrosTEF, pMensagemOperador);
    }
    public int ConsisteDadosCartaoDebito(String pUltimosDigitos, String pCodigoSeguranca, byte [] pMensagemOperador){
        return TefSharedLibrary.INSTANCE.ConsisteDadosCartaoDebito(pUltimosDigitos,
                pCodigoSeguranca, pMensagemOperador);
    }
    public int ColetaSenhaCartaoDebito(byte [] pNumeroControle, byte [] pMensagemOperador){ 
        return TefSharedLibrary.INSTANCE.ColetaSenhaCartaoDebito(pNumeroControle,
                pMensagemOperador);
    }
    public int ConsultaParametrosPBM(String pNumeroCupom, String pQuantidadeRedes, String pDadosRedes, String pMensagemOperador){     
        return TefSharedLibrary.INSTANCE.ConsultaParametrosPBM(pNumeroCupom, 
                pQuantidadeRedes, pDadosRedes, pMensagemOperador);
    }
    public int ConsultaProdutosPBM(String pNumeroCupom, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, String pAutorizacao, byte [] pDadosCRM,
               byte [] pTipoVenda, byte [] pValorTotalMedicamentos, byte [] pValorVista, byte [] pValorCartao, byte [] pCodigoCredenciado, byte [] pQuantidadeMedicamentos,
               byte [] pMedicamentos, byte [] pReservado, byte [] pNumeroControle, byte [] pMensagemOperador){    
        
        return TefSharedLibrary.INSTANCE.ConsultaProdutosPBM(pNumeroCupom, pRedePBM,
                pTrilha1, pTrilha2, pDigitado, pAutorizacao, pDadosCRM, pTipoVenda,
                pValorTotalMedicamentos, pValorVista, pValorCartao, pCodigoCredenciado,
                pQuantidadeMedicamentos, pMedicamentos, pReservado, pNumeroControle,
                pMensagemOperador);        
    }
    public int TransacaoVendaPBM(byte [] pValorTotalMedicamentos, String pNumeroCupom, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, String pAutorizacao,
            String pNSUConsulta, String pDadosCRM, String pTipoVenda, String pValorVista, String pValorCartao, String pCodigoCredenciado, String pRegraNegocio,
            byte [] pQuantidadeMedicamentos, byte [] pMedicamentos, byte [] pReservado, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pMensagemOperador){    
        
        return TefSharedLibrary.INSTANCE.TransacaoVendaPBM(pValorTotalMedicamentos,
                pNumeroCupom, pRedePBM, pTrilha1, pTrilha2, pDigitado, pAutorizacao,
                pNSUConsulta, pDadosCRM, pTipoVenda, pValorVista, pValorCartao,
                pCodigoCredenciado, pRegraNegocio, pQuantidadeMedicamentos,
                pMedicamentos, pReservado, pNumeroControle, pNumeroControleRede,
                pMensagemOperador);
        
    }
    
    public int ConfirmaVendaPBM(byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.ConfirmaVendaPBM(pNumeroControle);
    }
    public int TransacaoReimpressaoVendaPBM(){    
        return TefSharedLibrary.INSTANCE.TransacaoReimpressaoVendaPBM();
    }
    public int TransacaoCancelamentoVendaPBM(byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoVendaPBM(pNumeroControle);
    }
    public int TransacaoCancelamentoPreAutorizacaoPBM(byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoPreAutorizacaoPBM(pNumeroControle);
    }
    public int TransacaoElegibilidadePBM(String pNumeroCupom, String pRedePBM, String pMatricula, String pDadosElegibilidade, byte [] pNumeroControle,
               byte [] pNumeroControleRede, byte [] pNomeCliente, byte [] pNomeMedico, byte [] pInformaDependente, byte [] pListaDependentes, byte [] pReservado,
               byte [] pMensagemOperador){     
        
        return TefSharedLibrary.INSTANCE.TransacaoElegibilidadePBM(pNumeroCupom,
                pRedePBM, pMatricula, pDadosElegibilidade, pNumeroControle,
                pNumeroControleRede, pNomeCliente, pNomeMedico, pInformaDependente,
                pListaDependentes, pReservado, pMensagemOperador);
    }
    public int TransacaoPreAutorizacaoPBM(String pNumeroCupom, String pRedePBM, String pAutorizacaoElegibilidade, String pDadosFarmaceutico, byte [] pQuantidadeMedicamentos,
               byte [] pMedicamentos, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pReservado, byte [] pMensagemOperador){    
        
        return TefSharedLibrary.INSTANCE.TransacaoPreAutorizacaoPBM(pNumeroCupom,
                pRedePBM, pAutorizacaoElegibilidade, pDadosFarmaceutico,
                pQuantidadeMedicamentos, pMedicamentos, pNumeroControle,
                pNumeroControleRede, pReservado, pMensagemOperador);
    }
    public int TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pMatricula,
               String pReservado, byte [] pNumeroControle, byte [] pMensagemOperador){    
        
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoPreAutorizacaoPBM_TeleMarketing(pNumeroEmpresa,
                pMultiLoja, pNumeroLoja, pNumeroPDV, pMatricula, pReservado,
                pNumeroControle, pMensagemOperador);
    }
    
    public int TransacaoElegibilidadePBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom,
            String pRedePBM, String pMatricula, String pDadosElegibilidade, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pNomeCliente,
            byte [] pNomeMedico, byte [] pInformaDependente, byte [] pListaDependentes, byte [] pReservado, byte [] pMensagemOperador){    
      
        return TefSharedLibrary.INSTANCE.TransacaoElegibilidadePBM_TeleMarketing(pNumeroEmpresa,
                pMultiLoja, pNumeroLoja, pNumeroPDV, pNumeroCupom, pRedePBM,
                pMatricula, pDadosElegibilidade, pNumeroControle, pNumeroControleRede,
                pNomeCliente, pNomeMedico, pInformaDependente, pListaDependentes,
                pReservado, pMensagemOperador);
        
    }
    public int TransacaoPreAutorizacaoPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom,
            String pRedePBM, String pAutorizacaoElegibilidade, String pDadosFarmaceutico, byte [] pQuantidadeMedicamentos, byte [] pMedicamentos,
            byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pReservado, byte [] pMensagemOperador){     
        
        return TefSharedLibrary.INSTANCE.TransacaoPreAutorizacaoPBM_TeleMarketing(
                pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pNumeroCupom,
                pRedePBM, pAutorizacaoElegibilidade, pDadosFarmaceutico,
                pQuantidadeMedicamentos, pMedicamentos, pNumeroControle,
                pNumeroControleRede, pReservado, pMensagemOperador);
        
    }
    public int ConsultaParametrosPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom,
            byte [] pQuantidadeRedes, byte [] pDadosRedes, byte [] pMensagemOperador){    
        
        return TefSharedLibrary.INSTANCE.ConsultaParametrosPBM_TeleMarketing(
                pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV,
                pNumeroCupom, pQuantidadeRedes, pDadosRedes, pMensagemOperador);
    }
    public int ConsultaProdutosPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom, String pRedePBM,
            String pTrilha1, String pTrilha2, String pDigitado, String pAutorizacao, String pDadosCRM, byte [] pTipoVenda, byte [] pValorTotalMedicamentos,
            byte [] pValorVista, byte [] pValorCartao, byte [] pCodigoCredenciado, byte [] pQuantidadeMedicamentos, byte [] pMedicamentos, byte [] pReservado, 
            byte [] pNumeroControle, byte [] pMensagemOperador){     
       
        return TefSharedLibrary.INSTANCE.ConsultaProdutosPBM_TeleMarketing(
                pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pNumeroCupom,
                pRedePBM, pTrilha1, pTrilha2, pDigitado, pAutorizacao, pDadosCRM,
                pTipoVenda, pValorTotalMedicamentos, pValorVista, pValorCartao,
                pCodigoCredenciado, pQuantidadeMedicamentos, pMedicamentos,
                pReservado, pNumeroControle, pMensagemOperador);
    }
    public int TransacaoVendaPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pValorTotalMedicamentos,
            String pNumeroCupom, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, String pAutorizacao, String pNSUConsulta, String pDadosCRM,
            String pTipoVenda, String pValorVista, String pValorCartao, String pCodigoCredenciado, String pRegraNegocio, byte [] pQuantidadeMedicamentos,
            byte [] pMedicamentos, byte [] pReservado, byte [] pNumeroControle, byte [] pNumeroControleRede, byte [] pMensagemOperador){    
        
        return TefSharedLibrary.INSTANCE.TransacaoVendaPBM_TeleMarketing(pNumeroEmpresa,
                pMultiLoja, pNumeroLoja, pNumeroPDV, pValorTotalMedicamentos,
                pNumeroCupom, pRedePBM, pTrilha1, pTrilha2, pDigitado, pAutorizacao,
                pNSUConsulta, pDadosCRM, pTipoVenda, pValorVista, pValorCartao,
                pCodigoCredenciado, pRegraNegocio, pQuantidadeMedicamentos,
                pMedicamentos, pReservado, pNumeroControle, pNumeroControleRede,
                pMensagemOperador);
        
    }
    public int TransacaoCancelamentoVendaPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pTrilha1,
            String pTrilha2, String pDigitado, byte [] pReservado, byte [] pNumeroControle, byte [] pMensagemOperador){    
        
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoVendaPBM_TeleMarketing(
                pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pTrilha1,
                pTrilha2, pDigitado, pReservado, pNumeroControle, pMensagemOperador);
        
    }
    public int TransacaoAberturaVendaPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pRedePBM, String pTrilha1,
            String pTrilha2, String pDigitado, byte [] pReservado, byte [] pPedirDadosComplementares, byte [] pDadosComplementares, byte [] pInfoDadosComplementares,
            byte [] pMensagemOperador){    
       
        return TefSharedLibrary.INSTANCE.TransacaoAberturaVendaPBM_TeleMarketing(
                pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pRedePBM,
                pTrilha1, pTrilha2, pDigitado, pReservado, pPedirDadosComplementares,
                pDadosComplementares, pInfoDadosComplementares, pMensagemOperador);
    }
    public int TransacaoVendaProdutoPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pRedePBM, String pTrilha1, String pTrilha2, String pDigitado, byte [] pMedicamento, byte [] pReservado, byte [] pPedirDadosComplementares, byte [] pDadosComplementares,  byte [] pInfoDadosComplementares, byte [] pMensagemOperador){    
        return TefSharedLibrary.INSTANCE.TransacaoVendaProdutoPBM_TeleMarketing(
                pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pRedePBM,
                pTrilha1, pTrilha2, pDigitado, pMedicamento, pReservado,
                pPedirDadosComplementares, pDadosComplementares,
                pInfoDadosComplementares, pMensagemOperador);
    }
    public int TransacaoFechamentoVendaPBM_TeleMarketing(String pNumeroEmpresa, String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pRedePBM, String pTrilha1, String pTrilha2,
               String pDigitado, String pConfirmacao, byte [] pReservado, byte [] pAutorizacao, byte [] pNumeroControle, byte [] pMensagemOperador){    
       
        return TefSharedLibrary.INSTANCE.TransacaoFechamentoVendaPBM_TeleMarketing(
                pNumeroEmpresa, pMultiLoja, pNumeroLoja, pNumeroPDV, pRedePBM, 
                pTrilha1, pTrilha2, pDigitado, pConfirmacao, pReservado,
                pAutorizacao, pNumeroControle, pMensagemOperador);
    }
    public void InformaDadosMedicamentos(byte [] pIndicativoReceita, byte [] pRegistroProfissional, byte [] pListaMedicamentos){     
         TefSharedLibrary.INSTANCE.InformaDadosMedicamentos(pIndicativoReceita, pRegistroProfissional, pListaMedicamentos);
    }
    public int TransacaoSaqueSaldo(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoSaqueSaldo(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int TransacaoSaqueExtrato(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoSaqueExtrato(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int TransacaoConsultaAVS(byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoConsultaAVS(pNumeroControle);
    }
    public int TransacaoConsultaAVSConfirmada(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, String pNumeroCupom, byte [] pNumeroControle,
            String pNumeroCartao, String pDataVencimento, String pCVV2, String pEndereco, String pNumero, String pApto, String pBloco, String pCEP,
            String pBairro, String pCPF, byte [] pMensagemTEF, byte [] pReservado){    
        
        return TefSharedLibrary.INSTANCE.TransacaoConsultaAVSConfirmada(pMultiLoja,
                pNumeroLoja, pNumeroPDV, pNumeroCupom, pNumeroControle, pNumeroCartao,
                pDataVencimento, pCVV2, pEndereco, pNumero, pApto, pBloco, pCEP,
                pBairro, pCPF, pMensagemTEF, pReservado);
        
    }
    public int TransacaoPagamentoContasVisanet(byte [] pTipoConta, byte [] pCodigoBarras, byte [] pFormaPagamento, byte [] pTrilhaCartao, byte [] pValorTransacao,
            byte [] pNumeroCupom, byte [] pNumeroControle){    
        
        return TefSharedLibrary.INSTANCE.TransacaoPagamentoContasVisanet(pTipoConta,
                pCodigoBarras, pFormaPagamento, pTrilhaCartao, pValorTransacao,
                pNumeroCupom, pNumeroControle);
        
    }
    public int TransacaoEspecial(int iCodigoTransacao, String pDados){     
        return TefSharedLibrary.INSTANCE.TransacaoEspecial(iCodigoTransacao, pDados);
    }
    public int ConsultaValoresPrePago(byte [] pNumeroControle, byte [] pMensagemOperador){    
        return TefSharedLibrary.INSTANCE.ConsultaValoresPrePago(pNumeroControle,
                pMensagemOperador);
    }
    public int TransacaoRecargaCelular(byte [] pCodigoArea, byte [] pNumeroTelefone, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoRecargaCelular(pCodigoArea,
                pNumeroTelefone, pNumeroControle);
    }
    public int ConsultaParametrosTeledata(byte [] pDadosTeledata, byte [] pMensagemOperador){    
        return TefSharedLibrary.INSTANCE.ConsultaParametrosTeledata(pDadosTeledata,
                pMensagemOperador);
    }
    public int ConsultaChequesGarantidos(String pTipoDocumento, String pNumeroDocumento, String pDataInicialConsulta, String pDataFinalConsulta, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.ConsultaChequesGarantidos(pTipoDocumento,
                pNumeroDocumento, pDataInicialConsulta, pDataFinalConsulta,
                pNumeroControle);
    }
    public int TransacaoSaqueCompleta(String pValorTransacao, String pNumeroCupomFiscal, byte [] pNumeroControle, String pTipoTransacao, String pPlanoPagamento,
            String pNumeroParcelas, String pPermiteAlteracao, String pReservado){    
        
        return TefSharedLibrary.INSTANCE.TransacaoSaqueCompleta(pValorTransacao,
                pNumeroCupomFiscal, pNumeroControle, pTipoTransacao, pPlanoPagamento,
                pNumeroParcelas, pPermiteAlteracao, pReservado);      
    }
    public int TransacaoCartaoCompraSaque(String pValorCompra,String pValorSaque, String pNumeroCupom, byte [] pNumeroControle){    
        
        return TefSharedLibrary.INSTANCE.TransacaoCartaoCompraSaque(pValorCompra,
                pValorSaque, pNumeroCupom, pNumeroControle);      
    }
    public int TransacaoCartaoCompraSaqueCompleta(String pValorCompra,String pValorSaque, String pNumeroCupom,byte [] pNumeroControle,String pPermiteAlteracao){    
        return TefSharedLibrary.INSTANCE.TransacaoCartaoCompraSaqueCompleta(pValorCompra,
                pValorSaque, pNumeroCupom, pNumeroControle, pPermiteAlteracao);
    }
    public int TesteRedeAtiva(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV, String pCodigoRede, byte [] pStatusRede, byte [] pMensagemOperador){    
        return TefSharedLibrary.INSTANCE.TesteRedeAtiva(pNumeroEmpresa, pNumeroLoja,
                pNumeroPDV, pCodigoRede, pStatusRede, pMensagemOperador);
    }
    public int TransacaoCadastraSenha(byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoCadastraSenha(pNumeroControle);
    }
    public void ConfiguraFluxoExternoDTEF5(){    
         TefSharedLibrary.INSTANCE.ConfiguraFluxoExternoDTEF5();
    }
    public int TrataDesfazimento(int iTratar){     
        return TefSharedLibrary.INSTANCE.TrataDesfazimento(iTratar);
    }
    public int ConsultaTransacao(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV, String pSolicitacao, byte [] pResposta, byte [] pMensagemErro){     
        return TefSharedLibrary.INSTANCE.ConsultaTransacao(pNumeroEmpresa,
                pNumeroLoja, pNumeroPDV, pSolicitacao, pResposta, pMensagemErro);
    }
    public int TransacaoeValeGas(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pNumeroValeGas){     
        return TefSharedLibrary.INSTANCE.TransacaoeValeGas(pValorTransacao, 
                pNumeroCupom, pNumeroControle, pNumeroValeGas);
    }
    public int TransacaoConsultaeValeGas(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pNumeroValeGas, byte [] pDadosRetorno){     
        return TefSharedLibrary.INSTANCE.TransacaoConsultaeValeGas(pValorTransacao,
                pNumeroCupom, pNumeroControle, pNumeroValeGas, pDadosRetorno);
    }
    public int TransacaoCancelamentoPadrao(byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoCancelamentoPadrao(pNumeroControle);
    }
    public int ConfiguraModoTeleMarketing(int iModo){    
        return TefSharedLibrary.INSTANCE.ConfiguraModoTeleMarketing(iModo);
    }
    public int ConfirmaCartaoTeleMarketing(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, byte [] pNumeroControle, byte [] pMensagemTEF, String pReservado){    
        return TefSharedLibrary.INSTANCE.ConfirmaCartaoTeleMarketing(pMultiLoja,
                pNumeroLoja, pNumeroPDV, pNumeroControle, pMensagemTEF, pReservado);
    }
    public int DesfazCartaoTeleMarketing(String pMultiLoja, String pNumeroLoja, String pNumeroPDV, byte [] pNumeroControle, byte [] pMensagemTEF, String pReservado){     
        return TefSharedLibrary.INSTANCE.DesfazCartaoTeleMarketing(pMultiLoja, 
                pNumeroLoja, pNumeroPDV, pNumeroControle, pMensagemTEF, pReservado);
    }
    public int TransacaoEstatistica(byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoEstatistica(pNumeroControle);
    }
    public int TransacaoInjecaoChaves(byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoInjecaoChaves(pNumeroControle);
    }
    public int TransacaoTrocoSurpresa(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, byte [] pMensagemTEF, String pReservado){    
        return TefSharedLibrary.INSTANCE.TransacaoTrocoSurpresa(pValorTransacao,
                pNumeroCupom, pNumeroControle, pMensagemTEF, pReservado);
    }
    public int IdentificacaoAutomacaoComercial(String pNomeAutomacao, String pVersaoAutomacao, String pReservado){    
        return TefSharedLibrary.INSTANCE.IdentificacaoAutomacaoComercial(pNomeAutomacao,
                pVersaoAutomacao, pReservado);
    }
    public int ConsultaTabelasValeGas(byte [] pNumeroControle, byte [] pMensagemOperador){    
        return TefSharedLibrary.INSTANCE.ConsultaTabelasValeGas(pNumeroControle,
                pMensagemOperador);
    }
    public int DefineBandeiraTransacao(String pCodigoBandeira){    
        return TefSharedLibrary.INSTANCE.DefineBandeiraTransacao(pCodigoBandeira);
    }
    public int DefineRedeTransacao(String pCodigoRede){    
        return TefSharedLibrary.INSTANCE.DefineRedeTransacao(pCodigoRede);
    }
    public int ConverteCodigoRede(String pCodigoRede, byte [] pCodigoRedeDTEF5, byte [] pCodigoRedeDTEF8){     
        return TefSharedLibrary.INSTANCE.ConverteCodigoRede(pCodigoRede,
                pCodigoRedeDTEF5, pCodigoRedeDTEF8);
    }
    public int TransacaoAbreLote(String pNumeroCupom, byte [] pNumeroControle, byte [] pMensagemTEF, String pReservado){     
        return TefSharedLibrary.INSTANCE.TransacaoAbreLote(pNumeroCupom, 
                pNumeroControle, pMensagemTEF, pReservado);
    }
    public int TransacaoFechaLote(String pNumeroCupom, byte [] pNumeroControle, String pMensagemTEF, String pReservado){     
        return TefSharedLibrary.INSTANCE.TransacaoFechaLote(pNumeroCupom,
                pNumeroControle, pMensagemTEF, pReservado);
    }
    public void ConfiguraEmpresaLojaPDV(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV){    
         TefSharedLibrary.INSTANCE.ConfiguraEmpresaLojaPDV(pNumeroEmpresa, 
                 pNumeroLoja, pNumeroPDV);
    }
    public int TransacaoResgatePremio(String pNumeroCupom, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoResgatePremio(pNumeroCupom,
                pNumeroControle);
    }
    public int TransacaoVendaPOS(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, String pPagamentoTEF, String pCartaoProprio, String pValor,
            String pTelefoneCliente, String pCodigoOrigem, byte [] pSaldoPontos, byte [] pCodigoPesquisa, byte [] pReservado, byte [] pNumeroControle){    
        
        return TefSharedLibrary.INSTANCE.TransacaoVendaPOS(pCNPJ, pNumeroSerie,
                pCodigoFrentista, pCPFCNPJ, pPagamentoTEF, pCartaoProprio, pValor,
                pTelefoneCliente, pCodigoOrigem, pSaldoPontos, pCodigoPesquisa,
                pReservado, pNumeroControle);
                       
    }
    public int TransacaoEstornoVendaPOS(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, String pDataEstorno, String pNSUEstorno,
            String pAutorizacaoEstorno, byte [] pSaldoPontos, byte [] pNumeroControle){    
        
        return TefSharedLibrary.INSTANCE.TransacaoEstornoVendaPOS(pCNPJ, pNumeroSerie,
                pCodigoFrentista, pCPFCNPJ, pDataEstorno, pNSUEstorno, pAutorizacaoEstorno,
                pSaldoPontos, pNumeroControle);
        
    }
    public int TransacaoResgatePontosPOS(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, String pQuantidadeProdutos, String pListaProdutos,
            byte [] pSaldoPontos, String pReservado, byte [] pNumeroControle){    
        
        return TefSharedLibrary.INSTANCE.TransacaoResgatePontosPOS(pCNPJ, pNumeroSerie,
                pCodigoFrentista, pCPFCNPJ, pQuantidadeProdutos, pListaProdutos,
                pSaldoPontos, pReservado, pNumeroControle);  
    }
    public int TransacaoConsultaPontosPOS(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, byte [] pSaldoPontos, String pReservado, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoConsultaPontosPOS(pCNPJ, pNumeroSerie,
                pCodigoFrentista, pCPFCNPJ, pSaldoPontos, pReservado, pNumeroControle);
    }
    public int AtualizacaoFrentistasPOS(String pCNPJ, String pNumeroSerie, byte [] pNumeroFrentistas, byte [] pListaFrentistas, String pReservado, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.AtualizacaoFrentistasPOS(pCNPJ, pNumeroSerie,
                pNumeroFrentistas, pListaFrentistas, pReservado, pNumeroControle);
    }
    public int BuscaTabelaDTEF(int iTipoTabela, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.BuscaTabelaDTEF(iTipoTabela, pNumeroControle);
    }
    public int TransacaoContratacao(String pNumeroCupom, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoContratacao(pNumeroCupom, pNumeroControle);
    }
    public int TransacaoPrimeiraCompra(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoPrimeiraCompra(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int TransacaoCadastro(String pCNPJ, String pNumeroSerie, String pCodigoFrentista, String pCPFCNPJ, String pTelefoneCliente, String pReservado, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoCadastro(pCNPJ, pNumeroSerie,
                pCodigoFrentista, pCPFCNPJ, pTelefoneCliente, pReservado,
                pNumeroControle);
    }
    public int TransacaoDesativacaoPOS(String pCNPJ, String pNumeroSerie, String pNumeroSerieDesativacao, String pFrentista, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoDesativacaoPOS(pCNPJ, pNumeroSerie,
                pNumeroSerieDesativacao, pFrentista, pNumeroControle);
    }
    public int TransacaoConsultaPOSAtivos(String pCNPJ, String pNumeroSerie, String pNumeroPOSAtivos, String pListaPOSAtivos, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoConsultaPOSAtivos(pCNPJ, pNumeroSerie,
                pNumeroPOSAtivos, pListaPOSAtivos, pNumeroControle);
    }
    public int ProcuraPinPad(byte [] pDados){     
        return TefSharedLibrary.INSTANCE.ProcuraPinPad(pDados);
    }
    public int ApagaTabelasPinPad(String pDados){     
        return TefSharedLibrary.INSTANCE.ApagaTabelasPinPad(pDados);
    }
    public int TransacaoFuncoesAdministrativas(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pReservado){    
        return TefSharedLibrary.INSTANCE.TransacaoFuncoesAdministrativas(
                pValorTransacao, pNumeroCupom, pNumeroControle, pReservado);
    }
    public int TransacaoQuitacaoCartaFrete(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoQuitacaoCartaFrete(pValorTransacao, pNumeroCupom, pNumeroControle);     
    }
    public int TransacaoQuitacaoCartaFreteCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle,String pNumeroCartaFrete,String pQuantidadeChegada,
            String pPermiteAlteracao, String pReservado){    
        
        return TefSharedLibrary.INSTANCE.TransacaoQuitacaoCartaFreteCompleta(
                pValorTransacao, pNumeroCupom, pNumeroControle, pNumeroCartaFrete,
                pQuantidadeChegada, pPermiteAlteracao, pReservado);
        
    }
    public int TransacaoCartaoCrediario(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoCartaoCrediario(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int TransacaoSimulacaoCrediario(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoSimulacaoCrediario(
                pValorTransacao, pNumeroCupom, pNumeroControle);
    }
    public int TransacaoPagamentoPrivateLabelCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, String pIndicadorDigitacao, String pCodigoBarras,
            String pNumeroCartao, String pCodigoRede, String pPermiteAlteracao, String pReservado){     
        
        return TefSharedLibrary.INSTANCE.TransacaoPagamentoPrivateLabelCompleta(
                pValorTransacao, pNumeroCupom, pNumeroControle, pIndicadorDigitacao,
                pCodigoBarras, pNumeroCartao, pCodigoRede, pPermiteAlteracao, pReservado);
        
    }
    public int TransacaoCargaCartao(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoCargaCartao(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int TransacaoRecargaCartao(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoRecargaCartao(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int CadastraPDV(){     
        return TefSharedLibrary.INSTANCE.CadastraPDV();
    }
    public int CadastraPDVTelemarketing(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV, byte [] pMensagemTEF){     
        return TefSharedLibrary.INSTANCE.CadastraPDVTelemarketing(pNumeroEmpresa,
                pNumeroLoja, pNumeroPDV, pMensagemTEF);
    }
    public int TransacaoCartaoCrediarioCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle, byte [] pNumeroParcelas, byte [] pDataParcela1, byte [] pValorParcela1, byte [] pValorEntrada, String pPermiteAlteracao, byte [] pReservado){     
        return TefSharedLibrary.INSTANCE.TransacaoCartaoCrediarioCompleta(pValorTransacao,
                pNumeroCupom, pNumeroControle, pNumeroParcelas, pDataParcela1, 
                pValorParcela1, pValorEntrada, pPermiteAlteracao, pReservado);
    }
    public int TransacaoConsultaPlanos(String pValorTransacao, byte [] pNumeroControle, byte [] pReservado, byte [] pPlanos){    
        return TefSharedLibrary.INSTANCE.TransacaoConsultaPlanos(pValorTransacao,
                pNumeroControle, pReservado, pPlanos);
    }
    public int ConsultaCadastroPDV(byte [] pMensagem){    
        return TefSharedLibrary.INSTANCE.ConsultaCadastroPDV(pMensagem);
    }
    public int ConsultaCadastroPDVTelemarketing(String pNumeroEmpresa, String pNumeroLoja, String pNumeroPDV, byte [] pMensagemTEF){    
        return TefSharedLibrary.INSTANCE.ConsultaCadastroPDVTelemarketing(
                pNumeroEmpresa, pNumeroLoja, pNumeroPDV, pMensagemTEF);
    }
    public int TransacaoSimulacaoSaque(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle){    
        return TefSharedLibrary.INSTANCE.TransacaoSimulacaoSaque(pValorTransacao,
                pNumeroCupom, pNumeroControle);
    }
    public int TransacaoBloqueioCartao(String pNumeroCupom, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoBloqueioCartao(pNumeroCupom,
                pNumeroControle);
    }
    public int TransacaoDesbloqueioCartao(String pNumeroCupom, byte [] pNumeroControle){     
        return TefSharedLibrary.INSTANCE.TransacaoDesbloqueioCartao(pNumeroCupom,
                pNumeroControle);
    }
    public int TransacaoConsultaCadastroCPFCompleta(String pValorTransacao,String pNumeroCupom, byte [] pNumeroControle,byte [] pTipoOperacao,byte [] pDocEmissor,byte [] pPermiteAlteracao,byte [] pReservado){    
        return TefSharedLibrary.INSTANCE.TransacaoConsultaCadastroCPFCompleta(
                pValorTransacao, pNumeroCupom, pNumeroControle, pTipoOperacao,
                pDocEmissor, pPermiteAlteracao, pReservado);
    }
    public int TransacaoDepositoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle,byte [] pTipoOperacao,byte [] pDocEmissor,byte [] pDocDestinatario,byte [] pPermiteAlteracao,byte [] pReservado){    
        return TefSharedLibrary.INSTANCE.TransacaoDepositoCompleta(pValorTransacao,
                pNumeroCupom, pNumeroControle, pTipoOperacao, pDocEmissor,
                pDocDestinatario, pPermiteAlteracao, pReservado);
    }
    public int TransacaoSaqueDomesticoCompleta(String pValorTransacao, String pNumeroCupom, byte [] pNumeroControle,byte [] pTipoOperacao,byte [] pCodigoPIN,byte [] pDocDestinatario,byte [] pPermiteAlteracao, byte [] pReservado){
        return TefSharedLibrary.INSTANCE.TransacaoSaqueDomesticoCompleta(
                pValorTransacao, pNumeroCupom, pNumeroControle, pTipoOperacao,
                pCodigoPIN, pDocDestinatario, pPermiteAlteracao, pReservado);
    }
    public int TransacaoAlteraSenhaUsuarioDTEF(String pNumeroCupom, byte [] pNumeroControle){
        return TefSharedLibrary.INSTANCE.TransacaoAlteraSenhaUsuarioDTEF(
                pNumeroCupom, pNumeroControle);
    }
    public int DefineParametroTransacao(int iCodigoParametro, String pValorParametro, int iTamanhoParametro){ 
        return TefSharedLibrary.INSTANCE.DefineParametroTransacao(iCodigoParametro,
                pValorParametro, iTamanhoParametro);
    }   
    
    
    
//======================================================================================================================================
    public interface iSemTelas{
        
        public void pCallBackDisplayTerminal(String pMensagem);
        public void pCallBackDisplayErro(String pMensagem);
        public void pCallBackMensagem(String pMensagem);
        public void pCallBackBeep();
        public int pCallBackSolicitaConfirmacao(String pMensagem);
        public int pCallBackEntraCartao(String pLabel, String pCartao);
        public int pCallBackEntraDataValidade(String pLabel, String pDataValidade);
        public int pCallBackEntraData(String pLabel, String pDataValidade);
        public int pCallBackEntraCodigoSeguranca(String pLabel, String pEntraCodigoSeguranca,int iTamanhoMax);
        public int pCallBackSelecionaOpcao(String pLabel, String pOpcoes, int iOpcaoSelecionada);
        public int pCallBackEntraValor(String pLabel, String pValor, String pValorMinimo, String pValorMaximo);
        public int pCallBackEntraNumero(String pLabel, String pNumero, String pNumeroMinimo, String pNumeroMaximo,int iMinimoDigitos,int iMaximoDigitos,int iDigitosExatos);
        public int pCallBackOperacaoCancelada ();
        public int pCallBackSetaOperacaoCancelada(boolean bCancelada);
        public void pCallBackProcessaMensagens();
        public int pCallBackEntraString(String pLabel, String pString, String pTamanhoMaximo);
        public int pCallBackConsultaAVS(String cEndereco,String cNumero,String cApto,String cBloco,String cCEP,String cBairro,String cCPF);
        public int pCallBackMensagemAdicional(String pMensagemAdicional);
        public int pCallBackImagemAdicional(int iIndiceImagem); 
        public int pCallBackEntraCodigoBarras(String Label,String Campo);
        public int pCallBackEntraCodigoBarrasLido(String Label,String Campo);
        public void pCallBackMensagemAlerta(String pMensagemAlerta);
        public void pCallBackPreviewComprovante(String cComprovante);
        public int pCallBackSelecionaPlanos(int iCodigoRede, int iCodigoTransacao, int iTipoFinanciamento, int iMaximoParcelas, String pValorMinimoParcela,
                   int iMaxDiasPreDatado, String pNumeroParcelas, String pValorTransacao, String pValorParcela, String pValorEntrada, String pData);
        public int pCallBackSelecionaPlanosEx(String pSolicitacao, String pRetorno);
        public int pCallBackDadosHistorico(String parte1, int tamParte1, String parte2, int tamParte2);      
    }

    final Charset characterSet = Charset.forName("US-ASCII");
    CBImplementacao cbImp = new CBImplementacao();  
//====================================================================================================================================================   
      
    
    public void SetSemtelas(){
               
        TefSharedLibrary.iDisplayTerminal displayTerminal;
        displayTerminal = (new TefSharedLibrary.iDisplayTerminal() {
            public void pCallBackDisplayTerminal(String pMensagem) {
                cbImp.refCallBackDisplayTerminal(pMensagem);
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVDisplayTerminal(displayTerminal);
        
        //-------------------------------------------------------------------
                                        
        TefSharedLibrary.iDisplayErro displayErro = (new TefSharedLibrary.iDisplayErro() {

            public void pCallBackDisplayErro(String pMensagem) {
               cbImp.refCallBackDisplayErro(pMensagem);
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVDisplayErro(displayErro);
        
        //-------------------------------------------------------------------
        
         TefSharedLibrary.iMensagem oMensagem = (new TefSharedLibrary.iMensagem(){
            public void pCallBackMensagem(String pMensagem){
                cbImp.refCallBackMensagem(pMensagem);
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVMensagem(oMensagem);
        //-------------------------------------------------------------------
        TefSharedLibrary.iBeep beep = (new TefSharedLibrary.iBeep() {

            public void pCallBackBeep() {
                cbImp.refCallBackBeep();
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVBeep(beep);     
         
        //-------------------------------------------------------------------
        TefSharedLibrary.iSolicitaConfirmacao solicitaConfirmacao = (new TefSharedLibrary.iSolicitaConfirmacao() {

            public int pCallBackSolicitaConfirmacao(String pMensagem) {
                cbImp.refCallBackSolicitaConfirmacao(pMensagem);
                return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVSolicitaConfirmacao(solicitaConfirmacao);
        
        //-------------------------------------------------------------------
        TefSharedLibrary.iEntraCartao entraCartao = (new TefSharedLibrary.iEntraCartao() {
    
            public int pCallBackEntraCartao(String pLabel, Pointer pCartao) {
                
                String[] pegaResposta = cbImp.refCallBackEntraCartao(pLabel);
                
                pLabel = pegaResposta[0];
                String cartao = pegaResposta[1];
                cartao+="/0";
                byte[] bytes = cartao.getBytes(characterSet);
                pCartao.write(0, bytes, 0, bytes.length);
                return 0;
                
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVEntraCartao(entraCartao);

        //-------------------------------------------------------------------
        TefSharedLibrary.iEntraDataValidade entraDataValidade = (new TefSharedLibrary.iEntraDataValidade() {
            
            public int pCallBackEntraDataValidade(String pLabel, Pointer pDataValidade) {
                String[] dados = cbImp.refCallBackEntraDataValidade(pLabel);                
                String dataValidade = dados[1];
                byte[] bytes = dataValidade.getBytes(characterSet);
                pDataValidade.write(0, bytes, 0, bytes.length);
                
                return 0;
            }
        } );
       
       TefSharedLibrary.INSTANCE.RegPDVEntraDataValidade(entraDataValidade);
        
        //-------------------------------------------------------------------
        TefSharedLibrary.iEntraData entraData = (new TefSharedLibrary.iEntraData() {

            public int pCallBackEntraData(String pLabel, Pointer pDataValidade) {
                String[] dados = cbImp.refCallBackEntraData(pLabel);  
                String dataValidade= dados [1];
                byte[] bytes = dataValidade.getBytes(characterSet);
                pDataValidade.write(0, bytes, 0, bytes.length);
                
                return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVEntraData(entraData);
        
        //-------------------------------------------------------------------
        TefSharedLibrary.iEntraCodigoSeguranca entraCodigoSeguranca = (new TefSharedLibrary.iEntraCodigoSeguranca() {

            public int pCallBackEntraCodigoSeguranca(String pLabel, Pointer pEntraCodigoSeguranca, int iTamanhoMax) {
                String[] dados = cbImp.refCallBackEntraCodigoSeguranca(pLabel);
               
                pLabel = dados[0];
                String entraCodigoSeguranca = dados [1];
                iTamanhoMax = Integer.parseInt(dados[2]);
                
                byte[] bytes = entraCodigoSeguranca.getBytes(characterSet);
                pEntraCodigoSeguranca.write(0, bytes, 0, bytes.length);  
               
                return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVEntraCodigoSeguranca(entraCodigoSeguranca);
       
        //-------------------------------------------------------------------
        TefSharedLibrary.iSelecionaOpcao selecionaOpcao = (new TefSharedLibrary.iSelecionaOpcao() {

            public int pCallBackSelecionaOpcao(String pLabel, String pOpcoes, int iOpcaoSelecionada) {
               cbImp.refCallBackSelecionaOpcao(pLabel);
               return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVSelecionaOpcao(selecionaOpcao);
      
        //-------------------------------------------------------------------
        TefSharedLibrary.iEntraValor entraValor = (new TefSharedLibrary.iEntraValor() {

            public int pCallBackEntraValor(String pLabel, Pointer pValor, String pValorMinimo, String pValorMaximo) {
                cbImp.refCallBackEntraValor(pLabel);
                String valor = "000000005000";
                byte[] bytes = valor.getBytes(characterSet);
                pValor = new Memory(bytes.length);            
                pValor.write(0, bytes, 0, bytes.length);
                //pCartao = "5149450271826511";
                return 0;
            }
        } );
       
        TefSharedLibrary.INSTANCE.RegPDVEntraValor(entraValor);
        //-------------------------------------------------------------------
        TefSharedLibrary.iEntraNumero entraNumero = (new TefSharedLibrary.iEntraNumero() {

            public int pCallBackEntraNumero(String pLabel, Pointer pNumero, String pNumeroMinimo, String pNumeroMaximo, int iMinimoDigitos, int iMaximoDigitos, int iDigitosExatos) {
                String[] dados = cbImp.refCallBackEntraNumero(pLabel);
                
                pLabel = dados[0];
                String numero = dados[1];
                pNumeroMinimo = dados[2];
                pNumeroMaximo = dados[3];   
                iMinimoDigitos = Integer.parseInt(dados[4]);
                iMaximoDigitos = Integer.parseInt(dados[5]);
                iDigitosExatos = Integer.parseInt(dados[6]);
                        
                byte[] bytes = numero.getBytes(characterSet);
                pNumero = new Memory(bytes.length);            
                pNumero.write(0, bytes, 0, bytes.length);
                return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVEntraNumero(entraNumero);
        
        //-------------------------------------------------------------------
        TefSharedLibrary.iOperacaoCancelada operacaoCancelada = (new TefSharedLibrary.iOperacaoCancelada() {

            public int pCallBackOperacaoCancelada() {
                cbImp.refCallBackOperacaoCancelada();
                return 0;
            }
        } );
       
        TefSharedLibrary.INSTANCE.RegPDVOperacaoCancelada(operacaoCancelada);
        //-------------------------------------------------------------------
        TefSharedLibrary.iSetaOperacaoCancelada setaOperacaoCancelada = (new TefSharedLibrary.iSetaOperacaoCancelada() {

            public int pCallBackSetaOperacaoCancelada(boolean bCancelada) {
               bCancelada = cbImp.refCallBackSetaOperacaoCancelada();
               return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVSetaOperacaoCancelada(setaOperacaoCancelada);
        //-------------------------------------------------------------------
        TefSharedLibrary.iProcessaMensagens processaMensagens = (new TefSharedLibrary.iProcessaMensagens() {

            public void pCallBackProcessaMensagens() {
                cbImp.refCallBackProcessaMensagens();
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVProcessaMensagens(processaMensagens);
        
        //-------------------------------------------------------------------
        TefSharedLibrary.iEntraString entraString = (new TefSharedLibrary.iEntraString() {

            public int pCallBackEntraString(String pLabel, Pointer pString, String pTamanhoMaximo) {
                String[] dados = cbImp.refCallBackEntraString(pLabel);
                pLabel = dados[1];
                String theString = dados[2];
                pTamanhoMaximo = dados[3];
                         
                byte[] bytes = theString.getBytes(characterSet);
                pString = new Memory(bytes.length);            
                pString.write(0, bytes, 0, bytes.length);
                
                return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVEntraString(entraString);
        //-------------------------------------------------------------------
        TefSharedLibrary.iConsultaAVS consultaAVS = (new TefSharedLibrary.iConsultaAVS() {

            public int pCallBackConsultaAVS(Pointer cEndereco, Pointer cNumero, Pointer cApto, Pointer cBloco, Pointer cCEP, Pointer cBairro, Pointer cCPF) {
               String[] dados = cbImp.refCallBackConsultaAVS();
               
                String endereco = dados[0];
                String numero = dados[1];
                String apto = dados[2];
                String bloco = dados[3];
                String CEP = dados[4];
                String bairro = dados[5];
                String CPF = dados[6];

                byte[] bytesEnd = endereco.getBytes(characterSet);      
                cEndereco.write(0, bytesEnd, 0, bytesEnd.length);
               
                byte[] bytesNum = numero.getBytes(characterSet);     
                cNumero.write(0, bytesNum, 0, bytesNum.length);
               
                byte[] bytesApto = apto.getBytes(characterSet);       
                cApto.write(0, bytesApto, 0, bytesApto.length);
                
                byte[] bytesBloco = bloco.getBytes(characterSet);
                cBloco.write(0, bytesBloco, 0, bytesBloco.length);
               
                byte[] bytesCEP = CEP.getBytes(characterSet);  
                cCEP.write(0, bytesCEP, 0, bytesCEP.length);
               
                byte[] bytesBairro = bairro.getBytes(characterSet);      
                cBairro.write(0, bytesBairro, 0, bytesBairro.length);
                
                byte[] bytesCPF = CPF.getBytes(characterSet);      
                cCPF.write(0, bytesCPF, 0, bytesCPF.length);
                
                return 0;   
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVConsultaAVS(consultaAVS);
        //-------------------------------------------------------------------
        TefSharedLibrary.iMensagemAdicional mensagemAdicional = (new TefSharedLibrary.iMensagemAdicional() {

            public int pCallBackMensagemAdicional(String pMensagemAdicional) {
                cbImp.refCallBackMensagemAdicional(pMensagemAdicional);
                return 0;
            }
        } );
                
        TefSharedLibrary.INSTANCE.RegPDVMensagemAdicional(mensagemAdicional);
        //-------------------------------------------------------------------
        TefSharedLibrary.iImagemAdicional imagemAdicional = (new TefSharedLibrary.iImagemAdicional() {

            public int pCallBackImagemAdicional(int iIndiceImagem) {
                cbImp.refCallBackImagemAdicional(iIndiceImagem);
               return 0;
            }
        } );
                
        TefSharedLibrary.INSTANCE.RegPDVImagemAdicional(imagemAdicional);
        //-------------------------------------------------------------------
        TefSharedLibrary.iEntraCodigoBarras entraCodigoBarras = (new TefSharedLibrary.iEntraCodigoBarras() {

            public int pCallBackEntraCodigoBarras(String Label, Pointer Campo) {
                String dados = cbImp.refCallBackEntraCodigoBarras(Label);                
                byte[] bytesCPF = dados.getBytes(characterSet);      
                Campo.write(0, bytesCPF, 0, bytesCPF.length);
               return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVEntraCodigoBarras(entraCodigoBarras);
        //-------------------------------------------------------------------
        TefSharedLibrary.iEntraCodigoBarrasLido entraCodigoBarrasLido = (new TefSharedLibrary.iEntraCodigoBarrasLido() {

            public int pCallBackEntraCodigoBarrasLido(String Label, Pointer Campo) {
                String dados = cbImp.refCallBackEntraCodigoBarrasLido(Label);
                byte[] bytesCPF = dados.getBytes(characterSet);      
                Campo.write(0, bytesCPF, 0, bytesCPF.length);
                return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVEntraCodigoBarrasLido(entraCodigoBarrasLido);
        //-------------------------------------------------------------------
        TefSharedLibrary.iMensagemAlerta mensagemAlerta = (new TefSharedLibrary.iMensagemAlerta() {

            public void pCallBackMensagemAlerta(String pMensagemAlerta) {
                cbImp.refCallBackMensagemAlerta(pMensagemAlerta);
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVMensagemAlerta(mensagemAlerta);
        //-------------------------------------------------------------------
        TefSharedLibrary.iPreviewComprovante previewComprovante = (new TefSharedLibrary.iPreviewComprovante() {

            public void pCallBackPreviewComprovante(String cComprovante) {
               cbImp.refCallBackPreviewComprovante(cComprovante);
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVPreviewComprovante(previewComprovante);
        //-------------------------------------------------------------------
        TefSharedLibrary.iSelecionaPlanos selecionaPlanos = (new TefSharedLibrary.iSelecionaPlanos() {

            public int pCallBackSelecionaPlanos(int iCodigoRede, int iCodigoTransacao, int iTipoFinanciamento, int iMaximoParcelas,
                Pointer pValorMinimoParcela, int iMaxDiasPreDatado, Pointer pNumeroParcelas, Pointer pValorTransacao, Pointer pValorParcela, Pointer pValorEntrada, Pointer pData) {
                
                String[] dados = cbImp.refCallBackSelecionaPlanos();
                
                iCodigoRede = Integer.parseInt(dados[0]);
                iCodigoTransacao = Integer.parseInt(dados[1]);
                iTipoFinanciamento = Integer.parseInt(dados[2]);
                iMaximoParcelas = Integer.parseInt(dados[3]);
                String valorMinParcela = dados[4];
                iMaxDiasPreDatado = Integer.parseInt(dados[5]);
                String numeroParcelas = dados[6];
                String valorTransacao = dados[7];
                String valorParcela = dados[8];
                String valorEntrada = dados[9];
                String data = dados[10];
                
                
                byte[] bytesVlrMinParcelas = valorMinParcela.getBytes(characterSet);     
                pValorMinimoParcela.write(0, bytesVlrMinParcelas, 0, bytesVlrMinParcelas.length);
               
                byte[] bytesNumParcelas = numeroParcelas.getBytes(characterSet);       
                pNumeroParcelas.write(0, bytesNumParcelas, 0, bytesNumParcelas.length);
                
                byte[] bytesVlrTransacao = valorTransacao.getBytes(characterSet);
                pValorTransacao.write(0, bytesVlrTransacao, 0, bytesVlrTransacao.length);
               
                byte[] bytesVlrParcela = valorParcela.getBytes(characterSet);  
                pValorParcela.write(0, bytesVlrParcela, 0, bytesVlrParcela.length);
               
                byte[] bytesVlrEntrada = valorEntrada.getBytes(characterSet);      
                pValorEntrada.write(0, bytesVlrEntrada, 0, bytesVlrEntrada.length);
                
                byte[] bytesData = data.getBytes(characterSet);      
                pData.write(0, bytesData, 0, bytesData.length);
                        
                return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVSelecionaPlanos(selecionaPlanos);
        //-------------------------------------------------------------------
        TefSharedLibrary.iSelecionaPlanosEx selecionaPlanosEx = (new TefSharedLibrary.iSelecionaPlanosEx() {

            public int pCallBackSelecionaPlanosEx(Pointer pSolicitacao, Pointer pRetorno) {
                String[] dados = cbImp.refCallBackSelecionaPlanosEx();
                String solicitacao = dados[0];
                String retorno = dados[1];
                
                byte[] bytesSolicitacao = solicitacao.getBytes(characterSet);      
                pSolicitacao.write(0, bytesSolicitacao, 0, bytesSolicitacao.length);
                
                byte[] bytesRetorno = retorno.getBytes(characterSet);      
                pRetorno.write(0, bytesRetorno, 0, bytesRetorno.length);
                
                
                return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVSelecionaPlanosEx(selecionaPlanosEx);
        //-------------------------------------------------------------------
        TefSharedLibrary.iDadosHistorico dadosHistorico = (new TefSharedLibrary.iDadosHistorico() {

            public int pCallBackDadosHistorico(String parte1, int tamParte1, String parte2, int tamParte2) {
                cbImp.refCallBackDadosHistorico(parte1, tamParte1, parte2, tamParte2);             
                return 0;
            }
        } );
        
        TefSharedLibrary.INSTANCE.RegPDVDadosHistorico(dadosHistorico); 
    }  
}