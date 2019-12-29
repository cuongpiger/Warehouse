using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_3
{
    class project03
    {
        private double a, b, c;

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }

        public string solveProblem()
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    if (c != 0)
                    {
                        return ("Phương trình vô nghiệm");
                    }
                    else
                    {
                        return ("Phương trình có vô số nghiệm");
                    }
                }
                else
                {
                    double res = -c / b;
                    return "X = " + String.Format("{0:0.00}", res);
                }
            }
            else
            {
                double delta = b * b - 4 * a * c;

                if (delta > 0)
                {
                    double x1 = (-b - Math.Sqrt(delta)) / (2 * a);
                    double x2 = (-b + Math.Sqrt(delta)) / (2 * a);
                    return "X1 = " + String.Format("{0:0.00}", x1) + "\nX2 = " + String.Format("{0:0.00}", x2);
                }
                else if (delta == 0)
                {
                    double x = -b / (2 * a);
                    return "X = " + String.Format("{0:0.00}", x);
                }
                else
                {
                    return ("Phương trình vô nghiệm");
                }
            }
        }
    }
}
