using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Ioc;
using NavigationApp.Views;

namespace NavigationApp.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel( IContainerExtension container )
            : base()
        {
            _container = container;

            SelectionItems.Add( "foo" );
            SelectionItems.Add( "bar" );
        }

        private readonly IContainerExtension _container = null;

        private int _selectedIndex = -1;

        public ObservableCollection<string> SelectionItems { get; private set; } = new ObservableCollection<string>();

        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                SetProperty( ref _selectedIndex, value, () =>
                {
                    var regionManager = _container.Resolve<IRegionManager>();
                    regionManager.RequestNavigate( "MainRegion", SelectionItems.ElementAt( _selectedIndex ) );
                } );
            }
        }
    }
}
