using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;
using System.Web.Mvc;

namespace Computer_Communications_Project.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult addOrder(string movieName)
        {
            MoviesDal dal = new MoviesDal();
            Movie editMovie = dal.Movies.Find(movieName);
            editMovie.Price = editMovie.Price - editMovie.Discount;
            return View(editMovie);
        }
    }
}