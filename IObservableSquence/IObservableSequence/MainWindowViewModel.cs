using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive.Linq;
using System.Reactive.Disposables;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace IObservableSequence
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            // PropertyChangdのシーケンス化
            _foo.ObserveProperty( m => m.Value1 )
                .Subscribe( x => Value1.Value = x )
                .AddTo( _disposable );

            // PropertyChangedのシーケンス化
            _foo.PropertyChangedAsObservable()
                .Select( x => x.PropertyName == "Value1" )
                .Subscribe( _ => Value1A.Value = _foo.Value1 )
                .AddTo( _disposable );

            // FromEventPatternによるEventHander型イベントのシーケンス化
            Observable.FromEventPattern(
                    h => _foo.Value2Updated += h,
                    h => _foo.Value2Updated -= h )
                .Subscribe( _ => Value2.Value = _foo.Value2 )
                .AddTo( _disposable );

            // FromEventによるEventHandler型イベントのシーケンス化
            Observable.FromEvent<EventHandler, EventArgs>(
                    h => ( s, e ) => h( e ),
                    h => _foo.Value2Updated += h,
                    h => _foo.Value2Updated -= h )
                .Subscribe( _ => Value2A.Value = _foo.Value2 )
                .AddTo( _disposable );

            // FromEventPatternによるEventHandler<T>型イベントのシーケンス化
            Observable.FromEventPattern<ValueUpdatedEventArgs>(
                    h => _foo.Value3Updated += h,
                    h => _foo.Value3Updated -= h )
                .Subscribe( x => Value3.Value = x.EventArgs.Value )
                .AddTo( _disposable );

            // FromEventによるEventHander<T>型イベントのシーケンス化
            Observable.FromEvent<EventHandler<ValueUpdatedEventArgs>, ValueUpdatedEventArgs>(
                    h => ( s, e ) => h( e ),
                    h => _foo.Value3Updated += h,
                    h => _foo.Value3Updated -= h )
                .Subscribe( x => Value3A.Value = x.Value );

            Value1Command.Subscribe( _ => ++_foo.Value1 );
            Value2Command.Subscribe( _ => ++_foo.Value2 );
            Value3Command.Subscribe( _ => ++_foo.Value3 );
        }

        ~MainWindowViewModel()
        {
            _disposable.Dispose();
        }

        private readonly Foo _foo = new Foo();

        private CompositeDisposable _disposable = new CompositeDisposable();

        public ReactiveProperty<int> Value1 { get; private set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Value1A { get; private set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Value2 { get; private set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Value2A { get; private set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Value3 { get; private set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Value3A { get; private set; } = new ReactiveProperty<int>();

        public ReactiveCommand Value1Command { get; private set; } = new ReactiveCommand();
        public ReactiveCommand Value2Command { get; private set; } = new ReactiveCommand();
        public ReactiveCommand Value3Command { get; private set; } = new ReactiveCommand();
    }
}
