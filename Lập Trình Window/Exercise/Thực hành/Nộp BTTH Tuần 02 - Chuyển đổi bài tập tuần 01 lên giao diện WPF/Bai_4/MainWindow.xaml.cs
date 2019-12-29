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

namespace Bai_4
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

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            project04 equa = new project04();

            if (txbCost.Text != "" && txbCost.Text != "Nhập giá tiền điện thoại")
            {
                try
                {
                    equa.CostPhone = double.Parse(txbCost.Text);
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập giá tiền điện thoại", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txbCost.Text = "";
                    FocusManager.SetFocusedElement(this, txbCost);
                }
                
                txtbAnswer.Text = equa.solve();
            }
        }

        private void TxbCost_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txbCost.Text = "";
            txbCost.FontStyle = FontStyles.Normal;
        }
    }
}
