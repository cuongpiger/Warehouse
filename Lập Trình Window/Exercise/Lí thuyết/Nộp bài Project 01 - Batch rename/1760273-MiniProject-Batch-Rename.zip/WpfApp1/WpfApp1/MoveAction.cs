using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class MoveArgs : StringArgs, INotifyPropertyChanged
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

    public class MoveAction : StringAction
    {
        public string Name => "Move action";
        public StringProcessor Processor => _move;
        public StringArgs Args { get; set; }

        public StringAction Clone()
        {
            return new MoveAction()
            {
                Args = new MoveArgs()
            };
        }

        public void ShowEditDialog()
        {
            var screen = new Move_Dialog(Args as MoveArgs);

            if (screen.ShowDialog() == true)
            {
                var myArgs = Args as MoveArgs;
                myArgs.Choose = screen.choose;
                myArgs.Format = screen.format;
            }
        }

        private string _move(string origin)
        {
            var myArgs = Args as MoveArgs;
            var choose = myArgs.Choose;
            var format = myArgs.Format;
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

            bool check = true;
            string result = "";

            if (choose == 1)
            {
                if (origin.Length > 13)
                {
                    for (int i = 0; i < 13; ++i)
                    {
                        if ((origin[i] < '0' || origin[i] > '9') && origin[i] != '-')
                        {
                            check = false;
                            break;
                        }
                    }

                    if (check == true)
                    {
                        result += origin.Substring(14, origin.Length - 14);
                        result += " ";
                        result += origin.Substring(0, 13);

                        return result + type;
                    }
                }
            }
            else if (choose == 2)
            {
                if (origin.Length > 13)
                {
                    for (int i = origin.Length - 1; i > origin.Length - 14; --i)
                    {
                        if ((origin[i] < '0' || origin[i] > '9') && origin[i] != '-')
                        {
                            check = false;
                            break;
                        }
                    }

                    if (check == true)
                    {
                        result += origin.Substring(origin.Length - 13, 13);
                        result += " ";
                        result += origin.Substring(0, origin.Length - 14);

                        return result +  type;
                    }
                }
            }

            return origin + type;
        }
    }
}
