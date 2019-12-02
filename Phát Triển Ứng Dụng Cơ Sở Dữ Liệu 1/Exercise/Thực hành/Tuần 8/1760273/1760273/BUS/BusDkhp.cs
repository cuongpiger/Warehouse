using _1760273.DAO;
using _1760273.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.BUS
{
    public class BusDkhp
    {
        static DaoDkhp daoDkhp = new DaoDkhp();

        public DataTable LoadListDkhpsWithMaSV(string maSV)
        {
            return daoDkhp.LoadListDkhpsWithMaSV(maSV);
        }

        public int InsertOneDkhp(DtoDkhp dtoDkhp)
        {
            return daoDkhp.InsertOneDkhp(dtoDkhp);
        }

        public int DeleteOneDkhp(string nh, string hk, string maSV, string maMH)
        {
            return daoDkhp.DeleteOneDkhp(nh, hk, maSV, maMH);
        }

        public int UpdateOneDkhp(DtoDkhp dtoDkhp)
        {
            return daoDkhp.UpdateOneStudent(dtoDkhp);
        }
    }
}
