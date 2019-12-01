using QLBH_ProductManagement.BUS;
using QLBH_ProductManagement.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_ProductManagement
{
    public partial class frmProductManagement : Form
    {
        public frmProductManagement()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            RefreshData();

        }

        SqlDataAdapter sqlDataAdapter;
        ProductBUS productBUS = new ProductBUS();
        private void RefreshData()
        {
            var dataTable = productBUS.GetAllData();

            grvData.DataSource = dataTable;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = int.Parse(grvData.CurrentRow.Cells["Id"].Value.ToString());

            var rs = productBUS.DeleteById(id);

            if (rs > 0)
            {
                grvData.Rows.Remove(grvData.CurrentRow);
                MessageBox.Show("Delete Successfully!!!!!!!!");
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = int.Parse(grvData.CurrentRow.Cells["Id"].Value.ToString()),
                Quantity = int.Parse(grvData.CurrentRow.Cells["Quantity"].Value.ToString()),
                Price = float.Parse(grvData.CurrentRow.Cells["Price"].Value.ToString()),
                Code = grvData.CurrentRow.Cells["Code"].Value.ToString(),
                Name = grvData.CurrentRow.Cells["Name"].Value.ToString(),
                Description = grvData.CurrentRow.Cells["Description"].Value.ToString(),
                Image = grvData.CurrentRow.Cells["Image"].Value.ToString(),
            };

            frmInsertOrUpdateProduct frm = 
                new frmInsertOrUpdateProduct(product);
            frm.WhenInsertDone += Frm_WhenInsertDone;

            frm.ShowDialog();
        }

        private void Frm_WhenInsertDone()
        {
            RefreshData();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsertOrUpdateProduct frm = new frmInsertOrUpdateProduct();
            frm.WhenInsertDone += Frm_WhenInsertDone1;
            frm.ShowDialog();
        }

        private void Frm_WhenInsertDone1()
        {
            RefreshData();
        }

        private void btnUpdateWithStoreProc_Click(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Id = 1,
                Name = "Don't beleive",
                Description = "Nothing is impossible"
            };

            productBUS.UpdateByStore(product);
        }

        private void btnUpdateGrid_Click(object sender, EventArgs e)
        {
            ////C1 => Duyet tung dong trong luoi
            //foreach(var row in grvData.Rows)
            //{
            //    //Lay gia tri tung o
            //    //Goi thuc thi cau sql
            //}

            ////C2 => Lay Datatable tu DataSource
            //DataTable dt = (DataTable)grvData.DataSource;
            //foreach(DataRow dr in dt.Rows)
            //{
            //    int Id = int.Parse(dr["Id"].ToString());
            //    if(dr.RowState == DataRowState.Modified)
            //    {
            //        //Thuc thi cau sql o day
            //    }
            //    else if (dr.RowState == DataRowState.Added)
            //    {
            //        //Thuc thi cau sql o day
            //    }
            //    else if (dr.RowState == DataRowState.Deleted)
            //    {
            //        //Thuc thi cau sql o day
            //    }
            //}

            //C3 => Dung SqlCommandBuilder
            SqlCommandBuilder sqlCommandBuilder
                = new SqlCommandBuilder(sqlDataAdapter);
            DataTable dt1 = (DataTable)grvData.DataSource;
            sqlDataAdapter.Update(dt1);

        }

        private void frmProductManagement_Load(object sender, EventArgs e)
        {
            int formId = int.Parse(this.Tag.ToString());
            var roleForm = GlobalVar.dictRoleForm[formId];
            ucFunctions1.VisibleFunctions(roleForm);
           
        }
    }
}
