using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBreadCrumbs;
using OnlineShoppingMvcWebApp.Models;

namespace OnlineShoppingMvcWebApp.Controllers
{
    [BreadCrumb]
    public class ShoppingCartController : Controller
    {
        MyAppDbContext db = new MyAppDbContext();
        // GET: ShoppingCart
        private string strCart = "Cart";
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            }

            if (Session[strCart] == null)
            {

                List<Cart> isCart = new List<Cart>()
                {
                    new Cart(db.Book.Find(id),1)
                };
                Session[strCart] = isCart;
            }
            else {

                List<Cart> IsCart = (List<Cart>)Session[strCart];
                int check = isExist(id);
                if (check == -1)
                {

                    IsCart.Add(new Cart(db.Book.Find(id), 1));

                }
                else
                    IsCart[check].Quantity++;
                    
                 Session[strCart] = IsCart;

               
            }

            return View("OrderNow");

        }

        public int isExist(int? id) {
            List<Cart> IsCart = (List<Cart>)Session[strCart];
            
            for(int i=0;i<IsCart.Count; i++)
            {
                if (IsCart[i].Book.BookId == id) return i;

             }

            return -1;

        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            int check = isExist(id);
            List<Cart> IsCart = (List<Cart>)Session[strCart];
            IsCart.RemoveAt(check);
            return View("OrderNow");
           

            
        }
        public ActionResult CheckOut()
        {
           
            return RedirectToAction("Create", "Orders");
            


        }
    }
}