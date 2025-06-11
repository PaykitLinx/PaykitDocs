# RELEASE NOTES:

##  Versão: 8.22.23.0019
    Descrição: Correções
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 06/06/2025

1. **Bugfix**              - Correção para enviar os dados de criptografia de dados sensiveis corretamente

##  Versão: 8.22.23.0018
    Descrição: Correções
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 03/06/2025

1. **Bugfix**              - Evitando de acionar a callback LogTransacaoAtual caso o atributo que armazena o json da transação atual não esteja populado
1. **Bugfix**              - Adicionando logs para termos registro da interação do usuario no metodo TransacaoFuncoesAdministrativas
1. **Bugfix**              - Atualizando binário do gerenciador padrão com as ultimas correções da homologação. Versão atual do modulo: 8.22.22.0006

##  Versão: 8.22.23.0017
    Descrição: Correções
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 23/05/2025

1. **Hotfix**              - Ajustando coleta dos dados do objeto json e corrigindo verificação da formatação do json enviado pela AC.
1. **Bugfix**              - Corrigindo coleta log transação json, para transações que não seja a ultima.
1. **Feature**             - Utilizando classe de retorno para tratar os retornos de forma padronizada no paykit
1. **Feature**             - Sincroninzando release de support 8.22.22.0033
1. **Feature**             - Cancelamento de pagamento QRCode no TEF, caso o mesmo seja cancelado pelo operador no PDV.
1. **Bugfix**              - Tratando erro SSL 6 (Conection closed by another side) nas transações de QR, para considerar como um timeout.

##  Versão: 8.22.23.0016
    Descrição: Correção na exportação de callback de tela
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 14/05/2025

1. **Bugfix**             - Correção na exportação da callback RegPDVImagemAdicional
1. **Bugfix**             - Correção método de conversão de string para inteiro, para tratar ltrim corretamente

##  Versão: 8.22.23.0015
    Descrição: Correções
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 09/05/2025

1. **Bugfix**             - Correção na manipulação de memoria a fim de evitar crash por corrupção da heap.

##  Versão: 8.22.23.0014
    Descrição: Correção no preenchimento dos campos da GetInfo
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 07/05/2025

1. **Hotfix**             - Ajustar envios de campos da GetInfo.
1. **Hotfix**             - Ajustando paykit para que o mesmo não notifique a automação via as callbacks de tela quando o PIX NFC for processado e o pinpad estiver com problemas de conexão.

##  Versão: 8.22.23.0013
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 25/04/2025

1. **Bugfix**             - Gravar o payment id da transação QRCode na InformacaoTransacaoCorrente.


##  Versão: 8.22.23.0012
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 08/04/2025

1. **Bugfix**             - Corrigindo conversão dos dados para log json, para que evite crashs indevidos no retorno das operações.


##  Versão: 8.22.23.0011
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 31/03/2025

1. **Bugfix**             - Corrigindo consulta parametro do cartão frota para que sinalize no display corretamente a atualização de tabelas.
1. **Bugfix**             - Corrigindo processamento da carga de tabelas do pinpad para não excluir registros da leitura do cartão incorretamente.


##  Versão: 8.22.23.0010
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 26/03/2025

1. **Hotfix**             - Correção de fluxo na transação QRCode, para o countdown da transação ser em minutos, e a consulta status ser automatica e não manual dependendo da aprovação do operador, e não sumir com o QRCode do pinpad durante a consulta status.
1. **Bugfix**             - Tratando Json de entrada, para que caso venha um caracter que conflite entre ANSI e UTF-8 não gere problemas para parsear o objeto.
1. **Bugfix**             - Adicionando instrução para deletar arquivos no linux e assim remover os logs antigos adequadamente.
1. **Feature**            - Adicionando no log da transação os novos retornos da adyen, sendo estes validade do cartão, numero do cartao e e codigo rede terceiro
1. **Bugfix**             - Corrigindo versão de testes para validar corretamente os endereços permitidos de conexão com o TEF
1. **Bugfix**             - Corrigindo geração de logs JSON para as transações Recarga Celular, Crediario, Voucher, Cancelamento, Confirmacao Pre Autorizacao, Private Label, Cartao Frota, Corban, Carga Vale Presente, QRCode.


##  Versão: 8.22.23.0009
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 19/03/2025

1. **Bugfix**             - Correção para eliminar handles corretamente no windows (Log, Interface Grafica e threads)
1. **Feature**            - Trazendo implementações sobre backup do arquivo de configuração do paykit
1. **Hotfix**             - Correção para que a biblioteca de ini tenha menos acesso ao disco, e forçando flushs do sistema operacional Windows.
1. **Bugfix**             - Arrumando carregamento da thread de logs, para respeitar as flags do arquivo ini
1. **Bugfix**             - Desabilitando método para obter o nome de um executável java.
1. **Bugfix**             - Corrigindo erro da aplicação no carregamento da FinalizaClient no Linux.
1. **Bugfix**             - Ajustando para que a biblioteca de logs seja carregada corretamente no paykit modelo embarcado.
1. **Bugfix**             - Adicionando tratativas para evitar crashs no fluxo de atualização de tabelas.
1. **Bugfix**             - Corrigindo fluxo de cancelamento da transação QRCode.


##  Versão: 8.22.23.0008
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 06/03/2025
    
