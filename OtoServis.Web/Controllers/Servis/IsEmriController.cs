using OtoServis.BusinessLayer.Abstract;
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
        private readonly Repository<IsEmri> rpIsEmri = new Repository<IsEmri>(); 
        private readonly Repository<BakimGrup> rpBakimGrup = new Repository<BakimGrup>(); 
        private readonly Repository<Islem> rpIslem = new Repository<Islem>(); 
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
            var musteri = rpMusteri.GetById(musteriId);
            ViewBag.MusteriId = musteriId;
            ViewBag.AcikIsEmirleri = rpIsEmri.Get(x => x.Kapali == false && x.MusteriId == musteriId).ToList();
            ViewBag.Title = "İş Emri Oluştur - "+ musteri.AdSoyad;
            return View(rpIsEmri.Get(x=> x.Kapali==true && x.MusteriId==musteriId).OrderByDescending(x=>x.GelisTarihi).ToList());
        }
        public ActionResult IsEmriKaydet(IsEmri isEmri)
        {
            rpIsEmri.Insert(isEmri);
            return RedirectToAction("AcikIsEmirleri");
        }
        public ActionResult AcikIsEmirleri()
        {
            return View(rpIsEmri.Get(x=>x.Kapali == false).ToList());
        }
        public ActionResult IslemYap(int isEmriId)
        {
            var baslik = rpIsEmri.Get(x => x.IsEmriId == isEmriId, includeProperties: "Musteri").FirstOrDefault();
            ViewBag.Title ="İşlem Yap - Plaka: " +baslik.Plaka + " - Müşteri : " + baslik.Musteri.AdSoyad;
            ViewBag.BakimGrup = rpBakimGrup.List();
            ViewBag.IsEmriId = isEmriId;
            return View(rpIslem.Get(x=> x.IsEmriId==isEmriId).OrderByDescending(x=> x.IslemId).ToList());
        }

        public ActionResult IslemKaydet(Islem islem)
        {
            islem.IslemAd = islem.IslemAd.ToUpper();
            rpIslem.Insert(islem);
            return RedirectToAction("IslemYap", new { isEmriId = islem.IsEmriId});
        }
        public ActionResult IslemSil(int id)
        {
            var silinecek = rpIslem.GetById(id);
            rpIslem.Delete(silinecek);
            return RedirectToAction("IslemYap", new { isEmriId = silinecek.IsEmriId });
        }
        public ActionResult KaydetKapat(int IsEmriId,string OdemeSekli, string Aciklama, decimal AlinanUcret)
        {
            var isemri = rpIsEmri.GetById(IsEmriId);
            isemri.OdemeSekli = OdemeSekli;
            isemri.Aciklama = Aciklama;
            isemri.AlinanUcret = AlinanUcret;
            isemri.Kapali = true;
            isemri.KapatmaTarihi = DateTime.Now;
            rpIsEmri.Update(isemri);
            TempData["Ok"] = "İş Emri Kaydedildi ve Kapatıldı!";
            return RedirectToAction("AcikIsEmirleri");
        }
    }
}