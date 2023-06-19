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

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAppointmentRequest request)
        {
            await _appointmentService.CreateAppointment(request.patientName, request.patientId, request.slotid);
            return Ok("Appointment Created...");
        }

    }
}

