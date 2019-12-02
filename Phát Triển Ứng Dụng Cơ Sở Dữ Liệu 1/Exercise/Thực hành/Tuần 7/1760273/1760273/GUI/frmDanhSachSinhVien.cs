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
    public partial class frmDanhSachSinhVien : Form
    {
        public frmDanhSachSinhVien()
        {
            InitializeComponent();
        }

        private void frmDanhSachSinhVien_Load(object sender, EventArgs e)
        {
            InitCbClass();
            InitDgvDanhSach();
            LoadLstStudentWithClassID();
            AddLstStudentsIntoDgvDanhSach();
        }

        private void dgvDanhSach_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dgvDanhSach.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgvDanhSach.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dgvDanhSach.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadLstStudentWithClassID();
            AddLstStudentsIntoDgvDanhSach();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ButtonThemClick();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ButtonXoaClick();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            ButtonCapNhatClick();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
