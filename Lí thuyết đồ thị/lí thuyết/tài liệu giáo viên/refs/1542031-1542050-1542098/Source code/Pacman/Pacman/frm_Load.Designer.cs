namespace Pacman
{
    partial class frm_Load
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoBanDo5 = new System.Windows.Forms.RadioButton();
            this.rdoBanDo4 = new System.Windows.Forms.RadioButton();
            this.rdoBanDo3 = new System.Windows.Forms.RadioButton();
            this.rdoBanDo2 = new System.Windows.Forms.RadioButton();
            this.rdoBanDo1 = new System.Windows.Forms.RadioButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panelbanDo = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.nudBongMa = new System.Windows.Forms.NumericUpDown();
            this.nudThucAnLon = new System.Windows.Forms.NumericUpDown();
            this.nudThucAnNho = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.cbxTocDo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxH = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxThuatToan = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBongMa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThucAnLon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThucAnNho)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(775, 437);
            this.splitContainer1.SplitterDistance = 196;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton7);
            this.groupBox1.Controls.Add(this.radioButton8);
            this.groupBox1.Controls.Add(this.radioButton9);
            this.groupBox1.Controls.Add(this.radioButton10);
            this.groupBox1.Controls.Add(this.radioButton11);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton5);
            this.groupBox1.Controls.Add(this.radioButton6);
            this.groupBox1.Controls.Add(this.btnLoad);
            this.groupBox1.Controls.Add(this.txtPath);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.rdoBanDo5);
            this.groupBox1.Controls.Add(this.rdoBanDo4);
            this.groupBox1.Controls.Add(this.rdoBanDo3);
            this.groupBox1.Controls.Add(this.rdoBanDo2);
            this.groupBox1.Controls.Add(this.rdoBanDo1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 437);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bản đồ";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(129, 383);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(57, 23);
            this.btnLoad.TabIndex = 7;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(23, 385);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(100, 20);
            this.txtPath.TabIndex = 6;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(23, 361);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(72, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Tùy chỉnh";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdoBanDo5
            // 
            this.rdoBanDo5.AutoSize = true;
            this.rdoBanDo5.Location = new System.Drawing.Point(23, 116);
            this.rdoBanDo5.Name = "rdoBanDo5";
            this.rdoBanDo5.Size = new System.Drawing.Size(69, 17);
            this.rdoBanDo5.TabIndex = 4;
            this.rdoBanDo5.TabStop = true;
            this.rdoBanDo5.Text = "Bản đồ 5";
            this.rdoBanDo5.UseVisualStyleBackColor = true;
            this.rdoBanDo5.CheckedChanged += new System.EventHandler(this.rdoBanDo5_CheckedChanged);
            // 
            // rdoBanDo4
            // 
            this.rdoBanDo4.AutoSize = true;
            this.rdoBanDo4.Location = new System.Drawing.Point(23, 93);
            this.rdoBanDo4.Name = "rdoBanDo4";
            this.rdoBanDo4.Size = new System.Drawing.Size(69, 17);
            this.rdoBanDo4.TabIndex = 3;
            this.rdoBanDo4.TabStop = true;
            this.rdoBanDo4.Text = "Bản đồ 4";
            this.rdoBanDo4.UseVisualStyleBackColor = true;
            this.rdoBanDo4.CheckedChanged += new System.EventHandler(this.rdoBanDo4_CheckedChanged);
            // 
            // rdoBanDo3
            // 
            this.rdoBanDo3.AutoSize = true;
            this.rdoBanDo3.Location = new System.Drawing.Point(23, 70);
            this.rdoBanDo3.Name = "rdoBanDo3";
            this.rdoBanDo3.Size = new System.Drawing.Size(69, 17);
            this.rdoBanDo3.TabIndex = 2;
            this.rdoBanDo3.TabStop = true;
            this.rdoBanDo3.Text = "Bản đồ 3";
            this.rdoBanDo3.UseVisualStyleBackColor = true;
            this.rdoBanDo3.CheckedChanged += new System.EventHandler(this.rdoBanDo3_CheckedChanged);
            // 
            // rdoBanDo2
            // 
            this.rdoBanDo2.AutoSize = true;
            this.rdoBanDo2.Location = new System.Drawing.Point(23, 47);
            this.rdoBanDo2.Name = "rdoBanDo2";
            this.rdoBanDo2.Size = new System.Drawing.Size(69, 17);
            this.rdoBanDo2.TabIndex = 1;
            this.rdoBanDo2.TabStop = true;
            this.rdoBanDo2.Text = "Bản đồ 2";
            this.rdoBanDo2.UseVisualStyleBackColor = true;
            this.rdoBanDo2.CheckedChanged += new System.EventHandler(this.rdoBanDo2_CheckedChanged);
            // 
            // rdoBanDo1
            // 
            this.rdoBanDo1.AutoSize = true;
            this.rdoBanDo1.CausesValidation = false;
            this.rdoBanDo1.Location = new System.Drawing.Point(23, 24);
            this.rdoBanDo1.Name = "rdoBanDo1";
            this.rdoBanDo1.Size = new System.Drawing.Size(69, 17);
            this.rdoBanDo1.TabIndex = 0;
            this.rdoBanDo1.TabStop = true;
            this.rdoBanDo1.Text = "Bản đồ 1";
            this.rdoBanDo1.UseVisualStyleBackColor = true;
            this.rdoBanDo1.CheckedChanged += new System.EventHandler(this.rdoBanDo1_CheckedChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(575, 437);
            this.splitContainer2.SplitterDistance = 294;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panelbanDo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(575, 294);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hiển thị";
            // 
            // panelbanDo
            // 
            this.panelbanDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelbanDo.Location = new System.Drawing.Point(3, 16);
            this.panelbanDo.Name = "panelbanDo";
            this.panelbanDo.Size = new System.Drawing.Size(569, 275);
            this.panelbanDo.TabIndex = 0;
            this.panelbanDo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelbanDo_Paint);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.nudBongMa);
            this.groupBox3.Controls.Add(this.nudThucAnLon);
            this.groupBox3.Controls.Add(this.nudThucAnNho);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnBatDau);
            this.groupBox3.Controls.Add(this.cbxTocDo);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbxH);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbxThuatToan);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(575, 139);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cài đặt";
            // 
            // nudBongMa
            // 
            this.nudBongMa.Location = new System.Drawing.Point(327, 93);
            this.nudBongMa.Name = "nudBongMa";
            this.nudBongMa.Size = new System.Drawing.Size(73, 20);
            this.nudBongMa.TabIndex = 14;
            // 
            // nudThucAnLon
            // 
            this.nudThucAnLon.Location = new System.Drawing.Point(327, 62);
            this.nudThucAnLon.Name = "nudThucAnLon";
            this.nudThucAnLon.Size = new System.Drawing.Size(73, 20);
            this.nudThucAnLon.TabIndex = 13;
            // 
            // nudThucAnNho
            // 
            this.nudThucAnNho.Location = new System.Drawing.Point(327, 32);
            this.nudThucAnNho.Name = "nudThucAnNho";
            this.nudThucAnNho.Size = new System.Drawing.Size(73, 20);
            this.nudThucAnNho.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(248, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Bóng ma";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(248, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Thức ăn lớn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(248, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Thức ăn nhỏ";
            // 
            // btnBatDau
            // 
            this.btnBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBatDau.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnBatDau.Location = new System.Drawing.Point(425, 31);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(145, 83);
            this.btnBatDau.TabIndex = 6;
            this.btnBatDau.Text = "BẮT ĐẦU";
            this.btnBatDau.UseVisualStyleBackColor = true;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // cbxTocDo
            // 
            this.cbxTocDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTocDo.FormattingEnabled = true;
            this.cbxTocDo.Items.AddRange(new object[] {
            "20",
            "50",
            "100",
            "200",
            "500",
            "1000",
            "2000",
            "4000"});
            this.cbxTocDo.Location = new System.Drawing.Point(134, 93);
            this.cbxTocDo.Name = "cbxTocDo";
            this.cbxTocDo.Size = new System.Drawing.Size(86, 21);
            this.cbxTocDo.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tốc độ Pacman (ms)";
            // 
            // cbxH
            // 
            this.cbxH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxH.FormattingEnabled = true;
            this.cbxH.Items.AddRange(new object[] {
            "Manhattan",
            "Euclidean",
            "MaxDXDY",
            "DiagonalShortCut",
            "EuclideanNoSQR"});
            this.cbxH.Location = new System.Drawing.Point(134, 62);
            this.cbxH.Name = "cbxH";
            this.cbxH.Size = new System.Drawing.Size(86, 21);
            this.cbxH.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Heuristic";
            // 
            // cbxThuatToan
            // 
            this.cbxThuatToan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxThuatToan.FormattingEnabled = true;
            this.cbxThuatToan.Items.AddRange(new object[] {
            "AStar(A*)",
            "Dijkstra"});
            this.cbxThuatToan.Location = new System.Drawing.Point(134, 31);
            this.cbxThuatToan.Name = "cbxThuatToan";
            this.cbxThuatToan.Size = new System.Drawing.Size(86, 21);
            this.cbxThuatToan.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thuật toán";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(23, 229);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(75, 17);
            this.radioButton2.TabIndex = 12;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Bản đồ 10";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(23, 206);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(69, 17);
            this.radioButton3.TabIndex = 11;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Bản đồ 9";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(23, 183);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(69, 17);
            this.radioButton4.TabIndex = 10;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Bản đồ 8";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.Location = new System.Drawing.Point(23, 160);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(69, 17);
            this.radioButton5.TabIndex = 9;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Bản đồ 7";
            this.radioButton5.UseVisualStyleBackColor = true;
            this.radioButton5.CheckedChanged += new System.EventHandler(this.radioButton5_CheckedChanged);
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.CausesValidation = false;
            this.radioButton6.Location = new System.Drawing.Point(23, 137);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(69, 17);
            this.radioButton6.TabIndex = 8;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Bản đồ 6";
            this.radioButton6.UseVisualStyleBackColor = true;
            this.radioButton6.CheckedChanged += new System.EventHandler(this.radioButton6_CheckedChanged);
            // 
            // radioButton7
            // 
            this.radioButton7.AutoSize = true;
            this.radioButton7.Location = new System.Drawing.Point(23, 340);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(75, 17);
            this.radioButton7.TabIndex = 17;
            this.radioButton7.TabStop = true;
            this.radioButton7.Text = "Bản đồ 15";
            this.radioButton7.UseVisualStyleBackColor = true;
            this.radioButton7.CheckedChanged += new System.EventHandler(this.radioButton7_CheckedChanged);
            // 
            // radioButton8
            // 
            this.radioButton8.AutoSize = true;
            this.radioButton8.Location = new System.Drawing.Point(23, 317);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(75, 17);
            this.radioButton8.TabIndex = 16;
            this.radioButton8.TabStop = true;
            this.radioButton8.Text = "Bản đồ 14";
            this.radioButton8.UseVisualStyleBackColor = true;
            this.radioButton8.CheckedChanged += new System.EventHandler(this.radioButton8_CheckedChanged);
            // 
            // radioButton9
            // 
            this.radioButton9.AutoSize = true;
            this.radioButton9.Location = new System.Drawing.Point(23, 294);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(75, 17);
            this.radioButton9.TabIndex = 15;
            this.radioButton9.TabStop = true;
            this.radioButton9.Text = "Bản đồ 13";
            this.radioButton9.UseVisualStyleBackColor = true;
            this.radioButton9.CheckedChanged += new System.EventHandler(this.radioButton9_CheckedChanged);
            // 
            // radioButton10
            // 
            this.radioButton10.AutoSize = true;
            this.radioButton10.Location = new System.Drawing.Point(23, 271);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(75, 17);
            this.radioButton10.TabIndex = 14;
            this.radioButton10.TabStop = true;
            this.radioButton10.Text = "Bản đồ 12";
            this.radioButton10.UseVisualStyleBackColor = true;
            this.radioButton10.CheckedChanged += new System.EventHandler(this.radioButton10_CheckedChanged);
            // 
            // radioButton11
            // 
            this.radioButton11.AutoSize = true;
            this.radioButton11.CausesValidation = false;
            this.radioButton11.Location = new System.Drawing.Point(23, 248);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(75, 17);
            this.radioButton11.TabIndex = 13;
            this.radioButton11.TabStop = true;
            this.radioButton11.Text = "Bản đồ 11";
            this.radioButton11.UseVisualStyleBackColor = true;
            this.radioButton11.CheckedChanged += new System.EventHandler(this.radioButton11_CheckedChanged);
            // 
            // frm_Load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 437);
            this.Controls.Add(this.splitContainer1);
            this.Name = "frm_Load";
            this.Text = "Đường đi Pacman";
            this.Load += new System.EventHandler(this.frm_Load_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBongMa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThucAnLon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudThucAnNho)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdoBanDo5;
        private System.Windows.Forms.RadioButton rdoBanDo4;
        private System.Windows.Forms.RadioButton rdoBanDo3;
        private System.Windows.Forms.RadioButton rdoBanDo2;
        private System.Windows.Forms.RadioButton rdoBanDo1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ComboBox cbxTocDo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxThuatToan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Panel panelbanDo;
        private System.Windows.Forms.NumericUpDown nudBongMa;
        private System.Windows.Forms.NumericUpDown nudThucAnLon;
        private System.Windows.Forms.NumericUpDown nudThucAnNho;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButton7;
        private System.Windows.Forms.RadioButton radioButton8;
        private System.Windows.Forms.RadioButton radioButton9;
        private System.Windows.Forms.RadioButton radioButton10;
        private System.Windows.Forms.RadioButton radioButton11;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
    }
}