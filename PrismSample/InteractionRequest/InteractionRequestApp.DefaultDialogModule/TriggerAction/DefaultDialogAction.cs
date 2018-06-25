using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Interactivity;
using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestApp.DefaultDialogModule.TriggerAction
{
    public class DefaultDialogAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke( object parameter )
        {
            var args = parameter as InteractionRequestedEventArgs;
            var content = args.Context;

            if ( content is Confirmation )
            {
                var confirmation = content as Confirmation;
                var result = MessageBox.Show( confirmation.Content.ToString(),
                                              confirmation.Title,
                                              MessageBoxButton.OKCancel,
                                              MessageBoxImage.Question );
                confirmation.Confirmed = ( result == MessageBoxResult.OK );

                args.Callback();
            }
            else if ( content is Notification )
            {
                var notification = content as Notification;
                MessageBox.Show( notification.Content.ToString(),
                                 notification.Title,
                                 MessageBoxButton.OK,
                                 MessageBoxImage.Information );
                args.Callback();
            }
            else
            {
            }
        }
    }
}
