using DataSource.Context;
using DataSource.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Services
{
    public class PageRepository : IPageRepositories
    {
        private MyCmsContext db;
        public PageRepository(MyCmsContext context)
        {
            this.db = context;
        }

        public IEnumerable<Page> GetAllPages()
        {
            return db.Pages;
        }
        public Page GetPageById(int pageId)
        {
            return db.Pages.Find(pageId);
        }
        public bool InsertPage(Page page)
        {
            // First Solution
            /*
               var newPage = new Page()
               {
                   GroupID = page.GroupID,
                   Title = page.Title,
                   ShortDescription = page.Title,
                   Text = page.Text,
                   Visit = page.Visit,
                   ImageName = page.ImageName,
                   ShowInSlider = page.ShowInSlider,
                   CreateDate = page.CreateDate
               };
               db.Pages.Add(newPage);
               db.SaveChanges();
               return true;
            */
            try
            {
                db.Pages.Add(page);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool UpdatePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool DeletePage(Page page)
        {
            try
            {
                db.Entry(page).State = EntityState.Deleted;
                return true;
            }
            catch (Exception) { return false; throw; }
        }
        public bool DeletePage(int pageId)
        {
            try
            {
                var item = GetPageById(pageId);
                DeletePage(item);
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }
        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public IEnumerable<Page> TopNews(int take = 4)
        {
            return db.Pages.OrderByDescending(p => p.Visit).Take(take);
        }

        public IEnumerable<Page> ShowPageSlider()
        {
            return db.Pages.Where(s => s.ShowInSlider);
        }

        public IEnumerable<Page> LastNews(int take = 4)
        {
            return db.Pages.OrderByDescending(l => l.CreateDate).Take(take);
        }

        public IEnumerable<Page> ShowPageByGroupID(int groupId)
        {
            return db.Pages.Where(p => p.GroupID == groupId);
        }

        public IEnumerable<Page> SearchPage(string search)
        {
            return db.Pages.Where( p => p.Title.Contains(search) || p.ShortDescription.Contains(search) || p.Tags.Contains(search) || p.Text.Contains(search)).Distinct();
        }
    }
}
