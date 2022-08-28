using System;
using System.ComponentModel.DataAnnotations;

namespace Movies.Client.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Rating { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }
        public string ImageUrl { get; set; }

       
        public string Owner { get; set; }
    }
}
