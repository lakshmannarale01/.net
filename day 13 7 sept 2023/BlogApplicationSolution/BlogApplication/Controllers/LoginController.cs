using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Services;
using BlogApplication.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginservice;

        public LoginController(ILoginService service)
        {
            _loginservice=service;
        }
        [HttpGet]
        //Route("Login")]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        //[Route("Login")]
        public IActionResult UserLogin(Login login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var author = _loginservice.login(login);
                    if (author != null)
                    {
                        TempData.Add("un", author.AuthorId);
                    }
                    return RedirectToAction("Index", "Author");
                }
                catch (InvalidCredentialsException e)
                {
                    ViewBag.ErrorMessage = e.Message;
                }
            }

            return View(login);
        }
    }
}
