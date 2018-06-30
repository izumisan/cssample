using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Prism.Unity;
using Prism.Modularity;
using Prism.Regions;
using EventAggregatorApp.OutputModule.Views;

namespace EventAggregatorApp.OutputModule
{
    public class OutputModule : IModule
    {
        public OutputModule()
        {
        }

        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            this.Container.RegisterType<object, OutputView>( nameof( OutputView ) );

            this.RegionManager.RegisterViewWithRegion( "OutputRegion", typeof( OutputView ) );
        }
    }
}
