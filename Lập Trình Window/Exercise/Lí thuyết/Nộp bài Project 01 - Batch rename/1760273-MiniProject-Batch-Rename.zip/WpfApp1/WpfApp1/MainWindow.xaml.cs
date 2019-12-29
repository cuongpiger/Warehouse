using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using MessageBox = System.Windows.Forms.MessageBox;
using System.ComponentModel;

namespace WpfApp1
{
    static class RemoveSpace
    {
        public static string RemoveAllSpaceAheadString(this string myStr)
        {
            if (myStr == null || myStr.Length == 0)
            {
                return myStr;
            }

            int i = 0;

            for (i = 0; i < myStr.Length; ++i)
            {
                if (myStr[i] != ' ')
                {
                    break;
                }
            }

            if (i != 0)
            {
                return myStr.Remove(0, i);
            }

            return myStr;
        }
    }

    static class AvoidSameName
    {
        public static void AvoidTwoFilesHaveSameName(ref string _a, ref string _b)
        {
            if (_a != null && _a.Length != 0 && _b != null && _b.Length != 0 && _a == _b)
            {
                int num_a = 0, num_b = 0;
                int startA = -1, endA = -1, startB = -1, endB = -1;
                bool successA = false, successB = false;

                startA = _a.LastIndexOf('(');
                endA = _a.LastIndexOf(')');
                startB = _b.LastIndexOf('(');
                endB = _b.LastIndexOf(')');

                if (startA != -1 && endA != -1 && endA > startA && _a[endA + 1] == '.')
                {
                    successA = Int32.TryParse(_a.Substring(startA + 1, endA - startA - 1), out num_a);
                }

                if (startB != -1 && endB != -1 && endB > startB && _b[endB + 1] == '.')
                {
                    successB = Int32.TryParse(_b.Substring(startB + 1, endB - startB - 1), out num_b);
                }

                if (successA == false && successB == false)
                {
                    num_a = 1;
                    string inser = '(' + num_a.ToString() + ')';
                    _a = _a.Insert(_a.LastIndexOf('.'), inser);
                }
                else
                {
                    num_a++;
                    _a = _a.Remove(startA + 1, endA - startA - 1);
                    _a = _a.Insert(startA + 1, num_a.ToString());
                }
            }
        }

        public static void AvoidTwoFoldersHaveSameName(ref string _a, ref string _b)
        {
            if (_a != null && _a.Length != 0 && _b != null && _b.Length != 0 && _a == _b)
            {
                int num_a = 0, num_b = 0;
                int startA = -1, endA = -1, startB = -1, endB = -1;
                bool successA = false, successB = false;

                startA = _a.LastIndexOf('(');
                endA = _a.LastIndexOf(')');
                startB = _b.LastIndexOf('(');
                endB = _b.LastIndexOf(')');

                if (startA != -1 && endA != -1 && endA > startA && endA - 1 == _a.Length)
                {
                    successA = Int32.TryParse(_a.Substring(startA + 1, endA - startA - 1), out num_a);
                }

                if (startB != -1 && endB != -1 && endB > startB && endB - 1 == _b.Length)
                {
                    successB = Int32.TryParse(_b.Substring(startB + 1, endB - startB - 1), out num_b);
                }

                if (successA == false && successB == false)
                {
                    num_a = 1;
                    string inser = '(' + num_a.ToString() + ')';
                    _a = _a + inser;
                }
                else
                {
                    num_a++;
                    _a = _a.Remove(startA + 1, endA - startA - 1);
                    _a = _a.Insert(startA + 1, num_a.ToString());
                }
            }
        }

        public static string GetTypeFile(string _a)
        {
            int endDot = _a.LastIndexOf('.');
            return _a.Substring(endDot, _a.Length - endDot);
        }
    }

    public partial class MainWindow : Window
    {
        public List<string> mfName { get; set; }

        private int BeChecked()
        {
            if (replaceRadioButton.IsChecked == true)
            {
                return 0;
            }

            if (newCaseRadioButton.IsChecked == true)
            {
                return 1;
            }

            if (nameRadioButton.IsChecked == true)
            {
                return 2;
            }

            if (moveRadioButton.IsChecked == true)
            {
                return 3;
            }

            return 4;
        }
        public List<FileExtension> myFiles { get; set; }
        public List<FileExtension> myFolders { get; set; }
        public string[] files;
        public string[] folders;
        public string path;

        public MainWindow()
        {
            InitializeComponent();

            mfName = new List<string>();
        }

