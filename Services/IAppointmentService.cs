namespace ClinicApp.Services
{
    public interface IAppointmentService
    {
        public Task GetAvailableSlots();
        public Task BookSlot(Guid slotId);
    }
}

