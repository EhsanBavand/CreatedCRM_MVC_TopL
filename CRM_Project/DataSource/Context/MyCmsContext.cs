using DataSource.Models;
using System.Data.Entity;

namespace DataSource.Context
{
    public class MyCmsContext:DbContext
    {
        public DbSet<PageGroup> PageGroups { get; set; }
        public DbSet<PageComment> PageComments { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<AdminLogin> AdminLogins{ get; set; }

    }
}
