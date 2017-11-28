using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using System.Data.SqlClient;

namespace Models
{

    public class AccountModel
    {
        private PropertyDbContext context = null;
        public AccountModel()
        {
            context = new PropertyDbContext();
        }
        //public bool Login(string userName, string passWord)
        //{
        //    object[] sqlParas = new SqlParameter[]
        //    {
        //        new SqlParameter("@Email", userName),
        //        new SqlParameter("Password",passWord),
        //    };
        //    var res = context.Database.SqlQuery<bool>(
        //}
    }
}
