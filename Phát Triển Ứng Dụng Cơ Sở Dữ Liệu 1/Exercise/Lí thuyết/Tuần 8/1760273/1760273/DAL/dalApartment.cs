using _1760273.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.DAL
{
    public class dalApartment
    {
        static dalDB dalDB = new dalDB();

        public DataTable LoadApartment()
        {
            return dalDB.GetData("sLoadApartment");
        }

        public DataTable MaxIDApartment()
        {
            return dalDB.GetData("sMaxIDApartment");
        }

        public int InsertApartment(dtoApartment other)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@iLoai", other.CategoryID));
            paras.Add(new SqlParameter("@iDienTich", other.Acreage));
            paras.Add(new SqlParameter("@iTang", other.FloorID));
            paras.Add(new SqlParameter("@iKhoi", other.BlockID));
            paras.Add(new SqlParameter("@iChuNha", other.HostID));

            return dalDB.ExecuteStoredProcedure("sInsertApartment", paras.ToArray());
        }

        public int UpdateApartment(dtoApartment other)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@iID", other.ID));
            paras.Add(new SqlParameter("@iLoai", other.CategoryID));
            paras.Add(new SqlParameter("@iDienTich", other.Acreage));
            paras.Add(new SqlParameter("@iTang", other.FloorID));
            paras.Add(new SqlParameter("@iKhoi", other.BlockID));
            paras.Add(new SqlParameter("@iChuNha", other.HostID));

            return dalDB.ExecuteStoredProcedure("sUpdateApartment", paras.ToArray());
        }

        public int DeleteApartment(int id)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@iID", id));

            return dalDB.ExecuteStoredProcedure("sDeleteApartment", paras.ToArray());
        }

        public DataTable LoadApartmentWithID(int id)
        {
            List<SqlParameter> paras = new List<SqlParameter>();
            paras.Add(new SqlParameter("@iID", id));

            return dalDB.GetDataWithParameters("sLoadApartmentWithID", paras.ToArray());
        }
    }
}
