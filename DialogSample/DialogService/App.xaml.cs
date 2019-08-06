using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using Prism.Unity;
using Prism.Ioc;
using Prism.Regions;
using DialogService.Views;

namespace DialogService
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
            // ダイアログ用Viewの登録
            // (RegisterではなくRegisterDialogで登録する)
            containerRegistry.RegisterDialog<NotificationView>( nameof( NotificationView ) );
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionMgr = Container.Resolve<IRegionManager>();
            regionMgr.RegisterViewWithRegion( "ContentRegion", typeof( MainView ) );
        }
    }
}
