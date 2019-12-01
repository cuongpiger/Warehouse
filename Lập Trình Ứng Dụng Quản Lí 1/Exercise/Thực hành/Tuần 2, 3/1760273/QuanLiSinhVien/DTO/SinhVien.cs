using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DTO
{
    public class SinhVien
    {
        string MSSV;
        string HoTen;
        DateTime NgaySinh;
        string QueQuan;
        string GioiTinh;

        public string MSSV1 { get => MSSV; set => MSSV = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public DateTime NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string QueQuan1 { get => QueQuan; set => QueQuan = value; }
        public string GioiTinh1 { get => GioiTinh; set => GioiTinh = value; }

        public SinhVien(string mssv, string hoten, DateTime ngaysinh, string quequan, string gioitinh)
        {
            MSSV = mssv;
            HoTen = hoten;
            NgaySinh = ngaysinh;
            QueQuan = quequan;
            GioiTinh = gioitinh;
        }
    }
}
