using QLBH_ProductManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_ProductManagement.DAO
{
    public class UserDAO
    {
        public db db = new db();
        public UserInfo Login(string userName, string password)
        {
            string sql 
 = string.Format("Select Id, RoleId from [User] Where UserName='{0}' and Password='{1}'"
 , userName, password);
            var tb = db.GetData(sql);
            if(tb!=null && tb.Rows.Count>0)
            {
                return new UserInfo()
                {
                    Id = int.Parse(tb.Rows[0]["Id"].ToString()),
                    RoleId = int.Parse(tb.Rows[0]["RoleId"].ToString())
                };
            }
            else
                return null;
        }
    }
}
