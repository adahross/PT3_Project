using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcBreadCrumbs;
using OnlineShoppingMvcWebApp.Models;
using OnlineShoppingMvcWebApp.ViewModels;

namespace OnlineShoppingMvcWebApp.Controllers
{       [BreadCrumb]
    public class OrdersController : Controller
    {
        
        private string history = "OldCart";
        private MyAppDbContext db = new MyAppDbContext();
        static CustomerOrder vm = new CustomerOrder
        {
            
            CustomerOrders   = new List<CustomerOrder>()
        };

        // GET: Orders
        public ActionResult Index()
        {
           
            return View(db.Order.ToList());
        }

        public ActionResult OrderCustomer(int ? id)
        {
            var result = (from x in db.Order
                          where x.Customer.registeredUserId == id
                          select x).ToList();
            

            return View(result);
        }

        // GET: Orders/Details/5
        public ActionResult DetailsCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            Customer customer = (from o in db.Order
                                 join c in db.Customer
                                 on o.OrderCustomerid equals c.registeredUserId
                                 select c).First();

            Address address = (from c in db.Customer
                               join a in db.Address
                               on c.ShipAddressID equals a.AddressID
                               select a).First();
            order.Customer.ShipAddress = address;
            order.Customer = customer;


            return View(order);
        }
        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            Customer customer = (from o in db.Order
                                join c in db.Customer
                                on o.Customer.registeredUserId equals c.registeredUserId
                                select c).First();

            Address address = (from c in db.Customer
                                 join a in db.Address
                                 on c.ShipAddressID equals a.AddressID
                                 select a).First();
            order.Customer.ShipAddress = address;
            order.Customer = customer;


            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()

        {
            Order order = new Order()
            {

                TotalPrice = 0.00,
                ShipFee = 10.00,
               
            };

            return View(order);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="OrderId, PaymentType, TotalPrice,ShipFee, Date")] Order order)
        {
           
            if (ModelState.IsValid)
            {
              var custid = Int32.Parse(Request.Cookies["UserId"].Value);
                Customer cust = (from x in db.Customer
                                 where x.registeredUserId == custid
                                 select x).Single();
                     order.Customer = cust;
                List<Cart> IsCart = (List<Cart>)Session["Cart"];


                order.OrderCustomerid = custid;
                order.Date = DateTime.Now;
                db.Order.Add(order);
                db.SaveChanges();

                for (int i = 0; i < IsCart.Count; i++)
                {
                    var book = db.Book.Find(IsCart[i].Book.BookId);
                    if(book.BookId>0)
                    { 
                    IsCart[i].OrderID = order.OrderId;
                        IsCart[i].BookID =book.BookId;

                        db.Carts.Add(IsCart[i]);

                        db.SaveChanges();
                    }
                }
                Session["Cart"]=null;
                return RedirectToAction("OrderCustomer/"+Request.Cookies["UserId"].Value);
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderId,PaymentType,TotalPrice,ShipFee")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Order.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Order.Find(id);
            db.Order.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
