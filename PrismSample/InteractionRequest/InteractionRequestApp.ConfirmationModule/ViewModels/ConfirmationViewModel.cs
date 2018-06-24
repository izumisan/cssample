using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestApp.ConfirmationModule.ViewModels
{
    public class ConfirmationViewModel : BindableBase
    {
        public ConfirmationViewModel()
            : base()
        {
            ConfirmationCommand = new DelegateCommand( confirmationCommandExecute );
        }

        private string _message = string.Empty;

        public string Message
        {
            get { return _message; }
            set { SetProperty( ref _message, value ); }
        }

        public DelegateCommand ConfirmationCommand { get; set; }

        public InteractionRequest<Confirmation> ConfirmationRequest { get; } = new InteractionRequest<Confirmation>();

        private void confirmationCommandExecute()
        {
            Message = "now selecting...";

            ConfirmationRequest.Raise( new Confirmation
            {
                Title = "タイトル",
                Content = "コンテンツ"
            },
            ( c ) =>
            {
                if ( c.Confirmed )
                {
                    Message = "OK selected.";
                }
                else
                {
                    Message = "Cancel selected.";
                }
            } );
        }
    }
}
