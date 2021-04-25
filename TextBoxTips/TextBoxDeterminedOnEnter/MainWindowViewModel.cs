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

namespace TextBoxDeterminedOnEnter
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            OnEnterKeyCommand = new ReactiveCommand<string>()
                .WithSubscribe( x => Text.Value = x );

            ClearCommand = new ReactiveCommand()
                .WithSubscribe( () => Text.Value = string.Empty );
        }

        public ReactiveProperty<string> Text { get; set; } = new ReactiveProperty<string>( string.Empty );

        public ReactiveCommand<string> OnEnterKeyCommand { get; set; } = null;

        public ReactiveCommand ClearCommand { get; } = null;
    }
}
