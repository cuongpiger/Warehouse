using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    public class NewCaseArgs : StringArgs, INotifyPropertyChanged
    {
        private string _format;
        private int _choose;

        public string Format { get => _format; set { _format = value; NotifyChange("Format"); NotifyChange("Details"); } }
        public int Choose { get => _choose; set { _choose = value; NotifyChange("Choose"); NotifyChange("Details"); } }

        private void NotifyChange(string fileName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(fileName));
            }
        }

        public string Details => $"{Format}";
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class NewCaseAction : StringAction
    {
        public string Name => "New case action";
        public StringProcessor Processor => _newCase;
        public StringArgs Args { get; set; }

        public StringAction Clone()
        {
            return new NewCaseAction()
            {
                Args = new NewCaseArgs()
            };
        }

        public void ShowEditDialog()
        {
            var screen = new NewCase_Dialog(Args as NewCaseArgs);

            if (screen.ShowDialog() == true)
            {
                var myArgs = Args as NewCaseArgs;
                myArgs.Choose = screen.choose;
                myArgs.Format = screen.format;
            }
        }

        private string _newCase(string origin)
        {
            var myArgs = Args as NewCaseArgs;
            var choose = myArgs.Choose;
            var format = myArgs.Format;
            
            string result = "";

            if (choose == 1)
            {
                result = origin.ToUpper();
            }
            else if (choose == 2)
            {
                result = origin.ToLower();
            }
            else if (choose == 3)
            {
                string temp = origin.ToLower();
                result += char.ToUpper(temp[0]);
                
                for (int i = 1; i < temp.Length; ++i)
                {
                    if (temp[i - 1] == ' ')
                    {
                        result += char.ToUpper(temp[i]);
                    }
                    else
                    {
                        result += temp[i];
                    }
                }
            }
            else
            {
                result = origin;
            }

            return result;
        }
    }
}
