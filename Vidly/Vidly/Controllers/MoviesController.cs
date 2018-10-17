using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;
        // GET: Movies/Random

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
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
            MoviesViewModel model = new MoviesViewModel()
            {
                Movies = _context.Movies.Include(m=>m.Genre).ToList()
            };            
            return View(model);
        }

        [Route("Movies/Details/{id}")]
        public ActionResult Details(int id)
        {
            var model = new MovieDetailsViewModel
            {
                MovieDetails = _context.Movies.Include(m=>m.Genre).Where(m=>m.Id == id).Select(m=>m).FirstOrDefault()
            };
            return View(model);
        }

    }
}
