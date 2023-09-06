using System.ComponentModel.DataAnnotations;

namespace DoctorApp.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public string PatientName { get; set; }

        public int Age { get; set; }

        public string PatientPhone { get; set; }

        public string PatientEmail { get; set; }

  
    }
}
