using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using PrismApp.FooModule.Models;
using PrismApp.FooModule.Views;

namespace PrismApp.FooModule
{
    public class FooModule : IModule
    {
        // Prism 6までのIModuleはinitializeメソッドのみだったが、
        // Prism 7ではOnInitializedメソッドとRegisterTypesメソッドを有する

        public void OnInitialized( IContainerProvider containerProvider )
        {
            // IContainerProviderにより、コンテナからRegionManagerを取得する
            var regionManager = containerProvider.Resolve<IRegionManager>();

            // RegionManagerにより、Shellの"ContentRegion"にFooViewを登録する
            regionManager.RegisterViewWithRegion( "ContentRegion", typeof( FooView ) );
        }

        public void RegisterTypes( IContainerRegistry containerRegistry )
        {
            // モデルをコンテナに登録する
            containerRegistry.Register<IFoo, Foo>();
        }
    }
}
