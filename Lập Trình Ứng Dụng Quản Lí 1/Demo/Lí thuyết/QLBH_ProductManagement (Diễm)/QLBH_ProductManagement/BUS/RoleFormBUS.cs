using QLBH_ProductManagement.DAO;
using QLBH_ProductManagement.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_ProductManagement.BUS
{
    public class RoleFormBUS
    {
        RoleFormDAO roleFormDAO = new RoleFormDAO();

        public List<RoleForm> GetList(int roleId)
        {
            return roleFormDAO.GetList(roleId);
        }

    }
}
