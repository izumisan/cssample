using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reactive.Linq;
using System.Reactive.Disposables;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace ReactivePropertySample2
{
    public class MainWindowViewModel
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public MainWindowViewModel()
        {
            // CountのSubscibe
            // Countの値に応じて、_deltaを更新する
            Count.Subscribe( x =>
            {
                if ( Math.Abs( x ) < 10 )
                {
                    _delta = 1;
                }
                else if ( Math.Abs( x ) < 100 )
                {
                    _delta = 10;
                }
                else if ( Math.Abs( x ) < 1000 )
                {
                    _delta = 100;
                }
                else if ( Math.Abs( x ) < 10000 )
                {
                    _delta = 1000;
                }
                else
                {
                }
            } );

            // RxプロパティからRxコマンドを生成する &
            // CompositeDisposableへ自身を登録する
            UpCommand = Count
                .Select( x => x < 5000 )
                .ToReactiveCommand()
                .AddTo( _disposables );

            DownCommand = Count
                .Select( x => -5000 < x )
                .ToReactiveCommand()
                .AddTo( _disposables );

            // RxコマンドのSubscribe
            UpCommand.Subscribe( _ => Count.Value += _delta );
            DownCommand.Subscribe( _ => Count.Value -= _delta );

            // CompositeDisposableへの登録
            _disposables.Add( Count );
        }

        /// <summary>
        /// ファイナライザ
        /// </summary>
        ~MainWindowViewModel()
        {
            // 一括破棄
            _disposables.Dispose();
        }

        // CompositeDisposable
        //
        // 自身のDispose時、登録されている全ての要素のDisposeを実行する.
        // 再利用不可なので、自身をDisposeせずに登録要素だけをDisposeしたい場合は、
        // Clear()を使用する.
        private CompositeDisposable _disposables = new CompositeDisposable();

        private int _delta = 1;

        public ReactiveProperty<int> Count { get; private set; } = new ReactiveProperty<int>();

        public ReactiveCommand UpCommand { get; private set; }

        public ReactiveCommand DownCommand { get; private set; }
    }
}
