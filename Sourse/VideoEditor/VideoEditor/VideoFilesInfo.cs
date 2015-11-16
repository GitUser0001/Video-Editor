using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEditor
{
    public class VideoFilesInfo
    {
        private Dictionary<string, Uri> videoFilesDictionary = new Dictionary<string, Uri>();
        private MainWindow mainWindow;

        public VideoFilesInfo(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public void AddVideo(string path)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(path);
            string fileFullPath = System.IO.Path.GetFullPath(path);

            Uri fileUri = new Uri(fileFullPath);

            videoFilesDictionary.Add(fileName, fileUri);

            mainWindow.listVideoNames.Items.Add(fileName);

            //listVideoNames.Items.Add(fileName);
        }

        public Uri GetVideoUri(string videoName)
        {
            return videoFilesDictionary[videoName];
        }
    }
}
