# MyProject - Cadastro de Usuários

API de cadastro de usuários estruturada com **Clean Architecture**, **DDD** e princípios de **Arquitetura Hexagonal**.

## Arquitetura

```
├── Domain/              Núcleo do domínio (entidades, value objects, exceções, interfaces de repositório)
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Exceptions/
│   └── Repositories/
├── Application/         Casos de uso e DTOs
│   ├── UseCases/
│   ├── Interfaces/
│   └── DTOs/
├── Infrastructure/      Adaptadores externos (persistência, DI)
│   └── Repositories/
├── Controllers/         Camada de apresentação (API REST)
```

### Fluxo de Dependências

```
Controllers → Application → Domain ← Infrastructure
```

A camada de **Infrastructure** implementa as interfaces (ports) definidas no **Domain**, seguindo o padrão Ports & Adapters.

## Endpoints da API

### Usuário

- **POST /api/usuario** — Cadastra um novo usuário.

  ```json
  {
    "nome": "string",
    "cpf": "string",
    "rg": "string",
    "dataNascimento": "2025-06-25T00:00:00",
    "numeroTelefone": "string"
  }
  ```

  Retorno: `201 Created` com o usuário criado.

- **GET /api/usuario** — Lista todos os usuários.

  Retorno: `200 OK` com lista de usuários.

- **GET /api/usuario/{cpf}** — Busca usuário pelo CPF.

  Retorno: `200 OK` com o usuário ou `404 Not Found`.

- **PUT /api/usuario/{cpf}** — Atualiza dados de um usuário (CPF e RG não podem ser alterados).

  ```json
  {
    "nome": "string",
    "dataNascimento": "2025-06-25T00:00:00",
    "numeroTelefone": "string"
  }
  ```

  Retorno: `204 No Content` em sucesso ou `404 Not Found`.

## Tecnologias

- .NET Core 10.0
- Entity Framework Core 10.0
- Swagger (Swashbuckle) 7.3.1
