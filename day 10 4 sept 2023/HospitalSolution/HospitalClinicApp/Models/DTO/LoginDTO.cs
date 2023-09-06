using System.ComponentModel.DataAnnotations;

namespace HospitalClinicApp.Models.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "User Id is manditory")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Password is manditory")]
        public string Password { get; set; }
    }
}
