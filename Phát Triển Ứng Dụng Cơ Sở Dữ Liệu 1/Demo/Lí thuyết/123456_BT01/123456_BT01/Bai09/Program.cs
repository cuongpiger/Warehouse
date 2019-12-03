using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai09
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            double[] a;
            NhapMang(out a, out n);
            XuatMang(a, n);
            DuaSoMotVeDau(ref a, n);
            Console.Write("Mang a sau khi dua tat ca cac gia tri 1 ve dau: ");
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

        static void DuaSoMotVeDau(ref double[] a, int n)
        {
            int vt = 0;
            for (int i = 0; i < n; i++)
            {
                if (a[i] == 1)
                {
                    HoanVi(ref a[i], ref a[vt]);
                    vt++;
                }
            }
        }

        static void HoanVi(ref double a, ref double b)
        {
            double temp = a;
            a = b;
            b = temp;
        }
    }
}
