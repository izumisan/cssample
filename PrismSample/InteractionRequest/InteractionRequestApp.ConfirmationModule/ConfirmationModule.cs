using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using InteractionRequestApp.ConfirmationModule.Views;

namespace InteractionRequestApp.ConfirmationModule
{
    public class ConfirmationModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            this.Container.RegisterType<object, ConfirmationView>( nameof( ConfirmationView ) );

            this.RegionManager.RegisterViewWithRegion( "2ndRegion", typeof( ConfirmationView ) );
        }
    }
}
