namespace _1760273
{
    partial class frmOrderManagement
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbMadeIn = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbInvoiceID = new System.Windows.Forms.ComboBox();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txbTotalInvoice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvInvoiceDetail = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Các hóa đơn mua tất cả sản phẩm từ:";
            // 
            // cbMadeIn
            // 
            this.cbMadeIn.FormattingEnabled = true;
            this.cbMadeIn.Location = new System.Drawing.Point(205, 9);
            this.cbMadeIn.Name = "cbMadeIn";
            this.cbMadeIn.Size = new System.Drawing.Size(219, 21);
            this.cbMadeIn.TabIndex = 1;
            this.cbMadeIn.SelectedIndexChanged += new System.EventHandler(this.cbMadeIn_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hóa đơn có mã hóa đơn:";
            // 
            // cbInvoiceID
            // 
            this.cbInvoiceID.FormattingEnabled = true;
            this.cbInvoiceID.Location = new System.Drawing.Point(689, 10);
            this.cbInvoiceID.Name = "cbInvoiceID";
            this.cbInvoiceID.Size = new System.Drawing.Size(157, 21);
            this.cbInvoiceID.TabIndex = 3;
            this.cbInvoiceID.SelectedIndexChanged += new System.EventHandler(this.cbInvoiceID_SelectedIndexChanged);
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoices.Location = new System.Drawing.Point(13, 59);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.Size = new System.Drawing.Size(1028, 167);
            this.dgvInvoices.TabIndex = 4;
            this.dgvInvoices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoices_CellContentClick);
            this.dgvInvoices.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgvInvoices_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(814, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tổng tiền:";
            // 
            // txbTotalInvoice
            // 
            this.txbTotalInvoice.Location = new System.Drawing.Point(875, 237);
            this.txbTotalInvoice.Name = "txbTotalInvoice";
            this.txbTotalInvoice.ReadOnly = true;
            this.txbTotalInvoice.Size = new System.Drawing.Size(166, 20);
            this.txbTotalInvoice.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 261);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Chi tiết hóa đơn:";
            // 
            // dgvInvoiceDetail
            // 
            this.dgvInvoiceDetail.AllowUserToAddRows = false;
            this.dgvInvoiceDetail.AllowUserToDeleteRows = false;
            this.dgvInvoiceDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceDetail.Location = new System.Drawing.Point(13, 289);
            this.dgvInvoiceDetail.Name = "dgvInvoiceDetail";
            this.dgvInvoiceDetail.ReadOnly = true;
            this.dgvInvoiceDetail.Size = new System.Drawing.Size(1028, 276);
            this.dgvInvoiceDetail.TabIndex = 8;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(966, 577);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmOrderManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 608);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvInvoiceDetail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbTotalInvoice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvInvoices);
            this.Controls.Add(this.cbInvoiceID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbMadeIn);
            this.Controls.Add(this.label1);
            this.Name = "frmOrderManagement";
            this.Text = "Kiểm tra đơn hàng";
            this.Load += new System.EventHandler(this.frmOrderManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMadeIn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbInvoiceID;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbTotalInvoice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvInvoiceDetail;
        private System.Windows.Forms.Button btnClose;
    }
}

