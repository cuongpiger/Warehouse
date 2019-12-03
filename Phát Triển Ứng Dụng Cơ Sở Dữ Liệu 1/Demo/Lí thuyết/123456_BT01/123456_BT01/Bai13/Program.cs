using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai13
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double[] a;
            NhapMang(out a, out n);
            XuatMang(a, n);
        }

        static void NhapMang(out double[] a, out int n)
        {
            Console.Write("Nhap n: ");
            n = int.Parse(Console.ReadLine());
            a = new double[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("Nhap a[{0}]: ", i);
                double x = double.Parse(Console.ReadLine());
                int k = i - 1;
                for ( ; k >= 0 && a[k] < x; k--) 
                {
                    a[k + 1] = a[k];
                }
                a[k + 1] = x;
            }
        }

        static void XuatMang(double[] a, int n)
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine("a[{0}] = {1} ", i, a[i]);
        }
    }
}
