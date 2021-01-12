using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }
    }
}