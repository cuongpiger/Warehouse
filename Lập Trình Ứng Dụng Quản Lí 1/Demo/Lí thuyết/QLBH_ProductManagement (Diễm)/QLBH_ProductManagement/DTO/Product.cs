using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_ProductManagement
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string Code { get; set; }
        public int SupplierId { get; set; }
    }
}
