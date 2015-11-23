using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace VideoEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool fullscreen = false;
        private VideoFilesInfo videoFiles;
// motion jpeg
        public MainWindow()
        {
            InitializeComponent();
            Settings.GetInstance();
            videoFiles = new VideoFilesInfo(this);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.GetInstance().Dispose();
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.mkv;*.avi;*.mp4)|*.mkv;*.avi;*.mp4|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    //string fileName = System.IO.Path.GetFileNameWithoutExtension(file);
                    //listVideoNames.Items.Add(fileName);
                    videoFiles.AddVideo(System.IO.Path.GetFullPath(file));
                }
            }
        }

        private void CmdPlay(object sender, RoutedEventArgs e)
        {
            media.Play();
        }

        private void CmdPause(object sender, RoutedEventArgs e)
        {
            media.Pause();
        }

        private void CmdStop(object sender, RoutedEventArgs e)
        {
            media.Stop();
        }

        private void PlaySelectedVideo(object sender, MouseButtonEventArgs e)
        {
            string videoName = (sender as ListView).SelectedItem.ToString();
            media.Source = videoFiles.GetVideoUri(videoName);
            media.Play();
        }

        private void MediaOpened(object sender, System.Windows.RoutedEventArgs e)
        {
            sliProgress.Maximum = (int)media.NaturalDuration.TimeSpan.TotalSeconds;
        }

        private void SliProgressDragCompleted(object sender, DragCompletedEventArgs e)
        {
            media.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }

        private void SliProgressValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            txtProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }

        private void CmdSetFullScreen(object sender, RoutedEventArgs e)
        {
            if (!fullscreen)
            {
                //DependencyObject obj = LogicalTreeHelper.FindLogicalNode(this);
                //((FrameworkElement)obj). = Visibility.Collapsed;
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
            }

            fullscreen = !fullscreen;
        }
    }
}
