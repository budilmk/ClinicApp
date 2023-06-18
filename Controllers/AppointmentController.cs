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

    }
}

