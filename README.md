# 📝 Task Manager Console

Um gerenciador de tarefas robusto desenvolvido em **C#** para consolidar conceitos de Programação Orientada a Objetos (POO), Injeção de Dependência e persistência de dados real com banco de dados.

## 🚀 Funcionalidades
- **Adicionar Tarefas:** Registro de título, descrição, prioridade e status.
- **Listar Tarefas:** Consulta direta ao banco de dados SQLite.
- **Editar/Excluir:** Gerenciamento completo do ciclo de vida das tarefas via terminal.
- **Persistência Real:** Dados salvos em arquivo, permanecendo disponíveis após reiniciar.

## 🛠️ Tecnologias Utilizadas
- **Linguagem:** C# (.NET 8.0/9.0)
- **Tipo de Projeto:** Console Application
- **Banco de Dados:** SQLite (Arquivo local `.db`)
- **ORM:** Entity Framework Core
- **Arquitetura:** Service Pattern e Injeção de Dependência.

## 📂 Estrutura do Projeto
- `TaskItem.cs`: Entidade que representa a tarefa no banco.
- `AppDbContext.cs`: Coração da conexão com o SQLite.
- `TaskService.cs`: Onde a "mágica" acontece (lógica de salvar e buscar).
- `Program.cs`: Interface de usuário via Console.

## ⚙️ Como Rodar o Projeto

1. **Certifique-se de ter o SDK do .NET instalado.**
2. **Clone o repositório:**
   ```bash
   git clone [https://github.com/SEU_USUARIO/TaskManager.git](https://github.com/SEU_USUARIO/TaskManager.git)