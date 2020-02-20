using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;
namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class StaffController : Controller
    {
        DB_Kutuphane_Entities db = new DB_Kutuphane_Entities();
        public ActionResult Index()
        {
            var degerler = db.TBL_PERSONEL.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult PersonelEkle(TBL_PERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBL_PERSONEL.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult UyeSil(int id)
        {
            var person = db.TBL_PERSONEL.Find(id);
            db.TBL_PERSONEL.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            var prs = db.TBL_PERSONEL.Find(id);
            return View("PersonelGetir", prs);
        }
        public ActionResult PersonelGuncelle(TBL_PERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("PersonelGetir");
            }

            var prs = db.TBL_PERSONEL.Find(p.ID);
            prs.PERSONEL = p.PERSONEL;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}