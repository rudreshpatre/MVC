using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using Vidly.Dtos;
using System.Data.Entity;

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
        public IEnumerable<MovieDto> GetMovies()
        {
            //we use include to initialise navigation properties.
            var moviesInDb = _context.Movies.Include(m=>m.Genre).ToList();
            var movies = new List<MovieDto>();
            // manual mapping instead of using automapper like in case of customers.
            foreach(var movieinDB in moviesInDb)
            {
                var movie = new MovieDto();
                movie.Id = movieinDB.Id;
                movie.Name = movieinDB.Name;
                movie.GenreType.Id = movieinDB.Genre.Id;
                movie.GenreType.Name =movieinDB.Genre.Name;
                movie.ReleaseDate = movieinDB.ReleaseDate;
                movie.NumberInStock = movieinDB.NumberInStock;
                movies.Add(movie);
            }
            return movies;
        }

        //Get Movie api/movies/1
        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return movie;
        }

        [HttpPost]
        // Add Movie api/movies
        public Movie CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie;
        }

        [HttpPut]
        //Update Movie api/movies
        public void UpdateMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.GenreTypeId = movie.GenreTypeId;
            movieInDb.NumberInStock = movie.NumberInStock;
            _context.SaveChanges();
        }

        [HttpDelete]
        //Delete Movie api/movies
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Movies.Remove(movieInDb); _context.SaveChanges();
        }
    }
}
