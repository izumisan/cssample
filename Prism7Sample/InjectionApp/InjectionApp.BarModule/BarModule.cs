﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using InjectionApp.BarModule.Views;

namespace InjectionApp.BarModule
{
    public class BarModule : IModule
    {
        public void OnInitialized( IContainerProvider containerProvider )
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion( "ContentRegion", typeof( BarView ) );
        }

        public void RegisterTypes( IContainerRegistry containerRegistry )
        {
        }
    }
}
