using QuanLiSinhVien.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DAO
{
    public class SinhVien_DAO
    {
        public DB db = new DB();
        public DataTable GetAllData()
        {
            string sql = "select * from SINHVIEN";
            var res = db.GetDatabase(sql);

            return res;
        }

        public int DeleteSinhVienByMSSV(string p_mssv)
        {
            string sql = string.Format("delete from SINHVIEN where MSSV = {0}", p_mssv);
            return db.ExcuteSqlCommand(sql);
        }

        public int UpdateSinhVien(SinhVien sv)
        {
            string sql = string.Format("update SINHVIEN set HoTen = N'{0}', NgaySinh = '{1}', QueQuan = N'{2}', GioiTinh = N'{3}' where MSSV = '{4}'", 
                                        sv.HoTen1, sv.NgaySinh1, sv.QueQuan1, sv.GioiTinh1, sv.MSSV1);
            return db.ExcuteSqlCommand(sql);
        }

        public int AddSinhVien(SinhVien sv)
        {
            string sql = string.Format("insert into SINHVIEN values ('{0}', N'{1}', '{2}', N'{3}', N'{4}')",
                                        sv.MSSV1, sv.HoTen1, sv.NgaySinh1, sv.QueQuan1, sv.GioiTinh1);
            return db.ExcuteSqlCommand(sql);
        }
    }
}
