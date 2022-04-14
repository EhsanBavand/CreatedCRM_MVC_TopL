using DataSource.Context;
using DataSource.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM_Project.Controllers
{
    public class SearchController : Controller
    {
        private PageRepository pageRepository;
        MyCmsContext db = new MyCmsContext();

        public SearchController()
        {
            pageRepository = new PageRepository(db);


        }
        // GET: Search
        public ActionResult Index(string q)
        {
            ViewBag.Name = q;
            return View(pageRepository.SearchPage(q));
        }
    }
}