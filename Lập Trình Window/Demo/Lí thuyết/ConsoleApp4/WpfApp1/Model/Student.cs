using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Student: INotifyPropertyChanged
    {
        private string _avatar;
        private string _fullName;
        private int _credits;

        public string Fullname { get => _fullName; set => SetField(ref _fullName, value); }
        public string Avatar { get => _avatar; set => SetField(ref _avatar, value); }
        public int Credits { get => _credits; set => SetField(ref _credits, value); }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;

            field = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        
    }
}
