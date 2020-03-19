using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;

namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class KayitOlController : Controller
    {
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();

        // GET: KayitOl
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
       
       
        [HttpPost]
        public ActionResult Kayit(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}