1. **Bugfix**             - Ajustando a inicialização e encerramento das threads de display e logs para corrigir crash ao descarregar o paykit.


##  Versão: 8.22.23.0007
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 21/02/2025

1. **Bugfix**             - Correção para que o client preencha corretamente a estrutura getinfo reportada ao TEF.
1. **Bugfix**             - Correção na configuração de empresa,loja e pdv nas transações de teste de rede e consulta de transação


##  Versão: 8.22.23.0006
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 19/02/2025

1. **Bugfix**             - Corrigindo criação do cupom para aceitar PDV's de 4 digitos.
1. **Bugfix**             - Correção no parse do qrcode para o comando chipdirect.
1. **Bugfix**             - Correção na interação do usuario com a aplicação de interface gráfica, para que os inputs e botões do teclado funcionem da forma correta.
1. **Bugfix**             - Correção para que a thread de logs não gere crashs ao descarregar a DPOSDRV.


##  Versão: 8.22.23.0005
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 13/02/2025

1. **Bugfix**             - Corrigindo ordem das mensagens de display, para que o botão OK fique habilitado nas transações de cancelamento.
1. **Bugfix**             - Corrigindo problema de atualização de tabelas constantes para pinpads não abecs 
1. **Bugfix**             - Correção para que o ESC funcione quando o foco não está em nenhum botão


##  Versão: 8.22.23.0004
    Descrição: Correções homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 07/02/2025

1. **Bugfix**             - Corrigindo congelamento da tela do Paykit, quando recebida mensagem com ID divergente.
1. **Bugfix**             - Correção ObtemDadosConfigurados para evitar invasão de memoria.
1. **Bugfix**             - Correção na validação da abertura de arquivo ini
1. **Bugfix**             - Correção crash por conta da dll de logs que estava sendo destruída sem aguardar a thread ser lançada.
1. **Bugfix**             - Correção crash no fluxo de destruição do objeto de logs.
1. **Feature**            - Melhorando feedback visual para o usuário no inicio da transação QRCode
1. **Bugfix**             - Removendo looping interno da callback OperacaoCancelada de dentro do chipdirect e evitando chamadas duplicadas a interface grafica no fluxo PIXNFC.
1. **Bugfix**             - Corrigindo conversão de dados no log da transação json para QRCode, Credito, Recarga, Debito, Crediario, Voucher, Cancelamento, PreAutorizacao, Private Label, Frota
1. **Bugfix**             - Corrigindo fluxo de encerramento thread PIXNFC


##  Versão: 8.22.23.0003
    Descrição: Correções homologação PIX NFC
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 05/02/2025

1. **Bugfix**             - Corrigindo crash aplicação nas operações genericas QRCode


##  Versão: 8.22.23.0002
    Descrição: Correções homologação PIX NFC
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 04/02/2025

1. **Bugfix**             - Corrigindo fluxo de pagamento PIX NFC nos pinpads Lane3000 e Lane3600, pois, estes não desligam a antena com o comando APDU.


##  Versão: 8.22.23.0001
    Descrição: Correções homologação PIX NFC
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 29/01/2025

1. **Bugfix**             - Adicionando novos logs na comunicação entre Paykit e display e deixando log criptografado.
1. **Bugfix**             - Habilitando PIX NFC para pinpads NÃO ABECS e corrigindo fluxo de encerramento da thread do PIX NFC.
1. **Bugfix**             - Ajustando fluxo para não forçar coleta de valor para a rede Adyen


##  Versão: 8.22.23.0000
    Descrição: Proxima release de rollout do Paykit contendo fixes, QR Linx FULL, PIX NFC e outras otimizações.
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 23/01/2025

