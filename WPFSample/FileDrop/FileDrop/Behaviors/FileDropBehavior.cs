using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace FileDrop.Behaviors
{
    public class FileDropBehavior : Behavior<UIElement>
    {
        public static readonly DependencyProperty DropFileProperty =
            DependencyProperty.Register(
                "DropFile",
                typeof( string ),
                typeof( FileDropBehavior ),
                new PropertyMetadata( string.Empty ) );

        public string DropFile
        {
            get { return GetValue( DropFileProperty ) as string; }
            set { SetValue( DropFileProperty, value ); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewDragOver += AssociatedObject_PreviewDragOver;
            AssociatedObject.Drop += AssociatedObject_Drop;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();


            AssociatedObject.PreviewDragOver -= AssociatedObject_PreviewDragOver;
            AssociatedObject.Drop -= AssociatedObject_Drop;
        }

        private void AssociatedObject_PreviewDragOver( object sender, DragEventArgs e )
        {
            if ( e.Data.GetDataPresent( DataFormats.FileDrop, true ) )
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        private void AssociatedObject_Drop( object sender, DragEventArgs e )
        {
            var dropFiles = e.Data.GetData( DataFormats.FileDrop ) as string[];
            DropFile = dropFiles[0];
        }
    }
}
