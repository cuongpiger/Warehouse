using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<Student> _list = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _list = new BindingList<Student>()
            {
                new Student() { Fullname="Lê Văn Đạt", Avatar="/Images/avatar1.jpg", Credits=120},
                new Student() { Fullname="Nguyễn Ngọc Thúy Diễm", Avatar="/Images/avatar2.jpg", Credits=70},
                new Student() { Fullname="Đoàn Văn Bơ", Avatar="/Images/avatar3.jpg", Credits=20},
                new Student() { Fullname="Hồ Thảo Diệu", Avatar="/Images/avatar4.jpg", Credits=30},
                new Student() { Fullname="Trần My", Avatar="/Images/avatar5.jpg", Credits=30},

            };

            
            string[] paths = File.ReadAllLines("C:\list.txt");

            var selectedStudent = _list[3];
            selectedStackPanel.DataContext = selectedStudent;

            studentsList.ItemsSource = _list;


            //mainStackPanel.DataContext = _student;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            //var screen = new EditStudentWindow(_student);
            //var result = screen.ShowDialog();
            //if (result == true)
            //{
            //    Debug.WriteLine("OK button is clicked");
            //} else // result == false
            //{
            //    Debug.WriteLine("Dialog is closed without editing"); ;
            //}
        }

        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var source = sender as StackPanel;
            var student = source.DataContext as Student;

            Debug.WriteLine(student.Fullname);
        }
    }
}
