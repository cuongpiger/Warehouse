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
    /// Interaction logic for Replace_Dialog.xaml
    /// </summary>
    public partial class Replace_Dialog : Window
    {
        public string Needle;
        public string Hammer;

        public Replace_Dialog(ReplaceArgs args)
        {
            InitializeComponent();
            needleTextbox.Text = args.Needle;
            hammerTextbox.Text = args.Hammer;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Needle = needleTextbox.Text;
            Hammer = hammerTextbox.Text;

            this.DialogResult = true;
        }
    }
}