1. **Bugfix**             - Correção logica de carregamento da biblioteca de Logs no Linux, e correção para exibir janela de erro do sistema operacional.
1. **Feature**            - Atualização do binario do GPDirecao.exe para a versão 8.22.22.04 com tratamento de novos campos de requisição e resposta
1. **Bugfix**             - Remoção da possibilidade de atualização automatica para o Adapter Web.
1. **Bugfix**             - Corrigindo procura pinpad, para caso não esteja configurada a porta o paykit não gere bug.
1. **Bugfix**             - Alterado método de leitura da identificação do pinpad para abrir conexão com o pinpad de forma dinamica (Buscando pinpad)
1. **Bugfix**             - Corrigindo deadlock (thread de log) ao descarregar a DPOSDRV.dll da memoria, e adicionando nova dll nos instaladores e no embarcado (Windows e Linux).
1. **Feature**            - Novo método ObtemLogTransacaoJson
1. **Feature**            - Complementando os dados da callback LogTransacaoAtual com todos os dados disponíveis através do novo método ObtemLogTransacaoJson
1. **Feature**            - Ajuste nos paths criados no arquivo zip do Paykit embarcado
1. **Feature**            - Implementação PIX NFC para transações na rede Generica
1. **Feature**            - Alterando processamento dos logs do Paykit (arquivos dbg) para ser assincrono
1. **Feature**			  - Desabilitando o Campo do DPOS.ini que permite desligar a atualização automática
1. **Bugfix**             - Corrigindo alocação de mensagem de erro em caso de conexão sem ssl
1. **Feature**            - Otimizando tempo de verificação de tabelas em caso de falha de conexão
1. **Feature**            - Adicionando WebCheckout no instalador
1. **Feature**            - Desanexando aplicativo VerifNovaVersao do processo do Paykit, para ser executado de forma independente e ajustando instalador para reiniciar adapterweb caso necessário 
1. **Bugfix**             - Corrigindo logs antigos não serem deletados no Linux.
1. **Bugfix**             - Corrigindo menu para selecionar rede Adyen e outras, e também cache pinpad quando o mesmo não conter a tag PP_PUREVER
1. **Feature**            - Devolver informação de bandeira para a automação quando rede for Adyen
1. **Feature**            - Para cartões AMEX se timeout rede, executar o comando FCX
1. **Feature**            - Merge das implementacoes relativas a especificacao 2.03 da pagseguro
1. **Bugfix**             - Ajusta retorno da finischip
1. **Feature**            - Envio para o TEF de campo informando a razao do cancelmento de acordo com a spec 4.03/4.04 Stone
1. **Bugfix**             - Ajustando instalador Paykit para atualizar adaptadorWeb
1. **Feature**            - Refatoração para eliminar código inutilizado
1. **Feature**            - Adiciona funções no paykit para identificar Totem de autoatendimento e WebCheckout Java
1. **Bugfix**             - Desabilita o botão OK durante o processamento de mensagens e controle de identificação de mensagem enviada para o GrClient
1. **Feature**            - Nova funcionalidade de entrega de JSON via callback para a Automação
1. **Bugfix**             - Reinicia transação Voucher após erro "tarja antes de chip"
1. **Bugfix**             - Corrigindo descrição da rede SigaCred
1. **Bugfix**             - Correção do crash quando o registro AID recebido esta com tamanho incorreto
1. **Bugfix**             - Correção na aplicação de roteamento usando o campo lista de bins e aids
1. **Bugfix**             - Correção do comportamento da criação das tabelas com base no recebimento da lista de bins e aids
1. **Feature**            - Tratamento dos AIDs recebidos conforme o contexto do roteamento
1. **Feature**            - Ignorando lista de bins e AID's de contexto incorreto para o split de pagamentos


##  Versão: 8.22.22.1300
    Descrição: Versão de Projeto Integração completa QRLinx
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 20/12/2024

1. **Bugfix**             - Corrigir problemas de manipulação de memoria e padronização de retorno para a automação.
1. **Feature**            - Ajustes para considerar fluxo do NuPay, em transações QR Code na rede QRLinx
1. **Feature**            - Implementando nova callback de dados da transação corrente
1. **Feature**            - Implementando operação genérica QRLinx
1. **Feature**            - Suporte a novo formato de entrada de dados para transação QRCode
1. **Feature**            - Adicionando passo de entrada do motivo de cancelamento, para cancelamentos de pagamentos via QR Code na rede QRLinx


##  Versão: 8.22.22.0603
	Descrição: Versão de certificação rede Sicoob
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 03/10/2024

1. **Bugfix**             - Sicoob não suporta transações offline


##  Versão: 8.22.22.0602
	Descrição: Versão de certificação rede Sicoob
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 27/09/2024

1. **Bugfix**             - Ajusta nome da rede para Sipag-Sicoob


##  Versão: 8.22.22.0601
	Descrição: Versão de certificação rede Sicoob
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 16/05/2024

1. **Bugfix**             - Alteração para a rede Sicoob para executar corretamente o teste "AXP EMV 015" do roteiro da ABECS


##  Versão: 8.22.22.0600
	Descrição: Versão de certificação rede Sicoob
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 08/05/2024

1. **Feature**            - Adiciona nova rede Sicoob
1. **Feature**            - Adiciona informação capacidade do pinpad (PP_CAPAB)
1. **Bugfix**             - Corrige envio de informações do pinpad para o TEF
1. **Bugfix**             - Rede Generica: Resolve a passagem direta de cartões de tarja e exige fallback no chip.


##  Versão: 8.22.22.0028
    Descrição: Hotfix integração web legada
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 10/12/2024

1. **Hotfix**             - Correção para que a integração Web Java colete o path dos cupons pelo método do paykit e assim seja dinamica


##  Versão: 8.22.22.0027
    Descrição: Hotfix de produção
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 11/11/2024

1. **Hotfix**             - Ajustando retorno em caso de não recebimento do campo de status do QRCode na transação de Status QRCode
1. **Hotfix**             - Correção no metodo ConsultaTransacao que estava criando a estrutura de pastas do ambiente de telemarketing
1. **Hotfix**             - Ajuste na ConsultaTransacao para aceitar parâmetro pNumeroPDV de 4 bytes
1. **Hotfix**             - Força a carga de tabelas quando ocorrer o erro PP_TABEXP
1. **Hotfix**             - Ajuste no fluxo de reinicio transacional da rede Redecard
1. **Bugfix**             - Controle do envio e recebimento de mensagens entre o Client e o GrClient


##  Versão: 8.22.22.0026
    Descrição: Hotfix de produção
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 23/10/2024

1. **Hotfix**             - Ajuste no retorno do FinalizaTransacao em caso de erro


##  Versão: 8.22.22.0025
    Descrição: Hotfix de produção
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 08/10/2024

1. **Hotfix**             - Adição de novas validações na manipulação dos arquivos ini.


##  Versão: 8.22.22.0024
    Descrição: Hotfix de produção
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 04/10/2024

