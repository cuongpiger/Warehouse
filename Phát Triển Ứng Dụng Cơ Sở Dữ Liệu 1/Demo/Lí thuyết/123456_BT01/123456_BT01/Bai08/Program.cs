using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai08
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double[] a;
            NhapMang(out a, out n);
            XuatMang(a, n);
            Console.Write("Nhap k: ");
            int k = int.Parse(Console.ReadLine());
            XoaTaiViTriK(ref a, ref n,  k);
            Console.Write("Mang sau khi xoa tai vi tri {0} : ", k);
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

        static void XoaTaiViTriK(ref double[] a, ref int n, int k)
        {
            for (int i = k; i < n-1; i++)
                a[i] = a[i + 1];
            n--;
        }
    }
}
