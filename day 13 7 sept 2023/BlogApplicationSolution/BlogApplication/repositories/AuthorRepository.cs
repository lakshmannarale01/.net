using BlogApplication.BlogContext;
using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.repositories
{
    public class AuthorRepository : IRepository<int, Author>
    {
        private readonly BContexts _context;

        public AuthorRepository(BContexts contexts)
        {
            _context=contexts;
            
        }

        static List<Author> autcnt = new List<Author>();
        #region Add
        public Author Add(Author entity)
        {
            //entity.Id = GenerateIndex();
           _context.authors.Add(entity);
            _context.SaveChanges();
            return entity;
        }
#endregion
        #region Delete
        public Author Delete(int key)
        {
            var author = GetById(key);
            if (author != null)
            {
                _context.authors.Remove(author);
                _context.SaveChanges();
                return author;
            }
            throw new NoSuchEntityException("author");
        }
#endregion
        #region GetAll
        public ICollection<Author> GetAll()
        {
          var author = _context.authors;
            if(author.Count()==0)
            {
                throw new NoSuchEntityException("author");
            }
            return author.ToList();
        }
        #region
        // private int GenerateIndex()
        //{
        //    int id = autcnt.Count();
        //    return ++id;
        //}

        #endregion

        #endregion
        #region GetById
        public Author GetById(int key)
        {
           var author = _context.authors.SingleOrDefault(a=>a.Id == key);
            if(author != null)
            {
                return author;
            }
            throw new NoSuchEntityException("author");
        }
#endregion
        #region Update
        public Author Update(Author entity)
        {

            var author = GetById(entity.Id);
            if (author == null)
                throw new NoSuchEntityException("Author");
            _context.authors.Update(author);
            _context.SaveChanges();
            return entity;

        }
        #endregion

        
    }
}
