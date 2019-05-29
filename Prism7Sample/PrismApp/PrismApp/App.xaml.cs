using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using PrismApp.Views;

namespace PrismApp
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : PrismApplication  // AppクラスをPrismApplicationクラスのサブクラスとする
    {
        // Prism 7ではAppクラスをPrismApplicationクラスのサブクラスとし、
        // Bootstrapperの代わりにCreateShellやModuleの追加を行う

        protected override Window CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void RegisterTypes( IContainerRegistry containerRegistry )
        {
        }

        protected override void ConfigureModuleCatalog( IModuleCatalog moduleCatalog )
        {
            base.ConfigureModuleCatalog( moduleCatalog );

            // カタログにモジュールを追加
            moduleCatalog.AddModule<FooModule.FooModule>();
        }
    }
}
