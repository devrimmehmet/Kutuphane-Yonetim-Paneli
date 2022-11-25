using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphane.Models.Entity;
namespace MvcKutuphane.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        LibraryEntities db=new LibraryEntities();
        public ActionResult Index()
        {
            var values=db.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Categories c)
        {
            db.Categories.Add(c);
            db.SaveChanges();
            return View();
        }

        public ActionResult CategoryDelete(int id)
        {
            var category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult CategoryGet(int id)
        {
            var ctg=db.Categories.Find(id);
            return View("CategoryGet",ctg);
        }
        public ActionResult CategoryUpdate(Categories c)
        {
            var ctg=db.Categories.Find(c.Id);
            ctg.Name = c.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}