using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class SanPham
    {
        private string _maSP;
        private string _tenSP;
        private double _giaTien;
        private int _soLuong;
        private string _donVi;

        public string MaSP
        {
            get { return _maSP; }
            set { _maSP = value; }
        }

        public string TenSP
        {
            get { return _tenSP; }
            set { _tenSP = value; }
        }

        public double GiaTien
        {
            get { return _giaTien; }
            set { _giaTien = value; }
        }

        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        public string DonVi
        {
            get { return _donVi; }
            set { _donVi = value; }
        }

        public void Nhap()
        {
            Console.Write("Nhap ma san pham: ");
            MaSP = Console.ReadLine();
            Console.Write("Nhap ten san pham: ");
            TenSP = Console.ReadLine();
            Console.Write("Nhap gia tien: ");
            GiaTien = double.Parse(Console.ReadLine());
            Console.Write("Nhap so luong: ");
            SoLuong = int.Parse(Console.ReadLine());
            Console.Write("Nhap don vi tinh: ");
            DonVi = Console.ReadLine();

        }
    }
}