1. **Hotfix**             - Melhoria no tratamento de erro na abertura de arquivos de configuração


##  Versão: 8.22.22.0023
    Descrição: Hotfix de produção
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 25/09/2024

1. **Hotfix**             - Corrigindo fluxo de encerrar o processamento das callbacks de tela


##  Versão: 8.22.22.0022
  
    Descrição: Correções em homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 11/09/2024

1. **Hotfix**             - Fallback para placas gráficas sem suporte a OpenGL 2.0


##  Versão: 8.22.22.0021
  
    Descrição: Correções em homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 10/09/2024

1. **Hotfix**             - Correção de erro no instalador quando está fazendo atualização de versões com versão legada


##  Versão: 8.22.22.0020
  
    Descrição: Correções em homologação
    Plataforma: Windows x32, Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 28/08/2024

1. **Hotfix**             - Correção para exibir o código do erro junto à mensagem do erro
1. **Hotfix**             - Correção para enviar o CP_INFO_INSTALACAO_CLIENT em todas as solicitações ao TEF
1. **Hotfix**             - Correção de erro no instalador quando está fazendo atualização de versões com GP
1. **Hotfix**             - Adicionando logs de informações de controle para atualização de tabelas.
1. **Bugfix**             - Ajustando método de verificação de seção nos arquivos ini's para ser case insensitive.
1. **Hotfix**             - Priorizando o campo do TEF para coletar o nome da Rede.


##  Versão: 8.22.22.0019
  
    Descrição: Alteração no fluxo de Pipeline da aplicação
    Plataforma: Ubuntu 22.04 x64, Ubuntu 20.04 x64 e Ubuntu 20.04 x32
    Data: 08/07/2024

1. **Feature**            - Inclusão do fluxo de geração do Ubuntu 20.04 x64 e Ubuntu 20.04 x32.
1. **Hotfix**             - Impedindo criação do arquivo dpos.ini dentro da pasta virtualstore pelos binários das aplicações DPOSApp e GPDirecao.


##  Versão: 8.22.22.0018
  
    Descrição: Hotfixes produção
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 08/07/2024

1. **Hotfix**             - Inclusão de persistência nos dados da solicitação da automação para os casos de reinicio automatico de transação.
1. **Hotfix**             - Correção no processo de ativação da atualização automática e escolha de servidor
1. **Hotfix**             - Impedindo criação do arquivo dpos.ini dentro da pasta virtualstore pelas DLL's do Paykit.

##  Versão: 8.22.22.0017
  
    Descrição: Hotfixes produção
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 21/06/2024

1. **Hotfix**             - Ajuste no fluxo da tranação de débito da client visa para que processe os valores de saque e taxa embarque recebidos pela automação e respeitem o permite alteração.
1. **Hotfix**             - Ajuste no instalador, para que caso de problema para processar as constantes win e localappdata (Instalacao Padrao e compartilhada), o processamento siga via variaveis de ambiente.
1. **Hotfix**             - Ajuste no processamento das telas do Paykit, para encerrar adequadamente e limpeza da fila de processamento.
1. **Hotfix**             - Validação se foi possível manipular o arquivo INI nos métodos de confirmação da transação e finalização.


##  Versão: 8.22.22.0016
  
    Descrição: Correção do erro T014 - Cartão Inválido, no retorno da Consulta Parâmetros, da operação TransacaoCancelamentoConfirmada.
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 09/05/2024

1. **Hotfix**             - Correção na transação de telemarketing (CancelamentoConfirmada), para enviar ao TEF a forma de entrada digitado nessa transação.


## Versão: 8.22.22.0015
   
    Descrição: Correção do fluxo de cancelamento
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 09/05/2024

1. **Hotfix**             - Ajustando método LeIdentificacaoPinPad para que não corte os espaços em branco no final do número de série.
1. **Hotfix**             - Ajustando fluxo de cancelamento para não exibir o seleciona opção de última transação ou outra transação em caso de transação completa.

## Versão: 8.22.22.0014
   
    Descrição: Correção de problemas na homologação.
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 07/05/2024

1. **Hotfix**             - Corrige problema de travamento ao realizar uma transação com o pdv sem comunicação com o TEF na versão linux.

## Versão: 8.22.22.0013
   
    Descrição: Correção de problemas na certificação
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 19/04/2024

1. **Hotfix**             - Corrige a inicialização do diretorio dos certificados nas chamadas para busca de certificado em instalações que utilizam o modelo embarcado.

## Versão: 8.22.22.0012

    Descrição: Correção de problemas na certificação
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 18/04/2024

1. **Hotfix**             - Correção na carga de tabelas quando a automação mantém a DPOSDRV carregada entre transações

## Versão: 8.22.22.0011

    Descrição: Correção de problemas na certificação
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 16/04/2024

1. **Hotfix**             - Correção no calculo do MD5 dos arquivos e chaves de cache

## Versão: 8.22.22.0010

    Descrição: Correção de problemas na certificação
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 12/04/2024

1. **Hotfix**             - Registrando ponteiro para callback para função de bipe, e colocando verificação de nullpointer para evitar crash

## Versão: 8.22.22.0009

    Descrição: Correção de problemas na certificação
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 04/04/2024

1. **Hotfix**             - Corrigindo comportamento do objeto string entre Windows e Linux

