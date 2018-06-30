using DIContainerApp.CountModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

using DIContainerApp.CountModule.Models;

namespace DIContainerApp.CountModule
{
    public class CountModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public CountModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            // DIするため、Modelをコンテナに登録する
            _container.RegisterType<ICounter, Counter>( new ContainerControlledLifetimeManager() );

            _container.RegisterType<object, CountModuleView>( nameof( CountModuleView ) );

            _regionManager.RegisterViewWithRegion( "ContentRegion", typeof( CountModuleView ) );
        }
    }
}