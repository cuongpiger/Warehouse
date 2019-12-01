using QLBH_ProductManagement.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_ProductManagement.GUI
{
    public partial class frmLogin : Form
    {
        UserBUS userBUS = new UserBUS();
        RoleFormBUS roleFormBUS = new RoleFormBUS();  
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string password = txtPassword.Text;

            var rs = userBUS.Login(userName, password);
            //Login successfully
            if (rs !=null)
            {
                var lst = roleFormBUS.GetList(rs.RoleId);
                foreach(var roleForm in lst)
                {
                    GlobalVar.dictRoleForm
                        .Add(roleForm.FormId, roleForm);
                }

                this.Close();
            }
        }
    }
}
