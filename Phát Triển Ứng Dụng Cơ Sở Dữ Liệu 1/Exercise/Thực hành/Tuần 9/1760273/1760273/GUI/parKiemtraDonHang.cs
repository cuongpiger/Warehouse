using _1760273.BUS;
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
        static BusGoods busGoods = new BusGoods();
        static BusInvoice busInvoice = new BusInvoice();
        static DataTable dtInvoices = new DataTable();
        static DataTable dtInvoicesDetails = new DataTable();
        static string curInvoiceID = "";

        private void LoadListOrigins()
        {
            cbMadeIn.DataSource = busGoods.LoadListOrigins();
            cbMadeIn.DisplayMember = "xuatxu";
            cbMadeIn.ValueMember = "xuatxu";
        }

        private void LoadListGoodsOrigin(string origin)
        {
            cbInvoiceID.DataSource = busGoods.LoadListGoodsOrigin(origin);
            cbInvoiceID.DisplayMember = "tenhh";
            cbInvoiceID.ValueMember = "mahh";
        }

        private void LoadListInvoicesGoodsID(string goodsID)
        {
            dtInvoices = busInvoice.LoadListInvoicesGoodsID(goodsID);
        }

        private void CalcTotalInvoice(string goodsID)
        {
            txbTotalInvoice.Text = string.Format("{0:0,0} VND", busInvoice.CalcTotalInvoice(goodsID));
        }

        private void LoadDgvInvoice()
        {
            dgvInvoices.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInvoices.AllowUserToAddRows = false;
            dgvInvoices.ReadOnly = true;

            dgvInvoices.Columns[0].HeaderText = "Mã HĐ";
            dgvInvoices.Columns[1].HeaderText = "Tên khách hàng";
            dgvInvoices.Columns[2].HeaderText = "Địa chỉ";
            dgvInvoices.Columns[3].HeaderText = "SĐT";
            dgvInvoices.Columns[4].HeaderText = "Tổng tiền";
            dgvInvoices.Columns[5].HeaderText = "Ngày";

            dgvInvoices.Columns[0].Width = 100;
            dgvInvoices.Columns[1].Width = 200;
            dgvInvoices.Columns[2].Width = 300;
            dgvInvoices.Columns[3].Width = 150;
            dgvInvoices.Columns[4].Width = 150;
            dgvInvoices.Columns[5].Width = 100;
        }

        private void LoadDgvInvoiceDetail()
        {
            dgvInvoiceDetail.AllowUserToAddRows = false;
            dgvInvoiceDetail.ReadOnly = true;

            dgvInvoiceDetail.Columns[0].HeaderText = "Mã HĐ";
            dgvInvoiceDetail.Columns[1].HeaderText = "Mã hàng hóa";
            dgvInvoiceDetail.Columns[2].HeaderText = "Tên hàng hóa";
            dgvInvoiceDetail.Columns[3].HeaderText = "Đơn vị tính";
            dgvInvoiceDetail.Columns[4].HeaderText = "Xuất xứ";
            dgvInvoiceDetail.Columns[5].HeaderText = "Số lượng";
            dgvInvoiceDetail.Columns[6].HeaderText = "Đơn giá";

            dgvInvoiceDetail.Columns[0].Width = 100;
            dgvInvoiceDetail.Columns[1].Width = 200;
            dgvInvoiceDetail.Columns[2].Width = 300;
            dgvInvoiceDetail.Columns[3].Width = 130;
            dgvInvoiceDetail.Columns[4].Width = 100;
            dgvInvoiceDetail.Columns[5].Width = 80;
            dgvInvoiceDetail.Columns[6].Width = 80;
        }

        private void LoadListInvoicesDetailsByInvoiceID(string invoiceID)
        {
            dtInvoicesDetails = busInvoice.LoadListInvoicesDetailsByInvoiceID(invoiceID);
        }
    }
}
