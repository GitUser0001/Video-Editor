using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace VideoEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool fullscreen = false;

        public MainWindow()
        {
            InitializeComponent();
            Settings.GetInstance();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.GetInstance().Dispose();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.mkv;*.avi;*.mp4)|*.mkv;*.avi;*.mp4|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonVideos);
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    listVideoNames.Items.Add(System.IO.Path.GetFileNameWithoutExtension(filename));
                    listVideoPaths.Items.Add(System.IO.Path.GetFullPath(filename));
                    listVideoNames.SelectedIndex = listVideoNames.SelectedIndex = openFileDialog.FileNames.Length - 1;
                    //media.Source = (String as System.Uri)System.IO.Path.GetFullPath(filename);
                }

                PlaySelectedVideo(listVideoNames,null);
                //MediaElement me = new MediaElement();
                //me.Source = new System.Uri(listVideoPaths.Items[0].ToString());
                //media.Source = new System.Uri(listVideoPaths.Items[0].ToString());
                //media.Play();
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
            media.Source = new Uri(listVideoPaths.Items[(sender as ListView).SelectedIndex].ToString());
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
