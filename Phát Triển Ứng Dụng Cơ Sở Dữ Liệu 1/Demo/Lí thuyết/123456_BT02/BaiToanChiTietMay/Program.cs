using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiToanChiTietMay
{
    class Program
    {
        static void Main(string[] args)
        {
            May may = new May();
            may.Nhap();
            may.Xuat();
            Console.WriteLine("Nhap ma so cua chi tiet can tim: ");
            string ms = Console.ReadLine();
            ChiTiet kq = may.TimKiem(ms);
            if (kq == null)
                Console.WriteLine("Khong tim thay !!!");
            else
            {
                Console.WriteLine("Tim thay chi tiet: ");
                kq.Xuat();
            }

            int SLChiTietDon = may.DemChiTietDon();
            Console.WriteLine("So luong chi tiet don la: " + SLChiTietDon);
        }
    }
}
