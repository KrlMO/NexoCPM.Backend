# AGENTS.md - NexoCPM.Backend

## Architecture
Clean Architecture .NET 10.0 solution with 5 projects:
- `NexoCPM.Backend/` - API entrypoint (web project)
- `NexoCPM.Application/` - CQRS layer using MediatR
- `NexoCPM.Domain/` - Domain entities and exceptions
- `NexoCPM.Infraestructure/` - Auth (JWT, BCrypt), external services
- `NexoCPM.Persistence/` - EF Core with SQL Server

Dependency flow: Api → Infrastructure + Persistence → Application → Domain

## Commands
```bash
# Build solution
dotnet build

# Run API (default: http://localhost:5149)
dotnet run --project NexoCPM.Backend/NexoCPM.Api.csproj

# EF Core migrations (run from Persistence project)
dotnet ef migrations add <Name> --project NexoCPM.Persistence --startup-project NexoCPM.Backend
dotnet ef database update --project NexoCPM.Persistence --startup-project NexoCPM.Backend
```

## Key Conventions
- MediatR handlers auto-registered from `LoginHandler` assembly (`Program.cs:12`)
- API versioning: v1.0 default (`Microsoft.AspNetCore.Mvc.Versioning`)
- Custom exception handling middleware in `Program.cs` (DomainException → status code)
- CORS allows Angular dev server at `https://localhost:4200`
- JWT secret in `appsettings.json` (dev only, rotation needed for prod)

## Database
- SQL Server with Trusted_Connection on localhost
- Connection string: `Server=localhost;Database=NexoCPMdb;Trusted_Connection=True`
- Migrations in `NexoCPM.Persistence/Migrations/`

## Gotchas
- No test projects in solution (no `dotnet test` targets)
- No `.editorconfig` or CI workflows present
- .NET 10.0 requires SDK 10.0.202+
- `NexoCPM.Infraestructure` (note spelling) not "Infrastructure"
