using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760273
{
    public partial class frmThemMotSinhVien : Form
    {
        public frmThemMotSinhVien()
        {
            InitializeComponent();
        }

        private void frmThemMotSinhVien_Load(object sender, EventArgs e)
        {
            InitialCbPhai();
            InitialCbClass();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ButtonThemClick();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
