# Dom.App

Dom.App é uma solução desenvolvida em .NET 8, que consiste em uma API e um site com PWA (Progressive Web App). O objetivo deste projeto é aperfeiçoar meus conhecimentos em .NET, Blazor e MudBlazor para criação de interfaces personalizadas e modernas.

## Tecnologias Utilizadas

- **.NET 8**: A última versão do framework .NET, oferecendo melhorias de performance, recursos avançados e compatibilidade com uma ampla gama de plataformas.
- **Blazor**: Framework que permite a construção de aplicações web interativas usando C# e .NET no lado do cliente.
- **MudBlazor**: Uma biblioteca de componentes para Blazor que facilita a criação de interfaces ricas e personalizáveis com Material Design.

## Funcionalidades

- **API RESTful**: Desenvolvida em .NET 8, fornece os endpoints necessários para comunicação com o PWA.
- **Progressive Web App (PWA)**: O site é otimizado para dispositivos móveis e pode ser instalado como um aplicativo no dispositivo do usuário.
- **Personalização com MudBlazor**: Utiliza componentes modernos e customizáveis para melhorar a experiência do usuário.
  
## Estrutura do Projeto

- **/src/Api**: Código-fonte da API em .NET 8.
- **/src/Web**: Código-fonte do site com PWA utilizando Blazor e MudBlazor.

## Como Executar

### Pré-requisitos

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0)
- [Node.js](https://nodejs.org/en/) (opcional, caso use NPM para gestão de pacotes do frontend)
  
### Rodando o Projeto

1. Clone o repositório:
    ```bash
    git clone https://github.com/seu-usuario/dom.app.git
    cd dom.app
    ```

2. Navegue até a pasta `src/Api` e rode o seguinte comando para iniciar a API:
    ```bash
    dotnet run
    ```

3. Para rodar o site PWA, navegue até `src/Web` e rode:
    ```bash
    dotnet run
    ```

4. Acesse o aplicativo no navegador em `https://localhost:5001` para o PWA e `https://localhost:5000` para a API.

## Contribuições

Contribuições são bem-vindas! Se você tem ideias ou melhorias, sinta-se à vontade para abrir um pull request ou relatar um problema.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
