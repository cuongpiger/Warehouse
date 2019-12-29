using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_4
{
    class project04
    {
        private double costPhone;

        public double CostPhone { get => costPhone; set => costPhone = value; }

        public string solve()
        {
            double res = costPhone / 6.0;
            return "Số tiền mỗi tháng Hưng phải trả trong 6 thang: " + String.Format("{0:0.00}", res) + " VND";
        }
    }
}
