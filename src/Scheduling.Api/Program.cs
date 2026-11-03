using Scheduling.Api.Appointments;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IAppointmentStore, InMemoryAppointmentStore>();

var app = builder.Build();
app.MapAppointmentEndpoints();
app.Run();
