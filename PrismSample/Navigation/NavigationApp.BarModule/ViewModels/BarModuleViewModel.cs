using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Regions;
using Microsoft.Practices.Unity;
using NavigationApp.BarModule.Views;

namespace NavigationApp.BarModule.ViewModels
{
    public class BarModuleViewModel : BindableBase
    {
        public BarModuleViewModel()
            : base()
        {
            ShowCommand = new DelegateCommand<string>( showCommandExecute );
        }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public DelegateCommand<string> ShowCommand { get; set; }

        private void showCommandExecute( string x )
        {
            RegionManager.RequestNavigate( "MainRegion", nameof( BarView ), new NavigationParameters( $"name={ x }" ) );
        }
    }
}
