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

        public ActionResult MyPage(string CategorySelect)
        {
            List<Movie> movies;
            MoviesDal dal = new MoviesDal();
            if (CategorySelect == null)
            {
                movies = dal.Movies.ToList<Movie>();
            }
            else
            {
                movies = dal.Movies.Where(m => m.Category == CategorySelect).ToList();
            }
            MovieViewModel MyMovieModel = new MovieViewModel();
            MyMovieModel.Movies = movies;
            return View(MyMovieModel);
        }

        public ActionResult priceAction(string PriceSelect)
        {
            List<Movie> movies;
            MoviesDal dal = new MoviesDal();
            movies = dal.Movies.ToList<Movie>();
            if(PriceSelect == "price-increase")
            {
                movies = dal.Movies.OrderByDescending(m => m.Price).ToList();

            }
            else if(PriceSelect == "price-decrease")
            {
                movies = dal.Movies.OrderBy(m => m.Price).ToList();
            }
            else
            {
                movies = dal.Movies.OrderByDescending(m => m.Rating).ToList();
            }
            MovieViewModel MyMovieModel = new MovieViewModel();
            MyMovieModel.Movies = movies;
            return View("MyPage" ,MyMovieModel);
        }
        public ActionResult dateAction(string dateSelect)
        {
            DateTime dateS = Convert.ToDateTime(dateSelect);
            List<Movie> movies;
            MoviesDal dal = new MoviesDal();
            movies = dal.Movies.ToList<Movie>();
            if(dateSelect != null)
            {
                movies = movies.Where(m => m.Date.Date == dateS.Date).ToList();
            }
            MovieViewModel MyMovieModel = new MovieViewModel();
            MyMovieModel.Movies = movies;
            return View("MyPage", MyMovieModel);
        }
    }
}