using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DoctorsApplication.Models
{
    public class Patient
    {

        [Key]
        public string IdentityNo { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int AppointmentID { get; set; }
       
        [ForeignKey("AppointmentID")]

        public Appoitment appoitment { get; set; }


        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctors Doctor { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
