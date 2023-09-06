using System.ComponentModel.DataAnnotations;

namespace DoctorsApplication.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public ICollection<Doctors> doctor { get; set; }
    }
}
