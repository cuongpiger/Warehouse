using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_3
{
    class Class3
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

                    if (n < 0 || 1e9 < n)
                    {
                        Console.Write("\nVui long nhap gia tri trong khoang [{0}, {1}]", 0, 1e9);
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

        public bool IsTrue()
        {
            int multi = 1;

            while (multi < n)
            {
                multi *= 2;
            }

            if (multi == n)
            {
                return true;
            }

            return false;
        }

        public void Output()
        {
            if (this.IsTrue())
            {
                Console.Write("\nSo {0} co dang 2^k", n);
                return;
            }

            Console.Write("\nSo {0} khong co dang 2^k", n);
        }
    }
}
