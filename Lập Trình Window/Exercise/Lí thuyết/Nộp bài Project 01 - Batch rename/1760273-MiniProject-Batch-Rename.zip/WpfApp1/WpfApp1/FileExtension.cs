using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class FileExtension : INotifyPropertyChanged
    {
        public string fileName { get; set; }
        public string filePath { get; set; }
        public string filePreview { get; set; }

        public string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                NotifyChange("FileName");
            }
        }

        public string FilePath
        {
            get => filePath;
            set
            {
                filePath = value;
                NotifyChange("FilePath");
            }
        }

        public string FilePreview
        {
            get => FilePreview;
            set
            {
                FilePreview = value;
                NotifyChange("FilePreview");
            }
        }

        public void ConvertFile()
        {
            string[] split = fileName.Split(new Char[] { '\\' });

            fileName = split[split.Length - 1];
            filePath = "";
            filePreview = "";

            for (int i = 0; i < split.Length - 1; ++i)
            {
                filePath += (split[i] + '\\');
            }
        }

        private void NotifyChange(string newName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(newName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
