using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using Prism.Interactivity.InteractionRequest;

namespace MessageBoxService.Services
{
    public class MessageBoxService : IMessageBoxService
    {
        public MessageBoxService()
        {
        }

        public InteractionRequest<MessageContext> MessageRequest { get; } = new InteractionRequest<MessageContext>();

        public MessageBoxResult ShowInformation( string message )
        {
            return Show( "Information", message, MessageBoxButton.OK, MessageBoxImage.Information );
        }

        public MessageBoxResult ShowConfirmation( string message )
        {
            return Show( "Confirmation", message, MessageBoxButton.OKCancel, MessageBoxImage.Question );
        }

        public MessageBoxResult ShowWarning( string message )
        {
            return Show( "Warning", message, MessageBoxButton.OK, MessageBoxImage.Warning );
        }

        public MessageBoxResult ShowError( string message )
        {
            return Show( "Error", message, MessageBoxButton.OK, MessageBoxImage.Error );
        }

        public MessageBoxResult Show( string title, string message, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult = MessageBoxResult.None )
        {
            var result = defaultResult;
            Application.Current.Dispatcher.Invoke( () =>
            {
                MessageRequest.Raise(
                    new MessageContext
                    {
                        Title = title,
                        Message = message,
                        Button = button,
                        Icon = icon,
                        DefaultResult = defaultResult
                    },
                    ( c ) => result = c.Result );
            } );
            return result;
        }
    }
}
