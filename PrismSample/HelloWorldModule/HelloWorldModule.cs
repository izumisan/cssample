using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using HelloWorldModule.Models;
using HelloWorldModule.Views;

namespace HelloWorldModule
{
    public class HelloWorldModule : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; } 

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public void Initialize()
        {
            // ViewModelの登録
            this.Container.RegisterType<MessageProvider>( new ContainerControlledLifetimeManager() );

            // Viewの登録
            this.Container.RegisterType<object, HelloWorldView>( nameof( HelloWorldView ) );

            this.RegionManager.RequestNavigate( "MainRegion", nameof( HelloWorldView ) );
        }
    }
}
