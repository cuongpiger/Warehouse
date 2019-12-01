namespace QLBH_ProductManagement.GUI
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
            this.ucFunctions1 = new QLBH_ProductManagement.GUI.ucFunctions();
            this.SuspendLayout();
            // 
            // ucFunctions1
            // 
            this.ucFunctions1.Location = new System.Drawing.Point(22, 271);
            this.ucFunctions1.Name = "ucFunctions1";
            this.ucFunctions1.Size = new System.Drawing.Size(631, 48);
            this.ucFunctions1.TabIndex = 0;
            // 
            // frmUserManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 331);
            this.Controls.Add(this.ucFunctions1);
            this.Name = "frmUserManagement";
            this.Tag = "3";
            this.Text = "frmUserManagement";
            this.Load += new System.EventHandler(this.frmUserManagement_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucFunctions ucFunctions1;
    }
}