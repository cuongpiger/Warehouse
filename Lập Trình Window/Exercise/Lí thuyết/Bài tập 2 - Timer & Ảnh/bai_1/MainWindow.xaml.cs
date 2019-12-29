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

namespace bai_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] os = { "\"Bắt đầu biết hối hận là bắt đầu một cuộc sống mới.\"\nGeorge Eliot",
                            "\"Cuộc sống vốn không công bằng.\nHãy quen dần với điều đó.\"\nBill Gates",
                            "\"Hãy sống theo niềm tin của mình và bạn có thể xoay chuyển cả thế giới.\"\nHenry David Thoreau",
                            "\"Tôi không buồn vì bạn lừa dối tôi. Tôi buồn vì từ bây giờ tôi không thể tin bạn được nữa.\"\nFriedrich Nietzsche",
                            "\"Hãy dành thời gian cho những người quanh mình cho dù đó chỉ là một việc làm nho nhỏ.\"\nAlbert Scheweitzer",
                            "\"Đừng so sánh mình với bất cứ ai trong thế giới này.\"\nBill Gates",
                            "\"Tự tin là điều kiện đầu tiên để làm những việc lớn lao.\"\nSamuel Johnson",
                            "\"Nụ cười sẽ cho bạn một sắc thái tích cực khiến người khác thoải mái khi ở bên cạnh bạn.\"\nLee Brown",
                            "\"Người khôn ngoan hỏi nguyên do lầm lỗi ở bản thân, kẻ dại khờ hỏi nguyên do ở người khác.\"\nKhổng Tử",
                            "\"Bí mật của một cuộc đời là quan tâm đặc biệt tới một thứ và quan tâm đủ tới cả nghìn thứ.\"\nHorace Walpole"};
        public string[] ima = { "img0.jpg", "img1.jpg", "img2.png", "img3.jpg", "img4.jpg", "img5.jpg", "img6.jpg", "img7.jpg", "img8.jpg", "img9.jpg" };
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
