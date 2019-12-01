using Northwind.DAO;
using Northwind.DTB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Northwind
{
    public partial class Form1 : Form
    {
        static Database database = new Database();
        static Dictionary<string, int> categoryID = new Dictionary<string, int>();
        static DAO_Product daoProduct = new DAO_Product();
        static SqlDataAdapter sqlDataAdapter = null;
        static DataSet dataSet = null;
        static int scr_val = 0;
        static int noPages = 0;
        static int noRecords = 0;
        static int pageTh = 0;
        static string connStr = "Data Source=DESKTOP-714MBD8\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            LoadCategoriesName();
        }

        private void LoadCategoriesName()
        {
            DataTable dataTable = database.DTB_GetDatabase("GetCategoriesName", null);
            cmbCatagory.DataSource = dataTable;
            cmbCatagory.DisplayMember = "CategoryName";
            cmbCatagory.ValueMember = "CategoryName";
            categoryID = dataTable.AsEnumerable().ToDictionary<DataRow, string, int>(row => row[0].ToString(), row => int.Parse(row[1].ToString()));
            cmbCatagory.SelectedIndex = 0;
            LoadProducts(categoryID[cmbCatagory.SelectedValue.ToString()]);
        }

        private void LoadProducts(int categoryID)
        {
            string sql = string.Format("select * from Products where CategoryID = '{0}'", categoryID);
            SqlConnection sqlConnection = new SqlConnection(connStr);

            sqlDataAdapter = new SqlDataAdapter(sql, connStr);
            dataSet = new DataSet();

            sqlConnection.Open();
            noRecords = sqlDataAdapter.Fill(dataSet, "Products");
            dataSet.Clear();
            sqlDataAdapter.Fill(dataSet, scr_val, 5, "Products");
            sqlConnection.Close();

            dgvProducts.DataSource = dataSet;
            dgvProducts.DataMember = "Products";

            noPages = (noRecords / 5) + (noRecords % 5 != 0 ? 1 : 0);
            pageTh = 0;

            if (noPages != 0)
            {
                lblPerTotal.Text = string.Format("1/{0}", noPages);
            }
            else
            {
                lblPerTotal.Text = string.Format("0/{0}", noPages);
            }
        }

        private void cmbCatagory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = categoryID[cmbCatagory.SelectedValue.ToString()];
            LoadProducts(id);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            scr_val = scr_val - 5;
            pageTh -= 1;

            if (scr_val <= 0)
            {
                scr_val = 0;
                pageTh = 0;
            }

            lblPerTotal.Text = string.Format("{0}/{1}", pageTh + 1, noPages);
            dataSet.Clear();
            sqlDataAdapter.Fill(dataSet, scr_val, 5, "Products");
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            scr_val = scr_val + 5;
            pageTh += 1;

            if (scr_val > noRecords)
            {
                scr_val = noRecords - (noRecords % 5);
            }

            if (pageTh >= noPages)
            {
                pageTh = noPages - 1;
            }

            dataSet.Clear();
            sqlDataAdapter.Fill(dataSet, scr_val, 5, "Products");
            lblPerTotal.Text = string.Format("{0}/{1}", pageTh + 1, noPages);
            //MessageBox.Show()
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txbName.Text = dgvProducts.CurrentRow.Cells["ProductName"].Value.ToString();
            txbStocks.Text = dgvProducts.CurrentRow.Cells["UnitsInStock"].Value.ToString();
            txbPrice.Text = dgvProducts.CurrentRow.Cells["UnitPrice"].Value.ToString();
            txbUnits.Text = dgvProducts.CurrentRow.Cells["UnitsOnOrder"].Value.ToString();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            scr_val = 0;
            pageTh = 0;

            lblPerTotal.Text = string.Format("{0}/{1}", pageTh + 1, noPages);
            dataSet.Clear();
            sqlDataAdapter.Fill(dataSet, scr_val, 5, "Products");
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            scr_val = noRecords - (noRecords % 5);
            pageTh = noPages - 1;

            lblPerTotal.Text = string.Format("{0}/{1}", pageTh + 1, noPages);
            dataSet.Clear();
            sqlDataAdapter.Fill(dataSet, scr_val, 5, "Products");
        }
    }
}
