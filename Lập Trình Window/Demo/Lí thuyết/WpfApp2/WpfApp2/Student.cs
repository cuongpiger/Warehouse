using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Student: INotifyPropertyChanged
    {
        private string _id;
        private string _fullname;
        private string _avatar;
        private int _credits;

        public string ID { get => _id; set => SetField(ref _id, value); }
        public string Fullname { get => _fullname; set => SetField(ref _fullname, value); }
        public string Avatar { get => _avatar; set => SetField(ref _avatar, value); }
        public int Credits { get => _credits; set => SetField(ref _credits, value); }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            NotifyPropertyChanged(propertyName);
            return true;
        }
    }
}
