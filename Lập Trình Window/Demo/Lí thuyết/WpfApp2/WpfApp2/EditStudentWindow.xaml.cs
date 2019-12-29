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
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        public Student EditedStudent = null;

        public EditStudentWindow(Student student)
        {
            InitializeComponent();
            EditedStudent = student;

            avatarImage.Source = new BitmapImage(new Uri(EditedStudent.Avatar, UriKind.Relative));
            fullnameTextBox.Text = EditedStudent.Fullname;
            creditsTextBox.Text = EditedStudent.Credits.ToString();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            EditedStudent.Fullname = fullnameTextBox.Text;
            EditedStudent.Credits = int.Parse(creditsTextBox.Text);

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
