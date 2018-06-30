using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using EventAggregatorApp.OutputModule2.Views;

namespace EventAggregatorApp.OutputModule2
{
    public class OutputModule2 : IModule
    {
        public OutputModule2( IUnityContainer container, IRegionManager regionManager )
        {
            _container = container;
            _regionManager = regionManager;
        }

        private IUnityContainer _container = null;

        private IRegionManager _regionManager = null;

        public void Initialize()
        {
            _container.RegisterType<object, OutputModule2View>( nameof( OutputModule2View ) );

            _regionManager.RegisterViewWithRegion( "OutputRegion2", typeof( OutputModule2View ) );
        }
    }
}
