using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using MessageBox = System.Windows.Forms.MessageBox;

namespace b2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] files;
        public string path;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnList_Click(object sender, RoutedEventArgs e)
        {
            var screen = new Window1(files, path);
            screen.ShowDialog();
        }

        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            path = dialog.SelectedPath;

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                files = Directory.GetFiles(dialog.SelectedPath);
            }
        }
    }
}
