# ModularMonolith.Template

![Visitors](https://img.shields.io/badge/visitors-40_total-brightgreen)
![Clones](https://img.shields.io/badge/clones-13_total_10_unique-blue) <!--CLONE-BADGE-->

A **Modular Monolith** template built with **.NET 9** and clean DDD principles. It enables dynamic module loading, strong separation of concerns, and comes with batteries-included features like JWT authentication, rate limiting, Serilog logging, and health checks.

---

## 📌 Description

This template is designed for developers building scalable, maintainable modular monolithic systems using Domain-Driven Design (DDD). Each module (like `Auth`, `Users`) is independently structured, dynamically discovered, and injected into the main API host at runtime. The infrastructure is Docker-ready and supports multiple database backends (SQLite, PostgreSQL, MSSQL).

<a href='https://ko-fi.com/F1F82YR41' target='_blank'><img height='36' style='border:0px;height:36px;' src='https://storage.ko-fi.com/cdn/kofi6.png?v=6' border='0' alt='Buy Me a Coffee at ko-fi.com' /></a>

---

## ✨ Features

- ✅ .NET 9 and C# 13 support
- ✅ Clean DDD structure (Application / Domain / Infra / API)
- ✅ Modular architecture with dynamic module & entity loader
- ✅ Modular project isolation with independent build output
- ✅ Built-in JWT authentication and refresh tokens
- ✅ Serilog logging with file output
- ✅ Centralized exception handling middleware
- ✅ Global unified API response structure
- ✅ Rate limiting middleware
- ✅ Swagger (OpenAPI) UI with modular integration
- ✅ Health check endpoint
- ✅ Docker-ready with multi-database support (SQLite / PostgreSQL / MSSQL)
- ✅ API versioning
- ✅ Unit and integration testing structure

---

## 📂 Folder Highlights

```text
src/
├── ModularMonolith.Template.Api            # Main API host
│   ├── Middleware/                         # Global middlewares like exception handling
│   ├── Modules/                            # IModule interface for dynamic discovery
│   ├── appsettings.*.json                  # Environment-specific configuration
│   └── Program.cs                          # Startup logic that loads all module APIs dynamically
├── ModularMonolith.Template.Config         # Configuration layer (DbContext, loaders, DB factory)
│   ├── DbContext/                          # AppDbContext with modular-aware setup
│   ├── Factory/                            # DatabaseFactory for runtime database switching
│   └── Loader/                             # Module API and entity registration loaders
├── ModularMonolith.Template.Infra          # Cross-cutting concerns (logging, infrastructure)
│   └── Logging/                            # Serilog configurator and logger service
├── Modules/                                # All business feature modules go here
│   ├── Auth/                               # Authentication & Authorization bounded context
│   │   ├── Application/                    # Auth use cases, DTOs, services
│   │   ├── Domain/                         # Domain contracts and logic
│   │   ├── Infra/                          # External provider integrations (Google, Facebook)
│   │   └── API/                            # AuthController, modular API startup
│   ├── Users/                              # User management bounded context
│   │   ├── Application/                    # User DTOs, services, facades
│   │   ├── Domain/                         # Entities and repository interfaces
│   │   ├── Infra/                          # Entity configurations and repository implementation
│   │   └── API/                            # UserController, modular API startup
│   └── SharedKernel/                       # Shared DTOs, exceptions, helpers, JWT models
tests/
├── IntegrationTests/                       # End-to-end API integration tests
├── Common/                                 # Test data generators and shared helpers
└── ModularApiFactory.cs                    # Custom WebApplicationFactory for modular testing
```

## 🧪 Running Tests

```bash
# Run all unit and integration tests
dotnet test ./tests/ModularMonolith.Template.Application.Tests.csproj
```

## 🚀 How to Run

⚠️ Before running the main API, make sure all module APIs are built at least once so that their DLLs are available for dynamic loading.

```bash
# Step 1: Build all modules first
dotnet build ./src/Modules/*/*.csproj

# Step 2: Run main API
dotnet run --project ./src/ModularMonolith.Template.Api/ModularMonolith.Template.Api.csproj
```

Or using Docker Compose:

```bash
# For SQLite (default)
docker-compose -f docker-compose.sqlite.yml up --build

# For PostgreSQL
docker-compose -f docker-compose.postgres.yml up --build

# For MSSQL
docker-compose -f docker-compose.mssql.yml up --build
```

API will be available at: http://localhost:8080
Swagger UI: http://localhost:8080/swagger/index.html

## 📦 Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/en-us/)
- [Docker](https://www.docker.com/) (required for database containers)

## 🏛 Architecture Overview

This project uses a Modular Monolith structure with DDD principles, where:

- `API` is the main entry point hosting all modules.
- Each `Module` has its own `Application`, `Domain`, `Infra`, and `API`.
- Modules are discovered dynamically using reflection during startup.
- All modules register services/entities via standard interfaces:
    - `IModule` for DI registration
    - `IEntityTypeConfiguration<T>` for EF Core schema registration
- `Config` handles DbContext, dynamic loader, and DB factory abstraction.
- `Infra` contains logging infrastructure (Serilog).

## 🛠 Customize the Template
Create a new module under src/Modules/[YourModuleName]

1. Follow the same structure:
2. Application, Domain, Infra, API
3. Implement IModule and EntityTypeConfiguration to wire it up.
4. Build the new module at least once:

```bash
dotnet build ./src/Modules/YourModule/API/YourModule.API.csproj
```

5. Then run the main API project to automatically discover it.

## 📝 Other Notes

- Log files are saved in src/ModularMonolith.Template.Api/logs/
- Default DB is SQLite. You can switch to PostgreSQL or MSSQL via corresponding docker-compose file.
- Health check endpoint: GET /health
- JWT endpoints (Auth module): /api/v1/auth/login, /refresh, /register
- Responses follow a standard format with status, message, and data.

## 💬 Stay in touch

- Author - [Da-Wei Lin](https://www.linkedin.com/in/da-wei-lin-689a35107/)
- Website - [David Weblog](https://davidskyspace.com/)
- [MIT LICENSE](https://github.com/deadislove/dotnet-ModularMonolith-template/blob/main/LICENSE)

## Reference

- [Integration tests in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-9.0&pivots=xunit)