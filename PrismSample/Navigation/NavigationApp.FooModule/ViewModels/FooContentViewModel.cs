using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Regions;

namespace NavigationApp.FooModule.ViewModels
{
    public class FooContentViewModel : BindableBase, INavigationAware
    {
        public FooContentViewModel()
            : base()
        {
            Create = DateTime.Now;
        }

        private int _count = 0;

        #region INavigationAware

        public bool IsNavigationTarget( NavigationContext navigationContext )
        {
            Trace.WriteLine( "IsNavigationTarget" );
            return true;
        }

        public void OnNavigatedFrom( NavigationContext navigationContext )
        {
            Trace.WriteLine( "OnNavigatedFrom" );
        }

        public void OnNavigatedTo( NavigationContext navigationContext )
        {
            Trace.WriteLine( "OnNavigatedTo" );

            ++Count;
        }
        #endregion

        public DateTime Create { get; }

        public int Count
        {
            get { return _count; }
            set { SetProperty( ref _count, value ); }
        }

    }
}
