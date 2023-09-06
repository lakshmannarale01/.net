using EmployeeLoginApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeLoginApplication.Contexts
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options)
        {



        }
        public DbSet<Employee> employees { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "lakshman", DeptName = "accountant", Email = "abc@gmail.com", Phone = "+919988776655", Pic = "/images/Picture1.jpg" },
                 new Employee { Id = 2, Name = "deva", DeptName = "QualityControl", Email = "xyz@gmail.com", Phone = "+915544332211", Pic = "/images/Picture2.jpg" }
                );
        }
    }
}
