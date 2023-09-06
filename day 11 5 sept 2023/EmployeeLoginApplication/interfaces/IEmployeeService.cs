using EmployeeLoginApplication.Models;
using EmployeeLoginApplication.Models.DTOs;
using System.Numerics;

namespace EmployeeLoginApplication.interfaces
{
    public interface IEmployeeService
    {
        public Employee Add(Employee employee);
        public Employee UpdatePhone(EmployeeSpecialDTO doctor);
        public IList<Employee> GetAllEmployees();
    }
}
