using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_2
{
    class Class2
    {
        int a { get; set; }
        int b { get; set; }

        public void Input()
        {
            bool check = true;

            while (check)
            {
                try
                {
                    Console.Write("\nNhap vao gia tri a: ");
                    a = int.Parse(Console.ReadLine());

                    if (a < 0 || 1e9 < a)
                    {
                        Console.Write("\nVui long nhap gia tri trong khoang [{0}, {1}]", 1, 1e9);
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

            check = true;

            while (check)
            {
                try
                {
                    Console.Write("\nNhap vao gia tri b: ");
                    b = int.Parse(Console.ReadLine());

                    if (b < 0 || 1e9 < b)
                    {
                        Console.Write("\nVui long nhap gia tri trong khoang [{0}, {1}]", 1, 1e9);
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

        public static int gcd(int A, int B)
        {
            if (B == 0)
            {
                return A;
            }

            return gcd(B, A % B);
        }

        public void Output()
        {
            Console.Write("\nGCD({0}, {1}) = {2}", a, b, Class2.gcd(a, b));
        }
    }
}
