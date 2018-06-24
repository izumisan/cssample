using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestApp.NotificationModule.ViewModels
{
    public class NotificationViewModel : BindableBase
    {
        public NotificationViewModel()
            : base()
        {
            NotificationCommand = new DelegateCommand( () => notificationCommandExecute() );
        }

        public DelegateCommand NotificationCommand { get; private set; }

        public InteractionRequest<Notification> NotificationRequest { get; } = new InteractionRequest<Notification>();

        private void notificationCommandExecute()
        {
            this.NotificationRequest.Raise( new Notification
            {
                Title = "タイトル",
                Content = "コンテンツ"
            } );
        }
    }
}
