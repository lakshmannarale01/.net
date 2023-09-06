using EmployeeLoginApp.Exceptions;
using EmployeeLoginApp.interfaces;
using EmployeeLoginApp.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeLoginApp.Controllers
{
    public class LoginController : Controller
    {
      

        private readonly ILoginService _loginService;



        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }
        [HttpGet]
        #region UserLogin
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
        #endregion


    }
}
