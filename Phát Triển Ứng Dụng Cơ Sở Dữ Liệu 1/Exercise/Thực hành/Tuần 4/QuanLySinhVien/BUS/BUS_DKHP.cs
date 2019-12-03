using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BUS
{
    public class BUS_DKHP
    {
        public DTO_DKHP NhapDKHP()
        {
            DTO_DKHP dkhp = new DTO_DKHP();

            Console.WriteLine("Nhap nam hoc: ");
            dkhp.NamHoc1 = Console.ReadLine();

            Console.WriteLine("Nhap hoc ki: ");
            dkhp.HocKi1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Nhap MSSV: ");
            dkhp.MSSV1 = Console.ReadLine();

            do
            {
                Console.WriteLine("Nhap so tin chi: ");
                dkhp.SoTC1 = int.Parse(Console.ReadLine());

                if (dkhp.SoTC1 >= 10)
                {
                    Console.WriteLine("So tin chi khong duoc lon 9");
                }
            } while (dkhp.SoTC1 >= 10);


            Console.WriteLine("Nhap dia diem: ");
            dkhp.DiaDiem1 = Console.ReadLine();

            Console.WriteLine("Nhap diem: ");
            dkhp.Diem1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Nhap ten mon hoc: ");
            dkhp.TenMonHoc1 = Console.ReadLine();

            return dkhp;
        }

        public void XuatDKHP(DTO_DKHP dkhp)
        {
            Console.WriteLine("Nam hoc: {0}", dkhp.NamHoc1);
            Console.WriteLine("Hoc ki: {0}", dkhp.HocKi1);
            Console.WriteLine("MSSV: {0}", dkhp.MSSV1);
            Console.WriteLine("So TC: {0}", dkhp.SoTC1);
            Console.WriteLine("Dia diem: {0}", dkhp.DiaDiem1);
            Console.WriteLine("Diem: {0}", dkhp.Diem1);
            Console.WriteLine("Mon hoc : {0}", dkhp.TenMonHoc1);
        }

        public void NhapDKHPs(DTO_DKHP[] arrDKHP)
        {
            for (int i = 0; i < arrDKHP.Length; ++i)
            {
                Console.WriteLine("Nhap thong tin hoc phan thu {0}:", i + 1);
                arrDKHP[i] = NhapDKHP();
            }
        }

        public void XuatSV_MonHoc(DTO_DKHP[] arrDKHP, string mssv)
        {
            Console.WriteLine("Danh sach cac mon da dang ky cua {0} la :", mssv);
            for (int i = 0; i < arrDKHP.Length; ++i)
            {
                if (arrDKHP[i].MSSV1 == mssv)
                {
                    Console.WriteLine("{0}", arrDKHP[i].TenMonHoc1);
                }
            }
        }

        public bool KiemTraDKHP(DTO_DKHP[] arrDKHP, string mssv)
        {
            int cnt = 0;
            for (int i = 0; i < arrDKHP.Length; ++i)
            {
                if (arrDKHP[i].MSSV1 == mssv)
                {
                    cnt = cnt + arrDKHP[i].SoTC1;
                }
            }
            if (cnt < 10)
            {
                return true;
            }

            return false;
        }

        public void XuatDSDKHPTheoLop(DTO_DKHP[] arrDKHP, string malop)
        {
            Console.WriteLine("Cac mon hoc da dang ky cua lop : ");
            for (int i = 0; i < arrDKHP.Length; ++i)
            {
                if (malop == arrDKHP[i].MaLop1)
                {
                    Console.WriteLine("{0}", arrDKHP[i].TenMonHoc1);
                } 
            }
        }
    }
}
