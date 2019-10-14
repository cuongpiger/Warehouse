namespace QuanLiSinhVien
{
    partial class frmForm1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvDSSV = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.rdbGiTinhNu = new System.Windows.Forms.RadioButton();
            this.rdbGiTinhNam = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbQueQuan = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbNgaySinh = new System.Windows.Forms.TextBox();
            this.txbHoTen = new System.Windows.Forms.TextBox();
            this.txbMSSV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDSSV);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(790, 388);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách Sinh Viên";
            // 
            // dgvDSSV
            // 
            this.dgvDSSV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSSV.Location = new System.Drawing.Point(6, 19);
            this.dgvDSSV.Name = "dgvDSSV";
            this.dgvDSSV.Size = new System.Drawing.Size(778, 363);
            this.dgvDSSV.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnThem);
            this.groupBox2.Controls.Add(this.btnCapNhat);
            this.groupBox2.Controls.Add(this.btnXoa);
            this.groupBox2.Controls.Add(this.rdbGiTinhNu);
            this.groupBox2.Controls.Add(this.rdbGiTinhNam);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cmbQueQuan);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txbNgaySinh);
            this.groupBox2.Controls.Add(this.txbHoTen);
            this.groupBox2.Controls.Add(this.txbMSSV);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 406);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(790, 157);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết Sinh Viên";
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(645, 108);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 13;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(549, 108);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 12;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(453, 108);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // rdbGiTinhNu
            // 
            this.rdbGiTinhNu.AutoSize = true;
            this.rdbGiTinhNu.Location = new System.Drawing.Point(649, 73);
            this.rdbGiTinhNu.Name = "rdbGiTinhNu";
            this.rdbGiTinhNu.Size = new System.Drawing.Size(39, 17);
            this.rdbGiTinhNu.TabIndex = 10;
            this.rdbGiTinhNu.Text = "Nữ";
            this.rdbGiTinhNu.UseVisualStyleBackColor = true;
            // 
            // rdbGiTinhNam
            // 
            this.rdbGiTinhNam.AutoSize = true;
            this.rdbGiTinhNam.Checked = true;
            this.rdbGiTinhNam.Location = new System.Drawing.Point(560, 73);
            this.rdbGiTinhNam.Name = "rdbGiTinhNam";
            this.rdbGiTinhNam.Size = new System.Drawing.Size(47, 17);
            this.rdbGiTinhNam.TabIndex = 9;
            this.rdbGiTinhNam.TabStop = true;
            this.rdbGiTinhNam.Text = "Nam";
            this.rdbGiTinhNam.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Giới tính";
            // 
            // cmbQueQuan
            // 
            this.cmbQueQuan.FormattingEnabled = true;
            this.cmbQueQuan.Location = new System.Drawing.Point(536, 33);
            this.cmbQueQuan.Name = "cmbQueQuan";
            this.cmbQueQuan.Size = new System.Drawing.Size(188, 21);
            this.cmbQueQuan.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(474, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quê quán";
            // 
            // txbNgaySinh
            // 
            this.txbNgaySinh.Location = new System.Drawing.Point(114, 111);
            this.txbNgaySinh.Name = "txbNgaySinh";
            this.txbNgaySinh.Size = new System.Drawing.Size(226, 20);
            this.txbNgaySinh.TabIndex = 5;
            this.txbNgaySinh.Enter += new System.EventHandler(this.txbNgaySinh_Enter);
            this.txbNgaySinh.Leave += new System.EventHandler(this.txbNgaySinh_Leave);
            // 
            // txbHoTen
            // 
            this.txbHoTen.Location = new System.Drawing.Point(114, 72);
            this.txbHoTen.Name = "txbHoTen";
            this.txbHoTen.Size = new System.Drawing.Size(226, 20);
            this.txbHoTen.TabIndex = 4;
            // 
            // txbMSSV
            // 
            this.txbMSSV.Location = new System.Drawing.Point(114, 33);
            this.txbMSSV.Name = "txbMSSV";
            this.txbMSSV.Size = new System.Drawing.Size(226, 20);
            this.txbMSSV.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày sinh";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Họ tên";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "MSSV";
            // 
            // frmForm1
            // 
            this.ClientSize = new System.Drawing.Size(814, 575);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lí Sinh Viên";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSSV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvDSSV;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.RadioButton rdbGiTinhNu;
        private System.Windows.Forms.RadioButton rdbGiTinhNam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbQueQuan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbNgaySinh;
        private System.Windows.Forms.TextBox txbHoTen;
        private System.Windows.Forms.TextBox txbMSSV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

