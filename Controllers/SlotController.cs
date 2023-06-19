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

        [HttpPost("/doctor")]
        public async Task<IActionResult> GetSlotsByDoctor([FromBody] string? doctorName)
        {
            await _slotService.GetSlotsByDoctor(doctorName);
            return Ok("Slot listed by doctor...");
        }

        [HttpPost("/getall")]
        public async Task<IActionResult> GetAllSlots()
        {
            await _slotService.GetAllSlots();
            return Ok("All Slot listed...");
        }



    }
}

