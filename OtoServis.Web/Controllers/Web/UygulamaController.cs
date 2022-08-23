using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Web
{
    [Authorize(Roles = "Admin")]
    public class UygulamaController : Controller
    {
        private readonly Repository<Uygulama> rpUygulama = new Repository<Uygulama>();
        public ActionResult Index()
        {
            return View(rpUygulama.List().OrderByDescending(x=> x.UygulamaId));
        }
        [HttpPost]
        public ActionResult UygulamaKaydet(Uygulama uygulama, HttpPostedFileBase resim)
        {
            if (resim!=null)
            {
                string uzanti = Path.GetExtension(resim.FileName);
                string dosyaAdi = Path.GetFileNameWithoutExtension(resim.FileName) + "_" + Guid.NewGuid() + uzanti;
                string resimYol = Server.MapPath("/Img/Uygulamalar/" + dosyaAdi);
                resim.SaveAs(resimYol);
                WebImage image = new WebImage(resimYol);
                image.Resize(285,180,true,true);
                image.Save(resimYol);
                uygulama.Resim = "/Img/Uygulamalar/" + dosyaAdi;
                rpUygulama.Insert(uygulama);
                TempData["Ok"] = "Kayıt Başarılı";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult UygulamaSil(int id)
        {
            try
            {
                var uygulama = rpUygulama.GetById(id);
                string resimYolu = Request.MapPath(uygulama.Resim);
                rpUygulama.Delete(uygulama);
                if (System.IO.File.Exists(resimYolu))
                {
                    System.IO.File.Delete(resimYolu);
                }
                TempData["Ok"] = "Silme İşlemi Tamamlandı!";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["No"] = "Hata!";
                return RedirectToAction("Index");
            }
        }
    }
}