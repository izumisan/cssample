using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace CaptureOnEnter
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            ClearCommand = new ReactiveCommand()
                .WithSubscribe( () => Text.Value = string.Empty );
        }

        public ReactiveProperty<string> Text { get; set; } = new ReactiveProperty<string>( string.Empty );

        public ReactiveCommand ClearCommand { get; } = null;
    }
}
