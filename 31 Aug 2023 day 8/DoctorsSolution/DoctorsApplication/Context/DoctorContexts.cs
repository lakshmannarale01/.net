using DoctorsApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorsApplication.Context
{
    public class DoctorContexts : DbContext
    {
        public DoctorContexts(DbContextOptions options) : base(options)
        {
            
        }
        
    
        #region CollectionToTable
       
        public DbSet<Doctors> doctor { get; set; }
        public DbSet<Department> departments { get; set; }

        public DbSet<Patient> patients { get; set; }
        public DbSet<Appoitment> appoitments { get; set; }

        #endregion
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Patient>().HasKey(es => new { es.DoctorId, es.AppointmentID });


          
        //    modelBuilder.Entity<Department>().HasData(
        //        new Department { DepartmentId = 1, Name = "Operaton T " },
        //        new Department { DepartmentId = 2, Name = "General" }
        //        );
        //}
    }
}