## Versão: 8.22.22.0008

    Descrição: Correção de problemas na certificação
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 28/03/2024

1. **Hotfix**             - Corrigindo deadlock na configuração da otimização de telas

## Versão: 8.22.22.0007

    Descrição: Implementacao da consulta DCC para RedeCard. Adição da tag 84 para rede Cielo.
    Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
    Data: 15/03/2024

1. **Hotfix**             - Corrigindo fluxo de adição do pinpad keymap
1. **Hotfix**             - Corrigindo fluxo de coleta das informações estáticas do pinpad
1. **Feature**            - Validação das tabelas recebidas do TEF, para o Paykit se auto-recuperar em caso de tabelas vazias
1. **Feature**            - Gerar nova release de produção com DCC, tag 84 (Cielo) e consistência de tabelas
1. **Feature**            - Adiciona tag 84 a lista da GOONCHIP rede Cielo.
1. **Bugfix**             - Ajustes DE48 no DCC débito
1. **Bugfix**             - Ajusta fluxo DCC para pedir senha após a consulta
1. **Feature**            - Adição de logs para retornos sem consulta DCC
1. **Bugfix**             - Corrige falta de envio da transação de advice no débito
1. **Bugfix**             - Ajuste no conteúdo enviado no BIT48 da mensagem de consulta DCC
1. **Feature**            - Implementacao da consulta DCC para RedeCard.

## Versão: 8.22.22.0006
	
	Descrição: Correções realizadas durante a certificação de versão
	Plataforma: Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 15/02/2024

1. **Hotfix**             - Deletando cache a cada transação para não acumular dados.

### Links:
1. [Binários 8.22.22.0006](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/Ejw-2TSbwOZIo04AZf4Ri4sBpH5Yb2cGBYM1lDQpLeh14A?e=rNlKid)

## Versão: 8.22.22.0005
	
	Descrição: Correções realizadas durante a certificação de versão
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 15/02/2024

1. **Hotfix**             - Realizando cache de dados necessários para verificação de tabelas.

## Versão: 8.22.22.0004
	
	Descrição: Correções realizadas durante a certificação de versão
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 15/02/2024

1. **Bugfix**             - Alteração de passo que faz o envia da consulta status QR para imprimir comprovante.

## Versão: 8.22.22.0003
	Descrição: Correções realizadas durante a certificação de versão
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 08/02/2024

1. **Bugfix**             - Alteração da mensagem no pinpad para indicar timeout na transação QR.

## Versão: 8.22.22.0002
	
	Descrição: Correções realizadas durante a certificação de versão
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 08/02/2024

1. **Bugfix**             - Correção para que o client pegue os campos do TEF de forma correta.

## Versão: 8.22.22.0001
	
	Descrição: Correções realizadas durante a certificação de versão
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 07/02/2024

1. **Bugfix**             - Correção no fluxo de resolução de pendencias, para que se selecionada a opção MANTER o client acate e retire da lista principal a pendencia.
1. **Bugfix**             - Corrigindo transação de reimpressão completa para que acate os parametros passados e não questione ao usuário quando não deve.
1. **Bugfix**             - Limpando fila de mensagens de display para evitar crash ao destruir objeto de gerenciamento da tela.

## Versão: 8.22.22.0000
	
	Descrição: Pacote de rollout com melhorias de performance, retirada de uma perna transacional e hotfixes de produção.
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 29/01/2024

1. **Feature**             - Realizando cache de informações estaticas do pinpad.
1. **Feature**             - Diminuindo Sleep nos fluxos de looping com interação com o pinpad. Realizando mudanças para melhorias de consumo de CPU. Ajuste na thread de pinpad para remover looping infinito no momento de tratar dados no envio de QRCode para o device.
1. **Feature**             - Implementando Fluxo da transação consulta status na transação de QRCode.
1. **Feature**             - Uniformização dos tempos nas mensagens de display de acordo com o tipo de mensagem (normal, info, aprovação, erro).
1. **Feature**             - Otimizar a exibição das mensagens utilizando uma thread para controle da exibição das mensagens do Client no display.
1. **Feature**             - Alterando o instalador para remover os arquivos DiagnosticoDPOS.exe e Coletalogs.exe após a instalação.
1. **Bugfix**              - Adicionando tratamento de path com espaços no método ExtraiArquivos do ExecutaBuscaCertificado.
1. **Bugfix**              - Correção do comportamento do TextField de porta dentro de contingência.
1. **Feature**             - Alterando a lógica do campo que reporta a instalação do client para que também verifique se o tipo de instalação é TefPop ou WebCheckout

## Versão: 8.22.21.0402
	
	Descrição: Bugfix novo fluxo de atualização de tabelas
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 05/12/2023

1. **Bugfix**              - Validação para ver se pinpad está ativo no Paykit e o fluxo não entrar em looping para verificação de tabelas

## Versão: 8.22.21.0401
	
	Descrição: Bugfix novo fluxo de atualização de tabelas
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 30/11/2023

1. **Bugfix**              - Correção para que o client não fique atualizando tabelas a todo momento de forma indevida e Adição de mensagem informativa em caso de atualização de tabelas.

## Versão: 8.22.21.0400
	
	Descrição: Otimização fluxo transacional da carga de tabelas e na comunicação com o pinpad
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 10/11/2023

