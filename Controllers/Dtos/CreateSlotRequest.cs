namespace ClinicApp.Controllers.Dtos
{
    public class CreateSlotRequest
    {
        public string? time { get; set; }
        public string? doctorName { get; set; }
        public decimal cost { get; set; }

    }

    public class DeleteSlotRequest
    {
        public Guid slotid { get; set; }

    }

    public class ListSlotRequest
    {
        public string doctorName { get; set; }

    }
}

