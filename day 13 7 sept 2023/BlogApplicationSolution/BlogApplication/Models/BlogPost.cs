using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogApplication.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Title Name Is Mandatory")]
        public string Title { get; set; }

        public string BPost { get; set; }

        public DateTime Post_Publish_DateTime { get; set; }

        [Required(ErrorMessage = "Mandatory Field! Can't be blank.")]
        public string AuthorsName { get; set; }
        //[ForeignKey("AuthorsName")]
        //public Author? Author { get; set; }

        //public int AuthorId { get; set; }

        //[ForeignKey("AuthorId")]
        //public Author? Author { get; set; }

        //public int TagId { get; set; }
        //[ForeignKey("TagId")]
        //public CategoryTag? CategoryTag { get; set; }

        public ICollection<CategoryTag>? Tags { get; set; }
    }
}
