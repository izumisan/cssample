using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBoxSample.Components
{
    public class MessageBoxRequest
    {
        public event EventHandler<MessageBoxRequestArgs> Raised;

        public MessageBoxRequest()
        {
        }

        public void Raise( MessageBoxContents contents, Action<MessageBoxContents> callback = null )
        {
            Raised?.Invoke( this, new MessageBoxRequestArgs( contents, callback ) );
        }
    }
}
