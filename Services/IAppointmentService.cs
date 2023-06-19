using ClinicApp.Repositories;

namespace ClinicApp.Services
{
    public interface IAppointmentService
    {
        public Task CreateAppointment(string patientName, Guid patientId, Guid slotId);

        public Task AppointmentIsCompleted(bool status, Guid ApplicationId);

    }
}

