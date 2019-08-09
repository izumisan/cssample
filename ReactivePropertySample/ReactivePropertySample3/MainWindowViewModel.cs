using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace ReactivePropertySample3
{
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            // 値の検証サンプル
            //
            // アトリビュートで検証ルールを指定し、
            // SetValidateAttribute()で検証ルールをRxプロパティに設定する
            // (SetValidateAttribute()では、自分自身のプロパティを指定する)
            Input1 = new ReactiveProperty<string>()
                .SetValidateAttribute( () => Input1 )
                .AddTo( _disposables );

            // エラーメッセージのサンプル
            Message1 = Input1
                .ObserveErrorChanged
                // エラーがない場合、ObserveErrorChangedはnullを返すので(eがnullとなっているので)、
                // 空のIEnumerableを生成する
                .Select( e => e ?? Enumerable.Empty<object>() )
                // 最初のエラーメッセージを取得する
                .Select( e => e.OfType<string>().FirstOrDefault() )  
                .ToReactiveProperty()
                .AddTo( _disposables );

            // エラーがない場合に有効なRxコマンドの生成
            Command1 = Input1
                .ObserveHasErrors
                .Select( e => e != true )
                .ToReactiveCommand()
                .AddTo( _disposables );

            Input2 = new ReactiveProperty<string>()
                .SetValidateAttribute( () => Input2 )
                .AddTo( _disposables );

            Message2 = Input2
                .ObserveErrorChanged
                .Select( e => e ?? Enumerable.Empty<object>() )
                .Select( e => e.OfType<string>().FirstOrDefault() )
                .ToReactiveProperty()
                .AddTo( _disposables );

            Command2 = Input2
                .ObserveHasErrors
                .Select( e => e != true )
                .ToReactiveCommand()
                .AddTo( _disposables );
        }

        ~MainWindowViewModel()
        {
            _disposables.Dispose();
        }

        private CompositeDisposable _disposables = new CompositeDisposable();

        // アトリビュートで検証ルールの指定
        [Required( ErrorMessage = @"空白不可" )]
        public ReactiveProperty<string> Input1 { get; set; } = null;

        public ReactiveProperty<string> Message1 { get; private set; } = null;

        public ReactiveCommand Command1 { get; private set; } = null;

        [IntValidation( ErrorMessage = @"整数のみ可" )]
        public ReactiveProperty<string> Input2 { get; set; } = null;

        public ReactiveProperty<string> Message2 { get; private set; } = null;

        public ReactiveCommand Command2 { get; private set; } = null;
    }
}
