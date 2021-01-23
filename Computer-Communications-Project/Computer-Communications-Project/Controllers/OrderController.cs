using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;
using Computer_Communications_Project.ViewModel;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.totalVal = 0;
            MoviesDal dal = new MoviesDal();
            Movie editMovie = dal.Movies.Find(movieName);
            HallsDal halldal = new HallsDal();
            Hall hall = halldal.Halls.Find(editMovie.HallName);
            HallAndMovie hmvm = new HallAndMovie();
            OrdersDal odal = new OrdersDal();
            List<Order> objOrders = odal.Orders.Where(m => m.Date == editMovie.Date && m.HallName == hall.HallName && m.MovieName == editMovie.MovieName).ToList();
            hmvm.Orders = objOrders;
            editMovie.Price = editMovie.Price - editMovie.Discount;
            hmvm.Movie = editMovie;
            hmvm.Hall = hall;
            return View(hmvm);
        }
        public ActionResult payment()
        {
            return View();
        }
    }
}