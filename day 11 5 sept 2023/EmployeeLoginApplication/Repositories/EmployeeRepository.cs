using EmployeeLoginApplication.Contexts;
using EmployeeLoginApplication.Exceptions;
using EmployeeLoginApplication.interfaces;
using EmployeeLoginApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace EmployeeLoginApplication.Repositories
{
    public class EmployeeRepository : IRepository<int, Employee>
    {
        private readonly EmployeeContext _context;

        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }
        public Employee Add(Employee entity)
        {
            _context.employees.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public Employee Delete(int key)
        {
            //throw new NotImplementedException();
            var employee = GetById(key);
            if (employee != null)
            {
                _context.employees.Remove(employee);
                _context.SaveChanges();
                return employee;
            }
            throw new NoSuchEmployeeException();
        }

        public ICollection<Employee> GetAll()
        {
            // throw new NotImplementedException();
            var employees = _context.employees;
            if (employees.Count() == 0)
                throw new NoSuchEmployeeException();
            return employees.ToList();
        }

        public Employee GetById(int key)
        {
            // throw new NotImplementedException();
            var doctor = _context.employees.SingleOrDefault(d => d.Id == key);
            if (doctor != null)
                return doctor;
            throw new NoSuchEmployeeException();

        }

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
    }
    
}
