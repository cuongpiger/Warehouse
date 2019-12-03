using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai11
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double[] a;
            NhapMang(out a, out n);
            XuatMang(a, n);

            double[] b;
            int vt;
            TaoMangChuaCacGiaTriLe(a, n, out b, out vt);
            Console.WriteLine("Mang b: ");
            XuatMang(b, vt);
        }

        static void NhapMang(out double[] a, out int n)
        {
            Console.Write("Nhap n: ");
            n = int.Parse(Console.ReadLine());
            a = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}]: ", i);
                a[i] = double.Parse(Console.ReadLine());
            }
        }

        static void XuatMang(double[] a, int n)
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine("a[{0}] = {1} ", i, a[i]);
        }

        static void TaoMangChuaCacGiaTriLe(double[] a, int n, out double[] b, out int vt)
        {
            b = new double[n];
            vt = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] % 2 == 1)
                {
                    b[vt] = a[i];
                    vt = vt + 1;
                }
            }
        }
    }
}
