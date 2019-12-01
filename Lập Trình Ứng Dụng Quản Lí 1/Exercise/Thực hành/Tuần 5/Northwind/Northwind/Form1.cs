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
using System.Configuration;

namespace Northwind
{
    public partial class Form1 : Form
    {
        static string conString = ConfigurationManager.ConnectionStrings["Northwind.Properties.Settings.Setting"].ConnectionString;
        static SqlConnection sqlConnection = new SqlConnection(conString);
        static DataSet dataSet = new DataSet("Northwind");

        public Form1()
        {
            InitializeComponent();
            LoadData();
            BindingData();
            BindingContext[dataSet, "Categories.relCatPro"].PositionChanged += relCatPro_PositionChanged;
            FormatDisplayMidLabel();
            SwitchControlEvent();
        }

        private void relCatPro_PositionChanged(object sender, EventArgs e)
        {
            FormatDisplayMidLabel();
        }

        private void FormatDisplayMidLabel()
        {
            if (BM_relCatPro.Count == 0)
            {
                lblPerTotal.Text = "This category is empty!";
                SwitchControlEvent();

                return;
            }

            lblPerTotal.Text = string.Format($"{BM_relCatPro.Position + 1}/{BM_relCatPro.Count}");
            SwitchControlEvent();
        }

        BindingManagerBase BM_relCatPro
        {
            get { return BindingContext[dataSet, "Categories.relCatPro"]; }
        }

        private void SwitchControlEvent()
        {
            if (BM_relCatPro.Count == 0)
            {
                btnLastPage.Enabled = false;
                btnFirstPage.Enabled = false;
                btnNext.Enabled = false;
                btnPrevious.Enabled = false;
            }
            else if (BM_relCatPro.Position <= 0)
            {
                btnLastPage.Enabled = true;
                btnFirstPage.Enabled = false;
                btnNext.Enabled = true;
                btnPrevious.Enabled = false;
            }
            else if (BM_relCatPro.Position >= BM_relCatPro.Count - 1)
            {
                btnLastPage.Enabled = false;
                btnFirstPage.Enabled = true;
                btnNext.Enabled = false;
                btnPrevious.Enabled = true;
            }
            else
            {
                btnLastPage.Enabled = true;
                btnFirstPage.Enabled = true;
                btnNext.Enabled = true;
                btnPrevious.Enabled = true;
            }
        }

        private void LoadData()
        {
            var adapterC = new SqlDataAdapter(@"select * from Categories", sqlConnection);
            adapterC.TableMappings.Add("Table", "Categories");
            adapterC.Fill(dataSet);

            var adapterP = new SqlDataAdapter(@"select * from Products", sqlConnection);
            adapterP.TableMappings.Add("Table", "Products");
            adapterP.Fill(dataSet);

            var colMaster = dataSet.Tables["Categories"].Columns["CategoryID"];
            var colDetail = dataSet.Tables["Products"].Columns["CategoryID"];
            var relCatPro = new DataRelation("relCatPro", colMaster, colDetail);

            dataSet.Relations.Add(relCatPro);
        }

        private void BindingData()
        {
            cmbCatagory.DataSource = dataSet;
            cmbCatagory.DisplayMember = "Categories.CategoryName";
            cmbCatagory.ValueMember = "Categories.CategoryID";

            dgvProducts.DataSource = dataSet;
            dgvProducts.DataMember = "Categories.relCatPro";

            txbName.DataBindings.Add("Text", dataSet, "Categories.relCatPro.ProductName");
            txbPrice.DataBindings.Add("Text", dataSet, "Categories.relCatPro.UnitPrice");
            txbUnits.DataBindings.Add("Text", dataSet, "Categories.relCatPro.QuantityPerUnit");
            txbStocks.DataBindings.Add("Text", dataSet, "Categories.relCatPro.UnitsInStock");
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            BM_relCatPro.Position--;
            SwitchControlEvent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            BM_relCatPro.Position++;
            SwitchControlEvent();
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            BM_relCatPro.Position = 0;
            SwitchControlEvent();
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            BM_relCatPro.Position = BM_relCatPro.Count;
            SwitchControlEvent();
        }

        private void dgvProducts_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            FormatDisplayMidLabel();
            SwitchControlEvent();
        }
    }
}
