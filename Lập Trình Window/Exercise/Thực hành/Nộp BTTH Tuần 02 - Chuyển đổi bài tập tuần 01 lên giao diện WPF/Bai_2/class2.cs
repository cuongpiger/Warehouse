using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_2
{
    class class2
    {
        private double a, b;

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }

        public string solveProblem()
        {
            if (a == 0)
            {
                if (b == 0)
                {
                    return "The equation has no solution";
                }
                else
                {
                    return "The equation has a multitude of solutions";
                }
            }
            else
            {
                double res = -b / a;
                return "X = " + String.Format("{0:0.00}", res);
            }
        }
    }
}
