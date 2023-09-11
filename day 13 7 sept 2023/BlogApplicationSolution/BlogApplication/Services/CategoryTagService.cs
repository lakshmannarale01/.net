using BlogApplication.Interfaces;
using BlogApplication.Models;

namespace BlogApplication.Services
{
    public class CategoryTagService : ICategoryTagService
    {
        private readonly IRepository<int, CategoryTag> _repository;

        public CategoryTagService(IRepository <int , CategoryTag> repository)
        {
            _repository = repository;
        }
        public CategoryTag UpdateTitle(CategoryTag tag)
        {
            var t = _repository.GetById(tag.Id);
                t.TagTitle = tag.TagTitle;
            _repository.Update(t);
            return t;
        }
        public IList<CategoryTag> GetAllCategory()
        {
            return _repository.GetAll().ToList();
        }
    }
}
