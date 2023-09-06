using HospitalClinicApp.Models;
using HospitalClinicApp.Models.DTO;

namespace HospitalClinicApp.Interfaces
{
    public interface IAppointmentService : IAddingEntity<Appointment>
    {
        public Appointment Add(Appointment entity);
        public bool CheckAvailability(AppointmentCheckDTO appointment);

        public Appointment cancelAppointment(Appointment appointment);
        public IList<Appointment> GetAll();
    }
}
