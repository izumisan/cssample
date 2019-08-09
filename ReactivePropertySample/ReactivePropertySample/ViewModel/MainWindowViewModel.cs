using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

using ReactivePropertySample.Model;

namespace ReactivePropertySample.ViewModel
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            // IObservable<T>じゃないものからReactiveProperyへの接続
            //
            // _modelはINotifyPropertyChangedを継承しているので、
            // INotifyPropertyChangedをIObservable<T>に変換し、
            // IObservable<T>をReactivePropertyに変換する
            // (ObserveProperty() -> ToReactiveProperty() は
            //  モデルからReactivePropertyへのOneWayバインディング)
            Count = _model
                    .ObserveProperty( m => m.Count )
                    .ToReactiveProperty();

            // ReactivePropertyとReactivePropertyの連動
            //
            // Countの変更に連動するReactivePropertyを生成する
            Square = Count
                     .Select( x => x * x )
                     .ToReactiveProperty();

            // ReacriveCommandを購読する
            UpCommand.Subscribe( _ => _model.up() );
            DownCommand.Subscribe( _ => _model.down() );

            // CanExecuteを有するReactiveCommand
            //
            // Counterのカウントが0でない時に有効なReactiveCommandを生成する
            // (ReactiveCommandのコンストラクタで、canExecuteSourceを指定する)
            // (canExecuteSourceはIO<bool>なので、例によって、
            //  INotifyPropertyChangedの拡張メソッドを使用してIO<T>に変換する)
            ResetCommand = new ReactiveCommand(
                           _model
                           .ObserveProperty( x => x.Count )
                           .Select( x => x != 0 ) );
            // 今回の場合、Countプロパティ(ReactiveProperty)を有しているので、
            // 下記でも良い
            //ResetCommand = new ReactiveCommand( Count.Select( x => x != 0 ) );

            // ResetCommandの購読
            ResetCommand.Subscribe( _ => _model.reset() );
        }

        /// <summary>
        /// ファイナライザ
        /// </summary>
        ~MainWindowViewModel()
        {
            // Rxは内部で他オブジェクトをSubscribeしているので、リソースの解放が必要

            Count.Dispose();
            Square.Dispose();
            UpCommand.Dispose();
            DownCommand.Dispose();
            ResetCommand.Dispose();
        }

        private Counter _model = new Counter();

        public ReactiveProperty<int> Count { get; private set; } = null;

        public ReactiveProperty<int> Square { get; private set; } = null;

        public ReactiveCommand UpCommand { get; } = new ReactiveCommand();

        public ReactiveCommand DownCommand { get; } = new ReactiveCommand();

        public ReactiveCommand ResetCommand { get; } = null;
    }
}
