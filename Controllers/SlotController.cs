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

        //Qn 1b To add new slots
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSlotRequest request)
        {
            await _slotService.CreateSlot(request.time, request.doctorName, request.doctorId, request.cost);
            return Ok("Slot Created...");
        }

        //Qn 1a. To list my slots
        [HttpPost("/slots/doctor")]
        public async Task<IActionResult> GetSlotsByDoctor([FromBody] ListSlotByDoctorRequest request)
        {
         
            return new JsonResult(_slotService.GetSlotsByDoctor(request.doctorName));
        }

        //To get all slots irregardless of availability
        [HttpPost("/slots/getall")]
        public async Task<IActionResult> GetAllSlots()
        {
            await _slotService.GetAllSlots();
            return new JsonResult(_slotService.GetAllSlots()); 
        }

        //Qn 2a. To view all doctor's available slots only
        [HttpPost("/slots/getavailable")] //
        public async Task<IActionResult> GetAvailableSlots()
        {
            return new JsonResult(_slotService.GetAvailableSlots());
        }

        [HttpPost("/slots/updatereservation")] //API to update reservation status
        public async Task<IActionResult> UpdateSlotReservation([FromBody] GetSlotUpdateRequest request)
        {
            await _slotService.UpdateSlotReservation(request.isReserved, request.slotId);
            return Ok("Reservation updated");
        }







    }
}

