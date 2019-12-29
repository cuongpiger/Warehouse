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

namespace WpfApp1
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

        List<Student> list = null;

        class Student
        {
            public string ID { get; set; }
            public string Fullname { get; set; }
            public string Email { get; set; }
            public float GPA { get; set; }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            list = new List<Student>()
            {
                new Student() {
                    ID ="1", Fullname="Nguyen Van Long",
                    Email ="nvlong@gmail.com", GPA=3.4f},
                new Student() {
                    ID ="2", Fullname="Tran Hai Dang",
                    Email ="thdang@gmail.com", GPA=5.7f},
                new Student()
                {
                    ID="3", Fullname="Dang Thi Nhung",
                    Email ="dtnhung@gmail.com", GPA=9.2f
                }
            };

            studentsComboBox.ItemsSource = list;
        }
    }
}
