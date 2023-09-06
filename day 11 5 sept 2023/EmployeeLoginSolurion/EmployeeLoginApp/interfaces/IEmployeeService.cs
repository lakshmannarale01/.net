using EmployeeLoginApp.Models.DTOs;
using EmployeeLoginApp.Models;

namespace EmployeeLoginApp.interfaces
{
    public interface IEmployeeService
    {
        public Employee Add(Employee employee);
        public Employee UpdatePhone(EmployeeSpecialDTO doctor);
        public IList<Employee> GetAllEmployees();
    }
}
