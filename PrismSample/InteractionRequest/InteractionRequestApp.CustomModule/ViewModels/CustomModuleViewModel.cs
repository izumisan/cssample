using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestApp.CustomModule.ViewModels
{
    public class CustomModuleViewModel : BindableBase
    {
        public CustomModuleViewModel()
            : base()
        {
            CustomCommand = new DelegateCommand( customCommandExecute );
        }

        private string _message = string.Empty;

        public string Message
        {
            get { return _message; }
            private set { SetProperty( ref _message, value ); }
        }

        public DelegateCommand CustomCommand { get; private set; }

        public InteractionRequest<CustomNotification> CustomNotificationRequest { get; } = new InteractionRequest<CustomNotification>();

        private void customCommandExecute()
        {
            Message = "now editing...";

            CustomNotificationRequest.Raise(
                new CustomNotification { Title = "タイトル" },
                ( n ) =>
                {
                    Message = $"input: { n.Input }";
                } );

        }
    }
}
