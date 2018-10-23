using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public GenreType Genre { get; set; }

        public int GenreTypeId { get; set; }

        [Display(Name="Date of Release")]
        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1,20,ErrorMessage ="You can only enter values between 1 and 20.")]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }
    }
}