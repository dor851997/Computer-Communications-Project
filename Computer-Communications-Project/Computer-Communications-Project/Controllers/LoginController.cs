using Computer_Communications_Project.Classes;
using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Computer_Communications_Project.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            if (Session["loggedOn"] == null)
            {
                Session["LogoutStatus"] = null;
                return View(new User());
            }
            return RedirectToAction("MyPage", "Home");
        }
        public ActionResult SubmitLogin(User user)
        {
            UsersDal dal = new UsersDal();
            List<User> users = dal.Users.ToList<User>();
            Encryption enc = new Encryption();
            bool exists = false;
            foreach (User u in users)
            {
                if (u.UserName == user.UserName && enc.ValidatePassword(user.Password, u.Password))
                {
                    exists = true;
                    break;
                }
            }
            if (exists == true)
            {
                FormsAuthentication.SetAuthCookie("cookie", true);
                Session["username"] = user.UserName;
                Session["loggedOn"] = "true";
                TempData["LoginStatus"] = null;
                Session["userType"] = "user";
                return RedirectToAction("MyPage", "Home");
            }
            else
            {
                TempData["LoginStatus"] = "Username or Password are incorrect.";
                return View("SubmitLogin", user);
            }
        }
    }
}