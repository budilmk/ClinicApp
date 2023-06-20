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


        //Question 2b TO book an appointment on a free slot
        [HttpPost("/appointments/book")]
        public async Task<IActionResult> CreateAppointment([FromBody] CreateAppointmentRequest request)
        {
            await _appointmentService.CreateAppointment(request.patientName, request.patientId, request.slotId); //create new appointment
            await _slotService.UpdateSlotReservation(true, request.slotId); //update slot status to true

            return Ok("Appointment Created...");
        }

        //Question 3b TO mark an appointment as completed
        [HttpPost("/appointments/iscomplete")]
        public async Task<IActionResult> AppointmentUpdate([FromBody] AppointmentUpdateRequest request)
        {
            await _appointmentService.AppointmentIsCompleted(request.isCompleted, request.id); //Mark appointment as completed
            return Ok("Appointment Updated...");
        }

        //Question 3a TO get next appointment, check all next reserved slots
        [HttpPost("/appointments/nextappointment")]
        public async Task<IActionResult> NextAppointment([FromBody] NextAppointmentRequest request)
        {
            
            return Ok(_appointmentService.GetNextAppointment(request.doctorName)); 
        }

        //Question 3a TO get multiple next appointment, check all next reserved slots
        [HttpPost("/appointments/nextappointments")]
        public async Task<IActionResult> NextAppointments([FromBody] NextAppointmentsRequest request)
        {
            return Ok(_appointmentService.GetNextAppointments(request.doctorName));
        }

        //Question 3b To cancel appointment and delete
        [HttpPost("/appointments/cancel")]
        public async Task<IActionResult> CancelAppointment([FromBody] CancelAppointmentRequest request)
        {
            await _appointmentService.CancelAppointment(request.appointmentId);
            return Ok("Appointment cancelled...");

        }

    }
}


