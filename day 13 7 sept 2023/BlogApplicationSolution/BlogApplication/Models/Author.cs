using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models
{
    public class Author
    {
        [Key] 
          public int Id { get; set; }
        [Required(ErrorMessage ="AuthorName is Mandatory")]
        public string AuthorsName { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Mandatory Field,Can't be blank!")]
        [RegularExpression(@"^(\+91[\-\s]?)?[0]?(91)?[789]\d{9}$", ErrorMessage = "Invalid phone number")]
        public string Phone { get; set; }

        public string Description { get; set; }

        public string? Pic {get; set; }
        



    }
}
    