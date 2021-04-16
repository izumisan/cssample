using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Data;
using Microsoft.Xaml.Behaviors;

namespace CaptureOnEnter
{
    /// <summary>
    /// Enterキー押下で、TextBox.Textプロパティのバイディングソースを更新するビヘイビア
    /// </summary>
    public class CaptureOnEnterBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            AssociatedObject.PreviewKeyDown += OnPreviewKeyDown;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            AssociatedObject.PreviewKeyDown -= OnPreviewKeyDown;
        }

        private void OnPreviewKeyDown( object sender, KeyEventArgs e )
        {
            if ( ( sender is TextBox tb ) && ( e.Key == Key.Enter ) )
            {
                // TextBox.Textプロパティのバイディングソースを更新する
                var binding = BindingOperations.GetBindingExpression( tb, TextBox.TextProperty );
                binding?.UpdateSource();
            }
        }
    }
}
