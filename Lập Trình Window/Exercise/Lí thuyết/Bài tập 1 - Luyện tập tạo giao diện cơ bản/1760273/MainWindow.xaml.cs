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

namespace _1760273
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPro1_Click(object sender, RoutedEventArgs e)
        {
            Random rd = new Random();
            string[] os = { "\"Bắt đầu biết hối hận là bắt đầu một cuộc sống mới.\"\nGeorge Eliot",
                            "\"Cuộc sống vốn không công bằng.\nHãy quen dần với điều đó.\"\nBill Gates",
                            "\"Hãy sống theo niềm tin của mình và bạn có thể xoay chuyển cả thế giới.\"\nHenry David Thoreau",
                            "\"Tôi không buồn vì bạn lừa dối tôi. Tôi buồn vì từ bây giờ tôi không thể tin bạn được nữa.\"\nFriedrich Nietzsche",
                            "\"Hãy dành thời gian cho những người quanh mình cho dù đó chỉ là một việc làm nho nhỏ.\"\nAlbert Scheweitzer",
                            "\"Đừng so sánh mình với bất cứ ai trong thế giới này.\"\nBill Gates",
                            "\"Tự tin là điều kiện đầu tiên để làm những việc lớn lao.\"\nSamuel Johnson",
                            "\"Nụ cười sẽ cho bạn một sắc thái tích cực khiến người khác thoải mái khi ở bên cạnh bạn.\"\nLee Brown",
                            "\"Người khôn ngoan hỏi nguyên do lầm lỗi ở bản thân, kẻ dại khờ hỏi nguyên do ở người khác.\"\nKhổng Tử",
                            "\"Bí mật của một cuộc đời là quan tâm đặc biệt tới một thứ và quan tâm đủ tới cả nghìn thứ.\"\nHorace Walpole"};
            txb_Hello.Text = os[rd.Next(10)];
        }

        private void btnPro2_Click(object sender, RoutedEventArgs e)
        {
            Random rd = new Random();
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
            txb_Hello.Text = os[rd.Next(10)];
        }

        private void btnPro3_Click(object sender, RoutedEventArgs e)
        {
            Random rd = new Random();
            string[] os = {"people - người",
                           "history - lịch sử",
                           "way - con đường",
                           "world - thế giới",
                           "information - thông tin",
                           "family - gia đình",
                           "health - sức khỏe",
                           "computer - máy tính",
                           "music - âm nhạc",
                           "data - dữ liệu"};
            txb_Hello.Text = os[rd.Next(10)];
        }
    }
}
