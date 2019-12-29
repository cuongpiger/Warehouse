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
using System.Windows.Forms;
using System.IO;
using Path = System.IO.Path;
using MessageBox = System.Windows.Forms.MessageBox;

namespace b2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string myPath;
        public Window1(string[] files, string path)
        {
            InitializeComponent();

            for (int i = 0; i < files.Count<string>(); ++i)
            {
                lsbMain.Items.Add(files[i]);
            }

            myPath = path;
        }

        private void BtnRename_Click(object sender, RoutedEventArgs e)
        {
            if (lsbMain.SelectedIndex != -1)
            {
                if (txbRename.Text != "")
                {
                    string curDir = Path.GetDirectoryName(lsbMain.SelectedItem.ToString());
                    curDir += "\\";
                    curDir += txbRename.Text.ToString();
                    string from_ = lsbMain.SelectedItem.ToString();
                    lsbMain.Items.RemoveAt(lsbMain.Items.IndexOf(lsbMain.SelectedItem));
                    lsbMain.Items.Add(curDir);
                    File.Move(from_, curDir);
                    lsbMain.Items.Refresh();
                }
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(myPath);

            foreach (FileInfo file in di.EnumerateFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.EnumerateDirectories())
            {
                dir.Delete(true);
            }

            if (Directory.Exists(myPath))
            {
                Directory.Delete(myPath);
            }

            lsbMain.Items.Clear();
            lsbMain.Items.Refresh();
            this.Close();
        }
    }
}
