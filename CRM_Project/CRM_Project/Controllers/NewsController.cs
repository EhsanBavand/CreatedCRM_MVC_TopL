using DataSource;
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
    public class NewsController : Controller
    {
        MyCmsContext db = new MyCmsContext();
        IPageGroupRepositories pageGroupRepository;
        IPageRepositories pageRepositories;
        IPageCommentRepositories pageCommentRepositories;
        public NewsController()
        {
            pageGroupRepository = new PageGroupRepository(db);
            pageRepositories = new PageRepository(db);
            pageCommentRepositories = new PageCommentRepository(db);
        }

        // GET: News
        public ActionResult ShowGroups()
        {
            var data = pageGroupRepository.GetGroupsForView();
            return PartialView(data);
        }

        public ActionResult ShowGroupInMenu()
        {
            var data = pageGroupRepository.GetAllGroups();
            return PartialView(data);
        }

        public ActionResult ShowTopNews()
        {
            var data = pageRepositories.TopNews();
            return PartialView(data);
        }
        public ActionResult LastNews()
        {
            var data = pageRepositories.LastNews();
            return PartialView(data);
        }

        /*
            1- To Route Archive we have to use attrebute Route
            2- Go to App_Start/RouteConfig and run  below code top of the MapRoute
                routes.MapMvcAttributeRoutes();
        */
        [Route("Archive")]
        public ActionResult ArchiveNews()
        {
            return View(pageRepositories.GetAllPages());
        }
        [Route("Group/{id}/{title}")]
        public ActionResult ShowNewsByGroupId(int id, string title)
        {
            ViewBag.name = title;
            var data = pageRepositories.ShowPageByGroupID(id);
            return View(data);
        }

        [Route("News/{id}")]
        public ActionResult ShowNews(int id)
        {
            var news = pageRepositories.GetPageById(id);
            if (news == null)
            {
                return HttpNotFound();
            }

            news.Visit += 1;
            pageRepositories.UpdatePage(news);
            pageRepositories.Save();
            return View(news);

        }
        public ActionResult AddComment(int id =0, string name= "", string email="", string comment="")
        {
            PageComment addcomment = new PageComment()
            {
                CreateDate = DateTime.Now,
                PageID = id,
                Comment = comment,
                Email = email,
                Name = name
            };
            pageCommentRepositories.AddComment(addcomment);

            return PartialView("ShowComment ", pageCommentRepositories.GetCommentsByNewsID(id));
        }

        public ActionResult ShowComment(int id)
        {
            return PartialView(pageCommentRepositories.GetCommentsByNewsID(id));
        }
    }
}