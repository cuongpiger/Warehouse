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
        static DataTable dtStudents = new DataTable();

        private void LoadLstStudents()
        {
            dtStudents = busStudent.LoadListStudents();
        }

        private void LoadLstStudentWithClassID()
        {
            dtStudents = busStudent.LoadListStudentsWithClassID(cbLop.SelectedValue.ToString());
        }

        private void AddLstStudentsIntoDgvDanhSach()
        {
            dgvDanhSach.Rows.Clear();

            for (int i = 0; i < dtStudents.Rows.Count; ++i)
            {
                string tmp = dtStudents.Rows[i]["DTB"].ToString();
                dgvDanhSach.Rows.Add(false,
                    dtStudents.Rows[i]["MaSV"].ToString(),
                    dtStudents.Rows[i]["HoTen"].ToString(),
                    DateTime.Parse(dtStudents.Rows[i]["NgaySinh"].ToString()).ToString("dd-MM-yyyy"),
                    dtStudents.Rows[i]["Phai"].ToString(),
                    dtStudents.Rows[i]["Lop"].ToString(),
                    dtStudents.Rows[i]["DTB"].ToString(), "");
            }
        }

        private void ButtonThemClick()
        {
            dgvDanhSach.Rows.Add(true, "", "", "", "", "", "", "them");
        }

        private void ButtonXoaClick()
        {
            foreach (DataGridViewRow r in dgvDanhSach.Rows)
            {
                if ((bool)r.Cells["chon"].Value == true)
                {
                    if (busStudent.DeleteOneStudent(r.Cells["MaSV"].Value.ToString()) != 1)
                    {
                        MessageBox.Show(string.Format("Không thể xóa sinh viên {0}", r.Cells["MaSV"].Value.ToString()));
                    }
                }
            }

            LoadLstStudentWithClassID();
            AddLstStudentsIntoDgvDanhSach();
        }

        private DtoStudent CreateStudentObject(DataGridViewRow r)
        {
            DtoStudent stu = new DtoStudent();

            stu.DTB = (r.Cells["DTB"].Value is null || r.Cells["DTB"].Value.ToString() == "") ? -1 : float.Parse(r.Cells["DTB"].Value.ToString());
            stu.HoTen = r.Cells["HoTen"].Value.ToString();
            stu.Lop = r.Cells["Lop"].Value.ToString();
            stu.NgaySinh = r.Cells["NgaySinh"].Value.ToString();
            stu.Phai = r.Cells["Phai"].Value.ToString();
            stu.MaSV = r.Cells["MaSV"].Value.ToString();

            return stu;
        }

        private void ButtonCapNhatClick()
        {
            foreach (DataGridViewRow r in dgvDanhSach.Rows)
            {
                if ((bool)r.Cells["chon"].Value == true && (string)r.Cells["an"].Value == "them")
                {
                    DtoStudent newStudent = CreateStudentObject(r);
                    if (busStudent.InsertOneStudent(newStudent) == 1)
                        MessageBox.Show("Thêm thành công sinh viên" + r.Cells["MaSV"].Value.ToString());
                }
                else if ((bool)r.Cells["chon"].Value == true)
                {
                    DtoStudent updateStudent = CreateStudentObject(r);
                    if (busStudent.UpdateOneStudent(updateStudent) == 1)
                        MessageBox.Show("Cập nhật thành công sinh viên " + r.Cells["MaSV"].Value.ToString());
                }
            }

            LoadLstStudentWithClassID();
            AddLstStudentsIntoDgvDanhSach();
        }

        private void InitCbClass()
        {
            cbLop.DataSource = busClass.LoadListClasses();
            cbLop.DisplayMember = "MaLop";
            cbLop.ValueMember = "MaLop";
            cbLop.SelectedIndex = 0;
        }

        private void InitDgvDanhSach()
        {
            dgvDanhSach.AllowUserToAddRows = false;

            DataGridViewColumn col1 = new DataGridViewCheckBoxColumn();
            col1.Name = "chon";
            col1.HeaderText = "Chọn";
            col1.Width = 50;
            dgvDanhSach.Columns.Add(col1);

            DataGridViewColumn col2 = new DataGridViewTextBoxColumn();
            col2.Name = "MaSV";
            col2.HeaderText = "Mã SV";
            col2.Width = 80;
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
            col5.Width = 60;
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
            col7.Width = 80;
            dgvDanhSach.Columns.Add(col7);

            DataGridViewColumn col8 = new DataGridViewTextBoxColumn();
            col8.Name = "an";
            col8.HeaderText = "Ẩn";
            col8.Visible = false;
            dgvDanhSach.Columns.Add(col8);
        }
    }
}
