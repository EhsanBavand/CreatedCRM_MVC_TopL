using DataSource.Context;
using DataSource.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public class PageCommentRepository : IPageCommentRepositories
    {
        private MyCmsContext db;
        public PageCommentRepository(MyCmsContext context)
        {
            db = context;
        }

        public IEnumerable<PageComment> GetCommentsByNewsID(int pageID)
        {
            return db.PageComments.Where(c => c.PageID == pageID);
        }
        public bool AddComment(PageComment pageComment)
        {
            try
            {
                db.PageComments.Add(pageComment);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
