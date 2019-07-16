using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Diagnostics;

namespace TimerSample3
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Debug.WriteLine( $"Main thread id: { System.Threading.Thread.CurrentThread.ManagedThreadId }" );

            _timer = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromMilliseconds( 1000.0 ) };
            _timer.Tick += ( s, e ) =>
            {
                var id = System.Threading.Thread.CurrentThread.ManagedThreadId;
                var text = $"{ DateTime.Now.ToString( "HH:mm:ss.fff" ) }, id:{ id }";
                Debug.WriteLine( text );

                // UIスレッドで実行されるので、UIを直接操作しても例外にならない
                _text.Text = text;
            };

            _timer.Start();
        }

        ~MainWindow()
        {
            _timer.Stop();
        }

        private System.Windows.Threading.DispatcherTimer _timer = null;
    }
}
