using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int day = 0, month = 0, year = 0;
            bool check = false;

            Console.Write("Nhap nam: ");
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

            Console.Write("Nhap thang: ");
            check = false;
            while (!check)
            {
                try
                {
                    month = int.Parse(Console.ReadLine());

                    if (month < 1 || 12 < month)
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

            Console.Write("Nhap ngay: ");
            check = false;
            while (!check)
            {
                int[] mon = { -1, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

                if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
                {
                    ++mon[2];
                }

                try
                {
                    day = int.Parse(Console.ReadLine());

                    if (day < 1 || mon[month] < day)
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

            int[] month_ = { -1, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0))
            {
                ++month_[2];
            }

            ++day;
            
            if (day > month_[month])
            {
                day = 1;
                ++month;

                if (month > 12)
                {
                    month = 1;
                    ++year;

                    if (year > 1000000000)
                    {
                        Console.WriteLine("Khong the tien hanh xuat ngay hom sau do du lieu nam vuot qua gioi han cho phep");
                        return;
                    }
                }
            }

            Console.WriteLine("Ngay hom sau: {0}/{1}/{2}", day, month, year);

        }
    }
}
