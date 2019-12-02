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
    public class DaoDkhp
    {
        static DaoDB daoDB = new DaoDB();

        public DataTable LoadListDkhpsWithMaSV(string stuID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iMaSV", stuID));

            return daoDB.GetDataWithParameters("spdLoadListDkhpsWithMaSV", sqlParameters.ToArray());
        }

        public int InsertOneDkhp(DtoDkhp other)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iNH", other.NH));
            sqlParameters.Add(new SqlParameter("@iHK", other.HK));
            sqlParameters.Add(new SqlParameter("@iMaSV", other.MaSV));
            sqlParameters.Add(new SqlParameter("@iMaMH", other.MaMH));
            sqlParameters.Add(new SqlParameter("@iSoTC", other.SoTC));
            sqlParameters.Add(new SqlParameter("@iDiaDiem", other.DiaDiem));
            sqlParameters.Add(new SqlParameter("@iDiem", other.Diem));

            return daoDB.ExecuteStoredProcedure("stpInsertOneDkhp", sqlParameters.ToArray());
        }

        public int DeleteOneDkhp(string nh, string hk, string maSV, string maMH)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iNH", nh));
            sqlParameters.Add(new SqlParameter("@iHK", hk));
            sqlParameters.Add(new SqlParameter("@iMaSV", maSV));
            sqlParameters.Add(new SqlParameter("@iMaMH", maMH));

            return daoDB.ExecuteStoredProcedure("spdDeleteOneDkhp", sqlParameters.ToArray());
        }

        public int UpdateOneStudent(DtoDkhp other)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iNH", other.NH));
            sqlParameters.Add(new SqlParameter("@iHK", other.HK));
            sqlParameters.Add(new SqlParameter("@iMaSV", other.MaSV));
            sqlParameters.Add(new SqlParameter("@iMaMH", other.MaMH));
            sqlParameters.Add(new SqlParameter("@iSoTC", other.SoTC));
            sqlParameters.Add(new SqlParameter("@iDiaDiem", other.DiaDiem));
            sqlParameters.Add(new SqlParameter("@iDiem", other.Diem));

            return daoDB.ExecuteStoredProcedure("spdUpdateOneDkhp", sqlParameters.ToArray());
        }
    }
}
