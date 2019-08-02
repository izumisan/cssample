using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;

namespace InteractionRequestDialog.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
            : base()
        {
            NotificationCommand = new DelegateCommand( () =>
            {
                NotificationRequest.Raise(
                    new Notification
                    {
                        Title = "たいとる",
                        Content = "こんてんつ"
                    } );
            } );

            ConfirmationCommand = new DelegateCommand( () =>
            {
                ConfirmationRequest.Raise(
                    new Confirmation
                    {
                        Title = "たいとる",
                        Content = "こんてんつ"
                    },
                    ( c ) =>
                    {
                        if ( c.Confirmed )
                        {
                            Debug.WriteLine( "selected OK" );
                        }
                        else
                        {
                            Debug.WriteLine( "selected Cancel" );
                        }
                    } );
            } );
        }

        public DelegateCommand NotificationCommand { get; private set; } = null;
        public DelegateCommand ConfirmationCommand { get; private set; } = null;

        public InteractionRequest<Notification> NotificationRequest { get; } = new InteractionRequest<Notification>();
        public InteractionRequest<Confirmation> ConfirmationRequest { get; } = new InteractionRequest<Confirmation>();
    }
}
