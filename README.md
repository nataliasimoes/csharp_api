# API de Gerenciamento de Tarefas com C#

Esta é uma API RESTful desenvolvida em C# com .NET, projetada para realizar autenticação de usuários e gerenciamento de tarefas. A aplicação utiliza Entity Framework Core para acesso a dados, injeção de dependência para maior modularidade, autenticação via JWT e controle de acesso com autorização nas rotas protegidas.

## ✅ Funcionalidades

- Registro e login de usuários
- Criação, listagem, edição e exclusão de tarefas
- Camada de repositórios com injeção de dependência
- Validação de dados de entrada
- Documentação da API com Swagger
- Atribuição de tarefas a usuários

## 🔐 Autenticação e Autorização

A API utiliza JWT para autenticação de usuários. A autorização é aplicada nas rotas protegidas usando [Authorize].

## 📫 Endpoints

| Método HTTP | Rota                    | Autenticação   | Descrição                                |
| ----------- | ----------------------- | -------------- | ---------------------------------------- |
| GET         | /api/user               | 🔒 Autenticado | Retorna todos os usuários                |
| GET         | /api/user/{id}          | 🔒 Autenticado | Retorna um usuário por ID                |
| POST        | /api/user               | 🔓 Público     | Cria um novo usuário                     |
| PUT         | /api/user/{id}          | 🔒 Autenticado | Atualiza um usuário existente            |
| DELETE      | /api/user/{id}          | 🔒 Autenticado | Deleta um usuário por ID                 |
| GET         | /api/task               | 🔒 Autenticado | Retorna todas as tarefas                 |
| GET         | /api/task/filter        | 🔒 Autenticado | Filtra tarefas com base nos parâmetros   |
| GET         | /api/task/{id}          | 🔒 Autenticado | Retorna uma tarefa por ID                |
| POST        | /api/task               | 🔒 Autenticado | Cria uma nova tarefa                     |
| PUT         | /api/task/{id}          | 🔒 Autenticado | Atualiza uma tarefa existente            |
| PUT         | /api/task/complete/{id} | 🔒 Autenticado | Marca uma tarefa como concluída          |
| DELETE      | /api/task/{id}          | 🔒 Autenticado | Deleta uma tarefa por ID                 |
| POST        | /api/login              | 🔓 Público     | Realiza login e retorna token JWT válido |

## 🛠️ Tecnologias Utilizadas

Este projeto foi desenvolvido com as seguintes tecnologias e ferramentas:

- [**.NET 6**](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) – Plataforma principal para construção da API
- [**C#**](https://learn.microsoft.com/pt-br/dotnet/csharp/) – Linguagem de programação utilizada
- [**Entity Framework Core**](https://learn.microsoft.com/pt-br/ef/core/) – ORM para acesso ao banco de dados
- [**SQL Server**](https://www.microsoft.com/pt-br/sql-server/) – Banco de dados relacional
- [**JWT (JSON Web Tokens)**](https://jwt.io/) – Autenticação e autorização segura

## 🔧 Rodando localmente

Siga os passos abaixo para executar a API localmente usando o Visual Studio:

### 1. Clonar o repositório

Abra o terminal (ou Git Bash) e execute:

```bash
  git clone https://github.com/nataliasimoes/csharp_api.git
```

Ou, no próprio Visual Studio:

- Vá em File > Clone Repository...

- Cole o link: https://github.com/nataliasimoes/csharp_api.git

### 2. Abrir o projeto no Visual Studio

1. Com o repositório já clonado, abra o Visual Studio.

2. Clique em File > Open > Project/Solution.

3. Navegue até a pasta csharp_api e selecione o arquivo api_csharp.csproj.

### 3. Configurar appsettings.json

Antes de executar, abra o arquivo appsettings.json e configure a string de conexão com o banco e a sua chave JWT:

```json
  "ConnectionStrings": {
    "DataBase": "Server=[nomedoseuservidor];Database=DB_SistemaTarefas;Trusted_Connection=True;MultipleActiveResultSets=true;"
  },
  "Jwt": {
    "Key": "[sua_chave]",
    "Issuer": "sua_empresa",
    "Audience": "sua_aplicacao"
  }

```

> ❗ Importante: Certifique-se de ter o SQL Server instalado.

### 4. Rodar o projeto

No Visual Studio, selecione o projeto como Startup Project (clique com o botão direito no projeto api_csharp > Set as Startup Project) e pressione F5 para executar.

A API será inicializada e estará disponível em algo como:

```bash
  https://localhost:port/swagger
```
Para testar as rotas protegidas, crie um usuário utilizando o endpoint `POST /api/user` e, em seguida, realize o login com as credenciais informadas para obter o token JWT.

## 🖇️ Colaborando

Colaborações são bem-vindas! Se tiver alguma sugestão ou melhoria, fique à vontade para contribuir.

## 📄 Licença

Este projeto está sob a licença MIT - veja o arquivo [LICENSE.md](https://github.com/nataliasimoes/csharp_api/blob/master/LICENSE.txt) para detalhes.

---

⌨️ por [Natália Simões](https://github.com/nataliasimoes) 😊
