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
    public partial class frmOrderManagement : Form
    {
        public frmOrderManagement()
        {
            InitializeComponent();
        }

        private void frmOrderManagement_Load(object sender, EventArgs e)
        {
            LoadListOrigins();
            LoadListGoodsOrigin(cbMadeIn.SelectedValue.ToString());
            LoadDgvInvoice();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbInvoiceID_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListInvoicesGoodsID(cbInvoiceID.SelectedValue.ToString());
            dgvInvoices.DataSource = dtInvoices;
            CalcTotalInvoice(cbInvoiceID.SelectedValue.ToString());
        }

        private void cbMadeIn_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadListGoodsOrigin(cbMadeIn.SelectedValue.ToString());
        }

        private void dgvInvoices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            curInvoiceID = dgvInvoices.Rows[dgvInvoices.CurrentCell.RowIndex].Cells[0].Value.ToString();
            LoadListInvoicesDetailsByInvoiceID(curInvoiceID);
            dgvInvoiceDetail.DataSource = dtInvoicesDetails;
            LoadDgvInvoiceDetail();
        }

        private void dgvInvoices_MouseUp(object sender, MouseEventArgs e)
        {
            dgvInvoices.CurrentCell = null;
        }
    }
}
