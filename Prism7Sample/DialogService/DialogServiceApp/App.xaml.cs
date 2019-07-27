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
using Prism.Regions;
using DialogServiceApp.Views;

namespace DialogServiceApp
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

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionMgr = Container.Resolve<IRegionManager>();
            regionMgr.RegisterViewWithRegion( "ContentRegion", typeof( MainView ) );
        }

        protected override void RegisterTypes( IContainerRegistry containerRegistry )
        {
            // dialogの登録
            containerRegistry.RegisterDialog<DialogView>( nameof( DialogView ) );
        }
    }
}
