using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;

namespace InvokeCommandAction
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
            : base()
        {
            MouseEnterCommand = new DelegateCommand<string>( ( e ) => Label = $"Mouse Enter: parameter={ e }" );
            MouseLeaveCommand = new DelegateCommand<string>( ( e ) => Label = $"Mouse Leave: parameter={ e }" );
        }

        private string _label = "invokeCommandActionにより、任意のイベントをCommandにバインドする";

        public string Label
        {
            get { return _label; }
            set { SetProperty( ref _label, value ); }
        }

        public DelegateCommand<string> MouseEnterCommand { get; private set; }

        public DelegateCommand<string> MouseLeaveCommand { get; private set; }
    }
}
