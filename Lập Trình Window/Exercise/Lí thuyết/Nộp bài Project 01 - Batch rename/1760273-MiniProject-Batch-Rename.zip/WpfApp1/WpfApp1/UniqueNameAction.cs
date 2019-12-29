using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class UniqueNameArgs : StringArgs, INotifyPropertyChanged
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

    public class UniqueNameAction : StringAction
    {
        public string Name => "Unique name action";
        public StringProcessor Processor => _uniqueName;

        public StringArgs Args { get; set; }
        public StringAction Clone()
        {
            return new UniqueNameAction()
            {
                Args = new UniqueNameArgs()
            };
        }
        public void ShowEditDialog()
        {
        }

        private string _uniqueName(string origin)
        {
            Guid g = Guid.NewGuid();
            string type = "";

            for (int i = origin.Length - 1; i >= 0; --i)
            {
                if (origin[i] == '.')
                {
                    type = origin.Substring(i, origin.Length - i);
                    origin = origin.Substring(0, i);
                    break;
                }
            }

            return (g.ToString() + type);
        }
    }
}
