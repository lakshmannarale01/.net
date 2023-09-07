using BlogApplication.Interfaces;
using BlogApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace BlogApplication.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;

        public AuthorController(IAuthorService authorService , ILogger<AuthorController> logger)
        {
            _authorService = authorService;
            _logger = logger;
        }

        #region Index 
        public IActionResult Index()
        {
            var authors = new List<Author>();
            try
            {

                if (TempData.Peek("un") == null)
                    return RedirectToAction("UserLogin", "Login");
                ViewBag.Username = TempData.Peek("un").ToString();
                authors = _authorService.GetAllAuthor().ToList();
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogError("NoAuthor found..!!");
            }
            return View(authors);
        }
        #endregion
    }
}
