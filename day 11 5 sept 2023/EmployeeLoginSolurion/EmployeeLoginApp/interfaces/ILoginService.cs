using EmployeeLoginApp.Models.DTOs;
using EmployeeLoginApp.Models;

namespace EmployeeLoginApp.interfaces
{
    public interface ILoginService
    {
        public Employee Login(LoginDTO loginDTO);
    }
}
