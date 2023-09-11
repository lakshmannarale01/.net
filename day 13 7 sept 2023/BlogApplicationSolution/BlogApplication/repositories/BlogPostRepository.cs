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
        static List<BlogPost> blpcnt = new List<BlogPost>();
        public object GetAllBlogPost => throw new NotImplementedException();
        #region Add
        public BlogPost Add(BlogPost entity)
        {
            //entity.Id = GenerateIndex();
           _context.blogPosts.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        #endregion

        //#region
        //private int GenerateIndex()
        //{
        //    int id = blpcnt.Count();
        //    return ++id;
        //}

        //#endregion

        #region Delete

        public BlogPost Delete(int key)
        {
           var blp = GetById(key);
            if(blp != null)
            {
                _context.blogPosts.Remove(blp);
                _context.SaveChanges();
                return blp;
               
            }
            throw new NoSuchEntityException("Blog");
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
           var blp = _context.blogPosts.SingleOrDefault(b=>b.Id == key);
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
           var blog = GetById(entity.Id);
            if (blog == null) {
                throw new NoSuchEntityException("Blog");
            }
            _context.blogPosts.Update(blog);
            _context.SaveChanges();
            return entity;
        }
        #endregion
    }
}
