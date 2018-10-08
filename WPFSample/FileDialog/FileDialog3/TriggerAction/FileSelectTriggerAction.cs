using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Microsoft.Win32;

namespace FileDialog3.TriggerAction
{
    public class FileSelectTriggerAction : TriggerAction<Button>
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register( "Title",
                                         typeof( string ),
                                         typeof( FileSelectTriggerAction ),
                                         new PropertyMetadata( string.Empty ) );

        public static readonly DependencyProperty FileNameProperty =
            DependencyProperty.Register( "FileName",
                                         typeof( string ),
                                         typeof( FileSelectTriggerAction ),
                                         new PropertyMetadata( string.Empty ) );

        public string Title
        {
            get { return GetValue( TitleProperty ) as string; }
            set { SetValue( TitleProperty, value ); }
        }

        public string FileName
        {
            get { return GetValue( FileNameProperty ) as string; }
            set { SetValue( FileNameProperty, value ); }
        }

        protected override void Invoke( object parameter )
        {
            var dialog = new OpenFileDialog
            {
                Title = this.Title,
                CheckFileExists = true,
                InitialDirectory = Environment.CurrentDirectory
            };

            if ( dialog.ShowDialog() == true )
            {
                this.FileName = dialog.FileName;
            }
        }
    }
}
