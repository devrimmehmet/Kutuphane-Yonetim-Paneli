﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;
using System.Web.Security;


namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
   
    public class PanelimController : Controller
    {

        KutuphaneContext db = new KutuphaneContext();

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBL_UYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            uye.AD = p.AD;
            uye.TELEFON = p.TELEFON;
            uye.FOTOGRAF = p.FOTOGRAF;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.OKUL = p.OKUL;
            uye.SOYAD = p.SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Kitaplarim()
        {
            var kullanici = (string)Session["Mail"];
            var id = db.TBL_UYELER.Where(x => x.MAIL == kullanici.ToString()).Select(z => z.ID).FirstOrDefault();
            var degerler = db.TBL_HAREKET.Where(x => x.UYE == id).ToList();

                return View(degerler);
            
        }
        public ActionResult Duyurular()
        {
            var duyuruListesi = db.TBL_DUYURULAR.ToList(); 
           

            return View(duyuruListesi);

        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();


            return RedirectToAction("GirisYap", "uye");

        }
    }
}