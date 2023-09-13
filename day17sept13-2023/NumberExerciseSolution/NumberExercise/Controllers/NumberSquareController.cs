using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NumberExercise.Interfaces;
using NumberExercise.Models;

namespace NumberExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NumberSquareController : ControllerBase
    {
        private readonly INumberService _numService;

        public NumberSquareController(INumberService numberService)
        {
            _numService = numberService;
        }
        [HttpPost]
        public ActionResult FindSquare(NumberFromUser input)
        {
            if (input == null)
            {
                return BadRequest("Input  can not be empty");
            }
            List<int> result = _numService.FindSquare(input.Numbers);
            if (result == null)
            {
                return NotFound("Not Found");
            }
            return Ok(result);
        }
    }
}
