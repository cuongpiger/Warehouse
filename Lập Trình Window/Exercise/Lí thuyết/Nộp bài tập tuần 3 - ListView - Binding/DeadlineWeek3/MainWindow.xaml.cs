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
using System.IO;
using System.Data;

namespace DeadlineWeek3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.lsvMain.ItemsSource = new Sentence[]
            {
                new Sentence {ContentData="\"Bắt đầu biết hối hận là bắt đầu một cuộc sống mới.\"\nGeorge Eliot", ImageData=UploadImage("img0.jpg")},
                new Sentence {ContentData="\"Cuộc sống vốn không công bằng.\nHãy quen dần với điều đó.\"\nBill Gates", ImageData=UploadImage("img1.jpg")},
                new Sentence {ContentData="\"Hãy sống theo niềm tin của mình và bạn có thể xoay chuyển cả thế giới.\"\nHenry David Thoreau", ImageData=UploadImage("img2.png")},
                new Sentence {ContentData="\"Tôi không buồn vì bạn lừa dối tôi. Tôi buồn vì từ bây giờ tôi không thể tin bạn được nữa.\"\nFriedrich Nietzsche", ImageData=UploadImage("img3.jpg")},
                new Sentence {ContentData="\"Hãy dành thời gian cho những người quanh mình cho dù đó chỉ là một việc làm nho nhỏ.\"\nAlbert Scheweitzer", ImageData=UploadImage("img4.jpg")},
                new Sentence {ContentData= "\"Đừng so sánh mình với bất cứ ai trong thế giới này.\"\nBill Gates", ImageData=UploadImage("img5.jpg")},
                new Sentence {ContentData="\"Tự tin là điều kiện đầu tiên để làm những việc lớn lao.\"\nSamuel Johnson", ImageData=UploadImage("img6.jpg")},
                new Sentence {ContentData="Gập bụng - 10 cái", ImageData=UploadImage("gap_bung.jpg")},
                new Sentence {ContentData="Nâng tạ nằm - 20 cái", ImageData=UploadImage("nang_ta_nam.jpg")},
                new Sentence {ContentData="Hít đất - 20 cái", ImageData=UploadImage("hit_dat.jpg")},
                new Sentence {ContentData="Chạy bộ - 15 phút", ImageData=UploadImage("chay_bo.jpg")},
                new Sentence {ContentData="Lắc vòng - 10 phút", ImageData=UploadImage("lac_vong.jpg")},
                new Sentence {ContentData="Squat - 20 cái", ImageData=UploadImage("squad.jpg")},
                new Sentence {ContentData="Kéo xà đơn - 15 cái", ImageData=UploadImage("hit_xa_don.jpg")},
                new Sentence {ContentData="people - người", ImageData=UploadImage("people.jpg")},
                new Sentence {ContentData="history - lịch sử", ImageData=UploadImage("history.jpg")},
                new Sentence {ContentData="way - con đường", ImageData=UploadImage("way.jpg")},
                new Sentence {ContentData="world - thế giới", ImageData=UploadImage("world.jpg")},
                new Sentence {ContentData="information - thông tin", ImageData=UploadImage("information.jpg")},
                new Sentence {ContentData="family - gia đình", ImageData=UploadImage("family.jpg")},
                new Sentence {ContentData="health - sức khỏe", ImageData=UploadImage("healthy.jpg")}
            };
        }

        //private BitmapImage UploadImage(string filename)
        //{
        //    return new BitmapImage(new Uri("pack://application:,,,/images/" + filename));
        //}

        private string UploadImage(string filename)
        {
            return "/images/" + filename;
        }

        private void LsvMain_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sentence senten = (Sentence)lsvMain.SelectedItem;
            var screen = new WindowDialog(senten);
            screen.ShowDialog();
        }
    }
}
