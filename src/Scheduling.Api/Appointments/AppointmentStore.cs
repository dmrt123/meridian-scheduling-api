namespace Scheduling.Api.Appointments;

public interface IAppointmentStore
{
    Appointment? Find(Guid id);
    Appointment Book(BookAppointment request);
}

public sealed class InMemoryAppointmentStore : IAppointmentStore
{
    private readonly Dictionary<Guid, Appointment> _appointments = new();
    private readonly Guid _tenantId = Guid.NewGuid();

    public Appointment? Find(Guid id) => _appointments.GetValueOrDefault(id);

    public Appointment Book(BookAppointment request)
    {
        var appointment = new Appointment(Guid.NewGuid(), _tenantId, request.ProviderId, request.PatientRef, request.StartsAt, request.Minutes);
        _appointments[appointment.Id] = appointment;
        return appointment;
    }
}
