using _1760273.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.DAO
{
    public class DaoClass
    {
        static DaoDB daoDB = new DaoDB();

        public int InsertOneClass(DtoClass other)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iMaLop", other.MaLop));
            sqlParameters.Add(new SqlParameter("@iKhoa", other.Khoa));
            sqlParameters.Add(new SqlParameter("@iLoai", other.Loai));
            sqlParameters.Add(new SqlParameter("@iLopTruong", other.LopTruong));

            return daoDB.ExecuteStoredProcedure("stpInsertOneClass", sqlParameters.ToArray());
        }

        public int DeleteOneClass(string maLop)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iMaLop", maLop));

            return daoDB.ExecuteStoredProcedure("spdDeleteOneClass", sqlParameters.ToArray());
        }

        public int UpdateOneClass(DtoClass other)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iMaLop", other.MaLop));
            sqlParameters.Add(new SqlParameter("@iKhoa", other.Khoa));
            sqlParameters.Add(new SqlParameter("@iLoai", other.Loai));
            sqlParameters.Add(new SqlParameter("@iLopTruong", other.LopTruong));

            return daoDB.ExecuteStoredProcedure("spdUpdateOneClass", sqlParameters.ToArray());
        }

        public DataTable LoadListClasses()
        {
            return daoDB.GetData("spdLoadListClasses");
        }
    }
}
