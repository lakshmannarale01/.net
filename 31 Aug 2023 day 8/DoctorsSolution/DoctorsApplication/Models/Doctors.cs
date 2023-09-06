using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsApplication.Models
{
    public class Doctors
    {
        [Key] 
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public float Salary { get; set; }
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

       
    }
}
