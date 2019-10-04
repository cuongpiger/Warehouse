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
using WpfApp1.Model;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for EditStudentWindow.xaml
    /// </summary>
    public partial class EditStudentWindow : Window
    {
        private Student _myData = null;

        public EditStudentWindow(Student passedStudent)
        {
            InitializeComponent();
            _myData = passedStudent;

            //firstNameTextBox.Text = _myData.FirstName;
            //lastNameTextBox.Text = _myData.LastName;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            //_myData.FirstName = firstNameTextBox.Text;
            //_myData.LastName = lastNameTextBox.Text;

            this.DialogResult = true;
        }
    }
}
