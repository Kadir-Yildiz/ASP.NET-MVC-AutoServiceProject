using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Web;
using System.Linq;
using System.Web.Mvc;

namespace OtoServis.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository<Slider> rpSlider = new Repository<Slider>();
        private readonly Repository<Kampanya> rpKampanya = new Repository<Kampanya>();
        private readonly Repository<Uygulama> rpUygulama = new Repository<Uygulama>();
        private readonly Repository<Hakkimizda> rpHakkimizda = new Repository<Hakkimizda>();
        private readonly Repository<Blog> rpBlog = new Repository<Blog>();
        private readonly Repository<HaritaIletisim> rpIletisim = new Repository<HaritaIletisim>();

        
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Slider = rpSlider.List();
            ViewBag.Kampanya = rpKampanya.List().FirstOrDefault();
            ViewBag.Uygulama = rpUygulama.List();
            ViewBag.Hakkimizda = rpHakkimizda.List().FirstOrDefault();
            ViewBag.Blog = rpBlog.List().OrderByDescending(x=> x.BlogId).Take(4).ToList();
            ViewBag.Harita = rpIletisim.List().FirstOrDefault();
            ViewBag.Adres = rpIletisim.List().FirstOrDefault().Iletisim;
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Deneme()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Route("{baslik}/{blogId:int}")]
        public ActionResult BlogDetay(string baslik,int blogId)
        {
            var detay = rpBlog.GetById(blogId);
            ViewBag.Adres = rpIletisim.List().FirstOrDefault().Iletisim;
            return View(detay);
        }
    }
}
