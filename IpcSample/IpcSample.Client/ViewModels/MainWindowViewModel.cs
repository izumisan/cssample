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

namespace IpcSample.Client.ViewModels
{
    /// <summary>
    /// MainWindowViewModel（クライアント側）
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            _client.open();

            //@@@ Memo
            // IPCデータはサーバ側で保持している.
            // クライアント側でイベント登録(購読)は実施できない.

            //IpcValue = _client.IpcData
            //           .ObserveProperty( m => m.Value )
            //           .ToReactiveProperty()
            //           .AddTo( _disposable );

            //_client.IpcData.PropertyChanged += ( s, e ) =>
            //{
            //    switch ( e.PropertyName )
            //    {
            //    case "Value":
            //        IpcValue.Value = _client.IpcData.Value;
            //        break;
            //    default:
            //        break;
            //    }
            //};

            
            //
            // 定期的にIPCデータの値を取得する
            //
            _monitor = Observable.Interval( TimeSpan.FromSeconds( 5.0 ) );

            _monitor.Subscribe( i =>
            {
                MonitorCount.Value = i + 1;  //@@@ 初回発行値が0なので+1する
                IpcValue.Value = _client.IpcData.Value;
            } ).AddTo( _disposable );

            InputValueCommand = new DelegateCommand( () => _client.IpcData.Value = InputValue );
        }

        ~MainWindowViewModel()
        {
            _disposable.Dispose();
        }

        private CompositeDisposable _disposable = new CompositeDisposable();

        /// <summary>
        /// IPCクライアント
        /// </summary>
        private IpcClient _client = new IpcClient();

        private IObservable<long> _monitor = null;

        public ReactiveProperty<long> MonitorCount { get; private set; } = new ReactiveProperty<long>( 0L );

        public ReactiveProperty<int> IpcValue { get; private set; } = new ReactiveProperty<int>( 0 );

        public int InputValue { get; set; } = 0;

        public DelegateCommand InputValueCommand { get; private set; }
    }
}
