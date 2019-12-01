using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLBH
{
    public partial class frmUserManagement : Form
    {
        public frmUserManagement()
        {
            InitializeComponent();
        }

        private void BtnLoadData_Click(object sender, EventArgs e)
        {
            string path = "Data Source=LEANHTAI01-WIN7;Initial Catalog=BanHang;Integrated Security=True";

            SqlConnection conn = new SqlConnection(path);

            string sql = "Select * from Users";
            //Mo ket noi
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            var cursor = sqlCommand.ExecuteReader();


            List<dynamic> lst = new List<dynamic>();
            while(cursor.Read())
            {
                lst.Add(new {
                    UserName = cursor["UserName"].ToString(),
                    Phone = cursor["Phone"].ToString()
                }); 
            }

            grvData.DataSource = lst;
            //Dong ket noi
            conn.Close();
        }

        private void BtnExcuteScalar_Click(object sender, EventArgs e)
        {
            string path = "Data Source=LEANHTAI01-WIN7;Initial Catalog=BanHang;Integrated Security=True";

            SqlConnection conn = new SqlConnection(path);

            string sql = "Select count(*) from Users";
            //Mo ket noi
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            //Lay gia tri don
            var rs = (int)sqlCommand.ExecuteScalar();

            MessageBox.Show("Total users:" + rs.ToString());

            conn.Close();
        }

        private void BtnInsertUser_Click(object sender, EventArgs e)
        {
            string path = "Data Source=LEANHTAI01-WIN7;Initial Catalog=BanHang;Integrated Security=True";

            SqlConnection conn = new SqlConnection(path);

            string sql = string.Format(
                "Insert Into Users(UserName, Password) Values('{0}', '{1}')", "MrWhite", "12");
            //Mo ket noi
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            //Lay gia tri don
            var rs = sqlCommand.ExecuteNonQuery();

            if(rs>0)
                MessageBox.Show("Insert user successfully");

            conn.Close();
        }
    }
}

