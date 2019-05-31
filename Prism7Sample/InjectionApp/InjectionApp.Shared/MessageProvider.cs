using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InjectionApp.Shared
{
    public class MessageProvider : IMessageProvider
    {
        public MessageProvider()
        {
            System.Diagnostics.Debug.Print( "MessageProvider.ctor" );

            ++_count;

            Message = $"{ DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss.fff") } : count={ _count }";
        }

        private static int _count = 0;

        public string Message { get; set; } = string.Empty;
    }
}
