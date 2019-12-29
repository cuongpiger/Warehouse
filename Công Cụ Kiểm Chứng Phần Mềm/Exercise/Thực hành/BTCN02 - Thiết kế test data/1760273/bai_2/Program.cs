using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = 0;
            bool check = false;

            Console.Write("Enter year: ");

            while (!check)
            {
                try
                {
                    year = int.Parse(Console.ReadLine());

                    if (year < 1 || 1000000000 < year)
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

            check = ((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0);

            if (!check)
            {
                Console.WriteLine("{0} is a normal year", year);
            }
            else
            {
                Console.WriteLine("{0} is a leap year", year);
            }
        }
    }
}
