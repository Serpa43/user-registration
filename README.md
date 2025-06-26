# MyProject

Estrutura baseada em Clean Architecture + DDD para .NET.

- **Domain**: Entidades, ValueObjects, Aggregates, Repositories (interfaces)
- **Application**: Casos de uso, DTOs, Interfaces de serviços
- **Infrastructure**: Implementações de repositórios, serviços externos, Migrations
- **Presentation**: APIs, Controllers, ViewModels

Siga as melhores práticas de Clean Architecture e DDD.

---

## Endpoints da API

Todos os endpoints seguem o padrão RESTful e estão organizados na camada Presentation, que depende apenas das camadas Application e Domain, respeitando os princípios da Clean Architecture e DDD.

### Usuário

- **POST /api/usuario**
  - Cadastra um novo usuário.
  - Corpo (JSON):
    ```json
    {
      "nome": "string",
      "cpf": "string",
      "rg": "string",
      "dataNascimento": "2025-06-25T00:00:00",
      "numeroTelefone": "string"
    }
    ```
  - Retorno: Usuário criado.

- **GET /api/usuario**
  - Lista todos os usuários cadastrados.
  - Retorno: Lista de usuários.

- **POST /api/usuario/usuarioCpf**
  - Busca usuário pelo CPF.
  - Corpo (JSON):
    ```json
    {
      "cpf": "string"
    }
    ```
  - Retorno: Usuário correspondente ou 404 se não encontrado.

- **PUT /api/usuario/{cpf}**
  - Atualiza os dados de um usuário identificado pelo CPF.
  - Parâmetro de rota: `cpf` (string)
  - Corpo (JSON):
    ```json
    {
      "nome": "string",
      "dataNascimento": "2025-06-25T00:00:00",
      "numeroTelefone": "string"
    }
    ```
  - Observação: Não é permitido alterar o CPF ou RG.
  - Retorno: 204 No Content em caso de sucesso, 404 se não encontrado.

---

## Sobre Clean Architecture e DDD

Este projeto foi estruturado seguindo os princípios da Clean Architecture e Domain-Driven Design (DDD):

- **Separação de responsabilidades:**
  - Cada camada tem uma responsabilidade clara e depende apenas das camadas mais internas.
- **Domain:** Contém as regras de negócio, entidades e interfaces de repositórios.
- **Application:** Implementa os casos de uso e orquestra as operações de negócio.
- **Infrastructure:** Implementa detalhes de persistência e integrações externas.
- **Presentation:** Expõe a API e lida com a entrada/saída de dados.

Essa abordagem facilita testes, manutenção, evolução e desacoplamento do domínio de regras de negócio das tecnologias externas.
