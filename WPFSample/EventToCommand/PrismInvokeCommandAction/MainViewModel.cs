using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;

namespace PrismInvokeCommandAction
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
            : base()
        {
            MouseEnterCommand = new DelegateCommand<string>( ( e ) => Label = $"Mouse Enter: parameter={ e }" );
            MouseLeaveCommand = new DelegateCommand<string>( ( e ) => Label = $"Mouse Leave: parameter={ e }" );
            MouseDoubleClickCommand = new DelegateCommand( () => ++DoubleClickCount );
        }

        private string _label = "Prism InvokeCommandActionにより、任意のイベントをCommandにバインドする";

        private int _doubleClickCount = 0;

        public string Label
        {
            get { return _label; }
            set { SetProperty( ref _label, value ); }
        }

        public int DoubleClickCount
        {
            get { return _doubleClickCount; }
            set { SetProperty( ref _doubleClickCount, value ); }
        }

        public DelegateCommand<string> MouseEnterCommand { get; private set; }

        public DelegateCommand<string> MouseLeaveCommand { get; private set; }

        public DelegateCommand MouseDoubleClickCommand { get; private set; }
    }
}
