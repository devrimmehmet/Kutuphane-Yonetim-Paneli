using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Devrekani_Sehitler_Kutuphanesi.Models.Entity;

namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class HareketlerController : Controller
    {
        KutuphaneContext db = new KutuphaneContext();
        public ActionResult Index()
        {
            var degerler = db.TBL_HAREKET.Where(x => x.ISLEMDURUM == true).ToList();

            return View(degerler);
        }
    }
}