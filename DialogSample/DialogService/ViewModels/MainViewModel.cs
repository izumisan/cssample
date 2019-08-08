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
                    ( c ) => Debug.WriteLine( $"result: { c.Result }, ok: { c.Parameters.GetValue<int>( "ok" ) }, cancel: { c.Parameters.GetValue<int>( "cancel" ) }" ) );
            } );

            ConfirmationCommand = new DelegateCommand( () =>
            {
                _dialogService.ShowDialog(
                    "ConfirmationView",
                    new DialogParameters
                    {
                        { "title", "Confirmation" },
                        { "message", "おｋ？　きゃんせる？" }
                    },
                    ( c ) => Debug.WriteLine( $"result: { c.Result }, ok: { c.Parameters.GetValue<int>( "ok" ) }, cancel: { c.Parameters.GetValue<int>( "cancel" ) }" ) );
            } );
        }

        private readonly IDialogService _dialogService = null;

        public DelegateCommand NotificationCommand { get; private set; } = null;
        public DelegateCommand ConfirmationCommand { get; private set; } = null;
    }
}
