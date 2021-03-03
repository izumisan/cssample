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

            this.ProcessIdLabel.Content = $"PID: { PID }";
        }

        public int PID => Process.GetCurrentProcess().Id;

        private void RestarterEXE_Clicked( object sender, RoutedEventArgs e )
        {
            // Resterter.exeを起動し、自身を再起動してもらう
            var process = Process.GetCurrentProcess();
            var args = $"{ process.MainModule.FileName } { process.Id }";
            Process.Start( "Restarter.exe", args );

            Thread.Sleep( 5000 );  // 動作確認用ウェイト

            Application.Current.Shutdown();
        }

        private void RestarterPS1_Clicked( object sender, RoutedEventArgs e )
        {
            // restarter.ps1を実行し、自身を再起動してもらう
            var process = Process.GetCurrentProcess();
            var args = $"-ExecutionPolicy RemoteSigned -File restarter.ps1 { process.MainModule.FileName } { process.Id }";

            Process.Start( "powershell.exe", args );

            Thread.Sleep( 5000 );  // 動作確認用ウェイト

            Application.Current.Shutdown();
        }
    }
}
