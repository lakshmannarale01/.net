using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaStoreApp.Interfaces;
using PizzaStoreApp.Models;

namespace PizzaStoreApp.Controllers
{
    [EnableCors("MyCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaApiController : ControllerBase
    {
        private readonly IManagePizzaService _manageService;
        private readonly IPizzaService _pizzaService;

        public PizzaApiController(IManagePizzaService manageService, IPizzaService pizzaService)
        {
            _manageService = manageService;
            _pizzaService = pizzaService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pizzaService.GetAllPizzas());
        }
        [HttpPost]
        public IActionResult Add(PizzaWithPic pizza)
        {
            if (ModelState.IsValid)
            {
                pizza = _manageService.AddPizza(pizza);
                return Created("", pizza);
            }
            return BadRequest("Could not add pizza");
        }
    }
}
