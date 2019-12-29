using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp2
{
    public static class TextBoxExtension
    {
        public static bool IsEmpty(this TextBox control)
        {
            return control.Text.IsEmpty();
        }

        public static DateTime DateValue(this TextBox control)
        {
            

            string[] tokens = control.Text.Split(new string[]
            {
                "/"
            }, StringSplitOptions.None);

            var day = int.Parse(tokens[0]);
            var month = int.Parse(tokens[1]);
            var year = int.Parse(tokens[2]);

            DateTime result = new DateTime(year, month, day);

            return result;
        }
    }
}
