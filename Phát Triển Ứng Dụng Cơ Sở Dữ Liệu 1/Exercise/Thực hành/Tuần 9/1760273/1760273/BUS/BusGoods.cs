using _1760273.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.BUS
{
    public class BusGoods
    {
        static DaoGoods daoGoods = new DaoGoods();

        public DataTable LoadListOrigins()
        {
            return daoGoods.LoadListOrigins();
        }

        public DataTable LoadListGoodsOrigin(string origin)
        {
            return daoGoods.LoadListGoodsOrigin(origin);
        }
    }
}
