using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive.Linq;
using System.Reactive.Disposables;
using Reactive.Bindings;
using Reactive.Bindings.Notifiers;
using Reactive.Bindings.Extensions;

namespace BooleanNotifierSample
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            TurnOnCommand.Subscribe( _ => BooleanNotifier.TurnOn() ).AddTo( _disposable );
            TurnOffCommand.Subscribe( _ => BooleanNotifier.TurnOff() ).AddTo( _disposable );
            SwitchValueCommand.Subscribe( _ => BooleanNotifier.SwitchValue() ).AddTo( _disposable );
        }

        ~MainWindowViewModel()
        {
            _disposable.Dispose();
        }

        private CompositeDisposable _disposable = new CompositeDisposable();

        public BooleanNotifier BooleanNotifier { get; private set; } = new BooleanNotifier( false );

        public ReactiveCommand TurnOnCommand { get; private set; } = new ReactiveCommand();
        public ReactiveCommand TurnOffCommand { get; private set; } = new ReactiveCommand();
        public ReactiveCommand SwitchValueCommand { get; private set; } = new ReactiveCommand();
    }
}
