using NavigationApp.FooModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace NavigationApp.FooModule
{
    public class FooModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public FooModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterType<object, FooModuleView>( nameof( FooModuleView ) );
            _container.RegisterType<object, FooContentView>( nameof( FooContentView ) );

            _regionManager.RegisterViewWithRegion( "SelectionRegion", typeof( FooModuleView ) );
        }
    }
}