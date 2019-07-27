using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace DialogServiceApp.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel( IDialogService dialogService )
            : base()
        {
            _dialogService = dialogService;

            ShowDialogCommand = new DelegateCommand( () =>
            {
                ResultText = string.Empty;

                // モーダルダイアログを表示する
                _dialogService.ShowDialog(
                    "DialogView",
                    new DialogParameters
                    {
                        { "title", "たいとる" },
                        { "contents", "[ShowDialog] こんてんつ" }
                    },
                    ( c ) => ResultText = $"result: { c.Result }"
                );

                Debug.WriteLine( "end of ShowDialogCommand.Execute()" );
            } );

            ShowCommand = new DelegateCommand( () =>
            {
                ResultText = string.Empty;

                // 非モーダルダイアログを表示する
                _dialogService.Show(
                    "DialogView",
                    new DialogParameters
                    {
                        { "title", "たいとる" },
                        { "contents", "[Show] こんてんつ" }
                    },
                    ( c ) => ResultText = $"result: { c.Result }"
                );

                Debug.WriteLine( "end of ShowCommand.Execute()" );
            } );
        }

        private readonly IDialogService _dialogService = null;

        private string _resultText = string.Empty;

        public string ResultText
        {
            get { return _resultText; }
            set { SetProperty( ref _resultText, value ); } 
        }

        public DelegateCommand ShowDialogCommand { get; private set; } = null;

        public DelegateCommand ShowCommand { get; private set; } = null;
    }
}
