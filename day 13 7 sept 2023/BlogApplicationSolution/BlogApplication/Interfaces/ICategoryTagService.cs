using BlogApplication.Models;

namespace BlogApplication.Interfaces
{
    public interface ICategoryTagService
    {
        public CategoryTag UpdateTitle(CategoryTag tag);
        public IList<CategoryTag> GetAllCategory();
    }
}
