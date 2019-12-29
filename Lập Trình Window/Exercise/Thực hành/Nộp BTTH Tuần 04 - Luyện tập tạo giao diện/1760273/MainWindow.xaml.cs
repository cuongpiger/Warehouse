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

namespace _1760273
{
    static class StringExtension
    {
        public static bool IsEmpty(this string myStr)
        {
            return myStr.Length <= 0;
        }
    }

    static class TextBoxExtension
    {
        public static bool IsEmpty(this TextBox cnt)
        {
            return cnt.Text.IsEmpty();
        }
    }

    static class GreatestCommonDivisor
    {
        public static int gcd(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }

            return gcd(b, a % b);
        }
    }

    //=================================================== Class ahead============================================
    public partial class MainWindow : Window
    {
        class Fraction
        {
            public const string Separator = "/";
            public int Numerator { get; set; }
            public int Denominator { get; set; }

            public Fraction(int num, int den)
            {
                Numerator = num;
                Denominator = den;
            }

            public static Fraction Parse(string token)
            {
                var tokens = token.Split(new string[] { Separator }, StringSplitOptions.RemoveEmptyEntries);
                int num = 0, den = 0;
                bool check = true;

                check = int.TryParse(tokens[0], out num) && int.TryParse(tokens[1], out den);

                if (!check)
                {
                    MessageBox.Show("Your string contains invalid characters or empty!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    num = 0;
                    den = 0;
                }

                return new Fraction(num, den);
            }

            public static string[] CutString(TextBox datatxb)
            {
                var tokens = datatxb.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                return tokens;
            }

            public static Fraction operator +(Fraction a, Fraction b)
            {
                int num = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
                int den = a.Denominator * b.Denominator;

                return new Fraction(num, den);
            }

            public static Fraction operator -(Fraction a, Fraction b)
            {
                int num = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
                int den = a.Denominator * b.Denominator;

                return new Fraction(num, den);
            }

            public static Fraction operator *(Fraction a, Fraction b)
            {
                int num = a.Numerator * b.Numerator;
                int den = a.Denominator * b.Denominator;

                return new Fraction(num, den);
            }

            public static Fraction operator /(Fraction a, Fraction b)
            {
                int num = a.Numerator * b.Denominator;
                int den = a.Denominator * b.Numerator;

                return new Fraction(num, den);
            }

            public override string ToString()
            {
                return $"{Numerator}{Separator}{Denominator}";
            }
        }

        //=========================== Class ahead ================================
        public string[] tokens;
        Fraction res = new Fraction(0, 1);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            if (lsbSaveData.Items.Count != 0)
            {
                res = Fraction.Parse(lsbSaveData.Items.GetItemAt(0).ToString());

                for (int i = 1; i < lsbSaveData.Items.Count; ++i)
                {
                    if (rbtnAdd.IsChecked == true)
                    {
                        res = res + Fraction.Parse(lsbSaveData.Items.GetItemAt(i).ToString());
                    }
                    else if (rbtnSub.IsChecked == true)
                    {
                        res = res - Fraction.Parse(lsbSaveData.Items.GetItemAt(i).ToString());
                    }
                    else if (rbtnMul.IsChecked == true)
                    {
                        res = res * Fraction.Parse(lsbSaveData.Items.GetItemAt(i).ToString());
                    }
                    else
                    {
                        res = res / Fraction.Parse(lsbSaveData.Items.GetItemAt(i).ToString());
                    }
                }

                int GCD = GreatestCommonDivisor.gcd(res.Numerator, res.Denominator);

                if (GCD == 0 || res.Denominator == 0)
                {
                    txtbRes.Text = "Math ERROR";
                }
                else
                {
                    res.Numerator /= GCD;
                    res.Denominator /= GCD;

                    string num = res.Numerator.ToString();
                    string sep = "/";
                    string den = res.Denominator.ToString();

                    if (res.Denominator < 0)
                    {
                        res.Numerator *= -1;
                        res.Denominator *= -1;
                        num = res.Numerator.ToString();
                        den = res.Denominator.ToString();
                    }

                    if (res.Denominator == 1)
                    {
                        sep = den = "";
                    }

                    if (res.Numerator == res.Denominator)
                    {
                        den = sep = "";
                        num = "1";
                    }

                    if (res.Numerator == 0)
                    {
                        num = "0";
                        sep = den = "";
                    }

                    txtbRes.Text = num + sep + den;
                }
            }
        }
        
        private void TxbInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txbInput.Text = "";
            txbInput.FontStyle = FontStyles.Normal;
            txbInput.FontWeight = FontWeights.Bold;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            tokens = Fraction.CutString(txbInput);

            for (int i = 0; i < tokens.Length; ++i)
            {
                if (tokens[i][0] == ' ')
                {
                    tokens[i] = tokens[i].Remove(0, 1);
                }

                Fraction temp = Fraction.Parse(tokens[i]);

                if (temp.Denominator != 0)
                {
                    lsbSaveData.Items.Add(tokens[i]);
                }
            }

            lsbSaveData.Items.Refresh();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            lsbSaveData.Items.Clear();
            lsbSaveData.Items.Refresh();
        }
    }
}
