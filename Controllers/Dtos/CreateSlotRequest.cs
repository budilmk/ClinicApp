namespace ClinicApp.Controllers.Dtos
{
    public class CreateSlotRequest
    {
        public string? time { get; set; }
        public string? doctorName { get; set; }
        public Guid doctorId { get; set; }
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

    public class CreateAppointmentRequest
    {
        public string? patientName { get; set; }
        public Guid slotid { get; set; }
        public Guid patientId { get; set; }

    }

}

