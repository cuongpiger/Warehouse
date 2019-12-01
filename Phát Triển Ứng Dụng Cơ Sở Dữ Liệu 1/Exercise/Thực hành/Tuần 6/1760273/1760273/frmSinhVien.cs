using _1760273.BUS;
using _1760273.DAO;
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
    public partial class frmSinhVien : Form
    {
        static DaoDB daoDB = new DaoDB();
        static BusStudent busStudent = new BusStudent();
        static DataTable dtStudents = new DataTable();
        static int curRecord = 0;
        static int amoRecord = 0;

        private void InitialCbPhai()
        {
            string[] gender = { "Nam", "Nữ" };
            cbPhai.DataSource = gender;
            cbPhai.SelectedIndex = 0;
        }

        private void InitialCbClass()
        {
            cbLop.DataSource = daoDB.GetData("stpLoadClassID");
            cbLop.DisplayMember = "MaLop";
            cbLop.ValueMember = "MaLop";
        }

        private void RefreshListStudents()
        {
            dtStudents = busStudent.LoadListStudents();
            amoRecord = dtStudents.Rows.Count;
            curRecord = amoRecord != 0 ? 0 : -1;
            ShowStudentInfo();
        }

        private void ButtonThemClick()
        {
            DtoStudent stu = new DtoStudent();

            stu.DTB = txbDiemTB.Text == "" ? -1 : float.Parse(txbDiemTB.Text);
            stu.HoTen = txbHoTen.Text;
            stu.Lop = cbLop.SelectedValue.ToString();
            stu.NgaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            stu.Phai = cbPhai.SelectedValue.ToString();
            stu.MaSV = txbMaSinhVien.Text;

            if (busStudent.InsertOneStudent(stu) == 1)
            {
                MessageBox.Show("Thêm sinh viên mới thành công!");
                RefreshListStudents();
            }
            else
            {
                MessageBox.Show("Thêm sinh viên mới không thành công!");
            }
        }

        private void ButtonSuaClick()
        {
            DtoStudent stu = new DtoStudent();

            stu.DTB = txbDiemTB.Text == "" ? -1 : float.Parse(txbDiemTB.Text);
            stu.HoTen = txbHoTen.Text;
            stu.Lop = cbLop.SelectedValue.ToString();
            stu.NgaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            stu.Phai = cbPhai.SelectedValue.ToString();
            stu.MaSV = txbMaSinhVien.Text;

            if (busStudent.UpdateOneStudent(stu) == 1)
            {
                MessageBox.Show("Sửa sinh viên này thành công!");
                RefreshListStudents();
            }
            else
            {
                MessageBox.Show("Sửa sinh viên này không thành công!");
            }
        }

        private void ButtonXoaClick()
        {
            string maSV = txbMaSinhVien.Text;

            if (busStudent.DeleteOneStudent(maSV) == 1)
            {
                MessageBox.Show("Xóa sinh viên này thành công!");
                RefreshListStudents();
            }
            else
            {
                MessageBox.Show("Xóa sinh viên này không thành công!");
            }
        }

        private void ShowStudentInfo()
        {
            if (curRecord < 0)
            {
                return;
            }

            txbDiemTB.Text = dtStudents.Rows[curRecord]["DTB"].ToString();
            txbHoTen.Text = dtStudents.Rows[curRecord]["HoTen"].ToString();
            txbMaSinhVien.Text = dtStudents.Rows[curRecord]["MaSV"].ToString();
            dtpNgaySinh.Value = Convert.ToDateTime(dtStudents.Rows[curRecord]["NgaySinh"]);
            cbLop.SelectedValue = dtStudents.Rows[curRecord]["Lop"].ToString();
            cbPhai.SelectedItem = dtStudents.Rows[curRecord]["Phai"].ToString();
        }

        private void SwitchNextPrevButton()
        {
            if (amoRecord == 0)
            {
                btnNext.Enabled = btnPrev.Enabled = false;
            }
            else if (curRecord == 0)
            {
                btnNext.Enabled = true;
                btnPrev.Enabled = false;
            }
            else if (curRecord == amoRecord - 1)
            {
                btnNext.Enabled = false;
                btnPrev.Enabled = true;
            }
        }
    }
}
