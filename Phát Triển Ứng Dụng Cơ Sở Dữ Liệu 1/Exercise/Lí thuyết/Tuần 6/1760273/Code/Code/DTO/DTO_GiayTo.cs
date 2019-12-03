using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DTO
{
    public class DTO_GiayTo
    {
        private string loaiGiayTo;
        private string hinhAnh;
        private DTO_GiayToTuyThan cmnd;

        public string LoaiGiayTo { get => loaiGiayTo; set => loaiGiayTo = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public DTO_GiayToTuyThan Cmnd { get => cmnd; set => cmnd = value; }
    }
}
