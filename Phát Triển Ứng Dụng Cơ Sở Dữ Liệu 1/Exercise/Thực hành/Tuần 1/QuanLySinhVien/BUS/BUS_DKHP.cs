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
        }
    }
}
