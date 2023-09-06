using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace DoctorsApplication.Models
{
    public class Appoitment
    {
        [Key] 
        public int AppointmentID { get; set; }
        public Patient Patient { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department department { get; set; }

        public int DoctorId { get; set; }

        [ForeignKey ("DoctorId")]
        public Doctors Doctor { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
