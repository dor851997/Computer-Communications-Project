using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Computer_Communications_Project.Models;
using Computer_Communications_Project.DAL;
using System.Data.Entity.Infrastructure;

namespace Computer_Communications_Project.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            if (Session["userType"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new User());
        }

        public ActionResult SubmitRegister(User user)
        {
            UsersDal dal = new UsersDal();
            if (ModelState.IsValid)
            {
                    dal.Users.Add(user);
                    dal.SaveChanges();
                    TempData["LoginStatus"] = null;
                return RedirectToAction("MyPage", "Home");
            }
            return View("Register", user);
        }
    }
}