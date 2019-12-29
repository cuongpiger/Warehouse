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

        List<Operation> actions = null;
        static string duplicate(string origin,
        StringProcessorArgs args)
        {
            var multiplyArgs = args as MultiplyStringProcessorArgs;
            var count = multiplyArgs.Count;

            string result = "";
            for (int i = 0; i < count; i++)
            {
                result += origin + "\n";
            }

            return result;
        }

        static string remove(string origin, StringProcessorArgs args)
        {
            var myArgs = args as RemoveStringProcessorArgs;
            int startIndex = myArgs.StartIndex;
            int count = myArgs.Count;

            string result = "";
            result = origin.Remove(startIndex, count);
            return result;
        }

        static string replace(string origin, StringProcessorArgs args)
        {
            var myArgs = args as ReplaceStringProcessorArgs;
            var needle = myArgs.Needle;
            var hammer = myArgs.Hammer;

            string result = "";

            result = origin.Replace(needle, hammer);

            return result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            actions = new List<Operation>();

            actions.Add(new Operation()
            {
                Description = "Remove some characters",
                Processor = remove,
                Args = new RemoveStringProcessorArgs()
                {
                    StartIndex = 0,
                    Count = 10
                }
            });

            var replaceAction = new Operation()
            {
                Description = "Replace string with needle",
                Processor = replace,
                Args = new ReplaceStringProcessorArgs()
                {
                    Needle = "brown",
                    Hammer = "lazy"
                }
            };
            replaceAction.ConfigScreen = new NeedleParameterWindow(replaceAction);
            actions.Add(replaceAction);

            actions.Add(new Operation()
            {
                Description = "Duplicate a string a number of times",
                Processor = duplicate,
                Args = new MultiplyStringProcessorArgs()
                {
                    Count = 4
                }
            });

            actionsComboBox.ItemsSource = actions;
        }

        private void Process_Click(object sender, RoutedEventArgs e)
        {
            var hayStack = hayStackTextBox.Text;

            MessageBox.Show(hayStack);
        }
      
        private void ActionsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var control = sender as ComboBox;
            var item = control.SelectedItem as Operation;

            if (item.ConfigScreen.ShowDialog() == true)
            {
                var origin = hayStackTextBox.Text;
                var result = item.Invoke(origin);
                MessageBox.Show(result);
            }
        }
    }
}
