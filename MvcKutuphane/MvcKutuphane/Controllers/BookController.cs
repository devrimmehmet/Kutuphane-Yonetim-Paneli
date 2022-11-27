using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        LibraryEntities db=new LibraryEntities();
       
    
        public ActionResult Index(string p)
        {
            var books = from k in db.Books select k;
            if (!string.IsNullOrEmpty(p))
            {
                books = books.Where(book => book.Name.Contains(p));
            }
      
            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult BookAdd()
        {
            List<SelectListItem> categoryValue = (from i in db.Categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name,
                                                Value = i.Id.ToString()
                                            }).ToList();
            ViewBag.value1 = categoryValue;
            List<SelectListItem> authorValue = (from i in db.Authors.ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.Name+ ' ' +i.Surname,
                                                Value = i.Id.ToString()
                                            }).ToList();
            ViewBag.value2 = authorValue;
            return View();
        } 
        [HttpPost]
        public ActionResult BookAdd(Books books)
        {
            var category = db.Categories.Where(ctg => ctg.Id == books.Categories.Id).FirstOrDefault();
            var author = db.Authors.Where(authr => authr.Id == books.Authors.Id).FirstOrDefault();
            books.Categories = category;
            books.Authors = author;
            db.Books.Add(books);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BookDelete(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BookGet(int id)
        {
            var book = db.Books.Find(id);
            List<SelectListItem> categoryValue = (from i in db.Categories.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = i.Name,
                                                      Value = i.Id.ToString()
                                                  }).ToList();
            ViewBag.value1 = categoryValue;
            List<SelectListItem> authorValue = (from i in db.Authors.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = i.Name + ' ' + i.Surname,
                                                    Value = i.Id.ToString()
                                                }).ToList();
            ViewBag.value2 = authorValue;
           
            return View("BookGet", book);
        }
        public ActionResult BookUpdate(Books book)
        {
            var _book = db.Books.Find(book.Id);
            _book.Name = book.Name;
            _book.PublicationYear = book.PublicationYear;
            _book.Page = book.Page;
            _book.Publisher = book.Publisher;
            var category = db.Categories.Where(ctg => ctg.Id == book.Categories.Id).FirstOrDefault();
            var author = db.Categories.Where(authr => authr.Id == book.Authors.Id).FirstOrDefault();
            _book.Category_Id = category.Id;
            _book.Author_Id = author.Id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}