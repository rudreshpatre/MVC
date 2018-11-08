using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public GenreType Genre { get; set; }

        public int GenreTypeId { get; set; }

        public GenreTypeDto GenreType { get; set; }

        public DateTime ReleaseDate { get; set; }
        
        public DateTime DateAdded { get; set; }
               
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }

        public MovieDto()
        {
            GenreType = new GenreTypeDto();
        }
    }
}