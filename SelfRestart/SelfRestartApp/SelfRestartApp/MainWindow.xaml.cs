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

using System.IO;
using System.Threading;
using System.Diagnostics;

namespace SelfRestartApp
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.label.Content = $"PID: { PID }";
        }

        public int PID => Process.GetCurrentProcess().Id;

        private void Button_Click( object sender, RoutedEventArgs e )
        {
            // 自身を起動するようにResterterを起動する
            var process = Process.GetCurrentProcess();
            var args = $"{ process.MainModule.FileName } { process.Id }";
            Process.Start( "Restarter.exe", args );

            Thread.Sleep( 5000 );  // 動作確認用ウェイト

            Application.Current.Shutdown();
        }
    }
}
