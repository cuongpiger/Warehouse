using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DB_Connect
    {
        protected SqlConnection Connection = new SqlConnection("Data Source=DESKTOP-8U78UPU;Initial Catalog=QLSV;Integrated Security=True");

        public void OpenConnection()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
        }

        public void CloseConnection()
        {
            if (Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
        }
    }
}
