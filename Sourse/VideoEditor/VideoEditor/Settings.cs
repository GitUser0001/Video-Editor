using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace VideoEditor
{
    [DataContract]
    public class Settings : IDisposable
    {
        private static readonly object _lock = new object();
        private static Settings _instance;
        private bool _disposed = false;
        //private int _fontSize;
        private FormatVideo _formatVideo;

        private Settings()
        {
        }

        ~Settings()
        {
            Dispose(false);
        }

        public int FontSize { get; set; }

        public FormatAudio FormatAudio { get; set; }

        public FormatVideo FormatVideo
        {
            get { return _formatVideo; }
            set { _formatVideo = value; }
        }

        public static Settings GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Settings();

                        if (File.Exists(@"settings.xml"))
                        {
                            using (var sr = new StreamReader(@"settings.xml"))
                            {
                                XmlSerializer xs = new XmlSerializer(typeof(Settings));
                                _instance = (Settings)xs.Deserialize(sr);
                            }
                        }
                    }
                }
            }

            return _instance;
        }

        // Dispose() calls Dispose(true)
        public void Dispose()
        {
            // lock dispose?
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    using (var tw = new StreamWriter(@"settings.xml"))
                    {
                        XmlSerializer xs = new XmlSerializer(typeof(Settings));
                        xs.Serialize(tw, this);
                    }

                    FontSize = 0;
                }

                // Indicate that the instance has been disposed.
                _disposed = true;
            }
        }
    }
}
