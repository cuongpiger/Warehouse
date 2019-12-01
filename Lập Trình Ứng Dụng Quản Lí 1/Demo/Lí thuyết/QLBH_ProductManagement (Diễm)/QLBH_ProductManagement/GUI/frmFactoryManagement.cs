using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBH_ProductManagement.GUI
{
    public partial class frmFactoryManagement : Form
    {
        public frmFactoryManagement()
        {
            InitializeComponent();
        }

        private void frmFactoryManagement_Load(object sender, EventArgs e)
        {
            int formId = int.Parse(this.Tag.ToString());
            var roleForm = GlobalVar.dictRoleForm[formId];
            ucFunctions1.VisibleFunctions(roleForm);

        }
    }
}
