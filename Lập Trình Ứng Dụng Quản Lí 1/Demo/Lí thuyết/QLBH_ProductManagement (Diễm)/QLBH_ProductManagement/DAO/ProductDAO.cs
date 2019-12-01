using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBH_ProductManagement.DAO
{
    public class ProductDAO
    {
        public db db = new db();
        public DataTable GetAllData()
        {
            string sql = "Select * from Product";
            var rs = db.GetData(sql);

            return rs;
        }

        public int DeleteById(int productId)
        {
            string sql = string.Format("Delete from Product Where Id = {0}", productId);
            var rs = db.ExecuteSQL(sql);

            return rs;
        }

        public int Update(Product product)
        {
            string sql =
 string.Format("Update Product Set Code='{0}', Name='{1}', Description='{2}', Quantity={3}, Price = {4}, SupplierId={5} Where Id = {6}"
 , product.Code, product.Name, product.Description, product.Quantity, product.Price, product.SupplierId, product.Id);
            var rs = db.ExecuteSQL(sql);

            return rs;
        }

        public int Insert(Product product)
        {
            string sql =
 string.Format("Insert Into Product(Code, Name, Description, Quantity, Price, SupplierId) Values('{0}', '{1}', '{2}', {3}, {4}, {5})"
 , product.Code, product.Name, product.Description, product.Quantity, product.Price, product.SupplierId);
            var rs = db.ExecuteSQL(sql);

            return rs;
        }

        public int UpdateByStore(Product product)
        {
            string sql = "spProduct_Update";

            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@Id", product.Id));
            lstParams.Add(new SqlParameter("@Name", product.Name));
            lstParams.Add(new SqlParameter("@Description", product.Description));

            var rs = db.ExecuteStore(sql, lstParams.ToArray());

            return rs;
        }

        public List<Product> GetAllDataByList()
        {
            List<Product> rs = new List<Product>();

            var table = db.GetData("Select * from Product");
            foreach (DataRow row in table.Rows)
            {
                rs.Add(ConvertRowToProduct(row));
            }
           

            return rs;
        }

        private Product ConvertRowToProduct(DataRow row)
        {
            Product rs = new Product();

            rs.Id = int.Parse(row["Id"].ToString());
            rs.Name = row["Name"].ToString();


            return rs;
            
        }
    }
}
