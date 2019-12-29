using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class FullnameArgs : StringArgs, INotifyPropertyChanged
    {
        private string _displayScreen;

        public string DisplayScreen
        {
            get => _displayScreen;
            set
            {
                _displayScreen = value;
                NotifyChange("DisplayScreen");
                NotifyChange("Details");
            }
        }

        private void NotifyChange(string fileName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(fileName));
            }
        }

        public string Details => $"{DisplayScreen}";
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public class FullnameAction : StringAction
    {
        public string Name => "Fullname normalize action";
        public StringProcessor Processor => _fullname;

        public StringArgs Args { get; set; }

        public StringAction Clone()
        {
            return new FullnameAction()
            {
                Args = new FullnameArgs()
            };
        }

        public void ShowEditDialog()
        {
        }

        private string _fullname(string origin)
        {
            string result = "";
            string[] split = origin.ToLower().Split(new char[] { ' ' });
            string temp = split[0];

            for (int i = 1; i < split.Length; ++i)
            {
                if (split[i] == "")
                {
                    continue;
                }
                temp += ' ';
                temp += split[i];
            }

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

            return result;
        }
    }
}
