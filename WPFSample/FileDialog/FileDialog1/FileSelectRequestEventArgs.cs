using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDialog1
{
    public class FileSelectRequestEventArgs : EventArgs
    {
        public string Title { get; set; } = string.Empty;
        public Action<string> Callback { get; set; } = null;
    }
}
