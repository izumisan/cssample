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

            moduleCatalog.AddModule( typeof( LoaderModule.LoaderModule ), nameof( MonitorModule.MonitorModule ) );
            moduleCatalog.AddModule( typeof( MonitorModule.MonitorModule ) );
            moduleCatalog.AddModule( typeof( FooModule.FooModule ), InitializationMode.OnDemand );
        }
    }
}
