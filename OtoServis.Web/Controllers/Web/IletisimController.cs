using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Web
{
    public class IletisimController : Controller
    {
        private readonly Repository<HaritaIletisim> rpIletisim = new Repository<HaritaIletisim>();
        public ActionResult Index()
        {
            if (rpIletisim.List().Count == 0)
            {
                HaritaIletisim hi = new HaritaIletisim();
                hi.Harita = "-";
                hi.Iletisim = "-";
                rpIletisim.Insert(hi);
            }
            var iletisim = rpIletisim.List().FirstOrDefault();
            return View(iletisim);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Kaydet(HaritaIletisim iletisimm)
        {
            var guncellenecek = rpIletisim.GetById(iletisimm.HaritaIletisimId);
            guncellenecek.Harita = iletisimm.Harita;
            guncellenecek.Iletisim = iletisimm.Iletisim;
            rpIletisim.Update(guncellenecek);
            return RedirectToAction("Index");
        }
    }
}