using OtoServis.BusinessLayer.Abstract;
using OtoServis.Entities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OtoServis.Web.Controllers.Web
{
    public class BlogController : Controller
    {
        private readonly Repository<Blog> rpBlog = new Repository<Blog>();
        public ActionResult Index()
        {
            return View(rpBlog.List().OrderByDescending(x=> x.BlogId));
        }
    }
}