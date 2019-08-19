using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Notifiers;

namespace AsyncReactiveCommandSample
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            // 処理中はボタンを押せないようにする

            // よくやる実装
            //------------------------------------------------------------------
            FooCommand = IsBusy.Select( x => x != true ).ToReactiveCommand();
            FooCommand.Subscribe( async _ =>
            {
                IsBusy.TurnOn();
                await Task.Run( () => DoSomething() );
                IsBusy.TurnOff();
            } );

            // AsyncReactiveCommandによる実装
            //------------------------------------------------------------------
            BarCommand = new AsyncReactiveCommand();
            BarCommand.Subscribe( _ => Task.Run( () => DoSomething() ) );  // SubscribeにはAction<T>ではなく、Func<T, Task>を指定する
        }

        public ReactiveCommand FooCommand { get; private set; } = null;
        public BooleanNotifier IsBusy { get; private set; } = new BooleanNotifier( false );

        public AsyncReactiveCommand BarCommand { get; private set; } = null;

        private void DoSomething()
        {
            Debug.Print( "start..." );
            System.Threading.Thread.Sleep( TimeSpan.FromSeconds( 3.0 ) );
            Debug.Print( "end." );
        }
    }
}
