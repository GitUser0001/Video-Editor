using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEditor
{
    public class MP4 : Convertor
    {
        public override void ProcessRequest(Object toConvert)
        {
            if (Settings.GetInstance().FormatVideo == FormatVideo.MPFour)
            {
                Convert(toConvert);
            }
            else if (Successor != null)
            {
                Successor.ProcessRequest(toConvert);
            }
        }

        private static void Convert(Object obj)
        {
            // method to convert File, or Object
            obj.ToString();
        }
    }
}
