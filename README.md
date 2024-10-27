# Stock Quote

## Instalação e Configuração

1. Faça o clone do projeto:

```sh
git clone https://github.com/raffreitas/stock-quote.git
```

2. Crie um arquivo `settings.json` dentro da pasta do projeto, contendo as configurações de acesso ao servidor SMTP e ao serviço de consulta de ações. Foi utilizado o serviço **[brapi](https://brapi.dev/)** para a consulta das ações:

```json
{
    // Configurações de acesso ao servidor SMTP.
    "EmailHost": "", 
    "EmailPort": 0, 
    "EmailUserName": "",
    "EmailPassword": "",
    // E-mail do remetente.
    "EmailSender": "",
    // Lista dos destinatários.
    "EmailRecipients": [
        ""
    ],
    // Token de acesso a API do serviço de consulta de ações (brapi).
    "StockServiceApiKey": ""
}
```

3. Faça a publicação do release:

```sh
dotnet publish
```

## Execução

1. Acesse a pasta de release e faça a execução do arquivo:

```sh
./StockQuote.exe SIMBOLO_DO_ATIVO PREÇO_DE_VENDA PREÇO_DE_COMPRA
```
