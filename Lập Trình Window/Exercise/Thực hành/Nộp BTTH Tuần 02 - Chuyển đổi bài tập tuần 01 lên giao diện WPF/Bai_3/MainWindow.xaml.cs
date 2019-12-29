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

namespace Bai_3
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
            project03 equa = new project03();

            if (txbNumberA.Text != "" && txbNumberA.Text != "Enter the number A" && txbNumberB.Text != "" && txbNumberB.Text != "Enter the number B"
                && txbNumberC.Text != "" && txbNumberC.Text != "Enter the number C")
            {
                try
                {
                    equa.A = double.Parse(txbNumberA.Text);
                }
                catch
                {
                    MessageBox.Show("A is unvalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txbNumberA.Text = "";
                    FocusManager.SetFocusedElement(this, txbNumberA);
                }

                try
                {
                    equa.B = double.Parse(txbNumberB.Text);
                }
                catch
                {
                    MessageBox.Show("B is unvalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txbNumberB.Text = "";
                    FocusManager.SetFocusedElement(this, txbNumberB);
                }

                try
                {
                    equa.C = double.Parse(txbNumberC.Text);
                }
                catch
                {
                    MessageBox.Show("C is unvalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txbNumberC.Text = "";
                    FocusManager.SetFocusedElement(this, txbNumberC);
                }

                txtbAnswer.Text = equa.solveProblem();
            }
        }

        private void TxbNumberA_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txbNumberA.Text = "";
            txbNumberA.FontStyle = FontStyles.Normal;
        }

        private void TxbNumberB_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txbNumberB.Text = "";
            txbNumberB.FontStyle = FontStyles.Normal;
        }

        private void TxbNumberC_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txbNumberC.Text = "";
            txbNumberC.FontStyle = FontStyles.Normal;
        }
    }
}
