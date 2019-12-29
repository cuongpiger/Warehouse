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
    /// Interaction logic for Move_Dialog.xaml
    /// </summary>
    public partial class Move_Dialog : Window
    {
        public int choose;
        public string format;

        public Move_Dialog(MoveArgs args)
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            choose = 0;

            if (moveBackRadioButton.IsChecked == true)
            {
                format = "Move ISBN number to back";
                choose = 1;
            }
            else if (moveAheadRadioButton.IsChecked == true)
            {
                format = "Move ISBN number to ahead";
                choose = 2;
            }

            this.DialogResult = true;
        }
    }
}
