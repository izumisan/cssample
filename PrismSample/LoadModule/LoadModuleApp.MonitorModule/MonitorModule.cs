using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Events;
using LoadModuleApp.MonitorModule.Views;
using LoadModuleApp.MonitorModule.Models;

namespace LoadModuleApp.MonitorModule
{
    public class MonitorModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public MonitorModule( IUnityContainer container, IRegionManager regionManager )
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            string msg = $"{ DateTime.Now } MonitorModule.Initialize()";
            Trace.WriteLine( msg );

            //_container.RegisterType<IMessageStore, MessageStore>( new ContainerControlledLifetimeManager() );
            //_container.RegisterType<object, MonitorView>( nameof( MonitorView ) );

            // modelの登録
            _container.RegisterTypes(
                AllClasses.FromAssemblies( typeof( MonitorModule ).Assembly )
                    .Where( x => x.Namespace.EndsWith( ".Models" ) ),
                getFromTypes: WithMappings.FromAllInterfaces,
                getLifetimeManager: WithLifetime.ContainerControlled );

            // viewの登録
            _container.RegisterTypes(
                AllClasses.FromAssemblies( typeof( MonitorModule ).Assembly )
                    .Where( x => x.Namespace.EndsWith( ".Views" ) ),
                getFromTypes: _ => new[] { typeof( object ) },
                getName: WithName.TypeName );

            _regionManager.RegisterViewWithRegion( "BottomRegion", typeof( MonitorView ) );

            _container.Resolve<IEventAggregator>().GetEvent<PubSubEvent<string>>().Publish( msg );
        }
    }
}