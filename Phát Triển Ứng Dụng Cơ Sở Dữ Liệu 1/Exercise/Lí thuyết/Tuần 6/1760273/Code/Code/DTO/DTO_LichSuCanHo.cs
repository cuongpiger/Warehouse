using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.DTO
{
    public class DTO_LichSuCanHo
    {
        DateTime ngay;
        DTO_CanHo canHo;
        string ghiChu;

        public DateTime Ngay { get => ngay; set => ngay = value; }
        public DTO_CanHo CanHo { get => canHo; set => canHo = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
