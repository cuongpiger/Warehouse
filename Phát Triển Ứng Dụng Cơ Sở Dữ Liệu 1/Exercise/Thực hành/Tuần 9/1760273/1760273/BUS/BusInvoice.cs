using _1760273.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.BUS
{
    public class BusInvoice
    {
        static DaoInvoice daoInvoice = new DaoInvoice();

        public DataTable LoadListInvoicesGoodsID(string goodsID)
        {
            return daoInvoice.LoadListInvoicesGoodsID(goodsID);
        }

        public int CalcTotalInvoice(string goodsID)
        {
            return daoInvoice.CalcTotalInvoice(goodsID);
        }

        public DataTable LoadListInvoicesDetailsByInvoiceID(string invoiceID)
        {
            return daoInvoice.LoadListInvoicesDetailsByInvoiceID(invoiceID);
        }
    }
}
