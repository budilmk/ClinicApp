using ClinicApp.Entities;
using ClinicApp.Repositories;
using ClinicApp.Services;
namespace ClinicApp
    .Services
{
    public class SlotService : ISlotService
    {
        private readonly ISlotRepository _slotRepository;
        public SlotService(ISlotRepository slotRepository)
        {
            _slotRepository = slotRepository;
        }
        public async Task CreateSlot(string time, string doctorName, Guid doctorId, decimal cost)
        {
            if (string.IsNullOrEmpty(doctorName))
            {

            }

            var slot = new Slot { Id = Guid.NewGuid(), Time = time, DoctorId = doctorId, DoctorName = doctorName, Cost = cost, IsReserved = false };
            await _slotRepository.Add(slot);

        }

        public Task DeleteSlot(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task <List<Slot>> Get(string? doctorName)
        {

            return await _slotRepository.GetAll();

            throw new NotImplementedException();
        }

        public Task ListSlot(string doctorName)
        {
            throw new NotImplementedException();
        }

        public Task GetAvailableSlots()
        {
            throw new NotImplementedException();
        }

    }
}
