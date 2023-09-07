using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models
{
    public class Login
    {
        [Required(ErrorMessage = "User Id is manditory")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Password is manditory")]
        public string Password { get; set; }
    }
}
