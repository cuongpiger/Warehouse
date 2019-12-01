using QLBH_ProductManagement.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_ProductManagement.BUS
{
    public class ProductBUS
    {
        ProductDAO productDAO = new ProductDAO();

        public DataTable GetAllData()
        {
            return productDAO.GetAllData();
        }

        public int DeleteById(int productId)
        {
            return productDAO.DeleteById(productId);
        }

        public int Update(Product product)
        {
            return productDAO.Update(product);
        }

        public int Insert(Product product)
        {
            //Kiem tra nghiep vu
            if (!product.Code.StartsWith("PRO")) return -1;
            if (product.Quantity>10000) return -2;

            return productDAO.Insert(product);
        }

        public int UpdateByStore(Product product)
        {
            return productDAO.UpdateByStore(product);
        }

    }
}
