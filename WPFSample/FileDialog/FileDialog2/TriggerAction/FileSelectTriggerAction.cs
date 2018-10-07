using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Win32;
using Prism.Interactivity.InteractionRequest;

namespace FileDialog2.TriggerAction
{
    public class FileSelectTriggerAction : TriggerAction<ContentControl>
    {
        protected override void Invoke( object parameter )
        {
            var args = parameter as InteractionRequestedEventArgs;
            var context = args?.Context;

            if ( context is Notification )
            {
                var dialog = new OpenFileDialog
                {
                    Title = context.Title,
                    CheckFileExists = true,
                    InitialDirectory = Environment.CurrentDirectory
                };

                if ( dialog.ShowDialog() == true )
                {
                    var selectedFile = dialog.FileName;

                    context.Content = selectedFile;
                    args.Callback();
                }
            }
        }
    }
}
