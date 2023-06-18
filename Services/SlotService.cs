using ClinicApp.Entities;
using ClinicApp.Services;
namespace ClinicApp
    .Services
{
    public class SlotService : ISlotService
    {
        public async Task CreateSlot(string time, string doctorName, decimal cost)
        {
            if (string.IsNullOrEmpty(doctorName))
            {

            }

        }

        public Task DeleteSlot(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task ListSlot(string doctorName)
        {
            throw new NotImplementedException();
        }
    }
}
