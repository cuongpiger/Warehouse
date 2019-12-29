using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ImportData
{
    class RelativeToAbsolutePathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
            // Remove the last /
            var baseFolder = currentFolder.Substring(0, currentFolder.Length - 1);

            var filename = value as string;
            return $"{baseFolder}\\Images\\{filename}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
