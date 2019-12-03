using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BUS
{
    public class BUS_SinhVien
    {
        public DTO_SinhVien NhapSV()
        {
            DTO_SinhVien sv = new DTO_SinhVien();
            int ngay = 0, thang = 0, nam = 0;

            Console.WriteLine("Nhap ma sinh vien: ");
            sv.MaSV1 = Console.ReadLine();

            Console.WriteLine("Nhap ho ten sinh vien: ");
            sv.HoTen1 = Console.ReadLine();

            Console.WriteLine("Nhap ngay sinh: ");
            ngay = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap thang sinh: ");
            thang = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap nam sinh: ");
            nam = int.Parse(Console.ReadLine());

            sv.NgaySinh1 = new DateTime(nam, thang, ngay);

            Console.WriteLine("Nhap gioi tinh: ");
            sv.Phai1 = Console.ReadLine();

            Console.WriteLine("Nhap lop: ");
            sv.Lop1 = Console.ReadLine();

            Console.WriteLine("Nhap diem trung bình: ");
            sv.DTB1 = float.Parse(Console.ReadLine());

            return sv;
        }

        public void XuatSV(DTO_SinhVien sv)
        {
            Console.WriteLine("Ma sinh vien: {0}", sv.MaSV1);
            Console.WriteLine("Ho ten: {0}", sv.HoTen1);
            Console.WriteLine("Ngay sinh: {0}", sv.NgaySinh1.ToString("MM/dd/yyyy"));
            Console.WriteLine("Gioi tinh: {0}", sv.Phai1);
            Console.WriteLine("Lop: {0}", sv.Lop1);
            Console.WriteLine("Diem trung binh: {0}", sv.DTB1.ToString());
        }

        public List<DTO_SinhVien> NhapMangSV()
        {
            int n;
            Console.WriteLine("Nhap so luong sinh vien can them: ");
            n = int.Parse(Console.ReadLine());

            if (n != 0)
            {
                List<DTO_SinhVien> listSV = new List<DTO_SinhVien>();

                for (int i = 0; i < n; ++i)
                {
                    Console.WriteLine("Nhap sinh vien thu {0}", i + 1);
                    DTO_SinhVien newSV = this.NhapSV();
                    listSV.Add(newSV);
                }

                return listSV;
            }

            return null;
        }

        public void XuatMangSV(List<DTO_SinhVien> listSV)
        {
            int n = listSV.Count;
            for (int i = 0; i < n; ++i)
            {
                Console.WriteLine("Sinh vien thu {0}", i + 1);
                this.XuatSV(listSV[i]);
            }
        }

        public DTO_SinhVien TimSVCaoDiemNhat(List<DTO_SinhVien> listSV)
        {
            DTO_SinhVien res = listSV[0];

            for (int i = 1; i < listSV.Count; ++i)
            {
                if (listSV[i].DTB1 > res.DTB1)
                {
                    res = listSV[i];
                }
            }

            return res;
        }

        public DTO_SinhVien TimSVCaoThapNhat(List<DTO_SinhVien> listSV)
        {
            DTO_SinhVien res = listSV[0];

            for (int i = 1; i < listSV.Count; ++i)
            {
                if (listSV[i].DTB1 < res.DTB1)
                {
                    res = listSV[i];
                }
            }

            return res;
        }

        public void InDanhSachTheoGioiTinh(List<DTO_SinhVien> listSV, string gt)
        {
            int th = 1;

            for (int i = 0; i < listSV.Count; ++i)
            {
                if (listSV[i].Phai1 == gt)
                {
                    Console.WriteLine("Sinh vien thu {0}", th++);
                    this.XuatSV(listSV[i]);
                }
            }
        }

        public float DTBCuaMangSV(List<DTO_SinhVien> listSV)
        {
            float sum = 0;

            for (int i = 0; i < listSV.Count; ++i)
            {
                sum += listSV[i].DTB1;
            }

            return sum / listSV.Count;
        }

        public int TaoMenu()
        {
            Console.WriteLine("Thoat: 0");
            Console.WriteLine("In danh sach sinh vien: 1");
            Console.WriteLine("In SV co DTB lon nhat: 2");
            Console.WriteLine("In danh sach SV theo gioi tinh: 3");
            Console.WriteLine("In diem trung binh cong: 4");
            Console.WriteLine("Nhap lua chon cua ban: ");
            return int.Parse(Console.ReadLine());
        }
    }
}
