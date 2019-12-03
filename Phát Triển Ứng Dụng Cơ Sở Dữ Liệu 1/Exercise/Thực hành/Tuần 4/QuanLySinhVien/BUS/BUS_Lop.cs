using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BUS
{
    public class BUS_Lop
    {
        //static BUS_SinhVien tmp = new BUS_SinhVien();
        //public DTO_Lop NhapLop()
        //{
        //    DTO_Lop lop = new DTO_Lop();

        //    Console.WriteLine("Nhap ma lop: ");
        //    lop.MaLop1 = Console.ReadLine();

        //    Console.WriteLine("Nhap khoa: ");
        //    lop.Khoa1 = Console.ReadLine();

        //    Console.WriteLine("Nhap loai lop: ");
        //    lop.Loai1 = Console.ReadLine();

        //    Console.WriteLine("Nhap MSSV lop truong: ");
        //    lop.LopTruong1 = Console.ReadLine();

        //    return lop;
        //}

        //public void NhapThongTinCacLop(DTO_Lop[] arrLop)
        //{
        //    for (int i = 0; i < arrLop.Length; i++)
        //    {
        //        Console.WriteLine("Nhap thong tin lop thu {0}: ", i + 1);
        //        arrLop[i] = NhapLop();
        //    }
        //}

        //public void XuatLop(DTO_Lop lop)
        //{
        //    Console.WriteLine("Ma lop : {0}", lop.MaLop1);
        //    Console.WriteLine("Khoa : {0}", lop.Khoa1);
        //    Console.WriteLine("Loai lop : {0}", lop.Loai1);
        //    Console.WriteLine("Lop truong : {0}", lop.LopTruong1);

        //}

        ////public void XuatDSSVThuocLop(string malop, DTO_SinhVien[] arrSV)
        ////{
        ////    BUS_SinhVien b_sv = new BUS_SinhVien();
        ////    foreach (DTO_SinhVien element in arrSV)
        ////    {
        ////        if (malop == element.Lop1)
        ////        {
        ////            b_sv.XuatSV(element);
        ////            return;
        ////        }
        ////    }
        ////}

        //public void XuatThongTinMotLop(string maLop, DTO_Lop[] arrLop)
        //{
        //    for (int i = 0; i < arrLop.Length; i++)
        //    {
        //        if (maLop == arrLop[i].MaLop1)
        //        {
        //            XuatLop(arrLop[i]);
        //            return;
        //        }
        //    }
        //}

        //public DTO_SinhVien SVCoDTBCaoNhat(string maLop, DTO_SinhVien[] arrSV)
        //{
        //    BUS_SinhVien b_sv = new BUS_SinhVien();
        //    int pos = 0;
        //    float t = arrSV[0].DTB1;
        //    for (int i = 0; i < arrSV.Length; i++)
        //    {
        //        if (arrSV[i].Lop1 == maLop && arrSV[i].DTB1 > t)
        //        {
        //            t = arrSV[i].DTB1;
        //            pos = i;
        //        }
        //    }
        //    if (arrSV[pos].Lop1 != maLop)
        //        return null;

        //    return arrSV[pos];
        //}

        //public void ThongTinLopTruong(string malop, DTO_Lop[] arrLop, DTO_SinhVien[] arrSV)
        //{
        //    DTO_Lop lop = new DTO_Lop();
        //    for (int i = 0; i < arrLop.Length; i++)
        //    {
        //        if (malop == arrLop[i].MaLop1)
        //            lop = new DTO_Lop(arrLop[i]);
        //    }
        //    BUS_SinhVien bsv = new BUS_SinhVien();
        //    foreach (DTO_SinhVien element in arrSV)
        //    {
        //        if (element.MaSV1 == lop.LopTruong1)
        //        {
        //            bsv.XuatSV(element);
        //            return;
        //        }
        //    }
        //}
    }
}
