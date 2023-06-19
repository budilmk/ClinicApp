﻿using ClinicApp.Entities;
using ClinicApp.Repositories;
using ClinicApp.Services;
using Microsoft.Extensions.Hosting;

namespace ClinicApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepo _appointmentRepository;
        private readonly ISlotRepository _slotRepository;
        public AppointmentService(IAppointmentRepo appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        //question 2
        public async Task CreateAppointment(string patientName, Guid patientId, Guid slotId)
        {
            var appointment = new Appointment { Id = Guid.NewGuid(), SlotId = slotId, PatientName = patientName, PatientId = patientId, ReservedAt = DateTime.UtcNow, IsCompleted = false };
            await _appointmentRepository.Add(appointment);
        }

        public async Task AppointmentIsCompleted(bool status, Guid AppointmentId)
        {
            _appointmentRepository.AppointmentIsCompleted(status, AppointmentId);

        }

    }
}
