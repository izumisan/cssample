using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace DialogService.ViewModels
{
    public class ConfirmationViewModel : BindableBase, IDialogAware
    {
        public ConfirmationViewModel()
            : base()
        {
            OkCommand = new DelegateCommand( () =>
            {
                ++_okCount;

                RequestClose?.Invoke( 
                    new DialogResult( 
                        ButtonResult.OK, 
                        new DialogParameters { { "ok", _okCount }, { "cancel", _cancelCount } } ) );
            } );

            CancelCommand = new DelegateCommand( () =>
            {
                ++_cancelCount;

                RequestClose?.Invoke(
                    new DialogResult(
                        ButtonResult.Cancel,
                        new DialogParameters { { "ok", _okCount }, { "cancel", _cancelCount } } ) );
            } );
        }

        private string _message = "No Message.";

        private static int _okCount = 0;
        private static int _cancelCount = 0;

        #region IDialogAwareの実装

        public event Action<IDialogResult> RequestClose = null;

        public string Title { get; set; } = "No Title";

        public void OnDialogOpened( IDialogParameters parameters )
        {
            Title = parameters.GetValue<string>( "title" );
            Message = parameters.GetValue<string>( "message" ) + Environment.NewLine
                    + $"OK: { _okCount }, Canclel: { _cancelCount }";
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }
        #endregion

        public string Message
        {
            get { return _message; }
            set { SetProperty( ref _message, value ); }
        }

        public DelegateCommand OkCommand { get; private set; } = null;
        public DelegateCommand CancelCommand { get; private set; } = null;
    }
}
