using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;

namespace MvcKutuphane.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        LibraryEntities db = new LibraryEntities();
        public ActionResult Index()
        {
            var values = db.Authors.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AuthorAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AuthorAdd(Authors authors)
        {
            db.Authors.Add(authors);
            db.SaveChanges();
            return View();
        } 
        public ActionResult AuthorDelete(int id)
        {
            var author = db.Authors.Find(id);
            db.Authors.Remove(author);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult AuthorGet(int id)
        {
            var author = db.Authors.Find(id);
            return View("AuthorGet",author);
        }
        public ActionResult AuthorUpdate(Authors author)
        {
            var _author = db.Authors.Find(author.Id);
            _author.Name = author.Name;
            _author.Surname = author.Surname;
            _author.Detail = author.Detail;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}