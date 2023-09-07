using BlogApplication.BlogContext;
using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Utilities;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication.repositories
{
    public class CategoryTagRepository : IRepository<int, CategoryTag>
    {
        private readonly BContexts _context;

        public CategoryTagRepository(BContexts contexts)
        {
            _context=contexts;
        }
        #region
        public CategoryTag Add(CategoryTag entity)
        {
            _context.categoryTags.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        #endregion

        #region Delete
        public CategoryTag Delete(int key)
        {
            var tag = GetById(key);
           if(tag != null)
            {
                _context.categoryTags.Remove(tag);
                _context.SaveChanges();
                   return tag;
            }
            throw new NoSuchEntityException("CategoryTag");
        }
        #endregion
        #region GetAll

        public ICollection<CategoryTag> GetAll()
        {
            var tag = _context.categoryTags;
            if (tag.Count() == 0)
                throw new NoSuchEntityException("Category");
            return tag.ToList();
        }
        #endregion
        #region GetById

        public CategoryTag GetById(int key)
        {
            var tag = _context.categoryTags.SingleOrDefault(c=>c.TagId == key);
            if(tag != null)
            {
                return tag;
            }
            throw new NoSuchEntityException("Category");
        }

        public CategoryTag Update(CategoryTag entity)
        {
            var tag = GetById(entity.TagId);
            if(tag != null)
            {
                _context.Entry<CategoryTag>(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return tag;
            }
            throw new NoSuchEntityException("Category");
        }
        #endregion
    }
}
