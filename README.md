# 🚀 Task Manager API (.NET 10)

Um sistema de gerenciamento de tarefas (To-Do List) desenvolvido como uma **Web API Minimalista** utilizando .NET 10, Entity Framework Core e SQL Server hospedado na Azure.

## 📋 Funcionalidades

- **Listar Tarefas:** Retorna todas as tarefas salvas no banco de dados.
- **Criar Tarefa:** Adiciona uma nova tarefa com título, descrição, prioridade e status.
- **Remover Tarefa:** Exclui uma tarefa específica pelo ID.
- **Documentação Automática:** Interface visual via Swagger para testes rápidos.
- **Resiliência:** Configuração de *Retry Policy* para conexões estáveis com a nuvem.

## 🛠️ Tecnologias Utilizadas

- **C# / .NET 10**
- **ASP.NET Core Web API** (Minimal APIs)
- **Entity Framework Core 8**
- **Azure SQL Database** (Cloud Storage)
- **Swagger/OpenAPI** (Documentação)

## 🏗️ Estrutura do Projeto

* `Program.cs`: Configuração da API, Injeção de Dependência e Definição das Rotas.
* `AppDbContext.cs`: Contexto do banco de dados e mapeamento das entidades.
* `TaskItem.cs`: Modelo de dados representando uma tarefa e seus Enums.
* `appsettings.json`: Configurações de ambiente e strings de conexão (protegido por .gitignore).

## 🚀 Como Rodar o Projeto

### Pré-requisitos
* [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
* Um banco de dados SQL Server (Local ou Azure)

### Passo a Passo

1. **Clone o repositório:**
   ```bash
   git clone https://github.