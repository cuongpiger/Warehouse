using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DTO
{
    public class DTO_QuanHeGiaDinh
    {
        DTO_GiayToTuyThan nguoiA;
        DTO_GiayToTuyThan nguoiB;
        string moiQuanHe;

        public DTO_GiayToTuyThan NguoiA { get => nguoiA; set => nguoiA = value; }
        public DTO_GiayToTuyThan NguoiB { get => nguoiB; set => nguoiB = value; }
        public string MoiQuanHe { get => moiQuanHe; set => moiQuanHe = value; }
    }
}
