namespace ClinicApp.Services
{
    public interface IAppointmentService
    {
        public Task GetAvailableSlots();
        public Task CreateAppointment(string patientName, Guid patientId, Guid slotId);
    }
}

