using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class UsersController : Controller
    {
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();


        public ActionResult Index(int sayfa=1)
        {
            var degerler = db.TBL_UYELER.ToList().ToPagedList(sayfa,20);
            return View(degerler);
        }

        [HttpGet]
        public ActionResult UyeEkle()
        {
            return View();

        }
        [HttpPost]
        public ActionResult UyeEkle(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyeEkle");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }

        public ActionResult UyeSil(int id)
        {
            var usr = db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(usr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeGetir(int id)
        {
            var usr = db.TBL_UYELER.Find(id);
            return View("UyeGetir", usr);
        }
        public ActionResult UyeGuncelle(TBL_UYELER p)
        {
            var usr = db.TBL_UYELER.Find(p.ID);
            usr.AD = p.AD;
            usr.SOYAD = p.SOYAD;
            usr.MAIL = p.KULLANICIADI;
            usr.KULLANICIADI = p.KULLANICIADI;
            usr.SIFRE = p.SIFRE;
            usr.OKUL = p.OKUL;
            usr.TELEFON = p.TELEFON;
            usr.FOTOGRAF = p.FOTOGRAF;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}