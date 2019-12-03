using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.DAO
{
    public class DaoGoods
    {
        static DaoDB daoDB = new DaoDB();

        public DataTable LoadListOrigins()
        {
            return daoDB.GetData("sLoadListOrigins");
        }

        public DataTable LoadListGoodsOrigin(string origin)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@iOrigin", origin));

            return daoDB.GetDataWithParameters("sLoadListGoodsOrigin", paras.ToArray());
        }
    }
}
