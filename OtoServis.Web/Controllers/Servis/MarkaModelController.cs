using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Servis
{
    public class MarkaModelController : Controller
    {
        private readonly Repository<Model> rpModel = new Repository<Model>();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult ModelDoldur(int markaId)
        {
            var modeller = rpModel.Get(x => x.MarkaId == markaId).Select(x => new { x.ModelId, x.ModelAd }).ToList();
            return Json(modeller, JsonRequestBehavior.AllowGet);
        }
    }
}