using System.ComponentModel.DataAnnotations;

namespace NumberExercise.Models
{
    public class NumberFromUser
    {
        [MinLength(10, ErrorMessage = "Invalid Array Length")]
        [MaxLength(10, ErrorMessage = "Invalid Array Length")]
        public int[] Numbers { get; set; }
    }
}
