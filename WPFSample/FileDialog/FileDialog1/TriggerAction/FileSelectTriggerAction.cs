using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Win32;

namespace FileDialog1.TriggerAction
{
    public class FileSelectTriggerAction : TriggerAction<ContentControl>
    {
        protected override void Invoke( object parameter )
        {
            if ( parameter is FileSelectRequestEventArgs )
            {
                var args = parameter as FileSelectRequestEventArgs;

                var dialog = new OpenFileDialog
                {
                    Title = args.Title,
                    CheckFileExists = true,
                    InitialDirectory = Environment.CurrentDirectory
                };

                if ( dialog.ShowDialog() == true )
                {
                    var selectedFile = dialog.FileName;

                    args.Callback( selectedFile );
                }
            }
        }
    }
}
