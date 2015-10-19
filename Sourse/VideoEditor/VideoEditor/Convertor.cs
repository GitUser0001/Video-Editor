using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoEditor
{
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    public abstract class Convertor
    {
        private Convertor _successor = null;

        public Convertor Successor
        {
            get { return _successor; }
            set { _successor = value; }
        }

        public abstract void ProcessRequest(Object toConvert);
    }
}
