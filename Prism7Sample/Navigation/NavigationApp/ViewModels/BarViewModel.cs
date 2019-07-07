using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Regions;

namespace NavigationApp.ViewModels
{
    public class BarViewModel : BindableBase, INavigationAware
    {
        public BarViewModel()
            : base()
        {
            Trace.WriteLine( "[bar] ctor." );
            CreateTime = DateTime.Now;
        }

        private int _count = 0;

        public DateTime CreateTime { get; private set; } = default( DateTime );

        public int Count
        {
            get { return _count; }
            private set { SetProperty( ref _count, value ); }
        }

        public bool IsNavigationTarget( NavigationContext navigationContext )
        {
            Trace.WriteLine( "[bar] IsNavigationTarget" );
            return false;  // true:=viewを再利用する, false:=新たにviewを生成する
        }

        public void OnNavigatedFrom( NavigationContext navigationContext )
        {
            Trace.WriteLine( "[bar] OnNavigatedFrom" );
        }

        public void OnNavigatedTo( NavigationContext navigationContext )
        {
            Trace.WriteLine( "[bar] OnNavigatedTo" );
            ++Count;
        }
    }
}
