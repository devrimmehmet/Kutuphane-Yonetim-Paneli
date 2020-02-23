using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;
namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class IstatistiklerController : Controller
    {
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        public ActionResult Index()
        {
            var deger1 = db.TBL_UYELER.Count();
            var deger2 = db.TBL_KITAP.Count();
            var deger3 = db.TBL_KITAP.Where(x => x.DURUM == false).Count();
            var deger4 = db.TBL_CEZALAR.Sum(x => x.PARA);
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaDurumu()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult resimyukle(HttpPostedFileBase resim)
        {
            if (resim.ContentLength > 0)
            {
                string dosyayolu = Path.Combine(Server.MapPath("~/web2/resimler/"), Path.GetFileName(resim.FileName));
                resim.SaveAs(dosyayolu);
            }
            return RedirectToAction("Galeri");
        }

        public ActionResult Kartlar()
        {
            var deger1 = db.TBL_KITAP.Count();
            var deger2 = db.TBL_UYELER.Count();
            var deger3 = db.TBL_CEZALAR.Sum(x => x.PARA);
            var deger4 = db.TBL_KITAP.Where(x => x.DURUM==false).Count();
            var deger5 = db.TBL_KATEGORI.Count();
            var deger8 = db.EnFazlaKitabıOlanYazar().FirstOrDefault();
            var deger9 = db.TBL_KITAP.GroupBy(x=>x.YAYINEVI).OrderByDescending(z=>z.Count()).Select(y=>new { y.Key}).FirstOrDefault();
            var deger11 = db.TBL_ILETISIM.Count();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            ViewBag.dgr4 = deger4;
            ViewBag.dgr5 = deger5;
            ViewBag.dgr8 = deger8;
            ViewBag.dgr9 = deger9;
            ViewBag.dgr11 = deger11;
            return View();
        }
    }
}