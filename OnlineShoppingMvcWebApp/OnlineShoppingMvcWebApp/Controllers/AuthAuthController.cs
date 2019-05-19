using OnlineShoppingMvcWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineShoppingMvcWebApp.Controllers
{
    public class AuthAuthController : Controller
    {
              [AllowAnonymous]
        // GET: AuthAuth
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(RegisteredUser user)
        {
            //access to db. get username and password
            MyAppDbContext db = new MyAppDbContext();

            int count = (from x in db.RegisteredUser
                         where x.userName == user.userName
                         where x.password == user.password
                         select x).Count();

            if (count == 0)
            {
                ViewBag.errMsg = "No match found";
                return View();
            }
            else
            {
                HttpCookie cookie= new HttpCookie("Username", user.userName);
                FormsAuthentication.SetAuthCookie(user.userName, false);
                Response.SetCookie(cookie);
                return RedirectToAction("Index", "OnlineShopping");
            }
        }



        [AllowAnonymous]
        // GET: AuthAuth
        public ActionResult SignUp()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp(RegisteredUser user)
        {
            //access to db. get username and password
            MyAppDbContext db = new MyAppDbContext();

            int count = (from x in db.RegisteredUser
                         where x.userName == user.userName
                         where x.password == user.password
                         select x).Count();

            //check whether acc already exist
            if (count == 0)
            {
               ViewBag.errMsg = "Registration Successful. Please Login";
               db.RegisteredUser.Add(user);
               db.SaveChanges();
                return RedirectToAction("LoginCustomer", "AuthAuth");
            }
            else
            {      
                //check whether acc already exist
                ViewBag.errMsg = "This account already registered";
                return View(user);
                           }
        }

        public ActionResult Logout()
        {
            //signout
            HttpCookie cookie = new HttpCookie("Username", null);
            Response.SetCookie(cookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "OnlineShopping");
        }
    }
}