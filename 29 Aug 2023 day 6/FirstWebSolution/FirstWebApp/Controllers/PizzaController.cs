using Microsoft.AspNetCore.Mvc;

namespace FirstWebApp.Controllers
{
    public class PizzaController : Controller
    {

        List<string> pizzas = new List<string>
        {
            "ABC","XYZ","DEF","UVW"
        };
        public IActionResult Index()
        {
            ViewBag.PizzaName = "ABC Pizza";
            ViewBag.PIzzaPrice = 200;
            ViewBag.PizzaQtyAvailable = 50;

            return View();
        }
        public IActionResult List()
        {
            ViewBag.pizzas = pizzas;
            return View();  
        }
    }
}
