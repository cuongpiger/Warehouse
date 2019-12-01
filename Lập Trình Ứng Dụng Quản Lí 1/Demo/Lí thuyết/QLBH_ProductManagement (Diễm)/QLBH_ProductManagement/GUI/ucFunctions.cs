using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH_ProductManagement.DTO;

namespace QLBH_ProductManagement.GUI
{
    public partial class ucFunctions : UserControl
    {
        public ucFunctions()
        {
            InitializeComponent();
        }

        private void ucFunctions_Load(object sender, EventArgs e)
        {

        }

        public void VisibleFunctions(RoleForm roleForm)
        {
            btnLoadData.Visible = roleForm.Access;
            btnInsert.Visible = roleForm.Insert;
            btnUpdate.Visible = roleForm.Update;
            btnDelete.Visible = roleForm.Delete;
            btnPrint.Visible = roleForm.Print;
            btnImport.Visible = roleForm.Import;
            btnExport.Visible = roleForm.Export;
        }
    }
}
