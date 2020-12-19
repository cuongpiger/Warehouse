using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core;

namespace Pacman
{
    public partial class frm_Load : Form
    {
        public string[] allLinesMap;
        public string[] allLineRoute;
        public List<List<int>> ArrRoute;
        public string currentMap = "map/bando1.lay";
        
        public frm_Load()
        {
            InitializeComponent();
        }

        private void frm_Load_Load(object sender, EventArgs e)
        {
            // Nhóm hàm chống rung giật
            AntiBrum();

            // Set giá trị mặc định cho giao diện
            cbxThuatToan.SelectedItem = "AStar(A*)";
            cbxH.SelectedItem = "Manhattan";
            cbxTocDo.SelectedItem = "100";
            rdoBanDo1.Checked = true;

            // Chi phí mặc đinh
            nudBongMa.Value = 10;
            nudThucAnLon.Value = 1;
            nudThucAnNho.Value = 2;
        }

        private void AntiBrum()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        // Đọc bản đồ
        private string[] ReadFileMap(string filename)
        {
            return File.ReadAllLines(filename);
        }

        

        // Vẽ tường
        private void DrawWall(Graphics g, int x, int y, Bitmap bm)
        {
            Bitmap myBitmap = bm;// new Bitmap(imageFile);

            g.DrawImage(myBitmap, x, y, 12, 12);
        }

        
        public string pac = "images/P11.png";
        public Bitmap bmm = Properties.Resources.P11;

        private void panelbanDo_Paint(object sender, PaintEventArgs e)
        {
            int lineHeight = 0;
            int lineWidth = 50;

            for (int i = 0; i < allLinesMap.Count(); i++)
            {
                foreach (char c in allLinesMap[i])
                {
                    if (c == '%')
                    {
                        Bitmap newPic = Properties.Resources.Wall;
                        DrawWall(e.Graphics, 10 + lineWidth, 10 + lineHeight, newPic);
                    }
                    if (c == 'P')
                    {
                        DrawWall(e.Graphics, 10 + lineWidth, 10 + lineHeight, bmm);
                    }
                    if (c == 'G')
                    {
                        Bitmap newPic = Properties.Resources.G2;
                        DrawWall(e.Graphics, 10 + lineWidth, 10 + lineHeight, newPic);
                    }
                    if (c == 'o')
                    {
                        Bitmap newMap = Properties.Resources.Big;
                        DrawWall(e.Graphics, 10 + lineWidth, 10 + lineHeight, newMap);
                    }
                    if (c == '.')
                    {
                        Bitmap newMap = Properties.Resources.Small;
                        DrawWall(e.Graphics, 10 + lineWidth, 10 + lineHeight, newMap);
                    }
                    lineWidth = lineWidth + 12;
                }
                lineWidth = 50;
                lineHeight = lineHeight + 12;
            }
        }

        private void rdoBanDo1_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando1.lay");
            currentMap = "map/bando1.lay";
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void rdoBanDo2_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando2.lay");
            currentMap = "map/bando2.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void rdoBanDo3_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando3.lay");
            currentMap = "map/bando3.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void rdoBanDo4_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando4.lay");
            currentMap = "map/bando4.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void rdoBanDo5_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando5.lay");
            currentMap = "map/bando5.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            // Check option
            string opH = cbxH.SelectedItem.ToString();
            string opThuatToan = cbxThuatToan.SelectedItem.ToString();

            // Check chi phí
            int ThucAnNho = Int32.Parse(nudThucAnNho.Value.ToString());
            int ThucAnLon = Int32.Parse(nudThucAnLon.Value.ToString());
            int BongMa = Int32.Parse(nudBongMa.Value.ToString());

            // Tính toán tìm đường đi
            Graph g = new Graph();
            g.HType = opH; // Chọn Heuristic
            g.ThuatToan = opThuatToan; // Chọn thuật giải
            g.ThucAnNho = ThucAnNho;
            g.ThucAnLon = ThucAnLon;
            g.BongMa = BongMa;
            g.ReadFile(currentMap);
            g.RunPacman();
            int a = g.CountStep;

            g.WriteFile("log.txt"); // Ghi log đường đi
            List<List<int>> paths = g.GetPaths();
            int speed = Int32.Parse(cbxTocDo.SelectedItem.ToString());
            
            frm_Main main = new frm_Main(allLinesMap, speed, paths, allLinesMap[0].Count() * 16 + 40, allLinesMap.Count() * 16 + 80);
            main.ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "*.lay|*.lay| All File|*.*";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = open.FileName;
                allLinesMap = ReadFileMap(txtPath.Text);
                currentMap = txtPath.Text;
                this.Invalidate();
                panelbanDo.Hide();
                panelbanDo.Refresh();
                panelbanDo.Show();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando6.lay");
            currentMap = "map/bando6.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando7.lay");
            currentMap = "map/bando7.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando8.lay");
            currentMap = "map/bando8.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando9.lay");
            currentMap = "map/bando9.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando10.lay");
            currentMap = "map/bando10.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando11.lay");
            currentMap = "map/bando11.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando12.lay");
            currentMap = "map/bando12.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando13.lay");
            currentMap = "map/bando13.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando14.lay");
            currentMap = "map/bando14.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            allLinesMap = ReadFileMap("map/bando15.lay");
            currentMap = "map/bando15.lay";
            this.Invalidate();
            panelbanDo.Hide();
            panelbanDo.Refresh();
            panelbanDo.Show();
        }
    }
}
