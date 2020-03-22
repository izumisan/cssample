using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Interactivity;
using MessageBoxSample.Components;

namespace MessageBoxSample.TriggerActions
{
    public class MessageBoxAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke( object parameter )
        {
            var args = parameter as MessageBoxRequestArgs;
            if ( args != null )
            {
                var contents = args.Contents;
                contents.Result = MessageBox.Show( contents.Body, contents.Title, contents.Button, contents.Image );
                args.Callback?.Invoke( contents );
            }
        }
    }
}
