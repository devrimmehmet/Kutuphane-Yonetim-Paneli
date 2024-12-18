using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;
namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class YazarlarController : Controller
    {
        // GET: Writer
        KutuphaneContext db = new KutuphaneContext();

        public ActionResult Index(string p)
        {
            var yazarlar = from k in db.TBL_YAZAR select k;
            if (!string.IsNullOrEmpty(p))
            {
                yazarlar = yazarlar.Where(x => x.AD.Contains(p));
            }
          
            return View(yazarlar.ToList());
        }


        
        [HttpGet]
        public ActionResult YazarEkle()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(TBL_YAZAR p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarEkle");
            }
            db.TBL_YAZAR.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBL_YAZAR.Find(id);
            db.TBL_YAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.TBL_YAZAR.Find(id);
            return View("YazarGetir", yzr);
        }
        public ActionResult YazarGuncelle(TBL_YAZAR p)
        {
            if (!ModelState.IsValid)
            {
                return View("YazarGetir");
            }
            var yzr = db.TBL_YAZAR.Find(p.ID);
            yzr.AD = p.AD;
            yzr.SOYAD = p.SOYAD;
            yzr.DETAY = p.DETAY;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YazarKitaplar(int id)
        {
            var yazar = db.TBL_KITAP.Where(x => x.YAZAR == id).ToList();
            var yzrad = db.TBL_YAZAR.Where(y => y.ID == id).Select(z => z.AD + " " + z.SOYAD).FirstOrDefault();
            ViewBag.y1 = yzrad;
            return View(yazar);
        }
    }
}