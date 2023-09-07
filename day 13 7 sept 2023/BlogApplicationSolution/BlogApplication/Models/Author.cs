using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models
{
    public class Author
    {
        [Key]
          public int AuthorId { get; set; }
        [Required(ErrorMessage ="AuthorName is Mandatory")]
        public string AuthorsName { get; set; }

        [RegularExpression(@"^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        public string Description { get; set; }

        public string? Pic {get; set; }
        



    }
}
    