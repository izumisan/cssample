using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;
using System.Reactive.Disposables;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;

namespace ValidationSample
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            // サンプル1: SetValidateAttribute()によるバリデーション
            {
                // SetValidateAttribute()に、ValidationAttributeが付与されたプロパティ（自プロパティ）取得式を指定する
                Text1.SetValidateAttribute( () => Text1 );

                Command1 = Text1
                    .ObserveHasErrors
                    .Select( x => !x )
                    .ToReactiveCommand();
            }
            // サンプル2: SetValidateNotifyError()によるバリデーション
            {
                // SetValidateNotifyError()に、Validator（エラーがある場合はエラーメッセージを、エラーがない場合はnullを返す式）を指定する
                // (SetValidateAttribute()とSetValidateNotifyError()の同時適用は不可)
                Text2.SetValidateNotifyError( x => string.IsNullOrEmpty( x ) ? "Please input string." : null );

                Command2 = Text2
                    .ObserveHasErrors
                    .Select( x => !x )
                    .ToReactiveCommand();
            }
            // サンプル3: 複合条件によるバリデーション
            {
                Text3A.SetValidateAttribute( () => Text3A );
                Text3B.SetValidateAttribute( () => Text3B );

                // 両者のObserveHasErrorsを合成することで、複合条件によるバリデーションが可能
                Command3 = new[]
                {
                    Text3A.ObserveHasErrors.Select( x => !x ),
                    Text3B.ObserveHasErrors.Select( x => !x )
                }
                .CombineLatestValuesAreAllTrue()
                .ToReactiveCommand();
            }
        }

        [Required( ErrorMessage = "空文字の場合のエラーメッセージ" )]
        public ReactiveProperty<string> Text1 { get; set; } = new ReactiveProperty<string>( string.Empty );
        public ReactiveCommand Command1 { get; } = null;

        public ReactiveProperty<string> Text2 { get; set; } = new ReactiveProperty<string>( string.Empty );
        public ReactiveCommand Command2 { get; } = null;

        [Required]
        public ReactiveProperty<string> Text3A { get; } = new ReactiveProperty<string>( string.Empty );
        [Required]
        public ReactiveProperty<string> Text3B { get; } = new ReactiveProperty<string>( string.Empty );
        public ReactiveCommand Command3 { get; } = null;
    }
}
