using System.Linq;
using System.Web.Mvc;
using Computer_Communications_Project.Models;
using Computer_Communications_Project.DAL;
using Computer_Communications_Project.Classes;

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
                if(isUserAlreadyExists)
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
    }
}