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
        [HttpPost]
        public ActionResult Create(Musteri musteri)
        {
            rpMusteri.Insert(musteri);
            TempData["Ok"] = "Müşteri kaydedildi!";
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var musteri = rpMusteri.GetById(id);
            ViewBag.Title = musteri.AdSoyad + " Düzenleme";
            return View(musteri);
        }
        [HttpPost]
        public ActionResult Edit(Musteri musteri)
        {
            var guncelle = rpMusteri.GetById(musteri.MusteriId);
            guncelle.AdSoyad = musteri.AdSoyad;
            guncelle.Telefon = musteri.Telefon;
            guncelle.Adres = musteri.Adres;
            guncelle.Eposta = musteri.Eposta;
            rpMusteri.Update(guncelle);
            TempData["Ok"] = guncelle.AdSoyad + " bilgileri güncellenmiştir!";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult MusteriSil(int id)
        {
            var silinecek = rpMusteri.GetById(id);
            rpMusteri.Delete(silinecek);
            TempData["Ok"] = "Müşteri Silinmiştir!";
            return RedirectToAction("Index");
        }

    }
}