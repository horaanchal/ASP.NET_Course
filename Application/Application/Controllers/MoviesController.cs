using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.ViewModels;
using Application.Models;

namespace Application.Controllers
{
    public class MoviesController : Controller
    {
        private MyDBContext _context;

        public MoviesController()
        {
            _context = new MyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ViewResult Index()
        {
           // var movies = GetMovies();
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);
        }

        //private IEnumerable<Movie> GetMovies()
            public ActionResult Details(int id)
        {
            //return new List<Movie>
            //{
            //  new Movie { Id = 1, Name = "Shrek" },
            //  new Movie { Id = 2, Name = "Wall-e" }
            //};
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }



        // GET: Movies/Random
        //public ActionResult Random()
           
        //[Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        //public ActionResult ByReleaseDate( int year, int month)
        //{
           // return Content(year + "/" + month);
        //}
        //{
           // var movie = new Movie()
            //{
                //Name = "Hush!"
            //};
           // var customers = new List<Customer>
           // {
             //   new Customer {Name="Customer 1"},
              //  new Customer {Name="Customer 2"}
            //};
            //var viewModel = new RandomMovieViewModel
            //{
              //  Movie = movie,
               // Customers = customers
           // };
            //var viewResult = new ViewResult();
            //viewResult.ViewData.Model
            //ViewData["RandomMovie"] = movie;
            //ViewBag.RandomMovie = movie;
            //return View(viewModel);
            //return Content("Hello People!");
            //return HttpNotFound();
            //return new EmptyResult();
           // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        //}
        //public ActionResult Edit(int id)
        //{
            //return Content("id=" + id);
        //}
        //movies
        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
           // if (!pageIndex.HasValue)
                //pageIndex = 1;
            //if (String.IsNullOrWhiteSpace(sortBy))
                //sortBy = "Name";
            //return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        //}
    }
}