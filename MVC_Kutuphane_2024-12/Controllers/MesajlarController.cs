using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;

namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        KutuphaneContext db = new KutuphaneContext();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            
            var mesajlar = db.TBL_MESAJLAR.Where(x=>x.ALICI==uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        public ActionResult Giden()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var mesajlar = db.TBL_MESAJLAR.Where(x => x.GONDEREN == uyemail.ToString()).ToList();
            return View(mesajlar);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(TBL_MESAJLAR t)
        {
            var uyemail = (string)Session["Mail"].ToString();
            t.GONDEREN = uyemail.ToString();
            t.TARIH = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBL_MESAJLAR.Add(t);
            db.SaveChanges();
            return RedirectToAction("Giden","Mesajlar");
        }
    }
}