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
                Text1.SetValidateAttribute( () => Text1 );

                Command1 = Text1
                    .ObserveHasErrors
                    .Select( x => !x )
                    .ToReactiveCommand();
            }
            // サンプル2: 複合条件によるバリデーション
            {
                Text2A.SetValidateAttribute( () => Text2A );
                Text2B.SetValidateAttribute( () => Text2B );

                // 両者のObserveHasErrorsを合成することで、複合条件によるバリデーションが可能
                Command2 = new[]
                {
                    Text2A.ObserveHasErrors.Select( x => !x ),
                    Text2B.ObserveHasErrors.Select( x => !x )
                }
                .CombineLatestValuesAreAllTrue()
                .ToReactiveCommand();
            }
        }

        [Required( ErrorMessage = "空文字の場合のエラーメッセージ" )]
        public ReactiveProperty<string> Text1 { get; set; } = new ReactiveProperty<string>( string.Empty );
        public ReactiveCommand Command1 { get; } = null;

        [Required]
        public ReactiveProperty<string> Text2A { get; } = new ReactiveProperty<string>( string.Empty );
        [Required]
        public ReactiveProperty<string> Text2B { get; } = new ReactiveProperty<string>( string.Empty );
        public ReactiveCommand Command2 { get; } = null;
    }
}
