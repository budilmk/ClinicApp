using ClinicApp.Entities;
using System;

namespace ClinicApp.Repositories
{
    public interface ISlotRepository
    {
        public bool SlotIdIsExist(Guid id);
        public Task Add(Slot slot);
        public Task Delete(Guid slotId);
        public Task ListSlot(string doctorName);
        public Task <List<Slot>> GetAll();
    }
}
