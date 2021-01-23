using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;
using Computer_Communications_Project.ViewModel;
using System;
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
            Order order = new Order();
            List<Order> objOrders = odal.Orders.Where(m => m.Date == editMovie.Date && m.HallName == hall.HallName && m.MovieName == editMovie.MovieName).ToList();
            hmvm.Orders = objOrders;
            hmvm.order = order;
            editMovie.Price = editMovie.Price - editMovie.Discount;
            hmvm.Movie = editMovie;
            hmvm.Hall = hall;
            Session["hmvm"] = hmvm;
            return View(hmvm);
        }
        public ActionResult payment()
        {
            int line = Int32.Parse(Request.Form["line"]);
            int chair = Int32.Parse(Request.Form["chair"]);
            OrdersDal odal = new OrdersDal();
            HallAndMovie obj = (HallAndMovie)Session["hmvm"];
            obj.order.LineSeat = line;
            obj.order.RowSeat = chair;
            obj.order.HallName = obj.Movie.HallName;
            obj.order.MovieName = obj.Movie.MovieName;
            obj.order.Price = obj.Movie.Price;
            obj.order.Date = obj.Movie.Date;
            obj.order.OrderID = 0;
            odal.Orders.Add(obj.order);
            odal.SaveChanges();
            return View(obj);
        }
    }
}