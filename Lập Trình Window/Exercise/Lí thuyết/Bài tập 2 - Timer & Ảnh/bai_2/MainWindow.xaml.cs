using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Timers;

namespace bai_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] os = {"Gập bụng - 10 cái",
                           "Nâng tạ nằm - 20 cái",
                           "Hít đất - 20 cái",
                           "Chạy bộ - 15 phút",
                           "Lắc vòng - 10 phút",
                           "Squat - 20 cái",
                           "Kéo xà đơn - 15 cái",
                           "Đứng đẩy tạ đôi - 20 cái",
                           "Plank - 2 lần, mỗi lần 1 phút",
                           "Đạp xe đạp - 15 phút"};
        public string[] ima = { "img0.jpg", "img1.jpg", "img2.jpg", "img3.jpg", "img4.jpg", "img5.jpg", "img6.jpg", "img7.jpg", "img8.jpg", "img9.jpg" };
        public List<int> inIma = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            inIma.Clear();
            Random rd = new Random();

            bool[] cheExist = new bool[10];
            inIma = new List<int>();

            while (inIma.Count < 4)
            {
                int v = rd.Next(10);

                if (!cheExist[v])
                {
                    cheExist[v] = true;
                    inIma.Add(v);
                }
            }

            txtb_1.Text = os[inIma[0]].ToString();
            ImageSource img = new BitmapImage(new Uri("pack://application:,,,/image/" + ima[inIma[0]].ToString()));
            img_1.Source = img;

            txtb_2.Text = os[inIma[1]].ToString();
            img = new BitmapImage(new Uri("pack://application:,,,/image/" + ima[inIma[1]].ToString()));
            img_2.Source = img;

            txtb_3.Text = os[inIma[2]].ToString();
            img = new BitmapImage(new Uri("pack://application:,,,/image/" + ima[inIma[2]].ToString()));
            img_3.Source = img;

            txtb_4.Text = os[inIma[3]].ToString();
            img = new BitmapImage(new Uri("pack://application:,,,/image/" + ima[inIma[3]].ToString()));
            img_4.Source = img;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3);
            dispatcherTimer.Start();
        }
    }
}