1. **Feature**             - Verificado integridade dos arquivos de tabelas e forçando atualização de tabelas quando necessário.
1. **Feature**             - Suporte a novo campo que força a atualização de tabelas.
1. **Feature**             - Refatorando Historico tempos resposta e historico erros local e mantendo a retro compatibilidade
1. **Feature**             - Ajustando fluxo de resolução de pendências para funcionar com a retro compatibilidade
1. **Feature**             - Atualização das configurações do client de forma remota 
1. **Bugfix**              - Fechando conexão com o pinpad após a atualização de tabelas
1. **Feature**             - Exportando método de atualização de tabelas para automação e adicionando sua utilização no dposconfig
1. **Feature**             - Alterando cor e nomes do menu do dposconfig
1. **Feature**             - Otimizar processo de coleta de informações pinpad
1. **Feature**             - Refatorar lógica fallback QR Code (Transação de Crédito)
1. **Feature**             - Ajuste do fluxo para fazer a atualização de tabelas apenas quando necessário.
1. **Feature**             - Cache dos campos recebidos durante a atualização de tabelas
1. **Bugfix**              - Correção do comportamento da ExecutaTransacaoEspecialColetaInformacaoPinpad para exibir mensagens de coleta e de erro.
1. **Bugfix**              - Correção do comportamento na reimpressão cupom completa caso não permita alteração. 
1. **Feature**             - Merge client x64 Windows

## Versão: 8.22.21.0005

	Descrição: Corrigindo processo de baixar certificado digital automatico, crash da transação private label completa e ajuste no comportamento do método trim
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 16/01/2024

1. **Feature**             - Implementando coleta pinpad ao client (Exibe Imagem).
1. **Hotfix**              - Correção de erros nas transações de saque completa e private label completa que originava crash.
1. **Hotfix**              - Corrigindo método que baixa o certificado digital automaticamente.

## Versão: 8.22.21.0004
    
	Descrição: Correção débito pré-datado.
	Plataforma: Ubuntu 20.04 x64
	Data: 04/01/2024
    
1. **Bugfix**              - Negando operações de Débito Pré-datado quando não habilitadas e não permite alteração para Cielo.

### Links:
1. [Binários 8.22.21.0004](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EpxeldTcdFRMoMPEiPEQXEgBwg8mEcnj1h1wBPcRySSVXw?e=GCHKck)

## Versão: 8.22.21.0003
	
	Descrição: Correção no instalador do Paykit, processo para aguardar serviço de telas ficar pronto e correção na comunicação com pinpad ABECS no Windows.
	Plataforma: Ubuntu 20.04 x64
	Data: 11/12/2023

### Notes:
1. **Hotfix**              - Ajuste para que o paykit aguarde o serviço de telas terminar de se processar para somente após isso tentar se comunicar.
1. **Hotfix**              - Correção para que o atalho criado para o VerifNovaVersao no Windows Startup esteja correto em sistemas com linguagem apenas em Portugues
1. **Hotfix**              - Correção para ajustar a comunicação de pinpads ABECS em máquinas TS.

### Links:
1. [Binários 8.22.21.0003](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EigkYfWU_ehOoB929Q5hGDwBXYLyNjyck5se10r6upLifA?e=q0gkxu)

## Versão: 8.22.21.0002

	Descrição: Correção para exibir mensagens corretas de acordo com o retorno da adquirente
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 16/11/2023

1. **Bugfix**              - Ajustando retorno da FinishChip em pinpads ABECS para identificar corretamente o motivo em caso de transação negada.

## Versão: 8.22.21.0001

	Descrição: Desenvolvimento do Client Compartilhado(ClientTS)
	Plataforma: Windows x32
	Data: 05/09/2023

### Notes:
1. **Bugfix**               - Correção alocação de memoria em transações com tarja
1. **Bugfix**               - Correção da criação de pastas na instalação do client compartilhado


### Links:
1. [Binários 8.22.21.0001](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EmhENzu9xeFDtJegGF4CEFYBtqQmwqYF7Mm3rhbLjxYtMA?e=KLW2MQ)

## Versão: 8.22.21.00

	Descrição: Desenvolvimento do Client Compartilhado(ClientTS)
	Plataforma: Windows x32
	Data: 02/08/2023

### Notes:
1. **Feature**              - Adicionando método ConsultaCadastroLoja para automação obter os dados de Empresa e Loja retornados pelo TEF a partir do CNPJ.
1. **Feature**              - Adicionando método ObtemDadosConfigurados para automação obter os dados de Empresa, Loja, CNPJ, IP e Porta do servidor TEF.
1. **Feature**              - Adição de campo novo para sinalizar o TEF o tipo de instalação do client
1. **Bugfix**               - Alterando método para parsear inteiro para hexa.
1. **Feature**              - Permitir apenas uma conexão nas telas do Client
1. **Feature**              - Carregando dlls da pasta do usuário ao invés da instalação
1. **Feature**              - DPOSConfig utilizando a DPOSDRV para configuração do ambiente inicial de um novo PDV Compartilhado e validações de dados
1. **Feature**              - Atualizando o coletor de logs, para capturar logs em qualquer tipo de instalação do client
1. **Feature**              - Trava para que apenas 1 atualizador de versão execute na máquina TS
1. **Feature**              - Remoção dos arquivos de configuração na desinstalação do client
1. **Feature**              - Criação de link para iniciar o atualizador de versão no startup
1. **Feature**              - Atualizando método atualização remota para utilizar o arquivo de configuração correto
1. **Feature**              - Adicionando método para automação obter diretório de cupons de forma programática.
1. **Feature**              - Movendo dados da ultima transação para o ini de registro da execução do client
1. **Feature**              - Criação do arquivo de configuração e diretórios do ambiente compartilhado.
1. **Feature**              - Adequação do instalador para utilização em ambiente compartilhado
1. **Feature**              - Ajustar o client para trabalhar com diferentes arquivos de configuração
1. **Feature**              - Tratamento de erro para pinpads sem chave de criptografia de dados da rede.

