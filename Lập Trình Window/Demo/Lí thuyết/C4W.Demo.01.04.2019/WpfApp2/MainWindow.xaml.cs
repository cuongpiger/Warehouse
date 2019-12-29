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

namespace WpfApp2
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

        private void FindNextDateButton_Click(object sender, RoutedEventArgs e)
        {
            if (canFindNextDate())
            {
                findNextDate();
            }
        }

        private bool canFindNextDate()
        {
            bool isOkay = true;

            if (dateTextBox.IsEmpty())
            {
                isOkay = false;
                this.Error("Không thể bỏ trống textbox nhập ngày");
                dateTextBox.Focus();
            } else
            {
                string dateValue = dateTextBox.Text;
                if (dateValue.Length != 10)
                {
                    isOkay = false;
                    this.Error("Độ dài của chuỗi ngày không đủ");
                } else
                {
                    string[] tokens = dateValue.Split(new string[]
                    {
                        "/"
                    }, StringSplitOptions.None);

                    if (tokens.Length != 3)
                    {
                        isOkay = false;
                        this.Error("Định dạng ngày tháng không đủ 3 phần");
                    } else
                    {
                        int day = 0;
                        int month = 0;
                        int year = 0;

                        if (tokens[0].StartsWith("0")) {
                            tokens[0] = tokens[0].Substring(1, 1);
                        }
                        if (tokens[1].StartsWith("0"))
                        {
                            tokens[1] = tokens[1].Substring(1, 1);
                        }

                        if (int.TryParse(tokens[0], out day) == false) {
                            isOkay = false;
                            this.Error("Ngày không phải là số");
                        }

                        if (int.TryParse(tokens[1], out month) == false)
                        {
                            isOkay = false;
                            this.Error("Tháng không phải là số");
                        }

                        if (int.TryParse(tokens[2], out year) == false)
                        {
                            isOkay = false;
                            this.Error("Năm không phải là số");
                        }

                        if (isOkay)
                        {
                            int[] maxDays = {0, 31, 28, 31, 30, 31, 30, 31,
                                31, 30, 31, 30, 31};

                            if ( ! (1 <= day && day <= maxDays[month]))
                            {
                                isOkay = false;
                                this.Error("Ngày không hợp lệ");
                            }
                        }
                    }
                }
            }
                

            return isOkay;
        }

        private void findNextDate()
        {
            var date = dateTextBox.DateValue();
            dateListBox.Items.Add(date.ToString("dd/MM/yyyy"));
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            if (dateListBox.SelectedIndex < 0)
            {
                this.Error("Bạn chưa chọn item nào!");
            } else
            {
                dateListBox.Items.RemoveAt(dateListBox.SelectedIndex);
            }
        }
    }
}
