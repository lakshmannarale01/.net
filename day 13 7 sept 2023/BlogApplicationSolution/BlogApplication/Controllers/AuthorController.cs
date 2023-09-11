using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Numerics;

namespace BlogApplication.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly ILogger<AuthorController> _logger;
        private readonly IRepository<int, Author> _repository;

        public AuthorController(IAuthorService authorService, ILogger<AuthorController> logger, IRepository<int, Author> repository)
        {
            _authorService = authorService;
            _logger = logger;
            _repository = repository;
        }
        static List<Author> MyAuthor = new List<Author>();
        #region Index 
        public IActionResult Index()
        {
            var authors = new List<Author>();
            try
            {

                if (ViewBag.User = HttpContext.Session.GetString("Username").ToString() == null)
                {
                    return RedirectToAction("UserLogin", "Login");
                }
                //ViewBag.Username = HttpContext.Session.GetString("Username");
                //authors = _authorService.GetAllAuthor().ToList();
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
                _logger.LogError("No Blog found..!!");
            }
            return View(authors = _authorService.GetAllAuthor().ToList());
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var a = _repository.GetById(id);
            return View(a);
        }
        #endregion

        #region Create Author author
        [HttpGet]
        public IActionResult SignUpAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUpAuthor(Author author)
        {
            try
            {
                //author.Pic = "/images/" + author.Pic;
                var aut =_repository.Add(author);
                _logger.LogInformation("Created Author record");
                return RedirectToAction("UserLogin" , "Login");
            }
            catch (Exception e)
            {

                ViewBag.ErrorMessage = e.Message;
                //Logging for programmer
                _logger.LogError("Unable to add doctor " + DateTime.Now.ToString());
            }
            return View(author);
        }

        #endregion

        #region Update drscription

        [HttpGet]
        public IActionResult UpdateDescription(int id)
        {
            var aut = _authorService.GetAllAuthor().SingleOrDefault(x => x.Id == id);
            var author = new Author { Id = id, Description = aut.Description };
            return View(author);
        }
        [HttpPost]
        public IActionResult UpdateDescription(int id, Author author)
        {
            try
            {
                var result = _authorService.UpdateDesc(author);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new NoSuchEntityException("Author");

            }

        }
        #endregion

        #region Update 

        [HttpGet]
        public IActionResult Update(int id)
        {
            var aut = _repository.GetById(id);
            return View(aut);
            //var aut = _authorService.GetAllAuthor().SingleOrDefault(x => x.AuthorId == id);
            //var author = new Author { AuthorId = id, Description = aut.Description };
            //return View(author);
        }
        [HttpPost]
        public IActionResult Update(int id, Author author)
        {
            ViewBag.Message = "";
            try
            {

                _repository.Update(author);
                return RedirectToAction("Index");
                //var a = _repository.GetById(author.AuthorId);
                //var result = _repository.Update(author);
                //return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewBag.Message = "Unable to update author";
                Debug.WriteLine(e.Message);
                //throw new NoSuchEntityException("Author"
            }
            return View(author);

        }
        #endregion

        #region Update Name

        [HttpGet]
        public IActionResult UpdateName(int id)
        {
            var aut = _authorService.GetAllAuthor().SingleOrDefault(x => x.Id == id);
            var author = new Author { Id = id, AuthorsName = aut.AuthorsName };
            return View(author);
        }
        [HttpPost]
        public IActionResult UpdateName(int id, Author author)
        {
            try
            {
                var result = _authorService.UpdateName(author);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new NoSuchEntityException("Author");

            }

        }
        #endregion

        #region Update Email

        [HttpGet]
        public IActionResult UpdateEmail(int id)
        {
            var aut = _authorService.GetAllAuthor().SingleOrDefault(x => x.Id == id);
            var author = new Author { Id = id, Email = aut.Email };
            return View(author);
        }
        [HttpPost]
        public IActionResult UpdateEmail(int id, Author author)
        {
            try
            {
                var result = _authorService.UpdateEmail(author);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                throw new NoSuchEntityException("Author");

            }

        }
        #endregion
        #region Delete
        [HttpGet]

        public IActionResult Delete(int id)
        {
            var aut = _repository.GetById(id);
            return View(aut);
            //Author aut = MyAuthor.SingleOrDefault(x=>x.AuthorId== id);
            //return View(aut);
        }
        [HttpPost]

        public IActionResult Delete(int id, Author author)
        {
            //MyAuthor.Remove(author);
            //return RedirectToAction("Index");
            ViewBag.Message = "";
            try
            {
                _repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                ViewBag.Message = "Unable to delete author";

            }
            return View(author);
        }
        #endregion
    }
}
