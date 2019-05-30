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

namespace OnlineShoppingMvcWebApp.Controllers
{
    [BreadCrumb]
    public class CustomersController : Controller
    {
        private MyAppDbContext db = new MyAppDbContext();

        // GET: Customers
        public ActionResult Index()
        {
             var result = (from x in db.Customer
                          where x.role == "Customer"
                          select x).ToList();
                                
            
            return View(result);
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = new Customer();
            customer = db.Customer.Find(id);
            int adID = (from x in db.Customer
                        where x.registeredUserId == id
                           select x.ShipAddressID).First();

            var address = (from x in db.Address
                           where x.AddressID == adID
                           select x).First();

            customer.ShipAddress = address;

            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer()
            {
                role = "Customer"
            };
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "registeredUserId,fullName,userName,password,role,PhoneNo,Email,ShipAddress")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.RegisteredUser.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser customer = new Customer();
            customer = db.RegisteredUser.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "registeredUserId,fullName,userName,password,role,PhoneNo,Email,ShipAddress")] Customer customer)
        {
            if (ModelState.IsValid)
            {

                int adID = (from x in db.Customer
                            where x.registeredUserId == customer.registeredUserId
                            select x.ShipAddress.AddressID).First();

                customer.ShipAddress.AddressID = adID;

                Address newAdd = new Address
                {
                    AddressID = customer.ShipAddress.AddressID,
                    Street = customer.ShipAddress.Street,
                    State = customer.ShipAddress.State,
                    City = customer.ShipAddress.City,
                    PostCode = customer.ShipAddress.PostCode,
                    Country = customer.ShipAddress.Country


                };
                customer.ShipAddress = newAdd;
                db.Entry(customer.ShipAddress).State = EntityState.Modified;
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", customer.registeredUserId);
            }
            else
                return View(customer);
           
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisteredUser customer = new Customer();
            customer = db.RegisteredUser.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisteredUser customer = new Customer();

            customer= db.RegisteredUser.Find(id);
            db.RegisteredUser.Remove(customer);
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
