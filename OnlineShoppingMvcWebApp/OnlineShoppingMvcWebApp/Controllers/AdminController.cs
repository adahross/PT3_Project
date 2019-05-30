﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBreadCrumbs;
using OnlineShoppingMvcWebApp.Models;

namespace OnlineShoppingMvcWebApp.Controllers
{
    [BreadCrumb]
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
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult ViewBook()
        {
            return RedirectToAction("IndexBooks", "Books");
        }

        public ActionResult ViewOrder()
        {
            return RedirectToAction("Index", "Orders");
        }

        public ActionResult CreateUser()
        {
            return View();
        }

    }
}