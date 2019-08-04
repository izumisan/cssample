using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Commands;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace ReactiveCommandSample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            // パターン1
            // コンストラクタで、CanExecuteChangedイベントを発行する
            // IO<bool>のcanExecuteSourceを指定することができる
            Command1 = new ReactiveCommand( Value1.Select( x => x % 3 == 0 ) );
            Command1.Subscribe( _ => Debug.WriteLine( $"value1: { Value1.Value }" ) );

            // パターン2
            // IO<bool>からReactiveCommandを生成する
            Command2 = Value2.Select( x => x % 5 == 0 ).ToReactiveCommand();
            Command2.Subscribe( _ => Debug.WriteLine( $"value2: { Value2.Value }" ) );

            // パターン3
            // 複数のIO<T>を合成してからReactiveCommandを生成する
            FooCommand = Value1.CombineLatest(
                Value2,
                ( v1, v2 ) => ( v1 % 3 == 0 ) && ( v2 % 5 ) == 0 )
                .ToReactiveCommand();
            // ↓これの方が可読性が高い？
            //FooCommand = Observable.CombineLatest(
            //    Value1.Select( x => x % 3 == 0 ),
            //    Value2.Select( x => x % 5 == 0 ),
            //    ( v1, v2 ) => v1 && v2 )
            //    .ToReactiveCommand();
            FooCommand.Subscribe( _ => Debug.WriteLine( $"value1: { Value1.Value }, value2: { Value2.Value }" ) );

            // DelegateCommand.ObservesProperty()にReactivePropertyを指定しても、
            // CanExecuteChangedは発火されない？
            BarCommand = new DelegateCommand(
                () => Debug.WriteLine( $"value1: { Value1.Value }, value2: { Value2.Value }" ),
                () => ( Value1.Value % 3 == 0 ) && ( Value2.Value % 5 == 0 ) )
                .ObservesProperty( () => Value1 )
                .ObservesProperty( () => Value2 );

            BarCommand.CanExecuteChanged += ( s, e ) => Debug.WriteLine( "BarCommand.CanExecuteChanged" );
        }

        public ReactiveProperty<int> Value1 { get; } = new ReactiveProperty<int>( 3 );
        public ReactiveProperty<int> Value2 { get; } = new ReactiveProperty<int>( 5 );

        public ReactiveCommand Command1 { get; private set; } = null;
        public ReactiveCommand Command2 { get; private set; } = null;

        public ReactiveCommand FooCommand { get; private set; } = null;

        public DelegateCommand BarCommand { get; private set; } = null;
    }
}
