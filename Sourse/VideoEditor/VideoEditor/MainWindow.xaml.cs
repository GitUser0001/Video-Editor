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
        public MainWindow()
        {
            InitializeComponent();
            Settings.GetInstance();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.GetInstance().Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //int f = Settings.GetInstance().FontSize;
            //MessageBox.Show(String.Format("{0}", f));
            //Convertor mp4 = new MP4();
            //Convertor mp3 = new MP3();

            //mp4.Successor = mp3;
        }
    }
}
