using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace BlogApplication.Controllers
{
    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult UserProfile()
        {
            try
            {
                ViewBag.User = HttpContext.Session.GetString("Username").ToString();
            }
            catch (Exception)
            {
                return RedirectToAction("UserLogin", "User");
            }
            return View();
        }
        [HttpGet]
        public IActionResult UserLogout(string un)
        {
            HttpContext.Session.Clear();
            return RedirectToAction( "UserLogin" , "Login");
        }
    }
}
