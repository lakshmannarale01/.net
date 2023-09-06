using EmployeeLoginApplication.Exceptions;
using EmployeeLoginApplication.interfaces;
using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Models.DTOs;
using System.Security.Authentication;

namespace EmployeeLoginApplication.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository<int,Employee> _repository;

        
        public LoginService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }
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
    }
    
}
