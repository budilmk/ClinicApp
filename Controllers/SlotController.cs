using ClinicApp.Controllers.Dtos;
using ClinicApp.Services;
using Microsoft.AspNetCore.Mvc;


namespace ClinicApp.Controllers
{
    [Route("/slots")]
    public class SlotController : ControllerBase
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSlotRequest request)
        {
            await _slotService.CreateSlot(request.time, request.doctorName, request.doctorId, request.cost);
            return Ok("Slot Created...");
        }

        [HttpPost("/slots/doctor")]
        public async Task<IActionResult> GetSlotsByDoctor([FromBody] ListSlotByDoctorRequest request)
        {
         
            return new JsonResult(_slotService.GetSlotsByDoctor(request.doctorName));
        }

        [HttpPost("/slots/getall")]
        public async Task<IActionResult> GetAllSlots()
        {
            await _slotService.GetAllSlots();
            return new JsonResult(_slotService.GetAllSlots()); 
        }

        [HttpPost("/slots/getavailable")]
        public async Task<IActionResult> GetAvailableSlots()
        {
            return new JsonResult(_slotService.GetAvailableSlots());
        }





    }
}

