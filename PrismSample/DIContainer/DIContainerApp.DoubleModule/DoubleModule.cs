using DIContainerApp.DoubleModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

using DIContainerApp.DoubleModule.Models;

namespace DIContainerApp.DoubleModule
{
    public class DoubleModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public DoubleModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            /// DIするため、Modelをコンテナに登録する
            _container.RegisterType<IDoubleCounter, DoubleCounter>( new ContainerControlledLifetimeManager() );

            _container.RegisterType<object, DoubleModuleView>( nameof( DoubleModuleView ) );

            _regionManager.RegisterViewWithRegion( "ContentRegion", typeof( DoubleModuleView ) );
        }
    }
}