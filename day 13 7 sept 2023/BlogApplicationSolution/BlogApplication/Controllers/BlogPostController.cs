using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Services;
using BlogApplication.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection.Metadata;
using static System.Reflection.Metadata.BlobBuilder;

namespace BlogApplication.Controllers
{
    public class BlogPostController : Controller
    {
        #region injection
        private readonly IBlogPostService _blogPostService;
        private readonly ILogger<BlogPost> _logger;
        private readonly IRepository<int, BlogPost> _repository;
        private readonly ICategoryTagService _Tag;
        private readonly IAuthorService _author;

        public BlogPostController(IBlogPostService blogPostService,
            ICategoryTagService categoryTagService,
            ILogger<BlogPost> logger,
            IRepository<int , BlogPost> repository,
            IAuthorService authorService)
        {
            _blogPostService = blogPostService;
            _logger = logger;
            _repository = repository;
            _Tag=categoryTagService;
            _author=    authorService;
        }
        #endregion

        #region Index
        static List<BlogPost> Myblp = new List<BlogPost>();
        public IActionResult Index()
        {
         var blogs = new List<BlogPost>();
            try
            {
                blogs = _blogPostService.GetAllBlogPost().ToList();
                var authBlogs = blogs.Where(blog => blog.AuthorsName.Contains
                (ViewBag.User = HttpContext.Session.GetString("Username").ToString()));
                if (authBlogs != null)
                    return View(authBlogs);

                //blogPosts = _repository.GetAll().ToList();
                //return View(blogPosts);
            }
            catch (Exception e)
            {

                _logger.LogInformation("There are no blogPost");
            }
            return View(blogs);
        }
        #endregion

        #region details
        [HttpGet]
        public IActionResult Details(int id)
        {
            BlogPost b = _repository.GetById(id);
            return View(b);
        }

        #endregion




        #region Create blogPost
        [HttpGet]
        
        public IActionResult CreateBlogPost(int id)
        {
            //ViewBag.BlogPosts = GetCategoryTag();
            //ViewBag.authors = GetAuthor();
            //BlogPost blogPost= new BlogPost();
            // blogPost.AuthorId=id;
            // blogPost.Post_Publish_DateTime = DateTime.Now;
            return View();
        }
        [HttpPost]
        public IActionResult CreateBlogPost(int id, BlogPost blogPost)
        {
            //ViewBag.BlogPosts = GetCategoryTag();
            //ViewBag.authors = GetAuthor();
            if (ModelState.IsValid)
            {
                try
                {
                    var myblp = _repository.Add(blogPost);
                    return RedirectToAction("index");
                }
                catch (Exception e)
                {

                    _logger.LogInformation("Unable to add BlogPost");
                    throw new UnableToAddException();
                }
            }
            return View();
        }

        #endregion

        #region Get category
        private List<SelectListItem> GetCategoryTag()
        {

            List<SelectListItem> tag = new List<SelectListItem>();
            foreach(var  item in _Tag.GetAllCategory())
            {
                var li = new SelectListItem()

                {
                    
               Text = item.Id.ToString(),
                    Value = item.Id.ToString()
                };
                tag.Add(li);

            }return tag;

        }
        #endregion

        #region Get Author
        private List<SelectListItem> GetAuthor()
        {

            List<SelectListItem> aut = new List<SelectListItem>();
            foreach (var item in _author.GetAllAuthor())
            {
                var li = new SelectListItem()

                {
                    Text = item.Id.ToString(),
                    Value = item.Id.ToString()
                };
                aut.Add(li);

            }
            return aut;

        }
        #endregion

       


        #region Update Bpost

        [HttpGet]
        public IActionResult UpdateBlogPost(int id)
        {
            var aut = _blogPostService.GetAllBlogPost().SingleOrDefault(x => x.Id == id);
            var blp = new BlogPost { Id = id };
            return View(blp);
        }
        [HttpPost]
        public IActionResult UpdateBlogPost(int id, BlogPost blogPost)
        {
            try
            {
                var result = _blogPostService.UpdateBPost(blogPost);
                return RedirectToAction("Index");
            } // method oupput update hot nahi
            catch (Exception)
            {

                _logger.LogError("Unable to Update Bpost" + DateTime.Now.ToString());
                throw new UnableToUpdateException("Bpost");
            }

        }


        #endregion

     

        #region Update TagId

        //[HttpGet]
        //public IActionResult UpdateT(int id)
        //{
        //    var aut = _blogPostService.GetAllBlogPost().SingleOrDefault(x => x.Id == id);
        //    var blp = new BlogPost { Id = id };
        //    return View(blp);
        //}
        //[HttpPost]
        //public IActionResult UpdateT(int id, BlogPost blogPost)
        //{
        //    try
        //    {
        //        var result = _blogPostService.UpdateTitle(blogPost);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {

        //        _logger.LogError("Unable to Update TagId" + DateTime.Now.ToString());
        //        throw new UnableToUpdateException("TagId");
        //    }

        //}


        #endregion
        #region Delete
        [HttpGet]

        public IActionResult Delete(int id)
        {
            var blp = _repository.GetById(id);
            return View(blp);
        }
        [HttpPost]

        public IActionResult Delete(int id, BlogPost blp)
        {
            try
            {
                _repository.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ViewBag.ErrorMessage = e.Message;
                  _logger.LogError("Unable to delete Blog");
            }
            return View();
        }
        #endregion

        #region Update 

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    var aut = _blogPostService.GetAllBlogPost().SingleOrDefault(x => x.Id == id);
        //    var author = new Author { Id = id };
        //    return View(author);
        //}
        //[HttpPost]
        //public IActionResult Update(int id, BlogPost blp)
        //{
        //    try
        //    {
        //        var result = _repository.Update(blp);
        //        return RedirectToAction("Index" , "BlogPost");
        //    }
        //    catch (Exception e)
        //    {
        //        throw new NoSuchEntityException("Author");

        //    }

        //}
        #endregion
        #region Delete Blog
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    var blog = _repository.GetByID(id);
        //    return View(blog);
        //}


        //[HttpPost]
        //public IActionResult Delete(Blog blog)
        //{
        //    ViewBag.ErrorMessage = "";
        //    try
        //    {



        //        _blogService.Delete(blog);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception e)
        //    {
        //        ViewBag.ErrorMessage = e.Message;
        //        _logger.LogError("Unable to delete Blog");
        //    }
        //    return View();
        //}
        #endregion
        #region Update TagId

        //[HttpGet]
        //public IActionResult UpdateTagId(int id)
        //{
        //    var aut = _blogPostService.GetAllBlogPost().SingleOrDefault(x => x.BlogPostId == id);
        //    var blp = new BlogPost { BlogPostId = id };
        //    return View(blp);
        //}
        //[HttpPost]
        //public IActionResult UpdateTagId(int id, BlogPost blogPost)
        //{
        //    try
        //    {
        //        var result = _blogPostService.UpdateTagId(blogPost);
        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception)
        //    {

        //        _logger.LogError("Unable to Update TagId" + DateTime.Now.ToString());
        //        throw new UnableToUpdateException("TagId");
        //    }

        //}


        #endregion
    }
}
