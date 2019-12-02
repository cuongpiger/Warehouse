using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1760273.DAO
{
    public class DaoDB
    {
        //SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-LN7FVV9Q\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True");
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-714MBD8\SQLEXPRESS;Initial Catalog=QLSV;Integrated Security=True");

        public void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public DataTable GetData(string sql)
        {
            var datatable = new DataTable();
            var cmd = new SqlCommand(sql, sqlConnection);
            var adp = new SqlDataAdapter(cmd);

            cmd.CommandType = CommandType.StoredProcedure;
            adp.Fill(datatable);

            return datatable;
        }

        public DataTable GetDataWithParameters(string sql, SqlParameter[] sqlParameters)
        {
            var datatable = new DataTable();
            var cmd = new SqlCommand(sql, sqlConnection);
            var adp = new SqlDataAdapter(cmd);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange((sqlParameters));
            adp.Fill(datatable);

            return datatable;
        }

        public int ExecuteStoredProcedure(string sql, SqlParameter[] sqlParameters)
        {
            int affRows = 0;
            SqlCommand cmd = new SqlCommand(sql, sqlConnection);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(sqlParameters);
            
            try
            {
                OpenConnection();
                affRows = cmd.ExecuteNonQuery();
                CloseConnection();
            }
            catch
            {
                affRows = 0;
            }

            return affRows;
        }
    }
}
