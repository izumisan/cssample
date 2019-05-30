using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Prism.Unity;
using Prism.Ioc;
using Prism.Modularity;

using InjectionApp.Shared;
using InjectionApp.Views;

namespace InjectionApp
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes( IContainerRegistry containerRegistry )
        {
            containerRegistry.Register<IMessageProvider, MessageProvider>();
        }

        protected override void ConfigureModuleCatalog( IModuleCatalog moduleCatalog )
        {
            base.ConfigureModuleCatalog( moduleCatalog );

            moduleCatalog.AddModule<FooModule.FooModule>();
            moduleCatalog.AddModule<BarModule.BarModule>();
        }
    }
}
