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
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Slider = rpSlider.List();
            ViewBag.Kampanya = rpKampanya.List().FirstOrDefault();
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
    }
}
