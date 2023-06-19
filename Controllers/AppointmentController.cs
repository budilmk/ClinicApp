using ClinicApp.Entities;
using ClinicApp.Services;
using Microsoft.AspNetCore.Mvc;
using ClinicApp.Controllers.Dtos;

namespace ClinicApp.Controllers
{
    [Route("/appointments")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly ISlotService _slotService;

        public AppointmentController(IAppointmentService appointmentService, ISlotService slotService)
        {
            _appointmentService = appointmentService;
            _slotService = slotService;
        }



        [HttpPost("/appointments/book")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest request)
        {
            await _appointmentService.CreateAppointment(request.patientName, request.patientId, request.slotId);
            await _slotService.UpdateSlotReservation(true, request.slotId);

            return Ok("Appointment Created...");
        }

    }
}

