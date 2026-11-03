# Contributing to Scheduling API

- .NET 8 (C#) ASP.NET Core minimal APIs (`src/Scheduling.Api`). Run with `dotnet run --project src/Scheduling.Api`.
- Every error returns the shared envelope `{ error: { code, message, correlationId } }` with a stable UPPER_SNAKE code (see `Errors/ApiError.cs`). Never return raw exception text.
- Use `context.TraceIdentifier` as the correlationId and log it via `ILogger` structured fields.
- Never log patient names, dates of birth, member numbers or visit notes; log identifiers (e.g. AppointmentId) instead.
- Keep `clients/typescript/schedulingApi.ts` in sync with the C# records it mirrors.
- New endpoints need request validation, an OpenAPI description and an integration test.
- Ship clinic workflow changes behind a feature flag.
- Use the de-identified fixtures in the shared test-data package for tests and local dev; never paste real patient data into code, tickets or AI tools.
- PR titles: `type(scope): summary`. Link the ticket and state the risk and rollback plan; include tests.
- Release notes are written for clinic administrators: lead with what changes for them, avoid internal service names.
