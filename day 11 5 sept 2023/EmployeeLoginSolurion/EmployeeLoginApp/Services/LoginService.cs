using EmployeeLoginApp.Exceptions;
using EmployeeLoginApp.interfaces;
using EmployeeLoginApp.Models.DTOs;
using EmployeeLoginApp.Models;

namespace EmployeeLoginApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<int, Employee> _repository;


        public LoginService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }

        #region Login
        public Employee Login(LoginDTO loginDTO)
        {
            try
            {
                var employee = _repository.GetById(loginDTO.Id);
                if (employee.Phone == loginDTO.Password)
                    return employee;
            }
            catch (NoSuchEmployeeException e)
            {
                throw new InvalidCredentialsException();
            }
            throw new InvalidCredentialsException();
        }
        #endregion
    }
}
