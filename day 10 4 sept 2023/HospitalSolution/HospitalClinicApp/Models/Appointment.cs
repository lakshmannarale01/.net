using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalClinicApp.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentNumber { get; set; }
        [Required(ErrorMessage = "Patient details are manditory")]
        public int PatientId { get; set; }
        [Required(ErrorMessage = "Doctor details are manditory")]
        public int DoctorId { get; set; }
        [Required(ErrorMessage = "Plaease choose a date and time")]
        public DateTime AppointmentDateTime { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }

        public override bool Equals(object? obj)
        {
            Appointment a1, a2;
            a1 = (Appointment)obj;
            a2 = this;
            if (a1.AppointmentNumber == a2.AppointmentNumber)
                return true;
            return false;
        }
    }
}