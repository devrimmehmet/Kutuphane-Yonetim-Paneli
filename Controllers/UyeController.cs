using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;
namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class UyeController : Controller
    {
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpGet]
        public ActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}