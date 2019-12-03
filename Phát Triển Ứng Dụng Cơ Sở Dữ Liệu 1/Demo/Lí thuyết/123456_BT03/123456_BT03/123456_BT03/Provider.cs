using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Provider
    {
        static string ConnectionString = @"Data Source=PM2E-GV\MSSQLSERVER2014;Initial Catalog=QuanLySanPhamDB;Persist Security Info=True;User ID=sa;Password=ttth";
        SqlConnection Connection { get; set; }

        public void Connect()
        {
            try
            {
                if (Connection == null)
                    Connection = new SqlConnection(ConnectionString);
                if (Connection.State != ConnectionState.Closed)
                    Connection.Close();
                Connection.Open();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
                 
        }


        public void DisConnect()
        {
            if (Connection != null && Connection.State == ConnectionState.Open)
                Connection.Close();
        }

        public int ExeCuteNonQuery(CommandType cmtType, string strSQL, 
                            params SqlParameter []parameters)
        {
            try {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSQL;
                command.CommandType = cmtType;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);
                int nRow = command.ExecuteNonQuery();
                return nRow;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

        public DataTable Select(CommandType cmtType, string strSQL,
                            params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand command = Connection.CreateCommand();
                command.CommandText = strSQL;
                command.CommandType = cmtType;
                if (parameters != null && parameters.Length > 0)
                    command.Parameters.AddRange(parameters);

                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
