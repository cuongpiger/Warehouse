using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1
{
    class Class1
    {
        private long n { get; set; }

        public void Input()
        {
            bool check = true;

            while (check)
            {
                try
                {
                    Console.Write("\nNhap vao gia tri n: ");
                    n = long.Parse(Console.ReadLine());

                    if (n < -1e9 || 1e9 < n)
                    {
                        Console.Write("\nVui long nhap gia tri trong khoang [{0}, {1}]", -1e9, 1e9);
                    }
                    else
                    {
                        check = false;
                    }
                }
                catch
                {
                    Console.Write("\nGia tri nhap vao khong hop le!");
                }

            }
        }

        private static long GiaiThua(long x)
        {
            if (x == 0)
            {
                return 0;
            }

            long gt = 1;

            for (int i = 1; i <= x; ++i)
            {
                gt *= i;
            }

            return gt;
        }

        public long Sum()
        {
            long sum = 0;
            long lim = n < 0 ? -n : n;

            for (int i = 0; i <= lim; ++i)
            {
                sum += Class1.GiaiThua(i);
            }

            return n < 0 ? -sum : sum;
        }

        public void Output()
        {
            Console.Write("\n{0}! = {1}", n, this.Sum());
        }
    }
}
