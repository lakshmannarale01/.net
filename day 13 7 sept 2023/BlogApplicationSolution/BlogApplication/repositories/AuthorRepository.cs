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
        #region Add
        public Author Add(Author entity)
        {
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
#endregion
        #region GetById
        public Author GetById(int key)
        {
           var author = _context.authors.SingleOrDefault(a=>a.AuthorId==key);
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
            var author = GetById(entity.AuthorId);
            if(author != null)
            {
                _context.Entry<Author>(entity).State=EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            throw new NoSuchEntityException("Author");
        }
        #endregion
    }
}
