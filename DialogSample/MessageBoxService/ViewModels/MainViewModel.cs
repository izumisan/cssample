using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;
using Unity;
using MessageBoxService.Services;
using MessageBoxService.Extensions;

namespace MessageBoxService.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
            : base()
        {
            InformationCommand = new DelegateCommand( () =>
            {
                var result = MessageBoxService.ShowInformation( "いんふぉめーしょん" );
                Debug.WriteLine( $"selected: { result }" );
            } );

            ConfirmationCommand = new DelegateCommand( () =>
            {
                var result = MessageBoxService.ShowConfirmation( "こんふぁめーしょん" );
                Debug.WriteLine( $"selected: { result }" );
            } );

            YesNoCancelCommand = new DelegateCommand( () =>
            {
                // メッセージボックスの結果による分岐処理を
                // MessageBoxResultの拡張メソッドでメソッドチェインでつなげてみた
                MessageBoxService.Show( "たいとる", "はい？　いいえ？　きゃんせる？", MessageBoxButton.YesNoCancel, MessageBoxImage.Question )
                    .Yes( () => Debug.WriteLine( "はい" ) )
                    .No( () => Debug.WriteLine( "いいえ" ) )
                    .Cancel( () => Debug.WriteLine( "キャンセル" ) );
            } );
        }

        // MessageBoxServiceをプロパティインジェクション
        [Dependency]
        public IMessageBoxService MessageBoxService { get; set; } = null;

        public DelegateCommand InformationCommand { get; private set; } = null;
        public DelegateCommand ConfirmationCommand { get; private set; } = null;
        public DelegateCommand YesNoCancelCommand { get; private set; } = null;
    }
}
