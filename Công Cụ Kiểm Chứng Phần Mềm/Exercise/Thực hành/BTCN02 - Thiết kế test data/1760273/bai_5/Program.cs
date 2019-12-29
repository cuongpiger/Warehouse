using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_5
{
    class Program
    {
        static void Main(string[] args)
        {
            double kw = 0;
            double res = 0;

            bool check = false;

            Console.Write("Nhap so kilo dien: ");

            while (!check)
            {
                try
                {
                    kw = double.Parse(Console.ReadLine());

                    if (kw < 0 || 1000000000 < kw)
                    {
                        Console.WriteLine("Du lieu vuot qua gioi han cho phep");
                    }
                    else
                    {
                        check = true;
                    }
                }
                catch
                {
                    Console.WriteLine("Kieu du lieu khong hop le");
                }
            }

            if (kw <= 50)
            {
                res = kw * 1549;
            }
            else if (kw <= 100)
            {
                res = 1549 * 50 + (kw - 50) * 1600;
            }
            else if (kw <= 200)
            {
                res = 1549 * 50 + 1600 * 50 + (kw - 100) * 1858;
            }
            else if (kw <= 300)
            {
                res = 1549 * 50 + 1600 * 50 + 100 * 1858 + (kw - 200) * 2340;
            }
            else if (kw <= 400)
            {
                res = 1549 * 50 + 1600 * 50 + 100 * 1858 + 100 * 2340 + (kw - 300) * 2615;
            }
            else
            {
                res = 1549 * 50 + 1600 * 50 + 100 * 1858 + 100 * 2340 + 100 * 2615 + (kw - 400) * 2701;
            }

            res = res * (1 + 0.1);

            Console.WriteLine("So tien dien phai tra la: {0}", res);
        }
    }
}
