using QLBH_ProductManagement.DAO;
using QLBH_ProductManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_ProductManagement.BUS
{
    public class UserBUS
    {
        UserDAO userDAO = new UserDAO();
        public UserInfo Login(string userName, string password)
        {
            if (password.Length <= 2) return null;
            return userDAO.Login(userName, password);
        }
    }
}
