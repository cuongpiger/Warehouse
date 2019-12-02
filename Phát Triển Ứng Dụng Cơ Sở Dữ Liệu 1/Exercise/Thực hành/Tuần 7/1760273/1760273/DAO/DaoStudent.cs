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
    public class DaoStudent
    {
        static DaoDB daoDB = new DaoDB();

        public int InsertOneStudent(DtoStudent other)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iMaSV", other.MaSV));
            sqlParameters.Add(new SqlParameter("@iHoTen", other.HoTen));
            sqlParameters.Add(new SqlParameter("@iNgaySinh", other.NgaySinh));
            sqlParameters.Add(new SqlParameter("@iPhai", other.Phai));
            sqlParameters.Add(new SqlParameter("@iLop", other.Lop));
            sqlParameters.Add(new SqlParameter("@iDTB", other.DTB));
            
            return daoDB.ExecuteStoredProcedure("stpInsertOneStudent", sqlParameters.ToArray());
        }

        public int DeleteOneStudent(string studentID)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iMaSV", studentID));

            return daoDB.ExecuteStoredProcedure("spdDeleteOneStudent", sqlParameters.ToArray());
        }

        public int UpdateOneStudent(DtoStudent other)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iMaSV", other.MaSV));
            sqlParameters.Add(new SqlParameter("@iHoTen", other.HoTen));
            sqlParameters.Add(new SqlParameter("@iNgaySinh", other.NgaySinh));
            sqlParameters.Add(new SqlParameter("@iPhai", other.Phai));
            sqlParameters.Add(new SqlParameter("@iLop", other.Lop));
            sqlParameters.Add(new SqlParameter("@iDTB", other.DTB));

            return daoDB.ExecuteStoredProcedure("spdUpdateOneStudent", sqlParameters.ToArray());
        }

        public DataTable LoadListStudents()
        {
            return daoDB.GetData("spdLoadListStudents");
        }

        public DataTable LoadListStudentsWithClassID(string maLop)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@iMaLop", maLop));

            return daoDB.GetDataWithParameters("spdLoadListStudentsWithClassID", sqlParameters.ToArray());
        }
    }
}
