using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;
namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class KategorilerController : Controller
    {
    
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        public ActionResult Index()
        {
            var degerler = db.TBL_KATEGORI.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult KategoriEkle()
        {
           return View();
           
        }
        [HttpPost]
        public ActionResult KategoriEkle(TBL_KATEGORI p)
        {
            db.TBL_KATEGORI.Add(p);
            db.SaveChanges();
            return View();
           // return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBL_KATEGORI.Find(id);
            db.TBL_KATEGORI.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriGetir(int id)
        {
            var ktg = db.TBL_KATEGORI.Find(id);
            return View("KategoriGetir", ktg);
        }
        public ActionResult KategoriGuncelle(TBL_KATEGORI p)
        {
            var ktg = db.TBL_KATEGORI.Find(p.ID);
            ktg.AD = p.AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}