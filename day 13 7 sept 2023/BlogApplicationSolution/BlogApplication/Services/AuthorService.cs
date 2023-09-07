using BlogApplication.Interfaces;
using BlogApplication.Models;

namespace BlogApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<int, Author> _repository;

        public AuthorService( IRepository<int , Author> repository)
        {
            _repository = repository;
        }
        #region GetAll Author
        public IList<Author> GetAllAuthor()
        {
            return _repository.GetAll().ToList();
        }
        #endregion

        #region update description
        public Author UpdateDesc(Author author)
        {
            var myauthor = _repository.GetById(author.AuthorId);
            myauthor.Description = author.Description;
            _repository.Update(myauthor);
            return myauthor;
        }
        #endregion

        #region Update Email

        public Author UpdateEmail(Author author)
        {
            var myauthor = _repository.GetById(author.AuthorId);
            myauthor.Email = author.Email;  
            _repository.Update(myauthor);
            return myauthor;
        }
        #endregion

        #region Update Name
        public Author UpdateName(Author author)
        {
            var myauthor = _repository.GetById(author.AuthorId);
            myauthor.AuthorsName = author.AuthorsName;
            _repository.Update(myauthor);
                return myauthor;
        }
        #endregion

        #region UpdatePic

        public Author UpdatePic(Author author)
        {
            var myauthor = _repository.GetById(author.AuthorId);
            myauthor.Pic = author.Pic;
            _repository.Update(myauthor);
            return myauthor;
        }
        #endregion
    }
}
