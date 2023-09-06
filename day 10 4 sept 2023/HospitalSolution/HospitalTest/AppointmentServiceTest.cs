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
    internal class AppointmentServiceTest
    {

        ClinicContexts context;


        [SetUp]
        public void Setup()
        {
            var dbContextOption = new DbContextOptionsBuilder<ClinicContexts>().UseInMemoryDatabase(databaseName: "dbDummyClinic").Options;
            context = new ClinicContexts(dbContextOption);
        }

        #region Add appointment
        [Test]
        public void checkAvalibilityTest()
        {

            // Arrange
            IRepository<int, Appointment> appointmentRepository = new AppointmentRepository(context);
            DateTime dt2 = new DateTime(2023, 06, 7, 5, 10, 20);


            //Action
            Appointment appointment = (new Appointment { AppointmentNumber = 1, PatientId = 1, DoctorId = 1, AppointmentDateTime = dt2 });

            appointmentRepository.Add(appointment);
            IAppointmentService appointmentservice = new AppointmentService(appointmentRepository);

            var result = new Appointment { AppointmentNumber = 1, PatientId = 1, DoctorId = 1, AppointmentDateTime = dt2 };

            //Assert
            Assert.NotNull(appointment.AppointmentDateTime);

        }
        #endregion


        #region Add
        [Test]
        public void AddTest()
        {
            // Arrange
            IRepository<int, Appointment> appointmentRepository = new AppointmentRepository(context);
            DateTime dt2 = new DateTime(2023, 06, 7, 5, 10, 20);


            //Action
            Appointment appointment = (new Appointment { AppointmentNumber = 1, PatientId = 1, DoctorId = 1, AppointmentDateTime = dt2 });

            appointmentRepository.Add(appointment);
            IAppointmentService appointmentservice = new AppointmentService(appointmentRepository);

            var result = new Appointment { AppointmentNumber = 1, PatientId = 1, DoctorId = 1, AppointmentDateTime = dt2 };

            //Assert
            Assert.AreEqual(result,appointment);
        }

        #endregion


        #region cancel appointment

        [Test]
        public void cancelAppointmentTest()
        {

            // Arrange
            IRepository<int, Appointment> appointmentRepository = new AppointmentRepository(context);
            DateTime dt2 = new DateTime(2023, 06, 7, 5, 10, 20);


            //Action
            Appointment appointment = (new Appointment { AppointmentNumber = 1, PatientId = 1, DoctorId = 1, AppointmentDateTime = dt2 });

            appointmentRepository.Add(appointment);

            IAppointmentService appointmentservice = new AppointmentService(appointmentRepository);

            Appointment result = appointmentRepository.Delete(appointment.AppointmentNumber=1);

            //Assert
            Assert.IsNotNull(result);

        }
        #endregion



    }
}
