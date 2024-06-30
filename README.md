
# Consulta CPF Receita Federal

🚀 **Projeto de Consulta de Situação Cadastral do CPF**

![DemostraoProjetoAlem](https://github.com/TiagosCompanny/Alem-ConsultaCpf/assets/116459741/e345c4de-d8f5-48eb-99e6-b95b6d6d64a5)


## Descrição

Esta aplicação permite consultar a situação cadastral do CPF na Receita Federal de forma simples, eficiente e segura. Desenvolvi esta solução gratuita para automatizar o acesso às informações de regularidade fiscal dos contribuintes brasileiros, competindo com as APIs pagas disponíveis no mercado.

## Principais Funcionalidades

- **Processamento em segundo plano**: Garantia de eficiência máxima.
- **Importação direta de planilhas Excel**: Facilita o uso e a automação.
- **Resolução de captchas**: Validação automática para garantir acesso contínuo.
- **Tratamento robusto de erros e exceções**: Minimiza falhas e interrupções.
- **Validação de dados e arquivos de entrada**: Assegura a integridade e a precisão das informações.
- **Cronometragem do tempo de processamento**: Permite monitorar e otimizar o desempenho.

## Tecnologias Utilizadas

- **C#**: Linguagem de Programação utilizada no Projeto.
- **EPPLUS**: Biblioteca para leitura e escrita de dados no Excel.
- **Selenium**: Ferramenta de automação de processos web (RPA).
- **Auto CAPTCHA Solver**: Arquivo .crx para quebra de Captcha.

## Pipeline da Aplicação

1. **Envio de Planilha**: O usuário faz o envio da planilha no campo input do formulário.
2. **Processamento**: A aplicação consulta a situação cadastral do CPF para cada entrada.
3. **Leitura e Validação**: A aplicação valida o arquivo importado e os dados contidos nele.
4. **Retorno**: Os resultados de cada CPF consultado são salvos na planilha enviada.

## Como Utilizar

1. Clone este repositório:
    ```sh
    git clone https://github.com/TiagosCompanny/Alem-ConsultaCpf.git
    ```
2. Navegue até o diretório do projeto:
    ```sh
    cd seu-repositorio
    ```
3. Instale as dependências necessárias:
    ```sh
    dotnet restore
    ```
4. Compile e execute a aplicação:
    ```sh
    dotnet run
    ```

## Contato

🔍 Se você está interessado em simplificar e agilizar suas rotinas, estou à disposição para compartilhar mais sobre o projeto! Entre em contato pelo [LinkedIn](https://www.linkedin.com/in/tiagoscompanny/).