## Versão: 8.22.20.1119

	Descrição: Correção fluxo transação offline Cielo
	Plataforma: Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 24/08/2023
    
### Notes:
1. **Hotfix**           - Correção crash fluxo transação offline


### Links:
1. [Binários 8.22.20.1119](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/Emp5ijzAxJdOmqQCrc5NTp4BZWbuwWBlzfPt5JcqSF18xw?e=YwKYyL)
    
## Versão: 8.22.20.1118

	Descrição: Corrigindo processamento de log cartão pre pago
	Plataforma: Windows x32, Ubuntu 20.04 x64
	Data: 19/07/2023
    
### Notes:
1. **Bugfix**           - Ausencia informação log Client

### Links:
1. [Binários 8.22.20.1118](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EomK0XWMnF1Pv7V015J5f-0BIblTm_aEmkCZIO40wuNseA?e=447csr)
    
## Versão: 8.22.20.1117

	Descrição: Corrigindo fluxo na transação de Débito Parcelado
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 14/07/2023

### Notes:
1. **Bugfix**           - Correção tipagem de parametros recebidos pelo método que formata String e correção de situação de loop na transação de débito parcelado

    
## Versão: 8.22.20.1116

	Descrição: Sincronizando feature DPOS8 e ajuste no comportamento do GrClient para correção de erro no pagamento corban encontrado em certificação
	Plataforma: Windows x32 e Ubuntu 22.04 x64
	Data: 12/07/2023

### Notes:
1. **Bugfix**           - Reenvio de dados ao GrClient quando ocorre erro na comunicação
1. **Feature**          - Sincronizando DPOS8 e MP Feature cartão pré-pago
    

    
## Versão: 8.22.20.1115

	Descrição: Ajustes no log da transação de SPLIT
	Plataforma: Windows x32 e Ubuntu 22.04 x64
	Data: 05/07/2023

### Notes:
1. **Bugfix**           - Logs das transação SPLIT não estão sendo gravadas


    
## Versão: 8.22.20.1114

	Descrição: Ajustes na Instalação do Client no Ubuntu 22.04
	Plataforma: Ubuntu 22.04 x64
	Data: 04/07/2023

### Notes:
1. **Bugfix**           - Consertando instalação do client no Ubuntu 22.04



## Versão: 8.22.20.1113

	Descrição: Ajustes no funcionalidade de download de certificados e atualização dos dados do ini em memória quando a dll do client é mantida carregada.
	Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
	Data: 14/06/2023

### Notes:
1. **Bugfix**               - Ajustes na funcionalidade de download de certificados, para atender especificação.
1. **Feature**              - Atualização dos dados do ini dinamicamente quando a dll do client é mantida carregada entre chamadas.



## Versão: 8.22.20.1112

	Descrição: Ajuste para o método de configuração de comunicação com DTEF validar e retornar se foi um sucesso os parametros recebidos, correção de travamento em transação digitada e ajustes direcionados a aplicação DPOSAppConsole
	Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
	Data: 31/05/2023

### Notes:
1. **Feature**              - Melhorias no método ConfiguraComunicacaoDTEF
1. **Bugfix**               - Correção de travamento ao executar transação digitada em algumas adquirentes
1. **Bugfix**               - Ajustando extração de path de biblioteca no linux quando aplicação está no mesmo diretório do client



## Versão: 8.22.20.1111

	Descrição: Correção de problema encontrado na certificação
	Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
	Data: 26/05/2023

### Notes:
1. **Bugfix**              - Correção na funcionalidade de busca de certificado
1. **Bugfix**              - Melhorando mensagens de debug para busca de certificado no dposconfig



## Versão: 8.22.20.1110

	Descrição: Correção de problema encontrado na certificação
	Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
	Data: 22/05/2023

### Notes:
1. **Bugfix**              - Correção na funcionalidade de selecionar pasta do certificado no dposconfig e ajuste do arquivo qt.conf para client portable.



## Versão: 8.22.20.1109

	Descrição: Correção de problema encontrado na certificação
	Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
	Data: 17/05/2023

### Notes:
1. **Bugfix**              - Tratamento do campo permite alteração e controle dos produtos/serviços informados na transação completa para evitar a coleta quando não permite alteração
1. **Bugfix**              - Problema ao formatar valor em centavos em cenários específicos.
1. **Bugfix**              - [SPLIT] Removendo chamadas Crédito e Débito Simples para transação de split.



## Versão: 8.22.20.1108

	Descrição: Correção de problema de produção
	Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
	Data: 09/05/2023

	### Notes:
1. **Bugfix**              - Problema de parametro para pagamento de carne para SafraPay na transação de Débito



