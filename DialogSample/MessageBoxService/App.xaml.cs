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
using MessageBoxService.Services;
using MessageBoxService.Views;

namespace MessageBoxService
{
    // alias
    using MessageBoxService = MessageBoxService.Services.MessageBoxService;

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
            // MessageBoxServiceにコンテナに登録する
            containerRegistry.Register<IMessageBoxService, MessageBoxService>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionManager = Container.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion( "ContentRegion", typeof( MainView ) );
        }
    }
}
