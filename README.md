# DeskFlow - Sistema de Gestão  de Chamados e Helpdesk

[[README#Sobre]]
[[README#Mapa do Projeto]]
[[README#Utilização]]
[[README#Modelos e Ciclo de Vida]]
[[README#Tecnologias Usadas e Dependencias]]

## Sobre

Este é um sistema web para criação e gerenciamento de chamados de suporte via tickets.

O sistema possui rastreamento de chamados via prioridade, listagem por filtros, categorias de chamados e histórico de interações.

## Mapa do Projeto

```language
.
├── AppDbContext.cs
├── appsettings.Development.json
├── appsettings.json
├── DeskFlow.csproj
├── DeskFlow.http
├── Migrations
│
├── Properties
│   └── launchSettings.json
│
├─ README.md
├── Program.cs
│
├── Config
│   └── ErroMiddleware.cs
│
├── Controllers
│   ├── CategoriaController.cs
│   ├── ChamadoController.cs
│   └── PingController.cs
│
├── Models
│   ├── DTOs
│   │   ├── CategoriaDetalhesDto.cs
│   │   ├── CategoriaDto.cs
│   │   ├── CategoriaListadoDto.cs
│   │   ├── ChamadoDetalhesDto.cs
│   │   ├── ChamadoDto.cs
│   │   ├── ChamadoFiltroDto.cs
│   │   ├── ChamadoListaDto.cs
│   │   ├── EncerrarChamadoDto.cs
│   │   └── InteracaoDto.cs
│   │
│   └── Entities
│       ├── Categoria.cs
│       ├── Chamado.cs
│       └── Interacao.cs
│
├── Repositories
│   ├── CategoriaRepository.cs
│   ├── ChamadoRepository.cs
│   └── Interfaces
│       ├── ICategoriaRepository.cs
│       ├── IChamadoRepository.cs
│       └── IRepository.cs
│
└── Services
    ├── CategoriaService.cs
    ├── ChamadoService.cs
    └── Interfaces
        ├── ICategoriaService.cs
        └── IChamadoService.cs
```

## Utilização

Primeiramente clone o projeto:

```bash
git clone <este-repositorio>
cd <este-repositorio>
```

Configure a connection string em appsettings.json ou appsettings.Development.json (veja no mapa do sistema acima, o segundo é utilizado em ambiente de desenvolvimento):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost,1433;User=(Usuario SQL Server);Password=(Senha SQL Server);TrustServerCertificate=True;"
  }
}
```

Em seguida, aplique o esquema do projeto no banco e rode o projeto:
```bash
dotnet ef database update
dotnet run
```

Após isso, vai ficar disponivel no endereço http://localhost:5211/swagger/index.html uma página que mostra todos os endpoints do projeto.

Todo endpoint do sistema esta atrás de http://localhost:5211/api, e a porta `5211` é configuravel em ./Properties/launchSettings.json em "http".

Para realizar requisições HTTP, você vai precisar de um cliente HTTP, como os abaixo:

- [Postman](https://www.postman.com/)
- [posting](https://github.com/darrenburns/posting)
- [Insomnia](https://insomnia.rest/)
- [Bruno](https://www.usebruno.com/) (Recomendado)

## Modelos e Ciclo de Vida

Existem 3 modelos no projeto:

- Chamado: o ticket de suporte
- Categoria: a categoria do ticket. Possui uma relação 1:N com Chamado
- Interacao: comentários de suporte. Possui relação N:1 com Chamado

Além disso, Chamado tem um cíclo de vida seguindo o enum ChamadoStatus no arquivo Chamado.cs. Esse status é atualizado em Services/ChamadoService.cs, IniciarChamadoComIdAsync e EncerrarChamadoAsync.

Por fim, há 3 "tipos" principais de DTO:

- Padrão: utilizada principalmente para criação e atualização de entidades
- Detalhes: mostram informações detalhadas sobre a entidade no banco
- Lista: mostram a informação mais minimamente densa quanto possivel da entidade, utilizada principalmente para evitar problemas de referência circular

## Tecnologias Usadas e Dependencias

- .NET 10
- ASP.NET 10
- Sql Server 2025
- Entity Framework Core 10
- Swagger & OpenAPI
