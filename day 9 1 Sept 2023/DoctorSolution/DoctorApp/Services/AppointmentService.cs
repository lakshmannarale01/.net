using DoctorApp.Exceptions;
using DoctorApp.Exceptions.PatientException;
using DoctorApp.Interfaces;
using DoctorApp.Models;
using DoctorApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DoctorApp.Services
{
    public class AppointmentService : IManageAppointmentService
    {
        private readonly IRepository<int, Appointment> _repository;
        private readonly IRepository<int, Doctor> _DRepository;
        private readonly IRepository<int, Patient> _PRepository;

        //static List<Doctor> doctors = new List<Doctor>();
        public AppointmentService(IRepository<int, Appointment> repository , IRepository<int , Doctor>repository1 , IRepository<int , Patient>repository2)
        {
            _repository = repository;
            _DRepository=repository1;
            _PRepository=repository2;
        }
        public Appointment BookAppointment(Appointment appointment)
        {
            bool book = CheckAvailability(appointment);
            if (book== true)
            {
                _repository.Add(appointment);
                return appointment;
            }
            else
            {
                throw new DoctorNotAvailableException();
            }
        }

     public Appointment cancelAppointment(Appointment appointment) 
        {
            var dAppointment = _repository.GetById(appointment.AppointmentNumber);
            if(dAppointment == null)
            {
                throw new InvalidPatientException();
            }
            dAppointment = _repository.Delete(dAppointment.AppointmentNumber);
            return dAppointment;
        }

        public bool CheckAvailability(Appointment appointment)
        {
            if(appointment != null)
            {
                Doctor details = _DRepository.GetById(appointment.DoctorId);
                if(details != null) 
                {
                    var appointments = _repository.GetAll();
                    var existingAppointment = appointments.Where(D => D.DoctorId == appointment.DoctorId
                    && D.DateTime == appointment.DateTime).ToList();
                    if(existingAppointment == null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    throw new InvalidDoctorExceptions();
                }
            }
            throw new InvalidDoctorExceptions();

        }
    }
}
