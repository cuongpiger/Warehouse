using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DTO
{
    public class DTO_DiaDiem
    {
        string maTang;
        string maKhoi;
        int block;

        public string MaTang { get => maTang; set => maTang = value; }
        public string MaKhoi { get => maKhoi; set => maKhoi = value; }
        public int Block { get => block; set => block = value; }
    }
}
