namespace QLBH
{
    partial class frmUserManagement
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
            this.grvData = new System.Windows.Forms.DataGridView();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnExcuteScalar = new System.Windows.Forms.Button();
            this.btnInsertUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.SuspendLayout();
            // 
            // grvData
            // 
            this.grvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvData.Location = new System.Drawing.Point(13, 13);
            this.grvData.Name = "grvData";
            this.grvData.Size = new System.Drawing.Size(609, 255);
            this.grvData.TabIndex = 0;
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(13, 275);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(139, 23);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.BtnLoadData_Click);
            // 
            // btnExcuteScalar
            // 
            this.btnExcuteScalar.Location = new System.Drawing.Point(172, 275);
            this.btnExcuteScalar.Name = "btnExcuteScalar";
            this.btnExcuteScalar.Size = new System.Drawing.Size(157, 23);
            this.btnExcuteScalar.TabIndex = 2;
            this.btnExcuteScalar.Text = "Excute Scalar";
            this.btnExcuteScalar.UseVisualStyleBackColor = true;
            this.btnExcuteScalar.Click += new System.EventHandler(this.BtnExcuteScalar_Click);
            // 
            // btnInsertUser
            // 
            this.btnInsertUser.Location = new System.Drawing.Point(345, 274);
            this.btnInsertUser.Name = "btnInsertUser";
            this.btnInsertUser.Size = new System.Drawing.Size(152, 23);
            this.btnInsertUser.TabIndex = 3;
            this.btnInsertUser.Text = "Insert User";
            this.btnInsertUser.UseVisualStyleBackColor = true;
            this.btnInsertUser.Click += new System.EventHandler(this.BtnInsertUser_Click);
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 354);
            this.Controls.Add(this.btnInsertUser);
            this.Controls.Add(this.btnExcuteScalar);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.grvData);
            this.Name = "frmUserManagement";
            this.Text = "User Management Form";
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grvData;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.Button btnExcuteScalar;
        private System.Windows.Forms.Button btnInsertUser;
    }
}