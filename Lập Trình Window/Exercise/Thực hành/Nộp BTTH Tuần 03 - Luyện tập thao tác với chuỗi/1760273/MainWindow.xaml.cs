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
                int num = 0, den = 1;
                bool check = true;

                check = int.TryParse(tokens[0], out num) && int.TryParse(tokens[1], out den);
                
                if (!check)
                {
                    MessageBox.Show("Your string contains invalid characters or empty!", "Alert", MessageBoxButton.OK, MessageBoxImage.Error);
                    num = 0;
                    den = 1;
                }

                return new Fraction(num, den);
            }

            public static string[] CutString(TextBox datatxb)
            {
                var tokens = datatxb.Text.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                return tokens;
            }

            public static Fraction operator+(Fraction a, Fraction b)
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
        string answer = "";
        Fraction res = new Fraction(0, 1);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCalc_Click(object sender, RoutedEventArgs e)
        {
            txtbRes.Text = answer;
            
        }

        private void BtnPlus_Click(object sender, RoutedEventArgs e)
        {
            tokens = Fraction.CutString(txbInput);
            res = Fraction.Parse(tokens[0]);
            
            for (int i = 1; i < tokens.Length; ++i)
            {
                res = res + Fraction.Parse(tokens[i]);
            }

            int GCD = GreatestCommonDivisor.gcd(res.Numerator, res.Denominator);

            if (GCD == 0 || res.Denominator == 0)
            {
                answer = "Math ERROR";
            }
            else
            {
                res.Numerator /= GCD;
                res.Denominator /= GCD;
                answer = res.ToString();
            }
        }

        private void BtnExcept_Click(object sender, RoutedEventArgs e)
        {
            tokens = Fraction.CutString(txbInput);
            res = Fraction.Parse(tokens[0]);

            for (int i = 1; i < tokens.Length; ++i)
            {
                res = res - Fraction.Parse(tokens[i]);
            }

            int GCD = GreatestCommonDivisor.gcd(res.Numerator, res.Denominator);

            if (GCD == 0 || res.Denominator == 0)
            {
                answer = "Math ERROR";
            }
            else
            {
                res.Numerator /= GCD;
                res.Denominator /= GCD;
                answer = res.ToString();
            }
        }

        private void BtnMulti_Click(object sender, RoutedEventArgs e)
        {
            tokens = Fraction.CutString(txbInput);
            res = Fraction.Parse(tokens[0]);

            for (int i = 1; i < tokens.Length; ++i)
            {
                res = res * Fraction.Parse(tokens[i]);
            }

            int GCD = GreatestCommonDivisor.gcd(res.Numerator, res.Denominator);

            if (GCD == 0 || res.Denominator == 0)
            {
                answer = "Math ERROR";
            }
            else
            {
                res.Numerator /= GCD;
                res.Denominator /= GCD;
                answer = res.ToString();
            }
        }

        private void BtnDevide_Click(object sender, RoutedEventArgs e)
        {
            tokens = Fraction.CutString(txbInput);
            res = Fraction.Parse(tokens[0]);

            for (int i = 1; i < tokens.Length; ++i)
            {
                res = res / Fraction.Parse(tokens[i]);
            }

            int GCD = GreatestCommonDivisor.gcd(res.Numerator, res.Denominator);

            if (GCD == 0 || res.Denominator == 0)
            {
                answer = "Math ERROR";
            }
            else
            {
                res.Numerator /= GCD;
                res.Denominator /= GCD;
                answer = res.ToString();
            }
        }

        private void TxbInput_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            txbInput.Text = "";
            txbInput.FontStyle = FontStyles.Normal;
            txbInput.FontWeight = FontWeights.Bold;
        }
    }
}
