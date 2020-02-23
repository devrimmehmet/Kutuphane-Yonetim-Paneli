using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Devrekani_Sehitler_Kutuphanesi.Controllers
{
    public class IstatistiklerController : Controller
    {
        // GET: Istatistikler
        public ActionResult Index()
        {
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
    }
}