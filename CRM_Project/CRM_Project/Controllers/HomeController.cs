using DataSource.Context;
using DataSource.Repositories;
using DataSource.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM_Project.Controllers
{
    public class HomeController : Controller
    {
        MyCmsContext db = new MyCmsContext();
        private IPageRepositories pageRepositories;
        public HomeController()
        {
            pageRepositories = new PageRepository(db);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Slider()
        {
            var data = pageRepositories.ShowPageSlider();
            return PartialView(data);
        }
    }
}