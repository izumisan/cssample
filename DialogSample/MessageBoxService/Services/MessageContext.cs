using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using Prism.Interactivity.InteractionRequest;

namespace MessageBoxService.Services
{
    public class MessageContext : INotification
    {
        public string Title { get; set; } = string.Empty;

        object INotification.Content
        {
            get { return Message; }
            set { Message = value as string; }
        }

        public string Message { get; set; } = string.Empty;

        public MessageBoxButton Button { get; set; } = MessageBoxButton.OK;

        public MessageBoxImage Icon { get; set; } = MessageBoxImage.None;

        public MessageBoxResult DefaultResult { get; set; } = MessageBoxResult.None;

        public MessageBoxResult Result { get; set; } = MessageBoxResult.None;
    }
}
