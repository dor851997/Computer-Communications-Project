using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
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
            MoviesDal dal = new MoviesDal();
            MovieViewModel mvm = new MovieViewModel();
            List<Movie> movies = dal.Movies.ToList<Movie>();
            mvm.movieName = new Movie();
            mvm.Movies = movies;
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
            HallsDal hallDal = new HallsDal();
            Hall hall = new Hall();
            var sameHallname = dal.Movies.Any(x => x.Date == movie.Date && x.HallName == movie.HallName);
            var HallName = hallDal.Halls.Any(x => x.HallName == movie.HallName);
            var sameDate = dal.Movies.Any(x => x.Date == movie.Date);
            if (ModelState.IsValid)
            {
                if (sameDate == true)
                {
                    if(sameHallname == true)
                    {
                        TempData["MovieStatus"] = "There is a movie at the same date and hall.";
                        return RedirectToAction("AddMovie",movie);
                    }
                    else
                    {
                        if(HallName == false)
                        {
                            hall.HallName = movie.HallName;
                            hall.ColNumber = 10;
                            hall.RowNumber = 10;
                            hallDal.Halls.Add(hall);
                            hallDal.SaveChanges();
                        }
                        dal.Movies.Add(movie);
                        dal.SaveChanges();
                        
                    }
                }
                else
                {
                    if (HallName == false)
                    {
                        hall.HallName = movie.HallName;
                        hall.ColNumber = 10;
                        hall.RowNumber = 10;
                        hallDal.Halls.Add(hall);
                        hallDal.SaveChanges();
                    }
                    dal.Movies.Add(movie);
                    dal.SaveChanges();
                }
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
            MovieViewModel mvm = new MovieViewModel();
            MoviesDal dal = new MoviesDal();
            mvm.Movies = dal.Movies.ToList<Movie>();
            return View("ShowDetails", mvm);
        }
        public ActionResult ShowDetails(string movieName)
        {
            MoviesDal dal = new MoviesDal();
            MovieViewModel mvm = new MovieViewModel();
            mvm.movieName = dal.Movies.Find(movieName);
            mvm.Movies = dal.Movies.ToList<Movie>();
            //Movie editMovie = dal.Movies.Find(movieName);
            if (Request.Form["MovieName"] == null)
            {
                return RedirectToAction("MyPage", "Home");
            }
            return View(mvm);
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