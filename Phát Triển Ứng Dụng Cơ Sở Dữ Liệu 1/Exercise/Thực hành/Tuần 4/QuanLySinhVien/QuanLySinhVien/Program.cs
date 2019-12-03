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
            //bSV.NhapSV();

            //string mssv = "";
            //Console.Write("Nhap MSSV can tim: ");
            //mssv = Console.ReadLine();
            //bSV.XuatSV(mssv);

            //bSV.SVCoDTBThapNhat();
            //bSV.SVCoDTBCaoNhat();

            bSV.XuatDanhSachSVTheoPhai();
        }
    }
}
