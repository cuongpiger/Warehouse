using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiToanChiTietMay
{
    class May
    {
        int n;
        ChiTiet[] ds;

        public void Nhap()
        {
            Console.Write("Nhap n: ");
            n = int.Parse(Console.ReadLine());
            ds = new ChiTiet[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap loai(0. Chi Tiet Don, 1. Chi Tiet Phuc): ");
                int loai = int.Parse(Console.ReadLine());
                if (loai == 0)
                    ds[i] = new ChiTietDon();
                else if (loai == 1)
                    ds[i] = new ChiTietPhuc();
                ds[i].Nhap();
            }

        }

        public void Xuat()
        {
            Console.WriteLine("Cac chi tiet con la: ");
            for (int i = 0; i < n; i++)
                ds[i].Xuat();
        }

        public ChiTiet TimKiem(string ms)
        {
            for (int i = 0; i < n; i++)
            {
                ChiTiet kq = ds[i].TimKiem(ms);
                if (kq != null)
                    return kq;
            }
            return null;
        }

        public int DemChiTietDon()
        {
            int dem=0;
            for (int i = 0; i < n; i++)
                dem = dem + ds[i].DemChiTietDon();
            return dem;
        }
    }
}
