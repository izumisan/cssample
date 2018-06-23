using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Prism.Modularity;
using InteractionRequestApp.Views;

namespace InteractionRequestApp
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            ( this.Shell as Window ).Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            // モジュールをカタログに追加
            var catalog = this.ModuleCatalog as ModuleCatalog;

            catalog.AddModule( typeof( NotificationModule.NotificationModule ) );
            catalog.AddModule( typeof( ConfirmationModule.ConfirmationModule ) );
        }
    }
}
