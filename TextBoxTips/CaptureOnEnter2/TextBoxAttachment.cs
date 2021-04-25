using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CaptureOnEnter2
{
    public static class TextBoxAttachment
    {
        // 添付プロパティ: CaptureOnEnterEnabled
        public static readonly DependencyProperty CaptureOnEnterEnabled =
            DependencyProperty.RegisterAttached(
                "CaptureOnEnterEnabled",
                typeof( bool ),
                typeof( TextBoxAttachment ),
                new PropertyMetadata( false, CaptureOnEnterEnabledChanged ) );

        public static bool GetCaptureOnEnterEnabled( DependencyObject obj )
        {
            return (bool)obj.GetValue( CaptureOnEnterEnabled );
        }

        public static void SetCaptureOnEnterEnabled( DependencyObject obj, bool value )
        {
            obj.SetValue( CaptureOnEnterEnabled, value );
        }

        /// <summary>
        /// 添付プロパティ(CaptureOnEnterEnabled)変更時、TextBoxのPreviewKeyDownイベントの購読/解除を行う.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void CaptureOnEnterEnabledChanged( DependencyObject d, DependencyPropertyChangedEventArgs e )
        {
            if ( ( d is TextBox tb ) && ( e.NewValue is bool value ) )
            {
                // 添付プロパティ(CaptureOnEnterEnabled)の変更時に
                // DependencyObjectのイベントの購読する実装方法は、
                // 一般的に「添付ビヘイビア」と呼ばれる.
                //
                // プロパティ(CaptureOnEnterEnabled)と振る舞い(OnTextBoxPreviewKeyDown)が
                // 直接結びつかないので、命名を誤ると何をやっているのかわかりにくいコードになる
                if ( value )
                {
                    tb.PreviewKeyDown += OnTextBoxPreviewKeyDown;
                }
                else
                {
                    tb.PreviewKeyDown -= OnTextBoxPreviewKeyDown;
                }
            }
        }

        private static void OnTextBoxPreviewKeyDown( object sender, KeyEventArgs e )
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
