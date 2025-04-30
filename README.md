
# Bookstore Management API

API RESTful desenvolvida com ASP.NET Core para gerenciamento de uma livraria online. O projeto tem como objetivo fornecer funcionalidades essenciais para controle de acervo, permitindo operações de criação, leitura, atualização e exclusão (CRUD) de livros de forma eficiente.

## 🚀 Tecnologias Utilizadas

- ASP.NET Core
- Dapper (Micro ORM)
- SQL Server
- .NET 8
- RESTful APIs

## 📚 Funcionalidades

- [x] Cadastro de novos livros
- [x] Listagem de todos os livros
- [ ] Consulta por livro específico
- [ ] Atualização de informações de livros
- [ ] Remoção de livros do catálogo

## 📦 Estrutura do Projeto

```
BookstoreManagement/
├── Controllers/
├── Models/
├── Program.cs
├── appsettings.json
└── BookstoreManagement.csproj
```

## 🛠 Como Executar Localmente

1. Clone o repositório:
```bash
git clone https://github.com/EletherioAlexandre/BookstoreManagement.git
```

2. Navegue até a pasta do projeto:
```bash
cd BookstoreManagement
```

3. Restaure as dependências:
```bash
dotnet restore
```

4. Execute a aplicação:
```bash
dotnet run
```

5. Acesse no navegador (por padrão):
```
https://localhost:5001/swagger
```

## ✅ Requisitos

- .NET SDK 8.0+
- SQL Server

## 🧠 Sobre o Projeto

Este projeto foi criado com o propósito de consolidar conhecimentos em desenvolvimento backend com ASP.NET Core, focando em uma arquitetura simples, uso do micro ORM Dapper e boas práticas de criação de APIs RESTful.

## 🤝 Contribuições

Contribuições são bem-vindas!  
Sinta-se à vontade para abrir issues ou pull requests com sugestões, melhorias ou correções.

---

Desenvolvido por [Alexandre Eletherio](https://www.linkedin.com/in/alexandre-eletherio-ab799719a)
