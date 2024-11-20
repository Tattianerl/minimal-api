# Minimal API

Este projeto é um exemplo de implementação de APIs minimalistas utilizando .NET, focando em simplicidade e desempenho. O objetivo é demonstrar como criar endpoints leves e funcionais com a nova abordagem introduzida nas versões mais recentes do .NET.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET 8
- **Estrutura**:
  - Diretório `Api`: Contém a lógica principal da API.
  - Diretório `Test`: Configurações e arquivos para testes automatizados.
  - Arquivo `minimal-api.sln`: Solução para abrir o projeto no Visual Studio.

## Funcionalidades

- Configuração básica de uma API RESTful.
- Endpoints minimalistas para melhorar o desempenho e reduzir a complexidade.
- Estrutura modular para expansão futura.

## Como Executar o Projeto

1. Certifique-se de ter o .NET SDK instalado na sua máquina.
2. Clone este repositório:
   ```bash
   git clone https://github.com/Tattianerl/minimal-api.git

3. Navegue até o diretório do projeto:
    ```bash
    cd minimal-api
    ```
4. Restaure as dependências e execute a aplicação:
    ```bash
    dotnet restore
    dotnet run
    ```
5. Acesse os endpoints disponíveis no navegador ou via ferramentas como o Postman.
## Testes
Para executar os testes automatizados, utilize o seguinte comando:
  ```bash
  dotnet test
  ```
## Como Contribuir
Se você quiser contribuir para este projeto, siga os seguintes passos:

Faça um fork deste repositório.
Crie uma branch com suas mudanças (git checkout -b feature/nova-funcionalidade).
Comite suas mudanças (git commit -am 'Adiciona nova funcionalidade').
Envie a branch para o seu fork (git push origin feature/nova-funcionalidade).
Abra um pull request.

## Licença
Este projeto está licenciado sob MIT. Veja o arquivo LICENSE para mais detalhes.



