using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyMovies.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("MovieId")]
        public int MovieId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
