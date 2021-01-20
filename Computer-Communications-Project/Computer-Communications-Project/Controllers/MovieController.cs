using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;
using Computer_Communications_Project.ViewModel;

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
            MovieViewModel mvm = new MovieViewModel();
            mvm.movieName = new Movie();
            mvm.Movies = new List<Movie>();
            return View("SearchMovie", mvm);
        }

        public ActionResult SearchMovie()
        {
            MoviesDal dal = new MoviesDal();
            MovieViewModel mvm = new MovieViewModel();
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
            mvm.movieName = objMovie;
            mvm.Movies = objMovies;
            return View(mvm);
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
        public ActionResult Delete(string movieName)
        {
            MoviesDal dal = new MoviesDal();
            Movie objMovie = new Movie();
            if (movieName != "")
            {
                objMovie = (from x in dal.Movies
                            where x.MovieName == movieName
                            select x).Single<Movie>();
            }
            else
            {
                return RedirectToAction("MyPage", "Home");
            }
            dal.Movies.Remove(objMovie);
            dal.SaveChanges();
            return RedirectToAction("MyPage", "Home");
        }
        public ActionResult EditMovie()
        {
            Movie movie = new Movie();
            return View("ShowDetails", movie);
        }
        public ActionResult ShowDetails(string movieName)
        {
            MoviesDal dal = new MoviesDal();
            Movie editMovie = dal.Movies.Find(movieName);
            if (Request.Form["MovieName"] == null)
            {
                return RedirectToAction("MyPage", "Home");
            }
            return View(editMovie);
        }
        public ActionResult Edit(Movie movie)
        {
            MoviesDal dal = new MoviesDal();
            Movie objMovie = (from x in dal.Movies
                        where x.MovieName == movie.MovieName
                        select x).Single<Movie>();
            dal.Movies.Remove(objMovie);
            dal.Movies.Add(movie);
            dal.SaveChanges();
            return RedirectToAction("EditMovie");
        }
    }
}