using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using InjectionApp.BazModule.Views;

namespace InjectionApp.BazModule
{
    public class BazModule : IModule
    {
        public void OnInitialized( IContainerProvider containerProvider )
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion( "ContentRegion", typeof( BazView ) );
        }

        public void RegisterTypes( IContainerRegistry containerRegistry )
        {
        }
    }
}
