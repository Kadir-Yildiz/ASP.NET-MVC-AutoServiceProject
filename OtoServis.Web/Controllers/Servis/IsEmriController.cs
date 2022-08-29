﻿using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Servis
{
    public class IsEmriController : Controller
    {
        private readonly Repository<Musteri> rpMusteri = new Repository<Musteri>(); 
        private readonly Repository<Marka> rpMarka = new Repository<Marka>(); 
        public ActionResult Index(string ara)
        {
            if (ara == "" || ara== null)
            {
                var musteri = rpMusteri.Get().Take(20).OrderByDescending(x => x.MusteriId).ToList();
                return View(musteri);
            }
            var musteriAra = rpMusteri.Get(x => x.AdSoyad.Contains(ara) || x.Telefon.Contains(ara)).ToList();
            return View(musteriAra);
        }
        public ActionResult IsEmriOlustur(int musteriId)
        {
            ViewBag.Marka = rpMarka.List();
            return View();
        }
    }
}