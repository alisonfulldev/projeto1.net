# 📚 Gerenciador de Livraria — API REST

API REST desenvolvida em .NET para gerenciar os livros de uma livraria. Permite criar, listar, buscar, atualizar e excluir livros (CRUD completo), com validações de campos, documentação via Swagger e herança entre classes para organizar o domínio.

> Projeto desenvolvido como desafio prático da formação em C# da Rocketseat.

## ✨ Funcionalidades

- Criar um novo livro
- Listar todos os livros cadastrados
- Buscar um livro específico pelo ID
- Atualizar as informações de um livro
- Excluir um livro
- Validação automática dos campos
- Documentação interativa via Swagger

## 🛠️ Tecnologias

- .NET (ASP.NET Core Web API)
- C#
- Swagger (Swashbuckle) para documentação

## 📋 Modelo de dados

Cada livro possui os seguintes campos:

| Campo       | Tipo     | Regras                                      |
|-------------|----------|---------------------------------------------|
| `id`        | GUID     | Gerado automaticamente pelo sistema         |
| `title`     | string   | Obrigatório, entre 2 e 120 caracteres       |
| `author`    | string   | Obrigatório, entre 2 e 120 caracteres       |
| `genre`     | string   | Obrigatório                                 |
| `price`     | decimal  | Obrigatório, maior ou igual a 0             |
| `stock`     | int      | Obrigatório, maior ou igual a 0             |
| `createAt`  | DateTime | Preenchido automaticamente na criação       |
| `updatedAt` | DateTime | Atualizado automaticamente a cada alteração |

> Os campos `id`, `createAt` e `updatedAt` são herdados de uma classe base (`BaseEntity`).

## 🚀 Endpoints

| Método | Endpoint          | Descrição                  | Respostas         |
|--------|-------------------|----------------------------|-------------------|
| POST   | `/api/books`      | Criar um novo livro        | 201, 400          |
| GET    | `/api/books`      | Listar todos os livros     | 200               |
| GET    | `/api/books/{id}` | Buscar um livro pelo ID    | 200, 404          |
| PUT    | `/api/books/{id}` | Atualizar um livro         | 204, 404          |
| DELETE | `/api/books/{id}` | Excluir um livro           | 204, 404          |

### Exemplo de criação (POST `/api/books`)

```json
{
  "title": "Dom Casmurro",
  "author": "Machado de Assis",
  "genre": "romance",
  "price": 39.90,
  "stock": 10
}
```

## 💻 Como rodar o projeto

Pré-requisitos: ter o [SDK do .NET](https://dotnet.microsoft.com/download) instalado.

1. Clone o repositório:
   ```bash
   git clone https://github.com/alisonfulldev/projeto1.net.git
   ```

2. Entre na pasta do projeto:
   ```bash
   cd Gerenciadordelivros
   ```

3. Rode a aplicação:
   ```bash
   dotnet run
   ```

4. Acesse a documentação do Swagger no navegador:
   ```
   https://localhost:PORTA/swagger
   ```
   > A porta exata aparece no terminal ao rodar o projeto.

## 📝 Observações

- Os dados são armazenados em memória, ou seja, são reiniciados sempre que a aplicação é encerrada. Não há banco de dados nesta versão.

## 📄 Licença

Projeto de estudo, livre para uso e aprendizado.
