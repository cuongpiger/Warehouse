namespace _1760273.GUI
{
    partial class frmMenu
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
            this.btnFrmLop = new System.Windows.Forms.Button();
            this.btnFrmSinhVien = new System.Windows.Forms.Button();
            this.btnThemSinhVien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnFrmLop
            // 
            this.btnFrmLop.Location = new System.Drawing.Point(31, 29);
            this.btnFrmLop.Name = "btnFrmLop";
            this.btnFrmLop.Size = new System.Drawing.Size(140, 23);
            this.btnFrmLop.TabIndex = 0;
            this.btnFrmLop.Text = "Quản lí lớp học";
            this.btnFrmLop.UseVisualStyleBackColor = true;
            this.btnFrmLop.Click += new System.EventHandler(this.btnFrmLop_Click);
            // 
            // btnFrmSinhVien
            // 
            this.btnFrmSinhVien.Location = new System.Drawing.Point(209, 29);
            this.btnFrmSinhVien.Name = "btnFrmSinhVien";
            this.btnFrmSinhVien.Size = new System.Drawing.Size(140, 23);
            this.btnFrmSinhVien.TabIndex = 1;
            this.btnFrmSinhVien.Text = "Quán lí sinh viên";
            this.btnFrmSinhVien.UseVisualStyleBackColor = true;
            this.btnFrmSinhVien.Click += new System.EventHandler(this.btnFrmSinhVien_Click);
            // 
            // btnThemSinhVien
            // 
            this.btnThemSinhVien.Location = new System.Drawing.Point(387, 29);
            this.btnThemSinhVien.Name = "btnThemSinhVien";
            this.btnThemSinhVien.Size = new System.Drawing.Size(140, 23);
            this.btnThemSinhVien.TabIndex = 2;
            this.btnThemSinhVien.Text = "Thêm một sinh viên";
            this.btnThemSinhVien.UseVisualStyleBackColor = true;
            this.btnThemSinhVien.Click += new System.EventHandler(this.btnThemSinhVien_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 78);
            this.Controls.Add(this.btnThemSinhVien);
            this.Controls.Add(this.btnFrmSinhVien);
            this.Controls.Add(this.btnFrmLop);
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnFrmLop;
        private System.Windows.Forms.Button btnFrmSinhVien;
        private System.Windows.Forms.Button btnThemSinhVien;
    }
}