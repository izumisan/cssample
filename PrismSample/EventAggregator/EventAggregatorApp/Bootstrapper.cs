using EventAggregatorApp.Views;
using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace EventAggregatorApp
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

            moduleCatalog.AddModule(typeof(InputModule.InputModule));
            moduleCatalog.AddModule( typeof( OutputModule.OutputModule ) );
            moduleCatalog.AddModule( typeof( OutputModule2.OutputModule2 ) );
        }
    }
}
