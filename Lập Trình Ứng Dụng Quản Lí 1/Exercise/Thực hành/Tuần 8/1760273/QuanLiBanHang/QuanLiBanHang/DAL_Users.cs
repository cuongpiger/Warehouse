using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLiBanHang
{
    public class DAL_Users
    {
        protected SqlConnection sqlConnection = new SqlConnection("Data Source=LAPTOP-LN7FVV9Q\\SQLEXPRESS;Initial Catalog=QLBH;Integrated Security=True");

        public void OpenConnection()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public int CheckIdentityUsername(string iUsername)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand("select QLBH.dbo.CheckIdentityUsername(@i_username)", sqlConnection);
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.Parameters.AddWithValue("@i_username", iUsername);

            int res = int.Parse(sqlCommand.ExecuteScalar().ToString());
            CloseConnection();

            return res;
        }

        public int InsertNewUser(string iUsername, string iPassword, string iName, string iEmail, string iDOB)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand("QLBH.dbo.InsertNewUser", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@iUsername", iUsername);
            sqlCommand.Parameters.AddWithValue("@iPassword", iPassword);
            sqlCommand.Parameters.AddWithValue("@iName", iName);
            sqlCommand.Parameters.AddWithValue("@iEmail", iEmail);
            sqlCommand.Parameters.AddWithValue("@iDOB", iDOB);
            sqlCommand.Parameters.AddWithValue("@iPermission", 0);
            sqlCommand.Parameters.Add("@result", SqlDbType.Int);
            sqlCommand.Parameters["@result"].Direction = ParameterDirection.Output;
            
            sqlCommand.ExecuteNonQuery();
            return int.Parse(sqlCommand.Parameters["@result"].Value.ToString());
        }
    }
}
