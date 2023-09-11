using BlogApplication.Models;

namespace BlogApplication.Interfaces
{
    public interface ILoginService
    {
        public Author LoginCheck(Login login);
    }
}
