using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string path = "Data Source=LEANHTAI01-WIN7;Initial Catalog=BanHang;Integrated Security=True";

            SqlConnection conn = new SqlConnection(path);

            string userName = txtUserName.Text;
            string password = txtPassword.Text;
            string sql = string.Format("Select RoleId from Users Where UserName='{0}' and Password='{1}'", userName, password);
            //Mo ket noi
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand(sql, conn);
            var v = sqlCommand.ExecuteScalar();
            if (v != null)
            {
                int roleId = (int)v;
                MessageBox.Show("Login successfully!!!"); 
                if(roleId==1)
                {
                    frmUserManagement frm = new frmUserManagement();
                    frm.Show();
                }
            }
            else
            {
                MessageBox.Show("Failed!!!");
            }
            conn.Close();
        }
    }
}
