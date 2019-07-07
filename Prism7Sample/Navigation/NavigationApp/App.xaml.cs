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
using NavigationApp.Views;

namespace NavigationApp
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes( IContainerRegistry containerRegistry )
        {
            // viewの登録
            containerRegistry.Register<object, FooView>( "foo" );
            containerRegistry.Register<object, BarView>( "bar" );
        }
    }
}
