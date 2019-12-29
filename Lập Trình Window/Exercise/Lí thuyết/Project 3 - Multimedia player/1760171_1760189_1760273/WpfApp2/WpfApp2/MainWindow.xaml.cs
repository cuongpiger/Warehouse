using System;
using System.Collections.Generic;
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
using Gma.System.MouseKeyHook;
using System.Windows.Threading;
using Microsoft.Win32;
using System.Xml;
using System.Windows.Forms;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaElement VideoPlayer = new MediaElement();
        private DispatcherTimer timer = new DispatcherTimer();
        private Microsoft.Win32.OpenFileDialog openFileDialog;
        private IKeyboardMouseEvents _hook;

        public MainWindow()
        {
            InitializeComponent();
            _hook = Hook.GlobalEvents();
            _hook.KeyUp += _hook_KeyUp;
        }

        public void subscribe()
        {
            _hook = Hook.GlobalEvents();
            _hook.KeyUp += _hook_KeyUp;
        }

        public void unsubscribe()
        {
            _hook.KeyUp -= _hook_KeyUp;
            _hook.Dispose();
        }
        private void _hook_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                if (!isPlaying)
                {
                    var image = new BitmapImage(
                        new Uri("Images/Pause4.png", UriKind.Relative)
                    );
                    Pause_PlayImage.Source = image;
                    isPlaying = true;
                    VideoPlayer.Play();
                }
                else
                {
                    var image = new BitmapImage(
                        new Uri("Images/Play4.png", UriKind.Relative)
                    );
                    Pause_PlayImage.Source = image;
                    isPlaying = false;
                    VideoPlayer.Pause();
                }
            }
            if (e.Control && e.KeyCode == Keys.Left && VideoPlayer != null && VideoPlayer.Source != null)
            {
                i--;
                if (i <= 0)
                    i = ListBoxPlaylist.Items.Count - 1;
                playAudio(ListBoxPlaylist.Items[i].ToString());
            }
            if(e.Control && e.KeyCode == Keys.Right && VideoPlayer != null && VideoPlayer.Source != null)
            {
                i++;
                if (i > ListBoxPlaylist.Items.Count - 1)
                    i = 1;
                playAudio(ListBoxPlaylist.Items[i].ToString());
            }
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Text file (*.txt)|*.txt|Xml file (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == true)
            {

                var reader = new XmlDocument();
                reader.Load(openFileDialog.FileName);

                var childs = reader.DocumentElement.ChildNodes;


                foreach (XmlNode child in childs)
                {
                    ListBoxPlaylist.Items.Add(child.Attributes["source"].Value);
                }

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (VideoPlayer.Source != null && VideoPlayer.NaturalDuration.HasTimeSpan && !userIsDraggingSlider)
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = VideoPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = VideoPlayer.Position.TotalSeconds;
            }
        }
        public void playAudio(string audioSource)
        {
            mainCanvas.Children.Remove(VideoPlayer);
            VideoPlayer = new MediaElement();
            VideoPlayer.Width = 350;
            VideoPlayer.Height = 350;
            VideoPlayer.LoadedBehavior = MediaState.Manual;
            mainCanvas.Children.Add(VideoPlayer);
            Canvas.SetTop(VideoPlayer, 50);
            Canvas.SetLeft(VideoPlayer, 50);

            VideoPlayer.Source = new Uri(audioSource);
            VideoPlayer.Play();
            VideoPlayer.MediaEnded += VideoPlayer_MediaEnded;

            timer.Start();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
        }

        bool canPlay = false;
        bool isPlaying = true;
        private void PlayAndPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isPlaying)
            {
                var image = new BitmapImage(
                    new Uri("Images/Pause4.png", UriKind.Relative)
                );
                Pause_PlayImage.Source = image;
                isPlaying = true;
                VideoPlayer.Play();
            }
            else
            {
                var image = new BitmapImage(
                  new Uri("Images/Play4.png", UriKind.Relative)
                );
                Pause_PlayImage.Source = image;
                isPlaying = false;
                VideoPlayer.Pause();
            }
        }


        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            if (canPlay == false)
            {
                return;
            }
            VideoPlayer.Stop();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Xml file (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == true)
            {
                //save
                var xmlDoc = new XmlDocument();
                XmlDeclaration xmlDeclaration = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                XmlElement root = xmlDoc.DocumentElement;
                xmlDoc.InsertBefore(xmlDeclaration, root);

                for (int i = 0; i < ListBoxPlaylist.Items.Count; i++)
                {
                    var newNode = xmlDoc.CreateNode("element", "entry", "");
                    ((XmlElement)newNode).SetAttribute("source", ListBoxPlaylist.Items[i].ToString());
                    if (i == 0)
                    {
                        xmlDoc.AppendChild((XmlElement)newNode);
                    }
                    else
                    {
                        xmlDoc.DocumentElement.AppendChild((XmlElement)newNode);
                        xmlDoc.Save(saveFileDialog.FileName);
                    }
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (canPlay == false)
            {
                return;
            }
            ListBoxPlaylist.Items.RemoveAt(ListBoxPlaylist.SelectedIndex);
            ListBoxPlaylist.Items.Refresh();
        }


        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "Mp3 file (*.mp3)|*.mp3|Mp4 file (*.mp4)|*.mp4";
            if (openFileDialog.ShowDialog() == true)
            {
                ListBoxPlaylist.Items.Add(openFileDialog.FileName);
                canPlay = true;
            }
        }

        int i = 1;
        int time = 0;
        private void VideoPlayer_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (IterateOnceTimeRadioButton.IsChecked == true)
            {
                if (PlaySequantiallyRadioButton.IsChecked == true && time != ListBoxPlaylist.Items.Count - 1)
                {
                    playAudio(ListBoxPlaylist.Items[i].ToString());
                    i++;
                    time++;
                }
                if (PlayRandomlyRadioButton.IsChecked == true && time != ListBoxPlaylist.Items.Count - 1)
                {
                    Random r = new Random();
                    i = r.Next(1, ListBoxPlaylist.Items.Count - 2);
                    playAudio(ListBoxPlaylist.Items[i].ToString());
                    time++;
                }
            }
            else if (InfiniteInteratingRadioButton.IsChecked == true)
            {
                if (time == ListBoxPlaylist.Items.Count - 1)
                {
                    i = 1; time = 0;
                }
                if (PlaySequantiallyRadioButton.IsChecked == true && time != ListBoxPlaylist.Items.Count - 1)
                {
                    playAudio(ListBoxPlaylist.Items[i].ToString());
                    i++;
                    time++;
                }
                if (PlayRandomlyRadioButton.IsChecked == true && time != ListBoxPlaylist.Items.Count - 1)
                {
                    Random r = new Random();
                    i = r.Next(1, ListBoxPlaylist.Items.Count - 2);
                    playAudio(ListBoxPlaylist.Items[i].ToString());
                    time++;
                }
            }
            else
            {
                if (PlaySequantiallyRadioButton.IsChecked == true)
                { 
                    i++;
                    playAudio(ListBoxPlaylist.Items[i].ToString());
                    time++;
                }
                else if (PlayRandomlyRadioButton.IsChecked == true)
                {
                    Random r = new Random();
                    i = r.Next(1, ListBoxPlaylist.Items.Count - 2);
                    playAudio(ListBoxPlaylist.Items[i].ToString());
                    time++;
                }
            }
        }



        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            
            var audio = ListBoxPlaylist.SelectedItem as string;

            i = ListBoxPlaylist.SelectedIndex;
            playAudio(audio);

            var image = new BitmapImage(
                    new Uri("Images/Pause4.png", UriKind.Relative)
                );
            Pause_PlayImage.Source = image;
            isPlaying = true;
            sliProgress.IsEnabled = true;
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            i = 1;
            time = 0;
            if (PlaySequantiallyRadioButton.IsChecked == true)
            {
                playAudio(ListBoxPlaylist.Items.GetItemAt(i).ToString());
                i++;
                time++;
            }
            else if (PlayRandomlyRadioButton.IsChecked == true)
            {
                Random r = new Random();
                i = r.Next(1, ListBoxPlaylist.Items.Count - 2);
                playAudio(ListBoxPlaylist.Items[i].ToString());
                time++;
            }
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblStatus.Content = String.Format("{0} / {1}", TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss"), VideoPlayer.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss"));
        }
        private bool userIsDraggingSlider;
       

        private void sliProgress_DragStarted(object sender, RoutedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void sliProgress_DragCompleted(object sender, RoutedEventArgs e)
        {
            userIsDraggingSlider = false;
            VideoPlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void mainCanvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            sliVolume.Value = VideoPlayer.Volume;
            if (e.Delta > 0)
                VideoPlayer.Volume += 0.1;
            else
                VideoPlayer.Volume += -0.1;
        }

        private void sliVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VideoPlayer.Volume = sliVolume.Value;
        }

        private void sliVolume_DragCompleted(object sender, RoutedEventArgs e)
        {
            VideoPlayer.Volume = sliVolume.Value;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            subscribe();
            sliVolume.Value = VideoPlayer.Volume;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            unsubscribe();
        }
    }
}
