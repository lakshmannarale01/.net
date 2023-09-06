using HospitalClinicApp.contexts;
using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Models.DTO;
using HospitalClinicApp.Models;
using HospitalClinicApp.Repositories;
using HospitalClinicApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalTest
{
    public class DoctorServiceTest
    {
        ClinicContexts context;
        //Gets executed for every test
        #region LoginTest
        [SetUp]
        public void Setup()
        {
            var dbContextOption = new DbContextOptionsBuilder<ClinicContexts>().UseInMemoryDatabase(databaseName: "dbDummyClinic").Options;
            context = new ClinicContexts(dbContextOption);
        }
        [Test]
        public void AddTest()
        {

            // Arrange
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);

            IDoctorService doctorService = new DoctorService(doctorRepository);


            //Action
            var doct = new Doctor { Id = 1, Name = "Deva", Email = "Deva@gmail.com", Experience = 2, Phone = "8856904770", Speciality = "surgen", Pic = "-" };
        var result = doctorService.Add(doct);
            var data = new Doctor { Id = 1, Name = "Deva", Email = "Deva@gmail.com", Experience = 2, Phone = "8856904770", Speciality = "surgen", Pic = "-" };


        //Assert
        Assert.AreEqual(data.Id, result.Id);
        }

        #endregion

        #region UpdateSpecialization

        [Test]
        public void UpdateSpecializationTest()
        {
            //Arrange
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);

            IDoctorService doctorService = new DoctorService(doctorRepository);

            Doctor? doct = new Doctor { Id = 1, Name = "Deva", Email = "Deva@gmail.com", Experience = 2, Phone = "8856904770", Speciality = "surgen", Pic = "-" };
            doctorRepository.Add(doct);

            var result = doctorService.UpdateSpecialization(new DoctorSpecialDTO { Id=1 , Speciality = "dermatologist" });
            var data = "dermatologist";
            //Assert
            Assert.AreEqual(data, result.Speciality);
        }
        #endregion

        #region GeatAllDoctor
        [Test]
         public void GetAllDoctorTest()

            //Arrange
        {
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);

            IDoctorService doctorService = new DoctorService(doctorRepository);
            Doctor? doctor = new Doctor { Id = 1, Name = "Deva", Email = "Deva@gmail.com", Experience = 2, Phone = "8856904770", Speciality = "surgen", Pic = "-" };
            doctorRepository.Add(doctor);

            //Action
            var result = doctorService.GetAllDoctor();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count);


        }
        #endregion

        #region UpdatePhone

        [Test]
        public void UpdatePhoneTest()
        {
            //Arrange
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);

            IDoctorService doctorService = new DoctorService(doctorRepository);

            Doctor? doct = new Doctor { Id = 1, Name = "Deva", Email = "Deva@gmail.com", Experience = 2, Phone = "8856904770", Speciality = "surgen", Pic = "-" };
            doctorRepository.Add(doct);

            var result = doctorService.UpdatePhone(new Doctor { Id = 1, Phone="885690477056" });
            var data = "885690477056";
            //Assert
            Assert.AreEqual(data, result.Phone);
        }
        #endregion

        #region Update Email
        [Test]
        public void UpdateEmailTest()
        {
            //Arrange
            IRepository<int, Doctor> doctorRepository = new DoctorRepository(context);

            IDoctorService doctorService = new DoctorService(doctorRepository);

            Doctor? doct = new Doctor { Id = 1, Name = "Deva", Email = "Deva@gmail.com", Experience = 2, Phone = "8856904770", Speciality = "surgen", Pic = "-" };
            doctorRepository.Add(doct);

            var result = doctorService.UpdateEmail(new Doctor { Id = 1, Email="abc@gmail.com" });
            var data = "abc@gmail.com";
            //Assert
            Assert.AreEqual(data, result.Email);
            
        }
        #endregion



    }
}
