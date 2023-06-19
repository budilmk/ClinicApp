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
            await _slotService.CreateSlot(request.time, request.doctorName, request.cost);
            return Ok("Slot Created...");
        }

        [HttpPost("/query")]
        public async Task<IActionResult> Get([FromBody] string? doctorName)
        {
            await _slotService.Get(doctorName);
            return Ok("Slot listed...");
        }



    }
}

