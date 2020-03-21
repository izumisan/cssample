using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoxSample.Components
{
    public class MessageBoxRequestArgs : EventArgs
    {
        public MessageBoxRequestArgs( MessageBoxContents contents, Action<MessageBoxContents> callback )
            : base()
        {
            Contents = contents;
            Callback = callback;
        }

        public MessageBoxContents Contents { get; }
        public Action<MessageBoxContents> Callback { get; }
    }
}
