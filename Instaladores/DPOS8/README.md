# RELEASE NOTES:

## Versão: 8.22.15.0133

	Descrição: Atualização mensagem de erro display PDV
	Plataforma: Windows x32
	Data: 27/10/2023
    
### Notes:
1. **Feature**           - Alterando modulos do client para exibir mensagem de negativa da rede adquirente.

### Links:
1. [Binários 8.22.15.0133](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EqtPO0Otq09IryQDgNwTQ6MBZCFbgxi-q273j8wDHa83_w?e=IApVaH)

## Versão: 8.22.15.0132

	Descrição: Correção de certificação
	Plataforma: Windows x32
	Data: 19/07/2023
    
### Notes:
1. **Bugfix**           - Corrigindo ausencia de informação no log do cartão prepago.

### Links:
1. [Binários 8.22.15.0132](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EsvUZSjVndVKpO0JTAelfXcBdqw41B1JVcnsETuE85beaA?e=XddMyr)

## Versão: 8.22.15.0131

	Descrição: Feature cartão pré-pago
	Plataforma: Windows x32
	Data: 29/06/2023
    
### Notes:
1. **Feature**          - Alteração para disponibilizar no registro de log de débito e crédito para que seja informado se o cartão utilizado na transação é um cartão pré-pago ou pós-pago. 

### Links:


## Versão: 8.22.15.0130

	Descrição: Hotfix
	Plataforma: Windows x32
	Data: 15/05/2023
    
### Notes:
1. **Bugfix**           - Correção no retorno da DesfazCartao  
1. **Bugfix**           - Correção no processamento do byte 71 do campo reservado para pagamento carne no débito. 

### Links:
1. [Binários 8.22.15.0130](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EkmJZRETEgpEviNpngiFxtEB9ary81iGM7WAYuRkLTHQog?e=PlgX4r)

## Versão: 8.22.15.0129

	Descrição: Atualização transação especial e sincronização de versão DPOS8
	Plataforma: Windows x32
	Data: 15/05/2023
    
### Notes:
1. **Feature**          - Correção de fluxo referente aos produtos gift card com a rede Black Hawk. 
1. **Feature**          - Implementação dos métodos de coleta de data nos pinpads abecs contemplando os três formatos descritos na especificação e utilizados na transação 121. 

### Links:
1. [Binários 8.22.15.0129](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EjSQHHHtPgVPrakYSKZDzkgBlXSvQ3DxL57MwUN6lCXrMQ?e=dTxxax)

## Versão: 8.22.15.0128

	Descrição: Hotfix
	Plataforma: Windows x32
	Data: 07/03/2023
    
### Notes:
1. **Bugfix**           - Correção na biblioteca compartilhada e ppcomp para processar corretamente a lista de AID’s na stargetcard para pins abecs e não abecs. 


### Links:
1. [Binários 8.22.15.0128](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EnPkBty561FAnKKzYfYrbkEBDo3ZKrDq5fBlzWAYMSys6A?e=HXJdfB)

## Versão: 8.22.15.0127

	Descrição: Hotfix
	Plataforma: Windows x32
	Data: 27/02/23
    
### Notes:
1. **Bugfix**           - Alteração para que na startgetcard o pinpad recebesse uma lista com até 128 AID’s ao invés do limite de 99, suportando assim a especificação da ABECS. 


### Links:


## Versão: 8.22.15.0126

	Descrição: Hotfix
	Plataforma: Windows x32
	Data: 16/02/23
    
### Notes:
1. **Bugfix**           - Correção na transação de cancelamento completa, para que caso o valor seja passado como parametro pela automação ele seja devidamente configurado para processar a getcard. 


### Links:


## Versão: 8.22.15.0125

	Descrição: Alteração de validação da carga de tabelas
	Plataforma: Windows x32
	Data: 21/12/22
    
### Notes:
1. **Feature**          - Atualização Tabelas Pinpad: Atualizando método de obter dado de controle e evitar multiplas cargas durante o dia.


### Links:


## Versão: 8.22.15.0124

	Descrição: Hotfix
	Plataforma: Windows x32
	Data: 11/10/22
    
### Notes:
1. **Bugfix**           - TicketLog: Alteração no fluxo do client, para que ele passe a tratar o erro T92 durante a etapa de consulta de parametros rede. 
1. **Bugfix**           - ValeCard: Correção no parser das mensagens que o client recebe do TEF e precisa exibir uma seleção de menus para o usuario. 
1. **Bugfix**           - ObtemLogUltimaTransacao: Correção no ObtemLogUltimaTransacao para que o client devolva o tipo de parcelamento da forma correta, se é AV, FL ou FA. 


### Links:
1. [Binários 8.22.15.0124](https://grupolinx-my.sharepoint.com/:f:/g/personal/ped_payhub_tef_linx_com_br/EiNemWYcAlpMp9Xxnckwj50BqIaDRiyIX9Sq2wn378Kg3A?e=pbvZZz)

## Versão: 8.22.15.0123

	Descrição: Hotfix
	Plataforma: Windows x32
	Data: 28/09/22
    
### Notes:
1. **Bugfix**           - Correção para que o client se recupere em caso de falha na comunicação com o pinpad. Erros tratados: PP_COMMERR, PP_PORTERR e PP_NOTOPEN 


### Links:
