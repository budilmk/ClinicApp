namespace ClinicApp.Services
{
    public interface ISlotService
    {
        public Task CreateSlot(string schedule, string doctorName, decimal cost);
        public Task DeleteSlot(Guid id);
        public Task ListSlot(string doctorName);

    }
}
