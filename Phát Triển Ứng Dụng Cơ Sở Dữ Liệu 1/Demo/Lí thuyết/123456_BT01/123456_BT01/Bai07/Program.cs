using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai07
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double[] a;
            NhapMang(out a, out n);
            XuatMang(a, n);
            Console.Write("Nhap gia tri x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Nhap vi tri k: ");
            int k = int.Parse(Console.ReadLine());
            ThemXVaoViTriK(ref a, ref n, x, k);

            Console.Write("Mang sau khi them gia tri {0} vao vi tri {1} : ", x, k);
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
                a[i] = double.Parse(Console.ReadLine());
            }
        }

        static void XuatMang(double[] a, int n)
        {
            for (int i = 0; i < n; i++)
                Console.WriteLine("a[{0}] = {1} ", i, a[i]);
        }

        static void ThemXVaoViTriK(ref double[] a, ref int n, double x, int k)
        {
            double []b = new double[n + 1];
            int i;
            for (i = 0; i < n; i++)
                b[i] = a[i];

           for (i = n - 1; i >= k; i--)
                b[i + 1] = b[i];
            b[k] = x;

            a = b;
            n = n + 1;
        }
    }
}
