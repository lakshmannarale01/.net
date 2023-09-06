using HospitalClinicApp.contexts;
using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Models.DTO;
using HospitalClinicApp.Models;
using HospitalClinicApp.Repositories;
using HospitalClinicApp.Services;
using Microsoft.EntityFrameworkCore;

namespace HospitalTest
{
    public class LoginServiceTest
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
        public void LoginTest()
        {
            //Arrange
            IRepository<int, Patient> patientRepository = new PatientRepository(context);
            var patient = new Patient { Id = 1, Name = "Jim", Age = 22, Phone = "3435345636", Email = "jim@gmail.com" };
            patientRepository.Add(patient);
            ILoginService loginService = new LoginService(patientRepository);
            //Action
            var result = loginService.Login(new LoginDTO { Id = 1, Password = "3435345636" });
            //Assert
            Assert.AreEqual(1, result.Id);
        }
        #endregion
    }
}