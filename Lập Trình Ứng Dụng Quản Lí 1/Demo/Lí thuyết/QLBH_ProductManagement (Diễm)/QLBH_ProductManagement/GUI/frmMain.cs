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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void productManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProductManagement frm = new frmProductManagement();
            frm.Show();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserManagement frmUserManagement = new frmUserManagement();
            frmUserManagement.Show();
        }

        private void factoryManagmementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFactoryManagement frm = new frmFactoryManagement();
            frm.Show();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.ShowDialog();
        }
    }
}
