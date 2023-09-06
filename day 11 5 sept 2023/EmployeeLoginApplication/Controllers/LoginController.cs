using EmployeeLoginApplication.Exceptions;
using EmployeeLoginApplication.interfaces;
using EmployeeLoginApplication.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLoginApplication.Controllers
{
    public class LoginController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}


        private readonly ILoginService _loginService;



        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        //Route("Login")]
        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        //[Route("Login")]
        public IActionResult UserLogin(LoginDTO loginDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employee = _loginService.Login(loginDTO);
                    if (employee != null)
                    {
                        TempData.Add("un", employee.Name);
                    }
                    return RedirectToAction("Index", "Employee");
                }
                catch (InvalidCredentialsException e)
                {
                    ViewBag.ErrorMessage = e.Message;
                }
            }



            return View(loginDTO);
        }


       
    }
}




