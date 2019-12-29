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
    static class StringExtension
    {
        public static bool IsEmpty(this string line)
        {
            return line.Length == 0;
        }
    }

    static class TextBoxExtension
    {
        public static bool IsEmpty(this TextBox control)
        {
            return control.Text.IsEmpty();
        }
    }



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        bool canCalcSum()
        {
            var isOkay = true;
            //if (dataTextBox.IsEmpty())
            //{
            //    isOkay = false;
            //    MessageBox.Show("Bạn chưa nhập phân số");
            //}

            return isOkay;
        }

        void calcSum()
        {
            // 3/4 + 5/4 = 32/16
            // 3/4 + 5/4 ==> "+" 3/4  5/4
            // 3/4 ==> / 3    4 ==> so
            // 5/4 ==> / 5    4 ==> so
            //var idiom = dataTextBox.Text;

            //var separator = "+";
            //var tokens = idiom.Split(
            //    new string[] { separator },
            //     StringSplitOptions.None);
            //var firstFraction = Fraction.Parse(tokens[0]);
            //var secondFraction = Fraction.Parse(tokens[1]);
            //var result = Fraction.Plus(firstFraction, secondFraction);

            //MessageBox.Show(result.ToString());
        }

        class Fraction
        {
            public const string Separator = "/";

            public int Numerator { get; set; }
            public int Denominator { get; set; }

            public static Fraction Parse(string token)
            {
                var tokens = token.Split(
                    new string[] { Separator },
                    StringSplitOptions.None);
                var num = int.Parse(tokens[0]);
                var den = int.Parse(tokens[1]);

                return new Fraction()
                {
                    Numerator = num,
                    Denominator = den
                };
            }

            public static Fraction Plus(Fraction a, Fraction b)
            {
                int num = a.Numerator * b.Denominator + a.Denominator * b.Numerator;
                int den = a.Denominator * b.Denominator;
                return new Fraction()
                {
                    Numerator = num,
                    Denominator = den
                };
            }

            public override string ToString()
            {
                return $"{Numerator}{Separator}{Denominator}";
            }
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            if (canCalcSum())
            {
                calcSum();
            }

            ////if (TextBoxExtension.IsEmpty(dataTextBox))



            //if (dataTextBox.IsEmpty())
            //{
            //    MessageBox.Show("Chưa có dữ liệu");
            //}

        }
    }
}
