using ClinicApp.Entities;

namespace ClinicApp.Services
{
    public interface ISlotService
    {
        public Task CreateSlot(string time, string doctorName, Guid doctorId, decimal cost);
        public Task DeleteSlot(Guid id);
        public Task ListSlot(string doctorName);

        public Task <List<Slot>> Get(string doctorName);
        public Task GetAvailableSlots();

    }
}
