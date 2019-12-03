using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiToanChiTietMay
{
    class ChiTietDon:ChiTiet
    {
        double _giaTien;

        public double GiaTien
        {
            get { return _giaTien; }
            set { _giaTien = value; }
        }

        public override void Nhap()
        {
            Console.Write("Nhap ma so: ");
            MaSo = Console.ReadLine();
            Console.Write("Nhap gia tien: ");
            GiaTien = double.Parse(Console.ReadLine());
        }

        public override void Xuat()
        {
            Console.WriteLine("Ma so: " + MaSo);
            Console.WriteLine("Gia tien: " + GiaTien);
        }

        public override ChiTiet TimKiem(string ms)
        {
            if (MaSo.Equals(ms) == true)
                return this;
            return null;
        }

        public override int DemChiTietDon()
        {
            return 1;
        }
    }
}
