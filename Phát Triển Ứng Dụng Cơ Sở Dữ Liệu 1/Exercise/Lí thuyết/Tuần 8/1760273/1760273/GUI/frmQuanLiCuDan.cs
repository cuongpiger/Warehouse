using _1760273.GUI;
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
    public partial class frmMain : Form
    {
        

        public frmMain()
        {
            InitializeComponent();
            this.tbMain.TabPages.RemoveAt(1);


        }

        private void btnThoatCanHo_Click(object sender, EventArgs e)
        {
            this.tbMain.TabPages.Remove(this.tbCanHo);
            smiCanHo.Enabled = true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            tbMain.TabPages.Remove(this.tbCanHo);
            InitTabpageApartment();

        }

        private void smiCanHo_Click(object sender, EventArgs e)
        {
            //this.tabControl1.TabPages.RemoveAt(0);
            //tabControl1.SelectTab(this.tabPage2);
            //tabControl1.TabPages.Add(tabPage2);
            smiCanHo.Enabled = false;
            this.tbMain.TabPages.Add(this.tbCanHo);
            LoadApartment();
            dgvApartment.DataSource = dtAprt;
        }

        private void smiCuDan_Click(object sender, EventArgs e)
        {

        }

        private void btnThemCanHo_Click(object sender, EventArgs e)
        {
            Form frm = new frmIUCanHo();
            frm.Show();
        }

        private void dgvApartment_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.Message == "DataGridViewComboBoxCell value is not valid.")
            {
                object value = dgvApartment.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgvApartment.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dgvApartment.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            }
        }

        private void btnXoaCanHo_Click(object sender, EventArgs e)
        {
            string index = dgvApartment.CurrentRow.Cells["ID"].Value.ToString();
            
            if (busApt.DeleteApartment(int.Parse(index)) == 1)
            {
                MessageBox.Show("xóa thànhh công");
                LoadApartment();
                dgvApartment.DataSource = dtAprt;
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadApartment();
            dgvApartment.DataSource = dtAprt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GlobalVar.ID = -1;
            try
            {
                GlobalVar.ID = int.Parse(dgvApartment.CurrentRow.Cells["ID"].Value.ToString());
            }
            catch
            {
                GlobalVar.ID = -1;
                return;
            }

            Form frm = new frmIUCanHo();
            frm.Show();
        }
    }
}
