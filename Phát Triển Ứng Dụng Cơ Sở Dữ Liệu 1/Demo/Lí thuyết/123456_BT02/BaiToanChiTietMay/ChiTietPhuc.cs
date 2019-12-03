using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiToanChiTietMay
{
    class ChiTietPhuc:ChiTiet
    {
        int n;
        ChiTiet[] ds;
        public override void Nhap()
        {
            Console.Write("Nhap ma so: ");
            MaSo = Console.ReadLine();
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

        public override void Xuat()
        {
            Console.WriteLine("Ma so: " + MaSo);
            Console.WriteLine("Co {0} chi tiet con: " , n);
            for (int i = 0; i < n; i++)
            {
                ds[i].Xuat();
            }
        }

        public override ChiTiet TimKiem(string ms)
        {
            if (MaSo.Equals(ms) == true)
                return this;
            for (int i = 0; i < n; i++)
            {
                ChiTiet kq = ds[i].TimKiem(ms);
                if (kq != null)
                    return kq;
            }
            return null;
        }

        public override int DemChiTietDon()
        {
            int dem = 0;
            for (int i = 0; i < n; i++)
                dem = dem + ds[i].DemChiTietDon();
            return dem;
        }
    }
}
