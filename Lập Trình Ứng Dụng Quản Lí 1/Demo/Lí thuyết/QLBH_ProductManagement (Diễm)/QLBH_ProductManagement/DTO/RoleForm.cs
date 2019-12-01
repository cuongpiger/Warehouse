using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_ProductManagement.DTO
{
    public class RoleForm
    {
        public int Id { get; set; }
        public int RoleId { get; set; }

        public int FormId { get; set; }

        public bool  Access { get; set; }

        public bool Insert { get; set; }

        public bool Delete { get; set; }

        public bool Update { get; set; }

        public bool Print { get; set; }

        public bool Import { get; set; }

        public bool Export { get; set; }


    }
}
