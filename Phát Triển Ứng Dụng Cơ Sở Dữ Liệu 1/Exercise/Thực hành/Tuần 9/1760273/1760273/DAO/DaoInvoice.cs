using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.DAO
{
    public class DaoInvoice
    {
        static DaoDB daoDB = new DaoDB();

        public DataTable LoadListInvoicesGoodsID(string goodsID)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@iGoodsID", goodsID));

            return daoDB.GetDataWithParameters("sLoadListInvoicesGoodsID", paras.ToArray());
        }

        public int CalcTotalInvoice(string goodsID)
        {
            int rs = 0;
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@iGoodsID", goodsID));
            DataTable res = daoDB.ExecuteFunction("select dbo.fCalcTotalInvoice(@iGoodsID) as res", paras.ToArray());

            try
            {
                rs = int.Parse(res.Rows[0][0].ToString());
            }
            catch
            {
                rs = 0;
            }

            return rs;
        }

        public DataTable LoadListInvoicesDetailsByInvoiceID(string invoiceID)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@iInvoiceID", invoiceID));

            return daoDB.GetDataWithParameters("sLoadListInvoicesDetailsByInvoiceID", paras.ToArray());
        }
    }
}
