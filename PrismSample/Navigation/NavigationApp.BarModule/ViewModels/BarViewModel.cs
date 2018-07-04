using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Regions;

namespace NavigationApp.BarModule.ViewModels
{
    public class BarViewModel : BindableBase, INavigationAware
    {
        public BarViewModel()
            : base()
        {
            CountUpCommand = new DelegateCommand( () => ++Count );

            Create = DateTime.Now;
        }

        private string _name = string.Empty;

        private int _count = 0;

        public bool IsNavigationTarget( NavigationContext navigationContext )
        {
            return this.Name == navigationContext.Parameters["name"] as string;
        }

        public void OnNavigatedFrom( NavigationContext navigationContext )
        {
        }

        public void OnNavigatedTo( NavigationContext navigationContext )
        {
            this.Name = navigationContext.Parameters["name"] as string;
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty( ref _name, value ); }
        }

        public DateTime Create { get; } 

        public int Count
        {
            get { return _count; }
            set { SetProperty( ref _count, value ); }
        }

        public DelegateCommand CountUpCommand { get; private set; }
    }
}
