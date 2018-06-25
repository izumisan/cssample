using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestApp.DefaultDialogModule.ViewModels
{
    public class DefaultDialogModuleViewModel : BindableBase
    {
        public DefaultDialogModuleViewModel()
            : base()
        {
            NotificationCommand = new DelegateCommand( notificationCommandExecute );
            ConfirmationCommand = new DelegateCommand( confirmationCommandExecute );
        }

        private string _message = string.Empty;

        public string Message
        {
            get { return _message; }
            set { SetProperty( ref _message, value ); }
        }

        public DelegateCommand NotificationCommand { get; set; }
        public DelegateCommand ConfirmationCommand { get; set; }

        public InteractionRequest<Notification> NotificationRequest { get; } = new InteractionRequest<Notification>();
        public InteractionRequest<Confirmation> ConfirmationRequest { get; } = new InteractionRequest<Confirmation>();

        public void notificationCommandExecute()
        {
            Message = "Now notifying...";

            NotificationRequest.Raise(
                new Notification { Title = "タイトル", Content = "コンテンツ" },
                _ => Message = string.Empty );
        }

        private void confirmationCommandExecute()
        {
            Message = "Now confirming...";

            ConfirmationRequest.Raise( 
                new Confirmation { Title = "タイトル", Content = "コンテンツ" },
                ( c ) =>
                {
                    if ( c.Confirmed )
                    {
                        Message = "OK selected";
                    }
                    else
                    {
                        Message = "Cancel selected";
                    }
                } );
        }
    }
}
