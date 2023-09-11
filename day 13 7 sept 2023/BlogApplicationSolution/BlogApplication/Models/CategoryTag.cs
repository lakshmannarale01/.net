using System.ComponentModel.DataAnnotations;

namespace BlogApplication.Models
{
    public class CategoryTag
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Category Tag is mandatory")]
        public string TagTitle { get; set; }
    }
}
