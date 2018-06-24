using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using InteractionRequestApp.NotificationModule.ViewModels;
using InteractionRequestApp.NotificationModule.Views;

namespace InteractionRequestApp.NotificationModule
{
    public class NotificationModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            //this.Container.RegisterType<NotificationViewModel>( new ContainerControlledLifetimeManager() );
            this.Container.RegisterType<object, NotificationView>( nameof( NotificationView ) );

            this.RegionManager.RegisterViewWithRegion( "1stRegion", typeof( NotificationView ) );
        }
    }
}
