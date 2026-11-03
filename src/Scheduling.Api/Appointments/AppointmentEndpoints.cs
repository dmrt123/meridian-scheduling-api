using Scheduling.Api.Errors;

namespace Scheduling.Api.Appointments;

public sealed record Appointment(Guid Id, Guid TenantId, Guid ProviderId, Guid PatientRef, DateTimeOffset StartsAt, int Minutes);
public sealed record BookAppointment(Guid ProviderId, Guid PatientRef, DateTimeOffset StartsAt, int Minutes);

public static class AppointmentEndpoints
{
    public static void MapAppointmentEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/v1/appointments");

        group.MapGet("/{id:guid}", (Guid id, IAppointmentStore store, HttpContext context) =>
            store.Find(id) is { } appointment
                ? Results.Ok(appointment)
                : ApiError.Result(404, "APPOINTMENT_NOT_FOUND", "No appointment has that id.", context));

        group.MapPost("/", (BookAppointment request, IAppointmentStore store, ILogger<Appointment> logger, HttpContext context) =>
        {
            if (request.Minutes is < 5 or > 240)
                return ApiError.Result(400, "INVALID_LENGTH", "Appointments are 5 to 240 minutes long.", context);
            var appointment = store.Book(request);
            logger.LogInformation("Booked appointment {AppointmentId} ({CorrelationId})", appointment.Id, context.TraceIdentifier);
            return Results.Created($"/v1/appointments/{appointment.Id}", appointment);
        });
    }
}
