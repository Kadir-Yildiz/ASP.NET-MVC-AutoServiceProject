using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Web
{
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly Repository<Slider> rpSlider = new Repository<Slider>();
        // GET: Slider
        public ActionResult Index()
        {
            var slider = rpSlider.List().OrderByDescending(x => x.SliderId);
            return View(slider);
        }
        public ActionResult SliderKaydet(Slider slider, HttpPostedFileBase resim)
        {
            try
            {
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string dosyaAdi = Path.GetFileNameWithoutExtension(resim.FileName) + "_" + Guid.NewGuid();
                    string tamAd = dosyaAdi + uzanti;
                    string yol = Server.MapPath("/Img/Slider/") + tamAd;
                    resim.SaveAs(yol);
                    string kaydedilecekYol = "/Img/Slider/" + tamAd;
                    slider.Resim = kaydedilecekYol;
                    rpSlider.Insert(slider);
                    TempData["Ok"] = "Kayıt Başarılı";
                }
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["No"] = "Hata Oluştu";
                return RedirectToAction("Index");
            }

        }
        [HttpPost]
        public ActionResult SliderSil(int id)
        {
            try
            {
                var slider = rpSlider.GetById(id);
                string resimYolu = Request.MapPath(slider.Resim);
                rpSlider.Delete(slider);
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