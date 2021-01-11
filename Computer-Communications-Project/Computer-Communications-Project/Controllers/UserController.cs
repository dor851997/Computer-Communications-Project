using Computer_Communications_Project.Classes;
using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Models;
using Computer_Communications_Project.ViewModel;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Computer_Communications_Project.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            if (Session["userType"] != null)
            {
                return RedirectToAction("MyPage", "Home");
            }
            return View(new User());
        }
        public ActionResult SubmitRegister(User user)
        {
            Encryption enc = new Encryption();
            UsersDal dal = new UsersDal();
            if (ModelState.IsValid)
            {
                var isUserAlreadyExists = dal.Users.Any(x => x.UserName == user.UserName);
                string hashedPassword = enc.CreateHash(user.Password);
                if (isUserAlreadyExists)
                {
                    TempData["LoginStatus"] = "Username already exists.";
                    return View("Register", user);
                }
                user.Password = hashedPassword;
                dal.Users.Add(user);
                dal.SaveChanges();
                TempData["LoginStatus"] = null;
                return RedirectToAction("MyPage", "Home");
            }
            return View("Register", user);
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

        public ActionResult AdminLogin()
        {
            if (Session["loggedOn"] == null)
            {
                Session["LogoutStatus"] = null;
                return View(new Admin());
            }
            return RedirectToAction("Logout", "User");
        }

        public ActionResult Logout()
        {
            if (Session["loggedOn"] == null)
            {
                Session["LogoutStatus"] = "No user is logged on.";
            }
            return View();
        }
        public ActionResult LogoutAction()
        {
            Session["username"] = null;
            Session["loggedOn"] = null;
            Session["LogoutStatus"] = null;
            Session["userType"] = null;
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

        public ActionResult SubmitAdminLogin(Admin user)
        {
            AdminsDal dal = new AdminsDal();
            List<Admin> users = dal.Users.ToList<Admin>();
            Encryption enc = new Encryption();
            bool exists = false;
            foreach (Admin u in users)
                if (u.UserName == user.UserName && enc.ValidatePassword(user.Password, u.Password))
                {
                    exists = true;
                    break;
                }
            if (exists == true)
            {
                FormsAuthentication.SetAuthCookie("cookie", true);
                Session["username"] = user.UserName;
                Session["loggedOn"] = "true";
                Session["userType"] = "admin";
                TempData["LoginStatus"] = null;
                return RedirectToAction("MyPage", "Home");
            }
            else
            {
                TempData["LoginStatus"] = "Username or Password are incorrect.";
                return View("SubmitAdminLogin", user);
            }
        }
        public ActionResult AdminTools()
        {
            if (Session["userType"] == null || Session["userType"].ToString() != "admin")
            {
                return RedirectToAction("MyPage", "Home");
            }
            return View();
        }
        public ActionResult ManageUsers()
        {
            UserViewModel uvm = new UserViewModel();
            uvm.user = new User();
            uvm.users = new List<User>();
            return View("SearchUser", uvm);
        }

        public ActionResult SearchUser()
        {
            UsersDal dal = new UsersDal();
            UserViewModel uvm = new UserViewModel();
            if (Request.Form["username"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            string searchVal = Request.Form["username"].ToString();
            List<User> objUsers = (from x in dal.Users
                                   where x.UserName.Contains(searchVal)
                                   select x).ToList<User>();
            User objUser = new User();
            objUser.UserName = searchVal;
            uvm.user = objUser;
            uvm.users = objUsers;
            return View(uvm);
        }
        public ActionResult AddAdmin()
        {
            if (Session["userType"] != null && Session["userType"].ToString() == "admin")
            {
                return View(new Admin());
            }
            return RedirectToAction("MyPage", "Home");
        }

        public ActionResult SubmitAdminRegister(Admin admin)
        {
            AdminsDal dal = new AdminsDal();
            Encryption enc = new Encryption();
            if (ModelState.IsValid)
            {
                var isUserAlreadyExists = dal.Users.Any(x => x.UserName == admin.UserName);
                string hashedPassword = enc.CreateHash(admin.Password);
                if (isUserAlreadyExists)
                {
                    TempData["LoginStatus"] = "Username already exists.";
                    return View("AddAdmin", admin);
                }
                admin.Password = hashedPassword;
                dal.Users.Add(admin);
                dal.SaveChanges();
                TempData["LoginStatus"] = null;
                return RedirectToAction("MyPage", "Home");
            }
            return View("AddAdmin", admin);
        }
    }
}