using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;

namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class EmanetlerController : Controller
    {
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.Where(x=>x.ISLEMDURUM==false).ToList();

            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {
           // List<SelectListItem>
           //deger1 = (from i in db.TBL_PERSONEL.ToList()
           //          select new SelectListItem
           //          { Text = i.PERSONEL, Value = i.ID.ToString() }).ToList();
           // ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKET p)
        {
           // var ktg = db.TBL_PERSONEL.Where(k => k.ID == p.TBL_PERSONEL.ID).FirstOrDefault();
          //  p.TBL_H = ktg;
            db.SaveChanges();
            return View();
           
        }
        public ActionResult Odunciade(int id)
        {
            var odn = db.TBL_HAREKET.Find(id);
            return View("Odunciade", odn);
        }
        public ActionResult OduncGuncelle(TBL_HAREKET p)
        {
            var hrk = db.TBL_HAREKET.Find(p.ID);
            hrk.UYEGETIRTARIH = p.UYEGETIRTARIH;
            hrk.ISLEMDURUM = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}