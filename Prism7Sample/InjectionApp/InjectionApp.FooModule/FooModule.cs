using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using InjectionApp.FooModule.Views;

namespace InjectionApp.FooModule
{
    public class FooModule : IModule
    {
        public void OnInitialized( IContainerProvider containerProvider )
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion( "ContentRegion", typeof( FooView ) );
        }

        public void RegisterTypes( IContainerRegistry containerRegistry )
        {
        }
    }
}
