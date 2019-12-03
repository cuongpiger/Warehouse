using System;
using System.Collections.Generic;
using System.Text;
using BUS;
using DTO;

namespace QuanLySinhVien
{
    class Program
    {
        static BUS_SinhVien bSV = new BUS_SinhVien();
        static BUS_Lop bLop = new BUS_Lop();
        static BUS_DKHP bDKPH = new BUS_DKHP();

        static void Main(string[] args)
        {
            //bSV.NhapSV_sql();
            //Console.ReadLine();

            //bSV.XuatDanhSachSinhVienTheoPhai_sql();
            //bSV.XuatSV_sql();

            //bSV.UpdateDiemSV_sql();
            //bSV.TinhDiemTrungBinh_sql();
            //bSV.SinhVienCoDiemCaoNhat_sql();
            //bSV.TinhTongDiemTrungBinh_sql();
        }
    }
}
