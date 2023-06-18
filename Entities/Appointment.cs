using System.ComponentModel.DataAnnotations;

namespace ClinicApp.Entities
{
    public class Appointment
    {
        [Key] public Guid Id { get; set; }
        [Key] public Guid SlotId { get; set; }
        public Guid PatientId { get; set; }
        public string? PatientName { get; set; }
        public DateTime ReservedAt { get; set; }
        public bool IsCompleted { get; set; }

    }
}
