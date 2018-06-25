using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using InteractionRequestApp.DefaultDialogModule.Views;

namespace InteractionRequestApp.DefaultDialogModule
{
    public class DefaultDialogModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            this.Container.RegisterType<object, DefaultDialogModuleView>( nameof( DefaultDialogModuleView ) );

            this.RegionManager.RegisterViewWithRegion( "4thRegion", typeof( DefaultDialogModuleView ) );
        }
    }
}
