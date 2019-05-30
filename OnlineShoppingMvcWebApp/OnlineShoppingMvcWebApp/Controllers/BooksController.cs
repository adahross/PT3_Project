using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using MvcBreadCrumbs;
using OnlineShoppingMvcWebApp.Models;

namespace OnlineShoppingMvcWebApp.Controllers
{
    [BreadCrumb]
    public class BooksController : Controller
    {
        private MyAppDbContext db = new MyAppDbContext();

        // GET: Books
        public ActionResult IndexBooks()
        {
            return View(db.Book.ToList());
        }

        // GET: Books/Details/5
        public ActionResult DetailsBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult DetailsForCustomer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult CreateBook()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind(Include = "BookId,Title,Publisher,Year,CoverPage,ISBN,Author,Category,Price", Exclude="CoverPage")] Book book)
        {

            if (ModelState.IsValid)
            {
                HttpPostedFileBase poImgFile = Request.Files["CoverPage"];


                string path = @"\Images/"+ poImgFile.FileName;
                    poImgFile.SaveAs(Server.MapPath("~") + @"\" + path);
                    book.CoverPage = path;

                //Check book if exist
                int count = (from x in db.Book
                             where x.Title == book.Title
                             where x.ISBN == book.ISBN
                             select x).Count();

                if (count == 0)
                {
                    db.Book.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("IndexBooks");
                }

                else {

                    ViewBag.errorMessage = "Book already exist. Please create new book";
                    return View(book);

                }
               
                
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook([Bind(Include = "BookId,Title,Publisher,Year,ISBN,Author,Category,Price", Exclude = "CoverPage")] Book book)
        {
            HttpPostedFileBase poImgFile = Request.Files["CoverPage"];
            string path = @"\Images/" + poImgFile.FileName;
            poImgFile.SaveAs(Server.MapPath("~") + @"\" + path);
            book.CoverPage = path;

            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexBook");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult DeleteBook(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Book.Find(id);
            db.Book.Remove(book);
            db.SaveChanges();
            return RedirectToAction("IndexBooks");
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
