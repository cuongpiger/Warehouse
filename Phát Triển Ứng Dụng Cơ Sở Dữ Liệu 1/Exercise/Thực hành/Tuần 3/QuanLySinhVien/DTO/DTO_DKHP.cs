using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DTO_DKHP
    {
        private string NamHoc;
        private int HocKi;
        private string MSSV;
        private int SoTC;
        private string DiaDiem;
        private float Diem;
        private string TenMonHoc;
        private string MaLop;

        public string NamHoc1 { get => NamHoc; set => NamHoc = value; }
        public int HocKi1 { get => HocKi; set => HocKi = value; }
        public string MSSV1 { get => MSSV; set => MSSV = value; }
        public int SoTC1 { get => SoTC; set => SoTC = value; }
        public string DiaDiem1 { get => DiaDiem; set => DiaDiem = value; }
        public float Diem1 { get => Diem; set => Diem = value; }
        public string TenMonHoc1 { get => TenMonHoc; set => TenMonHoc = value; }
        public string MaLop1 { get => MaLop; set => MaLop = value; }

        public DTO_DKHP()
        {
            NamHoc = MSSV = DiaDiem = "";
            HocKi = SoTC = 0;
            Diem = 0;
        }

        public DTO_DKHP(string _NamHoc, int _HocKi, string _MSSV, int _SoTC, string _DiaDiem, float _Diem, string _TenMH, string _MaLop)
        {
            NamHoc = _NamHoc;
            HocKi = _HocKi;
            MSSV = _MSSV;
            SoTC = _SoTC;
            DiaDiem = _DiaDiem;
            Diem = _Diem;
            TenMonHoc = _TenMH;
            MaLop = _MaLop;
        }

        public DTO_DKHP(DTO_DKHP other)
        {
            NamHoc = other.NamHoc;
            HocKi = other.HocKi;
            MSSV = other.MSSV;
            SoTC = other.SoTC;
            DiaDiem = other.DiaDiem;
            Diem = other.Diem;
            TenMonHoc = other.TenMonHoc;
            MaLop = other.MaLop;
        }
    }
}
