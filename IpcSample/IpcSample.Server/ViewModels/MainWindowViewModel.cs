using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive.Disposables;
using System.Reactive.Linq;
using Prism.Mvvm;
using Prism.Commands;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using IpcSample.Shared;

namespace IpcSample.Server.ViewModels
{
    /// <summary>
    /// MainWindowViewModel（サーバ側）
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            _server.open();

            IpcValue = _server.IpcData
                       .ObserveProperty( m => m.Value )
                       .ToReadOnlyReactiveProperty()
                       .AddTo( _disposable );

            InputValueCommand = new DelegateCommand( () => _server.IpcData.Value = InputValue );
        }

        ~MainWindowViewModel()
        {
            _disposable.Dispose();
        }

        private CompositeDisposable _disposable = new CompositeDisposable();

        /// <summary>
        /// IPCサーバ
        /// </summary>
        private IpcServer _server = new IpcServer();

        public ReadOnlyReactiveProperty<int> IpcValue { get; private set; }

        public int InputValue { get; set; } = 0;

        public DelegateCommand InputValueCommand { get; private set; }
    }
}
