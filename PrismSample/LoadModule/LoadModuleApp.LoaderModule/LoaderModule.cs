using System;
using System.Linq;
using System.Diagnostics;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using LoadModuleApp.LoaderModule.Models;
using LoadModuleApp.LoaderModule.Views;

namespace LoadModuleApp.LoaderModule
{
    public class LoaderModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public LoaderModule( IUnityContainer container, IRegionManager regionManager )
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            string msg = $"{ DateTime.Now } LoaderModule.initialize()";
            Trace.WriteLine( msg );

            //_container.RegisterType<IMessagePublisher, MessagePublisher>();
            //_container.RegisterType<object, LoaderView>( nameof( LoaderView ) );

            // modelsの登録
            _container.RegisterTypes(
                AllClasses.FromAssemblies( typeof( LoaderModule ).Assembly )
                    .Where( x => x.Namespace.EndsWith( "Models" ) ),
                getFromTypes: WithMappings.FromAllInterfaces,
                getLifetimeManager: WithLifetime.ContainerControlled );

            // viewの登録
            _container.RegisterTypes(
                AllClasses.FromAssemblies( typeof( LoaderModule ).Assembly )
                    .Where( x => x.Namespace.EndsWith( "Views" ) ),
                getFromTypes: _ => new[] { typeof( object ) },
                getName: WithName.TypeName );

            _regionManager.RegisterViewWithRegion( "TopRegion", typeof( LoaderView ) );

            _container.Resolve<IMessagePublisher>().publish( msg );
        }
    }
}