using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;
using Computer_Communications_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            else if(CategorySelect == "null")
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
            if (PriceSelect == "null")
            {
                movies = dal.Movies.ToList<Movie>();
            }
            else if(PriceSelect == "price-increase")
            {
                movies = dal.Movies.OrderByDescending(m => m.Price).ToList();

            }
            else if(PriceSelect == "price-decrease")
            {
                movies = dal.Movies.OrderBy(m => m.Price).ToList();
            }
            else if(PriceSelect == "onsale")
            {
                movies = dal.Movies.Where(m => m.Discount > 0).ToList();
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
            List<Movie> movies;
            MoviesDal dal = new MoviesDal();
            movies = dal.Movies.ToList<Movie>();
            MovieViewModel MyMovieModel = new MovieViewModel();
            if (dateSelect == "")
            {

                MyMovieModel.Movies = movies;
                return View("MyPage", MyMovieModel);
            }
            DateTime dateS = Convert.ToDateTime(dateSelect);
            if (dateSelect != null)
            {
                movies = movies.Where(m => m.Date.Date == dateS.Date).ToList();
            }
            MyMovieModel.Movies = movies;
            return View("MyPage", MyMovieModel);
        }
    }
}