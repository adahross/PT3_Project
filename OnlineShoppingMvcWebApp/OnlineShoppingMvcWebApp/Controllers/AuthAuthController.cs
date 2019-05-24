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
                var item = (from x in db.RegisteredUser
                            where x.userName == user.userName
                            where x.password == user.password
                            select x).First();
                HttpCookie cookie= new HttpCookie("Username", user.userName);
                HttpCookie cookie1 = new HttpCookie("UserId", item.registeredUserId.ToString());
                FormsAuthentication.SetAuthCookie(user.userName, false);
                Response.SetCookie(cookie);
                Response.SetCookie(cookie1);
                return RedirectToAction("Index", "OnlineShopping");

            }
        }



        [AllowAnonymous]
        // GET: AuthAuth
        public ActionResult SignUp()
        {
            Customer customer = new Customer()
            {
                role = "Customer"
            };
            return View(customer);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp([Bind(Include = "registeredUserId,fullName,userName,password,role,PhoneNo,Email,ShipAddress")] Customer customer)
        {
            //access to db. get username and password
            MyAppDbContext db = new MyAppDbContext();

            int count = (from x in db.RegisteredUser
                         where x.userName == customer.userName
                         where x.password == customer.password
                         select x).Count();

            //check whether acc already exist
            if (count == 0)
            {
               ViewBag.errMsg = "Registration Successful. Please Login";
                db.Address.Add(customer.ShipAddress);
               db.RegisteredUser.Add(customer);
               db.SaveChanges();
                return RedirectToAction("Login", "AuthAuth");
            }
            else
            {      
                //check whether acc already exist
                ViewBag.errMsg = "This account already registered";
                return View(customer);
               
            }
        }

        public ActionResult Logout()
        {
            //signout
            HttpCookie cookie = new HttpCookie("Username", null);
            Response.SetCookie(cookie);
            HttpCookie cookie2 = new HttpCookie("Id", null);
            Response.SetCookie(cookie);
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "OnlineShopping");
        }
    }
}