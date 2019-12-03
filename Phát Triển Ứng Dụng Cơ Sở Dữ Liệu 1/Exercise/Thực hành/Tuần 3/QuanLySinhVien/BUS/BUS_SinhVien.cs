using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BUS
{
    public class BUS_SinhVien
    {
        private DAL_SinhVien dalSV = new DAL_SinhVien();
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

        public void SinhVienCoDiemCaoNhat_sql()
        {
            Console.WriteLine("Sinh Vien co diem trung binh cao nhat la: \n");
            DTO_SinhVien sv = new DTO_SinhVien();
            sv = dalSV.SinhVienCaoDiemNhat();
            XuatSV(sv);
        }

        public void TinhDiemTrungBinh_sql()
        {
            Console.WriteLine("Nhap ma so sinh vien can update diem: ");
            string mssv = Console.ReadLine();
            float res = dalSV.TinhDiemTrungBinh(mssv);
            Console.WriteLine("Diem trung binh la: {0}", res);
        }

        public void TinhTongDiemTrungBinh_sql()
        {
            float res = dalSV.TongDiemTrungBinh();
            Console.WriteLine("Tong diem trung binh cua cac sinh vien la: {0}", res);
        }

        public void UpdateDiemSV_sql()
        {
            float newScore = 0;
            string mssv = "";

            Console.WriteLine("Nhap ma so sinh vien can update diem: ");
            mssv = Console.ReadLine();
            Console.WriteLine("Nhap diem so can chinh sua cho sinh vien nay: ");
            newScore = float.Parse(Console.ReadLine());

            dalSV.UpdateDiemSV(mssv, newScore);
        }

        public void NhapSV_sql()
        {
            DTO_SinhVien sv = new DTO_SinhVien();
            sv = NhapSV();
            dalSV.InsertSV(sv);
        }

        public void NhapNhieuSinhVien_sql()
        {
            int soLuong = 0;
            Console.WriteLine("Nhap so luong sinh vien can nhap: "); soLuong = int.Parse(Console.ReadLine());

            for (int i = 0; i < soLuong; ++i)
            {
                Console.WriteLine("Sinh vien thu {0}", i + 1);
                NhapSV_sql();
            }

        }

        public void XuatSV_sql()
        {
            Console.WriteLine("Nhap ma sinh vien can in");
            string mssv = Console.ReadLine();
            DTO_SinhVien sv = new DTO_SinhVien();
            sv = dalSV.SelectSV(mssv);
            XuatSV(sv);
        }

        public void XuatDanhSachSinhVienTheoPhai_sql()
        {
            string phai = "Nam";
            Console.WriteLine("Nhap gioi tinh can tim de xuat: "); phai = Console.ReadLine();
            List<DTO_SinhVien> arrSV = dalSV.XuatSinhVienTheoPhai(phai);

            for (int i = 0; i < arrSV.Count(); ++i)
            {
                Console.WriteLine("\nSinh vien thu {0}\n", i + 1);
                XuatSV(arrSV[i]);
            }
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

        public void NhapDSSV(DTO_SinhVien[] arrSV)
        {
            Console.Clear();
            for (int i = 0; i < arrSV.Length; i++)
            {
                arrSV[i] = NhapSV();
            }
        }

        public void XuatDSSV(DTO_SinhVien[] arrSV)
        {
            for (int i = 0; i < arrSV.Length; i++)
            {
                Console.WriteLine("Sinh vien thu {0}", i + 1);
                XuatSV(arrSV[i]);
            }
        }

        public DTO_SinhVien TimSVCaoDiemNhat(DTO_SinhVien[] arrSV)
        {
            DTO_SinhVien res = arrSV[0];

            for (int i = 1; i < arrSV.Length; ++i)
            {
                if (arrSV[i].DTB1 > res.DTB1)
                {
                    res = arrSV[i];
                }
            }

            return res;
        }

        public void XuatDSTheoPhai(DTO_SinhVien[] arrSV)
        {
            string phai;
            Console.WriteLine("Nhap gioi tinh can in:");
            phai = Console.ReadLine();
            for (int i = 0; i < arrSV.Length; i++)
            {
                if (arrSV[i].Phai1 == phai)
                    XuatSV(arrSV[i]);
            }
        }

        public DTO_SinhVien TimSVThapDiemNhat(DTO_SinhVien[] arrSV)
        {
            DTO_SinhVien res = arrSV[0];

            for (int i = 1; i < arrSV.Length; ++i)
            {
                if (arrSV[i].DTB1 < res.DTB1)
                {
                    res = arrSV[i];
                }
            }

            return res;
        }

        public float DTBCuaMangSV(DTO_SinhVien[] arrSV)
        {
            float sum = 0;

            for (int i = 0; i < arrSV.Length; ++i)
            {
                sum += arrSV[i].DTB1;
            }

            return sum / arrSV.Length;
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
