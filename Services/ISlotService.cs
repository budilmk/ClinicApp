using ClinicApp.Entities;

namespace ClinicApp.Services
{
    public interface ISlotService
    {
        public Task CreateSlot(string time, string doctorName, Guid doctorId, decimal cost);
        public Task DeleteSlot(Guid id);

        public Task <List<Slot>> GetSlotsByDoctor(string doctorName);
        public Task <List<Slot>> GetAllSlots();
        public Task <List<Slot>> GetAvailableSlots();
        public Task UpdateSlotReservation();

    }
}
