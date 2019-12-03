using System;
using System.Collections.Generic;
using System.Text;
using BUS;
using DTO;

namespace QuanLySinhVien
{
    class Program
    {
        static BUS_SinhVien global = new BUS_SinhVien();
        static BUS_Lop globalLop = new BUS_Lop();
        static void Main(string[] args)
        {
            List<DTO_SinhVien> listSV = global.NhapMangSV();
            int choose = global.TaoMenu();

            if (choose == 0 || choose > 4)
            {
                Console.WriteLine("Good bye");
                return;
            }
            else if (choose == 1)
            {
                Console.WriteLine("Danh sach cac sinh vien la");
                global.XuatMangSV(listSV);
            }
            else if (choose == 2)
            {
                DTO_SinhVien svMaxScr = global.TimSVCaoDiemNhat(listSV);
                Console.WriteLine("Sinh vien co diem trung binh cao nhat la");
                global.XuatSV(svMaxScr);
            }
            else if (choose == 3)
            {
                Console.WriteLine("Nhap gioi tinh can loc: ");
                string gt = Console.ReadLine();

                Console.WriteLine("Danh sach sinh vien co gioi tinh {0}", gt);
                global.InDanhSachTheoGioiTinh(listSV, gt);
            }
            else
            {
                Console.WriteLine("Diem trung binh cong cua cac sinh vien la: {0}", global.DTBCuaMangSV(listSV).ToString());
            }

            DTO_Lop lop = globalLop.NhapLop();
            globalLop.XuatLop(lop);
        }
    }
}
