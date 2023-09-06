using System.ComponentModel.DataAnnotations;



namespace EmployeeLoginApplication.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Employee name is manditory")]
        public string Name { get; set; }



        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }



        [Required(ErrorMessage = "Employee's phone number is manditory")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }



        [Required(ErrorMessage = "Department name is manditory")]
        public string DeptName { get; set; }
        public string Pic { get; set; }



    }
}
