using Aspose.Cells;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImportData
{
    //class Product
    //{
    //    public string SKU { get; set; }
    //    public string Name { get; set; }
    //    public int Price { get; set; }
    //    public string ImagePath { get; set; }
    //}

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        List<Product> _list = null;

        private void ImportButton_Click(object sender, RoutedEventArgs e)
        {
            var db = new HisoEntities();

            _list = new List<Product>();

            string currentFolder = AppDomain.CurrentDomain.BaseDirectory;
            // Remove the last /
            var baseFolder = currentFolder.Substring(0, currentFolder.Length - 1);
            ////string filename = currentFolder + "Images/avatar1.jpg";

            ////avatarImage.Source = new BitmapImage(
            ////               new Uri(filename, UriKind.Absolute));

            ////Debug.WriteLine(currentFolder);

            //var folder = new DirectoryInfo(
            //    @"C:\Users\test\Desktop\avatars");
            //var files = folder.EnumerateFiles();

            //foreach(var file in files)
            //{
            //    file.CopyTo(baseFolder +
            //        $"\\Images\\{Guid.NewGuid()}.{file.Extension}");
            //}

            //MessageBox.Show("Done, all files copied");

            var screen = new OpenFileDialog();

            if (screen.ShowDialog() == true)
            {
                var filename = screen.FileName;

                var info = new FileInfo(filename);
                var folder = info.Directory;

                var workbook = new Workbook(filename);
                var sheet = workbook.Worksheets[0];

                var column = 'B';
                var row = 5;

                var cell = sheet.Cells[$"{column}{row}"];

                while (cell.Value != null)
                {
                    var sku = sheet.Cells[$"B{row}"].StringValue;
                    var name = sheet.Cells[$"C{row}"].StringValue;
                    var price = sheet.Cells[$"D{row}"].StringValue;
                    var imagePath = sheet.Cells[$"E{row}"].StringValue;
                    imagePath = folder + @"\img\"+imagePath;
                    var imgInfo = new FileInfo(imagePath);

                    var newName = Guid.NewGuid() 
                        + "." + imgInfo.Extension;

                    imgInfo.CopyTo(baseFolder + @"\Images\" + 
                        newName);

                    Debug.WriteLine($"{sku} - {name} - {price} - {imagePath}");

                    var product = new Product()
                    {
                        SKU = sku,
                        Name = name,
                        Price = int.Parse(price),
                        ImagePath = newName
                    };
                    db.Products.Add(product);
                    //_list.Add(product);

                    row++;
                    cell = sheet.Cells[$"{column}{row}"];
                }
                MessageBox.Show("Done, all products have been imported");

                //productListView.ItemsSource = _list;
                db.SaveChanges();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var db = new HisoEntities();
            productListView.ItemsSource = db.Products.ToList();
        }
    }
}