## Versão: 8.22.20.1107

    Descrição: Correções de problemas encontrados durante a certificação Ubuntu 20.04 32bits.
    Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
    Data: 04/05/2023

### Notes:
1. **Bugfix**              - Correção na função GravaErro que causava o travamento da aplicação em alguns casos.
1. **Bugfix**              - Correção de travamento ao finalizar uma transação de Pagamento Corban.



## Versão: 8.22.20.1106

    Descrição: Implementação da transacao de SPLIT Débito e crédito.
    Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
    Data: 25/04/2023

### Notes:
1. **Feature**             - [Split] SPLIT Estruturante Crédito e Débito
1. **Feature**             - [Split] Chamada função debito, mais produtos e recebedores
1. **Feature**             - [Split] Chamada função credito, mais produtos e recebedores
1. **Bugfix**              - [Split] Correções transação SPLIT
1. **Bugfix**              - Correção de travamento ao digitar o cvv.
1. **Bugfix**              - Tratamento de transação de qrcode sem wallet disponível.



## Versão: 8.22.20.1105

    Descrição: Implementação da coleta de dados usando comando GCD (ABECS 2.xx), redução no tamanho do instalador e correção de funcionalidade no modo portable linux.
    Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
    Data: 10/04/2023

### Notes:
1. **Feature**             - Implementar as coletas de dados disponibilizadas no comando GCD da especificação ABECS 2.xx.
1. **Feature**             - Ajustando dependências externas (Qt e MSVC) para reduzir o tamanho do setup e retirar a necessidade de instalar o runtime do MSVC.
1. **Bugfix**              - Correção da procura pinpad usando o dposconfig no Linux no modo portable.



## Versão: 8.22.20.1104

    Descrição: Versão de rollout incluíndo as últimas correções e suporte a Ubuntu 20.04 32bits.
    Plataforma: Ubuntu 20.04 x32, Ubuntu 22.04 x64 e Windows x32
    Data: 30/03/2023

### Notes:
1. **Feature**             - Suporte a Ubuntu 20.04 32 bits realizando cross-compile em um ambiente x64.
1. **Feature**             - Permitir a coleta da data de nascimento na transação especial 121 quando estiver sendo utilizado um pinpad ABECS
1. **Feature**             - Relacionar as perguntas variaveis do Gateway com os parâmetros da TransacaoCartaoFrotaCompleta, evitando a realização de perguntas que estejam nos parametros da transacao
1. **Feature**             - Permitir a passagem da placa completa (7 caracteres) nos parametros reservados da TransacaoCartaoFrotaCompleta
1. **Feature**             - Seleção automatica da rede para transação de frota na TransacaoCartaoFrotaCompleta
1. **Feature**             - Corrigir a alocação de memória para os dados de serviço de acordo com o tipo de cartão frota e criar estrutura para tratamento dos dados da TicketLog nas transacoes de frota
1. **Bugfix**              - Consertando operadores de classe
1. **Feature**             - Resolvendo dependências internas de forma que não seja mais necessário que o diretório do client seja incluido no path do sistema.
1. **Feature**             - Ajustes de comportamentos do GrClient no Linux para que se comporte da mesma forma em todos os SOs.



## Versão: 8.22.20.1103

    Descrição: Correção ponto levantado durante certificação DPOS8.
    Plataforma: Ubuntu 22.04 x64 e Windows x32
    Data: 07/03/2023

### Notes:
1. **Bugfix Certificação** - Correção no processamento da biblioteca compartilhada e ppcomp, para processarem adequadamente a lista de AID's na stargetcard, dependendo se o pinpad é ou não é ABECS.




## Versão: 8.22.20.1102

    Descrição: Hotfix de produção verificado no DPOS8.
    Plataforma: Ubuntu 22.04 x64 e Windows x32
    Data: 24/02/2023

### Notes:
1. **Hotfix**              - Correção na estrutura da startgetcard, para que ela passase aceitar a lista de AID's com 512 bytes, conforme especificação da ABECS.



## Versão: 8.22.20.1101

    Descrição: Hotfix de produção verificado no DPOS8.
    Plataforma: Ubuntu 22.04 x64 e Windows x32
    Data: 15/02/2023

### Notes:
1. **Hotfix**              - Correção na transação de cancelamento completa.



## Versão: 8.22.20.11

    Descrição: Versão de rollout.
    Plataforma: Ubuntu 22.04 x64 e Windows x32
    Data: 10/02/2023

### Notes:
1. **Feature** 		       - Upgrade das bibliotecas openssl.
1. **Bugfix**		       - Correção na data das transaçãoes nas transações de CORBAN.
1. **Bugfix**              - Validação de comunicação com o pinpad no Linux.
1. **Bugfix**              - Correção na seleção de opções no GRClient. 
1. **Bugfix**              - Ajuste na comunicação serial do pinpad com o client.
1. **Feature**             - Melhoria no download de certificados, para baixar com base em dados padrão. 
1. **Feature**             - Reestruturação libopenssl.
1. **Feature**             - Remoção de warnings
1. **Feature**             - Adição de bloqueio no download do certificado, para evitar que multiplos certificados sejam baixados
1. **Feature**             - Feature para fazer download de certificado SSL
1. **Bugfix Certificação** - Ajustes na funcionalidade do botão Configura DPOS no DPOSApp
1. **Merge**               - Merge das alterações do DPOS 8.22.15.0125
