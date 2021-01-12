using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;
using Computer_Communications_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Communications_Project.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyPage()
        {
            MoviesDal dal = new MoviesDal();
            MovieViewModel uvm = new MovieViewModel();
            if (Request.Form["MovieName"] == null)
            {
                return RedirectToAction("MyPage", "Home");
            }
            string searchVal = Request.Form["MovieName"].ToString();
            List<Movie> objMovies = (from x in dal.Movies
                                   where x.MovieName.Contains(searchVal)
                                   select x).ToList<Movie>();
            Movie objMovie = new Movie();
            objMovie.MovieName = searchVal;
            uvm.movieName = objMovie;
            uvm.Movies = objMovies;
            return View(uvm);

           
        }

    }
}