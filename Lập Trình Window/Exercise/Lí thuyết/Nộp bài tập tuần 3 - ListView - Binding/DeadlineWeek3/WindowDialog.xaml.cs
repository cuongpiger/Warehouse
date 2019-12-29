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

namespace DeadlineWeek3
{
    /// <summary>
    /// Interaction logic for WindowDialog.xaml
    /// </summary>
    public partial class WindowDialog : Window
    {
        public Sentence senten = null;

        public WindowDialog(Sentence mySence)
        {
            InitializeComponent();
            senten = mySence;

            img2.Source = new BitmapImage(new Uri(senten.ImageData, UriKind.Relative));
            txtb2.Text = senten.ContentData;
        }
    }
}
