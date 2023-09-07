using BlogApplication.Interfaces;
using BlogApplication.Models;
using BlogApplication.Utilities;

namespace BlogApplication.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<int, Author> _repository;

        public LoginService(IRepository<int,Author> repository)
        {
            _repository=repository;
        }

        public Author login(Login login)
        {
            try
            {
                var author = _repository.GetById(login.Id);
                if(author.AuthorsName==login.Password)
                {
                    return author;
                }
            }
            catch (NoSuchEntityException e )
            {
                throw new InvalidCredentialsException();
            }
            throw new InvalidCredentialsException();
        }
    }
}
