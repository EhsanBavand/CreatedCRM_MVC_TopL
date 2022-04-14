using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
    public interface IPageCommentRepositories
    {
        IEnumerable<PageComment> GetCommentsByNewsID(int pageID);
        bool AddComment(PageComment pageComment);

        //IEnumerable<PageComment> GetAllPageComments();
        //PageComment GetPageCommentById(int pageCommentId);
        //bool InsertPageComment(PageComment pageComment);
        //bool UpdatePageComment(PageComment pageComment);
        //bool DeletePageComment(PageComment pageComment);
        //bool DeletePageComment(int pageCommentId);
        //void Save();
    }
}
