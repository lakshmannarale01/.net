using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Models.DTOs;

namespace EmployeeLoginApplication.interfaces
{
    public interface ILoginService
    {

        public Employee Login(LoginDTO loginDTO);
    }
}
