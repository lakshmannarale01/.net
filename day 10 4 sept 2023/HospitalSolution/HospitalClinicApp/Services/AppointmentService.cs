using HospitalClinicApp.Interfaces;
using HospitalClinicApp.Models.DTO;
using HospitalClinicApp.Models;
using HospitalClinicApp.Utilities;
using NuGet.Protocol.Core.Types;

namespace HospitalClinicApp.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IRepository<int, Appointment> _appointmentRepository;

        public AppointmentService(IRepository<int, Appointment> repository)
        {
            _appointmentRepository = repository;
        }
        public Appointment Add(Appointment entity)
        {
            AppointmentCheckDTO appointmentDto = new AppointmentCheckDTO
            {
                AppointmentDateTime = entity.AppointmentDateTime,
                DoctorId = entity.DoctorId
            };
            if (CheckAvailability(appointmentDto) == true)
            {
                var appointment = _appointmentRepository.Add(entity);
                return appointment;
            }
            throw new DoctorNotFreeException();
        }

        public bool CheckAvailability(AppointmentCheckDTO appointment)
        {
            try
            {
                var appointmnets = _appointmentRepository.GetAll();

                var checkAppointment = appointmnets
                    .FirstOrDefault(a => a.DoctorId == appointment.DoctorId && a.AppointmentDateTime == appointment.AppointmentDateTime);
                return checkAppointment == null;
            }
            catch (DoctorNotFreeException e)
            {
                return true;
            }
            catch (NoEntriesAvailable e)
            {
                return true;
            }

        }

        public IList<Appointment> GetAll()
        {
            return _appointmentRepository.GetAll().ToList();
        }
        public Appointment cancelAppointment(Appointment appointment)
        {
            var dAppointment = _appointmentRepository.GetById(appointment.AppointmentNumber);
            if (dAppointment == null)
            {
                throw new NoEntriesAvailable("Doctor");
            }
            dAppointment = _appointmentRepository.Delete(dAppointment.AppointmentNumber);
            return dAppointment;
        }
    }
}
