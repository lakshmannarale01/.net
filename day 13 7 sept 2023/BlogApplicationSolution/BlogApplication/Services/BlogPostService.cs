using BlogApplication.Interfaces;
using BlogApplication.Models;

namespace BlogApplication.Services
{
    public class BlogPostService : IBlogPostService
    {
        private readonly IRepository<int, BlogPost> _repository;

        public BlogPostService(IRepository<int ,BlogPost> repository)
        {
            _repository = repository;
        }
        #region Get all Blog
        public IList<BlogPost> GetAllBlogPost()
        {
            return _repository.GetAll().ToList();

        }
        #endregion

        //#region Update Author id for that blog
        //public BlogPost UpdateAuthorId(BlogPost blogPost)
        //{
        //    var blp = _repository.GetById(blogPost.BlogPostId);
        //    //blp.AuthorId = blogPost.AuthorId;
        //    _repository.Update(blp);
        //    return blp;
        //}
        //#endregion

        public BlogPost UpdateBPost(BlogPost blogPost)
        {
            var blp = _repository.GetById(blogPost.Id);
            blp.BPost = blogPost.BPost;
            blp.Title = blogPost.Title;
            _repository.Update(blp);
            return blp;
        }

        //public BlogPost UpdateTagId(BlogPost blogPost)
        //{
        //    var blp = _repository.GetById(blogPost.BlogPostId);
        //    //blp.TagId = blogPost.TagId;
        //    _repository.Update(blp);
        //    return blp;
        //}

        public BlogPost UpdateTitle(BlogPost blogPost)
        {
            var blp = _repository.GetById(blogPost.Id);
            blp.Title = blogPost.Title;
            _repository.Update(blp);
                return blp;
        }
    }
}
