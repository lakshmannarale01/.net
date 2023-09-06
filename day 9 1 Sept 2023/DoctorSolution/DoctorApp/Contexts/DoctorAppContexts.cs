using DoctorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DoctorApp.Contexts
{
    public class DoctorAppContexts : DbContext
    {
        internal object appointment;

        public DoctorAppContexts(DbContextOptions options) : base(options) // ctor chaining
        {

        }
            #region CollectionToTable
        public DbSet<Doctor> doctors { get; set; }// doctor
        public DbSet<Patient> patients { get; set; } //patient
        public DbSet<Appointment> appointments { get; set; } // appointments
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>().HasKey(es => new { es.DoctorId, es.PatientId });


            // Initializing data
                     modelBuilder.Entity<Doctor>().HasData(
                new Doctor { DoctorId = 1, DoctorName = "Deva1", YearOfExp = 4, Speciality = "Surgen", Doctorphone = "1236541256", DoctorEmail = "abc@gmail.com", pic = "/Images/pic1.jpeg" }, // path is necessary

                 new Doctor { DoctorId = 2, DoctorName = "Deva2", YearOfExp = 4, Speciality = "General", Doctorphone = "8856904770", DoctorEmail = "xyz@gmail.com", pic = "/Images/pic2.jpeg" } // path is necessary
                 );

            modelBuilder.Entity<Patient>().HasData(
                new Patient { PatientId=101,PatientName="Ramu1",Age=23,PatientEmail="ramu1@gmail.com",PatientPhone="8525852252"},
                 new Patient { PatientId = 102, PatientName = "Ramu2", Age = 50, PatientEmail = "ramu2@gmail.com", PatientPhone = "00012102151" }
                );

            modelBuilder.Entity<Appointment>().HasData(
               new Appointment { AppointmentNumber = 1, DoctorId = 1, PatientId = 101,DateTime=null},
               new Appointment { AppointmentNumber = 2, DoctorId = 2, PatientId = 102, DateTime = null }
               ) ;



        }
    }
 }

