using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Servis
{
    public class BakimGrupController : Controller
    {
        private readonly Repository<BakimGrup> rpBakimGrup = new Repository<BakimGrup>();
        private readonly Repository<Bakim> rpBakim= new Repository<Bakim>();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BakimDoldur(int bakimGrupId)
        {
            var bakimGrup = rpBakim.Get(x => x.BakimGrupId == bakimGrupId).Select(x => new { x.BakimId, x.BakimAdi }).ToList();
            return Json(bakimGrup, JsonRequestBehavior.AllowGet);
        }
    }
}