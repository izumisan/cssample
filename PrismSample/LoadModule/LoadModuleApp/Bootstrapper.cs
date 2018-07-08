using LoadModuleApp.Views;
using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace LoadModuleApp
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;

            // LoaderModuleの依存先にMonitorModuleを指定
            // MonitorModule→LoaderModuleの順に読み込まれる.
            moduleCatalog.AddModule( typeof( LoaderModule.LoaderModule ), nameof( MonitorModule.MonitorModule ) );

            // LoaderModuleより後にAddModuleしているが、LoaderModuleより先に読み込まれる
            moduleCatalog.AddModule( typeof( MonitorModule.MonitorModule ) );

            // オンデマンドで読み込まれる
            moduleCatalog.AddModule( typeof( FooModule.FooModule ), InitializationMode.OnDemand );
        }
    }
}
