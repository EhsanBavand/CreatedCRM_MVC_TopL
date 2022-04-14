using DataSource.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource.Repositories
{
    public interface IPageRepositories : IDisposable
    {
        IEnumerable<Page> GetAllPages();
        Page GetPageById(int pageId);
        bool InsertPage(Page page);
        bool UpdatePage(Page page);
        bool DeletePage(Page page);
        bool DeletePage(int pageId);
        void Save();
        IEnumerable<Page> TopNews(int take = 4);
        IEnumerable<Page> ShowPageSlider();
        IEnumerable<Page> LastNews(int take = 4);
        IEnumerable<Page> ShowPageByGroupID(int groupId);
        IEnumerable<Page> SearchPage(string search);

        
    }
}
