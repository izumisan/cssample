using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;

namespace MessageBoxSample.Components
{
    public class MessageBoxContents
    {
        public string Title { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public MessageBoxImage Image { get; set; } = MessageBoxImage.None;
        public MessageBoxButton Button { get; set; } = MessageBoxButton.OK;
        public MessageBoxResult Result { get; set; } = MessageBoxResult.None;
    }
}
