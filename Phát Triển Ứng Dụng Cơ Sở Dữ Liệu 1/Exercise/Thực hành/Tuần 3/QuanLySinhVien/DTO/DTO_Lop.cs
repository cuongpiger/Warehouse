using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_Lop
    {
        private string MaLop;
        private string Khoa;
        private string Loai;
        private string LopTruong;

        public string MaLop1 { get => MaLop; set => MaLop = value; }
        public string Khoa1 { get => Khoa; set => Khoa = value; }
        public string Loai1 { get => Loai; set => Loai = value; }
        public string LopTruong1 { get => LopTruong; set => LopTruong = value; }

        public DTO_Lop()
        {
            MaLop = Khoa = Loai = "";
            LopTruong1 = "";
        }

        public DTO_Lop(string _MaLop, string _Khoa, string _Loai, string _LopTruong)
        {
            MaLop = _MaLop;
            Khoa = _Khoa;
            Loai = _Loai;
            LopTruong1 = _LopTruong;
        }

        public DTO_Lop(DTO_Lop other)
        {
            MaLop = other.MaLop;
            Khoa = other.Khoa;
            Loai = other.Loai;
            LopTruong1 = other.LopTruong1;
        }
    }
}
