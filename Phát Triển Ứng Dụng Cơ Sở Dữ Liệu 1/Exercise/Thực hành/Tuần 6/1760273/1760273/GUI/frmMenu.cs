using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760273.GUI
{
    public partial class frmMenu : Form
    {
        static Form frm = null;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void btnFrmLop_Click(object sender, EventArgs e)
        {
            frm = new frmLop();
            frm.ShowDialog();
        }

        private void btnFrmSinhVien_Click(object sender, EventArgs e)
        {
            frm = new frmSinhVien();
            frm.ShowDialog();
        }

        private void btnThemSinhVien_Click(object sender, EventArgs e)
        {
            frm = new frmThemMotSinhVien();
            frm.ShowDialog();
        }
    }
}
