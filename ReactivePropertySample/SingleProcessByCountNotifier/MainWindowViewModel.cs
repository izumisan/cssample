using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Notifiers;
using Reactive.Bindings.Extensions;

namespace SingleProcessByCountNotifier
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            // ProcessCounterがEmptyの時に実行できるRxCommand
            HeavyCommand = ProcessCounter
                .Select( x => x == CountChangedStatus.Empty )
                .ToReactiveCommand();

            HeavyCommand.Subscribe( async _ =>
            {
                // usingステートメントにより、Dispose()を呼び出す
                // Dispose()により、Incrementの増加分が取り消される
                using ( ProcessCounter.Increment() )
                {
                    await heavyProcesss();  // 重い処理
                }
            } );
        }

        public CountNotifier ProcessCounter { get; private set; } = new CountNotifier();

        public ReactiveCommand HeavyCommand { get; private set; } = null;

        private async Task heavyProcesss()
        {
            await Task.Delay( TimeSpan.FromSeconds( 5.0 ) );
        }
    }
}
