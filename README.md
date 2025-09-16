
# 🚀 API.NET — Gerenciamento de Motos e Pátios

API desenvolvida em ASP.NET Core com integração ao banco de dados Oracle, para cadastro e gerenciamento de Motos, Modelos e Pátios.

## 🔗 Rotas da API

### 🔹 Moto
- GET `/api/moto` → Lista todas as motos
- GET `/api/moto/{id}` → Busca uma moto por ID
- POST `/api/moto` → Cria uma moto
- PUT `/api/moto/{id}` → Atualiza uma moto
- DELETE `/api/moto/{id}` → Remove uma moto

### 🔹 Modelo
- GET `/api/modelo` → Lista todos os modelos
- GET `/api/modelo/{id}` → Busca um modelo por ID
- POST `/api/modelo` → Cria um modelo
- PUT `/api/modelo/{id}` → Atualiza um modelo
- DELETE `/api/modelo/{id}` → Remove um modelo

### 🔹 Pátio
- GET `/api/patio` → Lista todos os pátios
- GET `/api/patio/{id}` → Busca um pátio por ID
- POST `/api/patio` → Cria um pátio
- PUT `/api/patio/{id}` → Atualiza um pátio
- DELETE `/api/patio/{id}` → Remove um pátio

## 🛠️ Tecnologias

- ASP.NET Core
- C#
- Entity Framework Core
- Oracle Database
- Swagger (OpenAPI)

# API .NET - Sprint 1

## Integrantes
- Cadu Pacheco
- [Adicionar demais integrantes aqui]

---

## Justificativa da Arquitetura

O projeto segue a arquitetura **API RESTful com ASP.NET Core** com os seguintes pontos principais:

- **Entidades principais**: Produtos, Usuários, Pedidos  
  Essas entidades representam o domínio do sistema e permitem gerenciar o ciclo completo de pedidos, clientes e catálogo de produtos.
- **Camada de Persistência**: Entity Framework Core (EF Core) com suporte a Oracle ou SQLite, facilitando operações CRUD e integração com o banco.
- **Controllers e Endpoints REST**: Seguindo boas práticas REST, incluindo:
  - Paginação
  - Status codes adequados (200, 201, 404, 400)
  - HATEOAS (links de navegação nos recursos)
- **Swagger/OpenAPI**: Documentação interativa com exemplos de payloads e modelos de dados.
- **Program.cs** configurado para redirecionar a raiz `/` para Swagger.

---

## Instruções de Execução da API

### Pré-requisitos
- .NET SDK 9.x (ou compatível com os pacotes EF Core instalados)
- Banco de dados Oracle ou SQLite
- Git (opcional, para clonar o repositório)

### Passos para rodar
1. Clone o repositório:
```bash
git clone https://github.com/cadupacheco/Sprint-1-.NET.git
cd Sprint-1-.NET
```

2. Restaurar pacotes NuGet:
```bash
dotnet restore
```

3. Buildar o projeto:
```bash
dotnet build
```

4. Executar a API:
```bash
dotnet run
```

5. Acesse a documentação Swagger no navegador:
```
http://localhost:5000/swagger
```
ou, se estiver usando HTTPS:
```
https://localhost:7000/swagger
```

---

## Endpoints Detalhados

### Produtos
| Método | Endpoint | Descrição | Exemplo de Request | Exemplo de Response |
|--------|----------|-----------|-----------------|------------------|
| GET    | /api/produtos | Lista produtos paginados | - | 200 OK, JSON array |
| GET    | /api/produtos/{id} | Retorna produto por ID | - | 200 OK, JSON produto |
| POST   | /api/produtos | Cria um novo produto | `{ "nome": "Chocolate", "descricao": "Meio amargo", "preco": 10.50 }` | 201 Created, JSON produto criado |
| PUT    | /api/produtos/{id} | Atualiza produto | `{ "nome": "Chocolate", "descricao": "Amargo", "preco": 12.00 }` | 200 OK, JSON produto atualizado |
| DELETE | /api/produtos/{id} | Remove produto | - | 204 No Content |

### Usuários
| Método | Endpoint | Descrição | Exemplo de Request | Exemplo de Response |
|--------|----------|-----------|-----------------|------------------|
| GET    | /api/usuarios | Lista usuários paginados | - | 200 OK, JSON array |
| GET    | /api/usuarios/{id} | Retorna usuário por ID | - | 200 OK, JSON usuário |
| POST   | /api/usuarios | Cria um novo usuário | `{ "nome": "Cadu", "email": "cadu@example.com" }` | 201 Created, JSON usuário criado |
| PUT    | /api/usuarios/{id} | Atualiza usuário | `{ "nome": "Cadu P.", "email": "cadu@example.com" }` | 200 OK, JSON usuário atualizado |
| DELETE | /api/usuarios/{id} | Remove usuário | - | 204 No Content |

### Pedidos
| Método | Endpoint | Descrição | Exemplo de Request | Exemplo de Response |
|--------|----------|-----------|-----------------|------------------|
| GET    | /api/pedidos | Lista pedidos paginados | - | 200 OK, JSON array |
| GET    | /api/pedidos/{id} | Retorna pedido por ID | - | 200 OK, JSON pedido |
| POST   | /api/pedidos | Cria um novo pedido | `{ "usuarioId": 1, "produtoId": 2, "quantidade": 3 }` | 201 Created, JSON pedido criado |
| PUT    | /api/pedidos/{id} | Atualiza pedido | `{ "quantidade": 5 }` | 200 OK, JSON pedido atualizado |
| DELETE | /api/pedidos/{id} | Remove pedido | - | 204 No Content |

> Todos os endpoints retornam HATEOAS links quando aplicável.

---

## Comando para Rodar os Testes

Se você tiver testes implementados, rode:
```bash
dotnet test
```
Isso executará todos os testes automatizados do projeto.

---

## Observações
- A API está preparada para múltiplos ambientes (desenvolvimento e produção) via `appsettings.json`.
- Para ajustar o banco de dados, altere a connection string em `appsettings.json`.
- Recomendamos sempre usar Swagger para testar os endpoints e verificar exemplos de payload.


## 👨‍💻 Desenvolvedores
-Carlos Eduardo R C Pacheco – RM: 557323

-Pedro Augusto Costa Ladeira – RM: 558514
