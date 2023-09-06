using HospitalClinicApp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace HospitalClinicApp.contexts
{
    public class ClinicContexts : DbContext
    {
        public ClinicContexts(DbContextOptions options) : base(options)
        {

        }
        #region CollectionToTable
        public DbSet<Doctor> doctors { get; set; }// doctor
        public DbSet<Patient> patients { get; set; } //patient
        public DbSet<Appointment> appointments { get; set; } // appointments
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Initializing data
            modelBuilder.Entity<Doctor>().HasData(
       new Doctor {
           Id = 1,
           Name = "Deva1",
           Experience = 4,
           Speciality = "Surgen",
           Phone = "+91464676679", 
           Email = "abc@gmail.com",
           Pic = "/Images/pic1.jpeg"
       }, // path is necessary

       new Doctor
       {
           Id = 2,
           Name = "Deva2",
           Experience = 4,
           Speciality = "Surgen",
           Phone = "+918856904770",
           Email = "abc@gmail.com",
           Pic = "/Images/pic1.jpeg"
       } // path is necessary
        );

            modelBuilder.Entity<Patient>().HasData(
                new Patient
                {
                    Id = 101,
                    Name = "Ramu",
                    Phone = "918856904770",
                    Email = "xyz@gmail.com",
                    Age = 20
                },
                
              new Patient {
                    Id = 102,
                    Name = "Somu",
                    Phone = "917972051076",
                    Email = "aaa@gmail.com",
                    Age = 22
                }
                );;
        }

    }
}
