using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BUS
{
    public class BUS_Lop
    {
        static BUS_SinhVien tmp = new BUS_SinhVien();
        public DTO_Lop NhapLop()
        {
            DTO_Lop lop = new DTO_Lop();

            Console.WriteLine("Nhap ma lop: ");
            lop.MaLop1 = Console.ReadLine();

            Console.WriteLine("Nhap khoa: ");
            lop.Khoa1 = Console.ReadLine();

            Console.WriteLine("Nhap loai lop: ");
            lop.Loai1 = Console.ReadLine();

            Console.WriteLine("Nhap danh sach lop: ");
            List<DTO_SinhVien> ls = tmp.NhapMangSV();
            lop.DsLop = ls;

            Console.WriteLine("Nhap thong tin lop truong: ");
            DTO_SinhVien lt = tmp.NhapSV();
            lop.LopTruong1 = lt;

            return lop;
        }

        public void XuatLop(DTO_Lop lop)
        {
            Console.WriteLine("Ma lop: {0}", lop.MaLop1);
            Console.WriteLine("Khoa: {0}", lop.Khoa1);
            Console.WriteLine("Loai lop: {0}", lop.Loai1);
            this.XuatLopTruong(lop);
            Console.WriteLine("Danh sach cac sinh vien trong lop la:");
            tmp.XuatMangSV(lop.DsLop);
            
        }

        public void XuatLopTruong(DTO_Lop lop)
        {
            Console.WriteLine("Thong tin lop truong la");
            tmp.XuatSV(lop.LopTruong1);
        }

        public void SinhVienCoDTBMax(DTO_Lop lop)
        {
            Console.WriteLine("Sinh vien co DTB cao nhat lop {0} la", lop.MaLop1);
            tmp.TimSVCaoDiemNhat(lop.DsLop);
        }
    }
}
