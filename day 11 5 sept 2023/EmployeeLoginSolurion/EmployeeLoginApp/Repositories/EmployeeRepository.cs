using EmployeeLoginApp.Exceptions;
using EmployeeLoginApp.interfaces;
using EmployeeLoginApp.Models;
using EmployeeLoginApplication.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoginApp.Repositories
{
    public class EmployeeRepository :IRepository<int, Employee>
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        #region Add
        public Employee Add(Employee entity)
        {
            _context.employees.Add(entity);
            _context.SaveChanges();
            return entity;
        }
        #endregion

        #region Delete
        public Employee Delete(int key)
        {
           
            var employee = GetById(key);
            if (employee != null)
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();
                return employee;
            }
            throw new NoSuchEmployeeException();
        }
        #endregion

        #region GetAll

        public ICollection<Employee> GetAll()
        {
           
            var employees = _context.employees;
            if (employees.Count() == 0)
                throw new NoSuchEmployeeException();
            return employees.ToList();
        }

        #endregion

        #region GetById
        public Employee GetById(int key)
        {
           
            var doctor = _context.employees.SingleOrDefault(d => d.Id == key);
            if (doctor != null)
                return doctor;
            throw new NoSuchEmployeeException();

        }
        #endregion

        #region Update

        public Employee Update(Employee entity)
        {
            var employee = GetById(entity.Id);
            if (employee != null)
            {
                _context.Entry<Employee>(entity).State = EntityState.Modified;
                _context.SaveChanges();
                return entity;
            }
            throw new NoSuchEmployeeException();
        }
        #endregion
    }
}
