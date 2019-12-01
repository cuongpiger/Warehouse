using Northwind.DTB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DAO
{
    public class DAO_Product
    {
        static Database database = new Database();

        public DataTable GetDataDependCategoryID(int categoryID)
        {
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@i_category", categoryID));
            var dataTable = database.DTB_GetDatabase("GetDataDependCategoryID", lstParams);

            return dataTable;
        }
    }
}
