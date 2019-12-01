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
    public partial class frmLop : Form
    {
        static DaoDB daoDB = new DaoDB();
        static BusClass busClass = new BusClass();
        static DataTable dtClasses = new DataTable();
        static int curRecord = 0;
        static int amoRecord = 0;

        private void InitialCbLoai()
        {
            string[] typ = { "CQ", "TN", "CLC", "TT", "VP", "ĐB", "CĐ" };
            cbLoai.DataSource = typ;
            cbLoai.SelectedIndex = 0;
        }

        private void RefreshListClasses()
        {
            dtClasses = busClass.LoadListClasses();
            amoRecord = dtClasses.Rows.Count;
            curRecord = amoRecord != 0 ? 0 : -1;
            ShowClassInfo();
        }

        private void ButtonThemClick()
        {
            DtoClass cls = new DtoClass();

            cls.Khoa = txbKhoa.Text == "" ? -1 : int.Parse(txbKhoa.Text.ToString());
            cls.Loai = cbLoai.SelectedValue.ToString();
            cls.MaLop = txbMaLop.Text;
            cls.LopTruong = txbLopTruong.Text;

            if (busClass.InsertOneClass(cls) == 1)
            {
                MessageBox.Show("Thêm lớp mới thành công!");
                RefreshListClasses();
            }
            else
            {
                MessageBox.Show("Thêm lớp mới không thành công!");
            }
        }

        private void ButtonSuaClick()
        {
            DtoClass cls = new DtoClass();

            cls.Khoa = txbKhoa.Text == "" ? -1 : int.Parse(txbKhoa.Text.ToString());
            cls.Loai = cbLoai.SelectedValue.ToString();
            cls.MaLop = txbMaLop.Text;
            cls.LopTruong = txbLopTruong.Text;

            if (busClass.UpdateOneClass(cls) == 1)
            {
                MessageBox.Show("Sửa lớp này thành công!");
                RefreshListClasses();
            }
            else
            {
                MessageBox.Show("Sửa lớp này không thành công!");
            }
        }

        private void ButtonXoaClick()
        {
            string maLop = txbMaLop.Text;

            if (busClass.DeleteOneClass(maLop) == 1)
            {
                MessageBox.Show("Xóa lớp này thành công!");
                RefreshListClasses();
            }
            else
            {
                MessageBox.Show("Xóa lớp này không thành công!");
            }
        }

        private void ShowClassInfo()
        {
            if (curRecord < 0)
            {
                return;
            }

            txbKhoa.Text = dtClasses.Rows[curRecord]["khoa"].ToString();
            txbLopTruong.Text = dtClasses.Rows[curRecord]["LopTruong"].ToString();
            txbMaLop.Text = dtClasses.Rows[curRecord]["MaLop"].ToString();
            cbLoai.SelectedItem = dtClasses.Rows[curRecord]["loai"].ToString();
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