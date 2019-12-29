using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_4
{
    class Class4
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

        public static bool SoNguyenTo(int x)
        {
            if (x < 2)
            {
                return false;
            }
            else
            {
                for (int i = 2; i < x; ++i)
                {
                    if (x % i == 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public int SolveProblem()
        {
            int a = -1, b = -1;

            for (int i = n; i > 1; --i)
            {
                if (Class4.SoNguyenTo(i))
                {
                    a = i;
                    break;
                }
            }

            for (int i = n; ; ++i)
            {
                if (Class4.SoNguyenTo(i))
                {
                    b = i;
                    break;
                }
            }

            if (a != -1 || b != -1)
            {
                if (a != -1)
                {
                    return a;
                }
                else if (b != -1)
                {
                    return b;
                }
                else
                {
                    if (n - a < b - n)
                    {
                        return a;
                    }
                    else
                    {
                        return b;
                    }
                }
            }

            return -1;
        }

        public void Output()
        {
            int res = this.SolveProblem();

            if (res != -1)
            {
                Console.Write("\nSo nguyen to {0} gan voi gia tri {1} nhat", res, n);
            }
            else
            {
                Console.Write("\nKhong ton tai gia tri thoa yeu cau bai toan");
            }
        }
    }
}
