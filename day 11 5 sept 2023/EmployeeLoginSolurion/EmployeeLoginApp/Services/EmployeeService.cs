using EmployeeLoginApp.Models.DTOs;
using EmployeeLoginApp.Models;
using EmployeeLoginApp.interfaces;

namespace EmployeeLoginApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IRepository<int, Employee> _repository;
        public EmployeeService(IRepository<int, Employee> repository)
        {
            _repository = repository;
        }
        #region Add
        public Employee Add(Employee employee)
        {
            var employees = _repository.Add(employee);
            return employees;
        }
        #endregion

        #region GetAllEmployees

        public IList<Employee> GetAllEmployees()
        {
            return _repository.GetAll().ToList();
        }
        #endregion

        #region updatePhone
        public Employee UpdatePhone(EmployeeSpecialDTO employee)
        {
            var emp = _repository.GetById(employee.Id);
            emp.Phone = employee.Phone;
            _repository.Update(emp);
            return emp;
        }
        #endregion
    }
}
