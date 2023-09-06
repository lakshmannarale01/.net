using HospitalClinicApp.contexts;
using HospitalClinicApp.Interfaces;
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
    public class PatientServiceTest
    {
        ClinicContexts context;
       
        
        [SetUp]
        public void Setup()
        {
            var dbContextOption = new DbContextOptionsBuilder<ClinicContexts>().UseInMemoryDatabase(databaseName: "dbDummyClinic").Options;
            context = new ClinicContexts(dbContextOption);
        }

        #region Add Patient
        [Test]
        public void AddTest()
        {

            // Arrange
            IRepository<int, Patient> patientRepository = new PatientRepository(context);

           IPatientService patientService = new PatientService(patientRepository);


            //Action
            var pat = new Patient {Id = 1 , Name = "Deva", Email = "Deva@gmail.com" , Age=22 , Phone="8856904770" };
            var result = patientService.Add(pat);
            var data = new Patient { Id = 1, Name = "Deva", Email = "Deva@gmail.com", Age = 22, Phone = "8856904770" };

            //Assert
            Assert.AreEqual(data.Id, result.Id);
        }
        #endregion


        #region GeatAllPatient
        [Test]
        public void GetAllPatientTest()

        
        {
            // Arrange
            IRepository<int, Patient> patientRepository = new PatientRepository(context);

            IPatientService patientService = new PatientService(patientRepository);

            Patient? patient = new Patient { Id = 1, Name = "Deva", Email = "Deva@gmail.com", Age = 22, Phone = "8856904770" };
            patientRepository.Add(patient);

            //Action
            var result = patientService.GetAllPatient();

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(1, result.Count);


        }
        #endregion

        #region
        [Test]
        public void UpdatePatientTest()
        {

            // Arrange
            IRepository<int, Patient> patientRepository = new PatientRepository(context);

            IPatientService patientService = new PatientService(patientRepository);


            //Action
            var pat = new Patient { Id = 1, Name = "Deva", Email = "Deva@gmail.com", Age = 22, Phone = "8856904770" };
            patientService.Add(pat);

            Patient? result = patientService.UpdatePatient(new Patient { Id = 1, Name = "lakshman", Email = "xyz@gmail.com", Age = 2, Phone = "7972051076" });

            var data = new Patient { Id = 1, Name = "lakshman", Email = "xyz@gmail.com", Age = 2, Phone = "7972051076" };

            //Assert
            Assert.AreEqual(data,result);
        }
#endregion
    }
}
