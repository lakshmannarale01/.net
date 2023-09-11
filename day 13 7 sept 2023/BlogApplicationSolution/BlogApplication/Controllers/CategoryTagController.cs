using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace BlogApplication.Controllers
{
    public class CategoryTagController : Controller
    {
        #region injection
        private readonly ICategoryTagService _service;
        private readonly ILogger<CategoryTagController> _logger;
        private readonly IRepository<int, CategoryTag> _repository;

        public CategoryTagController(ICategoryTagService categoryTagService ,IRepository<int , CategoryTag> repository,ILogger <CategoryTagController> logger)
        {
            _service = categoryTagService;
            _logger = logger;
            _repository = repository;
        }
        #endregion

        #region index
        public ActionResult Index()
        {
            var tag = new List<CategoryTag>();
            try
            {
                tag = _service.GetAllCategory().ToList();

            }
            catch (Exception)
            {

                _logger.LogError("No Tag Available");
            }
            return View(tag);
        }
        #endregion

        #region Create tag
        [HttpGet]
        public ActionResult Createtag()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Createtag(CategoryTag tag)
        {
            try
            {
                var mytag = _repository.Add(tag);
                _logger.LogInformation("created tag record");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                _logger.LogError("Unable to add tag " + DateTime.Now.ToString());
            }
            return View();
        }
        #endregion

        #region Update

        [HttpGet]
        public IActionResult UpdateT(int id)
        {
            var t =_service.GetAllCategory().SingleOrDefault(x=>x.Id == id);
            var mytag = new CategoryTag { Id = id };
            return View(mytag);
        }
        [HttpPost]
        public IActionResult UpdateT(int id , CategoryTag tag)
        {
            try
            {
                var result = _service.UpdateTitle(tag);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                _logger.LogError("Unable to update");
                throw new UnableToUpdateException("TagTitle");
            }
        }
        #endregion
    }
}
