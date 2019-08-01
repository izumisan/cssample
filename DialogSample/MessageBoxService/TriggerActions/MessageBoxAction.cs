using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Interactivity;
using Prism.Interactivity.InteractionRequest;
using MessageBoxService.Services;

namespace MessageBoxService.TriggerActions
{
    public class MessageBoxAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke( object parameter )
        {
            var args = parameter as InteractionRequestedEventArgs;
            var context = args?.Context as MessageContext;
            if ( context != null )
            {
                // WPF標準のMessageBoxを表示する
                context.Result = MessageBox.Show(
                    context.Message,
                    context.Title,
                    context.Button,
                    context.Icon,
                    context.DefaultResult );

                args.Callback();
            }
        }
    }
}
