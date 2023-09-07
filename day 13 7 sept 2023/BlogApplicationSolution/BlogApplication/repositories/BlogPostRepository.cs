using BlogApplication.BlogContext;
using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Utilities;

namespace BlogApplication.repositories
{
    public class BlogPostRepository : IRepository<int , BlogPost>
    {
        private readonly BContexts _context;

        public BlogPostRepository(BContexts contexts)
        {
            _context=contexts;
        }
        #region Add
        public BlogPost Add(BlogPost entity)
        {
           _context.blogPosts.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        #endregion

        #region Delete

        public BlogPost Delete(int key)
        {
           var blp = GetById(key);
            if(blp == null)
            {
                throw new NoSuchEntityException("Blog");
            }
            _context.blogPosts.Remove(blp);
            _context.SaveChanges();
            return blp;
        }
        #endregion

        #region GetAll

        public ICollection<BlogPost> GetAll()
        {
            var blp = _context.blogPosts;
            if (blp.Count() == 0)
            {
                throw new NoSuchEntityException("Blog");
            }
            return blp.ToList();
        }
        #endregion

        #region GetById
        public BlogPost GetById(int key)
        {
           var blp = _context.blogPosts.SingleOrDefault(b=>b.BlogPostId == key);
            if(blp != null)
            {
                return blp;
            }
            throw new NoSuchEntityException("Blog");
        }
        #endregion

        #region Update 
        public BlogPost Update(BlogPost entity)
        {
            var blp = GetById(entity.BlogPostId);
            if (blp == null)
                throw new NoSuchEntityException("BlogId");
            blp.Title = entity.Title;
            blp.BPost = entity.BPost;
            blp.AuthorId = entity.AuthorId;
            blp.TagId = entity.TagId;
            _context.SaveChanges();
            return blp;
        }
        #endregion
    }
}
