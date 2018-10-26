using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //Get Movies api/movies
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        //Get Movie api/movies/1
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m=>m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return movie;
        }

        [HttpPost]
        // Add Movie api/movies
        public Movie CreateMovie()
        {
            return new Movie();
        }

        [HttpPut]
        //Update Movie api/movies
        public void UpdateMovie()
        {

        }

        [HttpDelete]
        //Delete Movie api/movies
        public void DeleteMovie()
        {

        }
    }
}
