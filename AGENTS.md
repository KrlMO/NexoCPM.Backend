# AGENTS.md

## Tech Stack
- **Framework:** .NET 10.0 (Core)
- **Architecture:** Clean Architecture (Domain, Application, Infrastructure, Persistence, Api)
- **Patterns:** CQRS with MediatR, Repository/Port Pattern
- **Database:** EF Core 10 with SQL Server (LocalDB: `NexoCPMDb`)

## Project Structure
- `NexoCPM.Domain`: Entities, enums, and domain exceptions. No external dependencies.
- `NexoCPM.Application`: CQRS Handlers, DTOs, and Port Interfaces. Depends on `Domain`.
- `NexoCPM.Persistence`: `ApplicationDbContext`, EF Configurations, and Repository implementations. Depends on `Application`.
- `NexoCPM.Infraestructure`: External service implementations (JWT, Security). Depends on `Application`.
- `NexoCPM.Backend` (Api): Controllers, Middleware, and API setup. Entry point.

## Essential Commands
- **Build:** `dotnet build`
- **Run API:** `dotnet run --project NexoCPM.Backend`
- **EF Migrations** (Run from root):
  - Add: `dotnet ef migrations add <Name> --project NexoCPM.Persistence --startup-project NexoCPM.Backend`
  - Update: `dotnet ef database update --project NexoCPM.Persistence --startup-project NexoCPM.Backend`

## Key Conventions
- **CQRS:** Features are organized in `NexoCPM.Application`. New logic should be a Command/Query + Handler.
- **Dependency Injection:** Register services in the local `DependencyInjection.cs` file of each project.
- **EF Configs:** Use `IEntityTypeConfiguration<T>` in `NexoCPM.Persistence/Configurations`. They are auto-registered.
- **API Versioning:** Standard is versioned via URL/Header (Default 1.0).
- **Global Settings:** `Nullable` and `ImplicitUsings` are enabled across all projects.

## Common Pitfalls
- **Migrations:** Commands WILL fail if `--project` and `--startup-project` are omitted.
- **Layers:** Do not leak Persistence or Infrastructure details into the Application layer. Use Interfaces (Ports).
- **Context:** Use `IApplicationDbContext` for DB access within the Application layer instead of the concrete class.

## Investigation Guidance
- **High-Value Sources:** `README*`, root manifests, workspace config, lockfiles, build/test/lint/formatter/typecheck/codegen config, CI workflows, pre-commit/task runner config, existing instruction files (`AGENTS.md`, `CLAUDE.md`, `.cursor/rules/`, `.cursorrules`, `.github/copilot-instructions.md`), repo-local OpenCode config (`opencode.json`).
- **Architecture Clarity:** If architecture is unclear, inspect representative code files for entrypoints, package boundaries, and execution flow. Prioritize wiring files over random leaf files.
- **Source of Truth:** Prefer executable sources (config, scripts) over prose. Trust executables if docs conflict.

## Extraction Guidance
- **High-Signal Facts:** Exact developer commands (especially non-obvious ones), single test/package execution, command order (e.g., `lint -> typecheck -> test`), monorepo/multi-package boundaries, ownership of major directories, app/library entrypoints, framework/toolchain quirks (generated code, migrations, codegen, build artifacts, env loading, dev servers, infra deploy flow), repo-specific style/workflow conventions, testing quirks (fixtures, integration test prerequisites, snapshot workflows, required services, flaky/expensive suites), important constraints from existing instruction files.

## Questions
- **When to Ask:** Only ask if the repo cannot answer important information (undocumented conventions, branch/PR/release expectations, missing setup/test prerequisites).
- **When NOT to Ask:** Do not ask about anything the repo makes clear.

## Writing Rules
- **Include:** High-signal, repo-specific guidance (exact commands, architecture notes, differing conventions, setup requirements, env quirks, operational gotchas, references to critical instruction sources).
- **Exclude:** Generic advice, long tutorials, obvious conventions, speculative claims, unverifiable info, content for `opencode.json`.
- **Formatting:** Prefer short sections and bullets. Keep the file simple if the repo is simple; summarize structural facts for large repos.
