using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_SinhVien
    {
        private string MaSV;
        private string HoTen;
        private DateTime NgaySinh;
        private string Phai;
        private string Lop;
        private float DTB;

        public string MaSV1 { get => MaSV; set => MaSV = value; }
        public string HoTen1 { get => HoTen; set => HoTen = value; }
        public DateTime NgaySinh1 { get => NgaySinh; set => NgaySinh = value; }
        public string Phai1 { get => Phai; set => Phai = value; }
        public string Lop1 { get => Lop; set => Lop = value; }
        public float DTB1 { get => DTB; set => DTB = value; }

        public DTO_SinhVien()
        {
            MaSV = HoTen = Phai = Lop = "";
            NgaySinh = new DateTime(1990, 1, 1);
            DTB = -1;
        }

        public DTO_SinhVien(string _MaSV, string _HoTen, DateTime _NgaySinh, string _Phai, string _Lop, float _DTB)
        {
            MaSV = _MaSV;
            HoTen = _HoTen;
            NgaySinh = _NgaySinh;
            Phai = _Phai;
            Lop = _Lop;
            DTB = _DTB;
        }

        public DTO_SinhVien(DTO_SinhVien other)
        {
            MaSV = other.MaSV;
            HoTen = other.HoTen;
            NgaySinh = other.NgaySinh;
            Phai = other.Phai;
            Lop = other.Lop;
            DTB = other.DTB;
        }
    }
}
