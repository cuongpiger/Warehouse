using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0, b = 0;
            bool check = false;

            Console.Write("Enter number A: ");

            while (!check)
            {
                try
                {
                    a = int.Parse(Console.ReadLine());
                    
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
            Console.Write("Enter number B: ");

            while (!check)
            {
                try
                {
                    b = int.Parse(Console.ReadLine());

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

            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
        }
    }
}
