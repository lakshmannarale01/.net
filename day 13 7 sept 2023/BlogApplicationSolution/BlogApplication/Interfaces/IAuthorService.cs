using BlogApplication.Models;

namespace BlogApplication.Interfaces
{
    public interface IAuthorService
    {
        public Author UpdateName(Author author);

        public Author UpdateEmail(Author author);

        public Author UpdateDesc(Author author);

        public Author UpdatePic(Author author);

        public IList<Author> GetAllAuthor();

    }
}
