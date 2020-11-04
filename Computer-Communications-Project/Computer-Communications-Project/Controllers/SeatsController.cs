using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Computer_Communications_Project.Controllers
{
    public class SeatsController : Controller
    {
        // GET: Seats
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Seats()
        {
            return View();
        }
    }
}