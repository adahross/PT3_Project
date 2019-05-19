using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingMvcWebApp.Models;

namespace OnlineShoppingMvcWebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        private MyAppDbContext db = new MyAppDbContext();
        public ActionResult ViewStaff()
        {
            return View(db.RegisteredUser.ToList());
        }

        public ActionResult ViewCustomer()
        {
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult ViewBook()
        {
            return RedirectToAction("Index", "Books");
        }

        public ActionResult ViewOrder()
        {
            return RedirectToAction("Index", "Order");
        }

        public ActionResult CreateUser()
        {
            return View();
        }

    }
}