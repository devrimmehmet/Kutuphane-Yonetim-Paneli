using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;
using Devrekani_Sehitler_Kutuphanesi.Models.Siniflarim;
namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class AnasayfaController : Controller
    {
        // GET: Showcase
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1 = db.TBL_KITAP.ToList();
            cs.Deger2 = db.TBL_HAKKIMIZDA.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(TBL_ILETISIM t)
        {
            db.TBL_ILETISIM.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}