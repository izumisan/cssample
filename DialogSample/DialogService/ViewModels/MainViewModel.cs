using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace DialogService.ViewModels
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel( IDialogService dialogService )
            : base()
        {
            _dialogService = dialogService;

            NotificationCommand = new DelegateCommand( () =>
            {
                _dialogService.ShowDialog(
                    "NotificationView", 
                    new DialogParameters(), 
                    ( c ) => Debug.WriteLine( $"result: { c.Result }" ) );  // 閉じるボタンから閉じた場合は ButtonResult.None となる
            } );

            ConfirmationCommand = new DelegateCommand( () =>
            {
                Debug.Print( "bar" );
            } );
        }

        private readonly IDialogService _dialogService = null;

        public DelegateCommand NotificationCommand { get; private set; } = null;
        public DelegateCommand ConfirmationCommand { get; private set; } = null;
    }
}
