
# 🚀 API.NET — Gerenciamento de Motos e Pátios

API desenvolvida em ASP.NET Core com integração ao banco de dados Oracle, para cadastro e gerenciamento de Motos, Modelos e Pátios.

## 👥 Integrantes
- **Carlos Eduardo R C Pacheco** – RM: 557323
- **Pedro Augusto Costa Ladeira** – RM: 558514

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

## 🏗️ Justificativa da Arquitetura

O projeto segue a arquitetura **API RESTful com ASP.NET Core** com:

- **Entidades principais**: Motos, Modelos e Pátios
- **Padrão Repository**: Abstração da camada de dados
- **Controllers REST**: Endpoints com status codes adequados
- **Paginação**: Para listas grandes de dados
- **HATEOAS**: Links de navegação nos recursos
- **Swagger**: Documentação interativa automática

## 🚀 Instruções de Execução da API

### Pré-requisitos
- .NET 8.0 SDK ou superior
- Visual Studio ou VS Code

### Passos para execução
1. Clone o repositório:
```bash
git clone https://github.com/cadupacheco/Sprint-1-.NET.git
```

2. Restaure os pacotes:
```bash
dotnet restore
```

3. Execute a aplicação:
```bash
dotnet run
```

4. Acesse a documentação:
```
http://localhost:5221/swagger
```

## 📝 Exemplos de Uso dos Endpoints

### Criar uma Moto
**POST** `/api/moto`
```json
{
  "placa": "ABC-1234",
  "cor": "Vermelha",
  "modeloId": 1,
  "patioId": 1
}
```

### Listar Motos
**GET** `/api/moto?pageNumber=1&pageSize=10`

### Criar um Modelo
**POST** `/api/modelo`
```json
{
  "nome": "VMoto VS1",
  "fabricante": "VMoto"
}
```

### Criar um Pátio
**POST** `/api/patio`
```json
{
  "nome": "Pátio Central",
  "localizacao": "São Paulo - SP"
}
```

## 🧪 Comando para Rodar os Testes

```bash
dotnet test
```


