# Sistema Escolar

API para gestão escolar voltada a **escolas particulares**, conectando a direção, os professores, os alunos e os responsáveis em um só lugar.

> 🚧 **Status: em desenvolvimento.** O projeto está sendo construído de forma incremental, começando por um MVP enxuto e evoluindo por fases. Este é também um projeto de estudo e portfólio.

## Objetivo

Escolas particulares costumam resolver a comunicação com as famílias e o acompanhamento dos alunos com grupos de mensagens, papel e planilhas. Este sistema busca centralizar isso, oferecendo a cada perfil (gestão, secretaria, professor, aluno e responsável) uma visão adequada às suas necessidades.

## Tecnologias

- **C# / .NET 10** com **ASP.NET Core Web API**
- **Entity Framework Core** (migrations e acesso a dados)
- **SQL Server** (LocalDB em desenvolvimento)
- **OpenAPI + Scalar** para documentação e teste interativo dos endpoints
- **React + TypeScript** para o frontend (planejado)

## Estado atual

- [x] Estrutura inicial do projeto e documentação interativa da API (Scalar)
- [x] Modelagem inicial com EF Core: `Escola` e `Turma`
- [x] Banco de dados criado via migrations
- [x] Endpoints de escolas (`GET /api/escolas` e `POST /api/escolas`) com uso de DTOs
- [x] Endpoints de turmas
- [ ] Alunos, responsáveis e professores
- [ ] Autenticação e autorização por perfil
- [ ] Frontend em React

## Roadmap do MVP

A ideia é entregar primeiro uma base simples e útil, e só depois expandir.

**Fase 1: MVP**
1. Cadastro de escolas, turmas, alunos, professores e responsáveis
2. Login por perfil, com cada usuário vendo apenas o que lhe cabe
3. Mural de avisos e comunicados por turma ou geral
4. Registro de frequência
5. Lançamento e consulta de notas (boletim)

**Fases seguintes:** tarefas e atividades, calendário, mensagens entre responsáveis e professores, módulo financeiro, relatórios gerenciais.

## Decisões de arquitetura

- **DTOs de entrada e saída:** a API nunca expõe nem recebe as entidades do banco diretamente. Isso protege contra *over-posting*, evita ciclos de serialização e mantém o contrato da API estável mesmo que o banco mude.
- **Migrations versionadas:** toda mudança na estrutura do banco passa por uma migration.
- **Preparado para várias escolas:** o modelo de dados parte da ideia de que cada escola é um cliente isolado dos demais.

## Como executar

### Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download)
- SQL Server LocalDB (já incluído no workload "ASP.NET e desenvolvimento para a Web" do Visual Studio)
- Visual Studio (recomendado) ou outro editor de sua preferência

### Passo a passo

```bash
# 1. Clonar o repositório
git clone https://github.com/vnery44/sistema-escolar.git
cd sistema-escolar

# 2. Criar o banco de dados (a partir da raiz do repositório, onde fica o .csproj)
dotnet tool install --global dotnet-ef
dotnet ef database update

# 3. Executar a API
dotnet run
```

No Visual Studio, o banco também pode ser criado com `Update-Database` no Console do Gerenciador de Pacotes, e a API executada com **F5**.

Com a API rodando, a documentação interativa fica em `https://localhost:<porta>/scalar` (a porta aparece no terminal, em `Now listening on`).

## Estrutura do projeto

```
sistema-escolar/
├── Controllers/              # Endpoints da API
├── Data/                     # DbContext (AppDbContext)
├── DTOs/                     # Objetos de entrada e saída da API
├── Entities/                 # Entidades mapeadas para o banco
├── Migrations/               # Histórico de alterações do banco
├── Program.cs                # Configuração e inicialização da aplicação
├── SistemaEscolar.Api.csproj # Arquivo do projeto
└── SistemaEscolar.Api.slnx   # Solução do Visual Studio
```

## Autor

**Vinicius Costa Nery Ferreira**
GitHub: [@vnery44](https://github.com/vnery44)
