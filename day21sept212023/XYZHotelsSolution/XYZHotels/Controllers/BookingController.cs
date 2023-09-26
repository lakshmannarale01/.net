using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZHotels.Interfaces;
using XYZHotels.Models;

namespace XYZHotels.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;

        public BookingController(IBookingService service)
        {
            _service= service;
            
        }

        [HttpGet("Get")]
        public ActionResult Get()
        {
            var result = _service.GetAll();
            if (result == null)
            {
                return NotFound("No Booking Available");
            }
            return Ok(result);
        }

        [HttpPost("AdBooking")]
        public ActionResult AdBooking(Booking book)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var result = _service.AddBooking(book);
                    return Ok(result);
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }

        [HttpDelete("CanclBooking")]
        public ActionResult CanclBooking(int id)
        {
            try
            {
                var result = _service.CancelBooking(id);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

    }
}
