using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiSinhVien.DAO
{
    public class DB
    {
        static string connStr = "Data Source=DESKTOP-8U78UPU;Initial Catalog=QuanLiSinhVien;Integrated Security=True";
        public DataTable GetDatabase(string sql)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        public int ExcuteSqlCommand(string sql)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(sql, sqlConnection);
            
            sqlConnection.Open();
            int res = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return res;
        }
    }
}
