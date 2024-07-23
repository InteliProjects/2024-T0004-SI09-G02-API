# Processo de Deploy com GitHub Actions e Docker

Este documento fornece uma visão geral do processo de deploy do backend em C# do nosso projeto, utilizando um pipeline de Integração Contínua (CI) e Entrega Contínua (CD) implementado com GitHub Actions com containerização no Docker.

## GitHub Actions Workflow

O arquivo YAML no diretório `.github` define o pipeline CI/CD e é dividido em três principais trabalhos: `build`, `test` e `deploy`.

### Build Job

```
jobs:
  build:
    name: "Build"
    runs-on: ubuntu-latest

    steps:
    - name: "Checkout"
      uses: actions/checkout@v2

    - name: "Set Dotnet"
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: "Restore dependencies"  
      run: dotnet restore

    - name: "Build api"  
      run: dotnet build --configuration Release
```
Processo realizado no **build**:

- Checkout: Obtém o código-fonte do repositório para o runner do GitHub.
- Set Dotnet: Configura o ambiente com a versão especificada do .NET 8.
- Restore dependencies: Instala todas as dependências do .NET.
- Build: Compila o o backend .NET para produção.

### Test Job
```
jobs:
  test:
   name: Unit Test
   runs-on: ubuntu-latest
   needs: build
   steps:
    - name: "Checkout"
      uses: actions/checkout@v2
    
    - name: "Set Dotnet"
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: '8.0.x'
    
    - name: "Restore dependencies"  
      run: dotnet restore
    
    - name: "Run unit test"
      run: dotnet test --no-build --verbosity normal
```
Processo adicional realizado no "Test Job":

- needs: Especifica que o trabalho de teste depende da conclusão bem-sucedida do trabalho de construção.
- Run unit test: A adição de teste aqui ela é feita a partir dos arquivos de teste na pasta Tests.

### Deploy Job

```
jobs:
  deploy:
    name: Deploy
    needs: test
    runs-on: ubuntu-latest
    steps:
      - name: Deploy to production
        uses: johnbeynon/render-deploy-action@v0.0.8
        with:
           service-id: ${{ secrets.RENDER_SERVICE_ID }}
           api-key: ${{ secrets.RENDER_API_KEY }}
```
Processo adicional para o deploy final:

- Deploy to Production: Este passo usa uma action do GitHub para implantar o backend na plataforma especificada, neste caso, o Render.
- secrets: Utiliza secrets do repositório para autenticar no serviço de hospedagem (chaves de acesso do Render).

### Docker Configuration 

```
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Usando a imagem SDK do .NET para construir o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiando o arquivo do projeto e restaurando dependências
COPY ["GTI.Dashboard.WebApi.csproj", "."]
RUN dotnet restore "GTI.Dashboard.WebApi.csproj"

# Copiando todo o código e construindo o aplicativo
COPY . .
WORKDIR "/src"
RUN dotnet build "GTI.Dashboard.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publicando o aplicativo
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "GTI.Dashboard.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Usando a imagem ASP.NET para executar o aplicativo publicado
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GTI.Dashboard.WebApi.dll"]
```

A configuração do Docker constrói uma imagem contendo a estrutura .NET:

- Base: Define a imagem base para o aplicativo, com a versão do .NET 8 e as portas 8080 e 8081 expostas.
- Build: Copia o código-fonte do aplicativo, restaura as dependências e compila o aplicativo.
- Publish: Publica o aplicativo compilado em um diretório específico.
- Final: Copia o aplicativo publicado para a imagem final e define o ponto de entrada para executar o aplicativo.


## CI/CD Pipeline Aplicado no projeto

O pipeline de CI/CD aplicado funciona da seguinte forma:

- Integração Contínua (CI): No push para o branch principal ou em um pull request, o GitHub Actions executa o build para compilar o código e executar os testes unitários (test).

- Entrega Contínua (CD): Se o build e testes passarem, o trabalho deploy é executado para implantar o aplicativo compilado em um ambiente de produção.

Este pipeline garante que cada alteração no código seja automaticamente construída e testada antes de ser entregue ao ambiente de produção, minimizando os riscos associados ao processo de deploy manual e aumentando a eficiência do ciclo de vida do desenvolvimento de software.