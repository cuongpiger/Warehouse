using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pacman
{
    public partial class frm_Main : Form
    {
        public string[] allLinesMap;
        public List<List<int>> ArrRoute;
        int ii = 0; // Biến xác định phần tử trong mảng route
        public bool checkStart = false; // Kiểm tra, ko cho vẽ pac man đầu tiên
        public int speed = 100;

        public frm_Main(string[] _allLinesMap, int speed, List<List<int>> paths, int _width, int _height)
        {
            InitializeComponent();
            this.allLinesMap = _allLinesMap;
            this.ArrRoute = paths;
            this.Width = _width;
            this.Height = _height;
            this.speed = speed;
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            // Nhóm hàm chống lag
            AntiBrum();

            // Cài đặt process bar
            toolStripProgressBar1.Maximum = ArrRoute.Count();
            toolStripProgressBar1.Minimum = 0;

            // lbl Số bước đi
            lblSoBuocDi.Text = "Số bước đi: 0/" + ArrRoute.Count;

            // Timer
            checkStart = true;
            timer1.Interval = speed;
            timer1.Start();
        }


        private void AntiBrum()
        {
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        // Vẽ tường
        private void DrawWall(Graphics g, int x, int y, Bitmap bm)
        {
            Bitmap myBitmap = bm;// new Bitmap(imageFile);
            g.DrawImage(myBitmap, x, y, 16, 16);
        }


        // Hàm xác định PacMan dịch sang trái phải, hay là lên xuống
        // 1 => Trái
        // 2 => Phải
        // 3 => Lên
        // 4 => Xuống
        private int XacDinhHuong(int x1, int y1, int x2, int y2)
        {
            int temp;
            if (x1 - 1 == x2 && y1 == y2)
            {
                temp = 1; // Trái
            }
            else if (x1 + 1 == x2 && y1 == y2)
            {
                temp = 2; // Phải
            }
            else if (x1 == x2 && y1 + 1 == y2)
            {
                temp = 3; // Lên
            }
            else
            {
                temp = 4; // Xuống
            }
            return temp;
        }



        public string pac = "images/P11.png";
        public Bitmap bmm = Properties.Resources.P11;


        int lineHeight = 0;
        int lineWidth = 0;
        int lineHeight1 = 0;
        int lineWidth1 = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ii < ArrRoute.Count())
            {
                int x11 = ArrRoute[ii][1];
                int y11 = ArrRoute[ii][0];

                if (XacDinhHuong(x11, y11, lineWidth1, lineHeight1) == 1)
                {
                    if (pac == "images/P21.png")
                    {
                        pac = "images/P22.png";
                        bmm = Properties.Resources.P22;
                    }
                    else
                    {
                        pac = "images/P21.png";
                        bmm = Properties.Resources.P21;
                    }
                }
                else if (XacDinhHuong(x11, y11, lineWidth1, lineHeight1) == 2)
                {
                    if (pac == "images/P11.png")
                    {
                        pac = "images/P12.png";
                        bmm = Properties.Resources.P12;
                    }
                    else
                    {
                        pac = "images/P11.png";
                        bmm = Properties.Resources.P11;
                    }
                }
                else if (XacDinhHuong(x11, y11, lineWidth1, lineHeight1) == 3)
                {
                    if (pac == "images/P31.png")
                    {
                        pac = "images/P32.png";
                        bmm = Properties.Resources.P32;
                    }
                    else
                    {
                        pac = "images/P31.png";
                        bmm = Properties.Resources.P31;
                    }
                }
                else if (XacDinhHuong(x11, y11, lineWidth1, lineHeight1) == 4)
                {
                    if (pac == "images/P41.png")
                    {
                        pac = "images/P42.png";
                        bmm = Properties.Resources.P42;
                    }
                    else
                    {
                        pac = "images/P41.png";
                        bmm = Properties.Resources.P41;
                    }
                }

                lblSoBuocDi.Text = "Số bước đi: " + (ii + 1) + "/" + ArrRoute.Count;

                lineWidth1 = ArrRoute[ii][1];
                lineHeight1 = ArrRoute[ii][0];
                ii++;
            }
            else
            {
                timer1.Stop();
            }

            toolStripProgressBar1.Value = ii;

            this.Invalidate();
        }

        private void frm_Main_Paint(object sender, PaintEventArgs e)
        {
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
                    lineWidth = lineWidth + 16;
                }
                lineWidth = 0;
                lineHeight = lineHeight + 16;
            }

            lineWidth = 0;
            lineHeight = 0;
            // Tiến hành chạy Pacman
            for (int i = 0; i < ii; i++)
            {
                // Thread.Sleep(100);
                Bitmap newMap = Properties.Resources.old;
                DrawWall(e.Graphics, 10 + ArrRoute[i][1] * 16, 10 + ArrRoute[i][0] * 16, newMap);
            }

            if (checkStart)
            {
                DrawWall(e.Graphics, 10 + lineWidth1 * 16, 10 + lineHeight1 * 16, bmm);
            }


            // Vẽ Pac Start
            Bitmap newMap1 = Properties.Resources.Pac1;
            DrawWall(e.Graphics, 10 + (ArrRoute[0][1] + 1) * 16, 10 + ArrRoute[0][0] * 16, newMap1);
        }

        private void lblTamDung_Click(object sender, EventArgs e)
        {
            if (lblTamDung.Text == "Tạm Dừng")
            {
                timer1.Stop();
                lblTamDung.Text = "Tiếp Tục";
            } else
            {
                timer1.Start();
                lblTamDung.Text = "Tạm Dừng";
            }
        }
    }
}
