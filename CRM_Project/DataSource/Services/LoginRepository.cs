using DataSource.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSource
{
    public class LoginRepository : ILoginRepository
    {
        private MyCmsContext db;
        public LoginRepository(MyCmsContext context)
        {
            db = context;
        }

        public bool IsExistUser(string username, string password)
        {
            return db.AdminLogins.Any(a => a.UserName.ToLower() == username.ToLower() && a.Password.ToLower() == password.ToLower());
        }
    }
}
