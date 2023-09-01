# RELEASE NOTES:


## Versão: 8.22.20.1119

	Descrição: Correção fluxo transação offline Cielo
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
	Data: 24/08/2023
    
### Notes:
1. **Hotfix**           - Correção crash fluxo transação offline


### Links:
1. [Binários 8.22.20.1119](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/Emp5ijzAxJdOmqQCrc5NTp4BZWbuwWBlzfPt5JcqSF18xw?e=YwKYyL)
    
## Versão: 8.22.20.1118

	Descrição: Corrigindo processamento de log cartão pre pago
	Plataforma: Windows x32, Ubuntu 22.04 x64 e Ubuntu 20.04 x64
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
