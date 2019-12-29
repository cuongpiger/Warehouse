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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for NewCase_Dialog.xaml
    /// </summary>
    public partial class NewCase_Dialog : Window
    {
        public int choose;
        public string format;

        public NewCase_Dialog(NewCaseArgs args)
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            choose = 0;

            if (uppercaseRadioButton.IsChecked == true)
            {
                format = "Uppercase";
                choose = 1;
            }
            else if (lowersaseRadioButton.IsChecked == true)
            {
                format = "Lowercase";
                choose = 2;
            }
            else if (capitalizeRadioButton.IsChecked == true)
            {
                format = "Capitalize";
                choose = 3;
            }

            this.DialogResult = true;
        }
    }
}
