using System.ComponentModel.DataAnnotations;

namespace SamuraiMovieDB.Models
{
    public class Movie
    {
        [Key] //indicates primary key
        public int Id { get; set; }

        [Required]
        [StringLength(100)] //max length of 100 characters
        public required string Name { get; set; }

        [Required]
        [Range(1900, 2100)] //between years 1900 and 2100
        public int Year { get; set; }

        public string? Director { get; set; } //? Indicates optionals

        [Required]
        public bool Color { get; set; }

        [StringLength(2000)]
        public string? Description { get; set; }
    }
}