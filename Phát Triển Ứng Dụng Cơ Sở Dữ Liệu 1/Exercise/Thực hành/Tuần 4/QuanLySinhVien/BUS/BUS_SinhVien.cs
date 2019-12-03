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

        /// <summary>
        ///     Thêm một sinh viên vào table SINHVIEN
        /// </summary>
        /// <param name="sv">
        ///     Đối tượng cần thêm
        /// </param>
        /// <returns>
        ///     0 nếu như thêm thành công, ngược lại trả về 1
        /// </returns>
        public int NhapSV_sql(DTO_SinhVien sv)
        {
            return dalSV.InsertSV(sv);
        }

        /// <summary>
        ///     Nhập sinh viên từ bàn phím đồng thời cho user biết có thêm thành công hay không
        /// </summary>
        public void NhapSV()
        {
            DTO_SinhVien sv = new DTO_SinhVien();
            int ngay = 0, thang = 0, nam = 0;

            Console.Write("Nhap ma sinh vien: ");
            sv.MaSV1 = Console.ReadLine();

            Console.Write("Nhap ho ten sinh vien: ");
            sv.HoTen1 = Console.ReadLine();

            Console.Write("Nhap ngay sinh: ");
            ngay = int.Parse(Console.ReadLine());

            Console.Write("Nhap thang sinh: ");
            thang = int.Parse(Console.ReadLine());

            Console.Write("Nhap nam sinh: ");
            nam = int.Parse(Console.ReadLine());

            sv.NgaySinh1 = new DateTime(nam, thang, ngay);

            Console.Write("Nhap gioi tinh: ");
            sv.Phai1 = Console.ReadLine();

            Console.Write("Nhap lop: ");
            sv.Lop1 = Console.ReadLine();

            Console.Write("Nhap diem trung bình: ");
            sv.DTB1 = float.Parse(Console.ReadLine());

            if (NhapSV_sql(sv) != 1)
            {
                Console.WriteLine("Them sinh vien thanh cong");
            }
            else
            {
                Console.WriteLine("Them sinh vien khong thanh cong");
            }
        }

        /// <summary>
        ///     Nhập danh sách nhiều sinh viên
        /// </summary>
        public void NhapDanhSachSV()
        {
            int soLuong = 0;

            Console.Write("Nhap so luong sinh vien can nhap: ");
            soLuong = int.Parse(Console.ReadLine());

            for (int i = 0; i < soLuong; ++i)
            {
                Console.WriteLine("Sinh vien thu {0}", i + 1);
                NhapSV();
            }
        }

        /// <summary>
        ///     Xuất ra thông tin đầy đủ của một sinh viên ra màn hình
        /// </summary>
        /// <param name="sv">
        ///     Đối tượng sinh viên cần xuất
        /// </param>
        public void XuatThongTinSV(DTO_SinhVien sv)
        {
            Console.WriteLine("Ma sinh vien: {0}", sv.MaSV1);
            Console.WriteLine("Ho ten: {0}", sv.HoTen1);
            Console.WriteLine("Ngay sinh: {0}", sv.NgaySinh1.ToString("MM/dd/yyyy"));
            Console.WriteLine("Gioi tinh: {0}", sv.Phai1);
            Console.WriteLine("Lop: {0}", sv.Lop1);
            Console.WriteLine("Diem trung binh: {0}", sv.DTB1.ToString());
        }

        /// <summary>
        ///     Xuất thông tin của một sinh viên
        /// </summary>
        /// <param name="mssv">
        ///     Mã sinh viên cần tìm để xuất
        /// </param>
        public void XuatSV(string mssv)
        {
            DTO_SinhVien r_sv = new DTO_SinhVien();

            if (dalSV.SeekSV(mssv, ref r_sv) == 0)
            {
                XuatThongTinSV(r_sv);
            }
            else
            {
                Console.WriteLine("Khong tim thay sinh vien co ma sinh vien la: {0}", mssv);
            }
        }

        /// <summary>
        ///     Xuất thông tin các sinh viên từ danh sách các sinh viên
        /// </summary>
        /// <param name="arrSV">
        ///     Là mảng sinh viên đầu vào cần xuất
        /// </param>
        public void XuatDanhSachSV(DTO_SinhVien[] arrSV)
        {
            for (int i = 0; i < arrSV.Length; i++)
            {
                Console.WriteLine("Sinh vien thu {0}", i + 1);
                XuatThongTinSV(arrSV[i]);
            }
        }

        /// <summary>
        ///     Tìm sinh viên có điểm trung bình cao nhất
        /// </summary>
        public void SVCoDTBCaoNhat()
        {
            Console.WriteLine("Danh sach sinh vien co diem trung binh cao nhat la: \n");
            List<DTO_SinhVien> listSVRes = null;

            if (dalSV.SeekSVMaxScore(ref listSVRes) == 0)
            {
                for (int i = 0; i < listSVRes.Count(); ++i)
                {
                    Console.WriteLine("Sinh vien thu {0}:", i + 1);
                    XuatThongTinSV(listSVRes[i]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Co so du lieu cua sinh vien hien dang rong");
            }
        }

        /// <summary>
        /// Danh sách các sinh viên có điểm trung bình thấp nhất
        /// </summary>
        public void SVCoDTBThapNhat()
        {
            Console.WriteLine("Danh sach sinh vien co diem trung binh thap nhat la: \n");
            List<DTO_SinhVien> listSVRes = null;

            if (dalSV.SeekSVMinScore(ref listSVRes) == 0)
            {
                for (int i = 0; i < listSVRes.Count(); ++i)
                {
                    Console.WriteLine("Sinh vien thu {0}:", i + 1);
                    XuatThongTinSV(listSVRes[i]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Co so du lieu cua sinh vien hien dang rong");
            }
        }

        /// <summary>
        ///     Xuất thông tin sinh viên theo phái
        /// </summary>
        public void XuatDanhSachSVTheoPhai()
        {
            string phai = "Nam";
            Console.Write("Nhap gioi tinh can tim: "); phai = Console.ReadLine();
            List<DTO_SinhVien> listSVRes = null;
               
            if (dalSV.PrintSVGender(phai, ref listSVRes) == 0)
            {
                for (int i = 0; i < listSVRes.Count(); ++i)
                {
                    Console.WriteLine("Sinh vien thu {0}", i + 1);
                    XuatThongTinSV(listSVRes[i]);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Khong co sinh vien gioi tinh {0} trong CSDL", phai);
            }
        }

        //public void TinhDiemTrungBinh_sql()
        //{
        //    Console.WriteLine("Nhap ma so sinh vien can update diem: ");
        //    string mssv = Console.ReadLine();
        //    float res = dalSV.TinhDiemTrungBinh(mssv);
        //    Console.WriteLine("Diem trung binh la: {0}", res);
        //}

        //public void TinhTongDiemTrungBinh_sql()
        //{
        //    float res = dalSV.TongDiemTrungBinh();
        //    Console.WriteLine("Tong diem trung binh cua cac sinh vien la: {0}", res);
        //}

        //public void UpdateDiemSV_sql()
        //{
        //    float newScore = 0;
        //    string mssv = "";

        //    Console.WriteLine("Nhap ma so sinh vien can update diem: ");
        //    mssv = Console.ReadLine();
        //    Console.WriteLine("Nhap diem so can chinh sua cho sinh vien nay: ");
        //    newScore = float.Parse(Console.ReadLine());

        //    dalSV.UpdateDiemSV(mssv, newScore);
        //}











        //public void NhapDSSV(DTO_SinhVien[] arrSV)
        //{
        //    Console.Clear();
        //    for (int i = 0; i < arrSV.Length; i++)
        //    {
        //        arrSV[i] = NhapSV();
        //    }
        //}



        //public DTO_SinhVien TimSVCaoDiemNhat(DTO_SinhVien[] arrSV)
        //{
        //    DTO_SinhVien res = arrSV[0];

        //    for (int i = 1; i < arrSV.Length; ++i)
        //    {
        //        if (arrSV[i].DTB1 > res.DTB1)
        //        {
        //            res = arrSV[i];
        //        }
        //    }

        //    return res;
        //}

        //public void XuatDSTheoPhai(DTO_SinhVien[] arrSV)
        //{
        //    string phai;
        //    Console.WriteLine("Nhap gioi tinh can in:");
        //    phai = Console.ReadLine();
        //    for (int i = 0; i < arrSV.Length; i++)
        //    {
        //        if (arrSV[i].Phai1 == phai)
        //            XuatSV(arrSV[i]);
        //    }
        //}

        //public DTO_SinhVien TimSVThapDiemNhat(DTO_SinhVien[] arrSV)
        //{
        //    DTO_SinhVien res = arrSV[0];

        //    for (int i = 1; i < arrSV.Length; ++i)
        //    {
        //        if (arrSV[i].DTB1 < res.DTB1)
        //        {
        //            res = arrSV[i];
        //        }
        //    }

        //    return res;
        //}

        //public float DTBCuaMangSV(DTO_SinhVien[] arrSV)
        //{
        //    float sum = 0;

        //    for (int i = 0; i < arrSV.Length; ++i)
        //    {
        //        sum += arrSV[i].DTB1;
        //    }

        //    return sum / arrSV.Length;
        //}

        //public int TaoMenu()
        //{
        //    Console.WriteLine("Thoat: 0");
        //    Console.WriteLine("In danh sach sinh vien: 1");
        //    Console.WriteLine("In SV co DTB lon nhat: 2");
        //    Console.WriteLine("In danh sach SV theo gioi tinh: 3");
        //    Console.WriteLine("In diem trung binh cong: 4");
        //    Console.WriteLine("Nhap lua chon cua ban: ");
        //    return int.Parse(Console.ReadLine());
        //}
    }
}
