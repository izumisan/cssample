using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Modularity;
using Prism.Regions;
using Microsoft.Practices.Unity;
using NavigationApp.BarModule.Views;

namespace NavigationApp.BarModule
{
    public class BarModule : IModule
    {
        public BarModule()
        {
        }

        [Dependency]
        public IUnityContainer UnityContainer { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            UnityContainer.RegisterType<object, BarModuleView>( nameof( BarModuleView ) );
            UnityContainer.RegisterType<object, BarView>( nameof( BarView ) );

            RegionManager.RegisterViewWithRegion( "SelectionRegion", typeof( BarModuleView ) );
        }
    }
}
