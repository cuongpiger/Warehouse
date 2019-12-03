using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DTO
{
    public class DTO_GiayToTuyThan
    {
        private string maSo;
        private string loaiGiayTo;

        public string MaSo { get => maSo; set => maSo = value; }
        public string LoaiGiayTo { get => loaiGiayTo; set => loaiGiayTo = value; }
    }
}
