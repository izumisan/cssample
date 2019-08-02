using System.Windows;
using Prism.Interactivity.InteractionRequest;

namespace MessageBoxService.Services
{
    public interface IMessageBoxService
    {
        InteractionRequest<MessageContext> MessageRquest { get; }
        
        MessageBoxResult ShowInformation( string message );
        MessageBoxResult ShowConfirmation( string message );
        MessageBoxResult ShowWarning( string message );
        MessageBoxResult ShowError( string message );

        MessageBoxResult Show( string title, string message, MessageBoxButton button, MessageBoxImage icon, MessageBoxResult defaultResult = MessageBoxResult.None );
    }
}