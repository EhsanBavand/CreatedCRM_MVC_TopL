using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataSource;
using DataSource.Context;
using DataSource.Repositories;
using DataSource.Services;

namespace CRM_Project.Areas.Admin.Controllers
{
    [Authorize]
    public class PagesController : Controller
    {
        private IPageRepositories pageRepositories;
        private IPageGroupRepositories pageGroupRepositories;
        private MyCmsContext db = new MyCmsContext();
        public PagesController()
        {
            pageRepositories = new PageRepository(db);
            pageGroupRepositories = new PageGroupRepository(db);
        }

        // GET: Admin/Pages
        public ActionResult Index()
        {
            return View(pageRepositories.GetAllPages());
        }

        // GET: Admin/Pages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepositories.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // GET: Admin/Pages/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(pageGroupRepositories.GetAllGroups(), "GroupID", "GroupTitle");
            return View();
        }

        // POST: Admin/Pages/Create 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Visit,ImageName,ShowInSlider,CreateDate,Tags")] Page page, HttpPostedFileBase imgUP)
        {
            if (ModelState.IsValid)
            {
                page.Visit = 0;
                page.CreateDate = DateTime.Now;

                // Save Image
                if (imgUP != null)
                {
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUP.FileName);
                    imgUP.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));
                }

                pageRepositories.InsertPage(page);
                pageRepositories.Save();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.PageGroups, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepositories.GetPageById(id.Value)
; if (page == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(pageGroupRepositories.GetAllGroups(), "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // POST: Admin/Pages/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PageID,GroupID,Title,ShortDescription,Text,Visit,ImageName,ShowInSlider,CreateDate,Tags")] Page page, HttpPostedFileBase imgUP)
        {
            if (ModelState.IsValid)
            {

                // Delete Previous Image and Save New Image
                if (imgUP != null)
                {
                    if (page.ImageName != null)
                    {
                        System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
                    }
                    page.ImageName = Guid.NewGuid() + Path.GetExtension(imgUP.FileName);
                    imgUP.SaveAs(Server.MapPath("/PageImages/" + page.ImageName));
                }

                pageRepositories.UpdatePage(page);
                pageRepositories.Save();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.PageGroups, "GroupID", "GroupTitle", page.GroupID);
            return View(page);
        }

        // GET: Admin/Pages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Page page = pageRepositories.GetPageById(id.Value);
            if (page == null)
            {
                return HttpNotFound();
            }
            return View(page);
        }

        // POST: Admin/Pages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Page page = pageRepositories.GetPageById(id);
            if (page.ImageName != null)
            {
                System.IO.File.Delete(Server.MapPath("/PageImages/" + page.ImageName));
            }
            pageRepositories.DeletePage(page);
            pageRepositories.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pageGroupRepositories.Dispose();
                pageRepositories.Dispose();
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
