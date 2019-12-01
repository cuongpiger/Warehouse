﻿using System;
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
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ButtonThemClick();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            ButtonXoaClick();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            ButtonSuaClick();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            InitialCbPhai();
            InitialCbClass();
            RefreshListStudents();
            SwitchNextPrevButton();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            SwitchNextPrevButton();
            curRecord -= (btnPrev.Enabled == true ? 1 : 0);
            ShowStudentInfo();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            SwitchNextPrevButton();
            curRecord += (btnNext.Enabled == true ? 1 : 0);
            ShowStudentInfo();
        }
    }
}
