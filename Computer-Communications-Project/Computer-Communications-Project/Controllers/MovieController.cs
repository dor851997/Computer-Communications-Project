using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;

namespace Computer_Communications_Project.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Movie()
        {
            return View();
        }

        public ActionResult ManageMovie()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddMovie()
        {
            return View("AddMovie");
        }

        [HttpPost]
        public ActionResult AddMovie(Movie movie)
        {
            MoviesDal dal = new MoviesDal();
            //var movieIsAlreadyExists = dal.Movies.Any(x => x.MovieName == movie.MovieName);
            //var sameHall = dal.Movies.Any(x => x.MovieName == movie.MovieName);
            if (ModelState.IsValid)
            {
                dal.Movies.Add(movie);
                dal.SaveChanges();
                return RedirectToAction("MyPage", "Home");
            }
            return View("AddMovie", movie);
        }
    }
}