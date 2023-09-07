using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.Models
{
    public class BlogPost
    {
        [Key]
        public int BlogPostId { get; set; }
        [Required(ErrorMessage ="Title Name Is Mandatory")]
        public string Title { get; set; }

        public string BPost { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int TagId { get; set; }
        [ForeignKey("TagId")]
        public CategoryTag CategoryTag { get; set; }

        public ICollection<CategoryTag> Tags { get; set; }
    }
}
