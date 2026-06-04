# AGENTS.md

Guidelines for AI agents working in this repository.

## Project snapshot

- Stack: ASP.NET Core `net10.0`, C# `LangVersion 14`, Entity Framework Core, SQLite.
- Main app: `AspNetCoreAPI/`
- Test project: `AspNetCoreAPI.Test/`
- Entry point: `AspNetCoreAPI/Program.cs`
- API controller: `AspNetCoreAPI/Components/Controllers/PersonController.cs`
- Service layer: `AspNetCoreAPI/Services/`
- Data layer and models: `AspNetCoreAPI/Models/`

## Build, run, test

Run commands from repository root unless noted:

1. Build: `dotnet build`
2. Run app: `cd AspNetCoreAPI && dotnet run`
3. Run tests: `dotnet test`

## Database and migrations

- SQLite database file is `aspnetcoreapi.db`.
- App uses `AspNetCoreAPI/aspnetcoreapi.db`.
- Tests rely on `AspNetCoreAPI.Test/aspnetcoreapi.db`.
- After migration updates, ensure the test DB is refreshed from the app DB when needed.

## Coding conventions to follow

- Preserve the existing file header comment block in C# files.
- Use file-scoped namespaces (`namespace X;`) as in current code.
- Keep dependency injection registration in `Program.cs`.
- Keep routes lowercase and compatible with existing controller patterns.
- Prefer async EF Core APIs (`ToListAsync`, `SaveChangesAsync`, `FindAsync`, `CountAsync`).
- Keep logging explicit and structured where already used.
- Keep public API shapes backward-compatible unless explicitly asked to change.

## Change policy for agents

- Make focused, minimal changes for the requested task.
- Do not refactor unrelated code.
- Add or update tests when behavior changes.
- If changing models or persistence, consider migration impact and test DB parity.
- Never commit secrets or credentials.

## Definition of done

- Code builds successfully.
- Relevant tests pass.
- Any docs impacted by the change are updated.
- Changes are limited to the requested scope.
