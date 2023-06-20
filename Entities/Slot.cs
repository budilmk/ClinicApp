﻿using System.ComponentModel.DataAnnotations;

namespace ClinicApp.Entities
{
    public class Slot
    {
        [Key] public Guid Id { get; set; }
        public DateTime Time { get; set; }
        public Guid DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public bool? IsReserved { get; set; }
        public decimal? Cost { get; set; }

    }
}
