using QuanLiSinhVien.DAO;
using QuanLiSinhVien.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiSinhVien
{
    public partial class frmForm1 : Form
    {
        static SinhVien_DAO sinhVien_DAO = new SinhVien_DAO();

        public frmForm1()
        {
            InitializeComponent();
            LoadData();
            ChangeColumnNameDGV();
            ImportCitiesToComboBox();

            txbNgaySinh.Text = "yyyy/MM/dd";
            txbNgaySinh.ForeColor = Color.Gray;
        }

        private void LoadData()
        {
            var dataTable = sinhVien_DAO.GetAllData();
            dgvDSSV.DataSource = dataTable;
        }

        public void ChangeColumnNameDGV()
        {
            dgvDSSV.Columns[1].HeaderText = "Họ tên";
            dgvDSSV.Columns[2].HeaderText = "Ngày sinh";
            dgvDSSV.Columns[3].HeaderText = "Quê quán";
            dgvDSSV.Columns[4].HeaderText = "Giới tính";
            dgvDSSV.Columns[2].DefaultCellStyle.Format = "yyyy'/'MM'/'dd";
        }

        public void ImportCitiesToComboBox()
        {
            string[] cities = {"Hà Nội", "Hồ Chí Minh", "Đắk Lắk", "Hà Tĩnh", "Điện Biên", "Nghệ An", "Tiền Giang", "Hải Phòng",
            "An Giang", "Bà Rịa - Vũng Tàu","Bắc Giang", "Bắc Kạn","Bạc Liêu", "Bắc Ninh", "Bến Tre", "Bình Định", "Bình Dương", "Bình Phước", "Bình Thuận",
            "Cà Mau", "Cao Bằng", "Đắk Nông", "Đồng Nai","Đồng Tháp","Gia Lai", "Hà Giang", "Hà Nam","Hải Dương","Hậu Giang","Hòa Bình", "Hưng Yên","Khánh Hòa",
            "Kiên Giang","Kon Tum", "Lai Châu", "Lâm Đồng", "Lạng Sơn","Lào Cai", "Long An","Nam Định","Ninh Bình","Ninh Thuận", "Phú Thọ","Quảng Bình","Quảng Nam",
            "Quảng Ngãi","Quảng Ninh", "Quảng Trị","Sóc Trăng", "Sơn La","Tây Ninh", "Thái Bình", "Thái Nguyên", "Thanh Hóa", "Thừa Thiên Huế", "Trà Vinh",
            "Tuyên Quang", "Vĩnh Long","Vĩnh Phúc", "Yên Bái","Phú Yên","Cần Thơ","Đà Nẵng",};
            cmbQueQuan.Items.AddRange(cities);
            cmbQueQuan.SelectedIndex = 1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string mssv = "";
            int res = 0;

            try
            {
                mssv = dgvDSSV.CurrentRow.Cells["MSSV"].Value.ToString();
                res = sinhVien_DAO.DeleteSinhVienByMSSV(mssv);
            }
            catch
            {
                res = 0;
            }

            if (res > 0)
            {
                dgvDSSV.Rows.Remove(dgvDSSV.CurrentRow);
                MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormatLayoutForm1();
            }
            else
            {
                MessageBox.Show("Xóa không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            int res = 0;
            try
            {
                string mssv = txbMSSV.Text;
                string hoTen = txbHoTen.Text;
                DateTime ngSinh = DateTime.ParseExact(txbNgaySinh.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                string queQuan = cmbQueQuan.SelectedItem.ToString();
                string giTinh = (rdbGiTinhNam.Checked == true ? "Nam" : "Nữ");

                SinhVien sv = new SinhVien(mssv, hoTen, ngSinh, queQuan, giTinh);
                res = sinhVien_DAO.UpdateSinhVien(sv);
            }
            catch
            {
                res = 0;
            }

            if (res > 0)
            {
                LoadData();
                MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormatLayoutForm1();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int res = 0;
            try
            {
                string mssv = txbMSSV.Text;
                string hoTen = txbHoTen.Text;
                DateTime ngSinh = DateTime.ParseExact(txbNgaySinh.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
                string queQuan = cmbQueQuan.SelectedItem.ToString();
                string giTinh = (rdbGiTinhNam.Checked == true ? "Nam" : "Nữ");

                SinhVien sv = new SinhVien(mssv, hoTen, ngSinh, queQuan, giTinh);
                res = sinhVien_DAO.AddSinhVien(sv);
            }
            catch
            {
                res = 0;
            }

            if (res > 0)
            {
                LoadData();
                MessageBox.Show("Thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormatLayoutForm1();
            }
            else
            {
                MessageBox.Show("Thêm thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txbNgaySinh_Enter(object sender, EventArgs e)
        {
            if (txbNgaySinh.Text == "yyyy/MM/dd")
            {
                txbNgaySinh.Text = "";
                txbNgaySinh.ForeColor = Color.Black;
            }
        }

        private void txbNgaySinh_Leave(object sender, EventArgs e)
        {
            if (txbNgaySinh.Text == "")
            {
                txbNgaySinh.Text = "yyyy/MM/dd";
                txbNgaySinh.ForeColor = Color.Gray;
            }
        }

        public void FormatLayoutForm1()
        {
            txbMSSV.Text = "";
            txbHoTen.Text = "";
            txbNgaySinh.Text = "yyyy/MM/dd";
            txbNgaySinh.ForeColor = Color.Gray;
            rdbGiTinhNam.Checked = true;
            cmbQueQuan.SelectedIndex = 1;
        }
    }
}
