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

        static List<CategoryTag> catcnt = new List<CategoryTag>();
        public CategoryTag Add(CategoryTag entity)
        {
            //entity.Id=GenerateIndex();
            _context.categoryTags.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        #endregion

        //#region
        //private int GenerateIndex()
        //{
        //    int id = catcnt.Count();
        //    return ++id;
        //}

        //#endregion

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
            var tag = _context.categoryTags.SingleOrDefault(c=>c.Id == key);
            if(tag != null)
            {
                return tag;
            }
            throw new NoSuchEntityException("Category");
        }

        public CategoryTag Update(CategoryTag entity)
        {
            var tag = GetById(entity.Id);
            if(tag == null)
            {
                throw new NoSuchEntityException("Category");
               
            }
            _context.categoryTags.Update(tag);
            _context.SaveChanges();
            return entity;
        }
        #endregion
    }
}
