using CookiesShop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarhanSolves.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        //This funciton will show login page
        public ActionResult Login(string err,string returnURL)
        {
            ViewBag.error = err;
            TempData["returnURL"] = returnURL;
            return View();
        }
        //Tfunction will validate email and pasword provided by user
        [HttpPost]
        public ActionResult PostLogin(string email,string password)
        {
            using (ShopDBContext db =new ShopDBContext())
            {
                var user = db.Users.Where(x => x.Email == email && x.Password == password).FirstOrDefault();
            if (user!=null)
                {
                    Session["username"] = user.FirstName+" "+user.LastName;
                    Session["userId"] = user.Id;
                    if (TempData["returnURL"]!=null)
                    {
                        return RedirectToAction("Order","Home");
                    }
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Login", new { err = "Please enter valid email and password." });
            }
            
        }
        //This functiion will show signup page to register and create new account
        public ActionResult SignUp(string err,int UserId=0)
        {
            ViewBag.error = err;
            User user = null;
            if (UserId>0)
            {
                using (ShopDBContext db=new ShopDBContext())
                {
                    user = db.Users.Find(UserId);
                }
            }
            return View(user);
        }
        //Add Users information to database
        [HttpPost]
        public ActionResult PostSignUp(User user)
        {
            using (ShopDBContext db = new ShopDBContext())
            {
                if (user.FirstName==null || user.LastName==null||user.Email==null||user.Password==null)
                {
                    return RedirectToAction("SignUp", new { err = "Please fill all fields carefully." });
                }
                else if (user.Id>0)
                {
                    var obj = db.Users.Find(user.Id);
                    obj.FirstName = user.FirstName;
                    obj.LastName = user.LastName;
                    obj.Email = user.Email;
                    obj.Password = user.Password;
                    db.SaveChanges();
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                Session["username"] = user.FirstName + " " + user.LastName;
                Session["userId"] = user.Id;
                return RedirectToAction("Index", "Home");
            }

        }
        //Logout functionality
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}