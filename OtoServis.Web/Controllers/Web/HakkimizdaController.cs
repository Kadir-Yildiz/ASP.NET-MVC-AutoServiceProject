using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Web
{
    public class HakkimizdaController : Controller
    {
        private readonly Repository<Hakkimizda> rpHakkimizda = new Repository<Hakkimizda>();
        public ActionResult Index()
        {
            if (rpHakkimizda.List().Count ==0)
            {
                Hakkimizda h = new Hakkimizda();
                h.Icerik = "-";
                h.Resim = "-";
                rpHakkimizda.Insert(h);
            }
            return View(rpHakkimizda.List().FirstOrDefault());
        }
    }
}