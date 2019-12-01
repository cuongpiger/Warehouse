namespace QLBH_ProductManagement
{
    partial class frmProductManagement
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
            this.components = new System.ComponentModel.Container();
            this.grvData = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.btnUpdateWithStoreProc = new System.Windows.Forms.Button();
            this.btnUpdateGrid = new System.Windows.Forms.Button();
            this.ucFunctions1 = new QLBH_ProductManagement.GUI.ucFunctions();
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grvData
            // 
            this.grvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvData.ContextMenuStrip = this.contextMenuStrip1;
            this.grvData.Location = new System.Drawing.Point(13, 13);
            this.grvData.Name = "grvData";
            this.grvData.Size = new System.Drawing.Size(670, 276);
            this.grvData.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.addNewToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 70);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.updateToolStripMenuItem.Text = "Update";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
            // 
            // addNewToolStripMenuItem
            // 
            this.addNewToolStripMenuItem.Name = "addNewToolStripMenuItem";
            this.addNewToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.addNewToolStripMenuItem.Text = "Add New";
            this.addNewToolStripMenuItem.Click += new System.EventHandler(this.addNewToolStripMenuItem_Click);
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(12, 295);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(109, 23);
            this.btnLoadData.TabIndex = 1;
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // btnUpdateWithStoreProc
            // 
            this.btnUpdateWithStoreProc.Location = new System.Drawing.Point(127, 295);
            this.btnUpdateWithStoreProc.Name = "btnUpdateWithStoreProc";
            this.btnUpdateWithStoreProc.Size = new System.Drawing.Size(130, 23);
            this.btnUpdateWithStoreProc.TabIndex = 2;
            this.btnUpdateWithStoreProc.Text = "Update With Store Proc";
            this.btnUpdateWithStoreProc.UseVisualStyleBackColor = true;
            this.btnUpdateWithStoreProc.Click += new System.EventHandler(this.btnUpdateWithStoreProc_Click);
            // 
            // btnUpdateGrid
            // 
            this.btnUpdateGrid.Location = new System.Drawing.Point(263, 295);
            this.btnUpdateGrid.Name = "btnUpdateGrid";
            this.btnUpdateGrid.Size = new System.Drawing.Size(157, 23);
            this.btnUpdateGrid.TabIndex = 3;
            this.btnUpdateGrid.Text = "Update Grid";
            this.btnUpdateGrid.UseVisualStyleBackColor = true;
            this.btnUpdateGrid.Click += new System.EventHandler(this.btnUpdateGrid_Click);
            // 
            // ucFunctions1
            // 
            this.ucFunctions1.Location = new System.Drawing.Point(12, 324);
            this.ucFunctions1.Name = "ucFunctions1";
            this.ucFunctions1.Size = new System.Drawing.Size(631, 48);
            this.ucFunctions1.TabIndex = 4;
            // 
            // frmProductManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 390);
            this.Controls.Add(this.ucFunctions1);
            this.Controls.Add(this.btnUpdateGrid);
            this.Controls.Add(this.btnUpdateWithStoreProc);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.grvData);
            this.Name = "frmProductManagement";
            this.Tag = "1";
            this.Text = "Product Management";
            this.Load += new System.EventHandler(this.frmProductManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvData)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grvData;
        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewToolStripMenuItem;
        private System.Windows.Forms.Button btnUpdateWithStoreProc;
        private System.Windows.Forms.Button btnUpdateGrid;
        private GUI.ucFunctions ucFunctions1;
    }
}

