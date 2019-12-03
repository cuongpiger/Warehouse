using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DTO
{
    public class DTO_CanHo
    {
        string maCanHo;
        DTO_DiaDiem diaDiem;
        float dienTich;
        string loaiCanHo;
        DTO_GiayToTuyThan chuCanHo;

        public string MaCanHo { get => maCanHo; set => maCanHo = value; }
        public DTO_DiaDiem DiaDiem { get => diaDiem; set => diaDiem = value; }
        public float DienTich { get => dienTich; set => dienTich = value; }
        public string LoaiCanHo { get => loaiCanHo; set => loaiCanHo = value; }
        public DTO_GiayToTuyThan ChuCanHo { get => chuCanHo; set => chuCanHo = value; }
    }
}
