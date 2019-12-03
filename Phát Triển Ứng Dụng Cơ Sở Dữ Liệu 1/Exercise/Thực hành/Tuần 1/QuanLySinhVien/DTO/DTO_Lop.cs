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
        private DTO_SinhVien LopTruong;
        private List<DTO_SinhVien> dsLop;

        public string MaLop1 { get => MaLop; set => MaLop = value; }
        public string Khoa1 { get => Khoa; set => Khoa = value; }
        public string Loai1 { get => Loai; set => Loai = value; }
        public DTO_SinhVien LopTruong1 { get => LopTruong; set => LopTruong = value; }
        public List<DTO_SinhVien> DsLop { get => dsLop; set => dsLop = value; }

        public DTO_Lop()
        {
            MaLop = Khoa = Loai = "";
            LopTruong = null;
            dsLop = null;
        }

        public DTO_Lop(string _MaLop, string _Khoa, string _Loai, DTO_SinhVien _LopTruong, List<DTO_SinhVien> _dsLop)
        {
            MaLop = _MaLop;
            Khoa = _Khoa;
            Loai = _Loai;
            LopTruong = _LopTruong;
            dsLop = _dsLop;
        }

        public DTO_Lop(DTO_Lop other)
        {
            MaLop = other.MaLop;
            Khoa = other.Khoa;
            Loai = other.Loai;
            LopTruong = other.LopTruong;
            dsLop = other.dsLop;
        }
    }
}
