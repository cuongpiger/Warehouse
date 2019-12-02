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

namespace _1760273
{
    public partial class frmDanhSachSinhVien : Form
    {
        static BusClass busClass = new BusClass();
        static BusStudent busStudent = new BusStudent();
        static BusDkhp busDkhp = new BusDkhp();
        static DataTable dtStudents = new DataTable();
        static DataTable dtDkhps = new DataTable();

        private void ButtonThemClick()
        {
            dgvDkhp.Rows.Add(true, "", "", curMaSV, "", "", "", "");
        }

        private void ButtonXoaClick()
        {
            foreach (DataGridViewRow r in dgvDkhp.Rows)
            {
                if ((bool)r.Cells["chon"].Value == true)
                {
                    if (busDkhp.DeleteOneDkhp(r.Cells["nh"].Value.ToString(), r.Cells["hk"].Value.ToString(),
                        r.Cells["masv"].Value.ToString(), r.Cells["mamh"].Value.ToString()) != 1)
                    {
                        MessageBox.Show(string.Format("Xóa không thành công"));
                    }
                }
            }

            LoadLstDkhpsWithStudentID(curMaSV);
            AddLstStudentsIntoDgvDanhSach();
        }

        private void ButtonCapNhatClick()
        {
            foreach (DataGridViewRow r in dgvDanhSach.Rows)
            {
                if ((bool)r.Cells["chon"].Value == true && (string)r.Cells["an"].Value == "them")
                {
                    DtoDkhp newDk = CreateDkhpObject(r);
                    if (busDkhp.InsertOneDkhp(newDk) == 1)
                        MessageBox.Show("Thêm thành công!");
                }
                else if ((bool)r.Cells["chon"].Value == true)
                {
                    DtoDkhp updateDk = CreateDkhpObject(r);
                    if (busDkhp.UpdateOneDkhp(updateDk) == 1)
                        MessageBox.Show("Cập nhật thành công!");
                }
            }

            LoadLstDkhpsWithStudentID(curMaSV);
            AddLstStudentsIntoDgvDanhSach();
        }

        private DtoDkhp CreateDkhpObject(DataGridViewRow r)
        {
            DtoDkhp dk = new DtoDkhp();

            dk.DiaDiem = r.Cells["diadiem"].Value.ToString();
            dk.Diem = (r.Cells["diem"].Value is null || r.Cells["diem"].Value.ToString() == "") ? -1 : float.Parse(r.Cells["diem"].Value.ToString());
            dk.HK = r.Cells["hk"].Value.ToString();
            dk.MaMH = r.Cells["mamh"].Value.ToString();
            dk.MaSV = r.Cells["masv"].Value.ToString();
            dk.NH = r.Cells["nh"].Value.ToString();
            dk.SoTC = (r.Cells["sotc"].Value is null || r.Cells["sotc"].Value.ToString() == "") ? 0 : int.Parse(r.Cells["sotc"].Value.ToString());

            return dk;
        }

        private void LoadLstStudentWithClassID(string classID)
        {
            dtStudents = busStudent.LoadListStudentsWithClassID(classID);
        }

        private void LoadLstDkhpsWithStudentID(string maSV)
        {
            dtDkhps = busDkhp.LoadListDkhpsWithMaSV(maSV);
        }

        private void AddLstStudentsIntoDgvDanhSach()
        {
            dgvDanhSach.Rows.Clear();

            for (int i = 0; i < dtStudents.Rows.Count; ++i)
            {
                dgvDanhSach.Rows.Add(
                    dtStudents.Rows[i]["MaSV"].ToString(),
                    dtStudents.Rows[i]["HoTen"].ToString(),
                    DateTime.Parse(dtStudents.Rows[i]["NgaySinh"].ToString()).ToString("dd-MM-yyyy"),
                    dtStudents.Rows[i]["Phai"].ToString(),
                    dtStudents.Rows[i]["Lop"].ToString(),
                    dtStudents.Rows[i]["DTB"].ToString());
            }
        }

        private void AddLstDkhpsIntoDgvDkhp()
        {
            dgvDkhp.Rows.Clear();

            for (int i = 0; i < dtDkhps.Rows.Count; ++i)
            {
                dgvDkhp.Rows.Add(false,
                    dtDkhps.Rows[i]["NH"].ToString(),
                    dtDkhps.Rows[i]["HK"].ToString(),
                    dtDkhps.Rows[i]["MaSV"].ToString(),
                    dtDkhps.Rows[i]["MaMH"].ToString(),
                    dtDkhps.Rows[i]["SoTC"].ToString(),
                    dtDkhps.Rows[i]["Diadiem"].ToString(),
                    dtDkhps.Rows[i]["Diem"].ToString());
            }
        }

