using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai12
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double[] a;
            NhapMang(out a, out n);
            XuatMang(a, n);
            Console.WriteLine("Cac mang con giam dan: ");
            XuatMangCon(a, n);
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

        static void XuatMangCon(double[] a, int n)
        {
            for (int l = 1; l <= n; l++)
            {
                Console.WriteLine("Mang con co chieu dai {0} : ", l);
                XuatCon(a, n, l);
            }
        }

        static void XuatCon(double[] a, int n, int l)
        {
            for (int vt = 0; vt <= n - l; vt++)
            {
                if (KiemTraGiamDan(a, n, l, vt) == 1)
                    XuatCon(a, n, l, vt);
            }
        }

        static void XuatCon(double[] a, int n, int l, int vt)
        {
            for (int i = 0; i < l; i++)
            {
                Console.Write(a[vt + i] + " ");
            }
            Console.WriteLine();
        }

        static int KiemTraGiamDan(double[] a, int n, int l, int vt)
        {
            int flag = 1;
            for (int i = 0; i < l-1; i++)
            {
                if (a[vt + i] < a[vt + i + 1])
                    flag = 0;
            }
            return flag;
        }
    }
}
