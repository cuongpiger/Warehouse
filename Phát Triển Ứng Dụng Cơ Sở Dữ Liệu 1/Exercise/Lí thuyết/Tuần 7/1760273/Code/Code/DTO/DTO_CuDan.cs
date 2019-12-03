using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DTO
{
    public class DTO_CuDan
    {
        string hoTen;
        string sdt;
        DTO_GiayToTuyThan cmnd;

        public string HoTen { get => hoTen; set => hoTen = value; }
        public string Sdt { get => sdt; set => sdt = value; }
        public DTO_GiayToTuyThan Cmnd { get => cmnd; set => cmnd = value; }
    }
}
