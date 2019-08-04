using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;

namespace DelegateCommandSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            // DelegateCommand.ObservesProperty()に自身のプロパティを指定することで、
            // 指定したプロパティ変更時にCanExecuteChangedが発行される
            FooCommand = new DelegateCommand(
                () => Debug.WriteLine( $"value1: { Value1 }, value2: { Value2 }" ),
                () => ( Value1 % 3 == 0 ) && ( Value2 % 5 == 0 ) )
                .ObservesProperty( () => Value1 )
                .ObservesProperty( () => Value2 );
        }

        private int _value1 = 3;
        private int _value2 = 5;

        public int Value1
        {
            get { return _value1; }
            set { SetProperty( ref _value1, value ); }
        }

        public int Value2
        {
            get { return _value2; }
            set { SetProperty( ref _value2, value ); }
        }

        public DelegateCommand FooCommand { get; private set; } = null;
    }
}
