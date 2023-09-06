using EmployeeLoginApplication.interfaces;
using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Models.DTOs;
using EmployeeLoginApplication.Repositories;
using System.Numerics;

namespace EmployeeLoginApplication.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<int, Employee> _repository;
        public EmployeeService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }

        public Employee Add(Employee employee)
        {
            //  throw new NotImplementedException();
            var employees = _repository.Add(employee);
            return employees;
        }

        public IList<Employee> GetAllEmployees()
        {
            return _repository.GetAll().ToList();
        }

        public Employee UpdatePhone(EmployeeSpecialDTO employee)
        {
            var emp = _repository.GetById(employee.Id);
            emp.Phone = employee.Phone;
            _repository.Update(emp);
            return emp;
        }
    }
}
