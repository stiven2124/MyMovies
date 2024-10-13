using MyMovies.Data.enums;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace MyMovies.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Genre Genre { get; set; }
        public float? AverageRating { get; set; } = null;

        public int RatingCount { get; set; } = 0;
        public float RatingSum { get; set; } = 0;
    }
}
