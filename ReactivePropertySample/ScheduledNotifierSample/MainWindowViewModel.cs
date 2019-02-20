using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Threading;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using Reactive.Bindings;
using Reactive.Bindings.Notifiers;
using Reactive.Bindings.Extensions;

namespace ScheduledNotifierSample
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ExecuteCommand.Subscribe( _ =>
            {
                Debug.Print( $"onExecuted: { DateTime.Now }" );
                Message.Value = "";

                // 即時実行
                _scheduledNotifier.Report( "0" );

                // 3秒後に実行
                _scheduledNotifier.Report( $"onReported: { DateTime.Now }", TimeSpan.FromSeconds( 3.0 ) );

                Debug.Print( $"[{ DateTime.Now }]---" );
            } );

            _scheduledNotifier.Subscribe( x =>
            {
                Debug.Print( $"[{ DateTime.Now }] { x }" );
                Message.Value = x;
            } );
        }

        public ScheduledNotifier<string> _scheduledNotifier = new ScheduledNotifier<string>();

        public ReactiveProperty<string> Message { get; private set; } = new ReactiveProperty<string>();

        public ReactiveCommand ExecuteCommand { get; private set; } = new ReactiveCommand();
    }
}
