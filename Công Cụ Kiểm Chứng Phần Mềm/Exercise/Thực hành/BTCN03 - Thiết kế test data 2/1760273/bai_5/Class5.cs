using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_5
{
    class Class5
    {
        int n { get; set; }

        public void Input()
        {
            bool check = true;

            while (check)
            {
                try
                {
                    Console.Write("\nNhap vao gia tri n: ");
                    n = int.Parse(Console.ReadLine());

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

        public bool Solve()
        {
            int right = 10;
            int num = Math.Abs(n);

            while (num > 0)
            {
                int left = num % 10;
                num /= 10;

                if (left > right)
                {
                    return false;
                }
                {
                    right = left;
                }
            }

            return true;
        }

        public void Output()
        {
            if (this.Solve())
            {
                Console.Write("\nCac chu so cua so {0} tang dan tu trai qua phai", n);
            }
            else
            {
                Console.Write("\nCac chu so cua so {0} khong tang dan tu trai qua phai", n);
            }
        }
    }
}
