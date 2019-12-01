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
namespace _1760273
{
    public partial class frmThemMotSinhVien
    {
        static DaoDB daoDB = new DaoDB();
        static BusStudent busStudent = new BusStudent();

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

        private void ButtonThemClick()
        {
            DtoStudent stu = new DtoStudent();

            stu.DTB = txbDiemTB.Text == "" ? -1:float.Parse(txbDiemTB.Text);
            stu.HoTen = txbHoTen.Text;
            stu.Lop = cbLop.SelectedValue.ToString();
            stu.NgaySinh = dtpNgaySinh.Value.ToString("yyyy-mm-dd");
            stu.Phai = cbPhai.SelectedValue.ToString();
            stu.MaSV = txbMaSinhVien.Text;

            if (busStudent.InsertOneStudent(stu) == 1)
            {
                MessageBox.Show("Insert successfully!");
            }
            else
            {
                MessageBox.Show("Insert unsuccessfully!");
            }
        }
    }
}
