using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Services;
using BlogApplication.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Authentication;

namespace BlogApplication.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginService _loginservice;

        public LoginController(LoginService service)
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
                    var author = _loginservice.LoginCheck(login);
                    if (author != null)
                    {
                        HttpContext.Session.SetString("Username", login.Username);
                        return RedirectToAction("Index", "Home");
                    }

                    ViewBag.ErrorMessage = "Invalid username or password";
                    return View(login);
                }
                catch (Exception)
                {
                    ViewBag.ErrorMessage = "Invalid username or password";
                    return View(login);
                }
            }
            return View(login);


            //var result =_loginservice.LoginCheck(login);
            // if(result!= null)
            // {
            //     HttpContext.Session.SetString("Username", login.Username);
            //     return RedirectToAction("Index", "Home");
            // }
            // ViewBag.ErrorMessage = "Invalid username or password";
            // return View(login);
        }
    }
}
