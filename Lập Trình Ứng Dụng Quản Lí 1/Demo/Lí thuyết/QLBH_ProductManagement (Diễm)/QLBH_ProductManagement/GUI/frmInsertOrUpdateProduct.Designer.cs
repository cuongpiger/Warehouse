namespace QLBH_ProductManagement
{
    partial class frmInsertOrUpdateProduct
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
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.nmrQuantity = new System.Windows.Forms.NumericUpDown();
            this.nmrPrice = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cboSupplier = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddSupplier = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(99, 16);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(337, 20);
            this.txtCode.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(99, 68);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(337, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(99, 42);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(337, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Location = new System.Drawing.Point(12, 101);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(46, 13);
            this.lblQuantity.TabIndex = 10;
            this.lblQuantity.Text = "Quantity";
            // 
            // nmrQuantity
            // 
            this.nmrQuantity.Location = new System.Drawing.Point(99, 95);
            this.nmrQuantity.Name = "nmrQuantity";
            this.nmrQuantity.Size = new System.Drawing.Size(120, 20);
            this.nmrQuantity.TabIndex = 3;
            // 
            // nmrPrice
            // 
            this.nmrPrice.Location = new System.Drawing.Point(99, 121);
            this.nmrPrice.Maximum = new decimal(new int[] {
            1316134912,
            2328,
            0,
            0});
            this.nmrPrice.Name = "nmrPrice";
            this.nmrPrice.Size = new System.Drawing.Size(120, 20);
            this.nmrPrice.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Price";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(12, 180);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(215, 23);
            this.btnProcess.TabIndex = 6;
            this.btnProcess.Text = "Update";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(233, 180);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(215, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cboSupplier
            // 
            this.cboSupplier.FormattingEnabled = true;
            this.cboSupplier.Location = new System.Drawing.Point(99, 148);
            this.cboSupplier.Name = "cboSupplier";
            this.cboSupplier.Size = new System.Drawing.Size(292, 21);
            this.cboSupplier.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Supplier";
            // 
            // btnAddSupplier
            // 
            this.btnAddSupplier.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSupplier.Location = new System.Drawing.Point(398, 148);
            this.btnAddSupplier.Name = "btnAddSupplier";
            this.btnAddSupplier.Size = new System.Drawing.Size(38, 23);
            this.btnAddSupplier.TabIndex = 18;
            this.btnAddSupplier.Text = "+";
            this.btnAddSupplier.UseVisualStyleBackColor = true;
            // 
            // frmInsertOrUpdateProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 215);
            this.Controls.Add(this.btnAddSupplier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboSupplier);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.nmrPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nmrQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Name = "frmInsertOrUpdateProduct";
            this.Text = "frmInsertOrUpdateProduct";
            this.Load += new System.EventHandler(this.frmInsertOrUpdateProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmrQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.NumericUpDown nmrQuantity;
        private System.Windows.Forms.NumericUpDown nmrPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cboSupplier;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddSupplier;
    }
}