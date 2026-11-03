# Scheduling API

Books, reschedules and cancels appointments and serves provider availability for Meridian Care Cloud clinics.

Run it with `dotnet run --project src/Scheduling.Api`. Errors use the shared envelope in `Errors/ApiError.cs`.

## Endpoints

- `GET /v1/appointments/{id}`: one appointment, or `404 APPOINTMENT_NOT_FOUND`.
- `POST /v1/appointments`: book an appointment of 5 to 240 minutes, or `400 INVALID_LENGTH`.

Errors use the shared `{ error: { code, message, correlationId } }` envelope. TypeScript clients such as the Patient Portal can use the types in `clients/typescript/schedulingApi.ts`.
