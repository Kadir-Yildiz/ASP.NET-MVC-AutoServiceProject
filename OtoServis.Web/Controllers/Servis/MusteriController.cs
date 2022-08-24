using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Servis
{
    public class MusteriController : Controller
    {
        private readonly Repository<Musteri> rpMusteri = new Repository<Musteri>();
        public ActionResult Index()
        {
            return View(rpMusteri.Get().Take(20).OrderByDescending(x=>x.MusteriId).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}