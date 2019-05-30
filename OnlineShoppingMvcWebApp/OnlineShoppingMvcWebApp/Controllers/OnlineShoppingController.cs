using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBreadCrumbs;
using OnlineShoppingMvcWebApp.Models;

namespace OnlineShoppingMvcWebApp.Controllers
{
    [BreadCrumb]
    public class OnlineShoppingController : Controller
    {
        
        private MyAppDbContext db = new MyAppDbContext();

        [AllowAnonymous]
        // GET: OnlineShopping
        public ActionResult Index()
        {
            
            return View(db.Book.ToList());
        }
        public ActionResult Index2()
        {

            return View(db.Book.ToList());
        }
        public ActionResult Index3()
        {

            return View(db.Book.ToList());

        }
    }
}