        private void LoadFolders_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            path = dialog.SelectedPath;

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                folders = Directory.GetDirectories(dialog.SelectedPath);
            }
            else
            {
                return;
            }

            if (myFolders == null)
                myFolders = new List<FileExtension>();

            foreach (var item in folders)
            {
                FileExtension temp = new FileExtension();
                temp.fileName = item;
                temp.ConvertFile();
                myFolders.Add(temp);
            }

            DataContext = this;
            foldersListView.Items.Refresh();

            if (myFolders != null || myFolders.Count != 0)
            {
                changeListFolderButton.IsEnabled = true;
            }
        }

        private void LoadFiles_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            path = dialog.SelectedPath;

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                files = Directory.GetFiles(dialog.SelectedPath);
            }
            else
            {
                return;
            }

            if (myFiles == null)
                myFiles = new List<FileExtension>();

            foreach (var item in files)
            {
                FileExtension temp = new FileExtension();
                temp.fileName = item;
                temp.ConvertFile();
                myFiles.Add(temp);
            }

            DataContext = this;
            filesListView.Items.Refresh();

            if (myFiles != null || myFiles.Count != 0)
            {
                changeListFileButton.IsEnabled = true;
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.BeChecked() == 0)
            {
                var instane = new ReplaceAction();
                actionListBox.Items.Add(instane.Clone());
            }
            else if (this.BeChecked() == 1)
            {
                var instane = new NewCaseAction();
                actionListBox.Items.Add(instane.Clone());
            }
            else if (this.BeChecked() == 2)
            {
                var instane = new FullnameAction();
                actionListBox.Items.Add(instane.Clone());
            }
            else if (this.BeChecked() == 3)
            {
                var instane = new MoveAction();
                actionListBox.Items.Add(instane.Clone());
            }
            else
            {
                var instane = new UniqueNameAction();
                actionListBox.Items.Add(instane.Clone());
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var action = actionListBox.SelectedItem as StringAction;
            action.ShowEditDialog();
        }

        private void BatchRenameFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (myFiles == null)
            {
                return;
            }

            string filepreview = "";
            changeListFileButton.IsEnabled = true;
            cancelListFileButton.IsEnabled = true;

            for (int i = 0; i < myFiles.Count; ++i)
            {
                if (myFiles[i].filePreview == null || myFiles[i].filePreview == "")
                {
                    filepreview = myFiles[i].fileName;
                }
                else
                {
                    filepreview = myFiles[i].filePreview;
                }

                foreach (StringAction action in actionListBox.Items)
                {
                    filepreview = action.Processor.Invoke(filepreview);
                }

                filepreview = filepreview.RemoveAllSpaceAheadString();

                for (int j = 0; j < i; ++j)
                {
                    string filePriviewJ = myFiles[j].filePreview;
                    AvoidSameName.AvoidTwoFilesHaveSameName(ref filepreview, ref filePriviewJ);
                }

                myFiles[i].filePreview = filepreview;
                filesListView.Items.Refresh();
            }
        }

        private void BatchRenameFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (myFolders == null)
            {
                return;
            }

            string filepreview = "";
            changeListFolderButton.IsEnabled = true;
            cancelListFolderButton.IsEnabled = true;

            for (int i = 0; i < myFolders.Count; ++i)
            {
                if (myFolders[i].filePreview == null || myFolders[i].filePreview == "")
                {
                    filepreview = myFolders[i].fileName;
                }
                else
                {
                    filepreview = myFolders[i].filePreview;
                }

                foreach (StringAction action in actionListBox.Items)
                {
                    filepreview = action.Processor.Invoke(filepreview);
                }

                filepreview = filepreview.RemoveAllSpaceAheadString();

                for (int j = 0; j < i; --j)
                {
                    string filePriviewJ = myFolders[j].filePreview;
                    AvoidSameName.AvoidTwoFoldersHaveSameName(ref filepreview, ref filePriviewJ);
                }

                myFolders[i].filePreview = filepreview;
                foldersListView.Items.Refresh();
            }
        }

        private void ClearListFile_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure that you want to delete all?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                myFiles.Clear();
                filesListView.Items.Refresh();
            }
        }

        private void ChangeListFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (myFiles == null)
            {
                return;
            }

            DialogResult res = MessageBox.Show("Are you sure that you want to change all?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            for (int i = 0; i < myFiles.Count; ++i)
            {
                string filename = myFiles[i].fileName;
                string filepath = myFiles[i].filePath;
                string filepreview = Guid.NewGuid().ToString() + AvoidSameName.GetTypeFile(filename);

                var file = new FileInfo(filepath + filename);
                file.MoveTo(filepath + filepreview);
                myFiles[i].fileName = filepreview;
            }

            for (int i = 0; i < myFiles.Count; ++i)
            {
                string filename = myFiles[i].fileName;
                string filepath = myFiles[i].filePath;
                string filepreview = myFiles[i].filePreview;

                if (filepreview == null || filepreview == "")
                {
                    continue;
                }

                var file = new FileInfo(filepath + filename);
                file.MoveTo(filepath + filepreview);
                myFiles[i].fileName = filepreview;
                myFiles[i].filePreview = "";
                filesListView.Items.Refresh();
            }



            changeListFileButton.IsEnabled = false;
            cancelListFileButton.IsEnabled = false;
        }

        private void ClearListFolderButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure that you want to delete all?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                myFolders.Clear();
                foldersListView.Items.Refresh();
            }
        }

        private void ChangeListFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (myFolders == null)
            {
                return;
            }

            DialogResult res = MessageBox.Show("Are you sure that you want to change all?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.No)
            {
                return;
            }

            for (int i = 0; i < myFolders.Count; ++i)
            {
                string filename = myFolders[i].fileName;
                string filepath = myFolders[i].filePath;
                string filepreview = Guid.NewGuid().ToString();

                var file = new FileInfo(filepath + filename);
                file.MoveTo(filepath + filepreview);
                myFolders[i].fileName = filepreview;
            }

            for (int i = 0; i < myFolders.Count; ++i)
            {
                string filename = myFolders[i].fileName;
                string filepath = myFolders[i].filePath;
                string filepreview = myFolders[i].filePreview;

                if (filepreview == null || filepreview == "")
                {
                    continue;
                }

                var file = new FileInfo(filepath + filename);
                file.MoveTo(filepath + filepreview);
                myFolders[i].fileName = filepreview;
                myFolders[i].filePreview = "";
                foldersListView.Items.Refresh();
            }

            changeListFolderButton.IsEnabled = false;
            cancelListFolderButton.IsEnabled = false;
        }

        private void ClearActionListButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure that you want to delete all?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                actionListBox.Items.Clear();
                actionListBox.Items.Refresh();
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure that you want to delete this action?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                actionListBox.Items.RemoveAt(actionListBox.SelectedIndex);
                actionListBox.Items.Refresh();
            }
        }

        private void ClearFavorite_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure that you want to delete all?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                myFavoriteComboBox.Items.Clear();
                myFavoriteComboBox.Items.Refresh();
            }
        }

        private void CancelListFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (myFiles == null)
            {
                return;
            }

            for (int i = 0; i < myFiles.Count; ++i)
            {
                myFiles[i].filePreview = "";
                filesListView.Items.Refresh();
            }

            changeListFileButton.IsEnabled = false;
            cancelListFileButton.IsEnabled = false;
        }

        private void CancelListFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (myFolders == null)
            {
                return;
            }

            for (int i = 0; i < myFolders.Count; ++i)
            {
                myFolders[i].filePreview = "";
                foldersListView.Items.Refresh();
            }

            changeListFolderButton.IsEnabled = false;
            cancelListFolderButton.IsEnabled = false;
        }

        private void AddFavorite_Click(object sender, RoutedEventArgs e)
        {
            var favouriteDialog = new MyFavourite_Dialog(mfName);
            favouriteDialog.ShowDialog();
            FavouriteAction mf = favouriteDialog._preset;
            myFavoriteComboBox.Items.Add(mf);
            mfName = favouriteDialog.dialogName;
        }

        private void ChooseFavorite_Click(object sender, RoutedEventArgs e)
        {
            var prototype = myFavoriteComboBox.SelectedItem as FavouriteAction;

            for (int i = 0; i < prototype.preset.Count; ++i)
            {
                var instance = prototype.preset[i];
                actionListBox.Items.Add(instance);
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            if (myFavoriteComboBox.SelectedIndex == -1) return;

            DialogResult res = MessageBox.Show("Are you sure that you want to delete this selected action?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes && myFavoriteComboBox.SelectedIndex != -1)
            {
                myFavoriteComboBox.Items.RemoveAt(myFavoriteComboBox.SelectedIndex);
                myFavoriteComboBox.Items.Refresh();
            }
        }
    }
}
