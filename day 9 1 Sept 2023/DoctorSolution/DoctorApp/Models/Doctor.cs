using System.ComponentModel.DataAnnotations;

namespace DoctorApp.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        public string DoctorName { get; set; }

        public int YearOfExp { get; set; }

        public string Speciality { get; set; }

        public string Doctorphone { get; set; }

        public string DoctorEmail { get; set; }

        public string? pic { get; set; }

       



    }
}
