namespace _1760273
{
    partial class frmMain
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
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tbCanHo = new System.Windows.Forms.TabPage();
            this.dgvApartment = new System.Windows.Forms.DataGridView();
            this.btnThoatCanHo = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCanHo = new System.Windows.Forms.ToolStripMenuItem();
            this.smiCuDan = new System.Windows.Forms.ToolStripMenuItem();
            this.btnThemCanHo = new System.Windows.Forms.Button();
            this.btnXoaCanHo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.tbMain.SuspendLayout();
            this.tbCanHo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartment)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbCanHo);
            this.tbMain.Controls.Add(this.tabPage2);
            this.tbMain.Location = new System.Drawing.Point(12, 27);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(1103, 433);
            this.tbMain.TabIndex = 0;
            // 
            // tbCanHo
            // 
            this.tbCanHo.Controls.Add(this.button3);
            this.tbCanHo.Controls.Add(this.button1);
            this.tbCanHo.Controls.Add(this.btnXoaCanHo);
            this.tbCanHo.Controls.Add(this.btnThemCanHo);
            this.tbCanHo.Controls.Add(this.dgvApartment);
            this.tbCanHo.Controls.Add(this.btnThoatCanHo);
            this.tbCanHo.Location = new System.Drawing.Point(4, 22);
            this.tbCanHo.Name = "tbCanHo";
            this.tbCanHo.Padding = new System.Windows.Forms.Padding(3);
            this.tbCanHo.Size = new System.Drawing.Size(1095, 407);
            this.tbCanHo.TabIndex = 0;
            this.tbCanHo.Text = "Căn hộ";
            this.tbCanHo.UseVisualStyleBackColor = true;
            // 
            // dgvApartment
            // 
            this.dgvApartment.AllowUserToAddRows = false;
            this.dgvApartment.AllowUserToDeleteRows = false;
            this.dgvApartment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApartment.Location = new System.Drawing.Point(6, 6);
            this.dgvApartment.Name = "dgvApartment";
            this.dgvApartment.ReadOnly = true;
            this.dgvApartment.Size = new System.Drawing.Size(1083, 366);
            this.dgvApartment.TabIndex = 1;
            this.dgvApartment.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvApartment_DataError);
            // 
            // btnThoatCanHo
            // 
            this.btnThoatCanHo.Location = new System.Drawing.Point(1014, 378);
            this.btnThoatCanHo.Name = "btnThoatCanHo";
            this.btnThoatCanHo.Size = new System.Drawing.Size(75, 23);
            this.btnThoatCanHo.TabIndex = 0;
            this.btnThoatCanHo.Text = "Thoát";
            this.btnThoatCanHo.UseVisualStyleBackColor = true;
            this.btnThoatCanHo.Click += new System.EventHandler(this.btnThoatCanHo_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1095, 407);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(534, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chứcNăngToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1127, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smiCanHo,
            this.smiCuDan});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.chứcNăngToolStripMenuItem.Text = "Quản lí trang";
            // 
            // smiCanHo
            // 
            this.smiCanHo.Name = "smiCanHo";
            this.smiCanHo.Size = new System.Drawing.Size(180, 22);
            this.smiCanHo.Text = "Căn hộ";
            this.smiCanHo.Click += new System.EventHandler(this.smiCanHo_Click);
            // 
            // smiCuDan
            // 
            this.smiCuDan.Name = "smiCuDan";
            this.smiCuDan.Size = new System.Drawing.Size(180, 22);
            this.smiCuDan.Text = "Cư dân";
            this.smiCuDan.Click += new System.EventHandler(this.smiCuDan_Click);
            // 
            // btnThemCanHo
            // 
            this.btnThemCanHo.Location = new System.Drawing.Point(7, 378);
            this.btnThemCanHo.Name = "btnThemCanHo";
            this.btnThemCanHo.Size = new System.Drawing.Size(75, 23);
            this.btnThemCanHo.TabIndex = 2;
            this.btnThemCanHo.Text = "Thêm";
            this.btnThemCanHo.UseVisualStyleBackColor = true;
            this.btnThemCanHo.Click += new System.EventHandler(this.btnThemCanHo_Click);
            // 
            // btnXoaCanHo
            // 
            this.btnXoaCanHo.Location = new System.Drawing.Point(114, 378);
            this.btnXoaCanHo.Name = "btnXoaCanHo";
            this.btnXoaCanHo.Size = new System.Drawing.Size(75, 23);
            this.btnXoaCanHo.TabIndex = 3;
            this.btnXoaCanHo.Text = "Xóa";
            this.btnXoaCanHo.UseVisualStyleBackColor = true;
            this.btnXoaCanHo.Click += new System.EventHandler(this.btnXoaCanHo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(334, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Làm mới";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(222, 378);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Sửa";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 584);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lí cư dân";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tbMain.ResumeLayout(false);
            this.tbCanHo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvApartment)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tbCanHo;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem smiCanHo;
        private System.Windows.Forms.Button btnThoatCanHo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView dgvApartment;
        private System.Windows.Forms.ToolStripMenuItem smiCuDan;
        private System.Windows.Forms.Button btnThemCanHo;
        private System.Windows.Forms.Button btnXoaCanHo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

