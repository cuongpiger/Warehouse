using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Northwind.DTB
{
    public class Database
    {
        /// <summary>
        ///     Thủ tục kết nối đến server
        /// </summary>
        protected string connStr = "Data Source=DESKTOP-714MBD8\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";

        public DataTable DTB_GetDatabase(string pSql, List<SqlParameter> pParam)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(pSql, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            sqlCommand.CommandType = CommandType.StoredProcedure;

            if (pParam != null)
            {
                sqlCommand.Parameters.AddRange(pParam.ToArray());
            }
            
            sqlDataAdapter.Fill(dataTable);

            return dataTable;
        }

        /// <summary>
        ///     Thực thi câu truy vấn sql
        /// </summary>
        /// <param name="pSql"></param>
        /// <returns></returns>
        public int DTB_ExcuteSqlCommand(string pSql)
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand(pSql, sqlConnection);

            sqlConnection.Open();
            int res = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return res;
        }
        
        //public int DTB_ExcuteStoreScalar(string pSql, SqlParameter[] pParam)
        //{
        //    SqlConnection sqlConnection = new SqlConnection(connStr);
        //    SqlCommand sqlCommand = new SqlCommand(pSql, sqlConnection);

        //    sqlCommand.CommandType = CommandType.StoredProcedure;
        //    sqlCommand.Parameters.AddRange(pParam);

        //    sqlConnection.Open();
        //    var affectedRows = sqlCommand.ex();
        //    sqlConnection.Close();

        //    return affectedRows;
        //}
    }
}
