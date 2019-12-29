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
    /// Interaction logic for NeedleParameterWindow.xaml
    /// </summary>
    public partial class NeedleParameterWindow : Window
    {
        Operation _op = null;
        public NeedleParameterWindow(Operation op)
        {
            InitializeComponent();
            _op = op;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            var args = _op.Args as ReplaceStringProcessorArgs;
            args.Needle = needleTextBox.Text;
            args.Hammer = hammerTextBox.Text;

            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var args = _op.Args as ReplaceStringProcessorArgs;
            needleTextBox.Text = $"{args.Needle}";
            hammerTextBox.Text = $"{args.Hammer}";
        }
    }
}
