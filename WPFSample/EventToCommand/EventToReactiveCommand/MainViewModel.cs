using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive.Disposables;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace EventToReactiveCommand
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            Label = new ReactiveProperty<string>( "EventToReactiveCommandにより、任意のイベントをReactiveCommandにバインドする" );

            MouseEnterCommand.Subscribe( _ => Label.Value = "MouseEnter" )
                .AddTo( _disposable );

            MouseLeaveCommand.Subscribe( x => Label.Value = $"MouseLeave: { x?.GetType() }" )
                .AddTo( _disposable );

            MouseDoubleClickCommand.Subscribe( _ => ++DoubleClickCount.Value )
                .AddTo( _disposable );
        }

        ~MainViewModel()
        {
            _disposable.Dispose();
        }

        private readonly CompositeDisposable _disposable = new CompositeDisposable();

        public ReactiveProperty<string> Label { get; private set; }

        public ReactiveProperty<int> DoubleClickCount { get; private set; } = new ReactiveProperty<int>();

        public ReactiveCommand MouseEnterCommand { get; private set; } = new ReactiveCommand();

        public ReactiveCommand<object> MouseLeaveCommand { get; private set; } = new ReactiveCommand<object>();

        public ReactiveCommand MouseDoubleClickCommand { get; private set; } = new ReactiveCommand();
    }
}
