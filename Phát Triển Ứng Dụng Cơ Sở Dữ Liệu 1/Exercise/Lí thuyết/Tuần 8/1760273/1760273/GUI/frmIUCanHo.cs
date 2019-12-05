using _1760273.BUS;
using _1760273.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1760273.GUI
{
    public partial class frmIUCanHo : Form
    {
        public frmIUCanHo()
        {
            InitializeComponent();
        }

        static busCategoryApartment busCA = new busCategoryApartment();
        static busApartment busAprt = new busApartment();
        static DataTable dtCA = new DataTable();

        private void frmIUCanHo_Load(object sender, EventArgs e)
        {
            cbLoaiCanHo.DataSource = busCA.LoadCategoryApartment();
            cbLoaiCanHo.DisplayMember = "Name";
            cbLoaiCanHo.ValueMember = "ID";
            txbIdCanHo.ReadOnly = true;
            txbIdCanHo.Text = (int.Parse(busAprt.MaxIDApartment().ToString()) + 1).ToString();

            if (GlobalVar.ID != -1)
            {
                this.Text = "Sửa căn hộ";
                txbIdCanHo.Text = GlobalVar.ID.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            

            dtoApartment dtoAprt = new dtoApartment();

            dtoAprt.ID = GlobalVar.ID;
            dtoAprt.Acreage = float.Parse(txbDienTich.Text);
            dtoAprt.BlockID = int.Parse(txbKhoi.Text);
            dtoAprt.CategoryID = int.Parse(cbLoaiCanHo.SelectedValue.ToString());
            dtoAprt.FloorID = int.Parse(txbKhoi.Text);
            dtoAprt.HostID = int.Parse(txbChuNha.Text);

            if (GlobalVar.ID != -1)
            {
                if (busAprt.UpdateApartment(dtoAprt) == 1)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else
                {
                    MessageBox.Show("Sửa thất bại");
                }

                GlobalVar.ID = -1;

                this.Close();

                return;
            }

            if (busAprt.InsertApartment(dtoAprt) == 1)
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
