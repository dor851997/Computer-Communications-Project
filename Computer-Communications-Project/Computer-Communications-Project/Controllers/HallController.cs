using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;
using Computer_Communications_Project.ViewModel;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Computer_Communications_Project.Controllers
{
    public class HallController : Controller
    {
        // GET: Seats
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EditHall()
        {
            HallViewModel hvm = new HallViewModel();
            HallsDal dal = new HallsDal();
            hvm.Halls = dal.Halls.ToList<Hall>();
            return View("ShowDetails", hvm);
        }
        public ActionResult ShowDetails(string hallName)
        {
            HallsDal dal = new HallsDal();
            HallViewModel hvm = new HallViewModel();
            hvm.Hall = dal.Halls.Find(hallName);
            hvm.Halls = dal.Halls.ToList<Hall>();
            //Hall editHall = dal.Halls.Find(hallName);
            if (Request.Form["HallName"] == null)
            {
                return RedirectToAction("MyPage", "Home");
            }
            return View(hvm);
        }
        public ActionResult Edit(Hall hall)
        {
            HallsDal dal = new HallsDal();
            Hall objHall = (from x in dal.Halls
                              where x.HallName == hall.HallName
                              select x).Single<Hall>();
            dal.Halls.Remove(objHall);
            dal.Halls.Add(hall);
            dal.SaveChanges();
            return RedirectToAction("EditHall");
        }
    }
}