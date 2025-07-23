# Automação de Testes de API com RestSharp + xUnit

Este projeto é uma automação de testes para a API `https://jsonplaceholder.typicode.com/`, utilizando RestSharp e xUnit.

## Cenários Automatizados

1. **GET /posts/1**
   - Valida se a resposta tem status 200.
   - Valida a existência e tipo dos campos: `userId`, `id`, `title`, `body`.

2. **POST /posts**
   - Cria um post.
   - Valida se a resposta tem status 201 (Created).
   - Valida se os dados enviados foram retornados corretamente.

3. **DELETE /posts/1**
   - Envia um DELETE.
   - Valida que a resposta tem status 200 (mesmo sendo fake).

## Tecnologias

- .NET 9
- xUnit
- RestSharp
- Newtonsoft.Json

## Como rodar os testes

1. Instale o SDK do [.NET 6](https://dotnet.microsoft.com/download).
2. Clone este repositório:
   ```bash
   git clone https://github.com/Galeazi/AutomacaoAPIRestSharp.git
   cd AutomacaoAPIRestSharp
   
## Execute os testes:
dotnet test

## Estrutura de Pastas
AutomacaoAPIRestSharp/
├── Tests/
│   ├── Posts/
│   │   ├── GetPostTests.cs
│   │   ├── CreatePostTests.cs
│   │   └── DeletePostTests.cs

