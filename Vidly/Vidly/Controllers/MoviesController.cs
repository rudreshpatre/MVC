using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random

        public ActionResult Random()
        {
            var movie = new Movie()
            {
                Name = "Shrek!"
            };

            var customers = new List<Customer>()
            {
                new Customer{ Id = 1,Name = "Rudresh" },
                new Customer{ Id =2,Name="Arun"}          
            };

            var randomMoviesViewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            }; 
            return View(randomMoviesViewModel);
        }

        [Route("movies/Edit/{id}/{name}")]
        public ActionResult Edit(int id,string name)
        {
            return Content($"id={id} name={name}");
        }

        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year+"/"+month);
        }

        public ActionResult Index()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie{Id =1,Name="Shawshank Redemption" },
                new Movie{Id=2,Name ="Kal Ho Na Hos" }
            };

            MoviesViewModel model = new MoviesViewModel()
            {
                Movies = movies
            };
            
            return View(model);
        } 

    }
}
