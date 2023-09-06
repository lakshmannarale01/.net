using DoctorApp.Models;

namespace DoctorApp.Interfaces
{
    public interface IManageAppointmentService
    {
        Appointment BookAppointment(Appointment appointment);

        public Appointment cancelAppointment(Appointment appointment);
        bool CheckAvailability(Appointment appointment);
    }
}
