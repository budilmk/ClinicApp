namespace ClinicApp.Controllers.Dtos
{
    public class CreateSlotRequest
    {
        public string? time { get; set; }
        public string? doctorName { get; set; }
        public decimal cost { get; set; }

    }
}

