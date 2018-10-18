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

        public MoviesController()
        {
            _context = new ApplicationDbContext();
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

        public ActionResult MovieForm()
        {
            var model = new MovieFormViewModel
            {
                GenreTypes = _context.GenreTypes.ToList()                
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var mov = _context.Movies.Where(m => m.Id == movie.Id).Select(m => m).FirstOrDefault();
                mov.Name = movie.Name;
                mov.ReleaseDate = movie.ReleaseDate;
                mov.DateAdded = movie.DateAdded;
                mov.GenreTypeId = movie.GenreTypeId;
                mov.NumberInStock = movie.NumberInStock;                
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index","Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.Where(m => m.Id == id).Select(m => m).FirstOrDefault();
            if (movie == null)
            {
                return new HttpNotFoundResult();
            }
            var model = new MovieFormViewModel
            {
                GenreTypes = _context.GenreTypes.ToList(),
                Movie =movie
            };
            return View("MovieForm", model);
        }
    }
}
