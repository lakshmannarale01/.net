using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Utilities;

namespace BlogApplication.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<int, Author> _repository;

        public LoginService(IRepository<int, Author> repository)
        {
            _repository = repository;
        }
     

      

        public Author LoginCheck(Login login)
        {
            var author = _repository.GetAll();
            var myAuthor = author.SingleOrDefault(x => x.AuthorsName == login.Username && x.Phone == login.Password);
            if (myAuthor == null)
            {
               throw new InvalidCredentialsException();
            }
            return myAuthor;
        }
    }
}
