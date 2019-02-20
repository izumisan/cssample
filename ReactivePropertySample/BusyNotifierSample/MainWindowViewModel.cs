using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Notifiers;
using Reactive.Bindings.Extensions;

namespace BusyNotifierSample
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            // BusyNotifierがBusy状態ではない時に実行できるRxCommand
            HeavyCommand = BusyNotifier
                .Select( x => x != true )
                .ToReactiveCommand();

            HeavyCommand.Subscribe( async _ =>
            {
                // ProcessStart()の呼び出しにより、Busy状態になる
                // ProcessStart()の戻り値をDisposeすることで、Busy状態が解除される
                using ( BusyNotifier.ProcessStart() )
                {
                    await heavyProcesss();  // 重い処理（5sec）
                }
            } );
        }

        public BusyNotifier BusyNotifier { get; private set; } = new BusyNotifier();

        public ReactiveCommand HeavyCommand { get; private set; } = null;

        private async Task heavyProcesss()
        {
            await Task.Delay( TimeSpan.FromSeconds( 5.0 ) );
        }
    }
}
