using System.ComponentModel.DataAnnotations;

namespace ClinicApp.Entities
{
    public class Slot
    {
        [Key] public Guid Id { get; set; }
        public string? Time { get; set; }
        public Guid DoctorId { get; set; }
        [Key] public string? DoctorName { get; set; }
        public bool? IsReserved { get; set; }
        public decimal? Cost { get; set; }

    }
}
