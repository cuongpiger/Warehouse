using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2
{
    public static class WindowExtension
    {
        public static void Error(this Window window,
            string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}
