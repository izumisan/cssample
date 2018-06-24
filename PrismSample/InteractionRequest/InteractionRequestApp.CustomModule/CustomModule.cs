using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using InteractionRequestApp.CustomModule.Views;

namespace InteractionRequestApp.CustomModule
{
    public class CustomModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            this.Container.RegisterType<object, CustomModuleView>( nameof( CustomModuleView ) );

            this.RegionManager.RegisterViewWithRegion( "3rdRegion", typeof( CustomModuleView ) );
        }
    }
}
