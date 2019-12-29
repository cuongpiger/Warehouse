using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageBox = System.Windows.Forms.MessageBox;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MyFavourite_Dialog.xaml
    /// </summary>
    public partial class MyFavourite_Dialog : Window
    {
        public FavouriteAction _preset { get; set; }
        public List<string> dialogName { get; set; }

        public MyFavourite_Dialog(List<string> mfName)
        {
            InitializeComponent();
            dialogName = mfName;
        }

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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dialogName.Count; ++i)
            {
                if (dialogName[i] == presetNameTextBox.Text.ToString())
                {
                    DialogResult res = MessageBox.Show("This name already exists in your My Favorite!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (res == System.Windows.Forms.DialogResult.Yes)
                    {
                        presetNameTextBox.Text = "";
                        presetNameTextBox.Focus();
                        return;
                    }
                }
            }
            FavouriteAction temp = new FavouriteAction();
            temp.namePreset = presetNameTextBox.Text.ToString();
            temp.preset = new List<StringAction>();
            dialogName.Add(presetNameTextBox.Text);

            foreach (StringAction action in actionListBox.Items)
            {
                temp.preset.Add(action);
            }

            if (presetNameTextBox.Text != "")
            {
                _preset = temp;
                this.Close();
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var action = actionListBox.SelectedItem as StringAction;
            action.ShowEditDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure that you want to delete this action?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == System.Windows.Forms.DialogResult.Yes)
            {
                actionListBox.Items.RemoveAt(actionListBox.SelectedIndex);
                actionListBox.Items.Refresh();
            }
        }

        private void AddActionButton_Click(object sender, RoutedEventArgs e)
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
    }
}
