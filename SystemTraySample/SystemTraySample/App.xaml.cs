using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using SystemTraySample.Components;

namespace SystemTraySample
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private NotifyIconWrapper _notifyIconWrapper = new NotifyIconWrapper();

        protected override void OnStartup( StartupEventArgs e )
        {
            base.OnStartup( e );

            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        }

        protected override void OnExit( ExitEventArgs e )
        {
            base.OnExit( e );

            _notifyIconWrapper.Dispose();
        }
    }
}
