using System;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Events;
using LoadModuleApp.FooModule.Views;

namespace LoadModuleApp.FooModule
{
    public class FooModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public FooModule( IUnityContainer container, IRegionManager regionManager )
        {
            _container = container;
            _regionManager = regionManager;
        }

        [Dependency]
        public IEventAggregator EventAggregator { get; set; }

        public void Initialize()
        {
            string msg = $"{ DateTime.Now } FooModule.Initialize()";
            Trace.WriteLine( msg );

            this.EventAggregator.GetEvent<PubSubEvent<string>>().Publish( msg );

            _container.RegisterType<object, FooView>( nameof( FooView ) );

            _regionManager.RegisterViewWithRegion( "BottomRegion", typeof( FooView ) );
        }
    }
}