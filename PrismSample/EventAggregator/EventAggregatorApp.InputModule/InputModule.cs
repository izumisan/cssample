using EventAggregatorApp.InputModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Microsoft.Practices.Unity;
using Prism.Unity;

namespace EventAggregatorApp.InputModule
{
    public class InputModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public InputModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<InputView>();

            _regionManager.RegisterViewWithRegion( "InputRegion", typeof( InputView ) );
        }
    }
}