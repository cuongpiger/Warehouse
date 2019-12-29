using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_1
{
    public class Coor
    {
        private int x;
        private int y;

        public Coor(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public double CalcDistance(Coor b)
        {
            return Math.Sqrt(Math.Pow(x - b.x, 2.0) + Math.Pow(y - b.y, 2.0));
        }
    }
}
