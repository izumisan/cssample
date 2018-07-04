using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Regions;
using Microsoft.Practices.Unity;

namespace NavigationApp.FooModule.ViewModels
{
    public class FooModuleViewModel : BindableBase
    {
        public FooModuleViewModel()
        {
            ShowCommand = new DelegateCommand( () => this.RegionManager.RequestNavigate( "MainRegion", nameof( Views.FooContentView ) ) );
        }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public DelegateCommand ShowCommand { get; private set; }
    }
}
