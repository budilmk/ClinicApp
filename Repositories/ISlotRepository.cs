using ClinicApp.Entities;
using System;

namespace ClinicApp.Repositories
{
    public interface ISlotRepository
    {
        public bool SlotIdIsExist(Guid id);
        public Task Add(Slot slot);
        public Task Delete(Guid slotId);
        public Task <List<Slot>> ListSlotByDoctor(string doctorName);
        public Task <List<Slot>> ListAllSlots();
        public Task<List<Slot>> ListAvailableSlots();
        public Task UpdateSlotReservation(bool isReserved, Guid slotId);    
    }
}
