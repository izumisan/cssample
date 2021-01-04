using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using MaterialDesignThemes.Wpf;

namespace Dialog2
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            OnClosing += ( s, e ) =>
            {
                string parameter = (string)e.Parameter;
                if ( parameter.Contains( "ok" ) )
                {
                    Debug.WriteLine( "OK selected." );
                }
                else
                {
                    Debug.WriteLine( "Cancel selected." );
                    e.Cancel();  // DialogClosingEventArgs.Cancel()により、ダイアログが閉じるのをキャンセルできる
                }
            };
        }

        public DialogClosingEventHandler OnClosing { get; set; }
    }
}
