using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_4
{
    class Program
    {
        static void Main(string[] args)
        {
            double a = 0, b = 0, c = 0;
            bool check = false;

            Console.Write("Enter number segment a: ");

            while (!check)
            {
                try
                {
                    a = double.Parse(Console.ReadLine());

                    if (a < -1000000000 || 1000000000 < a)
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
            
            check = false;

            Console.Write("Enter number segment b: ");

            while (!check)
            {
                try
                {
                    b = double.Parse(Console.ReadLine());

                    if (b < -1000000000 || 1000000000 < b)
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

            check = false;

            Console.Write("Enter number segment c: ");

            while (!check)
            {
                try
                {
                    c = double.Parse(Console.ReadLine());

                    if (c < -1000000000 || 1000000000 < c)
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

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                Console.WriteLine("Khong phai tam giac");
            }
            else
            {
                if (a == b || a == c || b == c)
                {
                    if (a*a + b*b == c*c || a*a + c*c == b*b || b*b + c*c == a * a)
                    {
                        Console.WriteLine("La tam giac vuong can");
                    }
                    else if (a != b || a != c || b!= c)
                    {
                        Console.WriteLine("La tam giac can");
                    }
                    else
                    {
                        Console.WriteLine("La tam giac deu");
                    }
                }
                else if (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a)
                {
                    Console.WriteLine("La tam giac vuong");
                }
                else
                {
                    Console.WriteLine("La tam giac thuong");
                }
            }
        }
    }
}
