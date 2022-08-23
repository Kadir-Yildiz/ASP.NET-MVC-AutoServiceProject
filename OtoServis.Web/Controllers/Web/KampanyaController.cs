using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Web
{
    [Authorize(Roles = "Admin")]
    public class KampanyaController : Controller
    {
        Repository<Kampanya> rpKampanya = new Repository<Kampanya>();
        public ActionResult Index()
        {
            if (rpKampanya.List().Count()==0)
            {
                Kampanya k = new Kampanya();
                k.Icerik = "-";
                rpKampanya.Insert(k);
            }
            var kampanya = rpKampanya.List().FirstOrDefault();

            return View(kampanya);
        }
        [HttpPost]
        public ActionResult KampanyaKaydet(Kampanya kampanya)
        {
            if (rpKampanya.List().Count>0)
            {
                var guncellenecek = rpKampanya.List().FirstOrDefault();
                guncellenecek.Icerik = kampanya.Icerik;
                rpKampanya.Update(guncellenecek);
            }
            return RedirectToAction("Index");
        }
    }
}