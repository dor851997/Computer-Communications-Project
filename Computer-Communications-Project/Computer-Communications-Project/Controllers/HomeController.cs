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
            List<Movie> movies = dal.Movies.ToList<Movie>();
            MovieViewModel MyMovieModel = new MovieViewModel();
            MyMovieModel.Movies = movies;
            return View(MyMovieModel);
        }

    }
}