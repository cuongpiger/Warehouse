using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;

namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private IKeyboardMouseEvents _hook;

        public void Subscribe()
        {
            _hook = Hook.GlobalEvents();

            _hook.KeyUp += _hook_KeyUp;
        }

        private void _hook_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            Debug.WriteLine("Hello");

            if (e.Control && e.Shift && (e.KeyCode == Keys.E))
            {
                System.Windows.MessageBox.Show("Combination shortcut key pressed");
            }
        }

        public void Unsubscribe()
        {
            _hook.KeyUp -= _hook_KeyUp;
            _hook.Dispose();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Subscribe();
        }

        MediaPlayer _player = new MediaPlayer();
        DispatcherTimer _timer = new DispatcherTimer();
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            //var screen = new OpenFileDialog();
            //if (screen.ShowDialog() == true)
            //{
                //var filename = screen.FileName;
                //videoPlayer.Source = new Uri(filename);

                //_timer.Interval = TimeSpan.FromSeconds(1);
                //_timer.Tick += timer_Tick;

                //var doc = new XmlDocument();
                //doc.Load(filename);

                //Debug.WriteLine(doc.DocumentElement.Name);
                //var childs = doc.DocumentElement.ChildNodes;

                //foreach(XmlNode child in childs)
                //{
                //    Debug.WriteLine(child.Name);
                //    Debug.WriteLine(child.Attributes["source"].Value);
                //}
                //doc.DocumentElement.RemoveChild(childs[1]);

                //var newNode = doc.CreateNode("element", "entry", "");
                //((XmlElement)newNode)
                //    .SetAttribute("source", "C:\\SonTung-ChayNgayDi.mp3");

                //doc.DocumentElement.AppendChild(newNode);


                //doc.Save(filename);


        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (videoPlayer.NaturalDuration.HasTimeSpan)
                Title = String.Format("{0} / {1}", 
                    videoPlayer.Position.ToString(@"mm\:ss"),
                    videoPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            videoPlayer.Play();
            _timer.Start();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            _player.Pause();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