        private void InitLsvClass()
        {
            lsvLop.FullRowSelect = true;
            lsvLop.View = View.Details;

            lsvLop.Columns.Add("Mã lớp", 100);
            lsvLop.Columns.Add("Khóa", 100);
            lsvLop.Columns.Add("Loại", 100);

            var dtClasses = busClass.LoadListClasses();
            for (int i = 0; i < dtClasses.Rows.Count; ++i)
            {
                ListViewItem lvi = new ListViewItem(dtClasses.Rows[i]["MaLop"].ToString());
                lvi.SubItems.Add(dtClasses.Rows[i]["khoa"].ToString());
                lvi.SubItems.Add(dtClasses.Rows[i]["loai"].ToString());

                lsvLop.Items.Add(lvi);
            }
        }

        private void InitDgvDanhSach()
        {
            dgvDanhSach.AllowUserToAddRows = false;

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "MaSV";
            col2.HeaderText = "Mã SV";
            col2.Width = 100;
            dgvDanhSach.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.Name = "HoTen";
            col3.HeaderText = "Họ tên";
            col3.Width = 250;
            dgvDanhSach.Columns.Add(col3);

            DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
            col4.Name = "NgaySinh";
            col4.HeaderText = "Ngày sinh";
            col4.Width = 120;
            dgvDanhSach.Columns.Add(col4);

            DataGridViewComboBoxColumn col5 = new DataGridViewComboBoxColumn();
            col5.Name = "Phai";
            col5.HeaderText = "Phái";
            col5.Width = 80;
            col5.Items.Add("Nam");
            col5.Items.Add("Nữ");
            dgvDanhSach.Columns.Add(col5);

            DataGridViewComboBoxColumn col6 = new DataGridViewComboBoxColumn();
            col6.Name = "Lop";
            col6.HeaderText = "Lớp";
            col6.Width = 100;
            col6.DataSource = busClass.LoadListClasses();
            col6.DisplayMember = "MaLop";
            col6.ValueMember = "MaLop";
            dgvDanhSach.Columns.Add(col6);

            DataGridViewColumn col7 = new DataGridViewTextBoxColumn();
            col7.Name = "DTB";
            col7.HeaderText = "Điểm TB";
            col7.Width = 85;
            dgvDanhSach.Columns.Add(col7);
        }

        private void InitDgvDkhp()
        {
            dgvDkhp.AllowUserToAddRows = false;

            DataGridViewColumn col1 = new DataGridViewCheckBoxColumn();
            col1.Name = "chon";
            col1.HeaderText = "Chọn";
            col1.Width = 100;
            dgvDkhp.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "nh";
            col2.HeaderText = "Năm học";
            col2.Width = 100;
            dgvDkhp.Columns.Add(col2);

            DataGridViewColumn col3 = new DataGridViewTextBoxColumn();
            col3.Name = "hk";
            col3.HeaderText = "Học kỳ";
            col3.Width = 100;
            dgvDkhp.Columns.Add(col3);

            DataGridViewColumn col4 = new DataGridViewTextBoxColumn();
            col4.Name = "masv";
            col4.HeaderText = "Mã SV";
            col4.Width = 120;
            dgvDkhp.Columns.Add(col4);

            DataGridViewColumn col5 = new DataGridViewTextBoxColumn();
            col5.Name = "mamh";
            col5.HeaderText = "Mã MH";
            col5.Width = 100;
            dgvDkhp.Columns.Add(col5);

            DataGridViewColumn col6 = new DataGridViewTextBoxColumn();
            col6.Name = "sotc";
            col6.HeaderText = "Số TC";
            col6.Width = 100;
            dgvDkhp.Columns.Add(col6);

            DataGridViewColumn col7 = new DataGridViewTextBoxColumn();
            col7.Name = "diadiem";
            col7.HeaderText = "Địa điểm";
            col7.Width = 100;
            dgvDkhp.Columns.Add(col7);

            DataGridViewColumn col8 = new DataGridViewTextBoxColumn();
            col8.Name = "diem";
            col8.HeaderText = "Điểm";
            col8.Width = 100;
            dgvDkhp.Columns.Add(col8);
        }
    }
}
