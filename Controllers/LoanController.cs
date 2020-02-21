using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;

namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class LoanController : Controller
    {
        DB_Kutuphane_Entities2 db = new DB_Kutuphane_Entities2();
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult OduncVer()
        {

            return View();
        }
        [HttpPost]
        public ActionResult OduncVer(TBL_HAREKET p)
        {
            db.TBL_HAREKET.Add(p);
            db.SaveChanges();
            return View();
           
        }
    }
}