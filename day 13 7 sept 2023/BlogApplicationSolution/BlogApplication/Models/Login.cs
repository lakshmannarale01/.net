using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User Id is manditory")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is manditory")]
        public string Password { get; set; }
    }
}
