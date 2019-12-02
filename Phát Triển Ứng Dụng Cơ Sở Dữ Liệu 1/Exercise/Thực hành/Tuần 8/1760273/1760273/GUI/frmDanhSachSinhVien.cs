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
        static string curMaSV = "";
        public frmDanhSachSinhVien()
        {
            InitializeComponent();
        }

        private void frmDanhSachSinhVien_Load(object sender, EventArgs e)
        {
            InitLsvClass();
            InitDgvDanhSach();
            InitDgvDkhp();
            LoadLstStudentWithClassID(lsvLop.Items[0].SubItems[0].Text.ToString());
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

        private void lsvLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvLop.SelectedItems.Count == 0)
                return;
            
            LoadLstStudentWithClassID(lsvLop.SelectedItems[0].SubItems[0].Text.ToString());
            AddLstStudentsIntoDgvDanhSach();
        }

        private void dgvDanhSach_SelectionChanged(object sender, EventArgs e)
        {
            curMaSV = dgvDanhSach.Rows[dgvDanhSach.CurrentCell.RowIndex].Cells["MaSV"].Value.ToString();
            LoadLstDkhpsWithStudentID(curMaSV);
            AddLstDkhpsIntoDgvDkhp();
        }
    }
}
