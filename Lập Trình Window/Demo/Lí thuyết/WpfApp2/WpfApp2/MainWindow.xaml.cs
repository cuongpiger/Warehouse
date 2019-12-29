using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
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

namespace WpfApp2
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

        BindingList<Student> list = null;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            list = new BindingList<Student>()
            {
                new Student() { ID = "1", Fullname="Tran Minh Long", Credits=100, Avatar="/Images/avatar1.jpg"},
                new Student() { ID = "2", Fullname="Le Kieu Diem", Credits=150, Avatar="/Images/avatar2.jpg"},
                new Student() { ID = "3", Fullname="Cao Huu Thinh", Credits=167, Avatar="/Images/avatar3.jpg"}
            };

            itemsControl.ItemsSource = list;

            var student = new Student()
            {
                ID = "4",
                Fullname = "Tran Duc Thang",
                Credits = 50
            };
            Change(student);
            Debug.WriteLine(student.Fullname);
        }

        void Change(Student info)
        {
            info.Fullname = "Nguyen Ai Linh";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var student = (sender as Button).DataContext as Student;
            var screen = new EditStudentWindow(student);

            if (screen.ShowDialog() == true)
            {
                Debug.WriteLine("True");
            } else
            {
                Debug.WriteLine("False");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem1_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(sender.ToString());
        }

        private void MenuItem2_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(sender.ToString());
        }

        private void MenuItem3_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine(sender.ToString());
        }
    }
}
